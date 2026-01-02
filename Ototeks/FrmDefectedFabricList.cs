using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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

namespace Ototeks.UI
{
    public partial class FrmDefectedFabricList : DevExpress.XtraEditors.XtraForm
    {
        private GenericRepository<Order> _orderRepo;
        private GenericRepository<QualityLog> _qualityLogRepo;

        public FrmDefectedFabricList()
        {
            InitializeComponent();
        }

        private void FrmDefectedFabricList_Load(object sender, EventArgs e)
        {
            LoadDefectedOrders();
            SetupGrid();
        }

        private void LoadDefectedOrders()
        {
            try
            {
                _orderRepo = new GenericRepository<Order>();
                _qualityLogRepo = new GenericRepository<QualityLog>();

                // Tüm hatalı kalite loglarını al (Include ile ilişkili verileri de çek)
                var defectedLogs = _qualityLogRepo.GetAll(
                    q => q.IsDefective == true,
                    "OrderItem",
                    "OrderItem.Order",
                    "OrderItem.Order.Customer",
                    "OrderItem.Fabric",
                    "OrderItem.Type",
                    "Defect"
                );

                // Hatalı kalemi olan siparişleri grupla
                var ordersWithDefects = defectedLogs
                    .Where(q => q.OrderItem?.Order != null)
                    .GroupBy(q => q.OrderItem.Order.OrderId)
                    .Select(g => g.First().OrderItem.Order)
                    .ToList();

                // Her sipariş için hatalı kalem bilgilerini oluştur
                var defectedOrderViewModels = new List<DefectedOrderViewModel>();

                foreach (var order in ordersWithDefects)
                {
                    var defectedOrderVM = new DefectedOrderViewModel
                    {
                        OrderId = order.OrderId,
                        OrderNumber = order.OrderNumber,
                        CustomerName = order.Customer?.CustomerName ?? "-",
                        OrderDate = order.OrderDate,
                        DueDate = order.DueDate,
                        OrderStatus = order.OrderStatus,
                        DefectedItems = new List<DefectedOrderItemViewModel>()
                    };

                    // Bu siparişe ait hatalı kalemleri bul
                    var orderDefectedLogs = defectedLogs
                        .Where(q => q.OrderItem?.OrderId == order.OrderId)
                        .ToList();

                    // Hatalı kalem view model'lerini oluştur
                    foreach (var log in orderDefectedLogs)
                    {
                        var item = log.OrderItem;
                        if (item == null) continue;

                        defectedOrderVM.DefectedItems.Add(new DefectedOrderItemViewModel
                        {
                            OrderItemId = item.OrderItemId,
                            FabricName = item.Fabric?.FabricName ?? "-",
                            TypeName = item.Type?.TypeName ?? "-",
                            Quantity = item.Quantity,
                            CurrentStage = item.CurrentStage,
                            // Yeni kolonlar - Hata bilgileri
                            DefectType = log.Defect?.DefectName ?? "-",
                            ConfidenceScore = log.ConfidenceScore ?? 0,
                            AnalysisDate = log.InspectionDate
                        });
                    }

                    defectedOrderViewModels.Add(defectedOrderVM);
                }

                gridControl1.DataSource = defectedOrderViewModels;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Hatalı kumaşlar yüklenirken hata oluştu: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SetupGrid()
        {
            // Grid'e Master-Detail özelliği ver
            gridView1.ActivateMasterDetail<DefectedOrderViewModel>(
                "DefectedItems",
                order => order.DefectedItems);
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            // Ana tablodaki OrderStatus kolonunu Türkçe göster
            if (e.Column.FieldName == "OrderStatus" && e.Value is OrderStatus status)
            {
                e.DisplayText = EnumHelper.GetOrderStatusName(status);
            }
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            // Alt tablodaki CurrentStage kolonunu Türkçe göster
            if (e.Column.FieldName == "CurrentStage" && e.Value is OrderStatus status)
            {
                e.DisplayText = EnumHelper.GetOrderStatusName(status);
            }
            // Güven skorunu yüzde olarak göster
            else if (e.Column.FieldName == "ConfidenceScore" && e.Value is double score)
            {
                e.DisplayText = $"%{score:F1}";
            }
            // Hata türünü Türkçe göster
            else if (e.Column.FieldName == "DefectType" && e.Value is string defectType)
            {
                e.DisplayText = EnumHelper.GetDefectTypeName(defectType);
            }
        }
    }

    #region ViewModels

    /// <summary>
    /// Hatalı sipariş için ViewModel - Master Grid'de gösterilecek
    /// </summary>
    public class DefectedOrderViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DueDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// Bu siparişe ait hatalı kalemler - Detail Grid'de gösterilecek
        /// </summary>
        public List<DefectedOrderItemViewModel> DefectedItems { get; set; }
    }

    /// <summary>
    /// Hatalı sipariş kalemi için ViewModel - Detail Grid'de gösterilecek
    /// </summary>
    public class DefectedOrderItemViewModel
    {
        public int OrderItemId { get; set; }
        public string FabricName { get; set; }
        public string TypeName { get; set; }
        public int Quantity { get; set; }
        public OrderStatus CurrentStage { get; set; }

        // Hata bilgileri - Yeni kolonlar
        public string DefectType { get; set; }      // Hata Türü
        public double ConfidenceScore { get; set; } // Güven Skoru
        public DateTime? AnalysisDate { get; set; } // Analiz Tarihi
    }

    #endregion
}