using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Net;
using Newtonsoft.Json;
using pmis.register;

namespace pmis
{
    public class RegisterDocumentDataService
    {

        private static string projectFolder = AppDomain.CurrentDomain.BaseDirectory;

        private IRegisterDocumentDao daoService;

        public event EventHandler ImportCompleteHandler;
        public event ErrorEventHandler ImportErrorHandler;

        public RegisterDocumentDataService(IRegisterDocumentDao daoService) {
            this.daoService = daoService;
        }

        public DataTable SearchDocument(Dictionary<string,object> criteria = null)
        {
            return daoService.SearchDocument(criteria);
        }

        public RegisterDocument LoadDocument(string docno, string version = null) {
            return daoService.LoadDocument(docno, version);
        }

        public List<RegisterFile> LoadRegisterFiles(RegisterDocument doc) {
            string registerURI = Properties.Settings.Default.register_folder_uri;
            registerURI = String.IsNullOrEmpty(registerURI) ? "register" : registerURI;

            string targetDirectory = registerURI + "/" +
                RegisterFile.SanitizeName(doc.DocumentNumber) + "/" + doc.Version;
            string[] files = new string[0];
            try
            {
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
                Console.WriteLine("Processed file: {0}", regfile);
            }
            return registerFiles;
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

        public void ImportFromWebService() {
            var apiurl = Properties.Settings.Default.pmis_api_url;
            var project = Properties.Settings.Default.pmis_project_code;
            var authkey = Properties.Settings.Default.pmis_auth_key;
            string url = String.Format("{0}/Doc/Register/loadDocList.action?pageScale=9999&srch_show_hist=1&forward=json&pjt_cd={1}&access_token={2}", apiurl, project, authkey);

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    //Console.WriteLine(result);
                    PmisJsonResponse<RegisterDocument> dt = JsonConvert.DeserializeObject<PmisJsonResponse<RegisterDocument>>(result);
                    ImportData(dt.List);
                }
            }
            catch (Exception ex)
            {
                ex.Log().Display();
                if (ImportErrorHandler != null)
                    ImportErrorHandler(this, new ErrorEventArgs(ex));
            }
            finally
            {
                if (ImportCompleteHandler != null)
                    ImportCompleteHandler(this, EventArgs.Empty);
            }
        }

        private void ImportData(List<RegisterDocument> docs)
        {
            daoService.ImportDocumentData(docs);
        }

        public void DeleteRegisterData() {
            daoService.DeleteRegisterData();
        }
    }
}
