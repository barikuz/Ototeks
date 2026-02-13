using FluentValidation.Results;
using Ototeks.Business.Abstract;
using Ototeks.Business.ValidationRules;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities;
using System;
using System.Collections.Generic;

namespace Ototeks.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly IGenericRepository<Customer> _customerRepo;

        public CustomerManager(IGenericRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public List<Customer> GetAll()
        {
            return _customerRepo.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerRepo.GetById(
                filter: c => c.CustomerId == id
            );
        }

        public void Add(Customer customer)
        {
            FormatData(customer);
            CheckValidation(customer);
            _customerRepo.Add(customer);
        }

        public void Update(Customer customer)
        {
            FormatData(customer);
            CheckValidation(customer, customer.CustomerId);
            _customerRepo.Update(customer);
        }

        public void Delete(Customer customer)
        {
            var validator = new CustomerValidator(_customerRepo);
            validator.ValidateForDeletion(customer);
            _customerRepo.Delete(customer);
        }

        // --- HELPER METHODS ---

        private void CheckValidation(Customer customer, int? excludeId = null)
        {
            var validator = new CustomerValidator(_customerRepo, excludeId);
            ValidationResult result = validator.Validate(customer);

            if (!result.IsValid)
            {
                throw new Exception(result.Errors[0].ErrorMessage);
            }
        }

        private static void FormatData(Customer customer)
        {
            customer.CustomerName = customer.CustomerName?.Trim();
            customer.Phone = customer.Phone?.Trim();
            customer.Email = customer.Email?.Trim().ToLower();
            customer.Address = customer.Address?.Trim();
        }
    }
}
