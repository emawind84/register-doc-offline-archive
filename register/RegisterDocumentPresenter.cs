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
        public event EventHandler<RegisterDocument> OnLoadRegisterDocument;

        private RegisterDocumentMainForm _form;
        private RegisterDocumentDataService _service;

        public RegisterDocumentPresenter(RegisterDocumentMainForm form, RegisterDocumentDataService service)
        {
            _form = form;
            _form.OnShowRegisterDocumentInfo += ShowRegisterDocumentInfo;
            _form.OnShowRegisterDocumentList += ShowRegisterDocuments;
            OnLoadRegisterDocument += ShowRegisterDocumentFiles;
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
            viewForm.ReviewStatus = doc.ReviewStatus;

            if(OnLoadRegisterDocument != null)
            {
                OnLoadRegisterDocument(this, doc);
            }
        }

        private void ShowRegisterDocuments(object sender, EventArgs e)
        {
            Dictionary<string, object> criteria = new Dictionary<string, object>();
            if(!String.IsNullOrEmpty(_form.SearchCriteriaDocNumber))
                criteria.Add("docno", _form.SearchCriteriaDocNumber);
            if (!String.IsNullOrEmpty(_form.SearchCriteriaTitle))
                criteria.Add("title", _form.SearchCriteriaTitle);
            if (!String.IsNullOrEmpty(_form.SearchCriteriaFromDate))
                criteria.Add("from_date", _form.SearchCriteriaFromDate);
            if (!String.IsNullOrEmpty(_form.SearchCriteriaToDate))
                criteria.Add("to_date", _form.SearchCriteriaToDate);
            if (!String.IsNullOrEmpty(_form.SearchCriteriaStatus))
                criteria.Add("status", _form.SearchCriteriaStatus);
            if (!String.IsNullOrEmpty(_form.SearchCriteriaDiscipline))
                criteria.Add("discipline", _form.SearchCriteriaDiscipline);
            if (!String.IsNullOrEmpty(_form.SearchCriteriaType))
                criteria.Add("type", _form.SearchCriteriaType);

            if(_form.SearchCriteriaAllHistory.Equals("Latest Revision Only"))
                criteria.Add("top_version", "1");

            DataTable dt = _service.SearchDocument(criteria);

            _form.DocumentList = dt;
        }

        private void ShowRegisterDocumentFiles(object sender, RegisterDocument doc)
        {
            _form.RegisterFilesDS = _service.LoadRegisterFiles(doc);
        }
    }
}
