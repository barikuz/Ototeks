using Ototeks.Entities;
using System.Collections.Generic;

namespace Ototeks.Business.Abstract
{
    public interface IProductTypeService
    {
        void Add(ProductType productType);
        void Update(ProductType productType);
        void Delete(ProductType productType);
        List<ProductType> GetAll();
        ProductType GetById(int id);
    }
}