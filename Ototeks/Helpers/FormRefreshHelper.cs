using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Ototeks.Helpers
{
    /// <summary>
    /// Açýk formlarý yenilemek için kullanýlan static helper sýnýfý.
    /// Tüm yenileme mantýðý tek bir yerde toplanmýþtýr.
    /// </summary>
    public static class FormRefreshHelper
    {
        /// <summary>
        /// Belirtilen tipteki TÜM açýk formlarýn RefreshData metodunu çaðýrýr.
        /// </summary>
        /// <typeparam name="TForm">Yenilenecek form tipi</typeparam>
        public static void RefreshAllOpenForms<TForm>() where TForm : Form
        {
            var formType = typeof(TForm);
            RefreshAllOpenFormsByType(formType);
        }

        /// <summary>
        /// Verilen form tipiyle ayný tipteki TÜM açýk formlarýn RefreshData metodunu çaðýrýr.
        /// </summary>
        /// <param name="formType">Yenilenecek form tipi</param>
        public static void RefreshAllOpenFormsByType(Type formType)
        {
            // Application.OpenForms üzerinde döngü yap
            // ToList() ile kopyasýný al çünkü koleksiyon deðiþebilir
            var openForms = Application.OpenForms.Cast<Form>().ToList();

            foreach (var form in openForms)
            {
                // Eðer form ayný tipte ise
                if (form.GetType() == formType)
                {
                    // RefreshData metodunu çaðýr
                    var refreshMethod = formType.GetMethod("RefreshData", BindingFlags.Public | BindingFlags.Instance);
                    refreshMethod?.Invoke(form, null);
                }
            }
        }
    }
}
