using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis.reviewinfo
{
    public interface ReviewInfoDaoInterface
    {
        DataTable LoadReviewInfo(string docno, string version);

        void DeleteReviewInfo();

        void ImportReviewInfoData(List<ReviewInfo> docs);
    }
}
