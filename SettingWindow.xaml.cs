using pmis.i18n;
using pmis.reviewinfo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace pmis
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {

        private RegisterDocumentDataService registerService;
        private ReviewInfoDataService reviewInfoService;

        public event EventHandler SettingChanged;

        // sqlite module
        private SQLiteDaoService sqliteDaoService;
        public SQLiteDaoService SQLiteDaoService
        {
            set
            {
                this.sqliteDaoService = value;
                this.sqliteDaoService.DatabaseInitialized += UpdateDataCount;
                this.sqliteDaoService.DatabaseInitialized += UpdateDBInfo;
            }
        }

        delegate void ChangeErrorMessage(object sender, ErrorEventArgs args);
        delegate void EventCallback(object sender = null, EventArgs args = null);

        public SettingWindow()
        {
            InitializeComponent();
        }

        public SettingWindow(RegisterDocumentDataService registerService, ReviewInfoDataService reviewInfoService)
        {
            InitializeComponent();
            
            this.registerService = registerService;
            this.reviewInfoService = reviewInfoService;

            this.registerService.ImportComplete += EnableImportRegisterDataButton;
            this.reviewInfoService.ImportComplete += EnableImportReviewDataButton;

            settingLanguage.ItemsSource = new BindingSource(AppConfig.Languages, null);
            settingLanguage.DisplayMemberPath = "Value";
            settingLanguage.SelectedValuePath = "Key";

            settingDbType.ItemsSource = new BindingSource(AppConfig.StorageOptions, null);
            settingDbType.DisplayMemberPath = "Value";
            settingDbType.SelectedValuePath = "Key";

            registerService.RegisterDocumentImported += LogRegisterImportedData;
            registerService.RegisterDocumentImported += UpdateDataCount;
            reviewInfoService.ReviewInfoImported += LogReviewImportedData;
            reviewInfoService.ReviewInfoImported += UpdateDataCount;

            IsVisibleChanged += (s, Nullable) => {
                LoadSettings();
            };

            try
            {
                LoadLanguage();

                LoadSettings();

                UpdateDataCount();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
                return;
            }
        }

        private void LoadLanguage(object sender = null, EventArgs args = null)
        {
            LanguageSupport i18n = new LanguageSupport();
            i18n.SetSettingFormLanguage(this);
        }

        public void LoadSettings(object sender = null, EventArgs e = null)
        {
            currentProfile.Text = String.Format("Current Profile: {0}", Properties.Settings.Default.current_profile);
            productInfoLabel.Text = string.Format("{0} - {1}", System.Windows.Forms.Application.ProductName, AppConfig.AssemblyVersion);

            settingPmisWsProjectCode.Text = Properties.Settings.Default.pmis_project_code;
            settingPmisWsUrl.Text = Properties.Settings.Default.pmis_api_url;
            settingDbType.SelectedValue = Properties.Settings.Default.db_type;
            settingSQLiteDbLocation.Text = Properties.Settings.Default.sqlite_db_location;
            settingRegisterFolderURI.Text = Properties.Settings.Default.register_folder_uri;
            settingPictureFolderURI.Text = Properties.Settings.Default.picture_folder_uri;
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

            UpdateDBInfo();
        }

        public void SaveSettings(object sender = null, EventArgs e = null)
        {
            LogUtil.Log("Saving settings...");
            Properties.Settings.Default.pmis_project_code = settingPmisWsProjectCode.Text;
            Properties.Settings.Default.pmis_api_url = settingPmisWsUrl.Text;
            Properties.Settings.Default.pmis_auth_key = settingPmisWsAuthKey.Text;
            Properties.Settings.Default.register_folder_uri = settingRegisterFolderURI.Text;
            Properties.Settings.Default.picture_folder_uri = settingPictureFolderURI.Text;
            Properties.Settings.Default.sqlite_db_location = settingSQLiteDbLocation.Text;
            Properties.Settings.Default.db_type = settingDbType.SelectedValue as string;
            Properties.Settings.Default.language = settingLanguage.SelectedValue as string;

            Properties.Settings.Default.register_status.Clear();
            foreach (var line in docStatusesTextBox.Text.Lines())
            {
                if (!String.IsNullOrEmpty(line))
                    Properties.Settings.Default.register_status.Add(line);
            }

            Properties.Settings.Default.register_discipline.Clear();
            foreach (var line in docDisciplinesTextBox.Text.Lines())
            {
                if (!String.IsNullOrEmpty(line))
                    Properties.Settings.Default.register_discipline.Add(line);
            }

            Properties.Settings.Default.register_type.Clear();
            foreach (var line in docTypesTextBox.Text.Lines())
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
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void LogImportMessage(string message)
        {
            if (importLogViewer.Dispatcher.CheckAccess())
            {
                if (importLogViewer.Text.Lines().Length > 10)
                    importLogViewer.Text = "";
                importLogViewer.Text += (message + Environment.NewLine);
            }
            else {
                importLogViewer.Dispatcher.Invoke(new Action<string>(LogImportMessage), message);
            }
        }

        private void EnableImportReviewDataButton(object sender = null, EventArgs args = null)
        {
            if (!this.importReviewDataButton.Dispatcher.CheckAccess())
            {
                EventCallback d = EnableImportReviewDataButton;
                this.importReviewDataButton.Dispatcher.Invoke(d, new object[] { null, null });
            }
            else {
                importReviewDataButton.IsEnabled = true;
            }
        }

        private void EnableImportRegisterDataButton(object sender, EventArgs args)
        {
            if (!this.importRegisterDataButton.Dispatcher.CheckAccess())
            {
                EventCallback d = EnableImportRegisterDataButton;
                this.importRegisterDataButton.Dispatcher.Invoke(d, new object[] { null, null });
            }
            else {
                importRegisterDataButton.IsEnabled = true;
            }
        }

        private void UpdateDataCount(object sender = null, object empty = null)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                EventCallback d = UpdateDataCount;
                this.Dispatcher.Invoke(d, new object[] { null, null });
            }
            else
            {
                this.settingsDocumentCount.Text = registerService.LoadRegisterCount().ToString();
                this.settingsReviewCount.Text = reviewInfoService.LoadReviewCount().ToString();
            }
        }

        private void UpdateDBInfo(object sender=null, object empty=null)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                EventCallback d = UpdateDBInfo;
                this.Dispatcher.Invoke(d, new object[] { null, null });
            }
            else
            {
                if(sqliteDaoService != null && sqliteDaoService.IsOpen()){
                    settingDBConnectionInfo.Text = String.Format("Connected to {0}.", sqliteDaoService.DatabaseFilePath);
                } else
                {
                    settingDBConnectionInfo.Text = String.Format("Not connected.");
                }
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

        private void connectSQLiteDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveSettings();
                sqliteDaoService.DatabaseFilePath = Properties.Settings.Default.sqlite_db_location;
                sqliteDaoService.Open();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void settingsOkButton_Click(object sender, RoutedEventArgs e)
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

        private void settingsCancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void importRegisterDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                importRegisterDataButton.IsEnabled = false;
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

        private void importReviewDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                importReviewDataButton.IsEnabled = false;
                SaveSettings();

                reviewInfoService.DeleteReviewInfo();

                Thread oThread = new Thread(new ThreadStart(reviewInfoService.ImportFromWebService));
                oThread.Start();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void sqliteFileLocationButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = AppConfig.AppDataFullPath;
            dialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(dialog.FileName))
                settingSQLiteDbLocation.Text = dialog.FileName;
        }

        private void registerFolderURIButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(dialog.SelectedPath))
                settingRegisterFolderURI.Text = dialog.SelectedPath;
        }

        private void pictureFolderURIButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(dialog.SelectedPath))
                settingPictureFolderURI.Text = dialog.SelectedPath;
        }

        private void settingsResetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.Reset();
                LoadSettings();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //base.OnClosing(e);
            this.Hide();
            e.Cancel = true;
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var tokenRequestWindow = new TokenRequestWindow(settingPmisWsUrl.Text);
                tokenRequestWindow.AfterRequestComplete += (s, token) => {
                    settingPmisWsAuthKey.Text = token;
                    tokenRequestWindow.Close();
                };
                tokenRequestWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }
    }
}
