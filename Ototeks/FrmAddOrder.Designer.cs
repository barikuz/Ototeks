namespace Ototeks.UI
{
    partial class FrmAddOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddOrder));
            tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            lkpMusteri = new DevExpress.XtraEditors.LookUpEdit();
            btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            gridSiparisKalemleri = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridTypeIdColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            repoProductType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridFabricIdColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            repoFabric = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridQuantityColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            dateTarih = new DevExpress.XtraEditors.DateEdit();
            txtSiparisNo = new DevExpress.XtraEditors.TextEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lkpMusteri.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSiparisKalemleri).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoProductType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoFabric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateTarih.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateTarih.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSiparisNo.Properties).BeginInit();
            SuspendLayout();
            // 
            // tablePanel1
            // 
            tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F) });
            tablePanel1.Controls.Add(lkpMusteri);
            tablePanel1.Controls.Add(btnKaydet);
            tablePanel1.Controls.Add(groupControl1);
            tablePanel1.Controls.Add(dateTarih);
            tablePanel1.Controls.Add(txtSiparisNo);
            tablePanel1.Controls.Add(labelControl4);
            tablePanel1.Controls.Add(labelControl3);
            tablePanel1.Controls.Add(labelControl2);
            tablePanel1.Controls.Add(labelControl1);
            tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel1.Location = new System.Drawing.Point(0, 0);
            tablePanel1.Name = "tablePanel1";
            tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 50F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 60F) });
            tablePanel1.Size = new System.Drawing.Size(640, 551);
            tablePanel1.TabIndex = 0;
            tablePanel1.UseSkinIndents = true;
            // 
            // lkpMusteri
            // 
            tablePanel1.SetColumn(lkpMusteri, 1);
            lkpMusteri.Location = new System.Drawing.Point(141, 110);
            lkpMusteri.Name = "lkpMusteri";
            lkpMusteri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lkpMusteri.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Müşteri Adı") });
            lkpMusteri.Properties.DisplayMember = "CustomerName";
            lkpMusteri.Properties.NullText = "Bir müşteri seçiniz...";
            lkpMusteri.Properties.ValueMember = "CustomerId";
            tablePanel1.SetRow(lkpMusteri, 2);
            lkpMusteri.Size = new System.Drawing.Size(478, 34);
            lkpMusteri.TabIndex = 8;
            // 
            // btnKaydet
            // 
            btnKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            btnKaydet.Appearance.Options.UseFont = true;
            tablePanel1.SetColumn(btnKaydet, 0);
            tablePanel1.SetColumnSpan(btnKaydet, 2);
            btnKaydet.Dock = System.Windows.Forms.DockStyle.Fill;
            btnKaydet.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnKaydet.ImageOptions.Image");
            btnKaydet.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnKaydet.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            btnKaydet.Location = new System.Drawing.Point(21, 478);
            btnKaydet.Name = "btnKaydet";
            tablePanel1.SetRow(btnKaydet, 5);
            btnKaydet.Size = new System.Drawing.Size(598, 52);
            btnKaydet.TabIndex = 7;
            btnKaydet.Text = "Siparişi Tamamla";
            btnKaydet.Click += btnKaydet_Click;
            // 
            // groupControl1
            // 
            tablePanel1.SetColumn(groupControl1, 0);
            tablePanel1.SetColumnSpan(groupControl1, 2);
            groupControl1.Controls.Add(gridSiparisKalemleri);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.Location = new System.Drawing.Point(21, 190);
            groupControl1.Name = "groupControl1";
            tablePanel1.SetRow(groupControl1, 4);
            groupControl1.Size = new System.Drawing.Size(598, 280);
            groupControl1.TabIndex = 6;
            groupControl1.Text = "Sipariş Kalemleri";
            // 
            // gridSiparisKalemleri
            // 
            gridSiparisKalemleri.Dock = System.Windows.Forms.DockStyle.Fill;
            gridSiparisKalemleri.Location = new System.Drawing.Point(2, 36);
            gridSiparisKalemleri.MainView = gridView1;
            gridSiparisKalemleri.Name = "gridSiparisKalemleri";
            gridSiparisKalemleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoProductType, repoFabric });
            gridSiparisKalemleri.Size = new System.Drawing.Size(594, 242);
            gridSiparisKalemleri.TabIndex = 0;
            gridSiparisKalemleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridTypeIdColumn, gridFabricIdColumn, gridQuantityColumn });
            gridView1.GridControl = gridSiparisKalemleri;
            gridView1.Name = "gridView1";
            gridView1.NewItemRowText = "Yeni ürün eklemek için tıklayın";
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            // 
            // gridTypeIdColumn
            // 
            gridTypeIdColumn.Caption = "Ürün Tipi";
            gridTypeIdColumn.ColumnEdit = repoProductType;
            gridTypeIdColumn.FieldName = "TypeId";
            gridTypeIdColumn.MinWidth = 25;
            gridTypeIdColumn.Name = "gridTypeIdColumn";
            gridTypeIdColumn.Visible = true;
            gridTypeIdColumn.VisibleIndex = 0;
            gridTypeIdColumn.Width = 94;
            // 
            // repoProductType
            // 
            repoProductType.AutoHeight = false;
            repoProductType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoProductType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName", "Ürün Tipi") });
            repoProductType.DisplayMember = "TypeName";
            repoProductType.Name = "repoProductType";
            repoProductType.NullText = "Bir ürün seçin...";
            repoProductType.ValueMember = "TypeId";
            // 
            // gridFabricIdColumn
            // 
            gridFabricIdColumn.Caption = "Kumaş";
            gridFabricIdColumn.ColumnEdit = repoFabric;
            gridFabricIdColumn.FieldName = "FabricId";
            gridFabricIdColumn.MinWidth = 25;
            gridFabricIdColumn.Name = "gridFabricIdColumn";
            gridFabricIdColumn.Visible = true;
            gridFabricIdColumn.VisibleIndex = 1;
            gridFabricIdColumn.Width = 94;
            // 
            // repoFabric
            // 
            repoFabric.AutoHeight = false;
            repoFabric.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoFabric.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FabricName", "Kumaş Adı") });
            repoFabric.DisplayMember = "FabricName";
            repoFabric.Name = "repoFabric";
            repoFabric.NullText = "Bir kumaş seçin...";
            repoFabric.ValueMember = "FabricId";
            // 
            // gridQuantityColumn
            // 
            gridQuantityColumn.Caption = "Adet";
            gridQuantityColumn.FieldName = "Quantity";
            gridQuantityColumn.MinWidth = 25;
            gridQuantityColumn.Name = "gridQuantityColumn";
            gridQuantityColumn.Visible = true;
            gridQuantityColumn.VisibleIndex = 2;
            gridQuantityColumn.Width = 94;
            // 
            // dateTarih
            // 
            tablePanel1.SetColumn(dateTarih, 1);
            dateTarih.EditValue = null;
            dateTarih.Location = new System.Drawing.Point(141, 150);
            dateTarih.Name = "dateTarih";
            dateTarih.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateTarih.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            tablePanel1.SetRow(dateTarih, 3);
            dateTarih.Size = new System.Drawing.Size(478, 34);
            dateTarih.TabIndex = 5;
            // 
            // txtSiparisNo
            // 
            tablePanel1.SetColumn(txtSiparisNo, 1);
            txtSiparisNo.Dock = System.Windows.Forms.DockStyle.Fill;
            txtSiparisNo.Location = new System.Drawing.Point(141, 70);
            txtSiparisNo.Name = "txtSiparisNo";
            txtSiparisNo.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            txtSiparisNo.Properties.Appearance.Options.UseFont = true;
            tablePanel1.SetRow(txtSiparisNo, 1);
            txtSiparisNo.Size = new System.Drawing.Size(478, 36);
            txtSiparisNo.TabIndex = 4;
            // 
            // labelControl4
            // 
            labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Appearance.Options.UseForeColor = true;
            tablePanel1.SetColumn(labelControl4, 0);
            labelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl4.Location = new System.Drawing.Point(21, 150);
            labelControl4.Name = "labelControl4";
            tablePanel1.SetRow(labelControl4, 3);
            labelControl4.Size = new System.Drawing.Size(112, 32);
            labelControl4.TabIndex = 3;
            labelControl4.Text = "Tarih:";
            // 
            // labelControl3
            // 
            labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Appearance.Options.UseForeColor = true;
            tablePanel1.SetColumn(labelControl3, 0);
            labelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl3.Location = new System.Drawing.Point(21, 110);
            labelControl3.Name = "labelControl3";
            tablePanel1.SetRow(labelControl3, 2);
            labelControl3.Size = new System.Drawing.Size(112, 32);
            labelControl3.TabIndex = 2;
            labelControl3.Text = "Müşteri:";
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Appearance.Options.UseForeColor = true;
            labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl2.Location = new System.Drawing.Point(21, 70);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(112, 32);
            labelControl2.TabIndex = 1;
            labelControl2.Text = "Sipariş No:";
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseForeColor = true;
            labelControl1.Appearance.Options.UseTextOptions = true;
            labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tablePanel1.SetColumn(labelControl1, 0);
            tablePanel1.SetColumnSpan(labelControl1, 2);
            labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl1.Location = new System.Drawing.Point(21, 20);
            labelControl1.Name = "labelControl1";
            tablePanel1.SetRow(labelControl1, 0);
            labelControl1.Size = new System.Drawing.Size(598, 42);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Sipariş Girişi";
            // 
            // FrmAddOrder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(640, 551);
            Controls.Add(tablePanel1);
            Name = "FrmAddOrder";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Sipariş Ekle";
            Load += FrmAddOrder_Load;
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lkpMusteri.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridSiparisKalemleri).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoProductType).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoFabric).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateTarih.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateTarih.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSiparisNo.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateTarih;
        private DevExpress.XtraEditors.TextEdit txtSiparisNo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridSiparisKalemleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LookUpEdit lkpMusteri;
        private DevExpress.XtraGrid.Columns.GridColumn gridTypeIdColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoProductType;
        private DevExpress.XtraGrid.Columns.GridColumn gridFabricIdColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoFabric;
        private DevExpress.XtraGrid.Columns.GridColumn gridQuantityColumn;
    }
}