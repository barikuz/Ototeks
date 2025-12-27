using DevExpress.Images;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using Ototeks.Helpers;
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
    public partial class FrmOrderList : DevExpress.XtraEditors.XtraForm
    {
        private OrderManager _manager;
        private GenericRepository<Order> _repo;
        private ListFormHelper<Order> _uiHelper;

        // Filtreleme için
        private bool _showOnlyPending = false;

        public FrmOrderList()
        {
            InitializeComponent();
            InitializeHelper();
        }

        /// <summary>
        /// Filtrelenmiş sipariş listesi için constructor
        /// </summary>
        /// <param name="showOnlyPending">True ise sadece bekleyen siparişleri gösterir</param>
        public FrmOrderList(bool showOnlyPending) : this()
        {
            _showOnlyPending = showOnlyPending;
            
            if (_showOnlyPending)
            {
                this.Text = "Bekleyen Siparişler";
            }
        }

        private void InitializeHelper()
        {
            _uiHelper = new ListFormHelper<Order>(
                gridView1,
                sagTikMenu,
                btnAdd,
                btnUpdate,
                btnDelete);

            // Data provider'ı set et
            _uiHelper.SetDataProvider(GetOrderData);
        }

        private List<Order> GetOrderData()
        {
            // 1. Manager'ı Oluştur (Her çağrıda yeni instance)
            _repo = new GenericRepository<Order>();
            _manager = new OrderManager(_repo);

            // 2. Verileri Çek (Include ile dolu dolu geliyor)
            var orders = _manager.GetAll();

            // 3. Filtre uygula
            if (_showOnlyPending)
            {
                orders = orders
                    .Where(o => o.OrderStatus == OrderStatus.Pending) // Sadece "Sipariş Alındı" durumundakiler
                    .OrderBy(o => o.DueDate ?? DateTime.MaxValue) // Teslim tarihi en yakın olan üstte (null olanlar en sonda)
                    .ToList();
            }

            return orders;
        }

        private void FrmOrderList_Load(object sender, EventArgs e)
        {
            RefreshData();
            SetupGrid();
        }

        private void SetupGrid()
        {
            // Grid'e Master-Detail özelliği ver. İlişki adı 'OrderItems' olsun. 
            // Listeyi bulmak için de siparişin içindeki .OrderItems özelliğine bak.
            gridView1.ActivateMasterDetail<Order>("OrderItems", order => order.OrderItems);
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
        }

        public void RefreshData()
        {
            _uiHelper.RefreshData();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            _uiHelper.HandlePopupMenuShowing(e);
            
            // Seçili siparişe göre "İptal Et" / "Yeniden İşleme Al" butonunu güncelle
            UpdateCancelButtonState();
        }

        /// <summary>
        /// Seçili siparişin durumuna göre btnCancel butonunun metnini ve ikonunu günceller
        /// </summary>
        private void UpdateCancelButtonState()
        {
            var selectedOrder = gridView1.GetFocusedRow() as Order;
            
            if (selectedOrder == null)
                return;

            if (selectedOrder.OrderStatus == OrderStatus.Cancelled)
            {
                btnCancel.Caption = "Yeniden İşleme Al";
                // Resources içine kaydettiğin ismi direkt çağır

                btnCancel.ImageOptions.SvgImage = Properties.Resources.Refresh;
            }
            else
            {
                btnCancel.Caption = "İptal Et";
                // Resources içine kaydettiğin ismi direkt çağır
                btnCancel.ImageOptions.SvgImage = Properties.Resources.Cancel;

            }
        }

        // --- SİL BUTONU KODU ---
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _uiHelper.Delete(
                deleteAction: (order) => _manager.Delete(order),
                confirmMessageFunc: (order) => MessageBox.Show(
                    $"'{order.OrderNumber}' numaralı siparişi silmek istediğinize emin misiniz?",
                    "Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning)
            );
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _uiHelper.ShowForm(() => new FrmAddOrder());
        }

        // Helper method to open the edit form
        private void OpenEditForm()
        {
            _uiHelper.Update(selectedOrder =>
            {
                _uiHelper.ShowForm(() => new FrmAddOrder(selectedOrder.OrderId));
            });
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            OpenEditForm();
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenEditForm();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Seçili satırı al
            var selectedOrder = gridView1.GetFocusedRow() as Order;

            if (selectedOrder == null)
            {
                XtraMessageBox.Show("Lütfen bir sipariş seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // İptal edilmiş sipariş için "Yeniden İşleme Al" işlemi
            if (selectedOrder.OrderStatus == OrderStatus.Cancelled)
            {
                ReactivateOrder(selectedOrder);
            }
            // Normal sipariş için "İptal Et" işlemi
            else
            {
                CancelOrder(selectedOrder);
            }
        }

        /// <summary>
        /// Siparişi iptal eder
        /// </summary>
        private void CancelOrder(Order selectedOrder)
        {
            // Kullanıcıdan onay al
            var result = XtraMessageBox.Show(
                $"'{selectedOrder.OrderNumber}' numaralı siparişi iptal etmek istediğinize emin misiniz?",
                "İptal Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                // Sipariş durumunu Cancelled olarak güncelle
                var orderToUpdate = new Order
                {
                    OrderId = selectedOrder.OrderId,
                    OrderNumber = selectedOrder.OrderNumber,
                    CustomerId = selectedOrder.CustomerId,
                    OrderDate = selectedOrder.OrderDate,
                    DueDate = selectedOrder.DueDate,
                    OrderStatus = OrderStatus.Cancelled
                };

                _manager.Update(orderToUpdate);

                XtraMessageBox.Show("Sipariş başarıyla iptal edildi.",
                    "Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Listeyi yenile
                RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Sipariş iptal edilirken hata oluştu: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// İptal edilmiş siparişi yeniden işleme alır (Pending durumuna getirir)
        /// </summary>
        private void ReactivateOrder(Order selectedOrder)
        {
            // Kullanıcıdan onay al
            var result = XtraMessageBox.Show(
                $"'{selectedOrder.OrderNumber}' numaralı siparişi yeniden işleme almak istediğinize emin misiniz?\n\nSipariş durumu 'Sipariş Alındı' olarak güncellenecektir.",
                "Yeniden İşleme Al",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                // Load the full order including OrderItems to reset item stages as well
                var orderToUpdate = _manager.GetById(selectedOrder.OrderId);
                if (orderToUpdate == null)
                {
                    XtraMessageBox.Show("Sipariş bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Sipariş durumunu Pending olarak güncelle
                orderToUpdate.OrderStatus = OrderStatus.Pending;

                // Tüm OrderItem'ların CurrentStage'ini de başa (Pending) al
                if (orderToUpdate.OrderItems != null)
                {
                    foreach (var item in orderToUpdate.OrderItems)
                    {
                        item.CurrentStage = OrderStatus.Pending;
                        // Eğer gerekiyorsa işleyen kullanıcı bilgisi sıfırlanabilir
                        // item.ProcessedByUserId = null;
                    }
                }

                _manager.Update(orderToUpdate);

                XtraMessageBox.Show("Sipariş yeniden işleme alındı.",
                    "Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Listeyi yenile
                RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Sipariş yeniden işleme alınırken hata oluştu: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}