namespace Ototeks.UI
{
    partial class FrmAddProductType
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
            tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            lblBaslik = new DevExpress.XtraEditors.LabelControl();
            lblUrunTipiAdi = new DevExpress.XtraEditors.LabelControl();
            txtUrunTipiAdi = new DevExpress.XtraEditors.TextEdit();
            lblGerekliKumasMiktari = new DevExpress.XtraEditors.LabelControl();
            txtGerekliKumasMiktari = new DevExpress.XtraEditors.TextEdit();
            btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtUrunTipiAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGerekliKumasMiktari.Properties).BeginInit();
            SuspendLayout();
            // 
            // tablePanel1
            // 
            tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 48.2F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 51.8F) });
            tablePanel1.Controls.Add(stackPanel1);
            tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel1.Location = new System.Drawing.Point(0, 0);
            tablePanel1.Name = "tablePanel1";
            tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 500F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F) });
            tablePanel1.Size = new System.Drawing.Size(500, 400);
            tablePanel1.TabIndex = 0;
            tablePanel1.UseSkinIndents = true;
            // 
            // stackPanel1
            // 
            stackPanel1.AutoSize = true;
            tablePanel1.SetColumn(stackPanel1, 1);
            stackPanel1.Controls.Add(lblBaslik);
            stackPanel1.Controls.Add(lblUrunTipiAdi);
            stackPanel1.Controls.Add(txtUrunTipiAdi);
            stackPanel1.Controls.Add(lblGerekliKumasMiktari);
            stackPanel1.Controls.Add(txtGerekliKumasMiktari);
            stackPanel1.Controls.Add(btnKaydet);
            stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            stackPanel1.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;
            stackPanel1.Location = new System.Drawing.Point(72, 50);
            stackPanel1.Name = "stackPanel1";
            stackPanel1.Padding = new System.Windows.Forms.Padding(16);
            tablePanel1.SetRow(stackPanel1, 1);
            stackPanel1.Size = new System.Drawing.Size(340, 300);
            stackPanel1.TabIndex = 1;
            stackPanel1.UseSkinIndents = true;
            // 
            // lblBaslik
            // 
            lblBaslik.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            lblBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblBaslik.Appearance.Options.UseFont = true;
            lblBaslik.Appearance.Options.UseForeColor = true;
            lblBaslik.Location = new System.Drawing.Point(28, 19);
            lblBaslik.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new System.Drawing.Size(284, 37);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Yeni Ürün Tipi Ekleme";
            // 
            // lblUrunTipiAdi
            // 
            lblUrunTipiAdi.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblUrunTipiAdi.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblUrunTipiAdi.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblUrunTipiAdi.Appearance.Options.UseFont = true;
            lblUrunTipiAdi.Appearance.Options.UseForeColor = true;
            lblUrunTipiAdi.Appearance.Options.UseTextOptions = true;
            lblUrunTipiAdi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblUrunTipiAdi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblUrunTipiAdi.Location = new System.Drawing.Point(20, 84);
            lblUrunTipiAdi.Name = "lblUrunTipiAdi";
            lblUrunTipiAdi.Padding = new System.Windows.Forms.Padding(2);
            lblUrunTipiAdi.Size = new System.Drawing.Size(300, 29);
            lblUrunTipiAdi.TabIndex = 1;
            lblUrunTipiAdi.Text = "Ürün Tipi Adý:";
            // 
            // txtUrunTipiAdi
            // 
            txtUrunTipiAdi.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtUrunTipiAdi.Location = new System.Drawing.Point(20, 120);
            txtUrunTipiAdi.Margin = new System.Windows.Forms.Padding(3, 3, 3, 16);
            txtUrunTipiAdi.Name = "txtUrunTipiAdi";
            txtUrunTipiAdi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtUrunTipiAdi.Properties.Appearance.Options.UseFont = true;
            txtUrunTipiAdi.Size = new System.Drawing.Size(300, 44);
            txtUrunTipiAdi.TabIndex = 2;
            // 
            // lblGerekliKumasMiktari
            // 
            lblGerekliKumasMiktari.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblGerekliKumasMiktari.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblGerekliKumasMiktari.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblGerekliKumasMiktari.Appearance.Options.UseFont = true;
            lblGerekliKumasMiktari.Appearance.Options.UseForeColor = true;
            lblGerekliKumasMiktari.Appearance.Options.UseTextOptions = true;
            lblGerekliKumasMiktari.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblGerekliKumasMiktari.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblGerekliKumasMiktari.Location = new System.Drawing.Point(20, 184);
            lblGerekliKumasMiktari.Name = "lblGerekliKumasMiktari";
            lblGerekliKumasMiktari.Padding = new System.Windows.Forms.Padding(2);
            lblGerekliKumasMiktari.Size = new System.Drawing.Size(300, 29);
            lblGerekliKumasMiktari.TabIndex = 3;
            lblGerekliKumasMiktari.Text = "Gerekli Kumaþ Miktarý (metre):";
            // 
            // txtGerekliKumasMiktari
            // 
            txtGerekliKumasMiktari.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtGerekliKumasMiktari.Location = new System.Drawing.Point(20, 220);
            txtGerekliKumasMiktari.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            txtGerekliKumasMiktari.Name = "txtGerekliKumasMiktari";
            txtGerekliKumasMiktari.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtGerekliKumasMiktari.Properties.Appearance.Options.UseFont = true;
            txtGerekliKumasMiktari.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            txtGerekliKumasMiktari.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            txtGerekliKumasMiktari.Properties.MaskSettings.Set("mask", "f2");
            txtGerekliKumasMiktari.Size = new System.Drawing.Size(300, 44);
            txtGerekliKumasMiktari.TabIndex = 4;
            // 
            // btnKaydet
            // 
            btnKaydet.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            btnKaydet.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnKaydet.Appearance.Options.UseFont = true;
            btnKaydet.Appearance.Options.UseForeColor = true;
            btnKaydet.Location = new System.Drawing.Point(111, 292);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new System.Drawing.Size(118, 42);
            btnKaydet.TabIndex = 5;
            btnKaydet.Text = "Kaydet";
            btnKaydet.Click += btnKaydet_Click;
            // 
            // FrmAddProductType
            // 
            AcceptButton = btnKaydet;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(500, 400);
            Controls.Add(tablePanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAddProductType";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Yeni Ürün Tipi";
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            stackPanel1.ResumeLayout(false);
            stackPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtUrunTipiAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGerekliKumasMiktari.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblUrunTipiAdi;
        private DevExpress.XtraEditors.TextEdit txtUrunTipiAdi;
        private DevExpress.XtraEditors.LabelControl lblGerekliKumasMiktari;
        private DevExpress.XtraEditors.TextEdit txtGerekliKumasMiktari;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
    }
}
