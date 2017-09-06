using pmis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis
{
    public class RegisterDocumentDetailView
    {
        private MainWindow _form;

        public RegisterDocumentDetailView(MainWindow form) {
            _form = form;
        }

        public string Number
        {
            get { return _form.docViewDocNumber.Text; }
            set { _form.docViewDocNumber.Text = value; }
        }

        public string Title
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

        public string Status
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

        public string Version
        {
            get { return _form.docViewVersion.Text; }
            set { _form.docViewVersion.Text = value; }
        }

        public string ReviewStatus
        {
            get { return _form.docViewReviewStatus.Text; }
            set { _form.docViewReviewStatus.Text = value; }
        }

        public string Type
        {
            get { return _form.docViewType.Text; }
            set { _form.docViewType.Text = value; }
        }

        public string Discipline
        {
            get { return _form.docViewDiscipline.Text; }
            set { _form.docViewDiscipline.Text = value; }
        }

        public string Organization
        {
            get { return _form.docViewOrganization.Text; }
            set { _form.docViewOrganization.Text = value; }
        }

        public string Current
        {
            get { return _form.docViewCurrent.Text; }
            set { _form.docViewCurrent.Text = value; }
        }

        public string InternalNumber
        {
            get { return _form.docViewIntNumber.Text; }
            set { _form.docViewIntNumber.Text = value; }
        }

    }
}
