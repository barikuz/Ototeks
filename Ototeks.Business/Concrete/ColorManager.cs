using Ototeks.Business.Abstract;
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
            // Renk adýný standartlaþtýr
            FormatData(color);

            // Ayný isimde renk var mý kontrol et
            var existingColors = _colorRepo.GetAll();
            var duplicate = existingColors.Find(c => c.ColorName.Equals(color.ColorName, StringComparison.OrdinalIgnoreCase));
            
            if (duplicate != null)
            {
                throw new Exception("Bu renk adý zaten kullanýlýyor!");
            }

            _colorRepo.Add(color);
        }

        public void Delete(Color color)
        {
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
            _colorRepo.Update(color);
        }

        // Yardýmcý Metot: Veriyi Temizle
        private static void FormatData(Color color)
        {
            color.ColorName = color.ColorName?.Trim();
        }
    }
}