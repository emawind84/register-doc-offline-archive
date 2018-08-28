using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis.archive
{
    public class Archive
    {

        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("file_seq")]
        public String FileSeq { get; set; }

        [JsonProperty("metadata")]
        public String MetaData { get; set; }

        [JsonProperty("reg_dt")]
        public String Created { get; set; }

        public Dictionary<string, string> MetaDataAsDictionary()
        {
            Dictionary<string,string> dt = JsonConvert.DeserializeObject<Dictionary<string, string>>(MetaData);
            
            return dt;
        }

    }
}
