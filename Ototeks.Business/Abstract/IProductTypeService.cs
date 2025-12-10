using Ototeks.Entities;
using System.Collections.Generic;

namespace Ototeks.Business.Abstract
{
    public interface IProductTypeService
    {
        List<ProductType> GetAll();
    }
}