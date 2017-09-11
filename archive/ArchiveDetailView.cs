using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis.archive
{
    public class ArchiveDetailView
    {

        private ArchiveDetailWindow _form;

        public string ArchiveDescription {
            get { return _form.archiveDescriptionTextBlock.Text; }
            set { _form.archiveDescriptionTextBlock.Text = value; }
        }

        public string ArchiveType
        {
            get { return _form.archiveTypeTextBlock.Text; }
            set { _form.archiveTypeTextBlock.Text = value; }
        }

        public IEnumerable ArchiveMetaData
        {
            set { _form.metaDataDataGrid.ItemsSource = value; }
        }

        public string ArchiveCreated
        {
            set { _form.archiveCreatedTextBlock.Text = value; }
        }

        public ArchiveDetailView(ArchiveDetailWindow form)
        {
            this._form = form;
        }

    }
}
