using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis.reviewinfo
{
    public class ReviewInfoPresenter
    {
        private RegisterDocumentMainForm _form;
        private ReviewInfoDataService _service;
        private RegisterDocumentDataService _docService;

        public ReviewInfoPresenter(RegisterDocumentMainForm form, ReviewInfoDataService service, RegisterDocumentDataService docService)
        {
            _form = form;
            _form.OnShowRegisterDocumentInfo += ShowReviewInfoList;
            _service = service;
            _docService = docService;
        }

        private void ShowReviewInfoList(object sender, EventArgs args)
        {
            var viewForm = _form.RegisterDocumentDetailView;
            var docno = viewForm.DocumentNumber;
            var version = viewForm.Version;
            RegisterDocument doc = _docService.LoadDocument(docno, version);
            var dt = _service.LoadReviewInfo(doc);

            _form.ReviewInfoList = dt;

            ShowReviewFiles(doc);
        }

        private void ShowReviewFiles(RegisterDocument doc)
        {
            _form.ReviewFilesDS = _service.LoadReviewRegisterFiles(doc);
        }

    }
}
