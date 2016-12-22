using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace pmis
{
    class RegisterDocumentPresenter
    {
        private RegisterDocumentMainForm _form;
        private RegisterDocumentDataService _service;

        public RegisterDocumentPresenter(RegisterDocumentMainForm form, RegisterDocumentDataService service)
        {
            _form = form;
            _form.OnShowRegisterDocumentInfo += ShowRegisterDocumentInfo;
            _form.OnShowRegisterDocumentList += ShowRegisterDocumentList;
            _service = service;
        }

        private void ShowRegisterDocumentInfo(object sender, EventArgs e) {
            var viewForm = _form.RegisterDocumentDetailView;
            var docno = _form.RegisterDocumentDetailView.DocumentNumber;
            var version = _form.RegisterDocumentDetailView.Version;
            RegisterDocument doc = _service.LoadDocument(docno, version);

            viewForm.DocumentNumber = doc.DocumentNumber;
            viewForm.DocumentTitle = doc.Title;
            viewForm.Revision = doc.Revision;
            viewForm.RevisionDate = doc.RevisionDate;
            viewForm.DocumentStatus = doc.Status;
            viewForm.Registered = doc.Registered;
            viewForm.RegisteredBy = doc.RegisteredBy;
            viewForm.Note = doc.Note;

            showFileList(doc);
        }

        private void ShowRegisterDocumentList(object sender, EventArgs e)
        {
            Dictionary<string, object> criteria = new Dictionary<string, object>();
            criteria.Add("docno", _form.SearchCriteriaDocNumber);
            criteria.Add("from_date", _form.SearchCriteriaFromDate);
            
            DataTable dt = _service.SearchDocument(criteria);

            _form.DocumentList = dt;
        }

        private void showFileList(RegisterDocument doc)
        {
            string targetDirectory = "register/" + doc.DocumentNumber + "/" + doc.Version;
            string[] files = new string[0];
            try
            {
                files = Directory.GetFiles(targetDirectory);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Directory not found: {0}", targetDirectory);
            }

            var registerFiles = new List<RegisterFile>();
            foreach (string fileName in files)
            {
                var regfile = new RegisterFile(fileName);
                registerFiles.Add(regfile);
                //fileManagerBS.Add(regfile);
                Console.WriteLine("Processed file: {0}", regfile);
            }
            _form.DocumentFilesDataSource = registerFiles;
        }
    }
}
