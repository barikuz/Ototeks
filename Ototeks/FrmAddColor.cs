using DevExpress.XtraEditors;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Windows.Forms;
using Ototeks.Interfaces;

namespace Ototeks.UI
{
    public partial class FrmAddColor : DevExpress.XtraEditors.XtraForm, IOperationForm
    {
        // Bu, formun dýþarýya göndereceði sinyaldir
        public event EventHandler OperationCompleted;

        private int _guncellenecekId = 0; // 0 ise Ekleme Modu, >0 ise Güncelleme Modu

        public FrmAddColor()
        {
            InitializeComponent();
        }

        public FrmAddColor(int id)
        {
            InitializeComponent();
            _guncellenecekId = id; // Hangi kaydý düzenleyeceðimizi not ettik.

            // Formun baþlýðýný deðiþtir ki kullanýcý anlasýn
            this.Text = "Renk Güncelle";
            lblBaslik.Text = "Renk Güncelleme";
            btnKaydet.Text = "Güncelle";

            getData(); // Kutularý doldur
        }

        void getData()
        {
            // Veritabanýndan o id'li rengi bul
            var repo = new GenericRepository<Color>();
            var manager = new ColorManager(repo);
            var color = manager.GetById(_guncellenecekId);

            if (color != null)
            {
                // Kutularý doldur
                txtRenkAdi.Text = color.ColorName;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. ADIM: Baðlantýlarý Hazýrla
            var repo = new GenericRepository<Color>();
            var manager = new ColorManager(repo);

            try
            {
                // SENARYO 1: YENÝ KAYIT (ID = 0)
                if (_guncellenecekId == 0)
                {
                    // Nesneyi Oluþtur
                    var yeniRenk = new Color
                    {
                        ColorName = txtRenkAdi.Text.Trim()
                    };

                    // Manager'a gönder (Oradaki kurallarý kontrol etsin)
                    manager.Add(yeniRenk);

                    // Baþarýlýysa mesaj ver
                    XtraMessageBox.Show("Renk baþarýyla sisteme eklendi!", "Tebrikler", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Kutularý temizle ki yeni kayýt girebilelim
                    txtRenkAdi.Text = "";
                    txtRenkAdi.Focus(); // Ýmleci tekrar ilk kutuya koy
                }
                // SENARYO 2: GÜNCELLEME (ID > 0)
                else
                {
                    // Önce veritabanýndaki orijinal kaydý çek
                    var guncellenecekRenk = manager.GetById(_guncellenecekId);

                    // Ekrandaki yeni bilgileri üzerine yaz
                    guncellenecekRenk.ColorName = txtRenkAdi.Text.Trim();

                    // Manager'a "Bunu güncelle" de
                    manager.Update(guncellenecekRenk);

                    XtraMessageBox.Show("Renk güncellendi!", "Baþarýlý", 
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
