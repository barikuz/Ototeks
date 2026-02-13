using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Ototeks.Helpers
{
    /// <summary>
    /// Static helper class used to refresh open forms.
    /// All refresh logic is centralized in one place.
    /// </summary>
    public static class FormRefreshHelper
    {
        /// <summary>
        /// Calls the RefreshData method on ALL open forms of the specified type.
        /// </summary>
        /// <typeparam name="TForm">The form type to refresh</typeparam>
        public static void RefreshAllOpenForms<TForm>() where TForm : Form
        {
            var formType = typeof(TForm);
            RefreshAllOpenFormsByType(formType);
        }

        /// <summary>
        /// Calls the RefreshData method on ALL open forms matching the given form type.
        /// </summary>
        /// <param name="formType">The form type to refresh</param>
        public static void RefreshAllOpenFormsByType(Type formType)
        {
            // Iterate over Application.OpenForms
            // Use ToList() to create a copy since the collection may change
            var openForms = Application.OpenForms.Cast<Form>().ToList();

            foreach (var form in openForms)
            {
                // If the form is the same type
                if (form.GetType() == formType)
                {
                    // Call the RefreshData method
                    var refreshMethod = formType.GetMethod("RefreshData", BindingFlags.Public | BindingFlags.Instance);
                    refreshMethod?.Invoke(form, null);
                }
            }
        }
    }
}
