using FluentValidation;
using Ototeks.DataAccess.Abstract;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Linq;

namespace Ototeks.Business.ValidationRules
{
    public class OrderValidator : AbstractValidator<Order>
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly int? _currentOrderId; // ID of the record being updated

        public OrderValidator(IGenericRepository<Order> orderRepository, int? currentOrderId = null)
        {
            _orderRepository = orderRepository;
            _currentOrderId = currentOrderId;

            // 1. Order Number Validation
            RuleFor(x => x.OrderNumber)
                .NotEmpty().WithMessage("Order number cannot be empty!")
                .Must(arg => arg != null && arg.StartsWith("ORD-", StringComparison.OrdinalIgnoreCase))
                    .WithMessage("Order number must start with 'ORD-'!")
                .Must(BeUniqueOrderNumber).WithMessage("This order number is already in use!");

            // 2. Order Date Validation
            RuleFor(x => x.OrderDate)
                .NotNull().WithMessage("Please select an order date!")
                .Must(date => date.Value != default(DateTime))
                .WithMessage("Please select a valid order date!");

            // 3. Customer Selection Validation
            // CustomerID must be greater than 0 since it is an int
            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("Please select a customer!");

            // 4. Order Items List Validation
            RuleFor(x => x.OrderItems)
                .NotNull().WithMessage("Order items list cannot be empty!")
                .Must(items => items.Count > 0)
                .WithMessage("You must add at least one item to the order!");

            // 5. Detailed Item Validation
            // Iterates through each item in the list and validates individually using ChildRules,
            // which scopes validation rules for each item under the parent order's validation context.
            RuleForEach(x => x.OrderItems).ChildRules(items =>
            {
                // Product Type Validation (correct check for nullable int)
                items.RuleFor(x => x.TypeId)
                     .NotNull().WithMessage("There are rows with no 'Product Type' selected!");

                // Fabric Validation (correct check for nullable int)
                items.RuleFor(x => x.FabricId)
                     .NotNull().WithMessage(item => $"'Fabric Type' is not selected for '{GetProductTypeName(item)}'!");

                // Quantity Validation
                items.RuleFor(x => x.Quantity)
                     .GreaterThan(0)
                     .WithMessage(item => $"You must enter a QUANTITY for '{GetProductTypeName(item)}'!");
            });
        }

        // Helper method to retrieve the product type name
        private string GetProductTypeName(OrderItem item)
        {
            if (item.TypeId.HasValue)
            {
                var productTypeRepo = new GenericRepository<ProductType>();
                var productType = productTypeRepo.GetById(item.TypeId.Value);
                return productType?.TypeName ?? "Unknown Product";
            }

            return "Not Selected";
        }

        // Order number uniqueness check
        private bool BeUniqueOrderNumber(Order order, string orderNumber)
        {
            var existingOrders = _orderRepository.GetAll();
            var existingOrder = existingOrders.FirstOrDefault(x =>
                x.OrderNumber.Equals(orderNumber, StringComparison.OrdinalIgnoreCase));

            if (existingOrder == null)
            {
                return true; // Not found, unique
            }

            // If updating and the found record is the same record, it's fine
            if (_currentOrderId.HasValue && existingOrder.OrderId == _currentOrderId.Value)
            {
                return true; // Same record, no conflict
            }

            return false; // Exists in another record, not unique
        }
    }
}
