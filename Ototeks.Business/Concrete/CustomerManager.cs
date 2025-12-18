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
            // Repository'nin hazır metodunu çağır ve sonucu dön (Orders olmadan)
            return _customerRepo.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerRepo.GetById(
                filter: c => c.CustomerId == id
            );
        }

        public void Add(Customer customer)
        {
            _customerRepo.Add(customer);
        }

        public void Update(Customer customer)
        {
            _customerRepo.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _customerRepo.Delete(customer);
        }
    }
}