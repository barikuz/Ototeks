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

            // Kural 1: "Renk adý boþ olamaz"
            RuleFor(x => x.ColorName)
                .NotEmpty().WithMessage("Renk adý boþ olamaz!")
                .MinimumLength(2).WithMessage("Renk adý en az 2 karakter olmalýdýr!");

            // Kural 2: "Renk adý benzersiz olmalý"
            RuleFor(x => x.ColorName)
                .Must(BeUniqueName).WithMessage("Bu renk adý zaten sistemde kayýtlý!");
        }

        // Benzersizlik Kontrolü
        private bool BeUniqueName(string colorName)
        {
            if (string.IsNullOrEmpty(colorName))
                return true;

            var dbList = _colorRepo.GetAll();
            var existingColor = dbList.FirstOrDefault(x => 
                x.ColorName != null && x.ColorName.Equals(colorName, StringComparison.OrdinalIgnoreCase));
            
            if (existingColor == null)
            {
                return true; // Yok, benzersiz
            }
            
            // Güncelleme modundaysak ve bulunan kayýt ayný kayýtsa sorun yok
            if (_currentColorId.HasValue && existingColor.ColorId == _currentColorId.Value)
            {
                return true;
            }
            
            return false; // Baþka kayýtta var
        }

        // Silme Kontrolü Metodu
        public void ValidateForDeletion(Color color)
        {
            // Bu rengin kumaþlarda kullanýlýp kullanýlmadýðýný kontrol et
            var colorWithFabrics = _colorRepo.GetById(c => c.ColorId == color.ColorId, "Fabrics");
            
            if (colorWithFabrics?.Fabrics != null && colorWithFabrics.Fabrics.Any())
            {
                throw new Exception($"'{color.ColorName}' rengi silinemez! Bu renk {colorWithFabrics.Fabrics.Count} adet kumaþta kullanýlmaktadýr.");
            }
        }
    }
}
