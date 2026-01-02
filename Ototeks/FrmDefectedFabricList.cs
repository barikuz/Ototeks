using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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

        // Seçili hatalı kalem için
        private DefectedOrderItemViewModel _selectedDefectedItem;
        // Seçili siparişin OrderId'si (expand durumunu korumak için)
        private int? _lastExpandedOrderId;

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
                            QualityLogId = log.LogId, // Silme işlemi için LogId'yi de saklıyoruz
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

                // Eğer daha önce expand edilmiş bir sipariş varsa, onu tekrar expand et
                RestoreExpandedOrder();
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

        /// <summary>
        /// Daha önce expand edilmiş siparişi bulup tekrar expand eder
        /// </summary>
        private void RestoreExpandedOrder()
        {
            if (_lastExpandedOrderId == null)
                return;

            // Tüm satırları tara ve OrderId'si eşleşen satırı bul
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                var row = gridView1.GetRow(i) as DefectedOrderViewModel;
                if (row != null && row.OrderId == _lastExpandedOrderId)
                {
                    // Satırı odakla
                    gridView1.FocusedRowHandle = i;
                    
                    // Master-detail ilişkisini expand et
                    gridView1.SetMasterRowExpanded(i, true);
                    
                    // Satırın görünür olmasını sağla
                    gridView1.MakeRowVisible(i);
                    
                    break;
                }
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

        /// <summary>
        /// Detail view (sipariş kalemleri) için sağ tık menüsü gösterme
        /// </summary>
        private void gridView2_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            var hitInfo = e.HitInfo;

            // Sadece satıra tıklandığında menüyü göster
            if (hitInfo.InRow)
            {
                // Seçili satırı al
                _selectedDefectedItem = view.GetRow(hitInfo.RowHandle) as DefectedOrderItemViewModel;

                if (_selectedDefectedItem != null)
                {
                    // Sil butonunu görünür yap
                    btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    // Hangi siparişin altındaki kalem olduğunu bul ve sakla
                    SaveCurrentExpandedOrder(view);

                    // Menüyü göster
                    popupMenuDetail.ShowPopup(Control.MousePosition);
                }
            }
        }

        /// <summary>
        /// Şu an expand edilmiş siparişin OrderId'sini saklar
        /// </summary>
        private void SaveCurrentExpandedOrder(GridView detailView)
        {
            // Detail view'ın parent row handle'ını al
            int parentRowHandle = detailView.SourceRowHandle;
            
            // Parent view'dan (gridView1) sipariş bilgisini al
            var parentOrder = gridView1.GetRow(parentRowHandle) as DefectedOrderViewModel;
            
            if (parentOrder != null)
            {
                _lastExpandedOrderId = parentOrder.OrderId;
            }
        }

        /// <summary>
        /// Hatalı kalem kaydını sil
        /// </summary>
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_selectedDefectedItem == null)
            {
                XtraMessageBox.Show(
                    "Lütfen silmek istediğiniz hatalı kalemi seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcıdan onay al
            var result = XtraMessageBox.Show(
                $"'{_selectedDefectedItem.FabricName}' kumaşına ait hata kaydını silmek istediğinize emin misiniz?\n\n" +
                $"Hata Türü: {EnumHelper.GetDefectTypeName(_selectedDefectedItem.DefectType)}\n" +
                $"Güven Skoru: %{_selectedDefectedItem.ConfidenceScore:F1}",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                // QualityLog kaydını veritabanından sil
                var qualityLog = _qualityLogRepo.GetById(_selectedDefectedItem.QualityLogId);
                if (qualityLog != null)
                {
                    _qualityLogRepo.Delete(qualityLog);

                    XtraMessageBox.Show(
                        "Hata kaydı başarıyla silindi.",
                        "Başarılı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Listeyi yenile (expand durumunu koruyarak)
                    LoadDefectedOrders();
                }
                else
                {
                    XtraMessageBox.Show(
                        "Hata kaydı bulunamadı.",
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Hata kaydı silinirken bir sorun oluştu: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _selectedDefectedItem = null;
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
        public int QualityLogId { get; set; } // Silme işlemi için QualityLog ID'si
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