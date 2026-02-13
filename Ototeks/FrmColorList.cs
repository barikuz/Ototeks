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
    public partial class FrmColorList : DevExpress.XtraEditors.XtraForm
    {
        private ColorManager _manager;
        private GenericRepository<Color> _repo;
        private ListFormHelper<Color> _uiHelper;

        public FrmColorList()
        {
            InitializeComponent();
            InitializeHelper();
        }

        private void InitializeHelper()
        {
            _uiHelper = new ListFormHelper<Color>(
                gridView1,
                contextMenu,
                btnAdd,
                btnUpdate,
                btnDelete);

            // Set the data provider
            _uiHelper.SetDataProvider(GetColorData);
        }

        private List<Color> GetColorData()
        {
            _repo?.Dispose();
            _repo = new GenericRepository<Color>();
            _manager = new ColorManager(_repo);
            return _manager.GetAll();
        }

        private void FrmColorList_Load(object sender, EventArgs e)
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
                deleteAction: (color) => _manager.Delete(color),
                confirmMessageFunc: (color) => MessageBox.Show(
                    $"Are you sure you want to delete the color '{color.ColorName}'?",
                    "Delete Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning)
            );
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _uiHelper.ShowForm(() => new FrmAddColor());
        }

        // Helper method to open the edit form
        private void OpenEditForm()
        {
            _uiHelper.Update(selectedColor =>
            {
                _uiHelper.ShowForm(() => new FrmAddColor(selectedColor.ColorId));
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
