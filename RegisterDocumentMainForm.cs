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
        private SQLiteDAOService sqliteDaoService;
        private RegisterDocumentDataService registerDocumentDataService;
        private RegisterDocumentPresenter registerDocumentPresenter;
        private RegisterDocumentDetailView registerDocumentDetailView;
        private ReviewInfoPresenter reviewInfoPresenter;
        private ReviewInfoDataService reviewInfoDataService;
        private BindingSource fileManagerBS;

        public event EventHandler OnShowRegisterDocumentInfo;
        public event EventHandler OnShowRegisterDocumentList;

        private string db_filename = "test.db";

        public RegisterDocumentDetailView RegisterDocumentDetailView
        {
            get { return this.registerDocumentDetailView; }
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
            sqliteDaoService = new SQLiteDAOService(db_filename);
            var conn = sqliteDaoService.InitDB();

            registerDocumentDataService = new RegisterDocumentDataService(sqliteDaoService);
            registerDocumentPresenter = new RegisterDocumentPresenter(this, registerDocumentDataService);
            registerDocumentDetailView = new RegisterDocumentDetailView(this);
            registerDataGridView.AllowUserToAddRows = false;
            registerDataGridView.AutoGenerateColumns = false;
            registerDocumentDataService.ImportErrorHandler += ImportErrorHandler;

            reviewInfoDataService = new ReviewInfoDataService(conn);
            reviewInfoPresenter = new ReviewInfoPresenter(this, reviewInfoDataService);
            reviewDataGridView.AutoGenerateColumns = false;
            reviewDataGridView.AllowUserToAddRows = false;
            reviewInfoDataService.ImportErrorHandler += ImportErrorHandler;

            fileManagerBS = new BindingSource();
            fileManagerBS.DataSource = new List<RegisterFile>();
            fileManagerBS.AllowNew = false;
            fileManagerDataGridView.AutoGenerateColumns = false;
            fileManagerDataGridView.DataSource = fileManagerBS;
            
            srchStatus.DataSource = Properties.Settings.Default.register_status;
            srchDiscipline.DataSource = Properties.Settings.Default.register_discipline;
            srchType.DataSource = Properties.Settings.Default.register_type;

            pmisWsProjectCode.Text = Properties.Settings.Default.pmis_project_code;
            pmisWsUrl.Text = Properties.Settings.Default.pmis_api_url;
            pmisWsAuthKey.Text = Properties.Settings.Default.pmis_auth_key;

            showRegisterList();
        }

        private void ImportErrorHandler(object sender, ErrorEventArgs args)
        {
            pmisWsErrorMessage.Text = args.GetException().Message;
        }

        public void SaveSettings(object sender, EventArgs e)
        {
            Console.WriteLine("Saving settings...");
            Properties.Settings.Default.pmis_project_code = pmisWsProjectCode.Text;
            Properties.Settings.Default.pmis_api_url = pmisWsUrl.Text;
            Properties.Settings.Default.pmis_auth_key = pmisWsAuthKey.Text;

            Properties.Settings.Default.Save();
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

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                registerDocumentDataService.ImportCSVFile(openFileDialog1.FileName);
                showRegisterList();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            registerDocumentDataService.ImportFromWebService();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            registerDocumentDataService.DeleteRegisterData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            reviewInfoDataService.ImportFromWebService();
        }
    }
}
