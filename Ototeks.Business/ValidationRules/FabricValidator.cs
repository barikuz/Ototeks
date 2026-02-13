using FluentValidation;
using Ototeks.Entities;
using Ototeks.DataAccess.Abstract;
using System.Linq;

namespace Ototeks.Business.ValidationRules
{
    public class FabricValidator : AbstractValidator<Fabric>
    {
        private readonly IGenericRepository<Fabric> _fabricRepo;
        private readonly int? _currentFabricId; // ID of the record being updated

        public FabricValidator(IGenericRepository<Fabric> fabricRepo, int? currentFabricId = null)
        {
            _fabricRepo = fabricRepo;
            _currentFabricId = currentFabricId;

            // Rule 1: Fabric code cannot be empty and must start with "FAB-"
            RuleFor(x => x.FabricCode)
                .NotEmpty().WithMessage("Fabric code cannot be empty!")
                .Must(arg => arg != null && arg.StartsWith("FAB-")).WithMessage("Fabric code must start with FAB-!");

            // Rule 2: Fabric code must be unique
            RuleFor(x => x.FabricCode)
                .Must(BeUniqueCode).WithMessage("This fabric code is already registered in the system!");

            // Rule 3: Fabric name cannot be empty
            RuleFor(x => x.FabricName)
                .NotEmpty().WithMessage("Fabric name cannot be empty!")
                .MinimumLength(3).WithMessage("Fabric name must be at least 3 characters.");

            // Rule 4: Color must be selected
            RuleFor(x => x.ColorId)
                .NotNull().WithMessage("A color must be selected!")
                .GreaterThan(0).WithMessage("A valid color must be selected!");

            // Rule 5: Stock quantity must be greater than 0
            RuleFor(x => x.StockQuantity)
                .NotNull().WithMessage("Stock quantity cannot be empty!")
                .GreaterThan(0).WithMessage("Stock quantity must be greater than 0!");
        }

        // Uniqueness check for fabric code
        private bool BeUniqueCode(string fabricCode)
        {
            var dbList = _fabricRepo.GetAll();
            var existingFabric = dbList.FirstOrDefault(x => x.FabricCode == fabricCode);

            if (existingFabric == null)
            {
                return true; // Not found, unique
            }

            // If updating and the found record is the same record, it's fine
            if (_currentFabricId.HasValue && existingFabric.FabricId == _currentFabricId.Value)
            {
                return true; // Same record, no conflict
            }

            return false; // Exists in another record, not unique
        }

        // Deletion validation
        public void ValidateForDeletion(Fabric fabric)
        {
            // Check if this fabric is used in any order items
            var fabricWithOrders = _fabricRepo.GetById(f => f.FabricId == fabric.FabricId, "OrderItems");

            if (fabricWithOrders?.OrderItems != null && fabricWithOrders.OrderItems.Any())
            {
                throw new System.Exception($"Fabric '{fabric.FabricCode}' cannot be deleted! It is used in {fabricWithOrders.OrderItems.Count} order item(s).");
            }
        }
    }
}
