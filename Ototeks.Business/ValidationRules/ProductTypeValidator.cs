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

            // Kural 1: "Ürün tipi adý boþ olamaz"
            RuleFor(x => x.TypeName)
                .NotEmpty().WithMessage("Ürün tipi adý boþ olamaz!")
                .MinimumLength(2).WithMessage("Ürün tipi adý en az 2 karakter olmalýdýr!");

            // Kural 2: "Ürün tipi adý benzersiz olmalý"
            RuleFor(x => x.TypeName)
                .Must(BeUniqueName).WithMessage("Bu ürün tipi adý zaten sistemde kayýtlý!");

            // Kural 3: "Gerekli kumaþ miktarý 0'dan büyük olmalý"
            RuleFor(x => x.RequiredFabricAmount)
                .GreaterThan(0).WithMessage("Gerekli kumaþ miktarý 0'dan büyük olmalýdýr!");
        }

        // Benzersizlik Kontrolü
        private bool BeUniqueName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
                return true;

            var dbList = _productTypeRepo.GetAll();
            var existingType = dbList.FirstOrDefault(x => 
                x.TypeName != null && x.TypeName.Equals(typeName, StringComparison.OrdinalIgnoreCase));
            
            if (existingType == null)
            {
                return true; // Yok, benzersiz
            }
            
            // Güncelleme modundaysak ve bulunan kayýt ayný kayýtsa sorun yok
            if (_currentTypeId.HasValue && existingType.TypeId == _currentTypeId.Value)
            {
                return true;
            }
            
            return false; // Baþka kayýtta var
        }

        // Silme Kontrolü Metodu
        public void ValidateForDeletion(ProductType productType)
        {
            // Bu ürün tipinin sipariþ kalemlerinde kullanýlýp kullanýlmadýðýný kontrol et
            var typeWithOrderItems = _productTypeRepo.GetById(pt => pt.TypeId == productType.TypeId, "OrderItems");
            
            if (typeWithOrderItems?.OrderItems != null && typeWithOrderItems.OrderItems.Any())
            {
                throw new Exception($"'{productType.TypeName}' ürün tipi silinemez! Bu ürün tipi {typeWithOrderItems.OrderItems.Count} adet sipariþ kaleminde kullanýlmaktadýr.");
            }
        }
    }
}
