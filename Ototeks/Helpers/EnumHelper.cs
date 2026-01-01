using Ototeks.Entities;
using System;
using System.Collections.Generic;

namespace Ototeks.UI.Helpers
{
    /// <summary>
    /// Enum deðerlerini kullanýcý dostu metinlere dönüþtürmek için yardýmcý sýnýf
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Kumaþ hata türleri için Ýngilizce-Türkçe eþleþtirme sözlüðü
        /// </summary>
        private static readonly Dictionary<string, string> DefectTypeTranslations = new(StringComparer.OrdinalIgnoreCase)
        {
            { "DefectFree", "Hatasýz" },
            { "Hole", "Delik" },
            { "Stain", "Leke" },
            { "WeavingError", "Dokuma Hatasý" },
            { "BrokenStitch", "Kopuk Dikiþ" },
        };

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

        /// <summary>
        /// Hata türü ismini Türkçe'ye çevirir
        /// </summary>
        /// <param name="defectType">Ýngilizce hata türü ismi</param>
        /// <returns>Türkçe hata türü ismi</returns>
        public static string GetDefectTypeName(string defectType)
        {
            if (string.IsNullOrEmpty(defectType))
                return "-";

            // Sözlükte varsa çeviriyi döndür
            if (DefectTypeTranslations.TryGetValue(defectType, out string translation))
                return translation;

            // Sözlükte yoksa orijinal deðeri döndür
            return defectType;
        }

        /// <summary>
        /// Hata türünün "hatasýz/iyi" anlamýna gelip gelmediðini kontrol eder
        /// </summary>
        /// <param name="defectType">Hata türü ismi</param>
        /// <returns>Hatasýz ise true</returns>
        public static bool IsDefectFree(string defectType)
        {
            if (string.IsNullOrEmpty(defectType))
                return false;
            
            return defectType == "DefectFree";
        }
    }
}
