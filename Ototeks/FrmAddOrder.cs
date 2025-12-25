using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using Ototeks.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ototeks.UI
{
    public partial class FrmAddOrder : DevExpress.XtraEditors.XtraForm, IOperationForm
    {
        // Bu, formun dışarıya göndereceği sinyaldir
        public event EventHandler OperationCompleted;

        private BindingList<OrderItem> _orderItems;
        private int _guncellenecekId = 0; // 0 ise Ekleme Modu, >0 ise Güncelleme Modu

        public FrmAddOrder()
        {
            InitializeComponent();
            _orderItems = new BindingList<OrderItem>();
        }

        public FrmAddOrder(int id)
        {
            InitializeComponent();
            _orderItems = new BindingList<OrderItem>();
            _guncellenecekId = id; // Hangi kaydı düzenleyeceğimizi not ettik.

            // Formun başlığını değiştir ki kullanıcı anlasın
            this.Text = "Sipariş Güncelle";
            btnKaydet.Text = "Güncelle";
        }

        private void FrmAddOrder_Load(object sender, EventArgs e)
        {
            // Önce dropdown'ları ve temel ayarları yükle
            LoadData();
            
            // Sonra güncelleme modundaysa sipariş verilerini yükle
            if (_guncellenecekId > 0)
            {
                LoadOrderData();
            }
        }

        private void LoadOrderData()
        {
            try
            {
                // Veritabanından o id'li siparişi bul
                var repo = new GenericRepository<Order>();
                var manager = new OrderManager(repo);
                var order = manager.GetById(_guncellenecekId);

                if (order != null)
                {
                    // Form kutularını doldur
                    txtSiparisNo.Text = order.OrderNumber;
                    dateTarih.DateTime = order.OrderDate ?? DateTime.Now;
                    lkpMusteri.EditValue = order.CustomerId;

                    // OrderItems'ları temizle ve yeniden yükle
                    _orderItems.Clear();
                    
                    // OrderItems'ları da yükle
                    if (order.OrderItems != null && order.OrderItems.Any())
                    {
                        foreach (var item in order.OrderItems)
                        {
                            _orderItems.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Sipariş verileri yüklenirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            // --- 1. Müşterileri (Customers) LookUpEdit'e Doldur ---
            var customerRepo = new GenericRepository<Customer>();
            var customerManager = new CustomerManager(customerRepo);

            // Veritabanından çek ve kutuya ata
            lkpMusteri.Properties.DataSource = customerManager.GetAll();

            // --- 2. Tarihi (Date) Bugüne Ayarla ---
            if (_guncellenecekId == 0) // Sadece yeni sipariş için
            {
                dateTarih.DateTime = DateTime.Now;
            }

            // --- 3. Grid (Sepet) Ayarları ---
            // Grid'i oluşturduğumuz BindingList'e bağlıyoruz.
            // Artık _orderItems'a ne eklersek ekranda görünecek.
            gridSiparisKalemleri.DataSource = _orderItems;

            // --- C. ÜRÜN TİPİ DROPDOWN ---
            var productTypeRepo = new GenericRepository<ProductType>();
            var productTypeManager = new ProductTypeManager(productTypeRepo);

            // Designer'da oluşturduğun repository 
            repoProductType.DataSource = productTypeManager.GetAll();

            // --- D. KUMAŞ DROPDOWN ---
            var fabricRepo = new GenericRepository<Fabric>();
            var fabricManager = new FabricManager(fabricRepo);

            // Designer'da oluşturduğun repository
            repoFabric.DataSource = fabricManager.GetAll();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // SENARYO 1: YENİ KAYIT (ID = 0)
                if (_guncellenecekId == 0)
                {
                    // 1. ADIM: Nesneyi Hazırla
                    Order newOrder = CreateOrderFromUI();

                    // 2. ADIM: Stok Kontrolü Yap ve Kullanıcıya Göster
                    ShowStockValidationResult(newOrder.OrderItems);

                    // 3. ADIM: İşi Bitir
                    var orderManager = new OrderManager(new GenericRepository<Order>());
                    orderManager.Add(newOrder);

                    // 4. ADIM: Kullanıcıya Haber Ver
                    XtraMessageBox.Show("Sipariş başarıyla sisteme eklendi ve kumaş stokları güncellendi!", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Form kutularını temizle
                    ClearForm();
                }
                // SENARYO 2: GÜNCELLEME (ID > 0)
                else
                {
                    // Güncellenecek siparişi UI'dan oluştur (ID'sini set et)
                    Order guncellenecekOrder = CreateOrderFromUI();
                    guncellenecekOrder.OrderId = _guncellenecekId;

                    // Stok kontrolü yap
                    ShowStockValidationResult(guncellenecekOrder.OrderItems);

                    // Manager'a "Bunu güncelle" de
                    var orderManager = new OrderManager(new GenericRepository<Order>());
                    orderManager.Update(guncellenecekOrder);

                    XtraMessageBox.Show("Sipariş güncellendi ve kumaş stokları yeniden hesaplandı!", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Güncelleme bitince formu kapatmak daha mantıklıdır.
                }

                // Anne Forma Sinyal Gönder (Yenilesin)
                OperationCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // Hataları yakala ve göster
                ShowErrorMessage(ex);
            }
        }

        private Order CreateOrderFromUI()
        {
            Order order = new Order();

            // 1. Basit Atamalar
            order.OrderNumber = txtSiparisNo.Text;
            order.OrderDate = dateTarih.DateTime;
            order.OrderStatus = OrderStatus.Pending;

            // "Müşteri seçili değilse 0 ata, seçiliyse ID'yi al"
            order.CustomerId = lkpMusteri.EditValue != null ? (int)lkpMusteri.EditValue : 0;

            // 3. İlişkili Veri (Sepet) - OrderItem ID'lerini koru
            order.OrderItems = new List<OrderItem>();
            foreach (var item in _orderItems)
            {
                var orderItem = new OrderItem
                {
                    OrderItemId = item.OrderItemId, // Mevcut ID'yi koru (güncelleme için)
                    OrderId = item.OrderId,
                    FabricId = item.FabricId,
                    TypeId = item.TypeId,
                    Quantity = item.Quantity,
                    CurrentStage = item.CurrentStage,
                    ProcessedByUserId = item.ProcessedByUserId
                };
                order.OrderItems.Add(orderItem);
            }

            return order;
        }

        private void ClearForm()
        {
            txtSiparisNo.Text = "";
            dateTarih.DateTime = DateTime.Now;
            lkpMusteri.EditValue = null;
            _orderItems.Clear();
        }

        private void ShowErrorMessage(Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowStockValidationResult(ICollection<OrderItem> orderItems)
        {
            try
            {
                var orderManager = new OrderManager(new GenericRepository<Order>());
                
                // Gerekli kumaş miktarlarını hesapla
                var requiredFabrics = orderManager.CalculateRequiredFabrics(orderItems);
                
                if (requiredFabrics.Any())
                {
                    var message = new StringBuilder();
                    message.AppendLine("Bu sipariş için gerekli kumaş miktarları:");
                    message.AppendLine();
                    
                    foreach (var fabric in requiredFabrics)
                    {
                        message.AppendLine($"• {fabric.Key}: {fabric.Value:F2} metre");
                    }
                    
                    message.AppendLine();
                    message.AppendLine("Devam etmek istiyor musunuz?");
                    
                    var result = XtraMessageBox.Show(message.ToString(), "Stok Bilgisi", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    
                    if (result == DialogResult.No)
                    {
                        throw new Exception("Sipariş işlemi kullanıcı tarafından iptal edildi.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Stok kontrolü hatalarını yakala ve göster
                throw; // Hatayı yukarı fırlat ki ana catch bloğu yakalasın
            }
        }

    }
}