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
            lkpCustomer = new DevExpress.XtraEditors.LookUpEdit();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            gridOrderItems = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridTypeIdColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            repoProductType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridFabricIdColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            repoFabric = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridQuantityColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            dateOrderDate = new DevExpress.XtraEditors.DateEdit();
            txtOrderNo = new DevExpress.XtraEditors.TextEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lkpCustomer.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridOrderItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoProductType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoFabric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateOrderDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateOrderDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtOrderNo.Properties).BeginInit();
            SuspendLayout();
            //
            // tablePanel1
            //
            tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F) });
            tablePanel1.Controls.Add(lkpCustomer);
            tablePanel1.Controls.Add(btnSave);
            tablePanel1.Controls.Add(groupControl1);
            tablePanel1.Controls.Add(dateOrderDate);
            tablePanel1.Controls.Add(txtOrderNo);
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
            // lkpCustomer
            //
            tablePanel1.SetColumn(lkpCustomer, 1);
            lkpCustomer.Location = new System.Drawing.Point(141, 110);
            lkpCustomer.Name = "lkpCustomer";
            lkpCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lkpCustomer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Customer Name") });
            lkpCustomer.Properties.DisplayMember = "CustomerName";
            lkpCustomer.Properties.NullText = "Select a customer...";
            lkpCustomer.Properties.ValueMember = "CustomerId";
            tablePanel1.SetRow(lkpCustomer, 2);
            lkpCustomer.Size = new System.Drawing.Size(478, 34);
            lkpCustomer.TabIndex = 8;
            //
            // btnSave
            //
            btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            btnSave.Appearance.Options.UseFont = true;
            tablePanel1.SetColumn(btnSave, 0);
            tablePanel1.SetColumnSpan(btnSave, 2);
            btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            btnSave.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnSave.ImageOptions.Image");
            btnSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            btnSave.Location = new System.Drawing.Point(21, 478);
            btnSave.Name = "btnSave";
            tablePanel1.SetRow(btnSave, 5);
            btnSave.Size = new System.Drawing.Size(598, 52);
            btnSave.TabIndex = 7;
            btnSave.Text = "Complete Order";
            btnSave.Click += btnSave_Click;
            //
            // groupControl1
            //
            tablePanel1.SetColumn(groupControl1, 0);
            tablePanel1.SetColumnSpan(groupControl1, 2);
            groupControl1.Controls.Add(gridOrderItems);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.Location = new System.Drawing.Point(21, 190);
            groupControl1.Name = "groupControl1";
            tablePanel1.SetRow(groupControl1, 4);
            groupControl1.Size = new System.Drawing.Size(598, 280);
            groupControl1.TabIndex = 6;
            groupControl1.Text = "Order Items";
            //
            // gridOrderItems
            //
            gridOrderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            gridOrderItems.Location = new System.Drawing.Point(2, 36);
            gridOrderItems.MainView = gridView1;
            gridOrderItems.Name = "gridOrderItems";
            gridOrderItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoProductType, repoFabric });
            gridOrderItems.Size = new System.Drawing.Size(594, 242);
            gridOrderItems.TabIndex = 0;
            gridOrderItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            //
            // gridView1
            //
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridTypeIdColumn, gridFabricIdColumn, gridQuantityColumn });
            gridView1.GridControl = gridOrderItems;
            gridView1.Name = "gridView1";
            gridView1.NewItemRowText = "Click here to add a new product";
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            //
            // gridTypeIdColumn
            //
            gridTypeIdColumn.Caption = "Product Type";
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
            repoProductType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName", "Product Type") });
            repoProductType.DisplayMember = "TypeName";
            repoProductType.Name = "repoProductType";
            repoProductType.NullText = "Select a product...";
            repoProductType.ValueMember = "TypeId";
            //
            // gridFabricIdColumn
            //
            gridFabricIdColumn.Caption = "Fabric";
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
            repoFabric.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FabricCode", "Code"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FabricName", "Fabric Name") });
            repoFabric.DisplayMember = "DisplayName";
            repoFabric.Name = "repoFabric";
            repoFabric.NullText = "Select a fabric...";
            repoFabric.ValueMember = "FabricId";
            //
            // gridQuantityColumn
            //
            gridQuantityColumn.Caption = "Quantity";
            gridQuantityColumn.FieldName = "Quantity";
            gridQuantityColumn.MinWidth = 25;
            gridQuantityColumn.Name = "gridQuantityColumn";
            gridQuantityColumn.Visible = true;
            gridQuantityColumn.VisibleIndex = 2;
            gridQuantityColumn.Width = 94;
            //
            // dateOrderDate
            //
            tablePanel1.SetColumn(dateOrderDate, 1);
            dateOrderDate.EditValue = null;
            dateOrderDate.Location = new System.Drawing.Point(141, 150);
            dateOrderDate.Name = "dateOrderDate";
            dateOrderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateOrderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            tablePanel1.SetRow(dateOrderDate, 3);
            dateOrderDate.Size = new System.Drawing.Size(478, 34);
            dateOrderDate.TabIndex = 5;
            //
            // txtOrderNo
            //
            tablePanel1.SetColumn(txtOrderNo, 1);
            txtOrderNo.Dock = System.Windows.Forms.DockStyle.Fill;
            txtOrderNo.Location = new System.Drawing.Point(141, 70);
            txtOrderNo.Name = "txtOrderNo";
            txtOrderNo.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            txtOrderNo.Properties.Appearance.Options.UseFont = true;
            tablePanel1.SetRow(txtOrderNo, 1);
            txtOrderNo.Size = new System.Drawing.Size(478, 36);
            txtOrderNo.TabIndex = 4;
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
            labelControl4.Text = "Date:";
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
            labelControl3.Text = "Customer:";
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
            labelControl2.Text = "Order No:";
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
            labelControl1.Text = "Order Entry";
            //
            // FrmAddOrder
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(640, 551);
            Controls.Add(tablePanel1);
            Name = "FrmAddOrder";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Add Order";
            Load += FrmAddOrder_Load;
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lkpCustomer.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridOrderItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoProductType).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoFabric).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateOrderDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateOrderDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtOrderNo.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateOrderDate;
        private DevExpress.XtraEditors.TextEdit txtOrderNo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridOrderItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LookUpEdit lkpCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn gridTypeIdColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoProductType;
        private DevExpress.XtraGrid.Columns.GridColumn gridFabricIdColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoFabric;
        private DevExpress.XtraGrid.Columns.GridColumn gridQuantityColumn;
    }
}
