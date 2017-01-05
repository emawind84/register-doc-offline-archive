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

        private ArchiveMainForm mainForm;
        private RegisterDocumentDataService registerService;
        private ReviewInfoDataService reviewInfoService;
        private Dictionary<string, string> languages;

        public event EventHandler SettingChanged;

        delegate void ChangeButtonStateCallback(object sender = null, EventArgs args = null);
        delegate void ChangeErrorMessage(object sender, ErrorEventArgs args);

        public SettingForm()
        {
            InitializeComponent();
            
        }

        public SettingForm(Form mainForm, 
            RegisterDocumentDataService registerService, ReviewInfoDataService reviewInfoService)
        {
            InitializeComponent();

            this.mainForm = mainForm as ArchiveMainForm;
            this.registerService = registerService;
            this.reviewInfoService = reviewInfoService;

            //this.registerService.ImportErrorHandler += ShowImportErrorMessage;
            this.registerService.ImportCompleteHandler += EnableImportRegisterDataButton;

            //this.reviewInfoService.ImportErrorHandler += ShowImportErrorMessage;
            this.reviewInfoService.ImportCompleteHandler += EnableImportReviewDataButton;

            //this.mainForm.DaoService.OnInitializationError += ShowSQLiteErrorMessage;

            languages = new Dictionary<string, string> {
                { "en_US", "English" },
                { "ko_KR", "Korean" }
            };
            settingLanguage.DataSource = new BindingSource(languages, null);
            settingLanguage.DisplayMember = "Value";
            settingLanguage.ValueMember = "Key";

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
            Properties.Settings.Default.db_type = settingDbType.Text;
            Properties.Settings.Default.language = settingLanguage.SelectedValue.ToString();

            Properties.Settings.Default.register_status.Clear();
            Properties.Settings.Default.register_status.Add("");
            foreach (var line in docStatusesTextBox.Lines)
            {
                if(!String.IsNullOrEmpty(line))
                    Properties.Settings.Default.register_status.Add(line);
            }

            Properties.Settings.Default.register_discipline.Clear();
            Properties.Settings.Default.register_discipline.Add("");
            foreach (var line in docDisciplinesTextBox.Lines)
            {
                if (!String.IsNullOrEmpty(line))
                    Properties.Settings.Default.register_discipline.Add(line);
            }

            Properties.Settings.Default.register_type.Clear();
            Properties.Settings.Default.register_type.Add("");
            foreach (var line in docTypesTextBox.Lines)
            {
                if (!String.IsNullOrEmpty(line))
                    Properties.Settings.Default.register_type.Add(line);
            }

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            if (SettingChanged != null)
                SettingChanged(this, EventArgs.Empty);

        }

        private void ShowImportErrorMessage(object sender, ErrorEventArgs args)
        {
            //if (this.pmisWsErrorMessage.InvokeRequired)
            //{
            //    ChangeErrorMessage d = ShowImportErrorMessage;
            //    this.Invoke(d, new object[] { sender, args });
            //}
            //else
            //{
            //    pmisWsErrorMessage.Text = args.GetException().Message;
            //}
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

        private void ShowSQLiteErrorMessage(object sender, ErrorEventArgs args)
        {
            //this.settingDbErrorMessage.Text = args.GetException().Message;
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

        private void connectDatabaseButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
                mainForm.DaoService.Open();
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

        private void SettingForm_Load(object sender, EventArgs e)
        {
            productInfoLabel.Text = string.Format("{0} - Version {1}", Application.ProductName, Application.ProductVersion);
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
    }
}
