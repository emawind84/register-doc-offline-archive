using pmis;
using pmis.profile;
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
            _form.searchDocDisciplineLabel.Content = AppConfig.i18n.Get("docdiscipline");
            _form.searchDocStatusLabel.Content = AppConfig.i18n.Get("docstatus");
            _form.searchDocTypeLabel.Content = AppConfig.i18n.Get("doctype");
            _form.searchHistoryLabel.Content = AppConfig.i18n.Get("history");
            _form.searchRegisteredByLabel.Content = AppConfig.i18n.Get("registeredby");
            _form.searchDocTitleLabel.Content = AppConfig.i18n.Get("doctitle");
            _form.searchDocNumberLabel.Content = AppConfig.i18n.Get("docno");
            _form.searchButton.Content = AppConfig.i18n.Get("search");
            _form.doclist_docno.Header = AppConfig.i18n.Get("docno");
            _form.doclist_title.Header = AppConfig.i18n.Get("title");
            _form.doclist_revision.Header = AppConfig.i18n.Get("revision");
            _form.doclist_version.Header = AppConfig.i18n.Get("version");
            //_form.doclist_current.HeaderText = AppConfig.i18n.Get("current");
            _form.doclist_revision_date.Header = AppConfig.i18n.Get("revisiondate");
            _form.doclist_organization.Header = AppConfig.i18n.Get("organization");
            _form.doclist_type.Header = AppConfig.i18n.Get("type");
            _form.doclist_review_status.Header = AppConfig.i18n.Get("reviewstatus");
            _form.doclist_registered_by.Header = AppConfig.i18n.Get("registeredby");
            _form.doclist_registered.Header = AppConfig.i18n.Get("modified");
            _form.doclist_discipline.Header = AppConfig.i18n.Get("discipline");
            _form.doclist_status.Header = AppConfig.i18n.Get("status");
            _form.detailTabPage.Header = AppConfig.i18n.Get("detail");
            _form.docNoteLabel.Header = AppConfig.i18n.Get("note");
            _form.fileManagerDataGridViewFilename.Header = AppConfig.i18n.Get("file_name");
            _form.fileManagerDataGridViewFilesize.Header = AppConfig.i18n.Get("size");
            //_form.fileManagerDataGridViewAction.DefaultCellStyle.NullValue = AppConfig.i18n.Get("show_in_folder");
            _form.detailGeneralGroupBox.Header = AppConfig.i18n.Get("general");
            _form.docNumberLabel.Content = AppConfig.i18n.Get("number");
            _form.docTitleLabel.Content = AppConfig.i18n.Get("title");
            _form.docTypeLabel.Content = AppConfig.i18n.Get("type");
            _form.docRevisionLabel.Content = AppConfig.i18n.Get("revision");
            _form.docRevisionDateLabel.Content = AppConfig.i18n.Get("revisiondate");
            _form.docVersionLabel.Content = AppConfig.i18n.Get("version");
            _form.docRegisteredLabel.Content = AppConfig.i18n.Get("registered");
            _form.docRegisteredByLabel.Content = AppConfig.i18n.Get("registeredby");
            _form.docStatusLabel.Content = AppConfig.i18n.Get("status");
            _form.docOrganizationLabel.Content = AppConfig.i18n.Get("organization");
            _form.docDisciplineLabel.Content = AppConfig.i18n.Get("discipline");
            _form.docIntNumberLabel.Content = AppConfig.i18n.Get("internalno");
            _form.reviewDetailTabPage.Header = AppConfig.i18n.Get("reviewdetail");
            //_form.groupBox8.Text = AppConfig.i18n.Get("review_supp_file");
            _form.reviewFileDataGridFilename.Header = AppConfig.i18n.Get("file_name");
            _form.reviewFileDataGridFilesize.Header = AppConfig.i18n.Get("size");
            //_form.reviewFileDataGridAction.DefaultCellStyle.NullValue = AppConfig.i18n.Get("show_in_folder");
            //_form.groupBox7.Text = AppConfig.i18n.Get("review_info");
            _form.reviewDataGridViewReviewDate.Header = AppConfig.i18n.Get("reviewed");
            _form.reviewDataGridViewReviewedBy.Header = AppConfig.i18n.Get("reviewed_by");
            _form.reviewDataGridViewReviewStatus.Header = AppConfig.i18n.Get("review_outcome");
            _form.reviewDataGridViewReviewNote.Header = AppConfig.i18n.Get("comment");
            _form.docReviewStatusLabel.Content = AppConfig.i18n.Get("review_outcome");
            _form.pictureViewerTabPage.Header = AppConfig.i18n.Get("picture_viewer");
            _form.pictureDataGridViewFileName.Header = AppConfig.i18n.Get("file_name");
            _form.pictureDataGridViewFileSize.Header = AppConfig.i18n.Get("file_size");
        }

        public void SetSettingFormLanguage(SettingWindow _form)
        {
            _form.generalSettingsTabItem.Header = AppConfig.i18n.Get("general_settings");
            _form.settingResetGroupBox.Header = AppConfig.i18n.Get("reset_settings");
            _form.settingsResetButton.Content = AppConfig.i18n.Get("reset_settings");
            _form.restoreSettingsMessage.Content = AppConfig.i18n.Get("restore_settings_message");
            _form.registerFolderLocationLabel.Content = AppConfig.i18n.Get("folder_location");
            _form.registerSettingsGroupBox.Header = "Register Settings";
            _form.settingStatusTabItem.Header = "Status items";
            _form.settingDisciplineTabItem.Header = "Discipline items";
            _form.settingTypeTabItem.Header = "Type items";
            _form.searchOptionsGroupBox.Header = "Search Options";
            _form.otherSettingsTabItem.Header = "Other Settings";
            _form.internationalSettingsGroupBox.Header = " International Settings";
            _form.settingLanguageLabel.Content = AppConfig.i18n.Get("language");
            _form.databaseSettingsTabItem.Header = "Database Settings";
            _form.sqliteSettingsGroupBox.Header = "SQLite Settings";
            _form.settingDatabaseLocationLabel.Content = "Database File Location";
            _form.databaseSettingsGroupBox.Header = "Database Settings";
            _form.settingDatabaseTypeLabel.Content = "Database Type";
            _form.dataImportSettingsTabItem.Header = "Data Import Settings";
            _form.dataImportSettingsGroupBox.Header = "Web Service Settings";
            _form.projectCodeLabel.Content = "Project Code";
            _form.apiUrlLabel.Content = "API Url";
            _form.authenticationKeyLabel.Content = "Authentication Key";
            _form.importReviewDataButton.Content = "Import Review Data";
            _form.importRegisterDataButton.Content = "Import Register Data";
            _form.productInfoLabel.Text = AppConfig.i18n.Get("version");
            _form.settingReviewCountLabel.Content = AppConfig.i18n.Get("review_info");
            _form.settingDocumentCountLabel.Content = AppConfig.i18n.Get("document");
            _form.pictureFolderLocationLabel.Content = AppConfig.i18n.Get("folder_location");
        }

        public void SetTokenRequestFormLanguage(TokenRequestWindow form)
        {
            form.requestTokenButton.Content = AppConfig.i18n.Get("request_token");
            form.passwordLabel.Content = AppConfig.i18n.Get("password");
            form.usernameLabel.Content = AppConfig.i18n.Get("username");
            form.passwordBase64Encoded.Content = AppConfig.i18n.Get("send_pwd_encoded");
        }

        public void SetNewProfileFormLanguage(NewProfileWindow form)
        {
            form.Title = AppConfig.i18n.Get("new_profile");
            form.profileNameLabel.Content = AppConfig.i18n.Get("profile_name");
            form.createProfileCreateButton.Content = AppConfig.i18n.Get("create_profile");
        }
    }
}
