using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using Ototeks.Interfaces;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        // Cache primary key property info for type T
        private PropertyInfo _keyProperty;

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
                    // 1) Yakalanacak anahtar değeri (odaklanan satır)
                    object focusedKeyValue = null;

                    var focusedRow = _view.GetFocusedRow() as T;
                    if (focusedRow != null)
                    {
                        var keyProp = GetKeyProperty();
                        if (keyProp != null)
                        {
                            focusedKeyValue = keyProp.GetValue(focusedRow);
                        }
                    }

                    // 2) Verileri çek ve ata
                    var data = _dataProvider();
                    _gridControl.DataSource = data;

                    // 3) Eğer daha önce bir satır seçili idiyse, aynı id'yi bulup odakla
                    if (focusedKeyValue != null)
                    {
                        var keyProp = GetKeyProperty();
                        if (keyProp != null)
                        {
                            int targetRowHandle = GridControl.InvalidRowHandle;

                            for (int i = 0; i < _view.DataRowCount; i++)
                            {
                                var row = _view.GetRow(i) as T;
                                if (row == null)
                                    continue;

                                var val = keyProp.GetValue(row);
                                if (object.Equals(val, focusedKeyValue))
                                {
                                    targetRowHandle = i;
                                    break;
                                }
                            }

                            if (targetRowHandle != GridControl.InvalidRowHandle)
                            {
                                _view.FocusedRowHandle = targetRowHandle;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veriler yüklenirken hata oluştu: {ex.Message}", 
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Find primary key property for type T. Uses cached value.
        private PropertyInfo GetKeyProperty()
        {
            if (_keyProperty != null)
                return _keyProperty;

            var type = typeof(T);

            // First try convention: TypeName + "Id" e.g., Order -> OrderId
            var prop = type.GetProperty(type.Name + "Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (prop != null)
            {
                _keyProperty = prop;
                return _keyProperty;
            }

            // Otherwise find first property that ends with "Id"
            prop = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                       .FirstOrDefault(p => p.Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase));

            _keyProperty = prop;
            return _keyProperty;
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
        public void Delete(Action<T> deleteAction, Func<T, DialogResult> confirmMessageFunc)
        {
            var selectedEntity = _view.GetFocusedRow() as T;
            if (selectedEntity == null) return;

            var message = confirmMessageFunc(selectedEntity);

            if (message == DialogResult.Yes)
            { 
                try
                {
                    deleteAction(selectedEntity);
                    RefreshAllSameTypeForms(); // Static helper'ı kullan
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // DÜZENLEME MANTIĞI
        public void Update(Action<T> openEditFormAction)
        {
            var selectedEntity = _view.GetFocusedRow() as T;
            if (selectedEntity == null) return;

            openEditFormAction(selectedEntity);
        }


        // Form açma ve otomatik yenileme
        public void ShowForm<TForm>(Func<TForm> createFormFunc)
            where TForm : Form, IOperationForm
        {
            using (var frm = createFormFunc())
            {
                frm.OperationCompleted += (s, args) =>
                {
                    RefreshAllSameTypeForms(); // Static helper'ı kullan
                };

                frm.ShowDialog();
            }
        }

        // Bu helper'ın bağlı olduğu form tipiyle aynı tipteki formları yenile
        private void RefreshAllSameTypeForms()
        {
            var parentForm = _gridControl.FindForm();
            if (parentForm == null) return;

            FormRefreshHelper.RefreshAllOpenFormsByType(parentForm.GetType());
        }
    }
}