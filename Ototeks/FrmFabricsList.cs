using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using Ototeks.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ototeks.UI
{
    public partial class FrmFabricsList : DevExpress.XtraEditors.XtraForm
    {
        private FabricManager _manager;
        private GenericRepository<Fabric> _repo;
        private ListFormHelper<Fabric> _uiHelper;

        // For filtering
        private bool _showOnlyCriticalStock = false;
        private const decimal CRITICAL_STOCK_THRESHOLD = 50;

        public FrmFabricsList()
        {
            InitializeComponent();
            InitializeHelper();
        }

        /// <summary>
        /// Constructor for filtered fabric list
        /// </summary>
        /// <param name="showOnlyCriticalStock">If true, shows only fabrics with critical stock levels</param>
        public FrmFabricsList(bool showOnlyCriticalStock) : this()
        {
            _showOnlyCriticalStock = showOnlyCriticalStock;

            if (_showOnlyCriticalStock)
            {
                this.Text = "Fabrics with Critical Stock";
            }
        }

        private void InitializeHelper()
        {
            _uiHelper = new ListFormHelper<Fabric>(
                gridView1,
                contextMenu,
                btnAdd,
                btnUpdate,
                btnDelete);

            // Set the data provider
            _uiHelper.SetDataProvider(GetFabricData);
        }

        private List<Fabric> GetFabricData()
        {
            _repo = new GenericRepository<Fabric>();
            _manager = new FabricManager(_repo);
            var fabrics = _manager.GetAll();

            // Apply filter
            if (_showOnlyCriticalStock)
            {
                fabrics = fabrics
                    .Where(f =>
                        f.StockQuantity.HasValue &&
                        f.StockQuantity.Value < CRITICAL_STOCK_THRESHOLD)
                    .OrderBy(f => f.StockQuantity ?? 0) // Lowest stock quantity on top
                    .ToList();
            }

            return fabrics;
        }

        private void FrmListFabrics_Load(object sender, EventArgs e)
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
                deleteAction: (fabric) => _manager.Delete(fabric),
                confirmMessageFunc: (fabric) => MessageBox.Show(
                    $"Are you sure you want to delete the fabric with code '{fabric.FabricCode}'?",
                    "Delete Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning)
            );
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _uiHelper.ShowForm(() => new FrmAddFabric());
        }

        // Helper method to open the edit form
        private void OpenEditForm()
        {
            _uiHelper.Update(selectedFabric =>
            {
                _uiHelper.ShowForm(() => new FrmAddFabric(selectedFabric.FabricId));
            });
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            OpenEditForm();
        }

        private void btnUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenEditForm();
        }
    }
}
