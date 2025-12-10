using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
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
    public partial class FrmAddOrder : DevExpress.XtraEditors.XtraForm
    {
        private BindingList<OrderItem> _orderItems;

        public FrmAddOrder()
        {
            InitializeComponent();

            _orderItems = new BindingList<OrderItem>();
        }

        private void FrmAddOrder_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // --- 1. Müşterileri (Customers) LookUpEdit'e Doldur ---
            var customerRepo = new GenericRepository<Customer>();
            var customerManager = new CustomerManager(customerRepo);

            // Veritabanından çek ve kutuya ata
            lkpMusteri.Properties.DataSource = customerManager.GetAll();

            // --- 2. Tarihi (Date) Bugüne Ayarla ---
            dateTarih.DateTime = DateTime.Now;


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
                // 1. ADIM: Nesneyi Hazırla
                Order newOrder = CreateOrderFromUI();

                // 2. ADIM: İşi Bitir
                var orderManager = new OrderManager(new GenericRepository<Order>());
                orderManager.Add(newOrder);

                // 3. ADIM: Kullanıcıya Haber Ver
                ShowSuccessMessage();
                this.Close();
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
            order.OrderStatus = "New";

            // "Müşteri seçili değilse 0 ata, seçiliyse ID'yi al"
            order.CustomerId = lkpMusteri.EditValue != null ? (int)lkpMusteri.EditValue : 0;

            // 3. İlişkili Veri (Sepet)
            order.OrderItems = _orderItems;

            return order;
        }

        private void ShowSuccessMessage()
        {
            XtraMessageBox.Show("Sipariş Başarıyla Oluşturuldu!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowErrorMessage(Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        
    }
}