using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace db_test
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
            var docView = _form.RegisterDocumentDetailView;
            RegisterDocument doc = _service.GetByDocumentNumber(docView.DocumentNumber);

            docView.DocumentNumber = doc.DocumentNumber;
            docView.DocumentTitle = doc.Title;
            docView.DocumentRevision = doc.Revision;
            docView.DocumentStatus = doc.Status;
        }

        private void ShowRegisterDocumentList(object sender, EventArgs e)
        {
            DataTable dt = _service.SearchDocument();

            _form.DocumentList = dt;
        }
    }
}
