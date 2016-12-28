using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using pmis.reviewinfo;

namespace pmis
{
    public partial class ArchiveMainForm : Form
    {
        private SettingForm settingForm;
        private SQLiteDaoService daoService;
        private RegisterDocumentDataService registerDocumentDataService;
        private RegisterDocumentPresenter registerDocumentPresenter;
        private RegisterDocumentDetailView registerDocumentDetailView;
        private ReviewInfoPresenter reviewInfoPresenter;
        private ReviewInfoDataService reviewInfoDataService;
        private BindingSource fileManagerBS;
        private BindingSource reviewFilesBS;

        public event EventHandler OnShowRegisterDocumentInfo;
        public event EventHandler OnShowRegisterDocumentList;

        public RegisterDocumentDetailView RegisterDocumentDetailView
        {
            get { return this.registerDocumentDetailView; }
        }

        public SQLiteDaoService DaoService {
            get { return daoService; }
        }

        public string SearchCriteriaDocNumber { get { return srchNumber.Text; } }

        public string SearchCriteriaTitle { get { return srchTitle.Text; } }

        public string SearchCriteriaFromDate { get { return srchFromDate.Text; } }

        public string SearchCriteriaToDate { get { return srchToDate.Text; } }

        public string SearchCriteriaStatus { get { return srchStatus.Text; } }

        public string SearchCriteriaDiscipline { get { return srchDiscipline.Text; } }

        public string SearchCriteriaType { get { return srchType.Text; } }

        public string SearchCriteriaAllHistory { get { return srchHistory.Text; } }

        public ArchiveMainForm()
        {
            InitializeComponent();

            // configure user folder in appdata
            AppConfig.InitConfig();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                daoService = new SQLiteDaoService();
            
                registerDocumentDataService = new RegisterDocumentDataService(daoService);
                registerDocumentPresenter = new RegisterDocumentPresenter(this, registerDocumentDataService);
                registerDocumentDetailView = new RegisterDocumentDetailView(this);
                registerDataGridView.AllowUserToAddRows = false;
                registerDataGridView.AutoGenerateColumns = false;
            
                reviewInfoDataService = new ReviewInfoDataService(daoService);
                reviewInfoPresenter = new ReviewInfoPresenter(this, reviewInfoDataService, registerDocumentDataService);
                reviewDataGridView.AutoGenerateColumns = false;
                reviewDataGridView.AllowUserToAddRows = false;

                reviewFilesBS = new BindingSource();
                reviewFilesBS.DataSource = new List<RegisterFile>();
                reviewFilesBS.AllowNew = false;
                reviewFileDataGrid.AutoGenerateColumns = false;
                reviewFileDataGrid.DataSource = reviewFilesBS;

                fileManagerBS = new BindingSource();
                fileManagerBS.DataSource = new List<RegisterFile>();
                fileManagerBS.AllowNew = false;
                fileManagerDataGridView.AutoGenerateColumns = false;
                fileManagerDataGridView.DataSource = fileManagerBS;

                settingForm = new SettingForm(this, registerDocumentDataService, reviewInfoDataService);
                settingForm.SettingChanged += LoadSearchOptions;
                
                // open db connection before doing anything else
                daoService.Open();

                // load search options
                LoadSearchOptions();

                // request docs list
                ShowRegisterList();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
            
        }

        public object DocumentList
        {
            set { registerDataGridView.DataSource = value; }
        }

        public object ReviewInfoList
        {
            set { reviewDataGridView.DataSource = value; }
        }

        public object RegisterFilesDS
        {
            get { return fileManagerBS.DataSource; }
            set { fileManagerBS.DataSource = value; }
        }

        public object ReviewFilesDS {
            get { return reviewFilesBS.DataSource; }
            set { reviewFilesBS.DataSource = value; }
        }

        private void LoadSearchOptions(object sender = null, EventArgs args = null)
        {
            srchStatus.DataSource = Properties.Settings.Default.register_status;
            srchDiscipline.DataSource = Properties.Settings.Default.register_discipline;
            srchType.DataSource = Properties.Settings.Default.register_type;
        }

        private void GetRegisterDocumentInfoButton_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }

            //string docno = (string)registerDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            var dr = registerDataGridView.Rows[e.RowIndex].DataBoundItem as DataRowView;
            this.registerDocumentDetailView.Number = Convert.ToString(dr["docno"]);
            this.registerDocumentDetailView.Version = Convert.ToString(dr["doc_version"]);

            if (OnShowRegisterDocumentInfo != null)
            {
                OnShowRegisterDocumentInfo(this, EventArgs.Empty);
            }
            
        }

        private void OpenRegisterFile(RegisterFile file) {
            System.Diagnostics.Process.Start(String.Format(@"{0}", file.FilePath));
        }

        private void OpenRegisterFileLocation(RegisterFile file)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select, " + file.FilePath);
        }

        private void ShowRegisterList()
        {
            try
            {
                if (OnShowRegisterDocumentList != null)
                    OnShowRegisterDocumentList(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Something really bad happened...", ex);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                ShowRegisterList();
            }
            catch(Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void fileManagerDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }

            string cellname = fileManagerDataGridView.Rows[e.RowIndex].DataGridView.Columns[e.ColumnIndex].DataPropertyName;
            if (cellname.Equals("open_location"))
            {
                RegisterFile file = fileManagerDataGridView.Rows[e.RowIndex].DataBoundItem as RegisterFile;
                OpenRegisterFileLocation(file);
            }
        }

        private void fileManagerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }

            RegisterFile file = fileManagerDataGridView.Rows[e.RowIndex].DataBoundItem as RegisterFile;
            Console.WriteLine(file);
            OpenRegisterFile(file);
        }

        private void registerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }

            tabControl1.SelectedIndex = 1;
        }

        private void archiveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
