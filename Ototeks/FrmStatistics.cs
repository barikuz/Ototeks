using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using Ototeks.UI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Ototeks.UI
{
    public partial class FrmStatistics : DevExpress.XtraEditors.XtraForm
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            try
            {
                LoadMostOrderedProductsPie();
                LoadMostRequiredFabricsBar();
                LoadTopCustomersBarHorizontal();
                LoadQualityControlPassFailPie();
                LoadDefectTypesBar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"İstatistikler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string StripLeadingDigitsAndPunctuation(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Remove leading digits, dots, dashes and whitespace
            return Regex.Replace(input, @"^[\d.\-\s]+", "");
        }

        private void LoadMostOrderedProductsPie()
        {
            // En çok sipariş edilen ürünler (Ürün Tipi bazında adet)
            var orderItemRepo = new GenericRepository<OrderItem>();
            var items = orderItemRepo.GetAll(null, "Type");

            var productGroups = items
                .Where(i => i.Type != null)
                .GroupBy(i => i.Type!.TypeName)
                .Select(g => new { Name = g.Key, Quantity = g.Sum(x => x.Quantity) })
                .OrderByDescending(x => x.Quantity)
                .Take(8)
                .ToList();

            // Görsel ayarlar Designer'da tanımlı, sadece veri ekleme
            var series = chartControl1.Series["Ürünler"];
            if (series != null)
            {
                series.Points.Clear();

                foreach (var p in productGroups)
                {
                    series.Points.Add(new SeriesPoint(p.Name, p.Quantity));
                }

                if (!productGroups.Any())
                {
                    series.Points.Add(new SeriesPoint("Veri Yok", 0));
                }
            }
        }

        private void LoadMostRequiredFabricsBar()
        {
            // En çok ihtiyaç duyulan kumaşlar
            // Gereken miktar = OrderItem.Quantity * ProductType.RequiredFabricAmount
            var orderItemRepo = new GenericRepository<OrderItem>();
            var items = orderItemRepo.GetAll(null, "Type", "Fabric");

            var fabricNeeds = items
                .Where(i => i.Type != null && i.Fabric != null)
                .GroupBy(i => new { i.Fabric!.FabricId, Code = i.Fabric!.FabricCode, Name = (i.Fabric!.FabricName ?? "") })
                .Select(g => new
                {
                    FabricId = g.Key.FabricId,
                    Code = g.Key.Code,
                    Name = g.Key.Name,
                    Required = g.Sum(x => x.Quantity * (x.Type?.RequiredFabricAmount ?? 0m))
                })
                .OrderByDescending(x => x.Required)
                .Take(8)
                .ToList();

            // Görsel ayarlar Designer'da tanımlı, sadece veri ekleme
            var series = chartControl3.Series["Gerekli Kumaş (m)"];
            if (series != null)
            {
                series.Points.Clear();

                foreach (var f in fabricNeeds)
                {
                    // Remove leading KMS from fabric code when displaying
                    var code = f.Code ?? string.Empty;
                    if (code.StartsWith("KMS", StringComparison.OrdinalIgnoreCase))
                    {
                        code = code.Substring(3).TrimStart();
                      }

                    // Also strip leading digits/punctuation from both code and name
                    code = StripLeadingDigitsAndPunctuation(code);
                    var name = StripLeadingDigitsAndPunctuation(f.Name ?? string.Empty);

                    var displayName = string.IsNullOrWhiteSpace(name)
                        ? code
                        : (string.IsNullOrWhiteSpace(code) ? name : $"{code} - {name}");

                    displayName = string.IsNullOrWhiteSpace(displayName) ? "Bilinmeyen Kumaş" : displayName;

                    series.Points.Add(new SeriesPoint(displayName, Convert.ToDouble(f.Required)));
                }

                if (!fabricNeeds.Any())
                {
                    series.Points.Add(new SeriesPoint("Veri Yok", 0));
                }
            }
        }

        private void LoadTopCustomersBarHorizontal()
        {
            // En çok sipariş veren müşteriler (sipariş adedi bazında)
            var orderRepo = new GenericRepository<Order>();
            var orders = orderRepo.GetAll(null, "Customer");

            var customerGroups = orders
                .Where(o => o.Customer != null)
                .GroupBy(o => new { o.Customer!.CustomerId, Name = o.Customer!.CustomerName })
                .Select(g => new { Id = g.Key.CustomerId, Name = g.Key.Name, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(10)
                .ToList();

            // Görsel ayarlar Designer'da tanımlı, sadece veri ekleme
            var series = chartControl4.Series["Sipariş Sayısı"];
            if (series != null)
            {
                series.Points.Clear();

                try
                {
                    foreach (var c in customerGroups)
                    {
                        // SeriesPoint argument must not be null or empty - provide fallback
                        var label = string.IsNullOrWhiteSpace(c.Name) ? $"Müşteri {c.Id}" : c.Name.Trim();
                        series.Points.Add(new SeriesPoint(label, c.Count));
                    }

                    if (!customerGroups.Any())
                    {
                        series.Points.Add(new SeriesPoint("Veri Yok", 0));
                    }
                }
                catch (ArgumentException)
                {
                    // Eğer SeriesPoint eklerken DevExpress bir "argument empty" hatası verirse, fallback göster
                    series.Points.Clear();
                    series.Points.Add(new SeriesPoint("Veri Yok", 0));
                }
            }
        }

        private void LoadQualityControlPassFailPie()
        {
            // AI Kalite Kontrol - Sağlam/Hatalı Dağılımı
            var qualityLogRepo = new GenericRepository<QualityLog>();
            var logs = qualityLogRepo.GetAll();

            // Sağlam (IsDefective = false) ve Hatalı (IsDefective = true) sayılarını hesapla
            int passedCount = logs.Count(q => q.IsDefective == false);
            int failedCount = logs.Count(q => q.IsDefective == true);

            var series = chartControl2.Series["Kalite Durumu"];
            if (series != null)
            {
                series.Points.Clear();

                if (passedCount > 0 || failedCount > 0)
                {
                    // Sağlam olanlar
                    var passedPoint = new SeriesPoint("Sağlam", passedCount);
                    series.Points.Add(passedPoint);

                    // Hatalı olanlar
                    var failedPoint = new SeriesPoint("Hatalı", failedCount);
                    series.Points.Add(failedPoint);

                    // Renkleri manuel ayarla (yeşil: sağlam, kırmızı: hatalı)
                    if (series.View is PieSeriesView pieView)
                    {
                        passedPoint.Color = System.Drawing.Color.FromArgb(92, 184, 92);  // Yeşil
                        failedPoint.Color = System.Drawing.Color.FromArgb(217, 83, 79);  // Kırmızı
                    }
                }
                else
                {
                    series.Points.Add(new SeriesPoint("Veri Yok", 0));
                }
            }
        }

        private void LoadDefectTypesBar()
        {
            // AI Kalite Kontrol - Hata Türleri Dağılımı
            var qualityLogRepo = new GenericRepository<QualityLog>();
            var logs = qualityLogRepo.GetAll(
                q => q.IsDefective == true && q.DefectId != null,
                "Defect"
            );

            // Hata türlerine göre grupla ve say (DefectFree olanları hariç tut)
            var defectGroups = logs
                .Where(q => q.Defect != null && 
                           !string.Equals(q.Defect.DefectName, "DefectFree", StringComparison.OrdinalIgnoreCase))
                .GroupBy(q => q.Defect!.DefectName)
                .Select(g => new { DefectName = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToList();

            var series = chartControl5.Series["Hata Sayısı"];
            if (series != null)
            {
                series.Points.Clear();

                if (defectGroups.Any())
                {
                    foreach (var defect in defectGroups)
                    {
                        // Hata türü ismini Türkçe'ye çevir
                        string displayName = EnumHelper.GetDefectTypeName(defect.DefectName);
                        series.Points.Add(new SeriesPoint(displayName, defect.Count));
                    }
                }
                else
                {
                    series.Points.Add(new SeriesPoint("Veri Yok", 0));
                }
            }
        }
    }
}