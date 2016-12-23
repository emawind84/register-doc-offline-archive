using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pmis
{
    public partial class SettingForm : Form
    {

        private RegisterDocumentMainForm mainForm;
        private RegisterDocumentDataService registerService;
        private ReviewInfoDataService reviewInfoService;

        public event EventHandler SettingChanged;

        public SettingForm()
        {
            InitializeComponent();
            
        }

        public SettingForm(Form mainForm, 
            RegisterDocumentDataService registerService, ReviewInfoDataService reviewInfoService)
        {
            InitializeComponent();

            this.mainForm = mainForm as RegisterDocumentMainForm;
            this.registerService = registerService;
            this.reviewInfoService = reviewInfoService;

            this.registerService.ImportErrorHandler += ImportErrorHandler;
            this.reviewInfoService.ImportErrorHandler += ImportErrorHandler;

            LoadSettings();
        }

        public void LoadSettings(object sender = null, EventArgs e = null)
        {
            settingPmisWsProjectCode.Text = Properties.Settings.Default.pmis_project_code;
            settingPmisWsUrl.Text = Properties.Settings.Default.pmis_api_url;
            settingPmisWsAuthKey.Text = Properties.Settings.Default.pmis_auth_key;
            settingDbType.Text = Properties.Settings.Default.db_type;
            settingSQLiteDbLocation.Text = Properties.Settings.Default.sqlite_db_location;
            settingRegisterFolderURI.Text = Properties.Settings.Default.register_folder_uri;

            foreach (var opt in Properties.Settings.Default.register_status)
            {
                documentStatusOptions.Text += opt + Environment.NewLine;
            }

            foreach (var opt in Properties.Settings.Default.register_discipline)
            {
                documentDisciplineOptions.Text += opt + Environment.NewLine;
            }

            foreach (var opt in Properties.Settings.Default.register_type)
            {
                documentTypeOptions.Text += opt + Environment.NewLine;
            }

        }

        public void SaveSettings(object sender = null, EventArgs e = null)
        {
            Console.WriteLine("Saving settings...");
            Properties.Settings.Default.pmis_project_code = settingPmisWsProjectCode.Text;
            Properties.Settings.Default.pmis_api_url = settingPmisWsUrl.Text;
            Properties.Settings.Default.pmis_auth_key = settingPmisWsAuthKey.Text;
            Properties.Settings.Default.register_folder_uri = settingRegisterFolderURI.Text;
            Properties.Settings.Default.sqlite_db_location = settingSQLiteDbLocation.Text;
            Properties.Settings.Default.db_type = settingDbType.Text;

            Properties.Settings.Default.register_status.Clear();
            foreach (var line in documentStatusOptions.Text
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                Console.WriteLine(line);
                Properties.Settings.Default.register_status.Add(line);
            }

            Properties.Settings.Default.Save();

            if(SettingChanged != null)
            {
                SettingChanged(this, EventArgs.Empty);
            }
        }

        private void ImportErrorHandler(object sender, ErrorEventArgs args)
        {
            pmisWsErrorMessage.Text = args.GetException().Message;
        }

        private void importRegisterDataButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            registerService.DeleteRegisterData();

            Thread oThread = new Thread(new ThreadStart(registerService.ImportFromWebService));
            oThread.Start();
        }

        private void importReviewDataButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            reviewInfoService.DeleteReviewInfo();

            Thread oThread = new Thread(new ThreadStart(reviewInfoService.ImportFromWebService));
            oThread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void connectDatabaseButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            mainForm.SQLiteDaoService.ConnectDatabase();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveSettings();

            this.Hide();
        }
    }
}
