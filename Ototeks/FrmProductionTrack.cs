using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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
    public partial class FrmProductionTrack : DevExpress.XtraEditors.XtraForm
    {
        private OrderManager _orderManager;
        private GenericRepository<Order> _orderRepo;
        private GenericRepository<OrderItem> _orderItemRepo;

        // Hangi view'ın aktif olduğunu takip etmek için (true = detail view aktif)
        private bool _isDetailViewActive = false;
        // Aktif detail view referansı
        private GridView _currentDetailView = null;

        public FrmProductionTrack()
        {
            InitializeComponent();
        }

        private void FrmProductionTrack_Load(object sender, EventArgs e)
        {
            LoadOrders();
            SetupGrid();
            SetupGridEvents();
        }

        private void LoadOrders()
        {
            try
            {
                _orderRepo = new GenericRepository<Order>();
                _orderItemRepo = new GenericRepository<OrderItem>();
                _orderManager = new OrderManager(_orderRepo);

                var orders = _orderManager.GetAll();
                
                // Her siparişin durumunu kalemlerden hesapla
                foreach (var order in orders)
                {
                    SyncOrderStatusFromItems(order);
                }
                
                gridControl1.DataSource = orders;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Siparişler yüklenirken hata oluştu: {ex.Message}", 
                    "Hata", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void SetupGrid()
        {
            gridView1.ActivateMasterDetail<Order>("OrderItems", order => order.OrderItems);
        }

        private void SetupGridEvents()
        {
            // Master view'a tıklandığında
            gridView1.Click += (s, e) =>
            {
                _isDetailViewActive = false;
                _currentDetailView = null;
                
                if (gridView1.GetFocusedRow() is Order selectedOrder)
                {
                    UpdateProgressBar(selectedOrder.OrderStatus);
                }
            };

            // Detail view oluşturulduğunda
            gridControl1.ViewRegistered += (s, e) =>
            {
                if (e.View is GridView detailView && e.View != gridView1)
                {
                    // Detail view'da satır seçilmemesi için başlangıçta -1 yap
                    detailView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle;
                    
                    // Detail view'a tıklandığında (mouse click ile)
                    detailView.Click += (sender, args) =>
                    {
                        _isDetailViewActive = true;
                        _currentDetailView = detailView;
                        
                        if (detailView.GetFocusedRow() is OrderItem selectedItem)
                        {
                            UpdateProgressBar(selectedItem.CurrentStage);
                        }
                    };

                    // Detail view'da satır değiştiğinde (sadece aktifse)
                    detailView.FocusedRowChanged += (sender, args) =>
                    {
                        // Sadece kullanıcı tıklayarak seçtiyse (aktif ise) çalış
                        if (_isDetailViewActive && detailView.GetFocusedRow() is OrderItem selectedItem)
                        {
                            UpdateProgressBar(selectedItem.CurrentStage);
                        }
                    };
                }
            };
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!_isDetailViewActive && gridView1.GetFocusedRow() is Order selectedOrder)
            {
                UpdateProgressBar(selectedOrder.OrderStatus);
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Sadece kullanıcı tıklayarak seçtiyse çalış
            if (_isDetailViewActive && sender is GridView detailView && detailView.GetFocusedRow() is OrderItem selectedOrderItem)
            {
                _currentDetailView = detailView;
                UpdateProgressBar(selectedOrderItem.CurrentStage);
            }
        }

        private void UpdateProgressBar(OrderStatus status)
        {
            stepProgressBar1.SelectedItemIndex = status switch
            {
                OrderStatus.Pending => 0,
                OrderStatus.Cutting => 1,
                OrderStatus.Sewing => 2,
                OrderStatus.Ironing => 3,
                OrderStatus.QualityControl => 4,
                OrderStatus.Completed => 5,
                OrderStatus.Cancelled => -1,
                _ => 0
            };
        }

        private void btnPreviousStage_Click(object sender, EventArgs e) => UpdateOrderStage(-1);

        private void btnNextStage_Click(object sender, EventArgs e) => UpdateOrderStage(1);

        private void UpdateOrderStage(int direction)
        {
            try
            {
                if (_isDetailViewActive && _currentDetailView != null)
                {
                    if (_currentDetailView.GetFocusedRow() is OrderItem selectedOrderItem)
                    {
                        UpdateStage(selectedOrderItem, direction);
                        return;
                    }
                }

                if (gridView1.GetFocusedRow() is Order selectedOrder)
                {
                    UpdateStage(selectedOrder, direction);
                }
                else
                {
                    XtraMessageBox.Show("Lütfen bir sipariş veya sipariş kalemi seçiniz.", 
                        "Uyarı", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Aşama güncellenirken hata oluştu: {ex.Message}", 
                    "Hata", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Generic aşama güncelleme metodu - Order ve OrderItem için ortak çalışır
        /// </summary>
        private void UpdateStage<T>(T entity, int direction) where T : class
        {
            // Mevcut durumu ve entity tipini belirle
            var (currentStatus, entityName) = entity switch
            {
                Order order => (order.OrderStatus, "Sipariş"),
                OrderItem item => (item.CurrentStage, "Sipariş kalemi"),
                _ => throw new ArgumentException("Desteklenmeyen entity tipi")
            };

            // İptal edilmiş kayıtlar için işlem yapma
            if (currentStatus == OrderStatus.Cancelled)
            {
                XtraMessageBox.Show($"İptal edilmiş {entityName.ToLower()}in durumu değiştirilemez.", 
                    "Uyarı", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            // Yeni aşamayı hesapla
            int newStageValue = (int)currentStatus + direction;

            // Geçerli aralıkta mı kontrol et (0-5 arası)
            if (newStageValue < 0 || newStageValue > 5)
            {
                string message = direction > 0 
                    ? $"{entityName} zaten son aşamada." 
                    : $"{entityName} zaten ilk aşamada.";
                
                XtraMessageBox.Show(message, 
                    "Uyarı", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                return;
            }

            OrderStatus newStatus = (OrderStatus)newStageValue;

            // Entity tipine göre güncelleme yap
            switch (entity)
            {
                case Order order:
                    UpdateOrderWithItems(order, newStatus);
                    break;

                case OrderItem orderItem:
                    UpdateOrderItemAndSyncOrder(orderItem, newStatus);
                    break;
            }

            // Progress bar'ı güncelle
            UpdateProgressBar(newStatus);

            // Başarı mesajı
            string stageName = EnumHelper.GetOrderStatusName(newStatus);
            XtraMessageBox.Show($"{entityName} durumu '{stageName}' olarak güncellendi.", 
                "Başarılı", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Siparişi ve geride kalan kalemleri günceller
        /// </summary>
        private void UpdateOrderWithItems(Order order, OrderStatus newStatus)
        {
            // Sipariş durumunu güncelle
            UpdateOrderInDatabase(order, newStatus);
            order.OrderStatus = newStatus;

            // Bu durumdan düşük aşamada olan kalemleri güncelle
            int updatedItemCount = 0;
            foreach (var item in order.OrderItems)
            {
                if ((int)item.CurrentStage < (int)newStatus && item.CurrentStage != OrderStatus.Cancelled)
                {
                    UpdateOrderItemInDatabase(item, newStatus);
                    item.CurrentStage = newStatus;
                    updatedItemCount++;
                }
            }

        }

        /// <summary>
        /// Sipariş kalemini günceller ve siparişin durumunu senkronize eder
        /// </summary>
        private void UpdateOrderItemAndSyncOrder(OrderItem orderItem, OrderStatus newStatus)
        {
            // Önce kalemi güncelle
            UpdateOrderItemInDatabase(orderItem, newStatus);
            orderItem.CurrentStage = newStatus;

            // Ana siparişi bul ve durumunu kalemlere göre senkronize et
            var parentOrder = gridView1.GetFocusedRow() as Order;
            if (parentOrder != null)
            {
                SyncOrderStatusFromItems(parentOrder);
            }

        }

        /// <summary>
        /// Siparişin durumunu kalemlerden hesaplar ve günceller
        /// Sipariş durumu = En düşük aşamadaki kalemin durumu
        /// </summary>
        private void SyncOrderStatusFromItems(Order order)
        {
            if (order.OrderItems == null || !order.OrderItems.Any())
                return;

            // İptal edilmemiş kalemlerin en düşük aşamasını bul
            var activeItems = order.OrderItems.Where(i => i.CurrentStage != OrderStatus.Cancelled);
            
            if (!activeItems.Any())
                return;

            var minStage = activeItems.Min(i => (int)i.CurrentStage);
            var newOrderStatus = (OrderStatus)minStage;

            // Eğer sipariş durumu farklıysa güncelle
            if (order.OrderStatus != newOrderStatus)
            {
                UpdateOrderInDatabase(order, newOrderStatus);
                order.OrderStatus = newOrderStatus;
            }
        }

        /// <summary>
        /// Order'ı veritabanında günceller
        /// </summary>
        private void UpdateOrderInDatabase(Order order, OrderStatus newStatus)
        {
            var orderToUpdate = new Order
            {
                OrderId = order.OrderId,
                OrderNumber = order.OrderNumber,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                DueDate = order.DueDate,
                OrderStatus = newStatus
            };
            _orderManager.Update(orderToUpdate);
        }

        /// <summary>
        /// OrderItem'ı veritabanında günceller
        /// </summary>
        private void UpdateOrderItemInDatabase(OrderItem orderItem, OrderStatus newStatus)
        {
            var orderItemToUpdate = new OrderItem
            {
                OrderItemId = orderItem.OrderItemId,
                OrderId = orderItem.OrderId,
                FabricId = orderItem.FabricId,
                TypeId = orderItem.TypeId,
                Quantity = orderItem.Quantity,
                CurrentStage = newStatus,
                ProcessedByUserId = orderItem.ProcessedByUserId
            };
            _orderItemRepo.Update(orderItemToUpdate);
        }

        /// <summary>
        /// Teslim tarihi değiştiğinde veritabanını günceller
        /// </summary>
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != "DueDate")
                return;

            try
            {
                var order = gridView1.GetRow(e.RowHandle) as Order;
                if (order == null)
                    return;

                // Veritabanında güncelle
                var orderToUpdate = new Order
                {
                    OrderId = order.OrderId,
                    OrderNumber = order.OrderNumber,
                    CustomerId = order.CustomerId,
                    OrderDate = order.OrderDate,
                    DueDate = order.DueDate,
                    OrderStatus = order.OrderStatus
                };
                _orderManager.Update(orderToUpdate);

                XtraMessageBox.Show(
                    $"Sipariş {order.OrderNumber} için teslim tarihi güncellendi.",
                    "Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Teslim tarihi güncellenirken hata oluştu: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}