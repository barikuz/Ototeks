namespace Ototeks.UI
{
    partial class FrmAddCustomer
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
            lblMusteriAdi = new DevExpress.XtraEditors.LabelControl();
            txtMusteriAdi = new DevExpress.XtraEditors.TextEdit();
            lblTelefon = new DevExpress.XtraEditors.LabelControl();
            txtTelefon = new DevExpress.XtraEditors.TextEdit();
            lblEposta = new DevExpress.XtraEditors.LabelControl();
            txtEposta = new DevExpress.XtraEditors.TextEdit();
            lblAdres = new DevExpress.XtraEditors.LabelControl();
            txtAdres = new DevExpress.XtraEditors.MemoEdit();
            btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtMusteriAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTelefon.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEposta.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAdres.Properties).BeginInit();
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
            tablePanel1.Size = new System.Drawing.Size(617, 699);
            tablePanel1.TabIndex = 0;
            tablePanel1.UseSkinIndents = true;
            // 
            // stackPanel1
            // 
            stackPanel1.AutoSize = true;
            tablePanel1.SetColumn(stackPanel1, 1);
            stackPanel1.Controls.Add(lblBaslik);
            stackPanel1.Controls.Add(lblMusteriAdi);
            stackPanel1.Controls.Add(txtMusteriAdi);
            stackPanel1.Controls.Add(lblTelefon);
            stackPanel1.Controls.Add(txtTelefon);
            stackPanel1.Controls.Add(lblEposta);
            stackPanel1.Controls.Add(txtEposta);
            stackPanel1.Controls.Add(lblAdres);
            stackPanel1.Controls.Add(txtAdres);
            stackPanel1.Controls.Add(btnKaydet);
            stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            stackPanel1.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;
            stackPanel1.Location = new System.Drawing.Point(134, 50);
            stackPanel1.Name = "stackPanel1";
            stackPanel1.Padding = new System.Windows.Forms.Padding(16);
            tablePanel1.SetRow(stackPanel1, 1);
            stackPanel1.Size = new System.Drawing.Size(340, 599);
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
            lblBaslik.Location = new System.Drawing.Point(40, 19);
            lblBaslik.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new System.Drawing.Size(260, 37);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Yeni Müþteri Ekleme";
            // 
            // lblMusteriAdi
            // 
            lblMusteriAdi.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblMusteriAdi.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblMusteriAdi.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblMusteriAdi.Appearance.Options.UseFont = true;
            lblMusteriAdi.Appearance.Options.UseForeColor = true;
            lblMusteriAdi.Appearance.Options.UseTextOptions = true;
            lblMusteriAdi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblMusteriAdi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblMusteriAdi.Location = new System.Drawing.Point(20, 84);
            lblMusteriAdi.Name = "lblMusteriAdi";
            lblMusteriAdi.Padding = new System.Windows.Forms.Padding(2);
            lblMusteriAdi.Size = new System.Drawing.Size(300, 29);
            lblMusteriAdi.TabIndex = 1;
            lblMusteriAdi.Text = "Müþteri Adý:";
            // 
            // txtMusteriAdi
            // 
            txtMusteriAdi.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtMusteriAdi.Location = new System.Drawing.Point(20, 120);
            txtMusteriAdi.Margin = new System.Windows.Forms.Padding(3, 3, 3, 16);
            txtMusteriAdi.Name = "txtMusteriAdi";
            txtMusteriAdi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtMusteriAdi.Properties.Appearance.Options.UseFont = true;
            txtMusteriAdi.Size = new System.Drawing.Size(300, 44);
            txtMusteriAdi.TabIndex = 2;
            // 
            // lblTelefon
            // 
            lblTelefon.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblTelefon.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblTelefon.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblTelefon.Appearance.Options.UseFont = true;
            lblTelefon.Appearance.Options.UseForeColor = true;
            lblTelefon.Appearance.Options.UseTextOptions = true;
            lblTelefon.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblTelefon.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblTelefon.Location = new System.Drawing.Point(20, 184);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Padding = new System.Windows.Forms.Padding(2);
            lblTelefon.Size = new System.Drawing.Size(300, 29);
            lblTelefon.TabIndex = 3;
            lblTelefon.Text = "Telefon:";
            // 
            // txtTelefon
            // 
            txtTelefon.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtTelefon.Location = new System.Drawing.Point(20, 220);
            txtTelefon.Margin = new System.Windows.Forms.Padding(3, 3, 3, 16);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtTelefon.Properties.Appearance.Options.UseFont = true;
            txtTelefon.Size = new System.Drawing.Size(300, 44);
            txtTelefon.TabIndex = 4;
            // 
            // lblEposta
            // 
            lblEposta.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblEposta.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblEposta.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblEposta.Appearance.Options.UseFont = true;
            lblEposta.Appearance.Options.UseForeColor = true;
            lblEposta.Appearance.Options.UseTextOptions = true;
            lblEposta.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblEposta.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblEposta.Location = new System.Drawing.Point(20, 284);
            lblEposta.Name = "lblEposta";
            lblEposta.Padding = new System.Windows.Forms.Padding(2);
            lblEposta.Size = new System.Drawing.Size(300, 29);
            lblEposta.TabIndex = 5;
            lblEposta.Text = "E-posta:";
            // 
            // txtEposta
            // 
            txtEposta.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtEposta.Location = new System.Drawing.Point(20, 320);
            txtEposta.Margin = new System.Windows.Forms.Padding(3, 3, 3, 16);
            txtEposta.Name = "txtEposta";
            txtEposta.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtEposta.Properties.Appearance.Options.UseFont = true;
            txtEposta.Size = new System.Drawing.Size(300, 44);
            txtEposta.TabIndex = 6;
            // 
            // lblAdres
            // 
            lblAdres.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblAdres.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblAdres.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblAdres.Appearance.Options.UseFont = true;
            lblAdres.Appearance.Options.UseForeColor = true;
            lblAdres.Appearance.Options.UseTextOptions = true;
            lblAdres.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblAdres.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblAdres.Location = new System.Drawing.Point(20, 384);
            lblAdres.Name = "lblAdres";
            lblAdres.Padding = new System.Windows.Forms.Padding(2);
            lblAdres.Size = new System.Drawing.Size(300, 29);
            lblAdres.TabIndex = 7;
            lblAdres.Text = "Adres:";
            // 
            // txtAdres
            // 
            txtAdres.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtAdres.Location = new System.Drawing.Point(20, 420);
            txtAdres.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            txtAdres.Name = "txtAdres";
            txtAdres.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtAdres.Properties.Appearance.Options.UseFont = true;
            txtAdres.Size = new System.Drawing.Size(300, 89);
            txtAdres.TabIndex = 8;
            // 
            // btnKaydet
            // 
            btnKaydet.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            btnKaydet.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnKaydet.Appearance.Options.UseFont = true;
            btnKaydet.Appearance.Options.UseForeColor = true;
            btnKaydet.Location = new System.Drawing.Point(111, 537);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new System.Drawing.Size(118, 42);
            btnKaydet.TabIndex = 9;
            btnKaydet.Text = "Kaydet";
            btnKaydet.Click += btnKaydet_Click;
            // 
            // FrmAddCustomer
            // 
            AcceptButton = btnKaydet;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(617, 699);
            Controls.Add(tablePanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAddCustomer";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Yeni Müþteri";
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            stackPanel1.ResumeLayout(false);
            stackPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtMusteriAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTelefon.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEposta.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAdres.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblMusteriAdi;
        private DevExpress.XtraEditors.TextEdit txtMusteriAdi;
        private DevExpress.XtraEditors.LabelControl lblTelefon;
        private DevExpress.XtraEditors.TextEdit txtTelefon;
        private DevExpress.XtraEditors.LabelControl lblEposta;
        private DevExpress.XtraEditors.TextEdit txtEposta;
        private DevExpress.XtraEditors.LabelControl lblAdres;
        private DevExpress.XtraEditors.MemoEdit txtAdres;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
    }
}