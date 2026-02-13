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
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            lblColorName = new DevExpress.XtraEditors.LabelControl();
            txtColorName = new DevExpress.XtraEditors.TextEdit();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtColorName.Properties).BeginInit();
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
            stackPanel1.Controls.Add(lblTitle);
            stackPanel1.Controls.Add(lblColorName);
            stackPanel1.Controls.Add(txtColorName);
            stackPanel1.Controls.Add(btnSave);
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
            // lblTitle
            //
            lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.Location = new System.Drawing.Point(65, 19);
            lblTitle.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(210, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Color";
            //
            // lblColorName
            //
            lblColorName.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblColorName.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblColorName.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblColorName.Appearance.Options.UseFont = true;
            lblColorName.Appearance.Options.UseForeColor = true;
            lblColorName.Appearance.Options.UseTextOptions = true;
            lblColorName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblColorName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblColorName.Location = new System.Drawing.Point(20, 84);
            lblColorName.Name = "lblColorName";
            lblColorName.Padding = new System.Windows.Forms.Padding(2);
            lblColorName.Size = new System.Drawing.Size(300, 29);
            lblColorName.TabIndex = 1;
            lblColorName.Text = "Color Name:";
            //
            // txtColorName
            //
            txtColorName.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtColorName.Location = new System.Drawing.Point(20, 120);
            txtColorName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            txtColorName.Name = "txtColorName";
            txtColorName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtColorName.Properties.Appearance.Options.UseFont = true;
            txtColorName.Size = new System.Drawing.Size(300, 44);
            txtColorName.TabIndex = 2;
            //
            // btnSave
            //
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Appearance.Options.UseForeColor = true;
            btnSave.Location = new System.Drawing.Point(111, 192);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(118, 42);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            //
            // FrmAddColor
            //
            AcceptButton = btnSave;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(450, 300);
            Controls.Add(tablePanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAddColor";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "New Color";
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            stackPanel1.ResumeLayout(false);
            stackPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtColorName.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblColorName;
        private DevExpress.XtraEditors.TextEdit txtColorName;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}
