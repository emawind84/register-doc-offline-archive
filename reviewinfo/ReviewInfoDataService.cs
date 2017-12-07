using Newtonsoft.Json;
using pmis.reviewinfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Http;

namespace pmis
{
    public class ReviewInfoDataService
    {
        private static string projectFolder = AppDomain.CurrentDomain.BaseDirectory;

        public event EventHandler<ReviewInfo> ReviewInfoImported;
        public event EventHandler ImportComplete;
        public event ErrorEventHandler ImportError;

        private IReviewInfoDao _dao;

        public ReviewInfoDataService(IReviewInfoDao dao)
        {
            _dao = dao;
        }

        public DataTable LoadReviewInfo(RegisterDocument doc)
        {
            try
            {
                return _dao.LoadReviewInfo(doc);
            }
            catch (Exception e)
            {
                e.Log();
                throw e;
            }
        }

        public void DeleteReviewInfo()
        {
            try
            {
                _dao.DeleteReviewInfo();
            }
            catch (Exception e)
            {
                e.Log();
                throw e;
            }
        }

        public List<RegisterFile> LoadReviewRegisterFiles(RegisterDocument doc)
        {
            string registerURI = Properties.Settings.Default.register_folder_uri;
            registerURI = String.IsNullOrEmpty(registerURI) ? "register" : registerURI;

            string targetDirectory = registerURI + "/" + 
                RegisterFile.SanitizeName(doc.DocumentNumber) + 
                "/" + doc.Version + "/extra";
            string[] files = new string[0];
            try
            {
                LogUtil.Log(String.Format("Looking for files... {0}", targetDirectory));
                files = Directory.GetFiles(targetDirectory);
            }
            catch (DirectoryNotFoundException e)
            {
                e.Log();
            }

            var registerFiles = new List<RegisterFile>();
            foreach (string fileName in files)
            {
                var regfile = new RegisterFile(fileName);
                registerFiles.Add(regfile);
                LogUtil.Log(String.Format("Processed file: {0}", regfile));
            }
            return registerFiles;
        }

        public int LoadReviewCount()
        {
            try
            {
                return _dao.LoadReviewInfoCount();
            }
            catch (Exception e)
            {
                e.Log();
                throw e;
            }
        }

        public void ImportData(List<ReviewInfo> docs)
        {
            try
            {
                foreach (ReviewInfo d in docs)
                {
                    _dao.ImportReviewInfoData(d);
                    //Console.WriteLine("Adding review data: {0}", d);
                    OnReviewInfoImported(d);
                }
            }
            catch (Exception e)
            {
                e.Log();
                throw e;
            }
        }

        public async void ImportFromWebService()
        {
            var apiurl = Properties.Settings.Default.pmis_api_url;
            var project = Properties.Settings.Default.pmis_project_code;
            var authkey = Properties.Settings.Default.pmis_auth_key;
            string url = String.Format("{0}/api/register/reviews.action", apiurl);

            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string> {
                        { "pjt_cd", project },
                        { "access_token", authkey },
                        { "pageScale", "200" },
                        { "pageNo", "1" }
                    };

                    var page = 1;
                    var total = 999;
                    while (page <= total)
                    {
                        values["pageNo"] = "" + page;
                        var content = new FormUrlEncodedContent(values);
                        var response = await client.PostAsync(url, content);
                        response.EnsureSuccessStatusCode();
                        var responseString = await response.Content.ReadAsStringAsync();
                        PmisJsonResponse<ReviewInfo> dt = JsonConvert.DeserializeObject<PmisJsonResponse<ReviewInfo>>(responseString);
                        
                        ImportData(dt.List);

                        page = dt.PageInfo.CurrentPage + 1;
                        total = dt.PageInfo.TotalPages;
                        LogUtil.Log(dt.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Log().Display();
                OnImportError(new ErrorEventArgs(ex));
            }
            finally
            {
                OnImportComplete(EventArgs.Empty);
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

        protected virtual void OnImportComplete(EventArgs e) {
            EventHandler handler = ImportComplete;
            if(handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnImportError(ErrorEventArgs e)
        {
            ErrorEventHandler handler = ImportError;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnReviewInfoImported(ReviewInfo d)
        {
            EventHandler<ReviewInfo> handler = ReviewInfoImported;
            if (handler != null)
            {
                handler(this, d);
            }
        }

    }
}
