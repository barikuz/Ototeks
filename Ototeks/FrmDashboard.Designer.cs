namespace Ototeks.UI
{
    partial class FrmDashboard
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            tileControl1 = new DevExpress.XtraEditors.TileControl();
            tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            tileOrder = new DevExpress.XtraEditors.TileItem();
            tileGroup3 = new DevExpress.XtraEditors.TileGroup();
            tileStock = new DevExpress.XtraEditors.TileItem();
            tileGroup4 = new DevExpress.XtraEditors.TileGroup();
            tileCustomer = new DevExpress.XtraEditors.TileItem();
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            panelDeliveryAlerts = new DevExpress.XtraEditors.PanelControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colMusteriAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            colTeslimTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            colKalanGun = new DevExpress.XtraGrid.Columns.GridColumn();
            colDurum = new DevExpress.XtraGrid.Columns.GridColumn();
            lblDeliveryAlertsTitle = new DevExpress.XtraEditors.LabelControl();
            chartControl1 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).BeginInit();
            splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).BeginInit();
            splitContainerControl1.Panel2.SuspendLayout();
            splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelDeliveryAlerts).BeginInit();
            panelDeliveryAlerts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series1).BeginInit();
            SuspendLayout();
            // 
            // tileControl1
            // 
            tileControl1.Dock = System.Windows.Forms.DockStyle.Top;
            tileControl1.Groups.Add(tileGroup2);
            tileControl1.Groups.Add(tileGroup3);
            tileControl1.Groups.Add(tileGroup4);
            tileControl1.Location = new System.Drawing.Point(0, 0);
            tileControl1.MaxId = 5;
            tileControl1.Name = "tileControl1";
            tileControl1.Size = new System.Drawing.Size(1118, 240);
            tileControl1.TabIndex = 0;
            tileControl1.Text = "tileControl1";
            // 
            // tileGroup2
            // 
            tileGroup2.Items.Add(tileOrder);
            tileGroup2.Name = "tileGroup2";
            // 
            // tileOrder
            // 
            tileOrder.AppearanceItem.Normal.BackColor = System.Drawing.Color.RoyalBlue;
            tileOrder.AppearanceItem.Normal.Options.UseBackColor = true;
            tileItemElement1.Appearance.Normal.FontSizeDelta = 2;
            tileItemElement1.Appearance.Normal.Options.UseFont = true;
            tileItemElement1.Text = "Bekleyen Sipariş";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileItemElement2.Appearance.Normal.FontSizeDelta = 15;
            tileItemElement2.Appearance.Normal.Options.UseFont = true;
            tileItemElement2.Text = "0";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileOrder.Elements.Add(tileItemElement1);
            tileOrder.Elements.Add(tileItemElement2);
            tileOrder.Id = 2;
            tileOrder.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            tileOrder.Name = "tileOrder";
            tileOrder.ItemClick += tileOrder_ItemClick;
            // 
            // tileGroup3
            // 
            tileGroup3.Items.Add(tileStock);
            tileGroup3.Name = "tileGroup3";
            // 
            // tileStock
            // 
            tileStock.AppearanceItem.Normal.BackColor = System.Drawing.Color.Firebrick;
            tileStock.AppearanceItem.Normal.Options.UseBackColor = true;
            tileItemElement3.Appearance.Normal.FontSizeDelta = 2;
            tileItemElement3.Appearance.Normal.Options.UseFont = true;
            tileItemElement3.Text = "Kritik Stok";
            tileItemElement4.Appearance.Normal.FontSizeDelta = 15;
            tileItemElement4.Appearance.Normal.Options.UseFont = true;
            tileItemElement4.Text = "0";
            tileItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileStock.Elements.Add(tileItemElement3);
            tileStock.Elements.Add(tileItemElement4);
            tileStock.Id = 3;
            tileStock.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            tileStock.Name = "tileStock";
            tileStock.ItemClick += tileStock_ItemClick;
            // 
            // tileGroup4
            // 
            tileGroup4.Items.Add(tileCustomer);
            tileGroup4.Name = "tileGroup4";
            // 
            // tileCustomer
            // 
            tileCustomer.AppearanceItem.Normal.BackColor = System.Drawing.Color.SeaGreen;
            tileCustomer.AppearanceItem.Normal.Options.UseBackColor = true;
            tileItemElement5.Appearance.Normal.FontSizeDelta = 2;
            tileItemElement5.Appearance.Normal.Options.UseFont = true;
            tileItemElement5.Text = "Toplam Müşteri";
            tileItemElement6.Appearance.Normal.FontSizeDelta = 15;
            tileItemElement6.Appearance.Normal.Options.UseFont = true;
            tileItemElement6.Text = "0";
            tileItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileCustomer.Elements.Add(tileItemElement5);
            tileCustomer.Elements.Add(tileItemElement6);
            tileCustomer.Id = 4;
            tileCustomer.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            tileCustomer.Name = "tileCustomer";
            tileCustomer.ItemClick += tileCustomer_ItemClick;
            // 
            // panelControl1
            // 
            panelControl1.Controls.Add(splitContainerControl1);
            panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl1.Location = new System.Drawing.Point(0, 240);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new System.Drawing.Size(1118, 520);
            panelControl1.TabIndex = 1;
            // 
            // splitContainerControl1
            // 
            splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            splitContainerControl1.Location = new System.Drawing.Point(2, 2);
            splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            splitContainerControl1.Panel1.Controls.Add(panelDeliveryAlerts);
            splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            splitContainerControl1.Panel2.Controls.Add(chartControl1);
            splitContainerControl1.Panel2.Text = "Panel2";
            splitContainerControl1.Size = new System.Drawing.Size(1114, 516);
            splitContainerControl1.SplitterPosition = 553;
            splitContainerControl1.TabIndex = 0;
            // 
            // panelDeliveryAlerts
            // 
            panelDeliveryAlerts.Controls.Add(gridControl1);
            panelDeliveryAlerts.Controls.Add(lblDeliveryAlertsTitle);
            panelDeliveryAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            panelDeliveryAlerts.Location = new System.Drawing.Point(0, 0);
            panelDeliveryAlerts.Name = "panelDeliveryAlerts";
            panelDeliveryAlerts.Size = new System.Drawing.Size(553, 516);
            panelDeliveryAlerts.TabIndex = 1;
            // 
            // gridControl1
            // 
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.Location = new System.Drawing.Point(2, 35);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(549, 479);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colOrderNumber, colMusteriAdi, colTeslimTarihi, colKalanGun, colDurum });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.RowStyle += gridView1_RowStyle;
            // 
            // colOrderNumber
            // 
            colOrderNumber.Caption = "Sipariş No";
            colOrderNumber.FieldName = "OrderNumber";
            colOrderNumber.Name = "colOrderNumber";
            colOrderNumber.Visible = true;
            colOrderNumber.VisibleIndex = 0;
            // 
            // colMusteriAdi
            // 
            colMusteriAdi.Caption = "Müşteri";
            colMusteriAdi.FieldName = "MusteriAdi";
            colMusteriAdi.Name = "colMusteriAdi";
            colMusteriAdi.Visible = true;
            colMusteriAdi.VisibleIndex = 1;
            // 
            // colTeslimTarihi
            // 
            colTeslimTarihi.Caption = "Teslim Tarihi";
            colTeslimTarihi.DisplayFormat.FormatString = "dd.MM.yyyy";
            colTeslimTarihi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colTeslimTarihi.FieldName = "TeslimTarihi";
            colTeslimTarihi.Name = "colTeslimTarihi";
            colTeslimTarihi.Visible = true;
            colTeslimTarihi.VisibleIndex = 2;
            // 
            // colKalanGun
            // 
            colKalanGun.Caption = "Kalan Gün";
            colKalanGun.FieldName = "KalanGun";
            colKalanGun.Name = "colKalanGun";
            colKalanGun.Visible = true;
            colKalanGun.VisibleIndex = 3;
            // 
            // colDurum
            // 
            colDurum.Caption = "Durum";
            colDurum.FieldName = "Durum";
            colDurum.Name = "colDurum";
            colDurum.Visible = true;
            colDurum.VisibleIndex = 4;
            // 
            // lblDeliveryAlertsTitle
            // 
            lblDeliveryAlertsTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            lblDeliveryAlertsTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblDeliveryAlertsTitle.Appearance.Options.UseFont = true;
            lblDeliveryAlertsTitle.Appearance.Options.UseForeColor = true;
            lblDeliveryAlertsTitle.Appearance.Options.UseTextOptions = true;
            lblDeliveryAlertsTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblDeliveryAlertsTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblDeliveryAlertsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblDeliveryAlertsTitle.Location = new System.Drawing.Point(2, 2);
            lblDeliveryAlertsTitle.Name = "lblDeliveryAlertsTitle";
            lblDeliveryAlertsTitle.Padding = new System.Windows.Forms.Padding(5);
            lblDeliveryAlertsTitle.Size = new System.Drawing.Size(549, 33);
            lblDeliveryAlertsTitle.TabIndex = 1;
            lblDeliveryAlertsTitle.Text = "Teslim Tarihi Yaklaşan Siparişler";
            // 
            // chartControl1
            // 
            xyDiagram1.AxisX.Label.Angle = -45;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            chartControl1.Diagram = xyDiagram1;
            chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            chartControl1.Location = new System.Drawing.Point(0, 0);
            chartControl1.Name = "chartControl1";
            series1.Name = "stagesBarChart";
            series1.SeriesID = 0;
            chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[]
    {
    series1
    };
            chartControl1.Size = new System.Drawing.Size(541, 516);
            chartControl1.TabIndex = 0;
            chartTitle1.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 12F, DevExpress.Drawing.DXFontStyle.Bold);
            chartTitle1.Text = "Üretim Aşamalarına Göre Sipariş Dağılımı";
            chartTitle1.TitleID = 0;
            chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle1 });
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1118, 760);
            Controls.Add(panelControl1);
            Controls.Add(tileControl1);
            Name = "FrmDashboard";
            Text = "Genel Bakış";
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).EndInit();
            splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).EndInit();
            splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).EndInit();
            splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelDeliveryAlerts).EndInit();
            panelDeliveryAlerts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram1).EndInit();
            ((System.ComponentModel.ISupportInitialize)series1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileGroup tileGroup3;
        private DevExpress.XtraEditors.TileGroup tileGroup4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TileItem tileOrder;
        private DevExpress.XtraEditors.TileItem tileStock;
        private DevExpress.XtraEditors.TileItem tileCustomer;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelDeliveryAlerts;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colTeslimTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colKalanGun;
        private DevExpress.XtraGrid.Columns.GridColumn colDurum;
        private DevExpress.XtraEditors.LabelControl lblDeliveryAlertsTitle;
        private DevExpress.XtraCharts.ChartControl chartControl1;
    }
}