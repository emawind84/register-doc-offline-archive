using pmis.reviewinfo;
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

        private RegisterDocumentDataService registerService;
        private ReviewInfoDataService reviewInfoService;

        // sqlite module
        public SQLiteDaoService SQLiteDaoService;

        public event EventHandler SettingChanged;

        delegate void ChangeButtonStateCallback(object sender = null, EventArgs args = null);
        delegate void ChangeErrorMessage(object sender, ErrorEventArgs args);

        public SettingForm()
        {
            InitializeComponent();
            
        }

        public SettingForm(RegisterDocumentDataService registerService, ReviewInfoDataService reviewInfoService)
        {
            InitializeComponent();

            this.registerService = registerService;
            this.reviewInfoService = reviewInfoService;

            this.registerService.ImportComplete += EnableImportRegisterDataButton;
            this.reviewInfoService.ImportComplete += EnableImportReviewDataButton;

            settingLanguage.DataSource = new BindingSource(AppConfig.Languages, null);
            settingLanguage.DisplayMember = "Value";
            settingLanguage.ValueMember = "Key";

            settingDbType.DataSource = new BindingSource(AppConfig.StorageOptions, null);
            settingDbType.DisplayMember = "Value";
            settingDbType.ValueMember = "Key";

            registerService.RegisterDocumentImported += LogRegisterImportedData;
            reviewInfoService.ReviewInfoImported += LogReviewImportedData;

            productInfoLabel.Text = string.Format("{0} - Build {1}", Application.ProductName, AppConfig.ProductVersion);

            openFileDialog.InitialDirectory = AppConfig.AppDataFullPath;

            LoadSettings();
        }

        public void LoadSettings(object sender = null, EventArgs e = null)
        {
            settingPmisWsProjectCode.Text = Properties.Settings.Default.pmis_project_code;
            settingPmisWsUrl.Text = Properties.Settings.Default.pmis_api_url;
            settingPmisWsAuthKey.Text = Properties.Settings.Default.pmis_auth_key;
            settingDbType.SelectedValue = Properties.Settings.Default.db_type;
            settingSQLiteDbLocation.Text = Properties.Settings.Default.sqlite_db_location;
            settingRegisterFolderURI.Text = Properties.Settings.Default.register_folder_uri;
            settingLanguage.SelectedValue = Properties.Settings.Default.language;

            StringBuilder strbuilder = new StringBuilder();
            foreach (var opt in Properties.Settings.Default.register_status)
            {
                strbuilder.AppendLine(opt);
            }
            docStatusesTextBox.Text = strbuilder.ToString();

            strbuilder = new StringBuilder();
            foreach (var opt in Properties.Settings.Default.register_discipline)
            {
                strbuilder.AppendLine(opt);
            }
            docDisciplinesTextBox.Text = strbuilder.ToString();

            strbuilder = new StringBuilder();
            foreach (var opt in Properties.Settings.Default.register_type)
            {
                strbuilder.AppendLine(opt);
            }
            docTypesTextBox.Text = strbuilder.ToString();
            
        }

        public void SaveSettings(object sender = null, EventArgs e = null)
        {
            LogUtil.Log("Saving settings...");
            Properties.Settings.Default.pmis_project_code = settingPmisWsProjectCode.Text;
            Properties.Settings.Default.pmis_api_url = settingPmisWsUrl.Text;
            Properties.Settings.Default.pmis_auth_key = settingPmisWsAuthKey.Text;
            Properties.Settings.Default.register_folder_uri = settingRegisterFolderURI.Text;
            Properties.Settings.Default.sqlite_db_location = settingSQLiteDbLocation.Text;
            Properties.Settings.Default.db_type = settingDbType.SelectedValue as string;
            Properties.Settings.Default.language = settingLanguage.SelectedValue as string;

            Properties.Settings.Default.register_status.Clear();
            foreach (var line in docStatusesTextBox.Lines)
            {
                if(!String.IsNullOrEmpty(line))
                    Properties.Settings.Default.register_status.Add(line);
            }

            Properties.Settings.Default.register_discipline.Clear();
            foreach (var line in docDisciplinesTextBox.Lines)
            {
                if (!String.IsNullOrEmpty(line))
                    Properties.Settings.Default.register_discipline.Add(line);
            }

            Properties.Settings.Default.register_type.Clear();
            foreach (var line in docTypesTextBox.Lines)
            {
                if (!String.IsNullOrEmpty(line))
                    Properties.Settings.Default.register_type.Add(line);
            }

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            OnSettingChanged(EventArgs.Empty);
        }

        protected virtual void OnSettingChanged(EventArgs e)
        {
            EventHandler handler = SettingChanged;
            if(handler != null)
            {
                handler(this, e);
            }
        }

        private void LogImportMessage(string message)
        {
            if (!importLogViewer.InvokeRequired)
            {
                if (importLogViewer.Lines.Length > 10)
                    importLogViewer.Clear();
                importLogViewer.AppendText(message + Environment.NewLine);
            }
            else {
                Invoke(new Action<string>(LogImportMessage), message);
            }
        }

        private void EnableImportReviewDataButton(object sender = null, EventArgs args = null)
        {
            if (this.importReviewDataButton.InvokeRequired)
            {
                ChangeButtonStateCallback d = EnableImportReviewDataButton;
                this.Invoke(d, new object[] { null, null });
            }
            else {
                importReviewDataButton.Enabled = true;
            }
        }

        private void EnableImportRegisterDataButton(object sender, EventArgs args)
        {
            if (this.importRegisterDataButton.InvokeRequired)
            {
                ChangeButtonStateCallback d = EnableImportRegisterDataButton;
                this.Invoke(d, new object[] { null, null });
            }
            else {
                importRegisterDataButton.Enabled = true;
            }
            
        }

        private void LogRegisterImportedData(object sender, RegisterDocument d)
        {
            LogImportMessage(String.Format("Imported {0}", d.ToString()));
        }

        private void LogReviewImportedData(object sender, ReviewInfo d)
        {
            LogImportMessage(String.Format("Imported {0}", d.ToString()));
        }

        private void importRegisterDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                importRegisterDataButton.Enabled = false;
                SaveSettings();

                registerService.DeleteRegisterData();

                Thread oThread = new Thread(new ThreadStart(registerService.ImportFromWebService));
                oThread.Start();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void importReviewDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                importReviewDataButton.Enabled = false;
                SaveSettings();

                reviewInfoService.DeleteReviewInfo();

                Thread oThread = new Thread(new ThreadStart(reviewInfoService.ImportFromWebService));
                oThread.Start();
            }
            catch(Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void connectSQLiteDatabaseButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
                SQLiteDaoService.DatabaseFilePath = Properties.Settings.Default.sqlite_db_location;
                SQLiteDaoService.Open();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
                this.Hide();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void registerLocationButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();

            if(!string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                settingRegisterFolderURI.Text = folderBrowserDialog.SelectedPath;
        }

        private void sqliteFileLocationButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                settingSQLiteDbLocation.Text = openFileDialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Reset();
                LoadSettings();
            } catch(Exception ex)
            {
                ex.Log().Display();
            }
        }
    }
}
