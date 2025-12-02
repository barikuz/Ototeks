namespace Ototeks.UI
{
	partial class FrmAddFabric
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
            lblKumasKodu = new DevExpress.XtraEditors.LabelControl();
            txtKumasKodu = new DevExpress.XtraEditors.TextEdit();
            lblKumasAdi = new DevExpress.XtraEditors.LabelControl();
            txtKumasAdi = new DevExpress.XtraEditors.TextEdit();
            btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKumasKodu.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKumasAdi.Properties).BeginInit();
            SuspendLayout();
            // 
            // tablePanel1
            // 
            tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 48.2F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 51.8F) });
            tablePanel1.Controls.Add(stackPanel1);
            tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tablePanel1.Location = new System.Drawing.Point(0, 0);
            tablePanel1.Name = "tablePanel1";
            tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 500F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F) });
            tablePanel1.Size = new System.Drawing.Size(599, 420);
            tablePanel1.TabIndex = 0;
            tablePanel1.UseSkinIndents = true;
            // 
            // stackPanel1
            // 
            stackPanel1.AutoSize = true;
            tablePanel1.SetColumn(stackPanel1, 1);
            stackPanel1.Controls.Add(lblBaslik);
            stackPanel1.Controls.Add(lblKumasKodu);
            stackPanel1.Controls.Add(txtKumasKodu);
            stackPanel1.Controls.Add(lblKumasAdi);
            stackPanel1.Controls.Add(txtKumasAdi);
            stackPanel1.Controls.Add(btnKaydet);
            stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            stackPanel1.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;
            stackPanel1.Location = new System.Drawing.Point(126, 21);
            stackPanel1.Name = "stackPanel1";
            stackPanel1.Padding = new System.Windows.Forms.Padding(16);
            tablePanel1.SetRow(stackPanel1, 1);
            stackPanel1.Size = new System.Drawing.Size(340, 378);
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
            lblBaslik.Location = new System.Drawing.Point(21, 19);
            lblBaslik.Margin = new System.Windows.Forms.Padding(3, 3, 3, 32);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new System.Drawing.Size(298, 37);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Yeni Kumaş Tanımlama";
            // 
            // lblKumasKodu
            // 
            lblKumasKodu.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblKumasKodu.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblKumasKodu.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblKumasKodu.Appearance.Options.UseFont = true;
            lblKumasKodu.Appearance.Options.UseForeColor = true;
            lblKumasKodu.Appearance.Options.UseTextOptions = true;
            lblKumasKodu.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblKumasKodu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblKumasKodu.Location = new System.Drawing.Point(20, 92);
            lblKumasKodu.Name = "lblKumasKodu";
            lblKumasKodu.Padding = new System.Windows.Forms.Padding(2);
            lblKumasKodu.Size = new System.Drawing.Size(300, 29);
            lblKumasKodu.TabIndex = 1;
            lblKumasKodu.Text = "Kumaş Kodu:";
            // 
            // txtKumasKodu
            // 
            txtKumasKodu.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtKumasKodu.Location = new System.Drawing.Point(20, 128);
            txtKumasKodu.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            txtKumasKodu.Name = "txtKumasKodu";
            txtKumasKodu.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtKumasKodu.Properties.Appearance.Options.UseFont = true;
            txtKumasKodu.Size = new System.Drawing.Size(300, 44);
            txtKumasKodu.TabIndex = 2;
            // 
            // lblKumasAdi
            // 
            lblKumasAdi.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblKumasAdi.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblKumasAdi.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblKumasAdi.Appearance.Options.UseFont = true;
            lblKumasAdi.Appearance.Options.UseForeColor = true;
            lblKumasAdi.Appearance.Options.UseTextOptions = true;
            lblKumasAdi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblKumasAdi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblKumasAdi.Location = new System.Drawing.Point(20, 200);
            lblKumasAdi.Name = "lblKumasAdi";
            lblKumasAdi.Padding = new System.Windows.Forms.Padding(2);
            lblKumasAdi.Size = new System.Drawing.Size(300, 29);
            lblKumasAdi.TabIndex = 3;
            lblKumasAdi.Text = "Kumaş Adı:";
            // 
            // txtKumasAdi
            // 
            txtKumasAdi.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtKumasAdi.Location = new System.Drawing.Point(20, 236);
            txtKumasAdi.Margin = new System.Windows.Forms.Padding(3, 3, 3, 32);
            txtKumasAdi.Name = "txtKumasAdi";
            txtKumasAdi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtKumasAdi.Properties.Appearance.Options.UseFont = true;
            txtKumasAdi.Size = new System.Drawing.Size(300, 44);
            txtKumasAdi.TabIndex = 4;
            // 
            // btnKaydet
            // 
            btnKaydet.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            btnKaydet.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnKaydet.Appearance.Options.UseFont = true;
            btnKaydet.Appearance.Options.UseForeColor = true;
            btnKaydet.Location = new System.Drawing.Point(111, 316);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new System.Drawing.Size(118, 42);
            btnKaydet.TabIndex = 5;
            btnKaydet.Text = "Kaydet";
            btnKaydet.Click += btnKaydet_Click;
            // 
            // FrmAddFabric
            // 
            AcceptButton = btnKaydet;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(599, 420);
            Controls.Add(tablePanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAddFabric";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Yeni Kumaş";
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            stackPanel1.ResumeLayout(false);
            stackPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtKumasKodu.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKumasAdi.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblKumasKodu;
        private DevExpress.XtraEditors.TextEdit txtKumasKodu;
        private DevExpress.XtraEditors.LabelControl lblKumasAdi;
        private DevExpress.XtraEditors.TextEdit txtKumasAdi;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
    }
}