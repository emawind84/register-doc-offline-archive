using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_test
{
    public class RegisterDocumentDetailView
    {
        private RegisterDocumentMainForm _form;

        public RegisterDocumentDetailView(RegisterDocumentMainForm form) {
            _form = form;
        }

        public string DocumentNumber
        {
            get { return _form.docViewLabelDocno.Text; }
            set { _form.docViewLabelDocno.Text = value; }
        }

        public string DocumentTitle
        {
            get { return _form.docViewLabelTitle.Text; }
            set { _form.docViewLabelTitle.Text = value; }
        }

        public string DocumentRevision
        {
            get { return _form.docViewLabelRevision.Text; }
            set { _form.docViewLabelRevision.Text = value; }
        }

        public string DocumentStatus
        {
            get { return _form.docViewLabelStatus.Text; }
            set { _form.docViewLabelStatus.Text = value; }
        }

    }
}
