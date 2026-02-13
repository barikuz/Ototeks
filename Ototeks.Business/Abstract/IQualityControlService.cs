using Ototeks.Entities;
using System.Collections.Generic;

namespace Ototeks.Business.Abstract
{
    /// <summary>
    /// Service interface for quality control operations
    /// </summary>
    public interface IQualityControlService
    {
        /// <summary>
        /// Analyzes a fabric image and performs defect detection
        /// </summary>
        /// <param name="imagePath">Path to the image to analyze</param>
        /// <returns>Analysis result</returns>
        QualityAnalysisResult AnalyzeFabricImage(string imagePath);

        /// <summary>
        /// Creates a quality control log entry
        /// </summary>
        /// <param name="qualityLog">Quality log information to save</param>
        void AddQualityLog(QualityLog qualityLog);

        /// <summary>
        /// Gets all defect types
        /// </summary>
        List<DefectType> GetAllDefectTypes();

        /// <summary>
        /// Gets a DefectType by its name
        /// </summary>
        DefectType GetDefectTypeByName(string defectName);
    }

    /// <summary>
    /// Quality analysis result model
    /// </summary>
    public class QualityAnalysisResult
    {
        /// <summary>
        /// Whether a defect was detected
        /// </summary>
        public bool IsDefective { get; set; }

        /// <summary>
        /// Detected defect type (null if no defect)
        /// </summary>
        public string DefectType { get; set; }

        /// <summary>
        /// Model confidence score (percentage, 0-100)
        /// </summary>
        public double ConfidenceScore { get; set; }

        /// <summary>
        /// Raw score value (0-1 range)
        /// </summary>
        public float RawScore { get; set; }
    }
}
