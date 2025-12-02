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
        // Bu, formun dışarıya göndereceği sinyaldir
        public event EventHandler IslemYapildi;

        private int _guncellenecekId = 0; // 0 ise Ekleme Modu, >0 ise Güncelleme Modu

        public FrmAddFabric()
        {
            InitializeComponent();
        }

        public FrmAddFabric(int id)
        {
            InitializeComponent();
            _guncellenecekId = id; // Hangi kaydı düzenleyeceğimizi not ettik.

            // Formun başlığını değiştir ki kullanıcı anlasın
            this.Text = "Kumaş Güncelle";
            lblBaslik.Text = "Kumaş Güncelleme";
            btnKaydet.Text = "Güncelle";

            getData(); // Kutuları doldur
        }

        void getData()
        {
            // Veritabanından o id'li kumaşı bul
            var repo = new GenericRepository<Fabric>();
            var manager = new FabricManager(repo);
            var kumas = manager.GetById(_guncellenecekId);

            if (kumas != null)
            {
                // Kutuları doldur
                txtKumasKodu.Text = kumas.FabricCode;
                txtKumasAdi.Text = kumas.FabricName;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. ADIM: Bağlantıları Hazırla
            // (Veritabanı erişimi ve İş mantığı sınıflarını çağırıyoruz)
            var repo = new GenericRepository<Fabric>();
            var manager = new FabricManager(repo);

            try
            {
                // SENARYO 1: YENİ KAYIT (ID = 0)
                if (_guncellenecekId == 0)
                {
                    // Nesneyi Oluştur
                    // Ekrandaki kutulardan verileri alıp bir Fabric nesnesine dolduruyoruz.
                    var yeniKumas = new Fabric
                    {
                        FabricCode = txtKumasKodu.Text,  // Barkod kutusundan al
                        FabricName = txtKumasAdi.Text,   // İsim kutusundan al
                        StockQuantity = 0,               // Yeni kumaşın stoğu 0 başlar

                        // DİKKAT: Veritabanında Renk tablosu zorunlu olduğu için şimdilik geçici olarak 1 (Beyaz) veriyoruz.
                        ColorId = 1
                    };

                    // Manager'a gönder (Oradaki kuralları kontrol etsin)
                    manager.Add(yeniKumas);

                    // Başarılıysa mesaj ver
                    XtraMessageBox.Show("Kumaş başarıyla sisteme eklendi!", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Kutuları temizle ki yeni kayıt girebilelim
                    txtKumasKodu.Text = "";
                    txtKumasAdi.Text = "";
                    txtKumasKodu.Focus(); // İmleci tekrar ilk kutuya koy
                }
                // SENARYO 2: GÜNCELLEME (ID > 0)
                else
                {
                    // Önce veritabanındaki orijinal kaydı çek
                    var guncellenecekKumas = manager.GetById(_guncellenecekId);

                    // Ekrandaki yeni bilgileri üzerine yaz
                    guncellenecekKumas.FabricCode = txtKumasKodu.Text;
                    guncellenecekKumas.FabricName = txtKumasAdi.Text;

                    // Manager'a "Bunu güncelle" de
                    manager.Update(guncellenecekKumas);

                    XtraMessageBox.Show("Kumaş güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Güncelleme bitince formu kapatmak daha mantıklıdır.
                }

                // Anne Forma Sinyal Gönder (Yenilesin)
                IslemYapildi?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // Hatayı burada yakalayıp kullanıcıya gösteriyoruz.
                XtraMessageBox.Show(ex.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}