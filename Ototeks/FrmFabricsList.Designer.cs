namespace Ototeks.UI
{
    partial class FrmFabricsList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFabricsList));
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            bindingSource1 = new System.Windows.Forms.BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFabricCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colFabricName = new DevExpress.XtraGrid.Columns.GridColumn();
            colStockQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            colColor = new DevExpress.XtraGrid.Columns.GridColumn();
            sagTikMenu = new DevExpress.XtraBars.PopupMenu(components);
            btnDelete = new DevExpress.XtraBars.BarButtonItem();
            btnAdd = new DevExpress.XtraBars.BarButtonItem();
            btnUpdate = new DevExpress.XtraBars.BarButtonItem();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sagTikMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            SuspendLayout();
            // 
            // gridControl1
            // 
            gridControl1.DataSource = bindingSource1;
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.Location = new System.Drawing.Point(32, 32);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(787, 548);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Entities.Fabric);
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFabricCode, colFabricName, colStockQuantity, colColor });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.PopupMenuShowing += gridView1_PopupMenuShowing;
            gridView1.DoubleClick += gridView1_DoubleClick;
            // 
            // colFabricCode
            // 
            colFabricCode.Caption = "Kumaş Kodu";
            colFabricCode.FieldName = "FabricCode";
            colFabricCode.MinWidth = 25;
            colFabricCode.Name = "colFabricCode";
            colFabricCode.Visible = true;
            colFabricCode.VisibleIndex = 0;
            colFabricCode.Width = 94;
            // 
            // colFabricName
            // 
            colFabricName.Caption = "Kumaş Adı";
            colFabricName.FieldName = "FabricName";
            colFabricName.MinWidth = 25;
            colFabricName.Name = "colFabricName";
            colFabricName.Visible = true;
            colFabricName.VisibleIndex = 1;
            colFabricName.Width = 94;
            // 
            // colStockQuantity
            // 
            colStockQuantity.Caption = "Stok Miktarı";
            colStockQuantity.FieldName = "StockQuantity";
            colStockQuantity.MinWidth = 25;
            colStockQuantity.Name = "colStockQuantity";
            colStockQuantity.Visible = true;
            colStockQuantity.VisibleIndex = 2;
            colStockQuantity.Width = 94;
            // 
            // colColor
            // 
            colColor.Caption = "Renk";
            colColor.FieldName = "Color";
            colColor.MinWidth = 25;
            colColor.Name = "colColor";
            colColor.Visible = true;
            colColor.VisibleIndex = 3;
            colColor.Width = 94;
            // 
            // sagTikMenu
            // 
            sagTikMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(btnDelete), new DevExpress.XtraBars.LinkPersistInfo(btnAdd), new DevExpress.XtraBars.LinkPersistInfo(btnUpdate) });
            sagTikMenu.Manager = barManager1;
            sagTikMenu.Name = "sagTikMenu";
            // 
            // btnDelete
            // 
            btnDelete.Caption = "Sil";
            btnDelete.Id = 0;
            btnDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnDelete.ImageOptions.SvgImage");
            btnDelete.Name = "btnDelete";
            btnDelete.ItemClick += btnDelete_ItemClick;
            // 
            // btnAdd
            // 
            btnAdd.Caption = "Kumaş Ekle";
            btnAdd.Id = 1;
            btnAdd.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnAdd.ImageOptions.SvgImage");
            btnAdd.Name = "btnAdd";
            btnAdd.ItemClick += btnAdd_ItemClick;
            // 
            // btnUpdate
            // 
            btnUpdate.Caption = "Güncelle";
            btnUpdate.Id = 2;
            btnUpdate.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnUpdate.ImageOptions.SvgImage");
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ItemClick += btnUpdate_ItemClick;
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
            barDockControlTop.Location = new System.Drawing.Point(32, 32);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(787, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(32, 580);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(787, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(32, 32);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 548);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(819, 32);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 548);
            // 
            // FrmListFabrics
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(851, 612);
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "FrmListFabrics";
            Padding = new System.Windows.Forms.Padding(32);
            Text = "Kumaş Listesi";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += FrmListFabrics_Load;
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sagTikMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colFabricCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFabricName;
        private DevExpress.XtraGrid.Columns.GridColumn colStockQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colColor;
        private DevExpress.XtraBars.PopupMenu sagTikMenu;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnUpdate;
    }
}