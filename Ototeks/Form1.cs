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

        private void btnYeniKumas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Formun bir örneğini oluştur
            FrmAddFabric frm = new FrmAddFabric();

            frm.IslemYapildi += (s, args) =>
            {
                // Form1 (Anne), çocuğunu (Listeyi) bulmaya çalışıyor...
                // Application.OpenForms: Açık olan tüm pencereleri tarar.
                var acikListeFormu = Application.OpenForms["FrmListFabrics"] as FrmListFabrics;

                // Eğer liste formu açıksa (kullanıcı kapatmadıysa)
                if (acikListeFormu != null)
                {
                    acikListeFormu.ListeyiYenile(); // Ve Bingo! Yenile komutunu gönder.
                }
            };

            // Formu "Dialog" olarak aç (Arkadaki pencereye tıklanmasını engeller)
            frm.ShowDialog();
        }

        private void btnKumasListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmListFabrics frm = new FrmListFabrics();
            frm.MdiParent = this; // Bu formu ana ekranın içinde (sekme gibi) aç
            frm.Show();
        }

        private void btnNewOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Formu oluştur
            FrmAddOrder frm = new FrmAddOrder();

            // Aç (ShowDialog: Kapanmadan arkadaki forma tıklatmaz, odaklanmayı sağlar)
            frm.ShowDialog();
        }
    }
}
