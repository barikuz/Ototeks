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
                XtraMessageBox.Show($"Error loading statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Most ordered products (by Product Type count)
            var orderItemRepo = new GenericRepository<OrderItem>();
            var items = orderItemRepo.GetAll(null, "Type");

            var productGroups = items
                .Where(i => i.Type != null)
                .GroupBy(i => i.Type!.TypeName)
                .Select(g => new { Name = g.Key, Quantity = g.Sum(x => x.Quantity) })
                .OrderByDescending(x => x.Quantity)
                .Take(8)
                .ToList();

            // Visual settings defined in Designer, only adding data
            var series = chartControl1.Series["Products"];
            if (series != null)
            {
                series.Points.Clear();

                foreach (var p in productGroups)
                {
                    series.Points.Add(new SeriesPoint(p.Name, p.Quantity));
                }

                if (!productGroups.Any())
                {
                    series.Points.Add(new SeriesPoint("No Data", 0));
                }
            }
        }

        private void LoadMostRequiredFabricsBar()
        {
            // Most required fabrics
            // Required amount = OrderItem.Quantity * ProductType.RequiredFabricAmount
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

            // Visual settings defined in Designer, only adding data
            var series = chartControl3.Series["Required Fabric (m)"];
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

                    displayName = string.IsNullOrWhiteSpace(displayName) ? "Unknown Fabric" : displayName;

                    series.Points.Add(new SeriesPoint(displayName, Convert.ToDouble(f.Required)));
                }

                if (!fabricNeeds.Any())
                {
                    series.Points.Add(new SeriesPoint("No Data", 0));
                }
            }
        }

        private void LoadTopCustomersBarHorizontal()
        {
            // Top customers (by order count)
            var orderRepo = new GenericRepository<Order>();
            var orders = orderRepo.GetAll(null, "Customer");

            var customerGroups = orders
                .Where(o => o.Customer != null)
                .GroupBy(o => new { o.Customer!.CustomerId, Name = o.Customer!.CustomerName })
                .Select(g => new { Id = g.Key.CustomerId, Name = g.Key.Name, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(10)
                .ToList();

            // Visual settings defined in Designer, only adding data
            var series = chartControl4.Series["Order Count"];
            if (series != null)
            {
                series.Points.Clear();

                try
                {
                    foreach (var c in customerGroups)
                    {
                        // SeriesPoint argument must not be null or empty - provide fallback
                        var label = string.IsNullOrWhiteSpace(c.Name) ? $"Customer {c.Id}" : c.Name.Trim();
                        series.Points.Add(new SeriesPoint(label, c.Count));
                    }

                    if (!customerGroups.Any())
                    {
                        series.Points.Add(new SeriesPoint("No Data", 0));
                    }
                }
                catch (ArgumentException)
                {
                    // If DevExpress throws an "argument empty" error when adding SeriesPoint, show fallback
                    series.Points.Clear();
                    series.Points.Add(new SeriesPoint("No Data", 0));
                }
            }
        }

        private void LoadQualityControlPassFailPie()
        {
            // AI Quality Control - Pass/Fail Distribution
            var qualityLogRepo = new GenericRepository<QualityLog>();
            var logs = qualityLogRepo.GetAll();

            // Calculate passed (IsDefective = false) and defective (IsDefective = true) counts
            int passedCount = logs.Count(q => q.IsDefective == false);
            int failedCount = logs.Count(q => q.IsDefective == true);

            var series = chartControl2.Series["Quality Status"];
            if (series != null)
            {
                series.Points.Clear();

                if (passedCount > 0 || failedCount > 0)
                {
                    // Passed items
                    var passedPoint = new SeriesPoint("Passed", passedCount);
                    series.Points.Add(passedPoint);

                    // Defective items
                    var failedPoint = new SeriesPoint("Defective", failedCount);
                    series.Points.Add(failedPoint);

                    // Set colors manually (green: passed, red: defective)
                    if (series.View is PieSeriesView pieView)
                    {
                        passedPoint.Color = System.Drawing.Color.FromArgb(92, 184, 92);  // Green
                        failedPoint.Color = System.Drawing.Color.FromArgb(217, 83, 79);  // Red
                    }
                }
                else
                {
                    series.Points.Add(new SeriesPoint("No Data", 0));
                }
            }
        }

        private void LoadDefectTypesBar()
        {
            // AI Quality Control - Defect Type Distribution
            var qualityLogRepo = new GenericRepository<QualityLog>();
            var logs = qualityLogRepo.GetAll(
                q => q.IsDefective == true && q.DefectId != null,
                "Defect"
            );

            // Group by defect type and count (exclude DefectFree entries)
            var defectGroups = logs
                .Where(q => q.Defect != null &&
                           !string.Equals(q.Defect.DefectName, "DefectFree", StringComparison.OrdinalIgnoreCase))
                .GroupBy(q => q.Defect!.DefectName)
                .Select(g => new { DefectName = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToList();

            var series = chartControl5.Series["Defect Count"];
            if (series != null)
            {
                series.Points.Clear();

                if (defectGroups.Any())
                {
                    foreach (var defect in defectGroups)
                    {
                        // Get display name for defect type
                        string displayName = EnumHelper.GetDefectTypeName(defect.DefectName);
                        series.Points.Add(new SeriesPoint(displayName, defect.Count));
                    }
                }
                else
                {
                    series.Points.Add(new SeriesPoint("No Data", 0));
                }
            }
        }
    }
}
