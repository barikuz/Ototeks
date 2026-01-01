namespace Ototeks.UI
{
    partial class FrmStatistics
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            chartControl5 = new DevExpress.XtraCharts.ChartControl();
            chartControl2 = new DevExpress.XtraCharts.ChartControl();
            chartControl4 = new DevExpress.XtraCharts.ChartControl();
            chartControl3 = new DevExpress.XtraCharts.ChartControl();
            chartControl1 = new DevExpress.XtraCharts.ChartControl();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartControl5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartControl2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartControl4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartControl3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pieSeriesView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(chartControl5);
            layoutControl1.Controls.Add(chartControl2);
            layoutControl1.Controls.Add(chartControl4);
            layoutControl1.Controls.Add(chartControl3);
            layoutControl1.Controls.Add(chartControl1);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1108, 172, 812, 500);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(839, 587);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // chartControl5
            // 
            chartControl5.Location = new System.Drawing.Point(423, 294);
            chartControl5.Name = "chartControl5";
            chartControl5.Size = new System.Drawing.Size(396, 273);
            chartControl5.TabIndex = 9;
            // 
            // chartControl2
            // 
            chartControl2.Location = new System.Drawing.Point(20, 294);
            chartControl2.Name = "chartControl2";
            chartControl2.Size = new System.Drawing.Size(395, 273);
            chartControl2.TabIndex = 8;
            // 
            // chartControl4
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            chartControl4.Diagram = xyDiagram1;
            chartControl4.Location = new System.Drawing.Point(550, 20);
            chartControl4.Name = "chartControl4";
            series1.Name = "Series 1";
            series1.SeriesID = 0;
            chartControl4.SeriesSerializable = new DevExpress.XtraCharts.Series[]
    {
    series1
    };
            chartControl4.Size = new System.Drawing.Size(269, 266);
            chartControl4.TabIndex = 7;
            // 
            // chartControl3
            // 
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            chartControl3.Diagram = xyDiagram2;
            chartControl3.Location = new System.Drawing.Point(309, 20);
            chartControl3.Name = "chartControl3";
            series2.Name = "Series 1";
            series2.SeriesID = 0;
            chartControl3.SeriesSerializable = new DevExpress.XtraCharts.Series[]
    {
    series2
    };
            chartControl3.Size = new System.Drawing.Size(233, 266);
            chartControl3.TabIndex = 6;
            // 
            // chartControl1
            // 
            chartControl1.Location = new System.Drawing.Point(20, 20);
            chartControl1.Name = "chartControl1";
            series3.Name = "Series 1";
            series3.SeriesID = 0;
            series3.View = pieSeriesView1;
            chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[]
    {
    series3
    };
            chartControl1.Size = new System.Drawing.Size(281, 266);
            chartControl1.TabIndex = 4;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem3, layoutControlItem4, layoutControlItem2, layoutControlItem5 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(839, 587);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = chartControl1;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(289, 274);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = chartControl3;
            layoutControlItem3.Location = new System.Drawing.Point(289, 0);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(241, 274);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = chartControl4;
            layoutControlItem4.Location = new System.Drawing.Point(530, 0);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(277, 274);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = chartControl2;
            layoutControlItem2.Location = new System.Drawing.Point(0, 274);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(403, 281);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = chartControl5;
            layoutControlItem5.Location = new System.Drawing.Point(403, 274);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(404, 281);
            layoutControlItem5.TextVisible = false;
            // 
            // FrmStatistics
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(839, 587);
            Controls.Add(layoutControl1);
            Name = "FrmStatistics";
            Text = "İstatistik";
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartControl5).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl2).EndInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram1).EndInit();
            ((System.ComponentModel.ISupportInitialize)series1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl4).EndInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram2).EndInit();
            ((System.ComponentModel.ISupportInitialize)series2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pieSeriesView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)series3).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraCharts.ChartControl chartControl5;
        private DevExpress.XtraCharts.ChartControl chartControl2;
        private DevExpress.XtraCharts.ChartControl chartControl4;
        private DevExpress.XtraCharts.ChartControl chartControl3;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}