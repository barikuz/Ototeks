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

            // 2. MODERN VALİDASYON
            var validator = new FabricValidator(_fabricRepo);
            ValidationResult result = validator.Validate(fabric);

            if (!result.IsValid)
            {
                // İlk hatayı fırlat
                throw new Exception(result.Errors[0].ErrorMessage);
            }

            // Kuralları geçtiyse Repository'e gönder
            _fabricRepo.Add(fabric);
        }

        public void Delete(Fabric fabric)
        {
            _fabricRepo.Delete(fabric);
        }

        public List<Fabric> GetAll()
        {
            return _fabricRepo.GetAll();
        }

        public Fabric GetById(int id)
        {
            return _fabricRepo.GetById(id);
        }

        public void Update(Fabric fabric)
        {
            // Stok eksiye düşerse güncelleme yapma
            if (fabric.StockQuantity < 0)
            {
                throw new Exception("Stok miktarı 0'dan küçük olamaz!");
            }

            FormatData(fabric);
            _fabricRepo.Update(fabric);
        }

        // Yardımcı Metot 1: Veriyi Temizle
        private static void FormatData(Fabric fabric)
        {
            fabric.FabricCode = fabric.FabricCode?.Trim().ToUpper();

            fabric.FabricName = fabric.FabricName?.Trim();
        }
    }
}