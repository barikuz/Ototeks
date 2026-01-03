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
    public partial class FrmProductTypeList : DevExpress.XtraEditors.XtraForm
    {
        private ProductTypeManager _manager;
        private GenericRepository<ProductType> _repo;
        private ListFormHelper<ProductType> _uiHelper;

        public FrmProductTypeList()
        {
            InitializeComponent();
            InitializeHelper();
        }

        private void InitializeHelper()
        {
            _uiHelper = new ListFormHelper<ProductType>(
                gridView1,
                sagTikMenu,
                btnAdd,
                btnUpdate,
                btnDelete);

            // Data provider'ý set et
            _uiHelper.SetDataProvider(GetProductTypeData);
        }

        private List<ProductType> GetProductTypeData()
        {
            _repo = new GenericRepository<ProductType>();
            _manager = new ProductTypeManager(_repo);
            return _manager.GetAll();
        }

        private void FrmProductTypeList_Load(object sender, EventArgs e)
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

        // --- SÝL BUTONU KODU ---
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _uiHelper.Delete(
                deleteAction: (productType) => _manager.Delete(productType),
                confirmMessageFunc: (productType) => MessageBox.Show(
                    $"'{productType.TypeName}' ürün tipini silmek istediðinize emin misiniz?",
                    "Silme Onayý",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning)
            );
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _uiHelper.ShowForm(() => new FrmAddProductType());
        }

        // Helper method to open the edit form
        private void OpenEditForm()
        {
            _uiHelper.Update(selectedProductType =>
            {
                _uiHelper.ShowForm(() => new FrmAddProductType(selectedProductType.TypeId));
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
