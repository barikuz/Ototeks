using Ototeks.Entities;
using System.Collections.Generic;

namespace Ototeks.Business.Abstract
{
    public interface IStockService
    {
        /// <summary>
        /// Belirtilen sipariþ kalemleri için gerekli kumaþ miktarýný hesaplar
        /// </summary>
        /// <param name="orderItems">Sipariþ kalemleri</param>
        /// <returns>Kumaþ ID'si ve gerekli miktar çiftleri</returns>
        Dictionary<int, decimal> CalculateRequiredFabricAmounts(ICollection<OrderItem> orderItems);

        /// <summary>
        /// Belirtilen kumaþ için yeterli stok olup olmadýðýný kontrol eder
        /// </summary>
        /// <param name="fabricId">Kumaþ ID'si</param>
        /// <param name="requiredAmount">Gerekli miktar</param>
        /// <returns>Yeterli stok var mý?</returns>
        bool HasSufficientStock(int fabricId, decimal requiredAmount);

        /// <summary>
        /// Sipariþ için tüm kumaþlarýn stokunu kontrol eder
        /// </summary>
        /// <param name="orderItems">Sipariþ kalemleri</param>
        /// <returns>Stok yetersizlikleri (kumaþ adý ve yetersizlik miktarlarý)</returns>
        Dictionary<string, decimal> CheckStockAvailability(ICollection<OrderItem> orderItems);

        /// <summary>
        /// Sipariþ onaylandýktan sonra kumaþ stoklarýndan gerekli miktarlarý düþer
        /// </summary>
        /// <param name="orderItems">Sipariþ kalemleri</param>
        void DeductStockFromFabrics(ICollection<OrderItem> orderItems);

        /// <summary>
        /// Ýptal edilen sipariþ için stoklarý geri ekler
        /// </summary>
        /// <param name="orderItems">Ýptal edilen sipariþ kalemleri</param>
        void RestoreStockToFabrics(ICollection<OrderItem> orderItems);
    }
}