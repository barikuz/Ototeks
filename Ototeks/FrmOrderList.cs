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

        // For filtering
        private bool _showOnlyPending = false;

        public FrmOrderList()
        {
            InitializeComponent();
            InitializeHelper();
        }

        /// <summary>
        /// Constructor for filtered order list
        /// </summary>
        /// <param name="showOnlyPending">If true, shows only pending orders</param>
        public FrmOrderList(bool showOnlyPending) : this()
        {
            _showOnlyPending = showOnlyPending;

            if (_showOnlyPending)
            {
                this.Text = "Pending Orders";
            }
        }

        private void InitializeHelper()
        {
            _uiHelper = new ListFormHelper<Order>(
                gridView1,
                contextMenu,
                btnAdd,
                btnUpdate,
                btnDelete);

            // Set the data provider
            _uiHelper.SetDataProvider(GetOrderData);
        }

        private List<Order> GetOrderData()
        {
            // 1. Create Manager (New instance per call)
            _repo?.Dispose();
            _repo = new GenericRepository<Order>();
            _manager = new OrderManager(_repo);

            // 2. Fetch data (fully loaded with Include)
            var orders = _manager.GetAll();

            // 3. Apply filter
            if (_showOnlyPending)
            {
                orders = orders
                    .Where(o => o.OrderStatus == OrderStatus.Pending) // Only those with "Pending" status
                    .OrderBy(o => o.DueDate ?? DateTime.MaxValue) // Nearest due date on top (nulls at the bottom)
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
            // Enable Master-Detail on the grid. The relation name is 'OrderItems'.
            // To find the list, look at the .OrderItems property of the order.
            gridView1.ActivateMasterDetail<Order>("OrderItems", order => order.OrderItems);
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            // Display the OrderStatus column in the main table
            if (e.Column.FieldName == "OrderStatus" && e.Value is OrderStatus status)
            {
                e.DisplayText = EnumHelper.GetOrderStatusName(status);
            }
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            // Display the CurrentStage column in the detail table
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

            // Update the "Cancel" / "Reactivate" button based on selected order
            UpdateCancelButtonState();
        }

        /// <summary>
        /// Updates the text and icon of the btnCancel button based on the selected order's status
        /// </summary>
        private void UpdateCancelButtonState()
        {
            var selectedOrder = gridView1.GetFocusedRow() as Order;

            if (selectedOrder == null)
                return;

            if (selectedOrder.OrderStatus == OrderStatus.Cancelled)
            {
                btnCancel.Caption = "Reactivate";
                // Call the name saved in Resources directly

                btnCancel.ImageOptions.SvgImage = Properties.Resources.Refresh;
            }
            else
            {
                btnCancel.Caption = "Cancel";
                // Call the name saved in Resources directly
                btnCancel.ImageOptions.SvgImage = Properties.Resources.Cancel;

            }
        }

        // --- DELETE BUTTON CODE ---
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _uiHelper.Delete(
                deleteAction: (order) => _manager.Delete(order),
                confirmMessageFunc: (order) => MessageBox.Show(
                    $"Are you sure you want to delete order '{order.OrderNumber}'?",
                    "Delete Confirmation",
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
            // Get the selected row
            var selectedOrder = gridView1.GetFocusedRow() as Order;

            if (selectedOrder == null)
            {
                XtraMessageBox.Show("Please select an order.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // "Reactivate" operation for cancelled order
            if (selectedOrder.OrderStatus == OrderStatus.Cancelled)
            {
                ReactivateOrder(selectedOrder);
            }
            // "Cancel" operation for normal order
            else
            {
                CancelOrder(selectedOrder);
            }
        }

        /// <summary>
        /// Cancels the order
        /// </summary>
        private void CancelOrder(Order selectedOrder)
        {
            // Get confirmation from user
            var result = XtraMessageBox.Show(
                $"Are you sure you want to cancel order '{selectedOrder.OrderNumber}'?",
                "Cancel Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                // Update order status to Cancelled
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

                XtraMessageBox.Show("Order cancelled successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Refresh the list
                RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"An error occurred while cancelling the order: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reactivates a cancelled order (sets it to Pending status)
        /// </summary>
        private void ReactivateOrder(Order selectedOrder)
        {
            // Get confirmation from user
            var result = XtraMessageBox.Show(
                $"Are you sure you want to reactivate order '{selectedOrder.OrderNumber}'?\n\nThe order status will be updated to 'Pending'.",
                "Reactivate",
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
                    XtraMessageBox.Show("Order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update order status to Pending
                orderToUpdate.OrderStatus = OrderStatus.Pending;

                // Reset all OrderItems' CurrentStage to Pending
                if (orderToUpdate.OrderItems != null)
                {
                    foreach (var item in orderToUpdate.OrderItems)
                    {
                        item.CurrentStage = OrderStatus.Pending;
                        // The processing user info can be reset if needed
                        // item.ProcessedByUserId = null;
                    }
                }

                _manager.Update(orderToUpdate);

                XtraMessageBox.Show("Order reactivated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Refresh the list
                RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"An error occurred while reactivating the order: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
