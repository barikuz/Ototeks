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
            btnNewCustomer = new DevExpress.XtraBars.BarButtonItem();
            btnListCustomers = new DevExpress.XtraBars.BarButtonItem();
            btnProductionTrack = new DevExpress.XtraBars.BarButtonItem();
            btnDashboard = new DevExpress.XtraBars.BarButtonItem();
            btnStatistics = new DevExpress.XtraBars.BarButtonItem();
            btnQualityControl = new DevExpress.XtraBars.BarButtonItem();
            btnDefectedFabrics = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(components);
            tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(components);
            ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            btnAddColor = new DevExpress.XtraBars.BarButtonItem();
            btnAddProductType = new DevExpress.XtraBars.BarButtonItem();
            btnListColors = new DevExpress.XtraBars.BarButtonItem();
            btnListProductTypes = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)documentManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabbedView1).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 37, 35, 37);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, skinRibbonGalleryBarItem1, btnYeniKumas, btnKumasListesi, btnNewOrder, btnSiparisListesi, btnNewCustomer, btnListCustomers, btnProductionTrack, btnDashboard, btnStatistics, btnQualityControl, btnDefectedFabrics, btnAddColor, btnAddProductType, btnListColors, btnListProductTypes });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.Margin = new System.Windows.Forms.Padding(4);
            ribbonControl1.MaxItemId = 17;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsMenuMinWidth = 385;
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl1.Size = new System.Drawing.Size(1620, 242);
            ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
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
            // btnProductionTrack
            // 
            btnProductionTrack.Caption = "Üretim Takibi";
            btnProductionTrack.Id = 8;
            btnProductionTrack.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnProductionTrack.ImageOptions.Image");
            btnProductionTrack.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnProductionTrack.ImageOptions.LargeImage");
            btnProductionTrack.Name = "btnProductionTrack";
            btnProductionTrack.ItemClick += btnProductionTrack_ItemClick;
            // 
            // btnDashboard
            // 
            btnDashboard.Caption = "Genel Bakış";
            btnDashboard.Id = 9;
            btnDashboard.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnDashboard.ImageOptions.Image");
            btnDashboard.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnDashboard.ImageOptions.LargeImage");
            btnDashboard.Name = "btnDashboard";
            btnDashboard.ItemClick += btnDashboard_ItemClick;
            // 
            // btnStatistics
            // 
            btnStatistics.Caption = "İstatistik";
            btnStatistics.Id = 10;
            btnStatistics.ImageOptions.Image = UI.Properties.Resources.previewchart_16x16;
            btnStatistics.ImageOptions.LargeImage = UI.Properties.Resources.previewchart_32x32;
            btnStatistics.Name = "btnStatistics";
            btnStatistics.ItemClick += btnStatistics_ItemClick;
            // 
            // btnQualityControl
            // 
            btnQualityControl.Caption = "Kumaş Kontrol";
            btnQualityControl.Id = 11;
            btnQualityControl.ImageOptions.Image = UI.Properties.Resources.find_16x161;
            btnQualityControl.ImageOptions.LargeImage = UI.Properties.Resources.find_32x321;
            btnQualityControl.Name = "btnQualityControl";
            btnQualityControl.ItemClick += btnQualityControl_ItemClick;
            // 
            // btnDefectedFabrics
            // 
            btnDefectedFabrics.Caption = "Hatalı Kumaşlar";
            btnDefectedFabrics.Id = 12;
            btnDefectedFabrics.ImageOptions.Image = UI.Properties.Resources.warning_16x16;
            btnDefectedFabrics.ImageOptions.LargeImage = UI.Properties.Resources.warning_32x32;
            btnDefectedFabrics.Name = "btnDefectedFabrics";
            btnDefectedFabrics.ItemClick += btnDefectedFabrics_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup5, ribbonPageGroup2, ribbonPageGroup4, ribbonPageGroup1, ribbonPageGroup3, ribbonPageGroup6, ribbonPageGroup7, ribbonPageGroup8 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "İşlemler";
            // 
            // ribbonPageGroup5
            // 
            ribbonPageGroup5.ItemLinks.Add(btnDashboard);
            ribbonPageGroup5.ItemLinks.Add(btnStatistics);
            ribbonPageGroup5.Name = "ribbonPageGroup5";
            ribbonPageGroup5.Text = "Raporlama";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(btnNewOrder);
            ribbonPageGroup2.ItemLinks.Add(btnSiparisListesi);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Sipariş İşlemleri";
            // 
            // ribbonPageGroup4
            // 
            ribbonPageGroup4.ItemLinks.Add(btnProductionTrack);
            ribbonPageGroup4.Name = "ribbonPageGroup4";
            ribbonPageGroup4.Text = "Üretim İşlemleri";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(btnYeniKumas);
            ribbonPageGroup1.ItemLinks.Add(btnKumasListesi);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Kumaş İşlemleri";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(btnNewCustomer);
            ribbonPageGroup3.ItemLinks.Add(btnListCustomers);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Müşteri İşlemleri";
            // 
            // ribbonPageGroup6
            // 
            ribbonPageGroup6.ItemLinks.Add(btnQualityControl);
            ribbonPageGroup6.ItemLinks.Add(btnDefectedFabrics);
            ribbonPageGroup6.Name = "ribbonPageGroup6";
            ribbonPageGroup6.Text = "Kalite Kontrol";
            // 
            // documentManager1
            // 
            documentManager1.MdiParent = this;
            documentManager1.MenuManager = ribbonControl1;
            documentManager1.View = tabbedView1;
            documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] { tabbedView1 });
            // 
            // ribbonPageGroup7
            // 
            ribbonPageGroup7.ItemLinks.Add(btnAddColor);
            ribbonPageGroup7.ItemLinks.Add(btnListColors);
            ribbonPageGroup7.Name = "ribbonPageGroup7";
            ribbonPageGroup7.Text = "Renk İşlemleri";
            // 
            // ribbonPageGroup8
            // 
            ribbonPageGroup8.ItemLinks.Add(btnAddProductType);
            ribbonPageGroup8.ItemLinks.Add(btnListProductTypes);
            ribbonPageGroup8.Name = "ribbonPageGroup8";
            ribbonPageGroup8.Text = "Ürün Tipi İşlemleri";
            // 
            // btnAddColor
            // 
            btnAddColor.Caption = "Yeni Renk";
            btnAddColor.Id = 13;
            btnAddColor.ImageOptions.Image = UI.Properties.Resources.colors_16x16;
            btnAddColor.ImageOptions.LargeImage = UI.Properties.Resources.colors_32x32;
            btnAddColor.Name = "btnAddColor";
            btnAddColor.ItemClick += btnAddColor_ItemClick;
            // 
            // btnAddProductType
            // 
            btnAddProductType.Caption = "Yeni Ürün Tipi";
            btnAddProductType.Id = 14;
            btnAddProductType.ImageOptions.Image = UI.Properties.Resources.tag_16x16;
            btnAddProductType.ImageOptions.LargeImage = UI.Properties.Resources.tag_32x32;
            btnAddProductType.Name = "btnAddProductType";
            btnAddProductType.ItemClick += btnAddProductType_ItemClick;
            // 
            // btnListColors
            // 
            btnListColors.Caption = "Renk Listesi";
            btnListColors.Id = 15;
            btnListColors.ImageOptions.Image = UI.Properties.Resources.colorlegend_16x16;
            btnListColors.ImageOptions.LargeImage = UI.Properties.Resources.colorlegend_32x32;
            btnListColors.Name = "btnListColors";
            btnListColors.ItemClick += btnListColors_ItemClick;
            // 
            // btnListProductTypes
            // 
            btnListProductTypes.Caption = "Ürün Tipi Listesi";
            btnListProductTypes.Id = 16;
            btnListProductTypes.ImageOptions.Image = UI.Properties.Resources.splittablecells_16x16;
            btnListProductTypes.ImageOptions.LargeImage = UI.Properties.Resources.splittablecells_32x32;
            btnListProductTypes.Name = "btnListProductTypes";
            btnListProductTypes.ItemClick += btnListProductTypes_ItemClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1620, 649);
            Controls.Add(ribbonControl1);
            IsMdiContainer = true;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "Form1";
            Ribbon = ribbonControl1;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Ototeks";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += Form1_Load;
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
        private DevExpress.XtraBars.BarButtonItem btnProductionTrack;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnDashboard;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnStatistics;
        private DevExpress.XtraBars.BarButtonItem btnQualityControl;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnDefectedFabrics;
        private DevExpress.XtraBars.BarButtonItem btnAddColor;
        private DevExpress.XtraBars.BarButtonItem btnAddProductType;
        private DevExpress.XtraBars.BarButtonItem btnListColors;
        private DevExpress.XtraBars.BarButtonItem btnListProductTypes;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
    }
}

