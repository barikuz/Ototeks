using FluentValidation.Results;
using Ototeks.Business.Abstract;
using Ototeks.Business.ValidationRules;
using Ototeks.DataAccess.Abstract;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ototeks.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IStockService _stockService;

        public OrderManager(IGenericRepository<Order> orderRepo)
        {
            _orderRepo = orderRepo;
            
            // StockService'i initialize et
            var fabricRepo = new GenericRepository<Fabric>();
            var productTypeRepo = new GenericRepository<ProductType>();
            _stockService = new StockManager(fabricRepo, productTypeRepo);
        }

        public void Add(Order order)
        {
            // 1. Validasyon
            CheckValidation(order);

            // 2. Stok Kontrolü
            CheckStockAvailability(order.OrderItems);

            // 3. Veritabanına Kayıt
            _orderRepo.Add(order);

            // 4. Stoktan Düşürme
            _stockService.DeductStockFromFabrics(order.OrderItems);
        }

        public void Update(Order order)
        {
            // Önce eski sipariş bilgilerini al
            var existingOrder = _orderRepo.GetById(
                filter: o => o.OrderId == order.OrderId,
                includeProperties: new string[] { "OrderItems" }
            );

            if (existingOrder == null)
                throw new Exception("Güncellenecek sipariş bulunamadı!");

            // 1. Validasyon (Güncelleme için order ID'si ile)
            CheckValidation(order, order.OrderId);

            // 2. Eski siparişin stokunu geri ekle
            if (existingOrder.OrderItems != null && existingOrder.OrderItems.Any())
            {
                _stockService.RestoreStockToFabrics(existingOrder.OrderItems);
            }

            // 3. Yeni sipariş için stok kontrolü
            CheckStockAvailability(order.OrderItems);

            // 4. Veritabanına güncelleme kayıt
            _orderRepo.Update(order);

            // 5. Yeni sipariş için stoktan düşürme
            _stockService.DeductStockFromFabrics(order.OrderItems);
        }

        public void Delete(Order order)
        {
            // Silinecek siparişi detaylarıyla al
            var orderWithItems = _orderRepo.GetById(
                filter: o => o.OrderId == order.OrderId,
                includeProperties: new string[] { "OrderItems" }
            );

            if (orderWithItems == null)
                throw new Exception("Silinecek sipariş bulunamadı!");

            // 1. Stokları geri ekle
            if (orderWithItems.OrderItems != null && orderWithItems.OrderItems.Any())
            {
                _stockService.RestoreStockToFabrics(orderWithItems.OrderItems);
            }

            // 2. Siparişi sil
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

        public Dictionary<string, decimal> CheckOrderStockAvailability(ICollection<OrderItem> orderItems)
        {
            return _stockService.CheckStockAvailability(orderItems);
        }

        public Dictionary<string, decimal> CalculateRequiredFabrics(ICollection<OrderItem> orderItems)
        {
            var fabricRequirements = _stockService.CalculateRequiredFabricAmounts(orderItems);
            var result = new Dictionary<string, decimal>();

            var fabricRepo = new GenericRepository<Fabric>();
            var fabricManager = new FabricManager(fabricRepo);

            foreach (var requirement in fabricRequirements)
            {
                var fabric = fabricManager.GetById(requirement.Key);
                if (fabric != null)
                {
                    string fabricDisplayName = $"{fabric.FabricCode} - {fabric.FabricName}";
                    result[fabricDisplayName] = requirement.Value;
                }
            }

            return result;
        }

        // --- YARDIMCI METOTLAR ---
        
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

        private void CheckStockAvailability(ICollection<OrderItem> orderItems)
        {
            if (orderItems == null || !orderItems.Any())
                return;

            // Stok yetersizliklerini kontrol et
            var stockInsufficiencies = _stockService.CheckStockAvailability(orderItems);

            if (stockInsufficiencies.Any())
            {
                var errorMessage = new StringBuilder();
                errorMessage.AppendLine("Sipariş verilemiyor! Aşağıdaki kumaşlarda yeterli stok bulunmuyor:");
                errorMessage.AppendLine();

                foreach (var insufficiency in stockInsufficiencies)
                {
                    errorMessage.AppendLine($"• {insufficiency.Key}: {insufficiency.Value:F2} metre eksik");
                }

                throw new Exception(errorMessage.ToString());
            }
        }
    }
}