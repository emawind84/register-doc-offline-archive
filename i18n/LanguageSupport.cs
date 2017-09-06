using pmis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis.i18n
{
    public class LanguageSupport
    {

        public LanguageSupport() { }
        
        public void SetMainFromLanguage(MainWindow _form)
        {
            _form.registerTabPage.Header = AppConfig.i18n.Get("register");
            _form.searchClearButton.Content = AppConfig.i18n.Get("clear");
            //_form.label9.Text = AppConfig.i18n.Get("docdiscipline");
            //_form.label17.Text = AppConfig.i18n.Get("docstatus");
            //_form.label15.Text = AppConfig.i18n.Get("doctype");
            //_form.label19.Text = AppConfig.i18n.Get("history");
            //_form.label11.Text = AppConfig.i18n.Get("registeredby");
            //_form.label18.Text = AppConfig.i18n.Get("doctitle");
            //_form.label16.Text = AppConfig.i18n.Get("docno");
            //_form.searchButton.Text = AppConfig.i18n.Get("search");
            //_form.doclist_docno.HeaderText = AppConfig.i18n.Get("docno");
            //_form.doclist_title.HeaderText = AppConfig.i18n.Get("title");
            //_form.doclist_revision.HeaderText = AppConfig.i18n.Get("revision");
            //_form.doclist_version.HeaderText = AppConfig.i18n.Get("version");
            //_form.doclist_current.HeaderText = AppConfig.i18n.Get("current");
            //_form.doclist_revision_date.HeaderText = AppConfig.i18n.Get("revisiondate");
            //_form.doclist_organization.HeaderText = AppConfig.i18n.Get("organization");
            //_form.doclist_type.HeaderText = AppConfig.i18n.Get("type");
            //_form.doclist_review_status.HeaderText = AppConfig.i18n.Get("reviewstatus");
            //_form.doclist_registered_by.HeaderText = AppConfig.i18n.Get("registeredby");
            //_form.doclist_registered.HeaderText = AppConfig.i18n.Get("modified");
            //_form.doclist_discipline.HeaderText = AppConfig.i18n.Get("discipline");
            //_form.doclist_status.HeaderText = AppConfig.i18n.Get("status");
            //_form.detailTabPage.Text = AppConfig.i18n.Get("detail");
            //_form.groupBox5.Text = AppConfig.i18n.Get("note");
            //_form.fileManagerDataGridViewFilename.HeaderText = AppConfig.i18n.Get("file_name");
            //_form.fileManagerDataGridViewFilesize.HeaderText = AppConfig.i18n.Get("size");
            //_form.fileManagerDataGridViewAction.DefaultCellStyle.NullValue = AppConfig.i18n.Get("show_in_folder");
            //_form.groupBox1.Text = AppConfig.i18n.Get("general");
            //_form.label1.Text = AppConfig.i18n.Get("number") + ":";
            //_form.label2.Text = AppConfig.i18n.Get("title") + ":";
            //_form.label27.Text = AppConfig.i18n.Get("type") + ":";
            //_form.label5.Text = AppConfig.i18n.Get("revision") + ":";
            //_form.label29.Text = AppConfig.i18n.Get("revisiondate") + ":";
            //_form.label4.Text = AppConfig.i18n.Get("version") + ":";
            //_form.label6.Text = AppConfig.i18n.Get("registered") + ":";
            //_form.label7.Text = AppConfig.i18n.Get("registeredby") + ":";
            //_form.label3.Text = AppConfig.i18n.Get("status") + ":";
            //_form.label23.Text = AppConfig.i18n.Get("organization") + ":";
            //_form.label31.Text = AppConfig.i18n.Get("discipline") + ":";
            //_form.label25.Text = AppConfig.i18n.Get("internalno") + ":";
            //_form.reviewDetailTabPage.Text = AppConfig.i18n.Get("reviewdetail");
            //_form.groupBox8.Text = AppConfig.i18n.Get("review_supp_file") + ":";
            //_form.reviewFileDataGridFilename.HeaderText = AppConfig.i18n.Get("file_name");
            //_form.reviewFileDataGridFilesize.HeaderText = AppConfig.i18n.Get("size");
            //_form.reviewFileDataGridAction.DefaultCellStyle.NullValue = AppConfig.i18n.Get("show_in_folder");
            //_form.groupBox7.Text = AppConfig.i18n.Get("review_info");
            //_form.reviewDataGridViewReviewDate.HeaderText = AppConfig.i18n.Get("reviewed");
            //_form.reviewDataGridViewReviewedBy.HeaderText = AppConfig.i18n.Get("reviewed_by");
            //_form.reviewDataGridViewReviewStatus.HeaderText = AppConfig.i18n.Get("review_outcome");
            //_form.reviewDataGridViewReviewNote.HeaderText = AppConfig.i18n.Get("comment");
            //_form.label8.Text = AppConfig.i18n.Get("review_outcome");
            //_form.pictureViewerTabPage.Text = AppConfig.i18n.Get("picture_viewer");
            //_form.pictureDataGridViewFileName.HeaderText = AppConfig.i18n.Get("file_name");
            //_form.pictureDataGridViewFileSize.HeaderText = AppConfig.i18n.Get("file_size");
        }

        public void SetSettingFormLanguage(SettingWindow _form)
        {
            //_form.tabPage3.Text = AppConfig.i18n.Get("general_settings");
            //_form.groupBox3.Text = AppConfig.i18n.Get("reset_settings");
            //_form.settingsResetButton.Text = AppConfig.i18n.Get("reset_settings");
            //_form.label2.Text = AppConfig.i18n.Get("restore_settings_message");
            //_form.label13.Text = AppConfig.i18n.Get("folder_location") + ":";
            //_form.groupBox11.Text = "Register Settings";
            //_form.tabPage7.Text = "Status items";
            //_form.tabPage6.Text = "Discipline items";
            //_form.tabPage5.Text = "Type items";
            //_form.groupBox1.Text = "Search Options";
            //_form.tabPage4.Text = "International Settings";
            //_form.groupBox2.Text = " International Settings";
            //_form.label1.Text = AppConfig.i18n.Get("language") + ":";
            //_form.tabPage2.Text = "Database Settings";
            //_form.groupBox10.Text = "SQLite Settings";
            //_form.label12.Text = "Database File Location:";
            //_form.groupBox9.Text = "Database Settings";
            //_form.label10.Text = "Database Type:";
            //_form.tabPage1.Text = "Data Import Settings";
            //_form.groupBox6.Text = "Web Service Settings";
            //_form.pmisWsProjectCodeLabel.Text = "Project Code:";
            //_form.pmisWsUrlLabel.Text = "API Url:";
            //_form.label11.Text = "Authentication Key:";
            //_form.importReviewDataButton.Text = "Import Review Data";
            //_form.importRegisterDataButton.Text = "Import Register Data";
            //_form.productInfoLabel.Text = AppConfig.i18n.Get("version");
        }
    }
}
