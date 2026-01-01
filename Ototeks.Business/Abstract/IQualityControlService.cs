using Ototeks.Entities;
using System.Collections.Generic;

namespace Ototeks.Business.Abstract
{
    /// <summary>
    /// Kalite kontrol iþlemleri için servis arayüzü
    /// </summary>
    public interface IQualityControlService
    {
        /// <summary>
        /// Kumaþ görüntüsünü analiz eder ve hata tespiti yapar
        /// </summary>
        /// <param name="imagePath">Analiz edilecek görüntünün yolu</param>
        /// <returns>Analiz sonucu</returns>
        QualityAnalysisResult AnalyzeFabricImage(string imagePath);

        /// <summary>
        /// Kalite kontrol kaydý oluþturur
        /// </summary>
        /// <param name="qualityLog">Kaydedilecek kalite log bilgisi</param>
        void AddQualityLog(QualityLog qualityLog);

        /// <summary>
        /// Tüm hata tiplerini getirir
        /// </summary>
        List<DefectType> GetAllDefectTypes();

        /// <summary>
        /// Hata adýna göre DefectType getirir
        /// </summary>
        DefectType GetDefectTypeByName(string defectName);
    }

    /// <summary>
    /// Kalite analiz sonucu modeli
    /// </summary>
    public class QualityAnalysisResult
    {
        /// <summary>
        /// Hata tespit edildi mi?
        /// </summary>
        public bool IsDefective { get; set; }

        /// <summary>
        /// Tespit edilen hata tipi (null ise hata yok)
        /// </summary>
        public string DefectType { get; set; }

        /// <summary>
        /// Model güven skoru (0-100 arasý yüzde)
        /// </summary>
        public double ConfidenceScore { get; set; }

        /// <summary>
        /// Ham skor deðeri (0-1 arasý)
        /// </summary>
        public float RawScore { get; set; }
    }
}
