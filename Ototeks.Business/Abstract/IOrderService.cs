using Ototeks.Entities;
using System.Collections.Generic;

namespace Ototeks.Business.Abstract
{
    public interface IOrderService
    {
        // Standard Operations
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);

        // Listing
        List<Order> GetAll();
        Order GetById(int id);

        // Stock Control Operations

        /// <summary>
        /// Checks stock availability before placing an order
        /// </summary>
        /// <param name="orderItems">Order items to check</param>
        /// <returns>Fabric name and shortage amount pairs (empty if sufficient)</returns>
        Dictionary<string, decimal> CheckOrderStockAvailability(ICollection<OrderItem> orderItems);

        /// <summary>
        /// Calculates the required fabric amounts for the given order items
        /// </summary>
        /// <param name="orderItems">Order items</param>
        /// <returns>Fabric name and required amount pairs</returns>
        Dictionary<string, decimal> CalculateRequiredFabrics(ICollection<OrderItem> orderItems);
    }
}
