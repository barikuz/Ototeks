using System;
using System.IO;

namespace Ototeks.DataAccess.Concrete;

/// <summary>
/// Provides the resolved database file path under the user's AppData\Roaming folder.
/// </summary>
public static class DatabaseHelper
{
    private const string ApplicationFolder = "Ototechstil";
    private const string DatabaseFileName = "OtotechstilDB.db";

    /// <summary>
    /// Returns the full path to the SQLite database file.
    /// e.g. C:\Users\{User}\AppData\Roaming\Ototechstil\OtotechstilDB.db
    /// </summary>
    public static string GetDatabasePath()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var appFolder = Path.Combine(appDataPath, ApplicationFolder);
        return Path.Combine(appFolder, DatabaseFileName);
    }

    /// <summary>
    /// Ensures the application data folder exists. Creates it if it doesn't.
    /// </summary>
    /// <exception cref="IOException">Thrown when the folder cannot be created.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when the user lacks permissions.</exception>
    public static void EnsureApplicationFolderExists()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var appFolder = Path.Combine(appDataPath, ApplicationFolder);

        if (!Directory.Exists(appFolder))
        {
            Directory.CreateDirectory(appFolder);
        }
    }

    /// <summary>
    /// Returns the SQLite connection string pointing to the AppData database file.
    /// </summary>
    public static string GetConnectionString()
    {
        return $"Data Source={GetDatabasePath()}";
    }
}
