using DevExpress.XtraCharts;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ototeks.UI
{
    public partial class FrmDashboard : DevExpress.XtraEditors.XtraForm
    {
        private DashboardManager _dashboardManager;
        private OrderManager _orderManager;

        // Keep references for disposal
        private GenericRepository<Order> _orderRepo;
        private GenericRepository<Order> _orderRepoForDashboard;
        private GenericRepository<Fabric> _fabricRepo;
        private GenericRepository<OrderItem> _orderItemRepo;

        // Critical stock threshold (in meters)
        private const decimal CRITICAL_STOCK_THRESHOLD = 50;

        // Due date thresholds (in days)
        private const int URGENT_DAYS = 3;      // 3 days or less = Yellow (Urgent)
        private const int WARNING_DAYS = 7;     // 7 days or less = Normal (Warning)
                                                 // More than 7 days = Not shown

        public FrmDashboard()
        {
            InitializeComponent();
            InitializeManager();
        }

        private void InitializeManager()
        {
            _orderRepoForDashboard = new GenericRepository<Order>();
            _fabricRepo = new GenericRepository<Fabric>();
            _orderItemRepo = new GenericRepository<OrderItem>();
            _orderRepo = new GenericRepository<Order>();

            _dashboardManager = new DashboardManager(_orderRepoForDashboard, _fabricRepo, _orderItemRepo);
            _orderManager = new OrderManager(_orderRepo);
        }

        private void tileOrder_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            // Open pending orders form with filter (as MDI tab)
            var frm = new FrmOrderList(showOnlyPending: true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void tileStock_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            // Open fabrics with critical stock form with filter (as MDI tab)
            var frm = new FrmFabricsList(showOnlyCriticalStock: true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void tileCustomer_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            // Open customers with orders form with filter (as MDI tab)
            var frm = new FrmCustomerList(showOnlyWithOrders: true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadDashboardData();
            LoadDeliveryAlerts();
            LoadProductionStagesChart();

            splitContainerControl1.SplitterPosition = splitContainerControl1.Width / 2;
        }

        private void LoadDashboardData()
        {
            try
            {
                // 1. Pending Order Count
                int pendingOrders = _dashboardManager.GetPendingOrderCount();
                tileOrder.Elements[1].Text = pendingOrders.ToString();

                // 2. Critical Stock Count (below 50 meters)
                int criticalStock = _dashboardManager.GetCriticalStockCount(CRITICAL_STOCK_THRESHOLD);
                tileStock.Elements[1].Text = criticalStock.ToString();

                // 3. Customer with Orders Count
                int customersWithOrders = _dashboardManager.GetCustomerWithOrdersCount();
                tileCustomer.Elements[1].Text = customersWithOrders.ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Error loading dashboard data:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadDeliveryAlerts()
        {
            try
            {
                var allOrders = _orderManager.GetAll();

                // Filter incomplete and non-cancelled orders
                // Get those with a due date within 7 days or past due
                var alertOrders = allOrders
                    .Where(o => o.OrderStatus != OrderStatus.Completed &&
                                o.OrderStatus != OrderStatus.Cancelled &&
                                o.DueDate.HasValue)
                    .Where(o =>
                    {
                        var daysRemaining = (o.DueDate!.Value.Date - DateTime.Today).Days;
                        return daysRemaining <= WARNING_DAYS; // 7 days or less (including past due)
                    })
                    .OrderBy(o => o.DueDate) // Nearest date on top
                    .Select(o => new
                    {
                        o.OrderNumber,
                        CustomerName = o.Customer?.CustomerName ?? "Unknown",
                        DueDate = o.DueDate,
                        RemainingDays = (o.DueDate!.Value.Date - DateTime.Today).Days,
                        Status = GetDeliveryStatus((o.DueDate!.Value.Date - DateTime.Today).Days)
                    })
                    .ToList();

                gridControl1.DataSource = alertOrders;
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Error loading delivery alerts:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadProductionStagesChart()
        {
            try
            {
                var allOrders = _orderManager.GetAll();

                // Get incomplete and non-cancelled orders
                var activeOrders = allOrders
                    .Where(o => o.OrderStatus != OrderStatus.Completed &&
                                o.OrderStatus != OrderStatus.Cancelled)
                    .ToList();

                // Group by production stages and count
                var stageData = activeOrders
                    .GroupBy(o => o.OrderStatus)
                    .Select(g => new
                    {
                        Stage = g.Key,
                        StageName = EnumHelper.GetOrderStatusName(g.Key),
                        Count = g.Count()
                    })
                    .OrderBy(x => (int)x.Stage) // Sort by stage order
                    .ToList();

                // Chart: clear existing series (visual settings defined in Designer)
                var funnelSeries = chartControl1.Series["stagesFunnel"];
                if (funnelSeries != null)
                {
                    funnelSeries.Points.Clear();

                    // Add funnel slice for each stage
                    foreach (var stage in stageData)
                    {
                        var point = new DevExpress.XtraCharts.SeriesPoint(stage.StageName, stage.Count);
                        funnelSeries.Points.Add(point);
                    }

                    // Show informational message if no data
                    if (!stageData.Any())
                    {
                        funnelSeries.Points.Add(new DevExpress.XtraCharts.SeriesPoint("No Data", 0));
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Error loading production chart:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string GetDeliveryStatus(int daysRemaining)
        {
            if (daysRemaining < 0)
                return "⚠️ OVERDUE";
            else if (daysRemaining == 0)
                return "🔴 TODAY";
            else if (daysRemaining <= URGENT_DAYS)
                return "🟡 URGENT";
            else
                return "🟢 NORMAL";
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            var view = sender as GridView;
            if (view == null) return;

            // Get the RemainingDays value
            var remainingDaysObj = view.GetRowCellValue(e.RowHandle, "RemainingDays");
            if (remainingDaysObj == null) return;

            int remainingDays = Convert.ToInt32(remainingDaysObj);

            if (remainingDays < 0)
            {
                // Past due date - RED
                e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                e.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            }
            else if (remainingDays <= URGENT_DAYS)
            {
                // 0-3 days - YELLOW (Urgent)
                e.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                e.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            }
            // 4-7 days remain in default color
        }

        /// <summary>
        /// Refreshes dashboard data (can be called externally)
        /// </summary>
        public void RefreshData()
        {
            LoadDashboardData();
            LoadDeliveryAlerts();
            LoadProductionStagesChart();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _orderRepo?.Dispose();
            _orderRepoForDashboard?.Dispose();
            _fabricRepo?.Dispose();
            _orderItemRepo?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
