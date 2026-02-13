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
            // chartControl1 - Pie Chart (Most Ordered Products)
            DevExpress.XtraCharts.Series pieSeries = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();

            // chartControl2 - Pie Chart (AI Quality Control - Pass/Fail Distribution)
            DevExpress.XtraCharts.Series pieSeries2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView2 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();

            // chartControl3 - Bar Chart (Most Required Fabrics)
            DevExpress.XtraCharts.XYDiagram xyDiagram3 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series barSeries3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView barSeriesView3 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle3 = new DevExpress.XtraCharts.ChartTitle();

            // chartControl4 - Horizontal Bar Chart (Top Customers by Order Count)
            DevExpress.XtraCharts.XYDiagram xyDiagram4 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series barSeries4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView barSeriesView4 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle4 = new DevExpress.XtraCharts.ChartTitle();

            // chartControl5 - Bar Chart (Defect Type Distribution)
            DevExpress.XtraCharts.XYDiagram xyDiagram5 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series barSeries5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView barSeriesView5 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle5 = new DevExpress.XtraCharts.ChartTitle();

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
            ((System.ComponentModel.ISupportInitialize)xyDiagram5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barSeries5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barSeriesView5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartControl2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pieSeries2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pieSeriesView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartControl4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barSeries4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barSeriesView4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartControl3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barSeries3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barSeriesView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pieSeries).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pieSeriesView).BeginInit();
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
            // chartControl5 - Defect Type Distribution (Vertical Bar)
            //
            xyDiagram5.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram5.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
            xyDiagram5.AxisX.Label.Angle = -45;
            xyDiagram5.AxisX.Label.TextPattern = "{A}";
            xyDiagram5.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram5.AxisY.Title.Text = "Count";
            xyDiagram5.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl5.Diagram = xyDiagram5;
            chartControl5.Location = new System.Drawing.Point(423, 294);
            chartControl5.Name = "chartControl5";
            chartControl5.PaletteName = "Office 2013";
            // barSeries5
            barSeries5.Name = "Defect Count";
            barSeries5.SeriesID = 0;
            barSeries5.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            barSeries5.LegendTextPattern = "{A}";
            barSeriesView5.ColorEach = true;
            barSeriesView5.BarWidth = 0.8;
            barSeries5.View = barSeriesView5;
            chartControl5.SeriesSerializable = new DevExpress.XtraCharts.Series[] { barSeries5 };
            chartControl5.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl5.Size = new System.Drawing.Size(396, 273);
            chartControl5.TabIndex = 9;
            // Legend settings
            chartControl5.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl5.Legend.Direction = DevExpress.XtraCharts.LegendDirection.TopToBottom;
            chartControl5.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.RightOutside;
            chartControl5.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Center;
            // Title
            chartTitle5.Text = "AI Quality Control - Defect Type Distribution";
            chartTitle5.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Top;
            chartTitle5.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            chartControl5.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle5 });
            //
            // chartControl2 - AI Quality Control Pass/Fail Distribution (Pie)
            //
            chartControl2.Location = new System.Drawing.Point(20, 294);
            chartControl2.Name = "chartControl2";
            chartControl2.PaletteName = "Office 2013";
            // pieSeries2
            pieSeries2.Name = "Quality Status";
            pieSeries2.SeriesID = 0;
            pieSeries2.LegendTextPattern = "{A}";
            pieSeries2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            pieSeries2.Label.TextPattern = "{A}: {V} ({VP:P0})";
            pieSeries2.View = pieSeriesView2;
            chartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[] { pieSeries2 };
            chartControl2.Size = new System.Drawing.Size(395, 273);
            chartControl2.TabIndex = 8;
            // Legend settings
            chartControl2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl2.Legend.Direction = DevExpress.XtraCharts.LegendDirection.TopToBottom;
            chartControl2.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.RightOutside;
            chartControl2.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Center;
            // Title
            chartTitle2.Text = "AI Quality Control - Pass/Fail Distribution";
            chartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Top;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            chartControl2.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle2 });
            //
            // chartControl4 - Top Customers by Order Count (Horizontal Bar)
            //
            xyDiagram4.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram4.AxisX.Title.Text = "Order Count";
            xyDiagram4.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram4.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram4.AxisY.Label.ResolveOverlappingOptions.AllowHide = false;
            xyDiagram4.Rotated = true;
            chartControl4.Diagram = xyDiagram4;
            chartControl4.Location = new System.Drawing.Point(550, 20);
            chartControl4.Name = "chartControl4";
            chartControl4.PaletteName = "Office 2013";
            // barSeries4
            barSeries4.Name = "Order Count";
            barSeries4.SeriesID = 0;
            barSeries4.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            barSeries4.LegendTextPattern = "{A}";
            barSeriesView4.ColorEach = true;
            barSeriesView4.BarWidth = 0.8;
            barSeries4.View = barSeriesView4;
            chartControl4.SeriesSerializable = new DevExpress.XtraCharts.Series[] { barSeries4 };
            chartControl4.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl4.Size = new System.Drawing.Size(269, 266);
            chartControl4.TabIndex = 7;
            // Legend settings
            chartControl4.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl4.Legend.Direction = DevExpress.XtraCharts.LegendDirection.TopToBottom;
            chartControl4.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.RightOutside;
            chartControl4.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Center;
            // Title
            chartTitle4.Text = "Top Customers by Order Count";
            chartTitle4.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Top;
            chartTitle4.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            chartControl4.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle4 });
            //
            // chartControl3 - Most Required Fabrics (Vertical Bar)
            //
            xyDiagram3.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram3.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
            xyDiagram3.AxisX.Label.Angle = -45;
            xyDiagram3.AxisX.Label.TextPattern = "{A}";
            xyDiagram3.AxisY.VisibleInPanesSerializable = "-1";
            chartControl3.Diagram = xyDiagram3;
            chartControl3.Location = new System.Drawing.Point(309, 20);
            chartControl3.Name = "chartControl3";
            chartControl3.PaletteName = "Office 2013";
            // barSeries3
            barSeries3.Name = "Required Fabric (m)";
            barSeries3.SeriesID = 0;
            barSeries3.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            barSeries3.LegendTextPattern = "{A}";
            barSeriesView3.ColorEach = true;
            barSeriesView3.BarWidth = 0.8;
            barSeries3.View = barSeriesView3;
            chartControl3.SeriesSerializable = new DevExpress.XtraCharts.Series[] { barSeries3 };
            chartControl3.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl3.Size = new System.Drawing.Size(233, 266);
            chartControl3.TabIndex = 6;
            // Legend settings
            chartControl3.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl3.Legend.Direction = DevExpress.XtraCharts.LegendDirection.TopToBottom;
            chartControl3.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.RightOutside;
            chartControl3.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Center;
            // Title
            chartTitle3.Text = "Most Required Fabrics (Meters)";
            chartTitle3.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Top;
            chartTitle3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            chartControl3.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle3 });
            //
            // chartControl1 - Most Ordered Products (Pie)
            //
            chartControl1.Location = new System.Drawing.Point(20, 20);
            chartControl1.Name = "chartControl1";
            chartControl1.PaletteName = "Office 2013";
            // pieSeries
            pieSeries.Name = "Products";
            pieSeries.SeriesID = 0;
            pieSeries.LegendTextPattern = "{A}";
            pieSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            pieSeries.Label.TextPattern = "{A}: {V}";
            pieSeries.View = pieSeriesView;
            chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] { pieSeries };
            chartControl1.Size = new System.Drawing.Size(281, 266);
            chartControl1.TabIndex = 4;
            // Legend settings
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.TopToBottom;
            chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.RightOutside;
            chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Center;
            // Title
            chartTitle1.Text = "Most Ordered Products";
            chartTitle1.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Top;
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle1 });
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
            Text = "Statistics";
            this.Load += FrmStatistics_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)xyDiagram5).EndInit();
            ((System.ComponentModel.ISupportInitialize)barSeries5).EndInit();
            ((System.ComponentModel.ISupportInitialize)barSeriesView5).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pieSeriesView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pieSeries2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl2).EndInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram4).EndInit();
            ((System.ComponentModel.ISupportInitialize)barSeries4).EndInit();
            ((System.ComponentModel.ISupportInitialize)barSeriesView4).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl4).EndInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram3).EndInit();
            ((System.ComponentModel.ISupportInitialize)barSeries3).EndInit();
            ((System.ComponentModel.ISupportInitialize)barSeriesView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pieSeriesView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pieSeries).EndInit();
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
