﻿using System;
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

namespace db_test
{
    public partial class RegisterDocumentView : Form
    {
        private SQLiteConnection m_dbConnection;
        private RegisterDocumentDataService registerDocumentDataService;
        private RegisterDocumentPresenter registerDocumentPresenter;
        private BindingSource fileManagerBS;

        private string db_filename = "test.db";
        private string connectionString;

        public event EventHandler OnShowRegisterDocumentInfo;
        public event EventHandler OnShowRegisterDocumentList;

        public RegisterDocumentView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitDB();

            registerDocumentDataService = new RegisterDocumentDataService(m_dbConnection);
            registerDocumentPresenter = new RegisterDocumentPresenter(this, registerDocumentDataService);

            fileManagerBS = new BindingSource();
            fileManagerBS.DataSource = new List<RegisterFile>();
            fileManagerBS.AllowNew = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = fileManagerBS;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;

            showRegisterList();
            //testDB();
        }

        public object DocumentList
        {
            set { dataGridView1.DataSource = value; }
        }

        public string SearchText
        {
            get { return searchBox.Text; }
        }

        public string DocumentNumber
        {
            get { return label8.Text; }
            set { label8.Text = value; }
        }

        public string DocumentTitle
        {
            get { return label9.Text; }
            set { label9.Text = value; }
        }

        private void GetRegisterDocumentInfoButton_Click(object sender, DataGridViewCellEventArgs e)
        {
            string docno = (string)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            this.DocumentNumber = docno;

            if (OnShowRegisterDocumentInfo != null)
            {
                OnShowRegisterDocumentInfo(this, EventArgs.Empty);
            }
            
            showFileList(docno);
        }

        private void InitDB() {
            connectionString = string.Format("Data Source={0};Version=3;", db_filename);

            if (!File.Exists(db_filename))
            {
                SQLiteConnection.CreateFile(db_filename);
                m_dbConnection = new SQLiteConnection(connectionString);
                m_dbConnection.Open();

                Console.WriteLine("Creating Database file...");

                string setupfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"db.setup.sql");
                string sql = File.ReadAllText(setupfile);
                Console.WriteLine("Executing query: {0}", sql);
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                command.Dispose();
            }
            
            m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
        }

        private void testDB() {

            string sql = "delete from register";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            command.Dispose();

            sql = "insert into register (docno) values ('doc1')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            command.Dispose();

            sql = "insert into register (docno) values ('doc2')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            command.Dispose();

            sql = "insert into register (docno) values ('doc3')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            command.Dispose();

        }

        private void showFileList(string docno) {
            string targetDirectory = "register/" + docno;
            string[] files = new string[0];
            try
            {
                files = Directory.GetFiles(targetDirectory);
            } catch( DirectoryNotFoundException e )
            {
                Console.WriteLine("Directory not found: {0}", targetDirectory);
            }
            

            fileManagerBS.Clear();  // clear the filemanager list before load it again
            var registerFiles = new List<RegisterFile>();
            foreach (string fileName in files)
            {
                var regfile = new RegisterFile(fileName);
                registerFiles.Add(regfile);
                //fileManagerBS.Add(regfile);
                Console.WriteLine("Processed file: {0}", regfile);
            }
            fileManagerBS.DataSource = registerFiles;
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

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RegisterFile file = dataGridView2.Rows[e.RowIndex].DataBoundItem as RegisterFile;
            Console.WriteLine(file);
            openRegisterFile(file);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellname = dataGridView2.Rows[e.RowIndex].DataGridView.Columns[e.ColumnIndex].DataPropertyName;
            if(cellname.Equals("open_location"))
            {
                RegisterFile file = dataGridView2.Rows[e.RowIndex].DataBoundItem as RegisterFile;
                openRegisterFileLocation(file);
            }
            
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
