using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
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
            this.Load += FrmStatistics_Load;
        }

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            try
            {
                LoadMostOrderedProductsPie();
                LoadMostRequiredFabricsBar();
                LoadTopCustomersBarHorizontal();
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

            chartControl1.Series.Clear();

            var series = new Series("Ürünler", ViewType.Pie);
            series.LegendTextPattern = "{A}";
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.Label.TextPattern = "{A}: {V}";

            foreach (var p in productGroups)
            {
                series.Points.Add(new SeriesPoint(p.Name, p.Quantity));
            }

            if (!productGroups.Any())
            {
                series.Points.Add(new SeriesPoint("Veri Yok", 0));
            }

            chartControl1.Series.Add(series);
            chartControl1.PaletteName = "Office 2013";

            // Başlık ekle
            chartControl1.Titles.Clear();
            var title1 = new ChartTitle() { Text = "En Çok Sipariş Edilen Ürünler", Dock = ChartTitleDockStyle.Top, Font = new Font("Tahoma", 11F, FontStyle.Bold) };
            chartControl1.Titles.Add(title1);

            // Pie legend keep default (usually right) - ensure visibility and vertical orientation
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl1.Legend.Direction = LegendDirection.TopToBottom;
            chartControl1.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.RightOutside;
            chartControl1.Legend.AlignmentVertical = LegendAlignmentVertical.Center;
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

            chartControl3.Series.Clear();

            var series = new Series("Gerekli Kumaş (m)", ViewType.Bar);
            series.ArgumentScaleType = ScaleType.Qualitative;
            series.LegendTextPattern = "{A}"; // Her sütun için lejantta argüman göster

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

            // Make each bar a different color
            if (series.View is DevExpress.XtraCharts.BarSeriesView barView)
            {
                barView.ColorEach = true;
                barView.BarWidth = 0.8;
            }

            chartControl3.Series.Add(series);
            chartControl3.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl3.PaletteName = "Office 2013";

            // Show legend on the right (default-like)
            chartControl3.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl3.Legend.Direction = LegendDirection.TopToBottom;
            chartControl3.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.RightOutside;
            chartControl3.Legend.AlignmentVertical = LegendAlignmentVertical.Center;

            // Görünümü iyileştir
            if (chartControl3.Diagram is XYDiagram xy)
            {
                xy.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
                xy.AxisX.Label.Angle = -45;
                xy.AxisX.Label.TextPattern = "{A}";
            }

            // Başlık ekle
            chartControl3.Titles.Clear();
            var title2 = new ChartTitle() { Text = "En Çok İhtiyaç Duyulan Kumaşlar (Metre)", Dock = ChartTitleDockStyle.Top, Font = new Font("Tahoma", 11F, FontStyle.Bold) };
            chartControl3.Titles.Add(title2);
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

            chartControl4.Series.Clear();

            var series = new Series("Sipariş Sayısı", ViewType.Bar);
            series.ArgumentScaleType = ScaleType.Qualitative;
            series.LegendTextPattern = "{A}"; // point argument in legend

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

                // Make each bar a different color
                if (series.View is DevExpress.XtraCharts.BarSeriesView barView)
                {
                    barView.ColorEach = true;
                    barView.BarWidth = 0.8;
                }

                chartControl4.Series.Add(series);
                chartControl4.PaletteName = "Office 2013";
                chartControl4.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

                // Show legend on the right (default-like)
                chartControl4.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
                chartControl4.Legend.Direction = LegendDirection.TopToBottom;
                chartControl4.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.RightOutside;
                chartControl4.Legend.AlignmentVertical = LegendAlignmentVertical.Center;

                // YATAY BAR yapmak için Diagram.Rotated = true
                if (chartControl4.Diagram is XYDiagram xy)
                {
                    xy.Rotated = true;
                    xy.AxisX.Title.Text = "Sipariş Sayısı";
                    xy.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                    xy.AxisY.Label.ResolveOverlappingOptions.AllowHide = false;
                }

                // Başlık ekle
                chartControl4.Titles.Clear();
                var title3 = new ChartTitle() { Text = "En Çok Sipariş Veren Müşteriler", Dock = ChartTitleDockStyle.Top, Font = new Font("Tahoma", 11F, FontStyle.Bold) };
                chartControl4.Titles.Add(title3);
            }
            catch (ArgumentException)
            {
                // Eğer SeriesPoint eklerken DevExpress bir "argument empty" hatası verirse, fallback göster
                chartControl4.Series.Clear();
                var fallback = new Series("Sipariş Sayısı", ViewType.Bar);
                fallback.Points.Add(new SeriesPoint("Veri Yok", 0));
                chartControl4.Series.Add(fallback);

                chartControl4.Titles.Clear();
                chartControl4.Titles.Add(new ChartTitle() { Text = "En Çok Sipariş Veren Müşteriler", Dock = ChartTitleDockStyle.Top, Font = new Font("Tahoma", 11F, FontStyle.Bold) });
            }
        }
    }
}