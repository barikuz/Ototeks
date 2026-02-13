using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Ototeks.Business.Abstract;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using Ototeks.Helpers;
using Ototeks.UI.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Image = System.Drawing.Image;

namespace Ototeks.UI
{
    public partial class FrmFabricQualityControl : DevExpress.XtraEditors.XtraForm
    {
        private OrderManager _orderManager;
        private GenericRepository<Order> _orderRepo;
        private QualityControlManager _qualityManager;
        private GenericRepository<QualityLog> _qualityLogRepo;
        private GenericRepository<DefectType> _defectTypeRepo;

        // Selected order item
        private OrderItem _selectedOrderItem;
        // Selected image path
        private string _selectedImagePath;
        // Last analysis result
        private QualityAnalysisResult _lastAnalysisResult;

        // Detail view tracking
        private bool _isDetailViewActive = false;
        private GridView _currentDetailView = null;

        public FrmFabricQualityControl()
        {
            InitializeComponent();
        }

        private void FrmFabricQualityControl_Load(object sender, EventArgs e)
        {
            InitializeManagers();
            LoadOrders();
            SetupGrid();
            SetupGridEvents();
            ClearAnalysisResults();
        }

        private void InitializeManagers()
        {
            _orderRepo = new GenericRepository<Order>();
            _orderManager = new OrderManager(_orderRepo);
            _qualityLogRepo = new GenericRepository<QualityLog>();
            _defectTypeRepo = new GenericRepository<DefectType>();
            _qualityManager = new QualityControlManager(_qualityLogRepo, _defectTypeRepo);
        }

        private void LoadOrders()
        {
            // Only get orders that have at least one item in the "Quality Control" stage
            var orders = _orderManager.GetAll()
                .Where(o => o.OrderItems != null &&
                            o.OrderItems.Any(item => item.CurrentStage == OrderStatus.QualityControl))
                .ToList();

            orderBindingSource.DataSource = orders;
        }

        private void SetupGrid()
        {
            // Enable Master-Detail for the grid
            gridView1.ActivateMasterDetail<Order>("OrderItems", order => order.OrderItems);
        }

        private void SetupGridEvents()
        {
            // When master view is clicked
            gridView1.Click += (s, e) =>
            {
                _isDetailViewActive = false;
                _currentDetailView = null;
                _selectedOrderItem = null;
            };

            // When detail view is registered
            gridControl1.ViewRegistered += (s, e) =>
            {
                if (e.View is GridView detailView && e.View != gridView1)
                {
                    // When detail view is clicked
                    detailView.Click += (sender, args) =>
                    {
                        _isDetailViewActive = true;
                        _currentDetailView = detailView;

                        if (detailView.GetFocusedRow() is OrderItem selectedItem)
                        {
                            // Only select items in Quality Control stage
                            if (selectedItem.CurrentStage == OrderStatus.QualityControl)
                            {
                                _selectedOrderItem = selectedItem;
                            }
                            else
                            {
                                _selectedOrderItem = null;
                            }
                        }
                    };

                    // When focused row changes in detail view
                    detailView.FocusedRowChanged += (sender, args) =>
                    {
                        if (_isDetailViewActive && detailView.GetFocusedRow() is OrderItem selectedItem)
                        {
                            if (selectedItem.CurrentStage == OrderStatus.QualityControl)
                            {
                                _selectedOrderItem = selectedItem;
                            }
                            else
                            {
                                _selectedOrderItem = null;
                            }
                        }
                    };
                }
            };
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // 1. Check if an order item is selected
            if (_selectedOrderItem == null)
            {
                XtraMessageBox.Show(
                    "Please select an order item in 'Quality Control' status first.\n",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 2. Open file selection dialog
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Fabric Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|" +
                                        "JPEG Files|*.jpg;*.jpeg|" +
                                        "PNG Files|*.png|" +
                                        "All Files|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                _selectedImagePath = openFileDialog.FileName;
            }

            // 3. Display the image in PictureEdit and refresh the screen immediately
            try
            {
                pictureEdit1.Image = Image.FromFile(_selectedImagePath);
                pictureEdit1.Refresh();
                Application.DoEvents(); // Wait for the screen to update
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"An error occurred while loading the image: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 4. Perform AI analysis
            AnalyzeImage();
        }

        private void AnalyzeImage()
        {
            try
            {
                // Show wait cursor
                Cursor = Cursors.WaitCursor;
                simpleButton1.Enabled = false;

                // Analyze with AI model
                _lastAnalysisResult = _qualityManager.AnalyzeFabricImage(_selectedImagePath);

                // Display results on screen
                DisplayAnalysisResults(_lastAnalysisResult);

                // Save quality log to database
                SaveQualityLog();

                // Success message with defect type
                string defectTypeText = EnumHelper.GetDefectTypeName(_lastAnalysisResult.DefectType);
                string statusMessage = _lastAnalysisResult.IsDefective
                    ? "Defect detected in fabric!"
                    : "Fabric passed quality control.";

                XtraMessageBox.Show(
                    $"{statusMessage}\n\n" +
                    $"Result: {defectTypeText}\n" +
                    $"Confidence Score: %{_lastAnalysisResult.ConfidenceScore}\n",
                    "Analysis Complete",
                    MessageBoxButtons.OK,
                    _lastAnalysisResult.IsDefective ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"An error occurred during analysis: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                simpleButton1.Enabled = true;
            }
        }

        private void DisplayAnalysisResults(QualityAnalysisResult result)
        {
            // Status
            lblValueStatus.Text = result.IsDefective ? "Defective" : "Intact";
            lblValueStatus.Appearance.ForeColor = result.IsDefective ? Color.Red : Color.Green;

            // Defect type
            string defectTypeText = EnumHelper.GetDefectTypeName(result.DefectType);
            lblValueDefect.Text = result.IsDefective ? defectTypeText : "-";

            // Confidence score
            lblValueConfidence.Text = $"%{result.ConfidenceScore}";

            // Color based on confidence score
            if (result.ConfidenceScore >= 80)
                lblValueConfidence.Appearance.ForeColor = Color.Green;
            else if (result.ConfidenceScore >= 50)
                lblValueConfidence.Appearance.ForeColor = Color.Orange;
            else
                lblValueConfidence.Appearance.ForeColor = Color.Red;
        }

        private void ClearAnalysisResults()
        {
            lblValueStatus.Text = "-";
            lblValueStatus.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            lblValueDefect.Text = "-";
            lblValueConfidence.Text = "-";
            lblValueConfidence.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            pictureEdit1.Image = null;
            _selectedImagePath = null;
            _lastAnalysisResult = null;
        }

        private void SaveQualityLog()
        {
            if (_selectedOrderItem == null || _lastAnalysisResult == null)
                return;

            try
            {
                // Find defect type from database (if exists)
                DefectType defectType = null;
                if (_lastAnalysisResult.IsDefective)
                {
                    defectType = _qualityManager.GetDefectTypeByName(_lastAnalysisResult.DefectType);
                }

                // Create quality log record
                var qualityLog = new QualityLog
                {
                    OrderItemId = _selectedOrderItem.OrderItemId,
                    InspectionDate = DateTime.Now,
                    IsDefective = _lastAnalysisResult.IsDefective,
                    DefectId = defectType?.DefectId,
                    ConfidenceScore = _lastAnalysisResult.ConfidenceScore,
                    ImagePath = _selectedImagePath,
                };

                // Save to database
                _qualityManager.AddQualityLog(qualityLog);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"An error occurred while saving quality log to database: {ex.Message}",
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            // Display CurrentStage column in the detail table
            if (e.Column.FieldName == "CurrentStage" && e.Value is OrderStatus status)
            {
                e.DisplayText = EnumHelper.GetOrderStatusName(status);
            }
        }
    }
}
