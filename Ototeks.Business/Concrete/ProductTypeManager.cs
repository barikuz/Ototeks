using FluentValidation.Results;
using Ototeks.Business.Abstract;
using Ototeks.Business.ValidationRules;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities;
using System;
using System.Collections.Generic;

namespace Ototeks.Business.Concrete
{
    public class ProductTypeManager : IProductTypeService
    {
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public ProductTypeManager(IGenericRepository<ProductType> productTypeRepo)
        {
            _productTypeRepo = productTypeRepo;
        }

        public void Add(ProductType productType)
        {
            // 1. Veriyi Standartlaştır
            FormatData(productType);

            // 2. Validasyon
            CheckValidation(productType);

            // 3. Kuralları geçtiyse Repository'e gönder
            _productTypeRepo.Add(productType);
        }

        public void Delete(ProductType productType)
        {
            // 1. Validasyon
            var validator = new ProductTypeValidator(_productTypeRepo);
            validator.ValidateForDeletion(productType);

            // 2. Validasyon geçtiyse güvenle sil
            _productTypeRepo.Delete(productType);
        }

        public List<ProductType> GetAll()
        {
            return _productTypeRepo.GetAll();
        }

        public ProductType GetById(int id)
        {
            return _productTypeRepo.GetById(id);
        }

        public void Update(ProductType productType)
        {
            // 1. Veriyi Standartlaştır
            FormatData(productType);

            // 2. Validasyon (Güncelleme için productType ID'si ile)
            CheckValidation(productType, productType.TypeId);

            // 3. Kuralları geçtiyse Repository'e gönder
            _productTypeRepo.Update(productType);
        }

        // --- YARDIMCI METOTLAR ---

        // Validasyon Metodu
        private void CheckValidation(ProductType productType, int? excludeId = null)
        {
            var validator = new ProductTypeValidator(_productTypeRepo, excludeId);
            ValidationResult result = validator.Validate(productType);

            if (!result.IsValid)
            {
                // İlk hatayı fırlat
                throw new Exception(result.Errors[0].ErrorMessage);
            }
        }

        // Veriyi Temizle
        private static void FormatData(ProductType productType)
        {
            productType.TypeName = productType.TypeName?.Trim();
        }
    }
}