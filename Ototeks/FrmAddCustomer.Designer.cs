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
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            lblCustomerName = new DevExpress.XtraEditors.LabelControl();
            txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            lblPhone = new DevExpress.XtraEditors.LabelControl();
            txtPhone = new DevExpress.XtraEditors.TextEdit();
            lblEmail = new DevExpress.XtraEditors.LabelControl();
            txtEmail = new DevExpress.XtraEditors.TextEdit();
            lblAddress = new DevExpress.XtraEditors.LabelControl();
            txtAddress = new DevExpress.XtraEditors.MemoEdit();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtCustomerName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPhone.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAddress.Properties).BeginInit();
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
            stackPanel1.Controls.Add(lblTitle);
            stackPanel1.Controls.Add(lblCustomerName);
            stackPanel1.Controls.Add(txtCustomerName);
            stackPanel1.Controls.Add(lblPhone);
            stackPanel1.Controls.Add(txtPhone);
            stackPanel1.Controls.Add(lblEmail);
            stackPanel1.Controls.Add(txtEmail);
            stackPanel1.Controls.Add(lblAddress);
            stackPanel1.Controls.Add(txtAddress);
            stackPanel1.Controls.Add(btnSave);
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
            // lblTitle
            //
            lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.Location = new System.Drawing.Point(40, 19);
            lblTitle.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(260, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Customer";
            //
            // lblCustomerName
            //
            lblCustomerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblCustomerName.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblCustomerName.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblCustomerName.Appearance.Options.UseFont = true;
            lblCustomerName.Appearance.Options.UseForeColor = true;
            lblCustomerName.Appearance.Options.UseTextOptions = true;
            lblCustomerName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblCustomerName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblCustomerName.Location = new System.Drawing.Point(20, 84);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Padding = new System.Windows.Forms.Padding(2);
            lblCustomerName.Size = new System.Drawing.Size(300, 29);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "Customer Name:";
            //
            // txtCustomerName
            //
            txtCustomerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtCustomerName.Location = new System.Drawing.Point(20, 120);
            txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 16);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtCustomerName.Properties.Appearance.Options.UseFont = true;
            txtCustomerName.Size = new System.Drawing.Size(300, 44);
            txtCustomerName.TabIndex = 2;
            //
            // lblPhone
            //
            lblPhone.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblPhone.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblPhone.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblPhone.Appearance.Options.UseFont = true;
            lblPhone.Appearance.Options.UseForeColor = true;
            lblPhone.Appearance.Options.UseTextOptions = true;
            lblPhone.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblPhone.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblPhone.Location = new System.Drawing.Point(20, 184);
            lblPhone.Name = "lblPhone";
            lblPhone.Padding = new System.Windows.Forms.Padding(2);
            lblPhone.Size = new System.Drawing.Size(300, 29);
            lblPhone.TabIndex = 3;
            lblPhone.Text = "Phone:";
            //
            // txtPhone
            //
            txtPhone.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtPhone.Location = new System.Drawing.Point(20, 220);
            txtPhone.Margin = new System.Windows.Forms.Padding(3, 3, 3, 16);
            txtPhone.Name = "txtPhone";
            txtPhone.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtPhone.Properties.Appearance.Options.UseFont = true;
            txtPhone.Size = new System.Drawing.Size(300, 44);
            txtPhone.TabIndex = 4;
            //
            // lblEmail
            //
            lblEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblEmail.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblEmail.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblEmail.Appearance.Options.UseFont = true;
            lblEmail.Appearance.Options.UseForeColor = true;
            lblEmail.Appearance.Options.UseTextOptions = true;
            lblEmail.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblEmail.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblEmail.Location = new System.Drawing.Point(20, 284);
            lblEmail.Name = "lblEmail";
            lblEmail.Padding = new System.Windows.Forms.Padding(2);
            lblEmail.Size = new System.Drawing.Size(300, 29);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtEmail.Location = new System.Drawing.Point(20, 320);
            txtEmail.Margin = new System.Windows.Forms.Padding(3, 3, 3, 16);
            txtEmail.Name = "txtEmail";
            txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtEmail.Properties.Appearance.Options.UseFont = true;
            txtEmail.Size = new System.Drawing.Size(300, 44);
            txtEmail.TabIndex = 6;
            //
            // lblAddress
            //
            lblAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblAddress.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            lblAddress.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblAddress.Appearance.Options.UseFont = true;
            lblAddress.Appearance.Options.UseForeColor = true;
            lblAddress.Appearance.Options.UseTextOptions = true;
            lblAddress.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblAddress.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblAddress.Location = new System.Drawing.Point(20, 384);
            lblAddress.Name = "lblAddress";
            lblAddress.Padding = new System.Windows.Forms.Padding(2);
            lblAddress.Size = new System.Drawing.Size(300, 29);
            lblAddress.TabIndex = 7;
            lblAddress.Text = "Address:";
            //
            // txtAddress
            //
            txtAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtAddress.Location = new System.Drawing.Point(20, 420);
            txtAddress.Margin = new System.Windows.Forms.Padding(3, 3, 3, 24);
            txtAddress.Name = "txtAddress";
            txtAddress.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            txtAddress.Properties.Appearance.Options.UseFont = true;
            txtAddress.Size = new System.Drawing.Size(300, 89);
            txtAddress.TabIndex = 8;
            //
            // btnSave
            //
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Appearance.Options.UseForeColor = true;
            btnSave.Location = new System.Drawing.Point(111, 537);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(118, 42);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            //
            // FrmAddCustomer
            //
            AcceptButton = btnSave;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(617, 699);
            Controls.Add(tablePanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAddCustomer";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "New Customer";
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            stackPanel1.ResumeLayout(false);
            stackPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtCustomerName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPhone.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAddress.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblCustomerName;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.LabelControl lblPhone;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl lblAddress;
        private DevExpress.XtraEditors.MemoEdit txtAddress;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}
