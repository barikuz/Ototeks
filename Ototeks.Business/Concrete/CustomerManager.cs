using FluentValidation.Results;
using Ototeks.Business.Abstract;
using Ototeks.Business.ValidationRules;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities;
using System;
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
            // 1. Veriyi Standartlaştır
            FormatData(customer);

            // 2. Validasyon
            CheckValidation(customer);

            // 3. Kuralları geçtiyse Repository'e gönder
            _customerRepo.Add(customer);
        }

        public void Update(Customer customer)
        {
            // 1. Veriyi Standartlaştır
            FormatData(customer);

            // 2. Validasyon (Güncelleme için customer ID'si ile)
            CheckValidation(customer, customer.CustomerId);

            // 3. Kuralları geçtiyse Repository'e gönder
            _customerRepo.Update(customer);
        }

        public void Delete(Customer customer)
        {
            // 1. Validasyon
            var validator = new CustomerValidator(_customerRepo);
            validator.ValidateForDeletion(customer);

            // 2. Validasyon geçtiyse güvenle sil
            _customerRepo.Delete(customer);
        }

        // --- YARDIMCI METOTLAR ---
        
        // Validasyon Metodu
        private void CheckValidation(Customer customer, int? excludeId = null)
        {
            var validator = new CustomerValidator(_customerRepo, excludeId);
            ValidationResult result = validator.Validate(customer);

            if (!result.IsValid)
            {
                // İlk hatayı fırlat
                throw new Exception(result.Errors[0].ErrorMessage);
            }
        }

        // Veriyi Temizle
        private static void FormatData(Customer customer)
        {
            customer.CustomerName = customer.CustomerName?.Trim();
            customer.Phone = customer.Phone?.Trim();
            customer.Email = customer.Email?.Trim().ToLower();
            customer.Address = customer.Address?.Trim();
        }
    }
}