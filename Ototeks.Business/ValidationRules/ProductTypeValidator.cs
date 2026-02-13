using FluentValidation;
using Ototeks.Entities;
using Ototeks.DataAccess.Abstract;
using System.Linq;
using System;

namespace Ototeks.Business.ValidationRules
{
    public class ProductTypeValidator : AbstractValidator<ProductType>
    {
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly int? _currentTypeId;

        public ProductTypeValidator(IGenericRepository<ProductType> productTypeRepo, int? currentTypeId = null)
        {
            _productTypeRepo = productTypeRepo;
            _currentTypeId = currentTypeId;

            // Rule 1: Product type name cannot be empty
            RuleFor(x => x.TypeName)
                .NotEmpty().WithMessage("Product type name cannot be empty!")
                .MinimumLength(2).WithMessage("Product type name must be at least 2 characters!");

            // Rule 2: Product type name must be unique
            RuleFor(x => x.TypeName)
                .Must(BeUniqueName).WithMessage("This product type name is already registered in the system!");

            // Rule 3: Required fabric amount must be greater than 0
            RuleFor(x => x.RequiredFabricAmount)
                .GreaterThan(0).WithMessage("Required fabric amount must be greater than 0!");
        }

        // Uniqueness check
        private bool BeUniqueName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
                return true;

            var dbList = _productTypeRepo.GetAll();
            var existingType = dbList.FirstOrDefault(x =>
                x.TypeName != null && x.TypeName.Equals(typeName, StringComparison.OrdinalIgnoreCase));

            if (existingType == null)
            {
                return true; // Not found, unique
            }

            // If updating and the found record is the same record, it's fine
            if (_currentTypeId.HasValue && existingType.TypeId == _currentTypeId.Value)
            {
                return true;
            }

            return false; // Exists in another record
        }

        // Deletion validation
        public void ValidateForDeletion(ProductType productType)
        {
            // Check if this product type is used in any order items
            var typeWithOrderItems = _productTypeRepo.GetById(pt => pt.TypeId == productType.TypeId, "OrderItems");

            if (typeWithOrderItems?.OrderItems != null && typeWithOrderItems.OrderItems.Any())
            {
                throw new Exception($"Product type '{productType.TypeName}' cannot be deleted! It is used in {typeWithOrderItems.OrderItems.Count} order item(s).");
            }
        }
    }
}
