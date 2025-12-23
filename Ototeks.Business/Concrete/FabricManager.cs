using FluentValidation.Results;
using Ototeks.Business.Abstract;
using Ototeks.Business.ValidationRules;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ototeks.Business.Concrete
{
    public class FabricManager : IFabricService
    {

        private readonly IGenericRepository<Fabric> _fabricRepo;

        public FabricManager(IGenericRepository<Fabric> fabricRepo)
        {
            _fabricRepo = fabricRepo;
        }

        public void Add(Fabric fabric)
        {
            // 1. Veriyi Standartlaştır
            FormatData(fabric);

            // 2. Validasyon
            CheckValidation(fabric);

            // 3. Kuralları geçtiyse Repository'e gönder
            _fabricRepo.Add(fabric);
        }

        public void Delete(Fabric fabric)
        {
            // 1. Validasyon
            var validator = new FabricValidator(_fabricRepo);
            validator.ValidateForDeletion(fabric);

            // 2. Validasyon geçtiyse güvenle sil
            _fabricRepo.Delete(fabric);
        }

        public List<Fabric> GetAll()
        {
            return _fabricRepo.GetAll(null, "Color");
        }

        public Fabric GetById(int id)
        {
            return _fabricRepo.GetById(id);
        }

        public void Update(Fabric fabric)
        {
            // 1. Veriyi Standartlaştır
            FormatData(fabric);

            // 2. Validasyon (Güncelleme için fabric ID'si ile)
            CheckValidation(fabric, fabric.FabricId);

            // 3. Kuralları geçtiyse Repository'e gönder
            _fabricRepo.Update(fabric);
        }

        // --- YARDIMCI METOTLAR ---
        
        // Validasyon Metodu
        private void CheckValidation(Fabric fabric, int? excludeId = null)
        {
            var validator = new FabricValidator(_fabricRepo, excludeId);
            ValidationResult result = validator.Validate(fabric);

            if (!result.IsValid)
            {
                // İlk hatayı fırlat
                throw new Exception(result.Errors[0].ErrorMessage);
            }
        }

        // Veriyi Temizle
        private static void FormatData(Fabric fabric)
        {
            fabric.FabricCode = fabric.FabricCode?.Trim().ToUpper();

            fabric.FabricName = fabric.FabricName?.Trim();
        }
    }
}