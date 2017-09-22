using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace pmis
{
    public static class AppConfig
    {

        //private static string appDataName = ".pmis-archive";
        public static LanguageService i18n;

        private static string appDataFullPath;
        public static string AppDataFullPath { get { return appDataFullPath; } }

        public static Dictionary<string, string> Languages = new Dictionary<string, string> {
            { "en_US", "English" },
            { "ko_KR", "Korean" }
        };

        public static Dictionary<string, string> StorageOptions = new Dictionary<string, string>
        {
            { "sqlite", "SQLite" }
        };

        public static string HISTORY_SHOW_ALL = "show_all";
        public static string HISTORY_LATEST = "last_revision";
        public static Dictionary<string, string> RegisterHistoryOptions = new Dictionary<string, string>
        {
            { HISTORY_SHOW_ALL, "Show All Revisions" },
            { HISTORY_LATEST, "Latest Revision Only" }
        };

        public static void InitConfig()
        {
            var _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appDataFullPath = Path.Combine(_path, ".pmis-archive");

            // create user app folder
            if (!Directory.Exists(AppDataFullPath))
                Directory.CreateDirectory(AppDataFullPath);

            // create data folder in user app folder
            DirectoryInfo userDataDir = new DirectoryInfo(Path.Combine(AppDataFullPath, "data"));
            if (!userDataDir.Exists)
            {
                userDataDir.Create();
            }

            DirectoryInfo dataDir = new DirectoryInfo("data");
            FileInfo[] files = dataDir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(userDataDir.FullName, file.Name);
                if (!File.Exists(temppath))
                {
                    file.CopyTo(temppath, false);
                }
            }

            // set the log root folder
            LogUtil.LogRootFolder = Path.Combine(AppDataFullPath, "logs");

            i18n = new LanguageService(Properties.Settings.Default.language);
        }


        #region Assembly Attribute Accessors

        public static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public static string AssemblyVersion
        {
            get
            {
                //return Assembly.GetExecutingAssembly().GetName().Version.ToString();
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyFileVersionAttribute)attributes[0]).Version;
            }
        }

        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

    }
}
