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
            // 1. Validasyon
            CheckValidation(order);

            // 2. Veritabanına Kayıt
            _orderRepo.Add(order);
        }

        public void Update(Order order)
        {
            // 1. Validasyon (Güncelleme için order ID'si ile)
            CheckValidation(order, order.OrderId);

            // 2. Veritabanına Kayıt
            _orderRepo.Update(order);
        }

        public void Delete(Order order)
        {
            _orderRepo.Delete(order);
        }

        public List<Order> GetAll()
        {
            return _orderRepo.GetAll(null,
                "Customer",               // 1. Müşteriyi getir
                "OrderItems",             // 2. Kalemleri getir
                "OrderItems.Fabric",      // 3. Kalemlerin içindeki Kumaşı da getir (İşte aradığımız bu!)
                "OrderItems.Type"         // 4. Kalemlerin içindeki Ürün Tipini de getir
            );
        }

        public Order GetById(int id)
        {
            // Include'larla birlikte siparişi getir (OrderItems ve ilişkili verilerle)
            return _orderRepo.GetById(
                filter: o => o.OrderId == id,
                includeProperties: new string[]
                {
                    "Customer",               // Müşteriyi getir
                    "OrderItems",             // Kalemleri getir
                    "OrderItems.Fabric",      // Kalemlerin içindeki Kumaşı getir
                    "OrderItems.Type"         // Kalemlerin içindeki Ürün Tipini getir
                }
            );
        }

        // --- YARDIMCI METOT ---
        private void CheckValidation(Order order, int? excludeId = null)
        {
            var validator = new OrderValidator(_orderRepo, excludeId);
            var result = validator.Validate(order);

            if (!result.IsValid)
            {
                // İlk hatayı yakala ve fırlat
                throw new Exception(result.Errors[0].ErrorMessage);
            }
        }
    }
}