using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro
{
    public class AppSettings
    {
        public static string DatabaseName = "database.db";
        public static string DatabaseDiectory = FileSystem.AppDataDirectory;
        public static string DatabasePath = Path.Combine(DatabaseDiectory, DatabaseName);
    }
}
