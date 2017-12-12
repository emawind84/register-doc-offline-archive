using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Reflection;

namespace pmis
{
    public static class AppConfig
    {

        //private static string appDataName = ".pmis-archive";
        public static LanguageService i18n;

        private static string appDataFullPath;
        public static string AppDataFullPath { get { return appDataFullPath; } }

        private static bool backupAndOverrideData = true;

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

            // set the log root folder
            LogUtil.LogRootFolder = Path.Combine(AppDataFullPath, "logs");

            i18n = new LanguageService(Properties.Settings.Default.language);

            // create user app folders
            Directory.CreateDirectory(AppDataFullPath);
            Directory.CreateDirectory(Path.Combine(AppDataFullPath, "backups"));
            Directory.CreateDirectory(Path.Combine(AppDataFullPath, "data"));

            // create data folder in user app folder (%appdata% directory)
            //DirectoryInfo userDataDir = new DirectoryInfo(Path.Combine(AppDataFullPath, "data"));
            //if (!userDataDir.Exists)
            //{
            //    userDataDir.Create();
            //}

            DirectoryInfo dataDir = new DirectoryInfo("data");  // this is the data directory inside the application folder
            try
            {
                FileInfo[] files = dataDir.GetFiles();
                foreach (FileInfo file in files)
                {
                    CopyDataFile(file.FullName);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                //ex.Log()
                LogUtil.Log("Setup data folder missing, skipping data copy.");
            }
            
        }

        private static void CopyDataFile(string filepath)
        {
            DirectoryInfo userDataDir = new DirectoryInfo(Path.Combine(AppDataFullPath, "data"));
            FileInfo file = new FileInfo(filepath);
            string temppath = Path.Combine(userDataDir.FullName, file.Name);
            if (backupAndOverrideData
                && File.Exists(temppath) 
                && File.GetLastWriteTime(temppath) < file.LastWriteTime)
            {
                File.Move(temppath, Path.Combine(AppDataFullPath, "backups", file.Name + DateTime.Now.ToString(".yyyyMMddHHmmss")));
            }

            if (File.GetLastWriteTime(temppath) < file.LastWriteTime)
            {
                file.CopyTo(temppath, backupAndOverrideData);
            }
        }

        #region Application Attribute Accessors

        public static string PublishVersion
        {
            get {
                if (ApplicationDeployment.IsNetworkDeployed) {
                    return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
                }
                return "N/A";
            }
        }

        #endregion

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
