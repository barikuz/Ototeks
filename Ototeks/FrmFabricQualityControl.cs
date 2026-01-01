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

        // Seçili sipariş kalemi
        private OrderItem _selectedOrderItem;
        // Seçili görüntü yolu
        private string _selectedImagePath;
        // Son analiz sonucu
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
            // Sadece "Kalite Kontrol" aşamasında en az bir kalemi olan siparişleri getir
            var orders = _orderManager.GetAll()
                .Where(o => o.OrderItems != null && 
                            o.OrderItems.Any(item => item.CurrentStage == OrderStatus.QualityControl))
                .ToList();

            orderBindingSource.DataSource = orders;
        }

        private void SetupGrid()
        {
            // Grid'e Master-Detail özelliği ver
            gridView1.ActivateMasterDetail<Order>("OrderItems", order => order.OrderItems);
        }

        private void SetupGridEvents()
        {
            // Master view'a tıklandığında
            gridView1.Click += (s, e) =>
            {
                _isDetailViewActive = false;
                _currentDetailView = null;
                _selectedOrderItem = null;
            };

            // Detail view oluşturulduğunda
            gridControl1.ViewRegistered += (s, e) =>
            {
                if (e.View is GridView detailView && e.View != gridView1)
                {
                    // Detail view'a tıklandığında
                    detailView.Click += (sender, args) =>
                    {
                        _isDetailViewActive = true;
                        _currentDetailView = detailView;
                        
                        if (detailView.GetFocusedRow() is OrderItem selectedItem)
                        {
                            // Sadece Kalite Kontrol aşamasındaki kalemleri seç
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

                    // Detail view'da satır değiştiğinde
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
            // 1. Sipariş kalemi seçili mi kontrol et
            if (_selectedOrderItem == null)
            {
                XtraMessageBox.Show(
                    "Lütfen önce 'Kalite Kontrol' durumunda bir sipariş kalemi seçin.\n",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 2. Dosya seçme dialogu aç
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Kumaş Görüntüsü Seçin";
                openFileDialog.Filter = "Görüntü Dosyaları|*.jpg;*.jpeg;*.png;*.bmp;*.gif|" +
                                        "JPEG Dosyaları|*.jpg;*.jpeg|" +
                                        "PNG Dosyaları|*.png|" +
                                        "Tüm Dosyalar|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                _selectedImagePath = openFileDialog.FileName;
            }

            // 3. Görüntüyü PictureEdit'te göster ve ekranı hemen güncelle
            try
            {
                pictureEdit1.Image = Image.FromFile(_selectedImagePath);
                pictureEdit1.Refresh();
                Application.DoEvents(); // Ekranın güncellenmesini bekle
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Görüntü yüklenirken hata oluştu: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 4. AI analizi yap
            AnalyzeImage();
        }

        private void AnalyzeImage()
        {
            try
            {
                // Bekleme cursor'u göster
                Cursor = Cursors.WaitCursor;
                simpleButton1.Enabled = false;

                // AI modeli ile analiz yap
                _lastAnalysisResult = _qualityManager.AnalyzeFabricImage(_selectedImagePath);

                // Sonuçları ekranda göster
                DisplayAnalysisResults(_lastAnalysisResult);

                // Kalite logunu veritabanına kaydet
                SaveQualityLog();

                // Başarı mesajı - Türkçe hata türü ile
                string defectTypeText = EnumHelper.GetDefectTypeName(_lastAnalysisResult.DefectType);
                string statusMessage = _lastAnalysisResult.IsDefective 
                    ? "Kumaşta hata tespit edildi!" 
                    : "Kumaş kalite kontrolden geçti.";
                
                XtraMessageBox.Show(
                    $"{statusMessage}\n\n" +
                    $"Sonuç: {defectTypeText}\n" +
                    $"Güven Skoru: %{_lastAnalysisResult.ConfidenceScore}\n",
                    "Analiz Tamamlandı",
                    MessageBoxButtons.OK,
                    _lastAnalysisResult.IsDefective ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Analiz sırasında hata oluştu: {ex.Message}",
                    "Hata",
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
            // Durum
            lblValueStatus.Text = result.IsDefective ? "Hatalı" : "Sağlam";
            lblValueStatus.Appearance.ForeColor = result.IsDefective ? Color.Red : Color.Green;

            // Hata türü - Türkçe olarak göster
            string defectTypeText = EnumHelper.GetDefectTypeName(result.DefectType);
            lblValueDefect.Text = result.IsDefective ? defectTypeText : "-";

            // Güven skoru
            lblValueConfidence.Text = $"%{result.ConfidenceScore}";
            
            // Güven skoruna göre renk
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
                // Hata tipini veritabanından bul (varsa)
                DefectType defectType = null;
                if (_lastAnalysisResult.IsDefective)
                {
                    defectType = _qualityManager.GetDefectTypeByName(_lastAnalysisResult.DefectType);
                }

                // Kalite log kaydı oluştur
                var qualityLog = new QualityLog
                {
                    OrderItemId = _selectedOrderItem.OrderItemId,
                    InspectionDate = DateTime.Now,
                    IsDefective = _lastAnalysisResult.IsDefective,
                    DefectId = defectType?.DefectId,
                    ConfidenceScore = _lastAnalysisResult.ConfidenceScore,
                    ImagePath = _selectedImagePath,
                };

                // Veritabanına kaydet
                _qualityManager.AddQualityLog(qualityLog);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Kalite kaydı veritabanına eklenirken hata oluştu: {ex.Message}",
                    "Kayıt Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            // Alt tablodaki CurrentStage kolonunu Türkçe göster
            if (e.Column.FieldName == "CurrentStage" && e.Value is OrderStatus status)
            {
                e.DisplayText = EnumHelper.GetOrderStatusName(status);
            }
        }
    }
}