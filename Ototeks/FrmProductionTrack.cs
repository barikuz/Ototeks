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

        // Track which view is active (true = detail view is active)
        private bool _isDetailViewActive = false;
        // Active detail view reference
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
                _orderRepo?.Dispose();
                _orderItemRepo?.Dispose();
                _orderRepo = new GenericRepository<Order>();
                _orderItemRepo = new GenericRepository<OrderItem>();
                _orderManager = new OrderManager(_orderRepo);

                // Do not fetch cancelled orders directly from the database
                // Include OrderItems and their related Fabric and Type so detail grid can show names
                var orders = _orderRepo.GetAll(
                    o => o.OrderStatus != OrderStatus.Cancelled,
                    "Customer",
                    "OrderItems",
                    "OrderItems.Fabric",
                    "OrderItems.Type"
                );

                // Calculate each order's status from its items
                foreach (var order in orders)
                {
                    SyncOrderStatusFromItems(order);
                }

                gridControl1.DataSource = orders;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"An error occurred while loading orders: {ex.Message}",
                    "Error",
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
            // When master view is clicked
            gridView1.Click += (s, e) =>
            {
                _isDetailViewActive = false;
                _currentDetailView = null;

                if (gridView1.GetFocusedRow() is Order selectedOrder)
                {
                    UpdateProgressBar(selectedOrder.OrderStatus);
                }
            };

            // When detail view is created
            gridControl1.ViewRegistered += (s, e) =>
            {
                if (e.View is GridView detailView && e.View != gridView1)
                {
                    // Set to -1 initially to prevent row selection in detail view
                    detailView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle;

                    // When detail view is clicked (via mouse click)
                    detailView.Click += (sender, args) =>
                    {
                        _isDetailViewActive = true;
                        _currentDetailView = detailView;

                        if (detailView.GetFocusedRow() is OrderItem selectedItem)
                        {
                            UpdateProgressBar(selectedItem.CurrentStage);
                        }
                    };

                    // When row changes in detail view (only if active)
                    detailView.FocusedRowChanged += (sender, args) =>
                    {
                        // Only run if user selected by clicking (if active)
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
            // Only run if user selected by clicking
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
                    XtraMessageBox.Show("Please select an order or an order item.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"An error occurred while updating the stage: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Generic stage update method - works for both Order and OrderItem
        /// </summary>
        private void UpdateStage<T>(T entity, int direction) where T : class
        {
            // Determine current status and entity type
            var (currentStatus, entityName) = entity switch
            {
                Order order => (order.OrderStatus, "Order"),
                OrderItem item => (item.CurrentStage, "Order item"),
                _ => throw new ArgumentException("Unsupported entity type")
            };

            // Do not process cancelled records
            if (currentStatus == OrderStatus.Cancelled)
            {
                XtraMessageBox.Show($"The status of a cancelled {entityName.ToLower()} cannot be changed.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Calculate the new stage
            int newStageValue = (int)currentStatus + direction;

            // Check if within valid range (0-5)
            if (newStageValue < 0 || newStageValue > 5)
            {
                string message = direction > 0
                    ? $"{entityName} is already at the last stage."
                    : $"{entityName} is already at the first stage.";

                XtraMessageBox.Show(message,
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            OrderStatus newStatus = (OrderStatus)newStageValue;

            // Update based on entity type
            switch (entity)
            {
                case Order order:
                    UpdateOrderWithItems(order, newStatus);
                    break;

                case OrderItem orderItem:
                    UpdateOrderItemAndSyncOrder(orderItem, newStatus);
                    break;
            }

            // Update the progress bar
            UpdateProgressBar(newStatus);

            // Success message
            string stageName = EnumHelper.GetOrderStatusName(newStatus);
            XtraMessageBox.Show($"{entityName} status updated to '{stageName}'.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Updates the order and its remaining items
        /// </summary>
        private void UpdateOrderWithItems(Order order, OrderStatus newStatus)
        {
            // Save old status (for direction determination)
            OrderStatus oldStatus = order.OrderStatus;
            bool isMovingBackward = (int)newStatus < (int)oldStatus;

            // Update order status
            UpdateOrderInDatabase(order, newStatus);
            order.OrderStatus = newStatus;

            // Update items
            foreach (var item in order.OrderItems)
            {
                if (item.CurrentStage == OrderStatus.Cancelled)
                    continue;

                bool shouldUpdate;
                if (isMovingBackward)
                {
                    // Moving backward: Pull back items higher than new status
                    shouldUpdate = (int)item.CurrentStage > (int)newStatus;
                }
                else
                {
                    // Moving forward: Push items at lower stages than new status forward
                    shouldUpdate = (int)item.CurrentStage < (int)newStatus;
                }

                if (shouldUpdate)
                {
                    UpdateOrderItemInDatabase(item, newStatus);
                    item.CurrentStage = newStatus;
                }
            }

        }

        /// <summary>
        /// Updates the order item and synchronizes the order status
        /// </summary>
        private void UpdateOrderItemAndSyncOrder(OrderItem orderItem, OrderStatus newStatus)
        {
            // Update the item first
            UpdateOrderItemInDatabase(orderItem, newStatus);
            orderItem.CurrentStage = newStatus;

            // Find the parent order and sync its status from items
            var parentOrder = gridView1.GetFocusedRow() as Order;
            if (parentOrder != null)
            {
                SyncOrderStatusFromItems(parentOrder);
            }

        }

        /// <summary>
        /// Calculates and updates the order status from its items.
        /// Order status = Status of the item at the lowest stage.
        /// </summary>
        private void SyncOrderStatusFromItems(Order order)
        {
            if (order.OrderItems == null || !order.OrderItems.Any())
                return;

            // Find the lowest stage among non-cancelled items
            var activeItems = order.OrderItems.Where(i => i.CurrentStage != OrderStatus.Cancelled);

            if (!activeItems.Any())
                return;

            var minStage = activeItems.Min(i => (int)i.CurrentStage);
            var newOrderStatus = (OrderStatus)minStage;

            // Update if order status is different
            if (order.OrderStatus != newOrderStatus)
            {
                UpdateOrderInDatabase(order, newOrderStatus);
                order.OrderStatus = newOrderStatus;
            }
        }

        /// <summary>
        /// Updates the order in the database
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
        /// Updates the order item in the database
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
        /// Updates the database when the due date changes
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

                // Update in database
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
                    $"Due date updated for order {order.OrderNumber}.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"An error occurred while updating the due date: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _orderRepo?.Dispose();
            _orderItemRepo?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
