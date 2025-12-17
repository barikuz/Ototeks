using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using Ototeks.UI.Helpers;
using Ototeks.Helpers;
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

        public FrmOrderList()
        {
            InitializeComponent();
            InitializeHelper();
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
            return _manager.GetAll();
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

        public void RefreshData()
        {
            _uiHelper.RefreshData();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            _uiHelper.HandlePopupMenuShowing(e);
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
    }
}