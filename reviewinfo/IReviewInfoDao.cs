using System.Data;

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
