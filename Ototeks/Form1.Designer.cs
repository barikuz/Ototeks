namespace Ototeks
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            btnYeniKumas = new DevExpress.XtraBars.BarButtonItem();
            btnKumasListesi = new DevExpress.XtraBars.BarButtonItem();
            btnNewOrder = new DevExpress.XtraBars.BarButtonItem();
            btnSiparisListesi = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(components);
            tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(components);
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            btnNewCustomer = new DevExpress.XtraBars.BarButtonItem();
            btnListCustomers = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)documentManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabbedView1).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 37, 35, 37);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, skinRibbonGalleryBarItem1, btnYeniKumas, btnKumasListesi, btnNewOrder, btnSiparisListesi, btnNewCustomer, btnListCustomers });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.Margin = new System.Windows.Forms.Padding(4);
            ribbonControl1.MaxItemId = 8;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsMenuMinWidth = 385;
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new System.Drawing.Size(973, 242);
            // 
            // skinRibbonGalleryBarItem1
            // 
            skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            skinRibbonGalleryBarItem1.Id = 1;
            skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // btnYeniKumas
            // 
            btnYeniKumas.Caption = "Yeni Kumaş";
            btnYeniKumas.Id = 2;
            btnYeniKumas.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnYeniKumas.ImageOptions.Image");
            btnYeniKumas.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnYeniKumas.ImageOptions.LargeImage");
            btnYeniKumas.Name = "btnYeniKumas";
            btnYeniKumas.ItemClick += btnYeniKumas_ItemClick;
            // 
            // btnKumasListesi
            // 
            btnKumasListesi.Caption = "Kumaş Listesi";
            btnKumasListesi.Id = 3;
            btnKumasListesi.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnKumasListesi.ImageOptions.Image");
            btnKumasListesi.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnKumasListesi.ImageOptions.LargeImage");
            btnKumasListesi.Name = "btnKumasListesi";
            btnKumasListesi.ItemClick += btnKumasListesi_ItemClick;
            // 
            // btnNewOrder
            // 
            btnNewOrder.Caption = "Yeni Sipariş";
            btnNewOrder.Id = 4;
            btnNewOrder.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnNewOrder.ImageOptions.Image");
            btnNewOrder.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnNewOrder.ImageOptions.LargeImage");
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.ItemClick += btnNewOrder_ItemClick;
            // 
            // btnSiparisListesi
            // 
            btnSiparisListesi.Caption = "Sipariş Listesi";
            btnSiparisListesi.Id = 5;
            btnSiparisListesi.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnSiparisListesi.ImageOptions.Image");
            btnSiparisListesi.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnSiparisListesi.ImageOptions.LargeImage");
            btnSiparisListesi.Name = "btnSiparisListesi";
            btnSiparisListesi.ItemClick += btnSiparisListesi_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2, ribbonPageGroup3 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Stok Yönetimi";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(btnYeniKumas);
            ribbonPageGroup1.ItemLinks.Add(btnKumasListesi);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Kumaş İşlemleri";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(btnNewOrder);
            ribbonPageGroup2.ItemLinks.Add(btnSiparisListesi);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Sipariş İşlemleri";
            // 
            // documentManager1
            // 
            documentManager1.MdiParent = this;
            documentManager1.MenuManager = ribbonControl1;
            documentManager1.View = tabbedView1;
            documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] { tabbedView1 });
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(btnNewCustomer);
            ribbonPageGroup3.ItemLinks.Add(btnListCustomers);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Müşteri İşlemleri";
            // 
            // btnNewCustomer
            // 
            btnNewCustomer.Caption = "Yeni Müşteri";
            btnNewCustomer.Id = 6;
            btnNewCustomer.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnNewCustomer.ImageOptions.Image");
            btnNewCustomer.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnNewCustomer.ImageOptions.LargeImage");
            btnNewCustomer.Name = "btnNewCustomer";
            btnNewCustomer.ItemClick += btnNewCustomer_ItemClick;
            // 
            // btnListCustomers
            // 
            btnListCustomers.Caption = "Müşteri Listesi";
            btnListCustomers.Id = 7;
            btnListCustomers.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnListCustomers.ImageOptions.Image");
            btnListCustomers.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnListCustomers.ImageOptions.LargeImage");
            btnListCustomers.Name = "btnListCustomers";
            btnListCustomers.ItemClick += btnListCustomers_ItemClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(973, 649);
            Controls.Add(ribbonControl1);
            IsMdiContainer = true;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "Form1";
            Ribbon = ribbonControl1;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)documentManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabbedView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnYeniKumas;
        private DevExpress.XtraBars.BarButtonItem btnKumasListesi;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem btnNewOrder;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnSiparisListesi;
        private DevExpress.XtraBars.BarButtonItem btnNewCustomer;
        private DevExpress.XtraBars.BarButtonItem btnListCustomers;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}

