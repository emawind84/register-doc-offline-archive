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
        private RegisterDocumentView _form;
        private RegisterDocumentDataService _service;

        public RegisterDocumentPresenter(RegisterDocumentView form, RegisterDocumentDataService service)
        {
            _form = form;
            _form.OnShowRegisterDocumentInfo += ShowRegisterDocumentInfo;
            _form.OnShowRegisterDocumentList += ShowRegisterDocumentList;
            _service = service;
        }

        private void ShowRegisterDocumentInfo(object sender, EventArgs e) {
            RegisterDocument doc = _service.GetByDocumentNumber(_form.DocumentNumber);

            _form.DocumentNumber = doc.DocumentNumber;
            _form.DocumentTitle = doc.Title;
        }

        private void ShowRegisterDocumentList(object sender, EventArgs e)
        {
            DataTable dt = _service.SearchDocument(_form.SearchText);

            _form.DocumentList = dt;
        }
    }
}
