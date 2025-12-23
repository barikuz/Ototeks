using DevExpress.XtraEditors;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Windows.Forms;
using Ototeks.Interfaces;
using System.Linq;

namespace Ototeks.UI
{
    public partial class FrmAddFabric : DevExpress.XtraEditors.XtraForm, IOperationForm
    {
        // Bu, formun dışarıya göndereceği sinyaldir
        public event EventHandler OperationCompleted;

        private int _guncellenecekId = 0; // 0 ise Ekleme Modu, >0 ise Güncelleme Modu

        public FrmAddFabric()
        {
            InitializeComponent();
            LoadColors(); // Renkleri yükle
        }

        public FrmAddFabric(int id)
        {
            InitializeComponent();
            LoadColors(); // Renkleri yükle
            _guncellenecekId = id; // Hangi kaydı düzenleyeceğimizi not ettik.

            // Formun başlığını değiştir ki kullanıcı anlasın
            this.Text = "Kumaş Güncelle";
            lblBaslik.Text = "Kumaş Güncelleme";
            btnKaydet.Text = "Güncelle";

            getData(); // Kutuları doldur
        }

        void LoadColors()
        {
            try
            {
                // Renkleri veritabanından getir
                var colorRepo = new GenericRepository<Color>();
                var colorManager = new ColorManager(colorRepo);
                var colors = colorManager.GetAll();

                cmbRenk.Properties.Items.Clear();
                
                // Placeholder ekle
                cmbRenk.Properties.Items.Add("Bir renk seçiniz...");
                
                // ComboBox'a renkleri ekle (Sadece metin olarak)
                foreach (var color in colors)
                {
                    cmbRenk.Properties.Items.Add(color.ColorName);
                }
                
                // Placeholder'ı seçili hale getir
                cmbRenk.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Renkler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                txtStok.Text = kumas.StockQuantity?.ToString("F2") ?? "0.00";
                
                // Renk seçimini ayarla
                if (kumas.ColorId.HasValue)
                {
                    // ColorId'den ColorName'i bulup seç
                    var colorRepo = new GenericRepository<Color>();
                    var colorManager = new ColorManager(colorRepo);
                    var selectedColor = colorManager.GetById(kumas.ColorId.Value);
                    if (selectedColor != null)
                    {
                        cmbRenk.SelectedItem = selectedColor.ColorName;
                    }
                }
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
                // Stok miktarını al
                decimal stokMiktari = 0;
                decimal.TryParse(txtStok.Text, out stokMiktari);

                // Seçili rengin ID'sini bul
                var colorRepo = new GenericRepository<Color>();
                var colorManager = new ColorManager(colorRepo);
                var colors = colorManager.GetAll();
                var selectedColorName = cmbRenk.SelectedItem.ToString();
                var selectedColor = colors.FirstOrDefault(c => c.ColorName == selectedColorName);
                
                // Placeholder seçiliyse ColorId null yap ki validator yakalasın
                int? colorId = null;
                if (selectedColorName != "Bir renk seçiniz..." && selectedColor != null)
                {
                    colorId = selectedColor.ColorId;
                }

                // SENARYO 1: YENİ KAYIT (ID = 0)
                if (_guncellenecekId == 0)
                {
                    // Nesneyi Oluştur
                    var yeniKumas = new Fabric
                    {
                        FabricCode = txtKumasKodu.Text.Trim(),
                        FabricName = txtKumasAdi.Text.Trim(),
                        StockQuantity = stokMiktari,
                        ColorId = colorId
                    };

                    // Manager'a gönder (Oradaki kuralları kontrol etsin)
                    manager.Add(yeniKumas);

                    // Başarılıysa mesaj ver
                    XtraMessageBox.Show("Kumaş başarıyla sisteme eklendi!", "Tebrikler", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Kutuları temizle ki yeni kayıt girebilelim
                    txtKumasKodu.Text = "";
                    txtKumasAdi.Text = "";
                    txtStok.Text = ""; // Boş bırak, 0.00 ile doldurma
                    cmbRenk.SelectedIndex = 0; // Placeholder'a döndür
                    txtKumasKodu.Focus(); // İmleci tekrar ilk kutuya koy
                }
                // SENARYO 2: GÜNCELLEME (ID > 0)
                else
                {
                    // Önce veritabanındaki orijinal kaydı çek
                    var guncellenecekKumas = manager.GetById(_guncellenecekId);

                    // Ekrandaki yeni bilgileri üzerine yaz
                    guncellenecekKumas.FabricCode = txtKumasKodu.Text.Trim();
                    guncellenecekKumas.FabricName = txtKumasAdi.Text.Trim();
                    guncellenecekKumas.StockQuantity = stokMiktari;
                    guncellenecekKumas.ColorId = colorId;

                    // Manager'a "Bunu güncelle" de
                    manager.Update(guncellenecekKumas);

                    XtraMessageBox.Show("Kumaş güncellendi!", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Güncelleme bitince formu kapatmak daha mantıklıdır.
                }

                // Anne Forma Sinyal Gönder (Yenilesin)
                OperationCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // Hatayı burada yakalayıp kullanıcıya gösteriyoruz.
                XtraMessageBox.Show(ex.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}