using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace pmis
{
    public class PmisJsonResponse<T>
    {
        public List<T> List
        {
            get; set;
        }

        [JsonProperty("pageUtil")]
        public PageInfo PageInfo { get; set; }

        public override string ToString()
        {
            return String.Format("Response [{0}, {1}]", List, PageInfo);
        }
    }

    public class PageInfo
    {

        [JsonProperty("last")]
        public int TotalPages { get; set; }

        [JsonProperty("current")]
        public int CurrentPage { get; set; }

        public override string ToString()
        {
            return String.Format("PageInfo [total: {0}, current: {1}]", TotalPages, CurrentPage);
        }
    }
}
