using Ototeks.Entities;
using System;
using System.Collections.Generic;

namespace Ototeks.UI.Helpers
{
    /// <summary>
    /// Helper class for converting enum values to user-friendly text
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Dictionary mapping fabric defect type keys to their display names
        /// </summary>
        private static readonly Dictionary<string, string> DefectTypeTranslations = new(StringComparer.OrdinalIgnoreCase)
        {
            { "DefectFree", "Defect Free" },
            { "Hole", "Hole" },
            { "Stain", "Stain" },
            { "WeavingError", "Weaving Error" },
            { "BrokenStitch", "Broken Stitch" },
        };

        /// <summary>
        /// Returns the display name for a given OrderStatus enum value
        /// </summary>
        /// <param name="status">OrderStatus enum value</param>
        /// <returns>Display name of the order status</returns>
        public static string GetOrderStatusName(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Pending => "Order Received",
                OrderStatus.Cutting => "Cutting",
                OrderStatus.Sewing => "Sewing",
                OrderStatus.Ironing => "Ironing & Packaging",
                OrderStatus.QualityControl => "Quality Control",
                OrderStatus.Completed => "Completed",
                OrderStatus.Cancelled => "Cancelled",
                _ => "Unknown"
            };
        }

        /// <summary>
        /// Returns the display name for a given defect type key
        /// </summary>
        /// <param name="defectType">Defect type key</param>
        /// <returns>Display name of the defect type</returns>
        public static string GetDefectTypeName(string defectType)
        {
            if (string.IsNullOrEmpty(defectType))
                return "-";

            // If found in the dictionary, return the translated name
            if (DefectTypeTranslations.TryGetValue(defectType, out string translation))
                return translation;

            // If not found in the dictionary, return the original value
            return defectType;
        }

        /// <summary>
        /// Checks whether the given defect type means "defect-free / good quality"
        /// </summary>
        /// <param name="defectType">Defect type name</param>
        /// <returns>True if defect-free</returns>
        public static bool IsDefectFree(string defectType)
        {
            if (string.IsNullOrEmpty(defectType))
                return false;

            return defectType == "DefectFree";
        }
    }
}
