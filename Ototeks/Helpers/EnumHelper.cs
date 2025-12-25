using Ototeks.Entities;
using System;

namespace Ototeks.UI.Helpers
{
    /// <summary>
    /// Enum deðerlerini kullanýcý dostu metinlere dönüþtürmek için yardýmcý sýnýf
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// OrderStatus enum deðerini Türkçe aþama ismini döndürür
        /// </summary>
        /// <param name="status">OrderStatus enum deðeri</param>
        /// <returns>Aþama ismi (Türkçe)</returns>
        public static string GetOrderStatusName(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Pending => "Sipariþ Alýndý",
                OrderStatus.Cutting => "Kesimhane",
                OrderStatus.Sewing => "Dikim Atölyesi",
                OrderStatus.Ironing => "Ütü & Paket",
                OrderStatus.QualityControl => "Kalite Kontrol",
                OrderStatus.Completed => "Tamamlandý",
                OrderStatus.Cancelled => "Ýptal Edildi",
                _ => "Bilinmeyen"
            };
        }
    }
}
