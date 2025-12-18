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
    public partial class FrmCustomerList : DevExpress.XtraEditors.XtraForm
    {
        private CustomerManager _manager;
        private GenericRepository<Customer> _repo;
        private ListFormHelper<Customer> _uiHelper;

        public FrmCustomerList()
        {
            InitializeComponent();
            InitializeHelper();
        }

        private void InitializeHelper()
        {
            _uiHelper = new ListFormHelper<Customer>(
                gridView1,
                sagTikMenu,
                btnAdd,
                btnUpdate,
                btnDelete);

            // Data provider'ı set et
            _uiHelper.SetDataProvider(GetCustomerData);
        }

        private List<Customer> GetCustomerData()
        {
            // 1. Manager'ı Oluştur (Her çağrıda yeni instance)
            _repo = new GenericRepository<Customer>();
            _manager = new CustomerManager(_repo);

            // 2. Verileri Çek (Orders olmadan)
            return _manager.GetAll();
        }

        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            RefreshData();
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
                deleteAction: (customer) => _manager.Delete(customer),
                confirmMessageFunc: (customer) => MessageBox.Show(
                    $"'{customer.CustomerName}' isimli müşteriyi silmek istediğinize emin misiniz?",
                    "Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning)
            );
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _uiHelper.ShowForm(() => new FrmAddCustomer());
        }

        // Helper method to open the edit form
        private void OpenEditForm()
        {
            _uiHelper.Update(selectedCustomer =>
            {
                _uiHelper.ShowForm(() => new FrmAddCustomer(selectedCustomer.CustomerId));
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