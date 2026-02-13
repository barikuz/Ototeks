using Ototeks.Business.Abstract;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities;
using Ototeks_Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ototeks.Business.Concrete
{
    /// <summary>
    /// Manager class that handles quality control operations.
    /// </summary>
    public class QualityControlManager : IQualityControlService
    {
        private readonly IGenericRepository<QualityLog> _qualityLogRepo;
        private readonly IGenericRepository<DefectType> _defectTypeRepo;

        public QualityControlManager(
            IGenericRepository<QualityLog> qualityLogRepo,
            IGenericRepository<DefectType> defectTypeRepo)
        {
            _qualityLogRepo = qualityLogRepo;
            _defectTypeRepo = defectTypeRepo;
        }

        /// <summary>
        /// Analyzes a fabric image using the ML model for defect detection.
        /// </summary>
        public QualityAnalysisResult AnalyzeFabricImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                throw new ArgumentException("A valid image file must be selected.");
            }

            try
            {
                byte[] imageBytes = File.ReadAllBytes(imagePath);

                var input = new FabricDefectModel.ModelInput
                {
                    ImageSource = imageBytes
                };

                var prediction = FabricDefectModel.Predict(input);

                var allScores = FabricDefectModel.GetSortedScoresWithLabels(prediction);
                var topResult = allScores.First();

                var result = new QualityAnalysisResult
                {
                    DefectType = prediction.PredictedLabel,
                    ConfidenceScore = Math.Round(topResult.Value * 100, 2),
                    IsDefective = !IsGoodLabel(prediction.PredictedLabel)
                };

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred during image analysis: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Adds a quality control log entry.
        /// </summary>
        public void AddQualityLog(QualityLog qualityLog)
        {
            if (qualityLog == null)
                throw new ArgumentNullException(nameof(qualityLog));

            if (qualityLog.OrderItemId == null || qualityLog.OrderItemId <= 0)
                throw new ArgumentException("A valid order item must be selected.");

            qualityLog.InspectionDate ??= DateTime.Now;

            _qualityLogRepo.Add(qualityLog);
        }

        /// <summary>
        /// Returns all defect types.
        /// </summary>
        public List<DefectType> GetAllDefectTypes()
        {
            return _defectTypeRepo.GetAll();
        }

        /// <summary>
        /// Returns a DefectType by its name (case-insensitive).
        /// </summary>
        public DefectType GetDefectTypeByName(string defectName)
        {
            if (string.IsNullOrEmpty(defectName))
                return null;

            var defectTypes = _defectTypeRepo.GetAll();

            return defectTypes.FirstOrDefault(d =>
                d.DefectName.Equals(defectName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Checks whether the label indicates a defect-free result.
        /// </summary>
        private bool IsGoodLabel(string label)
        {
            if (string.IsNullOrEmpty(label))
                return false;

            return label == "DefectFree";
        }
    }
}
