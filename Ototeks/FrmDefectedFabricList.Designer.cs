namespace Ototeks.UI
{
    partial class FrmDefectedFabricList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDefectedFabricList));
            gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFabricType = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductType = new DevExpress.XtraGrid.Columns.GridColumn();
            colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrentStage = new DevExpress.XtraGrid.Columns.GridColumn();
            colDefectType = new DevExpress.XtraGrid.Columns.GridColumn();
            colConfidenceScore = new DevExpress.XtraGrid.Columns.GridColumn();
            colAnalysisDate = new DevExpress.XtraGrid.Columns.GridColumn();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrderStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            btnDelete = new DevExpress.XtraBars.BarButtonItem();
            popupMenuDetail = new DevExpress.XtraBars.PopupMenu(components);
            ((System.ComponentModel.ISupportInitialize)gridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenuDetail).BeginInit();
            SuspendLayout();
            // 
            // gridView2
            // 
            gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFabricType, colProductType, colQuantity, colCurrentStage, colDefectType, colConfidenceScore, colAnalysisDate });
            gridView2.GridControl = gridControl1;
            gridView2.Name = "gridView2";
            gridView2.OptionsBehavior.Editable = false;
            gridView2.OptionsView.ShowGroupPanel = false;
            gridView2.PopupMenuShowing += gridView2_PopupMenuShowing;
            gridView2.CustomColumnDisplayText += gridView2_CustomColumnDisplayText;
            // 
            // colFabricType
            // 
            colFabricType.Caption = "Kumaş Türü";
            colFabricType.FieldName = "FabricName";
            colFabricType.MinWidth = 25;
            colFabricType.Name = "colFabricType";
            colFabricType.Visible = true;
            colFabricType.VisibleIndex = 0;
            colFabricType.Width = 94;
            // 
            // colProductType
            // 
            colProductType.Caption = "Ürün Türü";
            colProductType.FieldName = "TypeName";
            colProductType.MinWidth = 25;
            colProductType.Name = "colProductType";
            colProductType.Visible = true;
            colProductType.VisibleIndex = 1;
            colProductType.Width = 94;
            // 
            // colQuantity
            // 
            colQuantity.Caption = "Adet";
            colQuantity.FieldName = "Quantity";
            colQuantity.MinWidth = 25;
            colQuantity.Name = "colQuantity";
            colQuantity.Visible = true;
            colQuantity.VisibleIndex = 2;
            colQuantity.Width = 94;
            // 
            // colCurrentStage
            // 
            colCurrentStage.Caption = "Kalem Durumu";
            colCurrentStage.FieldName = "CurrentStage";
            colCurrentStage.MinWidth = 25;
            colCurrentStage.Name = "colCurrentStage";
            colCurrentStage.Visible = true;
            colCurrentStage.VisibleIndex = 3;
            colCurrentStage.Width = 94;
            // 
            // colDefectType
            // 
            colDefectType.Caption = "Hata Türü";
            colDefectType.FieldName = "DefectType";
            colDefectType.MinWidth = 25;
            colDefectType.Name = "colDefectType";
            colDefectType.Visible = true;
            colDefectType.VisibleIndex = 4;
            colDefectType.Width = 94;
            // 
            // colConfidenceScore
            // 
            colConfidenceScore.Caption = "Güven Skoru";
            colConfidenceScore.FieldName = "ConfidenceScore";
            colConfidenceScore.MinWidth = 25;
            colConfidenceScore.Name = "colConfidenceScore";
            colConfidenceScore.Visible = true;
            colConfidenceScore.VisibleIndex = 5;
            colConfidenceScore.Width = 94;
            // 
            // colAnalysisDate
            // 
            colAnalysisDate.Caption = "Analiz Tarihi";
            colAnalysisDate.FieldName = "AnalysisDate";
            colAnalysisDate.MinWidth = 25;
            colAnalysisDate.Name = "colAnalysisDate";
            colAnalysisDate.Visible = true;
            colAnalysisDate.VisibleIndex = 6;
            colAnalysisDate.Width = 94;
            // 
            // gridControl1
            // 
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = gridView2;
            gridLevelNode1.RelationName = "DefectedItems";
            gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode1 });
            gridControl1.Location = new System.Drawing.Point(0, 0);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(800, 496);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1, gridView2 });
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colOrderNumber, colCustomer, colOrderDate, colDueDate, colOrderStatus });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsDetail.ShowDetailTabs = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.CustomColumnDisplayText += gridView1_CustomColumnDisplayText;
            // 
            // colOrderNumber
            // 
            colOrderNumber.Caption = "Sipariş Numarası";
            colOrderNumber.FieldName = "OrderNumber";
            colOrderNumber.MinWidth = 25;
            colOrderNumber.Name = "colOrderNumber";
            colOrderNumber.Visible = true;
            colOrderNumber.VisibleIndex = 0;
            colOrderNumber.Width = 94;
            // 
            // colCustomer
            // 
            colCustomer.Caption = "Müşteri";
            colCustomer.FieldName = "CustomerName";
            colCustomer.MinWidth = 25;
            colCustomer.Name = "colCustomer";
            colCustomer.Visible = true;
            colCustomer.VisibleIndex = 1;
            colCustomer.Width = 94;
            // 
            // colOrderDate
            // 
            colOrderDate.Caption = "Sipariş Tarihi";
            colOrderDate.FieldName = "OrderDate";
            colOrderDate.MinWidth = 25;
            colOrderDate.Name = "colOrderDate";
            colOrderDate.Visible = true;
            colOrderDate.VisibleIndex = 2;
            colOrderDate.Width = 94;
            // 
            // colDueDate
            // 
            colDueDate.Caption = "Teslim Tarihi";
            colDueDate.FieldName = "DueDate";
            colDueDate.MinWidth = 25;
            colDueDate.Name = "colDueDate";
            colDueDate.Visible = true;
            colDueDate.VisibleIndex = 3;
            colDueDate.Width = 94;
            // 
            // colOrderStatus
            // 
            colOrderStatus.Caption = "Sipariş Durumu";
            colOrderStatus.FieldName = "OrderStatus";
            colOrderStatus.MinWidth = 25;
            colOrderStatus.Name = "colOrderStatus";
            colOrderStatus.Visible = true;
            colOrderStatus.VisibleIndex = 4;
            colOrderStatus.Width = 94;
            // 
            // barManager1
            // 
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { btnDelete });
            barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(800, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 496);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(800, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 496);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(800, 0);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 496);
            // 
            // btnDelete
            // 
            btnDelete.Caption = "Sil";
            btnDelete.Id = 0;
            btnDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnDelete.ImageOptions.SvgImage");
            btnDelete.Name = "btnDelete";
            btnDelete.ItemClick += btnDelete_ItemClick;
            // 
            // popupMenuDetail
            // 
            popupMenuDetail.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(btnDelete) });
            popupMenuDetail.Manager = barManager1;
            popupMenuDetail.Name = "popupMenuDetail";
            // 
            // FrmDefectedFabricList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 496);
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "FrmDefectedFabricList";
            Text = "Hatalı Kumaşlar";
            Load += FrmDefectedFabricList_Load;
            ((System.ComponentModel.ISupportInitialize)gridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenuDetail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        // Master View Columns
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderStatus;
        // Detail View Columns
        private DevExpress.XtraGrid.Columns.GridColumn colFabricType;
        private DevExpress.XtraGrid.Columns.GridColumn colProductType;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentStage;
        // Extra Defect Columns
        private DevExpress.XtraGrid.Columns.GridColumn colDefectType;
        private DevExpress.XtraGrid.Columns.GridColumn colConfidenceScore;
        private DevExpress.XtraGrid.Columns.GridColumn colAnalysisDate;
        // Context Menu Components
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.PopupMenu popupMenuDetail;
    }
}