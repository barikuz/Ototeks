namespace Ototeks.UI
{
    partial class FrmProductionTrack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductionTrack));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            btnPreviousStage = new DevExpress.XtraEditors.SimpleButton();
            btnNextStage = new DevExpress.XtraEditors.SimpleButton();
            stepProgressBar1 = new DevExpress.XtraEditors.StepProgressBar();
            stepProgressBarItem1 = new DevExpress.XtraEditors.StepProgressBarItem();
            stepProgressBarItem2 = new DevExpress.XtraEditors.StepProgressBarItem();
            stepProgressBarItem3 = new DevExpress.XtraEditors.StepProgressBarItem();
            stepProgressBarItem4 = new DevExpress.XtraEditors.StepProgressBarItem();
            stepProgressBarItem5 = new DevExpress.XtraEditors.StepProgressBarItem();
            stepProgressBarItem6 = new DevExpress.XtraEditors.StepProgressBarItem();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFabricType = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductType = new DevExpress.XtraGrid.Columns.GridColumn();
            colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).BeginInit();
            splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).BeginInit();
            splitContainerControl1.Panel2.SuspendLayout();
            splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stepProgressBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit1.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView2).BeginInit();
            SuspendLayout();
            //
            // splitContainerControl1
            //
            splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerControl1.Horizontal = false;
            splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            splitContainerControl1.Name = "splitContainerControl1";
            //
            // splitContainerControl1.Panel1
            //
            splitContainerControl1.Panel1.Controls.Add(groupControl1);
            splitContainerControl1.Panel1.Controls.Add(stepProgressBar1);
            splitContainerControl1.Panel1.Text = "Panel1";
            //
            // splitContainerControl1.Panel2
            //
            splitContainerControl1.Panel2.Controls.Add(gridControl1);
            splitContainerControl1.Panel2.Text = "Panel2";
            splitContainerControl1.Size = new System.Drawing.Size(748, 585);
            splitContainerControl1.SplitterPosition = 326;
            splitContainerControl1.TabIndex = 0;
            //
            // groupControl1
            //
            groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            groupControl1.Controls.Add(tableLayoutPanel1);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            groupControl1.Location = new System.Drawing.Point(0, 196);
            groupControl1.Name = "groupControl1";
            groupControl1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            groupControl1.Size = new System.Drawing.Size(748, 130);
            groupControl1.TabIndex = 1;
            groupControl1.Text = "Stage Control";
            //
            // tableLayoutPanel1
            //
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(btnPreviousStage, 1, 0);
            tableLayoutPanel1.Controls.Add(btnNextStage, 3, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(2, 36);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(744, 84);
            tableLayoutPanel1.TabIndex = 0;
            //
            // btnPreviousStage
            //
            btnPreviousStage.Dock = System.Windows.Forms.DockStyle.Fill;
            btnPreviousStage.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnPreviousStage.ImageOptions.SvgImage");
            btnPreviousStage.Location = new System.Drawing.Point(195, 13);
            btnPreviousStage.Name = "btnPreviousStage";
            btnPreviousStage.Size = new System.Drawing.Size(154, 58);
            btnPreviousStage.TabIndex = 0;
            btnPreviousStage.Text = "Previous Stage";
            btnPreviousStage.Click += btnPreviousStage_Click;
            //
            // btnNextStage
            //
            btnNextStage.Dock = System.Windows.Forms.DockStyle.Fill;
            btnNextStage.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            btnNextStage.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButton1.ImageOptions.SvgImage");
            btnNextStage.Location = new System.Drawing.Point(395, 13);
            btnNextStage.Name = "btnNextStage";
            btnNextStage.Size = new System.Drawing.Size(154, 58);
            btnNextStage.TabIndex = 2;
            btnNextStage.Text = "Next Stage";
            btnNextStage.Click += btnNextStage_Click;
            //
            // stepProgressBar1
            //
            stepProgressBar1.AllowUserInteraction = DevExpress.Utils.DefaultBoolean.True;
            stepProgressBar1.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            stepProgressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            stepProgressBar1.Items.Add(stepProgressBarItem1);
            stepProgressBar1.Items.Add(stepProgressBarItem2);
            stepProgressBar1.Items.Add(stepProgressBarItem3);
            stepProgressBar1.Items.Add(stepProgressBarItem4);
            stepProgressBar1.Items.Add(stepProgressBarItem5);
            stepProgressBar1.Items.Add(stepProgressBarItem6);
            stepProgressBar1.Location = new System.Drawing.Point(0, 0);
            stepProgressBar1.Name = "stepProgressBar1";
            stepProgressBar1.Size = new System.Drawing.Size(748, 196);
            stepProgressBar1.TabIndex = 0;
            //
            // stepProgressBarItem1
            //
            stepProgressBarItem1.ContentBlock2.Caption = "Order Received";
            stepProgressBarItem1.Name = "stepProgressBarItem1";
            //
            // stepProgressBarItem2
            //
            stepProgressBarItem2.ContentBlock2.Caption = "Cutting";
            stepProgressBarItem2.Name = "stepProgressBarItem2";
            //
            // stepProgressBarItem3
            //
            stepProgressBarItem3.ContentBlock2.Caption = "Sewing Workshop";
            stepProgressBarItem3.Name = "stepProgressBarItem3";
            //
            // stepProgressBarItem4
            //
            stepProgressBarItem4.ContentBlock2.Caption = "Ironing & Packaging";
            stepProgressBarItem4.Name = "stepProgressBarItem4";
            //
            // stepProgressBarItem5
            //
            stepProgressBarItem5.ContentBlock2.Caption = "Quality Control";
            stepProgressBarItem5.Name = "stepProgressBarItem5";
            //
            // stepProgressBarItem6
            //
            stepProgressBarItem6.ContentBlock2.Caption = "Completed";
            stepProgressBarItem6.Name = "stepProgressBarItem6";
            //
            // gridControl1
            //
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = gridView2;
            gridLevelNode1.RelationName = "OrderItems";
            gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode1 });
            gridControl1.Location = new System.Drawing.Point(0, 0);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemDateEdit1 });
            gridControl1.Size = new System.Drawing.Size(748, 239);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1, gridView2 });
            //
            // gridView1
            //
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colOrderNumber, colCustomer, colOrderDate, colDueDate });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsDetail.ShowDetailTabs = false;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridView1.CellValueChanged += gridView1_CellValueChanged;
            //
            // colOrderNumber
            //
            colOrderNumber.Caption = "Order Number";
            colOrderNumber.FieldName = "OrderNumber";
            colOrderNumber.MinWidth = 25;
            colOrderNumber.Name = "colOrderNumber";
            colOrderNumber.OptionsColumn.AllowEdit = false;
            colOrderNumber.Visible = true;
            colOrderNumber.VisibleIndex = 0;
            colOrderNumber.Width = 94;
            //
            // colCustomer
            //
            colCustomer.Caption = "Customer";
            colCustomer.FieldName = "Customer.CustomerName";
            colCustomer.MinWidth = 25;
            colCustomer.Name = "colCustomer";
            colCustomer.OptionsColumn.AllowEdit = false;
            colCustomer.Visible = true;
            colCustomer.VisibleIndex = 1;
            colCustomer.Width = 94;
            //
            // colOrderDate
            //
            colOrderDate.Caption = "Order Date";
            colOrderDate.FieldName = "OrderDate";
            colOrderDate.MinWidth = 25;
            colOrderDate.Name = "colOrderDate";
            colOrderDate.OptionsColumn.AllowEdit = false;
            colOrderDate.Visible = true;
            colOrderDate.VisibleIndex = 2;
            colOrderDate.Width = 94;
            //
            // colDueDate
            //
            colDueDate.Caption = "Due Date";
            colDueDate.ColumnEdit = repositoryItemDateEdit1;
            colDueDate.FieldName = "DueDate";
            colDueDate.MinWidth = 25;
            colDueDate.Name = "colDueDate";
            colDueDate.OptionsColumn.AllowEdit = true;
            colDueDate.Visible = true;
            colDueDate.VisibleIndex = 3;
            colDueDate.Width = 94;
            //
            // repositoryItemDateEdit1
            //
            repositoryItemDateEdit1.AutoHeight = false;
            repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemDateEdit1.DisplayFormat.FormatString = "dd.MM.yyyy";
            repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit1.EditFormat.FormatString = "dd.MM.yyyy";
            repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit1.Mask.EditMask = "dd.MM.yyyy";
            repositoryItemDateEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            //
            // gridView2
            //
            gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFabricType, colProductType, colQuantity });
            gridView2.GridControl = gridControl1;
            gridView2.Name = "gridView2";
            gridView2.OptionsBehavior.Editable = false;
            gridView2.FocusedRowChanged += gridView2_FocusedRowChanged;
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
            // FrmProductionTrack
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(748, 585);
            Controls.Add(splitContainerControl1);
            Name = "FrmProductionTrack";
            Text = "Production Tracking";
            Load += FrmProductionTrack_Load;
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).EndInit();
            splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).EndInit();
            splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).EndInit();
            splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stepProgressBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit1.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.StepProgressBar stepProgressBar1;
        private DevExpress.XtraEditors.StepProgressBarItem stepProgressBarItem1;
        private DevExpress.XtraEditors.StepProgressBarItem stepProgressBarItem2;
        private DevExpress.XtraEditors.StepProgressBarItem stepProgressBarItem3;
        private DevExpress.XtraEditors.StepProgressBarItem stepProgressBarItem4;
        private DevExpress.XtraEditors.StepProgressBarItem stepProgressBarItem5;
        private DevExpress.XtraEditors.StepProgressBarItem stepProgressBarItem6;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnPreviousStage;
        private DevExpress.XtraEditors.SimpleButton btnNextStage;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colFabricType;
        private DevExpress.XtraGrid.Columns.GridColumn colProductType;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
    }
}
