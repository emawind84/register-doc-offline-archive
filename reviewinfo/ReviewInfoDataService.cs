using Newtonsoft.Json;
using pmis.reviewinfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace pmis
{
    public class ReviewInfoDataService
    {
        private static string projectFolder = AppDomain.CurrentDomain.BaseDirectory;

        public event EventHandler<List<ReviewInfo>> ImportCompleteHandler;
        public event ErrorEventHandler ImportErrorHandler;

        private ReviewInfoDaoInterface _dao;

        public ReviewInfoDataService(ReviewInfoDaoInterface dao)
        {
            _dao = dao;
        }

        public DataTable LoadReviewInfo(string docno, string version)
        {
            return _dao.LoadReviewInfo(docno, version);
        }

        public void DeleteReviewInfo()
        {
            _dao.DeleteReviewInfo();
        }

        public void ImportData(List<ReviewInfo> docs)
        {
            _dao.ImportReviewInfoData(docs);
        }

        public async void ImportFromWebService()
        {
            var apiurl = Properties.Settings.Default.pmis_api_url;
            var project = Properties.Settings.Default.pmis_project_code;
            var authkey = Properties.Settings.Default.pmis_auth_key;
            string url = String.Format("http://localhost:8003/Core/CoreList.action", apiurl);

            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string> {
                        { "user-forward", "json" },
                        { "user-query", "doc.register.etc.selectDocumentReviewInfo" },
                        { "pjt_cd", project },
                        { "access_token", authkey }
                    };

                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();
                    var responseString = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine(responseString);
                    PmisJsonResponse<ReviewInfo> dt = JsonConvert.DeserializeObject<PmisJsonResponse<ReviewInfo>>(responseString);
                    ImportData(dt.List);

                    if (ImportCompleteHandler != null)
                    {
                        ImportCompleteHandler(this, dt.List);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ImportErrorHandler != null)
                {
                    ImportErrorHandler(this, new ErrorEventArgs(ex));
                }
                Console.WriteLine(ex);
            }

            //try
            //{
            //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            //    WebResponse response = request.GetResponse();
            //    using (Stream responseStream = response.GetResponseStream())
            //    {
            //        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            //        var result = reader.ReadToEnd();
            //        PmisJsonResponse<RegisterDocument> dt = JsonConvert.DeserializeObject<PmisJsonResponse<RegisterDocument>>(result);
            //        ImportData(dt.List);

            //        if (ImportCompleteHandler != null)
            //        {
            //            ImportCompleteHandler(this, dt.List);
            //        }
            //    }
            //}
            //catch (NotSupportedException ex)
            //{
            //    if (ImportErrorHandler != null)
            //    {
            //        ImportErrorHandler(this, new ErrorEventArgs(ex));
            //    }
            //}
            //catch (WebException ex)
            //{
            //    WebResponse errorResponse = ex.Response;
            //    using (Stream responseStream = errorResponse.GetResponseStream())
            //    {
            //        StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
            //        String errorText = reader.ReadToEnd();
            //        // log errorText
            //    }
            //    if (ImportErrorHandler != null)
            //    {
            //        ImportErrorHandler(this, new ErrorEventArgs(ex));
            //    }

            //    //throw;
            //}
        }
    }
}
