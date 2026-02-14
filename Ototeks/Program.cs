using DevExpress.Skins;
using DevExpress.UserSkins;
using Ototeks.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
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
            
            // Initialize the database (create if it doesn't exist)
            InitializeDatabase();

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("WXI");
            Application.Run(new Form1());
        }

        /// <summary>
        /// Initializes the SQLite database. Creates the application folder and database file if they don't exist.
        /// Database is stored in: %APPDATA%\Ototechstil\OtotechstilDB.db
        /// </summary>
        private static void InitializeDatabase()
        {
            try
            {
                // Ensure the AppData application folder exists
                DatabaseHelper.EnsureApplicationFolderExists();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to create application data folder:\n{ex.Message}\n\nDatabase path: {DatabaseHelper.GetDatabasePath()}",
                    "Folder Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using var context = new OtoteksContext();
                // Create database and tables (if they don't exist)
                context.Database.EnsureCreated();

                // Add default data (if it doesn't exist)
                SeedDefaultData(context);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error initializing database:\n{ex.Message}\n\nDatabase path: {DatabaseHelper.GetDatabasePath()}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Adds default seed data (defect types, etc.)
        /// </summary>
        private static void SeedDefaultData(OtoteksContext context)
        {
            // Add default defect types
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
