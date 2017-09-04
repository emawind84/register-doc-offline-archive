using pmis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis.reviewinfo
{
    public class ReviewInfoPresenter
    {
        private MainWindow _form;
        private ReviewInfoDataService _service;
        private RegisterDocumentDataService _docService;

        public ReviewInfoPresenter(MainWindow form, ReviewInfoDataService service, RegisterDocumentDataService docService)
        {
            _form = form;
            _form.OnShowRegisterDocumentInfo += ShowReviewInfoList;
            _service = service;
            _docService = docService;
        }

        private void ShowReviewInfoList(object sender, EventArgs args)
        {
            var viewForm = _form.RegisterDocumentDetailView;
            var docno = viewForm.Number;
            var version = viewForm.Version;
            RegisterDocument doc = _docService.LoadDocument(docno, version);
            DataTable dt = _service.LoadReviewInfo(doc);

            _form.ReviewInfoList = dt.AsEnumerable();

            ShowReviewFiles(doc);
        }

        private void ShowReviewFiles(RegisterDocument doc)
        {
            _form.ReviewFilesDS = _service.LoadReviewRegisterFiles(doc);
        }

    }
}
