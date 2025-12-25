namespace Ototeks.UI
{
    partial class FrmOrderList
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrderList));
            gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFabricType = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductType = new DevExpress.XtraGrid.Columns.GridColumn();
            colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrentStage = new DevExpress.XtraGrid.Columns.GridColumn();
            gridOrders = new DevExpress.XtraGrid.GridControl();
            orderBindingSource = new System.Windows.Forms.BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrderStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            sagTikMenu = new DevExpress.XtraBars.PopupMenu(components);
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            btnDelete = new DevExpress.XtraBars.BarButtonItem();
            btnAdd = new DevExpress.XtraBars.BarButtonItem();
            btnUpdate = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)gridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sagTikMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            SuspendLayout();
            // 
            // gridView2
            // 
            gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFabricType, colProductType, colQuantity, colCurrentStage });
            gridView2.GridControl = gridOrders;
            gridView2.Name = "gridView2";
            gridView2.OptionsBehavior.Editable = false;
            gridView2.CustomColumnDisplayText += gridView2_CustomColumnDisplayText;
            // 
            // colFabricType
            // 
            colFabricType.Caption = "Kumaş Türü";
            colFabricType.FieldName = "Fabric.FabricName";
            colFabricType.MinWidth = 25;
            colFabricType.Name = "colFabricType";
            colFabricType.Visible = true;
            colFabricType.VisibleIndex = 0;
            colFabricType.Width = 94;
            // 
            // colProductType
            // 
            colProductType.Caption = "Ürün Türü";
            colProductType.FieldName = "Type.TypeName";
            colProductType.MinWidth = 25;
            colProductType.Name = "colProductType";
            colProductType.Visible = true;
            colProductType.VisibleIndex = 1;
            colProductType.Width = 94;
            // 
            // colQuantity
            // 
            colQuantity.Caption = "Adet";
            colQuantity.FieldName = "Quantity";
            colQuantity.MinWidth = 25;
            colQuantity.Name = "colQuantity";
            colQuantity.Visible = true;
            colQuantity.VisibleIndex = 2;
            colQuantity.Width = 94;
            // 
            // colCurrentStage
            // 
            colCurrentStage.Caption = "Kalem Durumu";
            colCurrentStage.FieldName = "CurrentStage";
            colCurrentStage.MinWidth = 25;
            colCurrentStage.Name = "colCurrentStage";
            colCurrentStage.Visible = true;
            colCurrentStage.VisibleIndex = 3;
            colCurrentStage.Width = 94;
            // 
            // gridOrders
            // 
            gridOrders.DataSource = orderBindingSource;
            gridOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode2.LevelTemplate = gridView2;
            gridLevelNode2.RelationName = "OrderItems";
            gridOrders.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode2 });
            gridOrders.Location = new System.Drawing.Point(0, 0);
            gridOrders.MainView = gridView1;
            gridOrders.Name = "gridOrders";
            gridOrders.Size = new System.Drawing.Size(551, 443);
            gridOrders.TabIndex = 0;
            gridOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1, gridView2 });
            // 
            // orderBindingSource
            // 
            orderBindingSource.DataSource = typeof(Entities.Order);
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colOrderNumber, colOrderDate, colDueDate, colOrderStatus, colCustomer });
            gridView1.GridControl = gridOrders;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsDetail.ShowDetailTabs = false;
            gridView1.CustomColumnDisplayText += gridView1_CustomColumnDisplayText;
            gridView1.PopupMenuShowing += gridView1_PopupMenuShowing;
            gridView1.DoubleClick += gridView1_DoubleClick;
            // 
            // colOrderNumber
            // 
            colOrderNumber.Caption = "Sipariş Numarası";
            colOrderNumber.FieldName = "OrderNumber";
            colOrderNumber.MinWidth = 25;
            colOrderNumber.Name = "colOrderNumber";
            colOrderNumber.Visible = true;
            colOrderNumber.VisibleIndex = 0;
            colOrderNumber.Width = 94;
            // 
            // colOrderDate
            // 
            colOrderDate.Caption = "Sipariş Tarihi";
            colOrderDate.FieldName = "OrderDate";
            colOrderDate.MinWidth = 25;
            colOrderDate.Name = "colOrderDate";
            colOrderDate.Visible = true;
            colOrderDate.VisibleIndex = 2;
            colOrderDate.Width = 94;
            // 
            // colDueDate
            // 
            colDueDate.Caption = "Teslim Tarihi";
            colDueDate.FieldName = "DueDate";
            colDueDate.MinWidth = 25;
            colDueDate.Name = "colDueDate";
            colDueDate.Visible = true;
            colDueDate.VisibleIndex = 3;
            colDueDate.Width = 94;
            // 
            // colOrderStatus
            // 
            colOrderStatus.Caption = "Sipariş Durumu";
            colOrderStatus.FieldName = "OrderStatus";
            colOrderStatus.MinWidth = 25;
            colOrderStatus.Name = "colOrderStatus";
            colOrderStatus.Visible = true;
            colOrderStatus.VisibleIndex = 4;
            colOrderStatus.Width = 94;
            // 
            // colCustomer
            // 
            colCustomer.Caption = "Müşteri";
            colCustomer.FieldName = "Customer.CustomerName";
            colCustomer.MinWidth = 25;
            colCustomer.Name = "colCustomer";
            colCustomer.Visible = true;
            colCustomer.VisibleIndex = 1;
            colCustomer.Width = 94;
            // 
            // sagTikMenu
            // 
            sagTikMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(btnUpdate), new DevExpress.XtraBars.LinkPersistInfo(btnDelete), new DevExpress.XtraBars.LinkPersistInfo(btnAdd) });
            sagTikMenu.Manager = barManager1;
            sagTikMenu.Name = "sagTikMenu";
            // 
            // barManager1
            // 
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { btnDelete, btnAdd, btnUpdate });
            barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(551, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 443);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(551, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 443);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(551, 0);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 443);
            // 
            // btnDelete
            // 
            btnDelete.Caption = "Sil";
            btnDelete.Id = 0;
            btnDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem1.ImageOptions.SvgImage");
            btnDelete.Name = "btnDelete";
            btnDelete.ItemClick += btnDelete_ItemClick;
            // 
            // btnAdd
            // 
            btnAdd.Caption = "Sipariş Ekle";
            btnAdd.Id = 1;
            btnAdd.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem2.ImageOptions.SvgImage");
            btnAdd.Name = "btnAdd";
            btnAdd.ItemClick += btnAdd_ItemClick;
            // 
            // btnUpdate
            // 
            btnUpdate.Caption = "Güncelle";
            btnUpdate.Id = 2;
            btnUpdate.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem3.ImageOptions.SvgImage");
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ItemClick += btnUpdate_ItemClick;
            // 
            // FrmOrderList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(551, 443);
            Controls.Add(gridOrders);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "FrmOrderList";
            Text = "Sipariş Listesi";
            Load += FrmOrderList_Load;
            ((System.ComponentModel.ISupportInitialize)gridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sagTikMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridOrders;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colFabricType;
        private DevExpress.XtraGrid.Columns.GridColumn colProductType;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentStage;
        private DevExpress.XtraBars.PopupMenu sagTikMenu;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnUpdate;
    }
}