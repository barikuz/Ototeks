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

        // Filtreleme için
        private bool _showOnlyWithOrders = false;

        public FrmCustomerList()
        {
            InitializeComponent();
            InitializeHelper();
        }

        /// <summary>
        /// Filtrelenmiş müşteri listesi için constructor
        /// </summary>
        /// <param name="showOnlyWithOrders">True ise sadece sipariş veren müşterileri gösterir</param>
        public FrmCustomerList(bool showOnlyWithOrders) : this()
        {
            _showOnlyWithOrders = showOnlyWithOrders;
            
            if (_showOnlyWithOrders)
            {
                this.Text = "Sipariş Veren Müşteriler";
            }
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

            // 2. Verileri Çek
            var customers = _manager.GetAll();

            // 3. Filtre uygula - Sipariş veren müşteriler
            if (_showOnlyWithOrders)
            {
                // Sipariş tablosundan müşteri ID'lerini al
                var orderRepo = new GenericRepository<Order>();
                var orders = orderRepo.GetAll();
                var customerIdsWithOrders = orders
                    .Where(o => o.CustomerId.HasValue)
                    .Select(o => o.CustomerId.Value)
                    .Distinct()
                    .ToList();

                customers = customers.Where(c => customerIdsWithOrders.Contains(c.CustomerId)).ToList();
            }

            return customers;
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