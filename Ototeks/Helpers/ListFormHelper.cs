using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using Ototeks.Interfaces;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Ototeks.Helpers
{
    // T: Burada Fabric, Order gibi entity sınıfları olacak.
    public class ListFormHelper<T> where T : class
    {
        private GridView _view;
        private PopupMenu _popupMenu;
        private BarButtonItem _btnAdd;
        private BarButtonItem _btnEdit;
        private BarButtonItem _btnDelete;
        private GridControl _gridControl;
        private Func<List<T>> _dataProvider;

        // Constructor: Formdaki bileşenleri buraya tanıtıyoruz
        public ListFormHelper(GridView view, PopupMenu popupMenu, BarButtonItem btnAdd, BarButtonItem btnEdit, BarButtonItem btnDelete)
        {
            _view = view;
            _popupMenu = popupMenu;
            _btnAdd = btnAdd;
            _btnEdit = btnEdit;
            _btnDelete = btnDelete;
            _gridControl = view.GridControl;
        }

        // Data provider'ı set etme metodu
        public void SetDataProvider(Func<List<T>> dataProvider)
        {
            _dataProvider = dataProvider;
        }

        // Ortak RefreshData metodu
        public void RefreshData()
        {
            if (_dataProvider != null)
            {
                try
                {
                    var data = _dataProvider();
                    _gridControl.DataSource = data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veriler yüklenirken hata oluştu: {ex.Message}", 
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 1. POPUP GÖSTERME MANTIĞI
        public void HandlePopupMenuShowing(PopupMenuShowingEventArgs e)
        {
            var hitInfo = e.HitInfo;

            if (hitInfo.InRow)
            {
                // Satıra tıklandı: Düzenle/Sil görünsün
                if (_btnEdit != null) _btnEdit.Visibility = BarItemVisibility.Always;
                if (_btnDelete != null) _btnDelete.Visibility = BarItemVisibility.Always;
            }
            else if (hitInfo.HitTest == GridHitTest.EmptyRow || hitInfo.HitTest == GridHitTest.None)
            {
                // Boşluğa tıklandı: Düzenle/Sil gizlensin
                if (_btnEdit != null) _btnEdit.Visibility = BarItemVisibility.Never;
                if (_btnDelete != null) _btnDelete.Visibility = BarItemVisibility.Never;
            }

            // Menüyü aç
            _popupMenu.ShowPopup(Control.MousePosition);
        }


        // SİLME MANTIĞI
        // deleteAction: Manager.Delete(id) gibi asıl silme işi
        // confirmMessageFunc: Kullanıcıya gösterilecek mesajı üreten fonksiyon
        public void Delete(Action<T> deleteAction, Func<T, DialogResult> confirmMessageFunc)
        {
            var selectedEntity = _view.GetFocusedRow() as T;
            if (selectedEntity == null) return;

            // Mesajı dinamik olarak oluştur (Örn: "Kumaş X silinsin mi?")
            var message = confirmMessageFunc(selectedEntity);

            if (message == DialogResult.Yes)
            { 
                deleteAction(selectedEntity); // Veritabanından sil
                RefreshData();                // Otomatik olarak yenile
            }
        }

        // DÜZENLEME MANTIĞI
        // openEditFormAction: Formu açan metot (ID'yi alıp formu new'leyen yer)
        public void Update(Action<T> openEditFormAction)
        {
            var selectedEntity = _view.GetFocusedRow() as T;
            if (selectedEntity == null) return;

            openEditFormAction(selectedEntity);
        }


        // TForm: Hem bir 'Form' olmalı (ShowDialog için), hem de 'IOperationForm' olmalı (Event için).
        public void ShowForm<TForm>(Func<TForm> createFormFunc)
            where TForm : Form, IOperationForm
        {
            // 1. Formu yarat (Constructor parametresi varsa burada halledilir)
            using (var frm = createFormFunc())
            {
                // 2. OTOMATİK ABONELİK 
                // Helper, senin yerine event'e abone oluyor.
                frm.OperationCompleted += (s, args) =>
                {
                    RefreshData(); // İşlem bitince otomatik yenile
                };

                // 3. Formu Aç
                frm.ShowDialog();
            }
        }
    }
}