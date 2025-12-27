using Ototeks.Business.Abstract;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Ototeks.Business.Concrete
{
    public class DashboardManager : IDashboardService
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<Fabric> _fabricRepo;
        private readonly IGenericRepository<OrderItem> _orderItemRepo;

        public DashboardManager(
            IGenericRepository<Order> orderRepo,
            IGenericRepository<Fabric> fabricRepo,
            IGenericRepository<OrderItem> orderItemRepo)
        {
            _orderRepo = orderRepo;
            _fabricRepo = fabricRepo;
            _orderItemRepo = orderItemRepo;
        }

        /// <summary>
        /// Bekleyen sipariþ sayýsýný getirir (Sadece OrderStatus.Pending olanlar)
        /// </summary>
        public int GetPendingOrderCount()
        {
            var orders = _orderRepo.GetAll();
            return orders.Count(o => o.OrderStatus == OrderStatus.Pending);
        }

        /// <summary>
        /// Kritik stok seviyesindeki kumaþ sayýsýný getirir
        /// Varsayýlan eþik: 50 metre
        /// </summary>
        public int GetCriticalStockCount(decimal threshold = 50)
        {
            var fabrics = _fabricRepo.GetAll();
            return fabrics.Count(f => f.StockQuantity.HasValue && f.StockQuantity.Value < threshold);
        }

        /// <summary>
        /// Sipariþ vermiþ tekil müþteri sayýsýný getirir
        /// </summary>
        public int GetCustomerWithOrdersCount()
        {
            var orders = _orderRepo.GetAll();
            
            // Benzersiz müþteri ID'lerini say (CustomerId null olmayanlar)
            return orders
                .Where(o => o.CustomerId.HasValue)
                .Select(o => o.CustomerId.Value)
                .Distinct()
                .Count();
        }

        /// <summary>
        /// En çok sipariþ edilen ürün tiplerini getirir
        /// </summary>
        public Dictionary<string, int> GetTopOrderedProducts(int topCount = 5)
        {
            var orderItems = _orderItemRepo.GetAll(null, "Type");

            var topProducts = orderItems
                .Where(oi => oi.Type != null)
                .GroupBy(oi => oi.Type!.TypeName)
                .Select(g => new { ProductName = g.Key, TotalQuantity = g.Sum(oi => oi.Quantity) })
                .OrderByDescending(x => x.TotalQuantity)
                .Take(topCount)
                .ToDictionary(x => x.ProductName ?? "Bilinmiyor", x => x.TotalQuantity);

            return topProducts;
        }
    }
}
