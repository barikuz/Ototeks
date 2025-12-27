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

        // Filtreleme için
        private bool _showOnlyCriticalStock = false;
        private const decimal CRITICAL_STOCK_THRESHOLD = 50;

        public FrmFabricsList()
        {
            InitializeComponent();
            InitializeHelper();
        }

        /// <summary>
        /// Filtrelenmiş kumaş listesi için constructor
        /// </summary>
        /// <param name="showOnlyCriticalStock">True ise sadece kritik stokta olan kumaşları gösterir</param>
        public FrmFabricsList(bool showOnlyCriticalStock) : this()
        {
            _showOnlyCriticalStock = showOnlyCriticalStock;
            
            if (_showOnlyCriticalStock)
            {
                this.Text = "Kritik Stokta Olan Kumaşlar";
            }
        }

        private void InitializeHelper()
        {
            _uiHelper = new ListFormHelper<Fabric>(
                gridView1,
                sagTikMenu,
                btnAdd,
                btnUpdate,
                btnDelete);

            // Data provider'ı set et
            _uiHelper.SetDataProvider(GetFabricData);
        }

        private List<Fabric> GetFabricData()
        {
            _repo = new GenericRepository<Fabric>();
            _manager = new FabricManager(_repo);
            var fabrics = _manager.GetAll();

            // Filtre uygula
            if (_showOnlyCriticalStock)
            {
                fabrics = fabrics
                    .Where(f => 
                        f.StockQuantity.HasValue && 
                        f.StockQuantity.Value < CRITICAL_STOCK_THRESHOLD)
                    .OrderBy(f => f.StockQuantity ?? 0) // Stok miktarı en az olan üstte
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

        // --- SİL BUTONU KODU ---
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _uiHelper.Delete(
                deleteAction: (fabric) => _manager.Delete(fabric),
                confirmMessageFunc: (fabric) => MessageBox.Show(
                    $"'{fabric.FabricCode}' kodlu kumaşı silmek istediğinize emin misiniz?",
                    "Silme Onayı",
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