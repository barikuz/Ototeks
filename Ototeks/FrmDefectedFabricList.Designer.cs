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
            // Detail View (gridView2)
            gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFabricType = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductType = new DevExpress.XtraGrid.Columns.GridColumn();
            colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrentStage = new DevExpress.XtraGrid.Columns.GridColumn();
            colDefectType = new DevExpress.XtraGrid.Columns.GridColumn();
            colConfidenceScore = new DevExpress.XtraGrid.Columns.GridColumn();
            colAnalysisDate = new DevExpress.XtraGrid.Columns.GridColumn();
            // Master View (gridView1)
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrderStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)gridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // gridView2 (Detail View - Sipariş Kalemleri)
            // 
            gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFabricType, colProductType, colQuantity, colCurrentStage, colDefectType, colConfidenceScore, colAnalysisDate });
            gridView2.GridControl = gridControl1;
            gridView2.Name = "gridView2";
            gridView2.OptionsBehavior.Editable = false;
            gridView2.OptionsView.ShowGroupPanel = false;
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
            gridControl1.Size = new System.Drawing.Size(800, 500);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1, gridView2 });
            // 
            // gridView1 (Master View - Siparişler)
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
            // FrmDefectedFabricList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 500);
            Controls.Add(gridControl1);
            Name = "FrmDefectedFabricList";
            Text = "Hatalı Kumaşlar";
            Load += FrmDefectedFabricList_Load;
            ((System.ComponentModel.ISupportInitialize)gridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
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
    }
}