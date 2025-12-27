using Ototeks.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            // Uygulama açıldığında otomatik olarak Dashboard formunu aç
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

        // Generic helper metod - form ekleme ve liste yenileme işlemlerini tek yerde toplar
        private void ShowAddFormWithRefresh<TAddForm, TListForm>(Func<TAddForm> createAddForm, string listFormName, Action<TListForm> refreshAction)
            where TAddForm : Form, Ototeks.Interfaces.IOperationForm
            where TListForm : class
        {
            // 1. Ekleme formunu oluştur
            var addForm = createAddForm();

            // 2. Form kapatıldığında liste formunu yenileme event'i ekle
            addForm.OperationCompleted += (s, args) =>
            {
                // Açık olan liste formunu bul
                var openListForm = Application.OpenForms[listFormName] as TListForm;

                // Eğer liste formu açıksa yenile
                if (openListForm != null)
                {
                    refreshAction(openListForm);
                }
            };

            // 3. Formu dialog olarak aç
            addForm.ShowDialog();
        }

        private void btnYeniKumas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAddFormWithRefresh(
                createAddForm: () => new FrmAddFabric(),
                listFormName: "FrmListFabrics",
                refreshAction: (FrmFabricsList listForm) => listForm.RefreshData()
            );
        }

        private void btnKumasListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmFabricsList frm = new FrmFabricsList();
            frm.MdiParent = this; // Bu formu ana ekranın içinde (sekme gibi) aç
            frm.Show();
        }

        private void btnNewOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAddFormWithRefresh(
                createAddForm: () => new FrmAddOrder(),
                listFormName: "FrmOrderList",
                refreshAction: (FrmOrderList listForm) => listForm.RefreshData()
            );
        }

        private void btnSiparisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmOrderList frm = new FrmOrderList();

            // SİHİRLİ KOD BURASI:
            // "Bu form, şu an içinde bulunduğumuz (this) formun çocuğudur" diyoruz.
            frm.MdiParent = this;

            frm.Show();
        }

        private void btnListCustomers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmCustomerList frm = new FrmCustomerList();
            frm.MdiParent = this; // Bu formu ana ekranın içinde (sekme gibi) aç
            frm.Show();
        }

        private void btnNewCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAddFormWithRefresh(
                createAddForm: () => new FrmAddCustomer(),
                listFormName: "FrmCustomerList", 
                refreshAction: (FrmCustomerList listForm) => listForm.RefreshData()
            );
        }

        private void btnProductionTrack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmProductionTrack frm = new FrmProductionTrack();
            frm.MdiParent = this; // Bu formu ana ekranın içinde (sekme gibi) aç
            frm.Show();
        }
    }
}
