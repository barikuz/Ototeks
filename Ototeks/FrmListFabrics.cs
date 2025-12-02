using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Windows.Forms;

namespace Ototeks.UI
{
    public partial class FrmListFabrics : DevExpress.XtraEditors.XtraForm
    {
        private FabricManager _manager;
        private GenericRepository<Fabric> _repo;

        public FrmListFabrics()
        {
            InitializeComponent();
        }

        private void FrmListFabrics_Load(object sender, EventArgs e)
        {
            ListeyiYenile();
        }
        public void ListeyiYenile()
        {
            _repo = new GenericRepository<Fabric>();
            _manager = new FabricManager(_repo);
            bindingSource1.DataSource = _manager.GetAll();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            // Tıklanan yerin bilgisini al (Row mu? Boşluk mu?)
            var hitInfo = e.HitInfo;

            // 1. SENARYO: SATIRA TIKLANDI (Dolu)
            if (hitInfo.InRow)
            {
                // Sil butonu GÖRÜNSÜN
                btnDelete.Visibility = BarItemVisibility.Always;
            }
            // 2. SENARYO: BOŞLUĞA TIKLANDI (Empty Space)
            else if (hitInfo.HitTest == GridHitTest.EmptyRow)
            {
                // Sil butonu GİZLENSİN (Çünkü silinecek bir şey yok)
                btnDelete.Visibility = BarItemVisibility.Never;
            }

            // Menüyü aç
            sagTikMenu.ShowPopup(Control.MousePosition);
        }

        // --- SİL BUTONU KODU ---
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 1. Seçili satırdaki Kumaş nesnesini al
            var secilenKumas = gridView1.GetFocusedRow() as Fabric;

            if (secilenKumas == null) return;

            // 2. Kullanıcıya sor (Yanlışlıkla basmış olabilir)
            var cevap = MessageBox.Show(
                $"'{secilenKumas.FabricCode}' kodlu kumaşı silmek istediğinize emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (cevap == DialogResult.Yes)
            {
                // 3. Veritabanından sil
                _manager.Delete(secilenKumas);

                // 4. Listeyi yenile (ki silinen ekrandan gitsin)
                ListeyiYenile();
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmAddFabric frm = new FrmAddFabric();

            frm.IslemYapildi += (s, args) => ListeyiYenile();

            // Formu "Dialog" olarak aç 
            frm.ShowDialog();
        }

        // Helper method to open the edit form
        private void OpenEditForm()
        {
            // 1. Get the selected row data
            var pickedFabric = gridView1.GetFocusedRow() as Fabric;

            // Safety check: If nothing is selected or clicked on a group row
            if (pickedFabric == null) return;

            // 2. Open form with ID (Update Mode)
            FrmAddFabric frm = new FrmAddFabric(pickedFabric.FabricId);

            // 3. Subscribe to event to refresh the list after update
            frm.IslemYapildi += (s, args) => ListeyiYenile();

            frm.ShowDialog();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            // Call the common method
            OpenEditForm();
        }

        private void btnUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Call the common method
            OpenEditForm();
        }
    }
}