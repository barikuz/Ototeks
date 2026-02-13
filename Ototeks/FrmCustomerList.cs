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

        // For filtering
        private bool _showOnlyWithOrders = false;

        public FrmCustomerList()
        {
            InitializeComponent();
            InitializeHelper();
        }

        /// <summary>
        /// Constructor for filtered customer list
        /// </summary>
        /// <param name="showOnlyWithOrders">If true, shows only customers with orders</param>
        public FrmCustomerList(bool showOnlyWithOrders) : this()
        {
            _showOnlyWithOrders = showOnlyWithOrders;

            if (_showOnlyWithOrders)
            {
                this.Text = "Customers with Orders";
            }
        }

        private void InitializeHelper()
        {
            _uiHelper = new ListFormHelper<Customer>(
                gridView1,
                contextMenu,
                btnAdd,
                btnUpdate,
                btnDelete);

            // Set the data provider
            _uiHelper.SetDataProvider(GetCustomerData);
        }

        private List<Customer> GetCustomerData()
        {
            // 1. Create Manager (New instance per call)
            _repo = new GenericRepository<Customer>();
            _manager = new CustomerManager(_repo);

            // 2. Fetch data
            var customers = _manager.GetAll();

            // 3. Apply filter - Customers with orders
            if (_showOnlyWithOrders)
            {
                // Get customer IDs from the orders table
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

        // --- DELETE BUTTON CODE ---
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _uiHelper.Delete(
                deleteAction: (customer) => _manager.Delete(customer),
                confirmMessageFunc: (customer) => MessageBox.Show(
                    $"Are you sure you want to delete the customer '{customer.CustomerName}'?",
                    "Delete Confirmation",
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
