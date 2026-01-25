using DevExpress.Skins;
using DevExpress.UserSkins;
using Ototeks.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Ototeks.UI.Helpers;
using Ototeks.DataAccess.Concrete;

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
            
            // Veritabanını başlat (yoksa oluştur)
            InitializeDatabase();
            
            // 1. Grid Tercümanı
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new TurkishGridLocalizer();

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("WXI");
            Application.Run(new Form1());
        }

        /// <summary>
        /// SQLite veritabanını başlatır. Veritabanı dosyası yoksa oluşturur.
        /// </summary>
        private static void InitializeDatabase()
        {
            try
            {
                using var context = new OtoteksContext();
                // Veritabanını ve tabloları oluştur (yoksa)
                context.Database.EnsureCreated();
                
                // Varsayılan verileri ekle (eğer yoksa)
                SeedDefaultData(context);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı başlatılırken hata oluştu:\n{ex.Message}", 
                    "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Varsayılan verileri ekler (hata türleri, vb.)
        /// </summary>
        private static void SeedDefaultData(OtoteksContext context)
        {
            // Varsayılan hata türlerini ekle
            if (!context.DefectTypes.Any())
            {
                context.DefectTypes.AddRange(
                    new Entities.DefectType { DefectName = "DefectFree" },
                    new Entities.DefectType { DefectName = "BrokenStitch" },
                    new Entities.DefectType { DefectName = "Hole" },
                    new Entities.DefectType { DefectName = "WeavingError" },
                    new Entities.DefectType { DefectName = "Stain" }
                );
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new Entities.User { Username = "admin" , Password = "12345", Role = "Admin"}

                );
                context.SaveChanges();
            }
        }
    }
}
