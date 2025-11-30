using DevExpress.XtraEditors;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Windows.Forms;

namespace Ototeks.UI
{
    public partial class FrmAddFabric : DevExpress.XtraEditors.XtraForm
    {
        public FrmAddFabric()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. ADIM: Bağlantıları Hazırla
            // (Veritabanı erişimi ve İş mantığı sınıflarını çağırıyoruz)
            var repo = new GenericRepository<Fabric>();
            var manager = new FabricManager(repo);

            // 2. ADIM: Nesneyi Oluştur
            // Ekrandaki kutulardan verileri alıp bir Fabric nesnesine dolduruyoruz.
            var yeniKumas = new Fabric
            {
                FabricCode = txtKumasKodu.Text,  // Barkod kutusundan al
                FabricName = txtKumasAdi.Text,   // İsim kutusundan al
                StockQuantity = 0,               // Yeni kumaşın stoğu 0 başlar

                // DİKKAT: Veritabanında Renk tablosu zorunlu olduğu için şimdilik geçici olarak 1 (Beyaz) veriyoruz.
                ColorId = 1
            };

            // 3. ADIM: Kaydetmeyi Dene (Hata Yönetimi)
            try
            {
                // Manager'a gönder (Oradaki kuralları kontrol etsin)
                manager.Add(yeniKumas);

                // Başarılıysa mesaj ver
                XtraMessageBox.Show("Kumaş başarıyla sisteme eklendi!", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kutuları temizle ki yeni kayıt girebilelim
                txtKumasKodu.Text = "";
                txtKumasAdi.Text = "";
                txtKumasKodu.Focus(); // İmleci tekrar ilk kutuya koy
            }
            catch (Exception ex)
            {
                // Eğer Manager "Bu kod zaten var!" veya "KMS ile başlamalı!" derse
                // hatayı burada yakalayıp kullanıcıya gösteriyoruz.
                XtraMessageBox.Show(ex.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}