using Ototeks.Entities;
using System.Collections.Generic;

namespace Ototeks.Business.Abstract
{
    public interface IStockService
    {
        /// <summary>
        /// Calculates the required fabric amounts for the given order items
        /// </summary>
        /// <param name="orderItems">Order items</param>
        /// <returns>Fabric ID and required amount pairs</returns>
        Dictionary<int, decimal> CalculateRequiredFabricAmounts(ICollection<OrderItem> orderItems);

        /// <summary>
        /// Checks whether sufficient stock is available for the given fabric
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <param name="requiredAmount">Required amount</param>
        /// <returns>True if sufficient stock is available</returns>
        bool HasSufficientStock(int fabricId, decimal requiredAmount);

        /// <summary>
        /// Checks stock availability for all fabrics in the order
        /// </summary>
        /// <param name="orderItems">Order items</param>
        /// <returns>Stock shortages (fabric name and shortage amount pairs)</returns>
        Dictionary<string, decimal> CheckStockAvailability(ICollection<OrderItem> orderItems);

        /// <summary>
        /// Deducts the required amounts from fabric stocks after order confirmation
        /// </summary>
        /// <param name="orderItems">Order items</param>
        void DeductStockFromFabrics(ICollection<OrderItem> orderItems);

        /// <summary>
        /// Restores stock for cancelled order items
        /// </summary>
        /// <param name="orderItems">Cancelled order items</param>
        void RestoreStockToFabrics(ICollection<OrderItem> orderItems);
    }
}
