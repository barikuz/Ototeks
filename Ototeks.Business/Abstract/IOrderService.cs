using Ototeks.Entities;
using System.Collections.Generic;

namespace Ototeks.Business.Abstract
{
    public interface IOrderService
    {
        // Standart İşlemler
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);

        // Listeleme
        List<Order> GetAll();
        Order GetById(int id);

        // Stok Kontrolü İşlemleri
        /// <summary>
        /// Sipariş vermeden önce stok durumunu kontrol eder
        /// </summary>
        /// <param name="orderItems">Kontrol edilecek sipariş kalemleri</param>
        /// <returns>Stok yetersizliği var mı?</returns>
        Dictionary<string, decimal> CheckOrderStockAvailability(ICollection<OrderItem> orderItems);

        /// <summary>
        /// Belirtilen sipariş kalemleri için gerekli kumaş miktarlarını hesaplar
        /// </summary>
        /// <param name="orderItems">Sipariş kalemleri</param>
        /// <returns>Kumaş adı ve gerekli miktar çiftleri</returns>
        Dictionary<string, decimal> CalculateRequiredFabrics(ICollection<OrderItem> orderItems);
    }
}