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
            btnNewFabric = new DevExpress.XtraBars.BarButtonItem();
            btnFabricList = new DevExpress.XtraBars.BarButtonItem();
            btnNewOrder = new DevExpress.XtraBars.BarButtonItem();
            btnOrderList = new DevExpress.XtraBars.BarButtonItem();
            btnNewCustomer = new DevExpress.XtraBars.BarButtonItem();
            btnCustomerList = new DevExpress.XtraBars.BarButtonItem();
            btnProductionTrack = new DevExpress.XtraBars.BarButtonItem();
            btnDashboard = new DevExpress.XtraBars.BarButtonItem();
            btnStatistics = new DevExpress.XtraBars.BarButtonItem();
            btnQualityControl = new DevExpress.XtraBars.BarButtonItem();
            btnDefectedFabrics = new DevExpress.XtraBars.BarButtonItem();
            btnNewColor = new DevExpress.XtraBars.BarButtonItem();
            btnNewProductType = new DevExpress.XtraBars.BarButtonItem();
            btnColorList = new DevExpress.XtraBars.BarButtonItem();
            btnProductTypeList = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(components);
            tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(components);
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)documentManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabbedView1).BeginInit();
            SuspendLayout();
            //
            // ribbonControl1
            //
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 37, 35, 37);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, skinRibbonGalleryBarItem1, btnNewFabric, btnFabricList, btnNewOrder, btnOrderList, btnNewCustomer, btnCustomerList, btnProductionTrack, btnDashboard, btnStatistics, btnQualityControl, btnDefectedFabrics, btnNewColor, btnNewProductType, btnColorList, btnProductTypeList });
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
            // btnNewFabric
            //
            btnNewFabric.Caption = "New Fabric";
            btnNewFabric.Id = 2;
            btnNewFabric.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnNewFabric.ImageOptions.Image");
            btnNewFabric.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnNewFabric.ImageOptions.LargeImage");
            btnNewFabric.Name = "btnNewFabric";
            btnNewFabric.ItemClick += btnNewFabric_ItemClick;
            //
            // btnFabricList
            //
            btnFabricList.Caption = "Fabric List";
            btnFabricList.Id = 3;
            btnFabricList.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnFabricList.ImageOptions.Image");
            btnFabricList.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnFabricList.ImageOptions.LargeImage");
            btnFabricList.Name = "btnFabricList";
            btnFabricList.ItemClick += btnFabricList_ItemClick;
            //
            // btnNewOrder
            //
            btnNewOrder.Caption = "New Order";
            btnNewOrder.Id = 4;
            btnNewOrder.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnNewOrder.ImageOptions.Image");
            btnNewOrder.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnNewOrder.ImageOptions.LargeImage");
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.ItemClick += btnNewOrder_ItemClick;
            //
            // btnOrderList
            //
            btnOrderList.Caption = "Order List";
            btnOrderList.Id = 5;
            btnOrderList.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnOrderList.ImageOptions.Image");
            btnOrderList.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnOrderList.ImageOptions.LargeImage");
            btnOrderList.Name = "btnOrderList";
            btnOrderList.ItemClick += btnOrderList_ItemClick;
            //
            // btnNewCustomer
            //
            btnNewCustomer.Caption = "New Customer";
            btnNewCustomer.Id = 6;
            btnNewCustomer.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnNewCustomer.ImageOptions.Image");
            btnNewCustomer.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnNewCustomer.ImageOptions.LargeImage");
            btnNewCustomer.Name = "btnNewCustomer";
            btnNewCustomer.ItemClick += btnNewCustomer_ItemClick;
            //
            // btnCustomerList
            //
            btnCustomerList.Caption = "Customer List";
            btnCustomerList.Id = 7;
            btnCustomerList.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnListCustomers.ImageOptions.Image");
            btnCustomerList.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnListCustomers.ImageOptions.LargeImage");
            btnCustomerList.Name = "btnCustomerList";
            btnCustomerList.ItemClick += btnCustomerList_ItemClick;
            //
            // btnProductionTrack
            //
            btnProductionTrack.Caption = "Production Tracking";
            btnProductionTrack.Id = 8;
            btnProductionTrack.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnProductionTrack.ImageOptions.Image");
            btnProductionTrack.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnProductionTrack.ImageOptions.LargeImage");
            btnProductionTrack.Name = "btnProductionTrack";
            btnProductionTrack.ItemClick += btnProductionTrack_ItemClick;
            //
            // btnDashboard
            //
            btnDashboard.Caption = "Dashboard";
            btnDashboard.Id = 9;
            btnDashboard.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnDashboard.ImageOptions.Image");
            btnDashboard.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnDashboard.ImageOptions.LargeImage");
            btnDashboard.Name = "btnDashboard";
            btnDashboard.ItemClick += btnDashboard_ItemClick;
            //
            // btnStatistics
            //
            btnStatistics.Caption = "Statistics";
            btnStatistics.Id = 10;
            btnStatistics.ImageOptions.Image = UI.Properties.Resources.previewchart_16x16;
            btnStatistics.ImageOptions.LargeImage = UI.Properties.Resources.previewchart_32x32;
            btnStatistics.Name = "btnStatistics";
            btnStatistics.ItemClick += btnStatistics_ItemClick;
            //
            // btnQualityControl
            //
            btnQualityControl.Caption = "Quality Control";
            btnQualityControl.Id = 11;
            btnQualityControl.ImageOptions.Image = UI.Properties.Resources.find_16x161;
            btnQualityControl.ImageOptions.LargeImage = UI.Properties.Resources.find_32x321;
            btnQualityControl.Name = "btnQualityControl";
            btnQualityControl.ItemClick += btnQualityControl_ItemClick;
            //
            // btnDefectedFabrics
            //
            btnDefectedFabrics.Caption = "Defected Fabrics";
            btnDefectedFabrics.Id = 12;
            btnDefectedFabrics.ImageOptions.Image = UI.Properties.Resources.warning_16x16;
            btnDefectedFabrics.ImageOptions.LargeImage = UI.Properties.Resources.warning_32x32;
            btnDefectedFabrics.Name = "btnDefectedFabrics";
            btnDefectedFabrics.ItemClick += btnDefectedFabrics_ItemClick;
            //
            // btnNewColor
            //
            btnNewColor.Caption = "New Color";
            btnNewColor.Id = 13;
            btnNewColor.ImageOptions.Image = UI.Properties.Resources.colors_16x16;
            btnNewColor.ImageOptions.LargeImage = UI.Properties.Resources.colors_32x32;
            btnNewColor.Name = "btnNewColor";
            btnNewColor.ItemClick += btnNewColor_ItemClick;
            //
            // btnNewProductType
            //
            btnNewProductType.Caption = "New Product Type";
            btnNewProductType.Id = 14;
            btnNewProductType.ImageOptions.Image = UI.Properties.Resources.tag_16x16;
            btnNewProductType.ImageOptions.LargeImage = UI.Properties.Resources.tag_32x32;
            btnNewProductType.Name = "btnNewProductType";
            btnNewProductType.ItemClick += btnNewProductType_ItemClick;
            //
            // btnColorList
            //
            btnColorList.Caption = "Color List";
            btnColorList.Id = 15;
            btnColorList.ImageOptions.Image = UI.Properties.Resources.colorlegend_16x16;
            btnColorList.ImageOptions.LargeImage = UI.Properties.Resources.colorlegend_32x32;
            btnColorList.Name = "btnColorList";
            btnColorList.ItemClick += btnColorList_ItemClick;
            //
            // btnProductTypeList
            //
            btnProductTypeList.Caption = "Product Type List";
            btnProductTypeList.Id = 16;
            btnProductTypeList.ImageOptions.Image = UI.Properties.Resources.splittablecells_16x16;
            btnProductTypeList.ImageOptions.LargeImage = UI.Properties.Resources.splittablecells_32x32;
            btnProductTypeList.Name = "btnProductTypeList";
            btnProductTypeList.ItemClick += btnProductTypeList_ItemClick;
            //
            // ribbonPage1
            //
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup5, ribbonPageGroup2, ribbonPageGroup4, ribbonPageGroup1, ribbonPageGroup3, ribbonPageGroup6, ribbonPageGroup7, ribbonPageGroup8 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Operations";
            //
            // ribbonPageGroup5
            //
            ribbonPageGroup5.ItemLinks.Add(btnDashboard);
            ribbonPageGroup5.ItemLinks.Add(btnStatistics);
            ribbonPageGroup5.Name = "ribbonPageGroup5";
            ribbonPageGroup5.Text = "Reports";
            //
            // ribbonPageGroup2
            //
            ribbonPageGroup2.ItemLinks.Add(btnNewOrder);
            ribbonPageGroup2.ItemLinks.Add(btnOrderList);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Order Operations";
            //
            // ribbonPageGroup4
            //
            ribbonPageGroup4.ItemLinks.Add(btnProductionTrack);
            ribbonPageGroup4.Name = "ribbonPageGroup4";
            ribbonPageGroup4.Text = "Production";
            //
            // ribbonPageGroup1
            //
            ribbonPageGroup1.ItemLinks.Add(btnNewFabric);
            ribbonPageGroup1.ItemLinks.Add(btnFabricList);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Fabric Operations";
            //
            // ribbonPageGroup3
            //
            ribbonPageGroup3.ItemLinks.Add(btnNewCustomer);
            ribbonPageGroup3.ItemLinks.Add(btnCustomerList);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Customer Operations";
            //
            // ribbonPageGroup6
            //
            ribbonPageGroup6.ItemLinks.Add(btnQualityControl);
            ribbonPageGroup6.ItemLinks.Add(btnDefectedFabrics);
            ribbonPageGroup6.Name = "ribbonPageGroup6";
            ribbonPageGroup6.Text = "Quality Control";
            //
            // ribbonPageGroup7
            //
            ribbonPageGroup7.ItemLinks.Add(btnNewColor);
            ribbonPageGroup7.ItemLinks.Add(btnColorList);
            ribbonPageGroup7.Name = "ribbonPageGroup7";
            ribbonPageGroup7.Text = "Color Operations";
            //
            // ribbonPageGroup8
            //
            ribbonPageGroup8.ItemLinks.Add(btnNewProductType);
            ribbonPageGroup8.ItemLinks.Add(btnProductTypeList);
            ribbonPageGroup8.Name = "ribbonPageGroup8";
            ribbonPageGroup8.Text = "Product Type Operations";
            //
            // documentManager1
            //
            documentManager1.MdiParent = this;
            documentManager1.MenuManager = ribbonControl1;
            documentManager1.View = tabbedView1;
            documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] { tabbedView1 });
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
            Text = "OtoTechstil";
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
        private DevExpress.XtraBars.BarButtonItem btnNewFabric;
        private DevExpress.XtraBars.BarButtonItem btnFabricList;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem btnNewOrder;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnOrderList;
        private DevExpress.XtraBars.BarButtonItem btnNewCustomer;
        private DevExpress.XtraBars.BarButtonItem btnCustomerList;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnProductionTrack;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnDashboard;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnStatistics;
        private DevExpress.XtraBars.BarButtonItem btnQualityControl;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnDefectedFabrics;
        private DevExpress.XtraBars.BarButtonItem btnNewColor;
        private DevExpress.XtraBars.BarButtonItem btnNewProductType;
        private DevExpress.XtraBars.BarButtonItem btnColorList;
        private DevExpress.XtraBars.BarButtonItem btnProductTypeList;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
    }
}
