using Ototeks.Business.Abstract;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities;
using System.Collections.Generic;

namespace Ototeks.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        // Veritabanı işlerini yapacak yardımcı (Repository)
        private readonly IGenericRepository<Customer> _customerRepo;

        // "Bana bir müşteri repository'si ver, ben onunla çalışacağım" diyoruz.
        public CustomerManager(IGenericRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public List<Customer> GetAll()
        {
            // Repository'nin hazır metodunu çağır ve sonucu dön.
            return _customerRepo.GetAll();
        }
    }
}