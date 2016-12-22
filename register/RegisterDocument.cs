using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis
{
    public class RegisterDocument
    {

        [JsonProperty("matrl_draw_no")]
        public string DocumentNumber { get; set; }

        [JsonProperty("matrl_name")]
        public string Title { get; set; }

        [JsonProperty("revision")]
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

        [JsonProperty("reg_name")]
        public string RegisteredBy { get; set; }

        [JsonProperty("long_reg_date")]
        public string Registered { get; set; }

        [JsonProperty("int_cd")]
        public string InternalNumber { get; set; }

        [JsonProperty("reg_entprs_nm")]
        public string Organization { get; set; }

        [JsonProperty("top_revision")]
        public string Current { get; set; }

        [JsonProperty("descr")]
        public string Note { get; set; }

        public override string ToString()
        {
            return String.Format("Doocument [{0}, ver={1}]",
                DocumentNumber,
                Version );

        }
    }
}
