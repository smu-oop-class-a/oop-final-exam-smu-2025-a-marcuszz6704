using System.IO;

namespace OOP.FinalTerm.Exam.Utils
{
  
    public static class DatabaseHelper
    {
        
        private static string GetDatabaseFolder()
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string databaseFolder = Path.Combine(projectDirectory, "Database");

         
            if (!Directory.Exists(databaseFolder))
            {
                Directory.CreateDirectory(databaseFolder);
            }

            return databaseFolder;
        }

    
        public static string GetDatabasePath()
        {
            return Path.Combine(GetDatabaseFolder(), "nitpleks.db");
        }
    }
}