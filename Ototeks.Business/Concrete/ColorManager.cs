using FluentValidation.Results;
using Ototeks.Business.Abstract;
using Ototeks.Business.ValidationRules;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities;
using System;
using System.Collections.Generic;

namespace Ototeks.Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IGenericRepository<Color> _colorRepo;

        public ColorManager(IGenericRepository<Color> colorRepo)
        {
            _colorRepo = colorRepo;
        }

        public void Add(Color color)
        {
            // 1. Veriyi Standartlaþtýr
            FormatData(color);

            // 2. Validasyon
            CheckValidation(color);

            // 3. Kurallarý geçtiyse Repository'e gönder
            _colorRepo.Add(color);
        }

        public void Delete(Color color)
        {
            // 1. Validasyon
            var validator = new ColorValidator(_colorRepo);
            validator.ValidateForDeletion(color);

            // 2. Validasyon geçtiyse güvenle sil
            _colorRepo.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorRepo.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorRepo.GetById(id);
        }

        public void Update(Color color)
        {
            // 1. Veriyi Standartlaþtýr
            FormatData(color);

            // 2. Validasyon (Güncelleme için color ID'si ile)
            CheckValidation(color, color.ColorId);

            // 3. Kurallarý geçtiyse Repository'e gönder
            _colorRepo.Update(color);
        }

        // --- YARDIMCI METOTLAR ---

        // Validasyon Metodu
        private void CheckValidation(Color color, int? excludeId = null)
        {
            var validator = new ColorValidator(_colorRepo, excludeId);
            ValidationResult result = validator.Validate(color);

            if (!result.IsValid)
            {
                // Ýlk hatayý fýrlat
                throw new Exception(result.Errors[0].ErrorMessage);
            }
        }

        // Veriyi Temizle
        private static void FormatData(Color color)
        {
            color.ColorName = color.ColorName?.Trim();
        }
    }
}