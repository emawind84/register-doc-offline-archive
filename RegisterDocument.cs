using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_test
{
    class RegisterDocument
    {

        [JsonProperty("matrl_draw_no")]
        public string DocumentNumber { get; set; }

        [JsonProperty("matrl_name")]
        public string Title { get; set; }

        public string Revision { get; set; }

        [JsonProperty("hist_date")]
        public string RevisionDate { get; set; }

        [JsonProperty("discipline_nm")]
        public string Discipline { get; set; }

        public string Version { get; set; }

        [JsonProperty("status_nm")]
        public string Status { get; set; }

        [JsonProperty("fbs_cds_nm")]
        public string Type { get; set; }

        [JsonProperty("review_status_nm")]
        public string ReviewStatus { get; set; }

        [JsonProperty("mod_name")]
        public string ModifiedBy { get; set; }

        [JsonProperty("modit")]
        public string Modified { get; set; }

        [JsonProperty("int_cd")]
        public string InternalNumber { get; set; }

        [JsonProperty("reg_entprs_nm")]
        public string Organization { get; set; }

    }
}
