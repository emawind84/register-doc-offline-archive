using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using pmis.register;
using System.Net.Http;

namespace pmis
{
    public class RegisterDocumentDataService
    {

        private static string projectFolder = AppDomain.CurrentDomain.BaseDirectory;

        private IRegisterDocumentDao daoService;

        public event EventHandler<RegisterDocument> RegisterDocumentImported;
        public event EventHandler ImportComplete;
        public event ErrorEventHandler ImportError;

        public RegisterDocumentDataService(IRegisterDocumentDao daoService) {
            this.daoService = daoService;
        }

        public DataTable SearchDocument(Dictionary<string,object> criteria = null)
        {
            try {
                return daoService.SearchDocument(criteria);
            }
            catch(Exception e)
            {
                e.Log();
                throw e;
            }
        }

        public RegisterDocument LoadDocument(string docno, string version = null) {
            try
            {
                return daoService.LoadDocument(docno, version);
            }
            catch (Exception e)
            {
                e.Log();
                throw e;
            }
        }

        public List<RegisterFile> LoadRegisterFiles(RegisterDocument doc) {
            string registerURI = Properties.Settings.Default.register_folder_uri;
            registerURI = String.IsNullOrEmpty(registerURI) ? "register" : registerURI;

            string targetDirectory = registerURI + "/" +
                RegisterFile.SanitizeName(doc.DocumentNumber) + "/" + doc.Version;
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
            }
            return registerFiles;
        }

        public int LoadRegisterCount()
        {
            try
            {
                return daoService.LoadRegisterCount();
            }
            catch (Exception e)
            {
                e.Log();
                throw e;
            }
        }

        public void DeleteRegisterData()
        {
            try
            {
                daoService.DeleteRegisterData();
            }
            catch (Exception e)
            {
                e.Log();
                throw e;
            }
        }

        public void ImportCSVFile(string csvfile)
        {
            FileStream fs = new FileStream(csvfile, FileMode.Open, FileAccess.Read);
            List<RegisterDocument> docs = new List<RegisterDocument>();
            using (StreamReader reader = new StreamReader(fs, Encoding.Default))
            {
                reader.ReadLine();  // skip header
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    RegisterDocument d = new RegisterDocument();
                    d.DocumentNumber = values[4];
                    d.Title = values[5];
                    d.Discipline = values[6];
                    d.Revision = values[7];
                    d.Version = values[8];
                    d.Status = values[9];
                    
                    docs.Add(d);
                }
            }

            ImportData(docs);
        }

        public async void ImportFromWebService() {
            var apiurl = Properties.Settings.Default.pmis_api_url;
            var project = Properties.Settings.Default.pmis_project_code;
            var authkey = Properties.Settings.Default.pmis_auth_key;
            string url = String.Format("{0}/api/register/docs.action", apiurl);

            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string> {
                        { "forward", "json" },
                        { "srch_show_hist", "1" },
                        { "pjt_cd", project },
                        { "access_token", authkey },
                        { "pageScale", "200" },
                        { "pageNo", "1" },
                        { "login_locale", "ko_KR" }
                    };

                    var page = 1;
                    var total = 999;
                    while (page <= total)
                    {
                        values["pageNo"]= "" + page;
                        var content = new FormUrlEncodedContent(values);
                        var response = await client.PostAsync(url, content);
                        response.EnsureSuccessStatusCode();
                        var responseString = await response.Content.ReadAsStringAsync();
                        PmisJsonResponse<RegisterDocument> dt = JsonConvert.DeserializeObject<PmisJsonResponse<RegisterDocument>>(responseString);
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
                ImportError?.Invoke(this, new ErrorEventArgs(ex));
            }
            finally
            {
                ImportComplete?.Invoke(this, EventArgs.Empty);
            }

        }

        protected virtual void OnImportComplete(EventArgs e)
        {
            ImportComplete?.Invoke(this, e);
        }

        protected virtual void OnImportError(ErrorEventArgs e)
        {
            ImportError?.Invoke(this, e);
        }

        protected virtual void OnRegisterDocumentImported(RegisterDocument d)
        {
            RegisterDocumentImported?.Invoke(this, d);
        }

        private void ImportData(List<RegisterDocument> docs)
        {
            try
            {
                foreach (RegisterDocument d in docs)
                {
                    daoService.ImportDocumentData(d);
                    LogUtil.Log(String.Format("Adding register data: {0}", d));
                    OnRegisterDocumentImported(d);
                }
            }
            catch (Exception e)
            {
                e.Log();
                throw e;
            }
        }

    }
}
