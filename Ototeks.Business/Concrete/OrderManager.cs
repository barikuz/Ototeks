using FluentValidation.Results;
using Ototeks.Business.Abstract;
using Ototeks.Business.ValidationRules;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities;
using System;
using System.Collections.Generic;

namespace Ototeks.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepo;

        public OrderManager(IGenericRepository<Order> orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public void Add(Order order)
        {
            // 1. Validasyon (FluentValidation)
            var validator = new OrderValidator();
            ValidationResult result = validator.Validate(order);

            if (!result.IsValid)
            {
                throw new Exception(result.Errors[0].ErrorMessage);
            }

            // 2. Veritabanına Kayıt
            _orderRepo.Add(order);
        }

        public void Update(Order order)
        {
            // Güncelleme validasyonu
            var validator = new OrderValidator();
            ValidationResult result = validator.Validate(order);

            if (!result.IsValid) throw new Exception(result.Errors[0].ErrorMessage);

            _orderRepo.Update(order);
        }

        public void Delete(Order order)
        {
            // Siparişi silerken, veritabanı ayarlarında "Cascade Delete" varsa
            // kalemler de silinir. Yoksa hata alabilirsin.
            _orderRepo.Delete(order);
        }

        public List<Order> GetAll()
        {
            return _orderRepo.GetAll();
        }

        public Order GetById(int id)
        {
            return _orderRepo.GetById(id);
        }
    }
}