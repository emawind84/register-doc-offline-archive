﻿using pmis.clss;
using pmis.archive;
using pmis.i18n;
using pmis.profile;
using pmis.register;
using pmis.reviewinfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace pmis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SettingWindow settingForm;
        private IDbConnection daoService;
        private RegisterDocumentDetailView registerDocumentDetailView;
        private ReviewInfoPresenter reviewInfoPresenter;
        private ReviewInfoDataService reviewInfoDataService;
        private ClssService clssService;
        private BindingSource fileManagerBS;
        private BindingSource reviewFilesBS;
        private PicturePresenter picturePresenter;
        private PictureViewerService pictureViewerService;
        private ObservableCollection<Profile> profileListMenuItems = new ObservableCollection<Profile>();
        private ArchiveDataService archiveDataService;

        public event EventHandler OnShowRegisterDocumentInfo;
        public event EventHandler OnShowRegisterDocumentList;
        public event EventHandler OnShowArchiveList;
        public event EventHandler OnShowArchiveInfo;

        public RegisterDocumentDetailView RegisterDocumentDetailView => this.registerDocumentDetailView;

        public IDbConnection DaoService => daoService;

        public string ApplicationTitle => AppConfig.AssemblyProduct;

        public string SearchCriteriaDocNumber
        {
            get { return srchNumber.Text; }
            set { srchNumber.Text = value; }
        }

        public string SearchCriteriaTitle
        {
            get { return srchTitle.Text; }
            set { srchTitle.Text = value; }
        }

        public DateTime? SearchCriteriaFromDate {
            get {
                return srchFromDate.SelectedDate;
            }
            set { srchFromDate.SelectedDate = value; }
        }

        public DateTime? SearchCriteriaToDate {
            get {
                return srchToDate.SelectedDate;
            }
            set { srchToDate.SelectedDate = value; }
        }

        public string SearchCriteriaStatus
        {
            get { return srchStatus.Text; }
            set { srchStatus.Text = value; }
        }

        public string SearchCriteriaDiscipline
        {
            get { return srchDiscipline.Text; }
            set { srchDiscipline.Text = value; }
        }

        public string SearchCriteriaType
        {
            get { return srchType.SelectedValue?.ToString(); }
            set { srchType.SelectedValue = value; }
        }

        public string SearchCriteriaAllHistory { get { return srchHistory.Text; } }

        public string SearchCriteriaRegisteredBy {
            get { return srchRegisteredBy.Text; }
            set { srchRegisteredBy.Text = value; }
        }

        public string SearchCriteriaArchiveFullSearch { get { return archiveFullSearchValue.Text;  } }

        public string SearchCriteriaArchiveFilterType { get { return archiveFilterTypeCombo.Text; } }

        public ImageSource ImageBox
        {
            set
            {
                this.pictureBox1.Source = value;
            }
        }

        public IEnumerable DocumentList
        {
            set { registerDataGridView.ItemsSource = value; }
        }

        public IEnumerable ArchiveList
        {
            set { archiveDataGridView.ItemsSource = value; }
        }

        public IEnumerable ReviewInfoList
        {
            set { reviewDataGridView.ItemsSource = value; }
        }

        public object RegisterFilesDS
        {
            get { return fileManagerBS.DataSource; }
            set { fileManagerBS.DataSource = value; }
        }

        public object ReviewFilesDS
        {
            get { return reviewFilesBS.DataSource; }
            set { reviewFilesBS.DataSource = value; }
        }

        public IEnumerable PictureFilesDS
        {
            set { pictureGridView.ItemsSource = value; }
        }

        public IEnumerable PictureDirectoriesDS
        {
            set {
                pictureFolderListBox.ItemsSource = value;
            }
        }

        public ObservableCollection<Profile> ProfileListMenuItems => profileListMenuItems;

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            try
            {
                daoService = new SQLiteDaoService(Properties.Settings.Default.sqlite_db_location);
                // open db connection before doing anything else
                daoService.Open();

                RegisterDocumentDataService registerDocumentDataService = new RegisterDocumentDataService(daoService as IRegisterDocumentDao);
                RegisterDocumentPresenter registerDocumentPresenter = new RegisterDocumentPresenter(this, registerDocumentDataService);
                registerDocumentDetailView = new RegisterDocumentDetailView(this);
                registerDataGridView.CanUserAddRows = false;
                registerDataGridView.AutoGenerateColumns = false;

                ReviewInfoDataService reviewInfoDataService = new ReviewInfoDataService(daoService as IReviewInfoDao);
                ReviewInfoPresenter reviewInfoPresenter = new ReviewInfoPresenter(this, reviewInfoDataService, registerDocumentDataService);
                reviewDataGridView.AutoGenerateColumns = false;
                reviewDataGridView.CanUserAddRows = false;

                archiveDataService = new ArchiveDataService(daoService as IArchiveDataDao);
                ArchivePresenter archivePresenter = new ArchivePresenter(this, archiveDataService);
                archiveDataGridView.AutoGenerateColumns = false;
                archiveDataGridView.CanUserAddRows = false;

                clssService = new ClssService(daoService as IClssDao);
                clssService.ImportComplete += LoadSearchOptions;
                daoService.DatabaseInitialized += UpdateClssData;  // update clss on new db connection

                reviewFilesBS = new BindingSource();
                reviewFilesBS.DataSource = new List<RegisterFile>();
                reviewFilesBS.AllowNew = false;
                reviewFileDataGrid.AutoGenerateColumns = false;
                reviewFileDataGrid.ItemsSource = reviewFilesBS;

                fileManagerBS = new BindingSource();
                fileManagerBS.DataSource = new List<RegisterFile>();
                fileManagerBS.AllowNew = false;
                fileManagerDataGridView.AutoGenerateColumns = false;
                fileManagerDataGridView.ItemsSource = fileManagerBS;

                srchHistory.ItemsSource = new BindingSource(AppConfig.RegisterHistoryOptions, null);
                srchHistory.DisplayMemberPath = "Value";
                srchHistory.SelectedValuePath = "Key";
                srchHistory.SelectedValue = AppConfig.HISTORY_LATEST;

                settingForm = new SettingWindow(
                    registerDocumentDataService,
                    reviewInfoDataService,
                    archiveDataService);

                // adding sqlite module to setting form
                settingForm.SQLiteDaoService = daoService as SQLiteDaoService;

                settingForm.SettingChanged += LoadSearchOptions;
                settingForm.SettingChanged += LoadPictureViewer;
                settingForm.SettingChanged += ShowArchiveList;
                settingForm.SettingChanged += LoadLanguage;
                settingForm.SettingChanged += ShowRegisterList;
                settingForm.SettingChanged += UpdateClssData;

                ProfileService.ProfileChanged += (profile) =>
                {
                    LoadSearchOptions();
                    LoadPictureViewer();
                    LoadLanguage();
                    ShowRegisterList();
                };

                LoadLanguage();

                // load search options
                LoadSearchOptions();

                // request docs list
                ShowRegisterList();

                // load picture viewer
                LoadPictureViewer();

                ShowArchiveList();

                LoadProfileMenuItems();
            }
            catch (Exception ex)
            {
                throw ex.Log().Display();
            }

        }

        private void LoadLanguage(object sender = null, EventArgs args = null)
        {
            LanguageSupport i18n = new LanguageSupport();
            i18n.SetMainFromLanguage(this);
        }

        private void LoadSearchOptions(object sender = null, EventArgs args = null)
        {
            try
            {
                string[] statuses = new string[Properties.Settings.Default.register_status.Count + 1];
                statuses[0] = "";
                Properties.Settings.Default.register_status.CopyTo(statuses, 1);
                srchStatus.ItemsSource = statuses;

                string[] disciplines = new string[Properties.Settings.Default.register_discipline.Count + 1];
                disciplines[0] = "";
                Properties.Settings.Default.register_discipline.CopyTo(disciplines, 1);
                srchDiscipline.ItemsSource = disciplines;

                DataTable dt = clssService.LoadClassificationList();  // load all clss
                dt.Rows.InsertAt(dt.NewRow(), 0);  // add a blank option at the bottom
                srchType.ItemsSource = dt.AsEnumerable();  // change to enumerable type
                srchType.SelectedIndex = 0;  // select the empty option

                string[] archiveTypes = new string[Properties.Settings.Default.archive_types.Count + 1];
                archiveTypes[0] = "";
                Properties.Settings.Default.archive_types.CopyTo(archiveTypes, 1);
                archiveFilterTypeCombo.ItemsSource = archiveTypes;
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void LoadPictureViewer(object sender = null, EventArgs args = null)
        {
            if (pictureViewerService == null)
            {
                //pictureFilesBS = new BindingSource();
                //pictureFilesBS.DataSource = 
                //pictureFilesBS.AllowNew = false;
                pictureGridView.AutoGenerateColumns = false;
                pictureGridView.ItemsSource = new List<RegisterFile>();

                pictureFolderListBox.Items.Clear();
                pictureFolderListBox.DisplayMemberPath = "Value";
                pictureFolderListBox.SelectedValuePath = "Key";

                pictureViewerService = new PictureViewerService();
                pictureViewerService.OnPictureSelected += SelectPictureFileOnSelection;

                picturePresenter = new PicturePresenter(this, pictureViewerService);
            }
            picturePresenter.LoadPictureDirectories();
        }

        private void ShowRegisterList(object sender = null, EventArgs args = null)
        {
            try
            {
                OnShowRegisterDocumentList?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void ShowArchiveList(object sender=null, EventArgs e=null)
        {
            try
            {
                OnShowArchiveList?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void SearchButtonClickHandler(object sender, EventArgs e)
        {
            try
            {
                ShowRegisterList();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            daoService.Close();
        }

        private void registerDataGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    var dgr = AppUtil.FindDataGridRow((DependencyObject)e.OriginalSource);
                    if (dgr != null)
                    {
                        DataRow dr = dgr.Item as DataRow;
                        this.registerDocumentDetailView.Number = Convert.ToString(dr["docno"]);
                        this.registerDocumentDetailView.Version = Convert.ToString(dr["doc_version"]);

                        OnShowRegisterDocumentInfo?.Invoke(this, EventArgs.Empty);

                        tabControl1.SelectedIndex = 1;
                    }
                }

                e.Handled = true;
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void fileManagerDataGridView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AppUtil.FileManagerOnSingleClick(sender, e);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowRegisterList();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void searchClearButton_Click(object sender, RoutedEventArgs e)
        {
            SearchCriteriaDiscipline = "";
            SearchCriteriaStatus = "";
            SearchCriteriaType = "";
            SearchCriteriaDocNumber = "";
            SearchCriteriaTitle = "";
            SearchCriteriaRegisteredBy = "";
            SearchCriteriaFromDate = null;
            SearchCriteriaToDate = null;
        }

        private void settingMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                settingForm.Owner = this;
                settingForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void fileManagerDataGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AppUtil.FileManagerOnDoubleClick(sender, e);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void pictureNextButtonOnClick(object sender, RoutedEventArgs e)
        {
            picturePresenter.NextImage();
        }

        private void picturePreviousButtonOnClick(object sender, RoutedEventArgs e)
        {
            picturePresenter.PreviousImage();
        }

        private void pictureGridView_CellClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DependencyObject dep = (DependencyObject)e.OriginalSource;
                // iteratively traverse the visual tree
                while ((dep != null)
                    && !(dep is System.Windows.Controls.DataGridCell))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }

                if (dep is System.Windows.Controls.DataGridCell)
                {
                    var cell = dep as System.Windows.Controls.DataGridCell;
                    // navigate further up the tree
                    while ((dep != null) && !(dep is DataGridRow))
                    {
                        dep = VisualTreeHelper.GetParent(dep);
                    }
                    DataGridRow row = dep as DataGridRow;
                    RegisterFile file = row.Item as RegisterFile;

                    picturePresenter.ShowImage(file);
                }
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void SelectPictureFileOnSelection(object sender, RegisterFile file)
        {
            var rows = AppUtil.GetDataGridRows(pictureGridView);
            foreach (var row in rows)
            {
                var _t = row.Item as RegisterFile;
                if (_t.FilePath.Equals(file.FilePath))
                {
                    var rowIndex = pictureGridView.ItemContainerGenerator.IndexFromContainer(row);
                    pictureGridView.SelectedIndex = rowIndex;
                    break;
                }
            }
        }

        private void pictureFolderListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (pictureFolderListBox.SelectedValue != null)
                {
                    picturePresenter.LoadPictureFiles(pictureFolderListBox.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void closeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var aboutForm = new AboutBox();
            aboutForm.Owner = this;
            aboutForm.ShowDialog();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            System.Windows.Application.Current.Shutdown();
        }

        private void archiveDataGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    System.Windows.Controls.DataGrid grid = sender as System.Windows.Controls.DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        DataRow dr = dgr.Item as DataRow;

                        ArchiveDetailWindow w = new ArchiveDetailWindow(archiveDataService, (string)dr["id"]);
                        w.Show();

                        if (OnShowArchiveInfo != null)
                        {
                            OnShowArchiveInfo(this, EventArgs.Empty);
                        }
                    }
                }

                e.Handled = true;
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void archiveSearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowArchiveList();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is System.Windows.Controls.TabControl)
            {
                var tabc = e.Source as System.Windows.Controls.TabControl;
                var tabItem = tabc.SelectedItem as TabItem;
                if (tabItem.Name == "")
                {

                }
            }
        }

        private void GoToOnlineHelp(object sender, RoutedEventArgs e)
        {
            try {
                Process.Start("https://github.com/sangahco/register-doc-offline-archive/blob/master/README.md");
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void NewProfileOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var window = new NewProfileWindow();
                window.AfterProfileCreated += (s, Nullable) => {
                    window.Close();
                    LoadProfileMenuItems();
                };
                window.ShowDialog();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void SaveProfileOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var profile = ProfileService.BuildCurrentProfile();
                ProfileService.SaveProfile(profile);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void LoadProfileOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var profileName = ((System.Windows.Controls.MenuItem)sender).Header as string;
                var profile = ProfileService.LoadProfile(profileName);
                ProfileService.ChangeProfile(profile);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void LoadProfileMenuItems() {
            profileListMenuItems.Clear();
            foreach (var profile in ProfileService.LoadProfiles())
            {
                profileListMenuItems.Add(profile);
            }
            if ( profileListMenuItems.Count > 0 )
            {
                ProfileListMenuItem.IsEnabled = true;
            }
            else
            {
                ProfileListMenuItem.IsEnabled = false;
            }
        }

        private async void UpdateClssData(object sender, EventArgs args)
        {
            try
            {
                await clssService.UpdateClassificationData();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }
    }
}
