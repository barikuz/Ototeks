using FluentValidation;
using Ototeks.Entities;
using Ototeks.DataAccess.Abstract;
using System.Linq;
using System;

namespace Ototeks.Business.ValidationRules
{
    public class ColorValidator : AbstractValidator<Color>
    {
        private readonly IGenericRepository<Color> _colorRepo;
        private readonly int? _currentColorId;

        public ColorValidator(IGenericRepository<Color> colorRepo, int? currentColorId = null)
        {
            _colorRepo = colorRepo;
            _currentColorId = currentColorId;

            // Rule 1: Color name cannot be empty
            RuleFor(x => x.ColorName)
                .NotEmpty().WithMessage("Color name cannot be empty!")
                .MinimumLength(2).WithMessage("Color name must be at least 2 characters!");

            // Rule 2: Color name must be unique
            RuleFor(x => x.ColorName)
                .Must(BeUniqueName).WithMessage("This color name is already registered in the system!");
        }

        // Uniqueness check
        private bool BeUniqueName(string colorName)
        {
            if (string.IsNullOrEmpty(colorName))
                return true;

            var dbList = _colorRepo.GetAll();
            var existingColor = dbList.FirstOrDefault(x =>
                x.ColorName != null && x.ColorName.Equals(colorName, StringComparison.OrdinalIgnoreCase));

            if (existingColor == null)
            {
                return true; // Not found, unique
            }

            // If updating and the found record is the same record, it's fine
            if (_currentColorId.HasValue && existingColor.ColorId == _currentColorId.Value)
            {
                return true;
            }

            return false; // Exists in another record
        }

        // Deletion validation
        public void ValidateForDeletion(Color color)
        {
            // Check if this color is used in any fabrics
            var colorWithFabrics = _colorRepo.GetById(c => c.ColorId == color.ColorId, "Fabrics");

            if (colorWithFabrics?.Fabrics != null && colorWithFabrics.Fabrics.Any())
            {
                throw new Exception($"Color '{color.ColorName}' cannot be deleted! It is used in {colorWithFabrics.Fabrics.Count} fabric(s).");
            }
        }
    }
}
