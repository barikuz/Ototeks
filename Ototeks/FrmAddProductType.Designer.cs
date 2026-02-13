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
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            lblProductTypeName = new DevExpress.XtraEditors.LabelControl();
            txtProductTypeName = new DevExpress.XtraEditors.TextEdit();
            lblRequiredFabricAmount = new DevExpress.XtraEditors.LabelControl();
            txtRequiredFabricAmount = new DevExpress.XtraEditors.TextEdit();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtProductTypeName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRequiredFabricAmount.Properties).BeginInit();
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
            stackPanel1.Controls.Add(lblTitle);
            stackPanel1.Controls.Add(lblProductTypeName);
            stackPanel1.Controls.Add(txtProductTypeName);
            stackPanel1.Controls.Add(lblRequiredFabricAmount);
            stackPanel1.Controls.Add(txtRequiredFabricAmount);
            stackPanel1.Controls.Add(btnSave);
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
            // lblTitle
            //
            lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.Location = new System.Drawing.Point(28, 19);
            lblTitle.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(284, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Product Type";
            //
            // lblProductTypeName
            //
            lblProductTypeName.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblProductTypeName.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblProductTypeName.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblProductTypeName.Appearance.Options.UseFont = true;
            lblProductTypeName.Appearance.Options.UseForeColor = true;
            lblProductTypeName.Appearance.Options.UseTextOptions = true;
            lblProductTypeName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblProductTypeName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblProductTypeName.Location = new System.Drawing.Point(20, 84);
            lblProductTypeName.Name = "lblProductTypeName";
            lblProductTypeName.Padding = new System.Windows.Forms.Padding(2);
            lblProductTypeName.Size = new System.Drawing.Size(300, 29);
            lblProductTypeName.TabIndex = 1;
            lblProductTypeName.Text = "Product Type Name:";
            //
            // txtProductTypeName
            //
            txtProductTypeName.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtProductTypeName.Location = new System.Drawing.Point(20, 120);
            txtProductTypeName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 16);
            txtProductTypeName.Name = "txtProductTypeName";
            txtProductTypeName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtProductTypeName.Properties.Appearance.Options.UseFont = true;
            txtProductTypeName.Size = new System.Drawing.Size(300, 44);
            txtProductTypeName.TabIndex = 2;
            //
            // lblRequiredFabricAmount
            //
            lblRequiredFabricAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblRequiredFabricAmount.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblRequiredFabricAmount.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblRequiredFabricAmount.Appearance.Options.UseFont = true;
            lblRequiredFabricAmount.Appearance.Options.UseForeColor = true;
            lblRequiredFabricAmount.Appearance.Options.UseTextOptions = true;
            lblRequiredFabricAmount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblRequiredFabricAmount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblRequiredFabricAmount.Location = new System.Drawing.Point(20, 184);
            lblRequiredFabricAmount.Name = "lblRequiredFabricAmount";
            lblRequiredFabricAmount.Padding = new System.Windows.Forms.Padding(2);
            lblRequiredFabricAmount.Size = new System.Drawing.Size(300, 29);
            lblRequiredFabricAmount.TabIndex = 3;
            lblRequiredFabricAmount.Text = "Required Fabric Amount (meters):";
            //
            // txtRequiredFabricAmount
            //
            txtRequiredFabricAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtRequiredFabricAmount.Location = new System.Drawing.Point(20, 220);
            txtRequiredFabricAmount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            txtRequiredFabricAmount.Name = "txtRequiredFabricAmount";
            txtRequiredFabricAmount.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtRequiredFabricAmount.Properties.Appearance.Options.UseFont = true;
            txtRequiredFabricAmount.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            txtRequiredFabricAmount.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            txtRequiredFabricAmount.Properties.MaskSettings.Set("mask", "f2");
            txtRequiredFabricAmount.Size = new System.Drawing.Size(300, 44);
            txtRequiredFabricAmount.TabIndex = 4;
            //
            // btnSave
            //
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Appearance.Options.UseForeColor = true;
            btnSave.Location = new System.Drawing.Point(111, 292);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(118, 42);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            //
            // FrmAddProductType
            //
            AcceptButton = btnSave;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(500, 400);
            Controls.Add(tablePanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAddProductType";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "New Product Type";
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            stackPanel1.ResumeLayout(false);
            stackPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtProductTypeName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRequiredFabricAmount.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblProductTypeName;
        private DevExpress.XtraEditors.TextEdit txtProductTypeName;
        private DevExpress.XtraEditors.LabelControl lblRequiredFabricAmount;
        private DevExpress.XtraEditors.TextEdit txtRequiredFabricAmount;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}
