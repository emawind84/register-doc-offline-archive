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

        public ReviewInfoPresenter(RegisterDocumentMainForm form, ReviewInfoDataService service)
        {
            _form = form;
            _form.OnShowRegisterDocumentInfo += ShowReviewInfoList;
            _service = service;
        }

        private void ShowReviewInfoList(object sender, EventArgs args)
        {
            var viewForm = _form.RegisterDocumentDetailView;
            var docno = _form.RegisterDocumentDetailView.DocumentNumber;
            var version = _form.RegisterDocumentDetailView.Version;
            var dt = _service.LoadReviewInfo(docno, version);

            _form.ReviewInfoList = dt;
        }

    }
}
