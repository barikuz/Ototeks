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
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            lblFabricCode = new DevExpress.XtraEditors.LabelControl();
            txtFabricCode = new DevExpress.XtraEditors.TextEdit();
            lblFabricName = new DevExpress.XtraEditors.LabelControl();
            txtFabricName = new DevExpress.XtraEditors.TextEdit();
            lblColor = new DevExpress.XtraEditors.LabelControl();
            cmbColor = new DevExpress.XtraEditors.ComboBoxEdit();
            lblStock = new DevExpress.XtraEditors.LabelControl();
            txtStock = new DevExpress.XtraEditors.TextEdit();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtFabricCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFabricName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbColor.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStock.Properties).BeginInit();
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
            tablePanel1.Size = new System.Drawing.Size(599, 702);
            tablePanel1.TabIndex = 0;
            tablePanel1.UseSkinIndents = true;
            //
            // stackPanel1
            //
            stackPanel1.AutoSize = true;
            tablePanel1.SetColumn(stackPanel1, 1);
            stackPanel1.Controls.Add(lblTitle);
            stackPanel1.Controls.Add(lblFabricCode);
            stackPanel1.Controls.Add(txtFabricCode);
            stackPanel1.Controls.Add(lblFabricName);
            stackPanel1.Controls.Add(txtFabricName);
            stackPanel1.Controls.Add(lblColor);
            stackPanel1.Controls.Add(cmbColor);
            stackPanel1.Controls.Add(lblStock);
            stackPanel1.Controls.Add(txtStock);
            stackPanel1.Controls.Add(btnSave);
            stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            stackPanel1.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;
            stackPanel1.Location = new System.Drawing.Point(126, 54);
            stackPanel1.Name = "stackPanel1";
            stackPanel1.Padding = new System.Windows.Forms.Padding(16);
            tablePanel1.SetRow(stackPanel1, 1);
            stackPanel1.Size = new System.Drawing.Size(340, 594);
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
            lblTitle.Location = new System.Drawing.Point(21, 19);
            lblTitle.Margin = new System.Windows.Forms.Padding(3, 3, 3, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(298, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Fabric";
            //
            // lblFabricCode
            //
            lblFabricCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblFabricCode.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblFabricCode.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblFabricCode.Appearance.Options.UseFont = true;
            lblFabricCode.Appearance.Options.UseForeColor = true;
            lblFabricCode.Appearance.Options.UseTextOptions = true;
            lblFabricCode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblFabricCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblFabricCode.Location = new System.Drawing.Point(20, 92);
            lblFabricCode.Name = "lblFabricCode";
            lblFabricCode.Padding = new System.Windows.Forms.Padding(2);
            lblFabricCode.Size = new System.Drawing.Size(300, 29);
            lblFabricCode.TabIndex = 1;
            lblFabricCode.Text = "Fabric Code:";
            //
            // txtFabricCode
            //
            txtFabricCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtFabricCode.Location = new System.Drawing.Point(20, 128);
            txtFabricCode.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            txtFabricCode.Name = "txtFabricCode";
            txtFabricCode.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtFabricCode.Properties.Appearance.Options.UseFont = true;
            txtFabricCode.Size = new System.Drawing.Size(300, 44);
            txtFabricCode.TabIndex = 2;
            //
            // lblFabricName
            //
            lblFabricName.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblFabricName.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblFabricName.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblFabricName.Appearance.Options.UseFont = true;
            lblFabricName.Appearance.Options.UseForeColor = true;
            lblFabricName.Appearance.Options.UseTextOptions = true;
            lblFabricName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblFabricName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblFabricName.Location = new System.Drawing.Point(20, 200);
            lblFabricName.Name = "lblFabricName";
            lblFabricName.Padding = new System.Windows.Forms.Padding(2);
            lblFabricName.Size = new System.Drawing.Size(300, 29);
            lblFabricName.TabIndex = 3;
            lblFabricName.Text = "Fabric Name:";
            //
            // txtFabricName
            //
            txtFabricName.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtFabricName.Location = new System.Drawing.Point(20, 236);
            txtFabricName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            txtFabricName.Name = "txtFabricName";
            txtFabricName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtFabricName.Properties.Appearance.Options.UseFont = true;
            txtFabricName.Size = new System.Drawing.Size(300, 44);
            txtFabricName.TabIndex = 4;
            //
            // lblColor
            //
            lblColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblColor.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblColor.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblColor.Appearance.Options.UseFont = true;
            lblColor.Appearance.Options.UseForeColor = true;
            lblColor.Appearance.Options.UseTextOptions = true;
            lblColor.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblColor.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblColor.Location = new System.Drawing.Point(20, 308);
            lblColor.Name = "lblColor";
            lblColor.Padding = new System.Windows.Forms.Padding(2);
            lblColor.Size = new System.Drawing.Size(300, 29);
            lblColor.TabIndex = 5;
            lblColor.Text = "Color:";
            //
            // cmbColor
            //
            cmbColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            cmbColor.Location = new System.Drawing.Point(20, 344);
            cmbColor.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            cmbColor.Name = "cmbColor";
            cmbColor.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            cmbColor.Properties.Appearance.Options.UseFont = true;
            cmbColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbColor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbColor.Size = new System.Drawing.Size(300, 44);
            cmbColor.TabIndex = 6;
            //
            // lblStock
            //
            lblStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblStock.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblStock.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblStock.Appearance.Options.UseFont = true;
            lblStock.Appearance.Options.UseForeColor = true;
            lblStock.Appearance.Options.UseTextOptions = true;
            lblStock.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblStock.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblStock.Location = new System.Drawing.Point(20, 416);
            lblStock.Name = "lblStock";
            lblStock.Padding = new System.Windows.Forms.Padding(2);
            lblStock.Size = new System.Drawing.Size(300, 29);
            lblStock.TabIndex = 7;
            lblStock.Text = "Stock Quantity:";
            //
            // txtStock
            //
            txtStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtStock.Location = new System.Drawing.Point(20, 452);
            txtStock.Margin = new System.Windows.Forms.Padding(3, 3, 3, 32);
            txtStock.Name = "txtStock";
            txtStock.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtStock.Properties.Appearance.Options.UseFont = true;
            txtStock.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            txtStock.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            txtStock.Properties.MaskSettings.Set("mask", "f2");
            txtStock.Size = new System.Drawing.Size(300, 44);
            txtStock.TabIndex = 8;
            //
            // btnSave
            //
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Appearance.Options.UseForeColor = true;
            btnSave.Location = new System.Drawing.Point(111, 532);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(118, 42);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            //
            // FrmAddFabric
            //
            AcceptButton = btnSave;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(599, 702);
            Controls.Add(tablePanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAddFabric";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "New Fabric";
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            stackPanel1.ResumeLayout(false);
            stackPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtFabricCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFabricName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbColor.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStock.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblFabricCode;
        private DevExpress.XtraEditors.TextEdit txtFabricCode;
        private DevExpress.XtraEditors.LabelControl lblFabricName;
        private DevExpress.XtraEditors.TextEdit txtFabricName;
        private DevExpress.XtraEditors.LabelControl lblColor;
        private DevExpress.XtraEditors.ComboBoxEdit cmbColor;
        private DevExpress.XtraEditors.LabelControl lblStock;
        private DevExpress.XtraEditors.TextEdit txtStock;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}
