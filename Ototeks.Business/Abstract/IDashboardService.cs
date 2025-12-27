using System.Collections.Generic;

namespace Ototeks.Business.Abstract
{
    public interface IDashboardService
    {
        /// <summary>
        /// Bekleyen sipariþ sayýsýný getirir (Pending, Cutting, Sewing, Ironing, QualityControl durumundakiler)
        /// </summary>
        int GetPendingOrderCount();

        /// <summary>
        /// Kritik stok seviyesindeki kumaþ sayýsýný getirir
        /// </summary>
        /// <param name="threshold">Kritik stok eþiði (varsayýlan: 50 metre)</param>
        int GetCriticalStockCount(decimal threshold = 50);

        /// <summary>
        /// Sipariþ vermiþ toplam müþteri sayýsýný getirir (tekil müþteriler)
        /// </summary>
        int GetCustomerWithOrdersCount();

        /// <summary>
        /// En çok sipariþ edilen ürün tiplerini getirir
        /// </summary>
        /// <param name="topCount">Kaç ürün getirileceði</param>
        /// <returns>Ürün tipi adý ve toplam sipariþ adedi</returns>
        Dictionary<string, int> GetTopOrderedProducts(int topCount = 5);
    }
}
