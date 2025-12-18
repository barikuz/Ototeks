using DevExpress.XtraEditors;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Windows.Forms;
using Ototeks.Interfaces;

namespace Ototeks.UI
{
    public partial class FrmAddCustomer : DevExpress.XtraEditors.XtraForm, IOperationForm
    {
        // Bu, formun dýþarýya göndereceði sinyaldir
        public event EventHandler OperationCompleted;

        private int _guncellenecekId = 0; // 0 ise Ekleme Modu, >0 ise Güncelleme Modu

        public FrmAddCustomer()
        {
            InitializeComponent();
        }

        public FrmAddCustomer(int id)
        {
            InitializeComponent();
            _guncellenecekId = id; // Hangi kaydý düzenleyeceðimizi not ettik.

            // Formun baþlýðýný deðiþtir ki kullanýcý anlasýn
            this.Text = "Müþteri Güncelle";
            lblBaslik.Text = "Müþteri Güncelleme";
            btnKaydet.Text = "Güncelle";

            getData(); // Kutularý doldur
        }

        void getData()
        {
            // Veritabanýndan o id'li müþteriyi bul
            var repo = new GenericRepository<Customer>();
            var manager = new CustomerManager(repo);
            var customer = manager.GetById(_guncellenecekId);

            if (customer != null)
            {
                // Kutularý doldur
                txtMusteriAdi.Text = customer.CustomerName;
                txtTelefon.Text = customer.Phone;
                txtEposta.Text = customer.Email;
                txtAdres.Text = customer.Address;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. ADIM: Baðlantýlarý Hazýrla
            var repo = new GenericRepository<Customer>();
            var manager = new CustomerManager(repo);

            try
            {
                // SENARYO 1: YENÝ KAYIT (ID = 0)
                if (_guncellenecekId == 0)
                {
                    // Nesneyi Oluþtur
                    var yeniMusteri = new Customer
                    {
                        CustomerName = txtMusteriAdi.Text,
                        Phone = txtTelefon.Text,
                        Email = txtEposta.Text,
                        Address = txtAdres.Text
                    };

                    // Manager'a gönder
                    manager.Add(yeniMusteri);

                    // Baþarýlýysa mesaj ver
                    XtraMessageBox.Show("Müþteri baþarýyla sisteme eklendi!", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Kutularý temizle ki yeni kayýt girebilelim
                    txtMusteriAdi.Text = "";
                    txtTelefon.Text = "";
                    txtEposta.Text = "";
                    txtAdres.Text = "";
                    txtMusteriAdi.Focus(); // Ýmleci tekrar ilk kutuya koy
                }
                // SENARYO 2: GÜNCELLEME (ID > 0)
                else
                {
                    // Önce veritabanýndaki orijinal kaydý çek
                    var guncellenecekMusteri = manager.GetById(_guncellenecekId);

                    // Ekrandaki yeni bilgileri üzerine yaz
                    guncellenecekMusteri.CustomerName = txtMusteriAdi.Text;
                    guncellenecekMusteri.Phone = txtTelefon.Text;
                    guncellenecekMusteri.Email = txtEposta.Text;
                    guncellenecekMusteri.Address = txtAdres.Text;

                    // Manager'a "Bunu güncelle" de
                    manager.Update(guncellenecekMusteri);

                    XtraMessageBox.Show("Müþteri güncellendi!", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
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