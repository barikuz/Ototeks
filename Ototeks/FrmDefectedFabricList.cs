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

        // For the selected defected item
        private DefectedOrderItemViewModel _selectedDefectedItem;
        // OrderId of the selected order (to preserve expand state)
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
                _orderRepo?.Dispose();
                _qualityLogRepo?.Dispose();
                _orderRepo = new GenericRepository<Order>();
                _qualityLogRepo = new GenericRepository<QualityLog>();

                // Get all defective quality logs (also include related data)
                var defectedLogs = _qualityLogRepo.GetAll(
                    q => q.IsDefective == true,
                    "OrderItem",
                    "OrderItem.Order",
                    "OrderItem.Order.Customer",
                    "OrderItem.Fabric",
                    "OrderItem.Fabric.Color",
                    "OrderItem.Type",
                    "Defect"
                );

                // Group orders that have defective items
                var ordersWithDefects = defectedLogs
                    .Where(q => q.OrderItem?.Order != null)
                    .GroupBy(q => q.OrderItem.Order.OrderId)
                    .Select(g => g.First().OrderItem.Order)
                    .ToList();

                // Create defective item details for each order
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

                    // Find defective items belonging to this order
                    var orderDefectedLogs = defectedLogs
                        .Where(q => q.OrderItem?.OrderId == order.OrderId)
                        .ToList();

                    // Create defective item view models
                    foreach (var log in orderDefectedLogs)
                    {
                        var item = log.OrderItem;
                        if (item == null) continue;

                        defectedOrderVM.DefectedItems.Add(new DefectedOrderItemViewModel
                        {
                            OrderItemId = item.OrderItemId,
                            QualityLogId = log.LogId, // Also store LogId for delete operation
                            FabricName = item.Fabric != null ? $"{item.Fabric.FabricCode} - {item.Fabric.FabricName}" : "-",
                            ColorName = item.Fabric?.Color?.ColorName ?? "-",
                            TypeName = item.Type?.TypeName ?? "-",
                            Quantity = item.Quantity,
                            CurrentStage = item.CurrentStage,
                            // New columns - Defect details
                            DefectType = log.Defect?.DefectName ?? "-",
                            ConfidenceScore = log.ConfidenceScore ?? 0,
                            AnalysisDate = log.InspectionDate
                        });
                    }

                    defectedOrderViewModels.Add(defectedOrderVM);
                }

                gridControl1.DataSource = defectedOrderViewModels;

                // If a previously expanded order exists, re-expand it
                RestoreExpandedOrder();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"An error occurred while loading defective fabrics: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Finds and re-expands a previously expanded order.
        /// </summary>
        private void RestoreExpandedOrder()
        {
            if (_lastExpandedOrderId == null)
                return;

            // Scan all rows and find the one with matching OrderId
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                var row = gridView1.GetRow(i) as DefectedOrderViewModel;
                if (row != null && row.OrderId == _lastExpandedOrderId)
                {
                    // Focus the row
                    gridView1.FocusedRowHandle = i;

                    // Expand the master-detail relation
                    gridView1.SetMasterRowExpanded(i, true);

                    // Ensure the row is visible
                    gridView1.MakeRowVisible(i);

                    break;
                }
            }
        }

        private void SetupGrid()
        {
            // Enable Master-Detail for the grid
            gridView1.ActivateMasterDetail<DefectedOrderViewModel>(
                "DefectedItems",
                order => order.DefectedItems);
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            // Display OrderStatus column in the master table
            if (e.Column.FieldName == "OrderStatus" && e.Value is OrderStatus status)
            {
                e.DisplayText = EnumHelper.GetOrderStatusName(status);
            }
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            // Display CurrentStage column in the detail table
            if (e.Column.FieldName == "CurrentStage" && e.Value is OrderStatus status)
            {
                e.DisplayText = EnumHelper.GetOrderStatusName(status);
            }
            // Display confidence score as percentage
            else if (e.Column.FieldName == "ConfidenceScore" && e.Value is double score)
            {
                e.DisplayText = $"%{score:F1}";
            }
            // Display defect type
            else if (e.Column.FieldName == "DefectType" && e.Value is string defectType)
            {
                e.DisplayText = EnumHelper.GetDefectTypeName(defectType);
            }
        }

        /// <summary>
        /// Show context menu for detail view (order items).
        /// </summary>
        private void gridView2_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            var hitInfo = e.HitInfo;

            // Only show menu when clicking on a row
            if (hitInfo.InRow)
            {
                // Get the selected row
                _selectedDefectedItem = view.GetRow(hitInfo.RowHandle) as DefectedOrderItemViewModel;

                if (_selectedDefectedItem != null)
                {
                    // Make delete button visible
                    btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    // Find and save which order this item belongs to
                    SaveCurrentExpandedOrder(view);

                    // Show the menu
                    popupMenuDetail.ShowPopup(Control.MousePosition);
                }
            }
        }

        /// <summary>
        /// Saves the OrderId of the currently expanded order.
        /// </summary>
        private void SaveCurrentExpandedOrder(GridView detailView)
        {
            // Get the parent row handle of the detail view
            int parentRowHandle = detailView.SourceRowHandle;

            // Get order info from parent view (gridView1)
            var parentOrder = gridView1.GetRow(parentRowHandle) as DefectedOrderViewModel;

            if (parentOrder != null)
            {
                _lastExpandedOrderId = parentOrder.OrderId;
            }
        }

        /// <summary>
        /// Delete defect record.
        /// </summary>
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_selectedDefectedItem == null)
            {
                XtraMessageBox.Show(
                    "Please select the defect record you want to delete.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Get confirmation from user
            var result = XtraMessageBox.Show(
                $"Are you sure you want to delete the defect record for '{_selectedDefectedItem.FabricName}' fabric?\n\n" +
                $"Defect Type: {EnumHelper.GetDefectTypeName(_selectedDefectedItem.DefectType)}\n" +
                $"Confidence Score: %{_selectedDefectedItem.ConfidenceScore:F1}",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                // Delete QualityLog record from database
                var qualityLog = _qualityLogRepo.GetById(_selectedDefectedItem.QualityLogId);
                if (qualityLog != null)
                {
                    _qualityLogRepo.Delete(qualityLog);

                    XtraMessageBox.Show(
                        "Defect record deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Refresh the list (preserving expand state)
                    LoadDefectedOrders();
                }
                else
                {
                    XtraMessageBox.Show(
                        "Defect record not found.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"An error occurred while deleting the defect record: {ex.Message}",
                    "Error",
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
    /// ViewModel for defected order - displayed in the Master Grid.
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
        /// Defective items belonging to this order - displayed in the Detail Grid.
        /// </summary>
        public List<DefectedOrderItemViewModel> DefectedItems { get; set; }
    }

    /// <summary>
    /// ViewModel for defected order item - displayed in the Detail Grid.
    /// </summary>
    public class DefectedOrderItemViewModel
    {
        public int OrderItemId { get; set; }
        public int QualityLogId { get; set; } // QualityLog ID for delete operation
        public string FabricName { get; set; }
        public string ColorName { get; set; }  // Fabric Color
        public string TypeName { get; set; }
        public int Quantity { get; set; }
        public OrderStatus CurrentStage { get; set; }

        // Defect details - Additional columns
        public string DefectType { get; set; }      // Defect Type
        public double ConfidenceScore { get; set; } // Confidence Score
        public DateTime? AnalysisDate { get; set; } // Analysis Date
    }

    #endregion
}
