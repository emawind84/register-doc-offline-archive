using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using pmis;

namespace pmis
{
    class RegisterDocumentPresenter
    {
        public event EventHandler<RegisterDocument> OnLoadRegisterDocument;

        private MainWindow _form;
        private RegisterDocumentDataService _service;

        public RegisterDocumentPresenter(MainWindow form, RegisterDocumentDataService service)
        {
            _form = form;
            _form.OnShowRegisterDocumentInfo += ShowRegisterDocumentInfo;
            _form.OnShowRegisterDocumentList += ShowRegisterDocuments;
            OnLoadRegisterDocument += ShowRegisterDocumentFiles;
            _service = service;
        }

        private void ShowRegisterDocumentInfo(object sender, EventArgs e) {
            var viewForm = _form.RegisterDocumentDetailView;
            var docno = _form.RegisterDocumentDetailView.Number;
            var version = _form.RegisterDocumentDetailView.Version;
            RegisterDocument doc = _service.LoadDocument(docno, version);
            
            viewForm.Number = doc.DocumentNumber;
            viewForm.Title = doc.Title;
            viewForm.Revision = doc.Revision;
            viewForm.RevisionDate = doc.RevisionDate;
            viewForm.Status = doc.Status;
            viewForm.Registered = doc.Registered;
            viewForm.RegisteredBy = doc.RegisteredBy;
            viewForm.Note = doc.Note;
            viewForm.ReviewStatus = doc.ReviewStatus;
            viewForm.Version = doc.Version;
            viewForm.Type = doc.Type;
            viewForm.Organization = doc.Organization;
            viewForm.Current = doc.Current == "1" ? "(Top Version)" : "(Old Version)";
            viewForm.InternalNumber = doc.InternalNumber;

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
            if (!String.IsNullOrEmpty(_form.SearchCriteriaRegisteredBy))
                criteria.Add("registered_by", _form.SearchCriteriaRegisteredBy);
            if (!String.IsNullOrEmpty(_form.SearchCriteriaType))
            {
                var value = _form.SearchCriteriaType;
                String[] values = value.Split('>');
                criteria.Add("type", values[values.Length - 1].Trim());
            }

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
