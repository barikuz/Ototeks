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

        // Kritik stok eşiği (metre cinsinden)
        private const decimal CRITICAL_STOCK_THRESHOLD = 50;

        // Teslim tarihi eşikleri (gün cinsinden)
        private const int URGENT_DAYS = 3;      // 3 gün veya daha az = Sarı (Acil)
        private const int WARNING_DAYS = 7;     // 7 gün veya daha az = Normal (Uyarı)
                                                 // 7 günden fazla = Gösterilmez

        public FrmDashboard()
        {
            InitializeComponent();
            InitializeManager();
        }

        private void InitializeManager()
        {
            var orderRepo = new GenericRepository<Order>();
            var fabricRepo = new GenericRepository<Fabric>();
            var orderItemRepo = new GenericRepository<OrderItem>();

            _dashboardManager = new DashboardManager(orderRepo, fabricRepo, orderItemRepo);
            _orderManager = new OrderManager(orderRepo);
        }

        private void tileOrder_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            // Bekleyen siparişler formunu filtreli aç (MDI tab olarak)
            var frm = new FrmOrderList(showOnlyPending: true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void tileStock_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            // Kritik stokta olan kumaşlar formunu filtreli aç (MDI tab olarak)
            var frm = new FrmFabricsList(showOnlyCriticalStock: true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void tileCustomer_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            // Sipariş veren müşteriler formunu filtreli aç (MDI tab olarak)
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
                // 1. Bekleyen Sipariş Sayısı
                int pendingOrders = _dashboardManager.GetPendingOrderCount();
                tileOrder.Elements[1].Text = pendingOrders.ToString();

                // 2. Kritik Stok Sayısı (50 metrenin altındakiler)
                int criticalStock = _dashboardManager.GetCriticalStockCount(CRITICAL_STOCK_THRESHOLD);
                tileStock.Elements[1].Text = criticalStock.ToString();

                // 3. Sipariş Veren Müşteri Sayısı
                int customersWithOrders = _dashboardManager.GetCustomerWithOrdersCount();
                tileCustomer.Elements[1].Text = customersWithOrders.ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Dashboard verileri yüklenirken hata oluştu:\n{ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadDeliveryAlerts()
        {
            try
            {
                var allOrders = _orderManager.GetAll();

                // Tamamlanmamış ve iptal edilmemiş siparişleri filtrele
                // Teslim tarihi olan ve 7 gün içinde veya geçmiş olanları al
                var alertOrders = allOrders
                    .Where(o => o.OrderStatus != OrderStatus.Completed &&
                                o.OrderStatus != OrderStatus.Cancelled &&
                                o.DueDate.HasValue)
                    .Where(o =>
                    {
                        var daysRemaining = (o.DueDate!.Value.Date - DateTime.Today).Days;
                        return daysRemaining <= WARNING_DAYS; // 7 gün veya daha az (geçmiş dahil)
                    })
                    .OrderBy(o => o.DueDate) // En yakın tarih üstte
                    .Select(o => new
                    {
                        o.OrderNumber,
                        MusteriAdi = o.Customer?.CustomerName ?? "Bilinmiyor",
                        TeslimTarihi = o.DueDate,
                        KalanGun = (o.DueDate!.Value.Date - DateTime.Today).Days,
                        Durum = GetDeliveryStatus((o.DueDate!.Value.Date - DateTime.Today).Days)
                    })
                    .ToList();

                gridControl1.DataSource = alertOrders;
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Teslim uyarıları yüklenirken hata oluştu:\n{ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadProductionStagesChart()
        {
            try
            {
                var allOrders = _orderManager.GetAll();

                // Tamamlanmamış ve iptal edilmemiş siparişleri al
                var activeOrders = allOrders
                    .Where(o => o.OrderStatus != OrderStatus.Completed &&
                                o.OrderStatus != OrderStatus.Cancelled)
                    .ToList();

                // Üretim aşamalarına göre grupla ve say
                var stageData = activeOrders
                    .GroupBy(o => o.OrderStatus)
                    .Select(g => new
                    {
                        Stage = g.Key,
                        StageName = EnumHelper.GetOrderStatusName(g.Key),
                        Count = g.Count()
                    })
                    .OrderBy(x => (int)x.Stage) // Aşama sırasına göre sırala
                    .ToList();

                // Grafik serisini temizle ve doldur
                var series = chartControl1.Series["stagesBarChart"];
                series.Points.Clear();

                // --- GÖRSEL İYİLEŞTİRMELER ---

                // A. LEJANT (SAĞDAKİ KUTU) AYARI:
                series.LegendTextPattern = "{A}";

                // B. RENKLENDİRME AYARI (ColorEach):
                if (series.View is SideBySideBarSeriesView view)
                {
                    view.ColorEach = true;
                }

                // C. PALET SEÇİMİ:
                chartControl1.PaletteName = "Office 2013";

                // Her aşama için bar ekle
                foreach (var stage in stageData)
                {
                    var point = new SeriesPoint(stage.StageName, stage.Count);
                    series.Points.Add(point);
                }

                // Eğer veri yoksa bilgilendirme
                if (!stageData.Any())
                {
                    series.Points.Add(new SeriesPoint("Veri Yok", 0));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Üretim grafiği yüklenirken hata oluştu:\n{ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string GetDeliveryStatus(int daysRemaining)
        {
            if (daysRemaining < 0)
                return "⚠️ GECİKMİŞ";
            else if (daysRemaining == 0)
                return "🔴 BUGÜN";
            else if (daysRemaining <= URGENT_DAYS)
                return "🟡 ACİL";
            else
                return "🟢 NORMAL";
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            var view = sender as GridView;
            if (view == null) return;

            // KalanGun değerini al
            var kalanGunObj = view.GetRowCellValue(e.RowHandle, "KalanGun");
            if (kalanGunObj == null) return;

            int kalanGun = Convert.ToInt32(kalanGunObj);

            if (kalanGun < 0)
            {
                // Geçmiş tarih - KIRMIZI
                e.Appearance.BackColor = System.Drawing.Color.MistyRose;
                e.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            }
            else if (kalanGun <= URGENT_DAYS)
            {
                // 0-3 gün - SARI (Acil)
                e.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                e.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            }
            // 4-7 gün arası normal renkte kalır
        }

        /// <summary>
        /// Dashboard verilerini yeniler (dışarıdan çağrılabilir)
        /// </summary>
        public void RefreshData()
        {
            LoadDashboardData();
            LoadDeliveryAlerts();
            LoadProductionStagesChart();
        }
    }
}