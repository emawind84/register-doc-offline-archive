using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using pmis.reviewinfo;

namespace pmis
{
    public partial class RegisterDocumentMainForm : Form
    {
        private SettingForm settingForm;
        private SQLiteDAOService sqliteDaoService;
        private RegisterDocumentDataService registerDocumentDataService;
        private RegisterDocumentPresenter registerDocumentPresenter;
        private RegisterDocumentDetailView registerDocumentDetailView;
        private ReviewInfoPresenter reviewInfoPresenter;
        private ReviewInfoDataService reviewInfoDataService;
        private BindingSource fileManagerBS;

        public event EventHandler OnShowRegisterDocumentInfo;
        public event EventHandler OnShowRegisterDocumentList;

        public RegisterDocumentDetailView RegisterDocumentDetailView
        {
            get { return this.registerDocumentDetailView; }
        }

        public SQLiteDAOService SQLiteDaoService {
            get { return sqliteDaoService; }
        }

        public string SearchCriteriaDocNumber {
            get { return srchNumber.Text; }
        }

        public string SearchCriteriaFromDate
        {
            get { return srchFromDate.Text; }
        }

        public RegisterDocumentMainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqliteDaoService = new SQLiteDAOService();
            var conn = sqliteDaoService.InitDB();

            registerDocumentDataService = new RegisterDocumentDataService(sqliteDaoService);
            registerDocumentPresenter = new RegisterDocumentPresenter(this, registerDocumentDataService);
            registerDocumentDetailView = new RegisterDocumentDetailView(this);
            registerDataGridView.AllowUserToAddRows = false;
            registerDataGridView.AutoGenerateColumns = false;
            
            reviewInfoDataService = new ReviewInfoDataService(sqliteDaoService);
            reviewInfoPresenter = new ReviewInfoPresenter(this, reviewInfoDataService);
            reviewDataGridView.AutoGenerateColumns = false;
            reviewDataGridView.AllowUserToAddRows = false;

            fileManagerBS = new BindingSource();
            fileManagerBS.DataSource = new List<RegisterFile>();
            fileManagerBS.AllowNew = false;
            fileManagerDataGridView.AutoGenerateColumns = false;
            fileManagerDataGridView.DataSource = fileManagerBS;

            settingForm = new SettingForm(this, registerDocumentDataService, reviewInfoDataService);
            settingForm.SettingChanged += UpdateSearchOptions;

            UpdateSearchOptions();
            showRegisterList();
        }

        public object DocumentList
        {
            set { registerDataGridView.DataSource = value; }
        }

        public object ReviewInfoList
        {
            set { reviewDataGridView.DataSource = value; }
        }

        public object DocumentFilesDataSource
        {
            get { return fileManagerBS.DataSource; }
            set { fileManagerBS.DataSource = value; }
        }

        private void UpdateSearchOptions(object sender = null, EventArgs args = null)
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
            this.registerDocumentDetailView.DocumentNumber = Convert.ToString(dr["docno"]);
            this.registerDocumentDetailView.Version = Convert.ToString(dr["doc_version"]);

            if (OnShowRegisterDocumentInfo != null)
            {
                OnShowRegisterDocumentInfo(this, EventArgs.Empty);
            }
            
        }

        private void openRegisterFile(RegisterFile file) {
            System.Diagnostics.Process.Start(String.Format(@"{0}", file.FilePath));
        }

        private void openRegisterFileLocation(RegisterFile file)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select, " + file.FilePath);
        }

        private void showRegisterList()
        {
            if(OnShowRegisterDocumentList != null)
                OnShowRegisterDocumentList(this, EventArgs.Empty);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            showRegisterList();
        }

        private void fileManagerDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }

            string cellname = fileManagerDataGridView.Rows[e.RowIndex].DataGridView.Columns[e.ColumnIndex].DataPropertyName;
            if (cellname.Equals("open_location"))
            {
                RegisterFile file = fileManagerDataGridView.Rows[e.RowIndex].DataBoundItem as RegisterFile;
                openRegisterFileLocation(file);
            }
        }

        private void fileManagerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }

            RegisterFile file = fileManagerDataGridView.Rows[e.RowIndex].DataBoundItem as RegisterFile;
            Console.WriteLine(file);
            openRegisterFile(file);
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
