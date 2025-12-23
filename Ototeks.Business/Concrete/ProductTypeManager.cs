using Ototeks.Business.Abstract;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities;
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

        public List<ProductType> GetAll()
        {
            return _productTypeRepo.GetAll();
        }

        public ProductType GetById(int id)
        {
            return _productTypeRepo.GetById(id);
        }
    }
}