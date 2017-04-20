using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis.reviewinfo
{
    public interface IReviewInfoDao
    {
        DataTable LoadReviewInfo(RegisterDocument doc);

        void DeleteReviewInfo();

        void ImportReviewInfoData(ReviewInfo d);

        int LoadReviewInfoCount();
    }
}
