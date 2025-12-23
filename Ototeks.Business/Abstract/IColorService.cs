using Ototeks.Entities;
using System.Collections.Generic;

namespace Ototeks.Business.Abstract
{
    public interface IColorService
    {
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
        List<Color> GetAll();
        Color GetById(int id);
    }
}