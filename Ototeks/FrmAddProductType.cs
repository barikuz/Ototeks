using DevExpress.XtraEditors;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Windows.Forms;
using Ototeks.Interfaces;

namespace Ototeks.UI
{
    public partial class FrmAddProductType : DevExpress.XtraEditors.XtraForm, IOperationForm
    {
        // Bu, formun dýþarýya göndereceði sinyaldir
        public event EventHandler OperationCompleted;

        private int _guncellenecekId = 0; // 0 ise Ekleme Modu, >0 ise Güncelleme Modu

        public FrmAddProductType()
        {
            InitializeComponent();
        }

        public FrmAddProductType(int id)
        {
            InitializeComponent();
            _guncellenecekId = id; // Hangi kaydý düzenleyeceðimizi not ettik.

            // Formun baþlýðýný deðiþtir ki kullanýcý anlasýn
            this.Text = "Ürün Tipi Güncelle";
            lblBaslik.Text = "Ürün Tipi Güncelleme";
            btnKaydet.Text = "Güncelle";

            getData(); // Kutularý doldur
        }

        void getData()
        {
            // Veritabanýndan o id'li ürün tipini bul
            var repo = new GenericRepository<ProductType>();
            var manager = new ProductTypeManager(repo);
            var productType = manager.GetById(_guncellenecekId);

            if (productType != null)
            {
                // Kutularý doldur
                txtUrunTipiAdi.Text = productType.TypeName;
                txtGerekliKumasMiktari.Text = productType.RequiredFabricAmount.ToString("F2");
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. ADIM: Baðlantýlarý Hazýrla
            var repo = new GenericRepository<ProductType>();
            var manager = new ProductTypeManager(repo);

            try
            {
                // Gerekli kumaþ miktarýný al
                decimal gerekliMiktar = 0;
                decimal.TryParse(txtGerekliKumasMiktari.Text, out gerekliMiktar);

                // SENARYO 1: YENÝ KAYIT (ID = 0)
                if (_guncellenecekId == 0)
                {
                    // Nesneyi Oluþtur
                    var yeniUrunTipi = new ProductType
                    {
                        TypeName = txtUrunTipiAdi.Text.Trim(),
                        RequiredFabricAmount = gerekliMiktar
                    };

                    // Manager'a gönder (Oradaki kurallarý kontrol etsin)
                    manager.Add(yeniUrunTipi);

                    // Baþarýlýysa mesaj ver
                    XtraMessageBox.Show("Ürün tipi baþarýyla sisteme eklendi!", "Tebrikler", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Kutularý temizle ki yeni kayýt girebilelim
                    txtUrunTipiAdi.Text = "";
                    txtGerekliKumasMiktari.Text = "";
                    txtUrunTipiAdi.Focus(); // Ýmleci tekrar ilk kutuya koy
                }
                // SENARYO 2: GÜNCELLEME (ID > 0)
                else
                {
                    // Önce veritabanýndaki orijinal kaydý çek
                    var guncellenecekUrunTipi = manager.GetById(_guncellenecekId);

                    // Ekrandaki yeni bilgileri üzerine yaz
                    guncellenecekUrunTipi.TypeName = txtUrunTipiAdi.Text.Trim();
                    guncellenecekUrunTipi.RequiredFabricAmount = gerekliMiktar;

                    // Manager'a "Bunu güncelle" de
                    manager.Update(guncellenecekUrunTipi);

                    XtraMessageBox.Show("Ürün tipi güncellendi!", "Baþarýlý", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Güncelleme bitince formu kapatmak daha mantýklýdýr.
                }

                // Anne Forma Sinyal Gönder (Yenilesin)
                OperationCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // Hatayý burada yakalayýp kullanýcýya gösteriyoruz.
                XtraMessageBox.Show(ex.Message, "Hata Oluþtu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
