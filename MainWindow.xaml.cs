using pmis;
using pmis.i18n;
using pmis.register;
using pmis.reviewinfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace archive2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IDbConnection daoService;
        private RegisterDocumentDataService registerDocumentDataService;
        private RegisterDocumentPresenter registerDocumentPresenter;
        private RegisterDocumentDetailView registerDocumentDetailView;
        private ReviewInfoPresenter reviewInfoPresenter;
        private ReviewInfoDataService reviewInfoDataService;
        private PicturePresenter picturePresenter;
        private PictureViewerService pictureViewerService;

        public event EventHandler OnShowRegisterDocumentInfo;
        public event EventHandler OnShowRegisterDocumentList;

        public RegisterDocumentDetailView RegisterDocumentDetailView
        {
            get { return this.registerDocumentDetailView; }
        }

        public IDbConnection DaoService
        {
            get { return daoService; }
        }

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

        public string SearchCriteriaFromDate { get { return srchFromDate.Text; } }

        public string SearchCriteriaToDate { get { return srchToDate.Text; } }

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
            get { return srchType.Text; }
            set { srchType.Text = value; }
        }

        public MainWindow()
        {
            //SplashForm.ShowSplash();

            // configure user folder in appdata
            try
            {
                AppConfig.InitConfig();
            }
            catch (Exception e)
            {
                new ApplicationException("Application didn't start correctly, please check the log.", e)
                    .Log()
                    .Display();
            }

            InitializeComponent();

            daoService = new SQLiteDaoService(Properties.Settings.Default.sqlite_db_location);

            try
            {
                // open db connection before doing anything else
                daoService.Open();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
                return;
            }

            registerDocumentDataService = new RegisterDocumentDataService(daoService as IRegisterDocumentDao);
            registerDocumentPresenter = new RegisterDocumentPresenter(this, registerDocumentDataService);
            registerDocumentDetailView = new RegisterDocumentDetailView(this);
            //registerDataGridView.AllowUserToAddRows = false;
            //registerDataGridView.AutoGenerateColumns = false;

            reviewInfoDataService = new ReviewInfoDataService(daoService as IReviewInfoDao);
            reviewInfoPresenter = new ReviewInfoPresenter(this, reviewInfoDataService, registerDocumentDataService);
            //reviewDataGridView.AutoGenerateColumns = false;
            //reviewDataGridView.AllowUserToAddRows = false;

            //reviewFilesBS = new BindingSource();
            //reviewFilesBS.DataSource = new List<RegisterFile>();
            //reviewFilesBS.AllowNew = false;
            //reviewFileDataGrid.AutoGenerateColumns = false;
            //reviewFileDataGrid.DataSource = reviewFilesBS;

            //fileManagerBS = new BindingSource();
            //fileManagerBS.DataSource = new List<RegisterFile>();
            //fileManagerBS.AllowNew = false;
            //fileManagerDataGridView.AutoGenerateColumns = false;
            //fileManagerDataGridView.DataSource = fileManagerBS;

            //srchHistory.DataSource = new BindingSource(AppConfig.RegisterHistoryOptions, null);
            //srchHistory.DisplayMember = "Value";
            //srchHistory.ValueMember = "Key";
            //srchHistory.SelectedValue = AppConfig.HISTORY_LATEST;

            //settingForm = new SettingForm(
            //    registerDocumentDataService,
            //    reviewInfoDataService);

            // adding sqlite module to setting form
            //settingForm.SQLiteDaoService = daoService as SQLiteDaoService;

            //settingForm.SettingChanged += LoadSearchOptions;
            //settingForm.SettingChanged += LoadPictureViewer;

            //aboutForm = new AboutBox();

            LanguageSupport i18n = new LanguageSupport();
            i18n.SetMainFromLanguage(this);

            try
            {
                // load search options
                //LoadSearchOptions();

                // request docs list
                //ShowRegisterList();

                // load picture viewer
                //LoadPictureViewer();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
                return;
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            daoService.Close();
        }
    }
}
