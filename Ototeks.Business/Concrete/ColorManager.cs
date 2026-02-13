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
            FormatData(color);
            CheckValidation(color);
            _colorRepo.Add(color);
        }

        public void Delete(Color color)
        {
            var validator = new ColorValidator(_colorRepo);
            validator.ValidateForDeletion(color);
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
            FormatData(color);
            CheckValidation(color, color.ColorId);
            _colorRepo.Update(color);
        }

        // --- HELPER METHODS ---

        private void CheckValidation(Color color, int? excludeId = null)
        {
            var validator = new ColorValidator(_colorRepo, excludeId);
            ValidationResult result = validator.Validate(color);

            if (!result.IsValid)
            {
                throw new Exception(result.Errors[0].ErrorMessage);
            }
        }

        private static void FormatData(Color color)
        {
            color.ColorName = color.ColorName?.Trim();
        }
    }
}
