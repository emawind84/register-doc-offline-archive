using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

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
            viewForm.Discipline = doc.Discipline;

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
            if (_form.SearchCriteriaFromDate.HasValue)
                criteria.Add("from_date", _form.SearchCriteriaFromDate.Value.ToString("yyyy-MM-dd"));
            if (_form.SearchCriteriaToDate.HasValue)
                criteria.Add("to_date", _form.SearchCriteriaToDate.Value.ToString("yyyy-MM-dd"));
            if (!String.IsNullOrEmpty(_form.SearchCriteriaStatus))
                criteria.Add("status", _form.SearchCriteriaStatus);
            if (!String.IsNullOrEmpty(_form.SearchCriteriaDiscipline))
                criteria.Add("discipline", _form.SearchCriteriaDiscipline);
            if (!String.IsNullOrEmpty(_form.SearchCriteriaRegisteredBy))
                criteria.Add("registered_by", _form.SearchCriteriaRegisteredBy);
            if (!String.IsNullOrEmpty(_form.SearchCriteriaType))
            {
                criteria.Add("type", _form.SearchCriteriaType);
                LogUtil.Log("Searching for type " + _form.SearchCriteriaType);
            }

            if(_form.SearchCriteriaAllHistory.Equals("Latest Revision Only"))
                criteria.Add("top_version", "1");

            DataTable dt = _service.SearchDocument(criteria);

            _form.DocumentList = dt.AsEnumerable();
        }

        private void ShowRegisterDocumentFiles(object sender, RegisterDocument doc)
        {
            _form.RegisterFilesDS = _service.LoadRegisterFiles(doc);
        }

        //private IEnumerable<RegisterDocument> GetEnumerator(DataTable dt)
        //{
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        // Return the current element and then on next function call 
        //        // resume from next element rather than starting all over again;
        //        yield return new RegisterDocument {
        //            DocumentNumber = Convert.ToString(row["docno"])
        //        };
        //    }
        //}
    }
}
