using DevExpress.XtraGrid.Localization;

namespace Ototeks.UI
{
    public class TurkishGridLocalizer : GridLocalizer
    {
        // Bu metot, Grid her bir metni ekrana basmadan önce çalışır.
        // "id" parametresi, o an basılacak metnin kodudur.
        public override string GetLocalizedString(GridStringId id)
        {
            return id switch
            {
                // --- 1. GRUP PANELİ ---
                GridStringId.GridGroupPanelText => "Gruplamak istediğiniz sütun başlığını buraya sürükleyin",

                // --- 2. SAĞ TIK MENÜSÜ ---
                GridStringId.MenuColumnSortAscending => "Artan Sıralama (A-Z)",
                GridStringId.MenuColumnSortDescending => "Azalan Sıralama (Z-A)",
                GridStringId.MenuColumnClearSorting => "Sıralamayı Temizle",
                GridStringId.MenuColumnGroup => "Bu Sütuna Göre Grupla",
                GridStringId.MenuColumnUnGroup => "Grubu Kaldır",
                GridStringId.MenuColumnRemoveColumn => "Bu Sütunu Kaldır",
                GridStringId.MenuColumnColumnCustomization => "Sütun Seçici...",
                GridStringId.MenuColumnBestFit => "En Uygun Genişlik",
                GridStringId.MenuColumnBestFitAllColumns => "Tüm Sütunlara En Uygun Genişlik",
                GridStringId.MenuColumnFilterEditor => "Filtre Düzenleyici...",

                // --- 3. FİLTRE VE ARAMA PANELİ ---
                GridStringId.FindControlFindButton => "Bul",
                GridStringId.FindControlClearButton => "Temizle",
                GridStringId.FindNullPrompt => "Aranacak metni girin...",
                GridStringId.FilterPanelCustomizeButton => "Filtreyi Düzenle",
                GridStringId.CustomFilterDialogCaption => "Özel Filtre",
                GridStringId.CustomFilterDialogFormCaption => "Satırları Göster:",
                GridStringId.CustomFilterDialogOkButton => "Tamam",
                GridStringId.CustomFilterDialogCancelButton => "İptal",

                // --- 4. DİĞER METİNLER ---
                GridStringId.PopupFilterAll => "(Tümü)",
                GridStringId.PopupFilterCustom => "(Özel)",
                GridStringId.PopupFilterBlanks => "(Boş Olanlar)",
                GridStringId.PopupFilterNonBlanks => "(Boş Olmayanlar)",

                // Diğer durumlarda orijinal İngilizcesini kullan
                _ => base.GetLocalizedString(id)
            };
        }
    }
}