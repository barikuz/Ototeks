namespace Ototeks.UI
{
    partial class FrmAddColor
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
            lblRenkAdi = new DevExpress.XtraEditors.LabelControl();
            txtRenkAdi = new DevExpress.XtraEditors.TextEdit();
            btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtRenkAdi.Properties).BeginInit();
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
            tablePanel1.Size = new System.Drawing.Size(450, 300);
            tablePanel1.TabIndex = 0;
            tablePanel1.UseSkinIndents = true;
            // 
            // stackPanel1
            // 
            stackPanel1.AutoSize = true;
            tablePanel1.SetColumn(stackPanel1, 1);
            stackPanel1.Controls.Add(lblBaslik);
            stackPanel1.Controls.Add(lblRenkAdi);
            stackPanel1.Controls.Add(txtRenkAdi);
            stackPanel1.Controls.Add(btnKaydet);
            stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            stackPanel1.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;
            stackPanel1.Location = new System.Drawing.Point(67, 50);
            stackPanel1.Name = "stackPanel1";
            stackPanel1.Padding = new System.Windows.Forms.Padding(16);
            tablePanel1.SetRow(stackPanel1, 1);
            stackPanel1.Size = new System.Drawing.Size(340, 200);
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
            lblBaslik.Location = new System.Drawing.Point(65, 19);
            lblBaslik.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new System.Drawing.Size(210, 37);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Yeni Renk Ekleme";
            // 
            // lblRenkAdi
            // 
            lblRenkAdi.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblRenkAdi.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblRenkAdi.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblRenkAdi.Appearance.Options.UseFont = true;
            lblRenkAdi.Appearance.Options.UseForeColor = true;
            lblRenkAdi.Appearance.Options.UseTextOptions = true;
            lblRenkAdi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblRenkAdi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblRenkAdi.Location = new System.Drawing.Point(20, 84);
            lblRenkAdi.Name = "lblRenkAdi";
            lblRenkAdi.Padding = new System.Windows.Forms.Padding(2);
            lblRenkAdi.Size = new System.Drawing.Size(300, 29);
            lblRenkAdi.TabIndex = 1;
            lblRenkAdi.Text = "Renk Adý:";
            // 
            // txtRenkAdi
            // 
            txtRenkAdi.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtRenkAdi.Location = new System.Drawing.Point(20, 120);
            txtRenkAdi.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            txtRenkAdi.Name = "txtRenkAdi";
            txtRenkAdi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtRenkAdi.Properties.Appearance.Options.UseFont = true;
            txtRenkAdi.Size = new System.Drawing.Size(300, 44);
            txtRenkAdi.TabIndex = 2;
            // 
            // btnKaydet
            // 
            btnKaydet.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            btnKaydet.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnKaydet.Appearance.Options.UseFont = true;
            btnKaydet.Appearance.Options.UseForeColor = true;
            btnKaydet.Location = new System.Drawing.Point(111, 192);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new System.Drawing.Size(118, 42);
            btnKaydet.TabIndex = 3;
            btnKaydet.Text = "Kaydet";
            btnKaydet.Click += btnKaydet_Click;
            // 
            // FrmAddColor
            // 
            AcceptButton = btnKaydet;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(450, 300);
            Controls.Add(tablePanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAddColor";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Yeni Renk";
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            stackPanel1.ResumeLayout(false);
            stackPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtRenkAdi.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblRenkAdi;
        private DevExpress.XtraEditors.TextEdit txtRenkAdi;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
    }
}
