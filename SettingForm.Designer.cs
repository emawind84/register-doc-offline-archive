namespace pmis
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.settingsResetButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.docTypesTextBox = new System.Windows.Forms.RichTextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.docDisciplinesTextBox = new System.Windows.Forms.RichTextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.docStatusesTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.registerFolderLocationButton = new System.Windows.Forms.Button();
            this.settingRegisterFolderURI = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.settingLanguage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.sqliteFileLocationButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.settingSQLiteDbLocation = new System.Windows.Forms.TextBox();
            this.connectSQLiteDatabaseButton = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.settingDbType = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.settingsDocumentCount = new System.Windows.Forms.Label();
            this.settingsReviewCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.importLogViewer = new System.Windows.Forms.RichTextBox();
            this.pmisWsProjectCodeLabel = new System.Windows.Forms.Label();
            this.settingPmisWsProjectCode = new System.Windows.Forms.TextBox();
            this.pmisWsUrlLabel = new System.Windows.Forms.Label();
            this.settingPmisWsUrl = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.settingPmisWsAuthKey = new System.Windows.Forms.TextBox();
            this.importReviewDataButton = new System.Windows.Forms.Button();
            this.importRegisterDataButton = new System.Windows.Forms.Button();
            this.settingsOkButton = new System.Windows.Forms.Button();
            this.settingsCancelButton = new System.Windows.Forms.Button();
            this.productInfoLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(730, 418);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.groupBox11);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(722, 392);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "General Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.settingsResetButton);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(373, 299);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 87);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reset Settings";
            // 
            // settingsResetButton
            // 
            this.settingsResetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.settingsResetButton.ForeColor = System.Drawing.Color.Black;
            this.settingsResetButton.Location = new System.Drawing.Point(6, 47);
            this.settingsResetButton.Name = "settingsResetButton";
            this.settingsResetButton.Size = new System.Drawing.Size(108, 31);
            this.settingsResetButton.TabIndex = 1;
            this.settingsResetButton.Text = "Reset Settings";
            this.settingsResetButton.UseVisualStyleBackColor = false;
            this.settingsResetButton.Click += new System.EventHandler(this.settingsResetButtonOnClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Restore settings to their original defaults.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl2);
            this.groupBox1.Location = new System.Drawing.Point(6, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 263);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Options";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Location = new System.Drawing.Point(6, 19);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(349, 233);
            this.tabControl2.TabIndex = 50;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.docTypesTextBox);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(341, 207);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Type items";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // docTypesTextBox
            // 
            this.docTypesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.docTypesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.docTypesTextBox.Location = new System.Drawing.Point(-1, 0);
            this.docTypesTextBox.Name = "docTypesTextBox";
            this.docTypesTextBox.Size = new System.Drawing.Size(342, 207);
            this.docTypesTextBox.TabIndex = 42;
            this.docTypesTextBox.Text = "";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.docDisciplinesTextBox);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(341, 207);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Discipline items";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // docDisciplinesTextBox
            // 
            this.docDisciplinesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.docDisciplinesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.docDisciplinesTextBox.Location = new System.Drawing.Point(0, 0);
            this.docDisciplinesTextBox.Name = "docDisciplinesTextBox";
            this.docDisciplinesTextBox.Size = new System.Drawing.Size(234, 207);
            this.docDisciplinesTextBox.TabIndex = 43;
            this.docDisciplinesTextBox.Text = "";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.docStatusesTextBox);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(341, 207);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "Status items";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // docStatusesTextBox
            // 
            this.docStatusesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.docStatusesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.docStatusesTextBox.Location = new System.Drawing.Point(0, 0);
            this.docStatusesTextBox.Name = "docStatusesTextBox";
            this.docStatusesTextBox.Size = new System.Drawing.Size(234, 207);
            this.docStatusesTextBox.TabIndex = 45;
            this.docStatusesTextBox.Text = "";
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox11.Controls.Add(this.registerFolderLocationButton);
            this.groupBox11.Controls.Add(this.settingRegisterFolderURI);
            this.groupBox11.Controls.Add(this.label13);
            this.groupBox11.Location = new System.Drawing.Point(6, 6);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(468, 86);
            this.groupBox11.TabIndex = 41;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Register Settings";
            // 
            // registerFolderLocationButton
            // 
            this.registerFolderLocationButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.registerFolderLocationButton.Location = new System.Drawing.Point(342, 46);
            this.registerFolderLocationButton.Name = "registerFolderLocationButton";
            this.registerFolderLocationButton.Size = new System.Drawing.Size(80, 24);
            this.registerFolderLocationButton.TabIndex = 43;
            this.registerFolderLocationButton.Text = "Browse...";
            this.registerFolderLocationButton.UseVisualStyleBackColor = false;
            this.registerFolderLocationButton.Click += new System.EventHandler(this.registerLocationButton_Click);
            // 
            // settingRegisterFolderURI
            // 
            this.settingRegisterFolderURI.Location = new System.Drawing.Point(6, 49);
            this.settingRegisterFolderURI.Name = "settingRegisterFolderURI";
            this.settingRegisterFolderURI.Size = new System.Drawing.Size(330, 20);
            this.settingRegisterFolderURI.TabIndex = 45;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 44;
            this.label13.Text = "Folder Location:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(722, 392);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "International Settings";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.settingLanguage);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(710, 380);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " International Settings";
            // 
            // settingLanguage
            // 
            this.settingLanguage.FormattingEnabled = true;
            this.settingLanguage.Items.AddRange(new object[] {
            "English",
            "Korean"});
            this.settingLanguage.Location = new System.Drawing.Point(6, 40);
            this.settingLanguage.Name = "settingLanguage";
            this.settingLanguage.Size = new System.Drawing.Size(208, 21);
            this.settingLanguage.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Language:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox10);
            this.tabPage2.Controls.Add(this.groupBox9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(722, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Database Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.sqliteFileLocationButton);
            this.groupBox10.Controls.Add(this.label12);
            this.groupBox10.Controls.Add(this.settingSQLiteDbLocation);
            this.groupBox10.Controls.Add(this.connectSQLiteDatabaseButton);
            this.groupBox10.Location = new System.Drawing.Point(6, 105);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(710, 120);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "SQLite Settings";
            // 
            // sqliteFileLocationButton
            // 
            this.sqliteFileLocationButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sqliteFileLocationButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sqliteFileLocationButton.Location = new System.Drawing.Point(302, 39);
            this.sqliteFileLocationButton.Name = "sqliteFileLocationButton";
            this.sqliteFileLocationButton.Size = new System.Drawing.Size(80, 24);
            this.sqliteFileLocationButton.TabIndex = 44;
            this.sqliteFileLocationButton.Text = "Browse...";
            this.sqliteFileLocationButton.UseVisualStyleBackColor = false;
            this.sqliteFileLocationButton.Click += new System.EventHandler(this.sqliteFileLocationButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Database File Location:";
            // 
            // settingSQLiteDbLocation
            // 
            this.settingSQLiteDbLocation.Location = new System.Drawing.Point(6, 42);
            this.settingSQLiteDbLocation.Name = "settingSQLiteDbLocation";
            this.settingSQLiteDbLocation.Size = new System.Drawing.Size(290, 20);
            this.settingSQLiteDbLocation.TabIndex = 4;
            // 
            // connectSQLiteDatabaseButton
            // 
            this.connectSQLiteDatabaseButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.connectSQLiteDatabaseButton.Location = new System.Drawing.Point(9, 77);
            this.connectSQLiteDatabaseButton.Name = "connectSQLiteDatabaseButton";
            this.connectSQLiteDatabaseButton.Size = new System.Drawing.Size(114, 26);
            this.connectSQLiteDatabaseButton.TabIndex = 2;
            this.connectSQLiteDatabaseButton.Text = "Connect Database";
            this.connectSQLiteDatabaseButton.UseVisualStyleBackColor = false;
            this.connectSQLiteDatabaseButton.Click += new System.EventHandler(this.connectSQLiteDatabaseButton_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.label10);
            this.groupBox9.Controls.Add(this.settingDbType);
            this.groupBox9.Location = new System.Drawing.Point(6, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(710, 93);
            this.groupBox9.TabIndex = 6;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Database Settings";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Database Type:";
            // 
            // settingDbType
            // 
            this.settingDbType.FormattingEnabled = true;
            this.settingDbType.Location = new System.Drawing.Point(6, 46);
            this.settingDbType.Name = "settingDbType";
            this.settingDbType.Size = new System.Drawing.Size(228, 21);
            this.settingDbType.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(722, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data Import Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.groupBox4);
            this.groupBox6.Controls.Add(this.importLogViewer);
            this.groupBox6.Controls.Add(this.pmisWsProjectCodeLabel);
            this.groupBox6.Controls.Add(this.settingPmisWsProjectCode);
            this.groupBox6.Controls.Add(this.pmisWsUrlLabel);
            this.groupBox6.Controls.Add(this.settingPmisWsUrl);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.settingPmisWsAuthKey);
            this.groupBox6.Controls.Add(this.importReviewDataButton);
            this.groupBox6.Controls.Add(this.importRegisterDataButton);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(710, 380);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Web Service Settings";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.settingsDocumentCount);
            this.groupBox4.Controls.Add(this.settingsReviewCount);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(486, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 82);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data Stats";
            // 
            // settingsDocumentCount
            // 
            this.settingsDocumentCount.AutoSize = true;
            this.settingsDocumentCount.Location = new System.Drawing.Point(125, 47);
            this.settingsDocumentCount.Name = "settingsDocumentCount";
            this.settingsDocumentCount.Size = new System.Drawing.Size(22, 13);
            this.settingsDocumentCount.TabIndex = 27;
            this.settingsDocumentCount.Text = "NA";
            // 
            // settingsReviewCount
            // 
            this.settingsReviewCount.AutoSize = true;
            this.settingsReviewCount.Location = new System.Drawing.Point(125, 30);
            this.settingsReviewCount.Name = "settingsReviewCount";
            this.settingsReviewCount.Size = new System.Drawing.Size(22, 13);
            this.settingsReviewCount.TabIndex = 26;
            this.settingsReviewCount.Text = "NA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Document #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Review #";
            // 
            // importLogViewer
            // 
            this.importLogViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importLogViewer.Location = new System.Drawing.Point(6, 223);
            this.importLogViewer.MaxLength = 10;
            this.importLogViewer.Name = "importLogViewer";
            this.importLogViewer.ReadOnly = true;
            this.importLogViewer.Size = new System.Drawing.Size(698, 151);
            this.importLogViewer.TabIndex = 19;
            this.importLogViewer.Text = "";
            // 
            // pmisWsProjectCodeLabel
            // 
            this.pmisWsProjectCodeLabel.AutoSize = true;
            this.pmisWsProjectCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmisWsProjectCodeLabel.Location = new System.Drawing.Point(6, 79);
            this.pmisWsProjectCodeLabel.Name = "pmisWsProjectCodeLabel";
            this.pmisWsProjectCodeLabel.Size = new System.Drawing.Size(71, 13);
            this.pmisWsProjectCodeLabel.TabIndex = 17;
            this.pmisWsProjectCodeLabel.Text = "Project Code:";
            // 
            // settingPmisWsProjectCode
            // 
            this.settingPmisWsProjectCode.Location = new System.Drawing.Point(6, 95);
            this.settingPmisWsProjectCode.Name = "settingPmisWsProjectCode";
            this.settingPmisWsProjectCode.Size = new System.Drawing.Size(245, 20);
            this.settingPmisWsProjectCode.TabIndex = 18;
            // 
            // pmisWsUrlLabel
            // 
            this.pmisWsUrlLabel.AutoSize = true;
            this.pmisWsUrlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmisWsUrlLabel.Location = new System.Drawing.Point(6, 30);
            this.pmisWsUrlLabel.Name = "pmisWsUrlLabel";
            this.pmisWsUrlLabel.Size = new System.Drawing.Size(43, 13);
            this.pmisWsUrlLabel.TabIndex = 15;
            this.pmisWsUrlLabel.Text = "API Url:";
            // 
            // settingPmisWsUrl
            // 
            this.settingPmisWsUrl.Location = new System.Drawing.Point(6, 46);
            this.settingPmisWsUrl.Name = "settingPmisWsUrl";
            this.settingPmisWsUrl.Size = new System.Drawing.Size(245, 20);
            this.settingPmisWsUrl.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Authentication Key:";
            // 
            // settingPmisWsAuthKey
            // 
            this.settingPmisWsAuthKey.Location = new System.Drawing.Point(6, 144);
            this.settingPmisWsAuthKey.Name = "settingPmisWsAuthKey";
            this.settingPmisWsAuthKey.Size = new System.Drawing.Size(245, 20);
            this.settingPmisWsAuthKey.TabIndex = 14;
            // 
            // importReviewDataButton
            // 
            this.importReviewDataButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.importReviewDataButton.Location = new System.Drawing.Point(170, 180);
            this.importReviewDataButton.Name = "importReviewDataButton";
            this.importReviewDataButton.Size = new System.Drawing.Size(149, 26);
            this.importReviewDataButton.TabIndex = 9;
            this.importReviewDataButton.Text = "Import Review Data";
            this.importReviewDataButton.UseVisualStyleBackColor = false;
            this.importReviewDataButton.Click += new System.EventHandler(this.importReviewDataButton_Click);
            // 
            // importRegisterDataButton
            // 
            this.importRegisterDataButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.importRegisterDataButton.Location = new System.Drawing.Point(6, 180);
            this.importRegisterDataButton.Name = "importRegisterDataButton";
            this.importRegisterDataButton.Size = new System.Drawing.Size(149, 26);
            this.importRegisterDataButton.TabIndex = 0;
            this.importRegisterDataButton.Text = "Import Register Data";
            this.importRegisterDataButton.UseVisualStyleBackColor = false;
            this.importRegisterDataButton.Click += new System.EventHandler(this.importRegisterDataButton_Click);
            // 
            // settingsOkButton
            // 
            this.settingsOkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsOkButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.settingsOkButton.Location = new System.Drawing.Point(508, 436);
            this.settingsOkButton.Name = "settingsOkButton";
            this.settingsOkButton.Size = new System.Drawing.Size(111, 36);
            this.settingsOkButton.TabIndex = 4;
            this.settingsOkButton.Text = "OK";
            this.settingsOkButton.UseVisualStyleBackColor = false;
            this.settingsOkButton.Click += new System.EventHandler(this.settingsOkButtonOnClick);
            // 
            // settingsCancelButton
            // 
            this.settingsCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsCancelButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.settingsCancelButton.Location = new System.Drawing.Point(625, 436);
            this.settingsCancelButton.Name = "settingsCancelButton";
            this.settingsCancelButton.Size = new System.Drawing.Size(111, 36);
            this.settingsCancelButton.TabIndex = 5;
            this.settingsCancelButton.Text = "Cancel";
            this.settingsCancelButton.UseVisualStyleBackColor = false;
            this.settingsCancelButton.Click += new System.EventHandler(this.settingsCancelButtonOnClick);
            // 
            // productInfoLabel
            // 
            this.productInfoLabel.AutoSize = true;
            this.productInfoLabel.Location = new System.Drawing.Point(9, 459);
            this.productInfoLabel.Name = "productInfoLabel";
            this.productInfoLabel.Size = new System.Drawing.Size(42, 13);
            this.productInfoLabel.TabIndex = 6;
            this.productInfoLabel.Text = "Version";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "archive.db";
            // 
            // SettingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(754, 484);
            this.ControlBox = false;
            this.Controls.Add(this.productInfoLabel);
            this.Controls.Add(this.settingsCancelButton);
            this.Controls.Add(this.settingsOkButton);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.Text = "Archive Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.Button importReviewDataButton;
        public System.Windows.Forms.Button importRegisterDataButton;
        public System.Windows.Forms.GroupBox groupBox10;
        public System.Windows.Forms.GroupBox groupBox9;
        public System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.GroupBox groupBox11;
        public System.Windows.Forms.Button settingsOkButton;
        public System.Windows.Forms.Button settingsCancelButton;
        public System.Windows.Forms.Button connectSQLiteDatabaseButton;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TabControl tabControl2;
        public System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.RichTextBox docTypesTextBox;
        public System.Windows.Forms.TabPage tabPage6;
        public System.Windows.Forms.RichTextBox docDisciplinesTextBox;
        public System.Windows.Forms.TabPage tabPage7;
        public System.Windows.Forms.RichTextBox docStatusesTextBox;
        public System.Windows.Forms.Label productInfoLabel;
        public System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox settingLanguage;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button registerFolderLocationButton;
        public System.Windows.Forms.TextBox settingRegisterFolderURI;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox settingSQLiteDbLocation;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox settingDbType;
        public System.Windows.Forms.Label pmisWsProjectCodeLabel;
        public System.Windows.Forms.TextBox settingPmisWsProjectCode;
        public System.Windows.Forms.Label pmisWsUrlLabel;
        public System.Windows.Forms.TextBox settingPmisWsUrl;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox settingPmisWsAuthKey;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        public System.Windows.Forms.Button sqliteFileLocationButton;
        public System.Windows.Forms.OpenFileDialog openFileDialog;
        public System.Windows.Forms.RichTextBox importLogViewer;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Button settingsResetButton;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label settingsDocumentCount;
        private System.Windows.Forms.Label settingsReviewCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}