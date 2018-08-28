using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pmis.archive
{
    public class ArchivePresenter
    {

        public event EventHandler<Archive> OnLoadArchive;

        private Window _form;
        private ArchiveDataService _service;

        public ArchivePresenter(MainWindow form, ArchiveDataService service)
        {
            form.OnShowArchiveList += ShowArchiveList;
            this._form = form;
            this._service = service;
        }

        public ArchivePresenter(ArchiveDetailWindow form, ArchiveDataService service)
        {
            this._form = form;
            this._service = service;
            OnLoadArchive += ShowArchiveFiles;
        }

        public void ShowArchiveList(object sender=null, EventArgs e=null)
        {
            Console.WriteLine("Loading archive list...");
            MainWindow mainWindow = _form as MainWindow;

            Dictionary<string, object> criteria = new Dictionary<string, object>();
            if (!String.IsNullOrEmpty(mainWindow.SearchCriteriaArchiveFullSearch))
                criteria.Add("search_value", mainWindow.SearchCriteriaArchiveFullSearch);

            if (!String.IsNullOrEmpty(mainWindow.SearchCriteriaArchiveFilterType))
                criteria.Add("filter_type", mainWindow.SearchCriteriaArchiveFilterType);

            DataTable dt = _service.SearchArchive(criteria);

            mainWindow.ArchiveList = dt.AsEnumerable();
        }

        public void ShowArchiveDetail(string id)
        {
            ArchiveDetailWindow detailWindow = _form as ArchiveDetailWindow;
            var viewForm = detailWindow.ArchiveDetailView;

            Archive archive = _service.LoadArchive(id);
            viewForm.ArchiveDescription = archive.Description;
            viewForm.ArchiveType = archive.Type;
            viewForm.ArchiveCreated = archive.Created;
            viewForm.ArchiveMetaData = archive.MetaDataAsDictionary().AsEnumerable();

            OnLoadArchive?.Invoke(this, archive);
        }

        public void ShowArchiveFiles(object sender, Archive archive)
        {
            ArchiveDetailWindow detailWindow = _form as ArchiveDetailWindow;
            detailWindow.FileManagerItemsSource = _service.LoadArchiveFiles(archive);
        }

    }
}
