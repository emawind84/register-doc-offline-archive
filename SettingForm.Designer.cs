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
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.documentTypeOptions = new System.Windows.Forms.RichTextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.documentDisciplineOptions = new System.Windows.Forms.RichTextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.documentStatusOptions = new System.Windows.Forms.RichTextBox();
            this.settingRegisterFolderURI = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.connectDatabaseButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.settingSQLiteDbLocation = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.settingDbType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.pmisWsErrorMessage = new System.Windows.Forms.RichTextBox();
            this.importReviewDataButton = new System.Windows.Forms.Button();
            this.settingPmisWsAuthKey = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.settingPmisWsProjectCode = new System.Windows.Forms.TextBox();
            this.pmisWsProjectCodeLabel = new System.Windows.Forms.Label();
            this.settingPmisWsUrl = new System.Windows.Forms.TextBox();
            this.pmisWsUrlLabel = new System.Windows.Forms.Label();
            this.importRegisterDataButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
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
            this.tabPage3.Controls.Add(this.groupBox11);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(722, 392);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "General Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox11.Controls.Add(this.tabControl2);
            this.groupBox11.Controls.Add(this.settingRegisterFolderURI);
            this.groupBox11.Controls.Add(this.label13);
            this.groupBox11.Location = new System.Drawing.Point(6, 6);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(710, 380);
            this.groupBox11.TabIndex = 41;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Register Settings";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Location = new System.Drawing.Point(21, 71);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(344, 272);
            this.tabControl2.TabIndex = 49;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.documentTypeOptions);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(336, 246);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Document Type";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // documentTypeOptions
            // 
            this.documentTypeOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentTypeOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.documentTypeOptions.Location = new System.Drawing.Point(-1, 0);
            this.documentTypeOptions.Name = "documentTypeOptions";
            this.documentTypeOptions.Size = new System.Drawing.Size(337, 246);
            this.documentTypeOptions.TabIndex = 42;
            this.documentTypeOptions.Text = "";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.documentDisciplineOptions);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(336, 246);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Document Discipline";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // documentDisciplineOptions
            // 
            this.documentDisciplineOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentDisciplineOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.documentDisciplineOptions.Location = new System.Drawing.Point(0, 0);
            this.documentDisciplineOptions.Name = "documentDisciplineOptions";
            this.documentDisciplineOptions.Size = new System.Drawing.Size(336, 246);
            this.documentDisciplineOptions.TabIndex = 43;
            this.documentDisciplineOptions.Text = "";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.documentStatusOptions);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(336, 246);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "Document Status";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // documentStatusOptions
            // 
            this.documentStatusOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentStatusOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.documentStatusOptions.Location = new System.Drawing.Point(0, 0);
            this.documentStatusOptions.Name = "documentStatusOptions";
            this.documentStatusOptions.Size = new System.Drawing.Size(336, 246);
            this.documentStatusOptions.TabIndex = 45;
            this.documentStatusOptions.Text = "";
            // 
            // settingRegisterFolderURI
            // 
            this.settingRegisterFolderURI.Location = new System.Drawing.Point(72, 28);
            this.settingRegisterFolderURI.Name = "settingRegisterFolderURI";
            this.settingRegisterFolderURI.Size = new System.Drawing.Size(293, 20);
            this.settingRegisterFolderURI.TabIndex = 39;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Location";
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
            this.groupBox10.Controls.Add(this.connectDatabaseButton);
            this.groupBox10.Controls.Add(this.label12);
            this.groupBox10.Controls.Add(this.settingSQLiteDbLocation);
            this.groupBox10.Location = new System.Drawing.Point(6, 91);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(710, 93);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "SQLite Settings";
            // 
            // connectDatabaseButton
            // 
            this.connectDatabaseButton.BackColor = System.Drawing.SystemColors.Control;
            this.connectDatabaseButton.Location = new System.Drawing.Point(9, 53);
            this.connectDatabaseButton.Name = "connectDatabaseButton";
            this.connectDatabaseButton.Size = new System.Drawing.Size(114, 26);
            this.connectDatabaseButton.TabIndex = 2;
            this.connectDatabaseButton.Text = "Connect Database";
            this.connectDatabaseButton.UseVisualStyleBackColor = false;
            this.connectDatabaseButton.Click += new System.EventHandler(this.connectDatabaseButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "DB File Location";
            // 
            // settingSQLiteDbLocation
            // 
            this.settingSQLiteDbLocation.Location = new System.Drawing.Point(97, 27);
            this.settingSQLiteDbLocation.Name = "settingSQLiteDbLocation";
            this.settingSQLiteDbLocation.Size = new System.Drawing.Size(275, 20);
            this.settingSQLiteDbLocation.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.settingDbType);
            this.groupBox9.Controls.Add(this.label10);
            this.groupBox9.Location = new System.Drawing.Point(6, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(710, 79);
            this.groupBox9.TabIndex = 6;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Database Settings";
            // 
            // settingDbType
            // 
            this.settingDbType.FormattingEnabled = true;
            this.settingDbType.Items.AddRange(new object[] {
            "SQLite"});
            this.settingDbType.Location = new System.Drawing.Point(61, 30);
            this.settingDbType.Name = "settingDbType";
            this.settingDbType.Size = new System.Drawing.Size(228, 21);
            this.settingDbType.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "DB Type";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(722, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Web Service Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.pmisWsErrorMessage);
            this.groupBox6.Controls.Add(this.importReviewDataButton);
            this.groupBox6.Controls.Add(this.settingPmisWsAuthKey);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.settingPmisWsProjectCode);
            this.groupBox6.Controls.Add(this.pmisWsProjectCodeLabel);
            this.groupBox6.Controls.Add(this.settingPmisWsUrl);
            this.groupBox6.Controls.Add(this.pmisWsUrlLabel);
            this.groupBox6.Controls.Add(this.importRegisterDataButton);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(710, 380);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Web Service Settings";
            // 
            // pmisWsErrorMessage
            // 
            this.pmisWsErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pmisWsErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.pmisWsErrorMessage.Location = new System.Drawing.Point(5, 156);
            this.pmisWsErrorMessage.Name = "pmisWsErrorMessage";
            this.pmisWsErrorMessage.Size = new System.Drawing.Size(342, 53);
            this.pmisWsErrorMessage.TabIndex = 10;
            this.pmisWsErrorMessage.Text = "";
            // 
            // importReviewDataButton
            // 
            this.importReviewDataButton.Location = new System.Drawing.Point(184, 127);
            this.importReviewDataButton.Name = "importReviewDataButton";
            this.importReviewDataButton.Size = new System.Drawing.Size(149, 23);
            this.importReviewDataButton.TabIndex = 9;
            this.importReviewDataButton.Text = "Import Review Data";
            this.importReviewDataButton.UseVisualStyleBackColor = true;
            this.importReviewDataButton.Click += new System.EventHandler(this.importReviewDataButton_Click);
            // 
            // settingPmisWsAuthKey
            // 
            this.settingPmisWsAuthKey.Location = new System.Drawing.Point(107, 85);
            this.settingPmisWsAuthKey.Name = "settingPmisWsAuthKey";
            this.settingPmisWsAuthKey.Size = new System.Drawing.Size(245, 20);
            this.settingPmisWsAuthKey.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Authentication Key";
            // 
            // settingPmisWsProjectCode
            // 
            this.settingPmisWsProjectCode.Location = new System.Drawing.Point(107, 59);
            this.settingPmisWsProjectCode.Name = "settingPmisWsProjectCode";
            this.settingPmisWsProjectCode.Size = new System.Drawing.Size(245, 20);
            this.settingPmisWsProjectCode.TabIndex = 5;
            // 
            // pmisWsProjectCodeLabel
            // 
            this.pmisWsProjectCodeLabel.AutoSize = true;
            this.pmisWsProjectCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmisWsProjectCodeLabel.Location = new System.Drawing.Point(35, 62);
            this.pmisWsProjectCodeLabel.Name = "pmisWsProjectCodeLabel";
            this.pmisWsProjectCodeLabel.Size = new System.Drawing.Size(68, 13);
            this.pmisWsProjectCodeLabel.TabIndex = 4;
            this.pmisWsProjectCodeLabel.Text = "Project Code";
            // 
            // settingPmisWsUrl
            // 
            this.settingPmisWsUrl.Location = new System.Drawing.Point(107, 33);
            this.settingPmisWsUrl.Name = "settingPmisWsUrl";
            this.settingPmisWsUrl.Size = new System.Drawing.Size(245, 20);
            this.settingPmisWsUrl.TabIndex = 3;
            // 
            // pmisWsUrlLabel
            // 
            this.pmisWsUrlLabel.AutoSize = true;
            this.pmisWsUrlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmisWsUrlLabel.Location = new System.Drawing.Point(63, 36);
            this.pmisWsUrlLabel.Name = "pmisWsUrlLabel";
            this.pmisWsUrlLabel.Size = new System.Drawing.Size(40, 13);
            this.pmisWsUrlLabel.TabIndex = 2;
            this.pmisWsUrlLabel.Text = "API Url";
            // 
            // importRegisterDataButton
            // 
            this.importRegisterDataButton.Location = new System.Drawing.Point(20, 127);
            this.importRegisterDataButton.Name = "importRegisterDataButton";
            this.importRegisterDataButton.Size = new System.Drawing.Size(149, 23);
            this.importRegisterDataButton.TabIndex = 0;
            this.importRegisterDataButton.Text = "Import Register Data";
            this.importRegisterDataButton.UseVisualStyleBackColor = true;
            this.importRegisterDataButton.Click += new System.EventHandler(this.importRegisterDataButton_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(508, 436);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 36);
            this.button3.TabIndex = 4;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(625, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 484);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingForm";
            this.Text = "Archive Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox pmisWsErrorMessage;
        private System.Windows.Forms.Button importReviewDataButton;
        private System.Windows.Forms.TextBox settingPmisWsAuthKey;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox settingPmisWsProjectCode;
        private System.Windows.Forms.Label pmisWsProjectCodeLabel;
        private System.Windows.Forms.TextBox settingPmisWsUrl;
        private System.Windows.Forms.Label pmisWsUrlLabel;
        private System.Windows.Forms.Button importRegisterDataButton;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox settingSQLiteDbLocation;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ComboBox settingDbType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox settingRegisterFolderURI;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RichTextBox documentTypeOptions;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.RichTextBox documentDisciplineOptions;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.RichTextBox documentStatusOptions;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button connectDatabaseButton;
    }
}