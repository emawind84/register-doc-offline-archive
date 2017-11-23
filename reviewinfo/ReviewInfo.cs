using Newtonsoft.Json;
using System;

namespace pmis.reviewinfo
{
    public class ReviewInfo
    {

        [JsonProperty("matrl_draw_no")]
        public string DocumentNumber { get; set; }

        [JsonProperty("version")]
        public string DocumentVersion { get; set; }

        [JsonProperty("review_status_nm")]
        public string ReviewStatus { get; set; }

        [JsonProperty("review_note")]
        public string ReviewNote { get; set; }

        [JsonProperty("review_date")]
        public string ReviewDate { get; set; }

        [JsonProperty("reviewer_nm")]
        public string ReviewedBy { get; set; }

        public override string ToString()
        {
            return String.Format("ReviewInfo [{0}, ver={1}, {2}, {3}, {4}]", 
                DocumentNumber, 
                DocumentVersion, 
                ReviewDate, 
                ReviewedBy, 
                ReviewStatus);
        }
    }
}
