using Ototeks.UI;
using Ototeks.Helpers;
using System;
using System.Windows.Forms;

namespace Ototeks
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenDashboard();
        }

        private void OpenDashboard()
        {
            FrmDashboard frm = new FrmDashboard();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnDashboard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenDashboard();
        }

        private void btnStatistics_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmStatistics frm = new FrmStatistics();
            frm.MdiParent = this;
            frm.Show();
        }

        // Generic helper - Add formu açar ve işlem sonrası ilgili liste formlarını yeniler
        private void ShowAddForm<TAddForm, TListForm>(Func<TAddForm> createAddForm)
            where TAddForm : Form, Ototeks.Interfaces.IOperationForm
            where TListForm : Form
        {
            using (var addForm = createAddForm())
            {
                addForm.OperationCompleted += (s, args) =>
                {
                    FormRefreshHelper.RefreshAllOpenForms<TListForm>();
                };

                addForm.ShowDialog();
            }
        }

        // --- KUMAŞ İŞLEMLERİ ---
        private void btnYeniKumas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAddForm<FrmAddFabric, FrmFabricsList>(() => new FrmAddFabric());
        }

        private void btnKumasListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmFabricsList frm = new FrmFabricsList();
            frm.MdiParent = this;
            frm.Show();
        }

        // --- SİPARİŞ İŞLEMLERİ ---
        private void btnNewOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAddForm<FrmAddOrder, FrmOrderList>(() => new FrmAddOrder());
        }

        private void btnSiparisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmOrderList frm = new FrmOrderList();
            frm.MdiParent = this;
            frm.Show();
        }

        // --- MÜŞTERİ İŞLEMLERİ ---
        private void btnNewCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAddForm<FrmAddCustomer, FrmCustomerList>(() => new FrmAddCustomer());
        }

        private void btnListCustomers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmCustomerList frm = new FrmCustomerList();
            frm.MdiParent = this;
            frm.Show();
        }

        // --- ÜRETİM VE KALİTE İŞLEMLERİ ---
        private void btnProductionTrack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmProductionTrack frm = new FrmProductionTrack();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnQualityControl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmFabricQualityControl frm = new FrmFabricQualityControl();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnDefectedFabrics_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDefectedFabricList frm = new FrmDefectedFabricList();
            frm.MdiParent = this;
            frm.Show();
        }

        // --- RENK İŞLEMLERİ ---
        private void btnAddColor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAddForm<FrmAddColor, FrmColorList>(() => new FrmAddColor());
        }

        private void btnListColors_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmColorList frm = new FrmColorList();
            frm.MdiParent = this;
            frm.Show();
        }

        // --- ÜRÜN TİPİ İŞLEMLERİ ---
        private void btnAddProductType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAddForm<FrmAddProductType, FrmProductTypeList>(() => new FrmAddProductType());
        }

        private void btnListProductTypes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmProductTypeList frm = new FrmProductTypeList();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
