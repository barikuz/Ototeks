namespace Ototeks.UI
{
    partial class FrmListFabrics
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
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            bindingSource1 = new System.Windows.Forms.BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFabricCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colFabricName = new DevExpress.XtraGrid.Columns.GridColumn();
            colStockQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            colColor = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // gridControl1
            // 
            gridControl1.DataSource = bindingSource1;
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.Location = new System.Drawing.Point(32, 32);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(534, 385);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            gridControl1.Click += gridControl1_Click;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Entities.Fabric);
            bindingSource1.CurrentChanged += bindingSource1_CurrentChanged;
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFabricCode, colFabricName, colStockQuantity, colColor });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
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
            // FrmKumasListesi
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(598, 449);
            Controls.Add(gridControl1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "FrmKumasListesi";
            Padding = new System.Windows.Forms.Padding(32);
            Text = "Kumaş Listesi";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += FrmKumasListesi_Load;
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colFabricCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFabricName;
        private DevExpress.XtraGrid.Columns.GridColumn colStockQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colColor;
    }
}