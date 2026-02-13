using System.Collections.Generic;

namespace Ototeks.Business.Abstract
{
    public interface IDashboardService
    {
        /// <summary>
        /// Gets the count of pending orders (in Pending, Cutting, Sewing, Ironing, or QualityControl status)
        /// </summary>
        int GetPendingOrderCount();

        /// <summary>
        /// Gets the count of fabrics at critical stock level
        /// </summary>
        /// <param name="threshold">Critical stock threshold (default: 50 meters)</param>
        int GetCriticalStockCount(decimal threshold = 50);

        /// <summary>
        /// Gets the total count of unique customers who have placed orders
        /// </summary>
        int GetCustomerWithOrdersCount();

        /// <summary>
        /// Gets the most ordered product types
        /// </summary>
        /// <param name="topCount">Number of products to retrieve</param>
        /// <returns>Product type name and total order quantity pairs</returns>
        Dictionary<string, int> GetTopOrderedProducts(int topCount = 5);
    }
}
