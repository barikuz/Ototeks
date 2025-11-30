using DevExpress.Skins;
using DevExpress.UserSkins;
using Ototeks.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Ototeks
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // 1. Grid Tercümanı
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new TurkishGridLocalizer();

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("WXI");
            Application.Run(new Form1());
        }
    }
}
