using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis
{
    public class RegisterDocumentDetailView
    {
        private RegisterDocumentMainForm _form;

        public RegisterDocumentDetailView(RegisterDocumentMainForm form) {
            _form = form;
        }

        public string DocumentNumber
        {
            get { return _form.docViewDocNumber.Text; }
            set { _form.docViewDocNumber.Text = value; }
        }

        public string DocumentTitle
        {
            get { return _form.docViewTitle.Text; }
            set { _form.docViewTitle.Text = value; }
        }

        public string Revision
        {
            get { return _form.docViewRevision.Text; }
            set { _form.docViewRevision.Text = value; }
        }

        public string RevisionDate
        {
            get { return _form.docViewRevisionDate.Text; }
            set { _form.docViewRevisionDate.Text = value; }
        }

        public string DocumentStatus
        {
            get { return _form.docViewStatus.Text; }
            set { _form.docViewStatus.Text = value; }
        }

        public string Registered
        {
            get { return _form.docViewRegistered.Text; }
            set { _form.docViewRegistered.Text = value; }
        }

        public string RegisteredBy
        {
            get { return _form.docViewRegisteredBy.Text; }
            set { _form.docViewRegisteredBy.Text = value; }
        }

        public string Note
        {
            get { return _form.docViewNote.Text; }
            set { _form.docViewNote.Text = value; }
        }

        public string Version {
            get { return _form.docViewVersion.Text; }
            set { _form.docViewVersion.Text = value; }
        }

    }
}
