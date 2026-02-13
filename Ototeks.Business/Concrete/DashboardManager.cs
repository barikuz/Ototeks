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
        /// Returns the count of orders with Pending status.
        /// </summary>
        public int GetPendingOrderCount()
        {
            var orders = _orderRepo.GetAll();
            return orders.Count(o => o.OrderStatus == OrderStatus.Pending);
        }

        /// <summary>
        /// Returns the count of fabrics below the critical stock threshold.
        /// Default threshold: 50 meters.
        /// </summary>
        public int GetCriticalStockCount(decimal threshold = 50)
        {
            var fabrics = _fabricRepo.GetAll();
            return fabrics.Count(f => f.StockQuantity.HasValue && f.StockQuantity.Value < threshold);
        }

        /// <summary>
        /// Returns the number of distinct customers who have placed orders.
        /// </summary>
        public int GetCustomerWithOrdersCount()
        {
            var orders = _orderRepo.GetAll();

            // Count unique customer IDs, excluding nulls
            return orders
                .Where(o => o.CustomerId.HasValue)
                .Select(o => o.CustomerId.Value)
                .Distinct()
                .Count();
        }

        /// <summary>
        /// Returns the most ordered product types ranked by total quantity.
        /// Groups all order items by their product type name, sums the quantities for each group,
        /// sorts them in descending order, and returns the top N results as a dictionary
        /// mapping product type name to total ordered quantity.
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
                .ToDictionary(x => x.ProductName ?? "Unknown", x => x.TotalQuantity);

            return topProducts;
        }
    }
}
