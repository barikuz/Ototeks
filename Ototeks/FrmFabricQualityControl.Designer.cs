namespace Ototeks.UI
{
    partial class FrmFabricQualityControl
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
            components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            lblTitleStatus = new DevExpress.XtraEditors.LabelControl();
            lblTitleConfidence = new DevExpress.XtraEditors.LabelControl();
            lblTitleDefectType = new DevExpress.XtraEditors.LabelControl();
            lblValueStatus = new DevExpress.XtraEditors.LabelControl();
            lblValueDefect = new DevExpress.XtraEditors.LabelControl();
            lblValueConfidence = new DevExpress.XtraEditors.LabelControl();
            pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            orderBindingSource = new System.Windows.Forms.BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFabricType = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductType = new DevExpress.XtraGrid.Columns.GridColumn();
            colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrentStage = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).BeginInit();
            splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).BeginInit();
            splitContainerControl1.Panel2.SuspendLayout();
            splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView2).BeginInit();
            SuspendLayout();
            //
            // splitContainerControl1
            //
            splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            splitContainerControl1.Name = "splitContainerControl1";
            //
            // splitContainerControl1.Panel1
            //
            splitContainerControl1.Panel1.Controls.Add(layoutControl1);
            splitContainerControl1.Panel1.Text = "Panel1";
            //
            // splitContainerControl1.Panel2
            //
            splitContainerControl1.Panel2.Controls.Add(gridControl1);
            splitContainerControl1.Panel2.Text = "Panel2";
            splitContainerControl1.Size = new System.Drawing.Size(800, 717);
            splitContainerControl1.SplitterPosition = 374;
            splitContainerControl1.TabIndex = 0;
            //
            // layoutControl1
            //
            layoutControl1.Controls.Add(simpleButton1);
            layoutControl1.Controls.Add(groupControl1);
            layoutControl1.Controls.Add(pictureEdit1);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(982, 367, 812, 500);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(374, 717);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            //
            // simpleButton1
            //
            simpleButton1.Location = new System.Drawing.Point(20, 366);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(334, 34);
            simpleButton1.StyleController = layoutControl1;
            simpleButton1.TabIndex = 6;
            simpleButton1.Text = "Select Image && Analyze";
            simpleButton1.Click += simpleButton1_Click;
            //
            // groupControl1
            //
            groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            groupControl1.Controls.Add(tableLayoutPanel1);
            groupControl1.Location = new System.Drawing.Point(20, 408);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(334, 289);
            groupControl1.TabIndex = 5;
            groupControl1.Text = "Analysis Results";
            //
            // tableLayoutPanel1
            //
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblTitleStatus, 0, 0);
            tableLayoutPanel1.Controls.Add(lblTitleConfidence, 0, 2);
            tableLayoutPanel1.Controls.Add(lblTitleDefectType, 0, 1);
            tableLayoutPanel1.Controls.Add(lblValueStatus, 1, 0);
            tableLayoutPanel1.Controls.Add(lblValueDefect, 1, 1);
            tableLayoutPanel1.Controls.Add(lblValueConfidence, 1, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(2, 36);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(16);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new System.Drawing.Size(330, 251);
            tableLayoutPanel1.TabIndex = 3;
            //
            // lblTitleStatus
            //
            lblTitleStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            lblTitleStatus.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblTitleStatus.Appearance.Options.UseFont = true;
            lblTitleStatus.Appearance.Options.UseForeColor = true;
            lblTitleStatus.Appearance.Options.UseTextOptions = true;
            lblTitleStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            lblTitleStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTitleStatus.Location = new System.Drawing.Point(19, 19);
            lblTitleStatus.Name = "lblTitleStatus";
            lblTitleStatus.Size = new System.Drawing.Size(143, 66);
            lblTitleStatus.TabIndex = 0;
            lblTitleStatus.Text = "Status:";
            //
            // lblTitleConfidence
            //
            lblTitleConfidence.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            lblTitleConfidence.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblTitleConfidence.Appearance.Options.UseFont = true;
            lblTitleConfidence.Appearance.Options.UseForeColor = true;
            lblTitleConfidence.Appearance.Options.UseTextOptions = true;
            lblTitleConfidence.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            lblTitleConfidence.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTitleConfidence.Location = new System.Drawing.Point(19, 163);
            lblTitleConfidence.Name = "lblTitleConfidence";
            lblTitleConfidence.Size = new System.Drawing.Size(143, 69);
            lblTitleConfidence.TabIndex = 2;
            lblTitleConfidence.Text = "Confidence Score:";
            //
            // lblTitleDefectType
            //
            lblTitleDefectType.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            lblTitleDefectType.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblTitleDefectType.Appearance.Options.UseFont = true;
            lblTitleDefectType.Appearance.Options.UseForeColor = true;
            lblTitleDefectType.Appearance.Options.UseTextOptions = true;
            lblTitleDefectType.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            lblTitleDefectType.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTitleDefectType.Location = new System.Drawing.Point(19, 91);
            lblTitleDefectType.Name = "lblTitleDefectType";
            lblTitleDefectType.Size = new System.Drawing.Size(143, 66);
            lblTitleDefectType.TabIndex = 1;
            lblTitleDefectType.Text = "Defect Type:";
            //
            // lblValueStatus
            //
            lblValueStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            lblValueStatus.Appearance.Options.UseFont = true;
            lblValueStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            lblValueStatus.Location = new System.Drawing.Point(168, 19);
            lblValueStatus.Name = "lblValueStatus";
            lblValueStatus.Size = new System.Drawing.Size(143, 66);
            lblValueStatus.TabIndex = 3;
            lblValueStatus.Text = "Defective";
            //
            // lblValueDefect
            //
            lblValueDefect.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            lblValueDefect.Appearance.Options.UseFont = true;
            lblValueDefect.Dock = System.Windows.Forms.DockStyle.Fill;
            lblValueDefect.Location = new System.Drawing.Point(168, 91);
            lblValueDefect.Name = "lblValueDefect";
            lblValueDefect.Size = new System.Drawing.Size(143, 66);
            lblValueDefect.TabIndex = 4;
            lblValueDefect.Text = "Tear";
            //
            // lblValueConfidence
            //
            lblValueConfidence.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            lblValueConfidence.Appearance.Options.UseFont = true;
            lblValueConfidence.Dock = System.Windows.Forms.DockStyle.Fill;
            lblValueConfidence.Location = new System.Drawing.Point(168, 163);
            lblValueConfidence.Name = "lblValueConfidence";
            lblValueConfidence.Size = new System.Drawing.Size(143, 69);
            lblValueConfidence.TabIndex = 5;
            lblValueConfidence.Text = "92%";
            //
            // pictureEdit1
            //
            pictureEdit1.Location = new System.Drawing.Point(20, 49);
            pictureEdit1.Name = "pictureEdit1";
            pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pictureEdit1.Size = new System.Drawing.Size(334, 309);
            pictureEdit1.StyleController = layoutControl1;
            pictureEdit1.TabIndex = 4;
            //
            // Root
            //
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(374, 717);
            Root.TextVisible = false;
            //
            // layoutControlItem1
            //
            layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem1.Control = pictureEdit1;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(342, 346);
            layoutControlItem1.Text = "Fabric to Analyze";
            layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem1.TextSize = new System.Drawing.Size(166, 21);
            //
            // layoutControlItem2
            //
            layoutControlItem2.Control = groupControl1;
            layoutControlItem2.Location = new System.Drawing.Point(0, 388);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(342, 297);
            layoutControlItem2.TextVisible = false;
            //
            // layoutControlItem3
            //
            layoutControlItem3.Control = simpleButton1;
            layoutControlItem3.Location = new System.Drawing.Point(0, 346);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(342, 42);
            layoutControlItem3.TextVisible = false;
            //
            // gridView2
            //
            gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFabricType, colProductType, colQuantity, colCurrentStage });
            gridView2.GridControl = gridControl1;
            gridView2.Name = "gridView2";
            gridView2.OptionsBehavior.Editable = false;
            gridView2.CustomColumnDisplayText += gridView2_CustomColumnDisplayText;
            //
            // colFabricType
            //
            colFabricType.Caption = "Fabric Type";
            colFabricType.FieldName = "Fabric.FabricName";
            colFabricType.MinWidth = 25;
            colFabricType.Name = "colFabricType";
            colFabricType.Visible = true;
            colFabricType.VisibleIndex = 0;
            colFabricType.Width = 94;
            //
            // colProductType
            //
            colProductType.Caption = "Product Type";
            colProductType.FieldName = "Type.TypeName";
            colProductType.MinWidth = 25;
            colProductType.Name = "colProductType";
            colProductType.Visible = true;
            colProductType.VisibleIndex = 1;
            colProductType.Width = 94;
            //
            // colQuantity
            //
            colQuantity.Caption = "Quantity";
            colQuantity.FieldName = "Quantity";
            colQuantity.MinWidth = 25;
            colQuantity.Name = "colQuantity";
            colQuantity.Visible = true;
            colQuantity.VisibleIndex = 2;
            colQuantity.Width = 94;
            //
            // colCurrentStage
            //
            colCurrentStage.Caption = "Item Status";
            colCurrentStage.FieldName = "CurrentStage";
            colCurrentStage.MinWidth = 25;
            colCurrentStage.Name = "colCurrentStage";
            colCurrentStage.Visible = true;
            colCurrentStage.VisibleIndex = 3;
            colCurrentStage.Width = 94;
            //
            // gridControl1
            //
            gridControl1.DataSource = orderBindingSource;
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = gridView2;
            gridLevelNode1.RelationName = "OrderItems";
            gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode1 });
            gridControl1.Location = new System.Drawing.Point(0, 0);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(406, 717);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1, gridView2 });
            //
            // orderBindingSource
            //
            orderBindingSource.DataSource = typeof(Entities.Order);
            //
            // gridView1
            //
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colOrderNumber, colOrderDate, colDueDate, colCustomer });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsDetail.ShowDetailTabs = false;
            //
            // colOrderNumber
            //
            colOrderNumber.Caption = "Order Number";
            colOrderNumber.FieldName = "OrderNumber";
            colOrderNumber.MinWidth = 25;
            colOrderNumber.Name = "colOrderNumber";
            colOrderNumber.Visible = true;
            colOrderNumber.VisibleIndex = 0;
            colOrderNumber.Width = 94;
            //
            // colOrderDate
            //
            colOrderDate.Caption = "Order Date";
            colOrderDate.FieldName = "OrderDate";
            colOrderDate.MinWidth = 25;
            colOrderDate.Name = "colOrderDate";
            colOrderDate.Visible = true;
            colOrderDate.VisibleIndex = 2;
            colOrderDate.Width = 94;
            //
            // colDueDate
            //
            colDueDate.Caption = "Due Date";
            colDueDate.FieldName = "DueDate";
            colDueDate.MinWidth = 25;
            colDueDate.Name = "colDueDate";
            colDueDate.Visible = true;
            colDueDate.VisibleIndex = 3;
            colDueDate.Width = 94;
            //
            // colCustomer
            //
            colCustomer.Caption = "Customer";
            colCustomer.FieldName = "Customer.CustomerName";
            colCustomer.MinWidth = 25;
            colCustomer.Name = "colCustomer";
            colCustomer.Visible = true;
            colCustomer.VisibleIndex = 1;
            colCustomer.Width = 94;
            //
            // FrmFabricQualityControl
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 717);
            Controls.Add(splitContainerControl1);
            Name = "FrmFabricQualityControl";
            Text = "Fabric Control";
            Load += FrmFabricQualityControl_Load;
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).EndInit();
            splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).EndInit();
            splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).EndInit();
            splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colFabricType;
        private DevExpress.XtraGrid.Columns.GridColumn colProductType;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentStage;
        private DevExpress.XtraEditors.LabelControl lblTitleConfidence;
        private DevExpress.XtraEditors.LabelControl lblTitleDefectType;
        private DevExpress.XtraEditors.LabelControl lblTitleStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl lblValueStatus;
        private DevExpress.XtraEditors.LabelControl lblValueDefect;
        private DevExpress.XtraEditors.LabelControl lblValueConfidence;
    }
}
