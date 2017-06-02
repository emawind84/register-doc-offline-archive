using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using pmis.reviewinfo;
using pmis.register;
using pmis.i18n;
using System.IO;
using System.Threading;
using System.Drawing;

namespace pmis
{
    public partial class ArchiveMainForm : Form
    {
        private SettingForm settingForm;
        private IDbConnection daoService;
        private RegisterDocumentDataService registerDocumentDataService;
        private RegisterDocumentPresenter registerDocumentPresenter;
        private RegisterDocumentDetailView registerDocumentDetailView;
        private ReviewInfoPresenter reviewInfoPresenter;
        private ReviewInfoDataService reviewInfoDataService;
        private BindingSource fileManagerBS;
        private BindingSource reviewFilesBS;
        private Form aboutForm;
        protected Graphics myGraphics;
        private int currentImage = 0;

        public event EventHandler OnShowRegisterDocumentInfo;
        public event EventHandler OnShowRegisterDocumentList;

        public RegisterDocumentDetailView RegisterDocumentDetailView
        {
            get { return this.registerDocumentDetailView; }
        }

        public IDbConnection DaoService {
            get { return daoService; }
        }

        public string SearchCriteriaDocNumber {
            get { return srchNumber.Text; }
            set { srchNumber.Text = value; }
        }

        public string SearchCriteriaTitle {
            get { return srchTitle.Text; }
            set { srchTitle.Text = value; }
        }

        public string SearchCriteriaFromDate { get { return srchFromDate.Text; } }

        public string SearchCriteriaToDate { get { return srchToDate.Text; } }

        public string SearchCriteriaStatus {
            get { return srchStatus.Text; }
            set { srchStatus.Text = value; }
        }

        public string SearchCriteriaDiscipline {
            get { return srchDiscipline.Text; }
            set { srchDiscipline.Text = value; }
        }

        public string SearchCriteriaType {
            get { return srchType.Text; }
            set { srchType.Text = value; }
        }

        public string SearchCriteriaAllHistory { get { return srchHistory.Text; } }

        public string SearchCriteriaRegisteredBy { get { return srchRegisteredBy.Text; } }

        public ArchiveMainForm()
        {
            SplashForm.ShowSplash();

            // configure user folder in appdata
            try {
                AppConfig.InitConfig();
            } catch (Exception e)
            {
                new ApplicationException("Application didn't start correctly, please check the log.", e)
                    .Log()
                    .Display();
            }

            InitializeComponent();

            SplashForm.HideSplash(2000);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            registerDataGridView.AllowUserToAddRows = false;
            registerDataGridView.AutoGenerateColumns = false;
            
            reviewInfoDataService = new ReviewInfoDataService(daoService as IReviewInfoDao);
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

            srchHistory.DataSource = new BindingSource(AppConfig.RegisterHistoryOptions, null);
            srchHistory.DisplayMember = "Value";
            srchHistory.ValueMember = "Key";
            srchHistory.SelectedValue = AppConfig.HISTORY_LATEST;

            // Assigns the graphics object to use in the draw options.
            myGraphics = Graphics.FromHwnd(pictureBox1.Handle);

            string targetDirectory = Path.Combine(AppConfig.AppDataFullPath, "images"); ;

            listBox1.Items.Clear();
            imageList1.Images.Clear();

            listBox1.BeginUpdate();
            string[] dirs = Directory.GetDirectories(targetDirectory);
            foreach (string dir in dirs)
            {
                listBox1.Items.Add(dir);
            }
            listBox1.EndUpdate();

            settingForm = new SettingForm(
                registerDocumentDataService, 
                reviewInfoDataService);

            // adding sqlite module to setting form
            settingForm.SQLiteDaoService = daoService as SQLiteDaoService;

            settingForm.SettingChanged += LoadSearchOptions;
            
            aboutForm = new AboutBox();

            LanguageSupport i18n = new LanguageSupport();
            i18n.SetMainFromLanguage(this);

            try
            {
                // load search options
                LoadSearchOptions();

                // request docs list
                ShowRegisterList();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
                return;
            }
            
            Application.ApplicationExit += delegate (object s, EventArgs args)
            {
                daoService.Close();
            };
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
            string[] statuses = new string[Properties.Settings.Default.register_status.Count + 1];
            statuses[0] = "";
            Properties.Settings.Default.register_status.CopyTo(statuses, 1);
            srchStatus.DataSource = statuses;

            string[] disciplines = new string[Properties.Settings.Default.register_discipline.Count + 1];
            disciplines[0] = "";
            Properties.Settings.Default.register_discipline.CopyTo(disciplines, 1);
            srchDiscipline.DataSource = disciplines;

            string[] types = new string[Properties.Settings.Default.register_type.Count + 1];
            types[0] = "";
            Properties.Settings.Default.register_type.CopyTo(types, 1);
            srchType.DataSource = types;
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
                ex.Log().Display();
            }
        }

        private void SearchButtonClickHandler(object sender, EventArgs e)
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
            try
            {
                if (e.RowIndex == -1) { return; }

                string cellname = fileManagerDataGridView.Rows[e.RowIndex].DataGridView.Columns[e.ColumnIndex].DataPropertyName;
                if (cellname.Equals("open_location"))
                {
                    RegisterFile file = fileManagerDataGridView.Rows[e.RowIndex].DataBoundItem as RegisterFile;
                    RegisterFileService.OpenRegisterFileLocation(file);
                }
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void fileManagerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (e.RowIndex == -1) { return; }

                RegisterFile file = fileManagerDataGridView.Rows[e.RowIndex].DataBoundItem as RegisterFile;
                RegisterFileService.OpenRegisterFile(file);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void registerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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

                tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void archiveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            aboutForm.Show();
        }

        private void SearchClearButtonClickHandler(object sender, EventArgs e)
        {
            SearchCriteriaDiscipline = "";
            SearchCriteriaStatus = "";
            SearchCriteriaType = "";
            SearchCriteriaDocNumber = "";
            SearchCriteriaTitle = "";
        }

        private void DataGridViewShowInFolderHandler(object sender, DataGridViewCellEventArgs e)
        {
            //Skip the Column and Row headers
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            var dataGridView = (sender as DataGridView);
            
            if (e.ColumnIndex == 2)
                dataGridView.Cursor = Cursors.Hand;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nextImage();
        }

        private void nextImage()
        {
            if (imageList1.Images.Empty != true)
            {
                if (imageList1.Images.Count - 1 > currentImage)
                {
                    currentImage++;
                }
                else
                {
                    currentImage = 0;
                }
                pictureBox1.Refresh();

                // Draw the image in the panel.
                imageList1.Draw(myGraphics, 10, 10, currentImage);

                // Show the image in the PictureBox.
                pictureBox1.Image = imageList1.Images[currentImage];
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imageDirectory = listBox1.SelectedItem.ToString();
            string[] files = new string[0];
            try
            {
                LogUtil.Log(String.Format("Looking for files... {0}", imageDirectory));
                files = Directory.GetFiles(imageDirectory);
            }
            catch (DirectoryNotFoundException ex)
            {
                ex.Log();
            }

            var images = new List<RegisterFile>();

            foreach (string fileName in files)
            {
                imageList1.Images.Add(Image.FromFile(fileName));
            }
            currentImage = 0;
            nextImage();
        }
    }
}
