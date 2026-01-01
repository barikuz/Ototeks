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
    /// Kalite kontrol iþlemlerini yöneten manager sýnýfý
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
        /// Kumaþ görüntüsünü ML modeli ile analiz eder
        /// </summary>
        public QualityAnalysisResult AnalyzeFabricImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                throw new ArgumentException("Geçerli bir görüntü dosyasý seçilmelidir.");
            }

            try
            {
                // Görüntüyü byte array olarak oku
                byte[] imageBytes = File.ReadAllBytes(imagePath);

                // Model input oluþtur
                var input = new FabricDefectModel.ModelInput
                {
                    ImageSource = imageBytes
                };

                // Model ile tahmin yap
                var prediction = FabricDefectModel.Predict(input);

                // Tüm etiketlerin skorlarýný al
                var allScores = FabricDefectModel.GetSortedScoresWithLabels(prediction);
                var topResult = allScores.First();

                // Sonucu oluþtur
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
                throw new Exception($"Görüntü analizi sýrasýnda hata oluþtu: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Kalite kontrol kaydý ekler
        /// </summary>
        public void AddQualityLog(QualityLog qualityLog)
        {
            if (qualityLog == null)
                throw new ArgumentNullException(nameof(qualityLog));

            if (qualityLog.OrderItemId == null || qualityLog.OrderItemId <= 0)
                throw new ArgumentException("Geçerli bir sipariþ kalemi seçilmelidir.");

            // Varsayýlan deðerleri ayarla
            qualityLog.InspectionDate ??= DateTime.Now;

            _qualityLogRepo.Add(qualityLog);
        }

        /// <summary>
        /// Tüm hata tiplerini getirir
        /// </summary>
        public List<DefectType> GetAllDefectTypes()
        {
            return _defectTypeRepo.GetAll();
        }

        /// <summary>
        /// Hata adýna göre DefectType getirir
        /// </summary>
        public DefectType GetDefectTypeByName(string defectName)
        {
            if (string.IsNullOrEmpty(defectName))
                return null;

            var defectTypes = _defectTypeRepo.GetAll();
            
            // Büyük/küçük harf duyarsýz arama
            return defectTypes.FirstOrDefault(d => 
                d.DefectName.Equals(defectName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Etiketin "iyi/hatasýz" anlamýna gelip gelmediðini kontrol eder
        /// </summary>
        private bool IsGoodLabel(string label)
        {
            if (string.IsNullOrEmpty(label))
                return false;

            return label == "DefectFree";
        }
    }
}
