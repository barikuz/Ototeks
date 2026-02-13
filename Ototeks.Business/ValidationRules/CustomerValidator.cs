using FluentValidation;
using Ototeks.Entities;
using Ototeks.DataAccess.Abstract;
using System.Linq;
using System;

namespace Ototeks.Business.ValidationRules
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        private readonly IGenericRepository<Customer> _customerRepo;
        private readonly int? _currentCustomerId; // ID of the record being updated

        public CustomerValidator(IGenericRepository<Customer> customerRepo, int? currentCustomerId = null)
        {
            _customerRepo = customerRepo;
            _currentCustomerId = currentCustomerId;

            // Rule 1: Customer name cannot be empty and must be unique
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Customer name cannot be empty!")
                .Must(customerName => IsUnique(customerName, c => c.CustomerName))
                .WithMessage("This customer name is already registered in the system!");

            // Rule 2: Phone cannot be empty, format and uniqueness check
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number cannot be empty!")
                .Matches(@"^[\+]?[1-9][\d]{0,15}$")
                .WithMessage("Please enter a valid phone number!")
                .Must(phone => IsUnique(phone, c => c.Phone))
                .WithMessage("This phone number is already registered in the system!");

            // Rule 3: Email cannot be empty, format and uniqueness check
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email address cannot be empty!")
                .EmailAddress().WithMessage("Please enter a valid email address!")
                .Must(email => IsUnique(email, c => c.Email))
                .WithMessage("This email address is already registered in the system!");

            // Rule 4: Address cannot be empty
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address cannot be empty!");

        }

        // Generic uniqueness check
        private bool IsUnique(string? value, Func<Customer, string?> propertySelector)
        {
            if (string.IsNullOrEmpty(value))
                return true; // Skip uniqueness check for empty values

            var dbList = _customerRepo.GetAll();
            var existingCustomer = dbList.FirstOrDefault(x =>
            {
                var propertyValue = propertySelector(x);
                return propertyValue != null && propertyValue.Equals(value, StringComparison.OrdinalIgnoreCase);
            });

            if (existingCustomer == null)
            {
                return true; // Not found, unique
            }

            // If updating and the found record is the same record, it's fine
            if (_currentCustomerId.HasValue && existingCustomer.CustomerId == _currentCustomerId.Value)
            {
                return true; // Same record, no conflict
            }

            return false; // Exists in another record, not unique
        }

        // Deletion validation
        public void ValidateForDeletion(Customer customer)
        {
            // Check if this customer has any orders
            var customerWithOrders = _customerRepo.GetById(c => c.CustomerId == customer.CustomerId, "Orders");

            if (customerWithOrders?.Orders != null && customerWithOrders.Orders.Any())
            {
                throw new System.Exception($"Customer '{customer.CustomerName}' cannot be deleted! This customer has {customerWithOrders.Orders.Count} order(s).");
            }
        }
    }
}
