using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace pmis.archive
{
    public class ArchiveDataService
    {

        private IArchiveDataDao dao;

        public event EventHandler<Archive> ArchiveDataImported;
        public event EventHandler ImportComplete;
        public event ErrorEventHandler ImportError;

        public ArchiveDataService(IArchiveDataDao dao)
        {
            this.dao = dao;
        }

        public DataTable SearchArchive(Dictionary<string, object> criteria = null)
        {
            try
            {
                return dao.SearchArchive(criteria);
            }
            catch (Exception e)
            {
                e.Log();
                throw e;
            }
        }

        public Archive LoadArchive(String id)
        {
            try
            {
                LogUtil.Log(String.Format("Loading archive data {0}", id));
                return dao.LoadArchive(id);
            }
            catch (Exception e)
            {
                e.Log();
                throw e;
            }
        }

        public IEnumerable<RegisterFile> LoadArchiveFiles(Archive archive)
        {
            string registerURI = Properties.Settings.Default.register_folder_uri;
            registerURI = String.IsNullOrEmpty(registerURI) ? "register" : registerURI;

            string targetDirectory = registerURI + "/" + RegisterFile.SanitizeName(archive.Id);
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

            foreach (string fileName in files)
            {
                var regfile = new RegisterFile(fileName);
                yield return regfile;
            }
        }

        public void DeleteArchive()
        {
            try
            {
                dao.DeleteArchive();
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
            string url = String.Format("{0}/api/archive.action", apiurl);

            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string> {
                        { "forward", "json" },
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
                        values["pageNo"] = "" + page;
                        var content = new FormUrlEncodedContent(values);
                        var response = await client.PostAsync(url, content);
                        response.EnsureSuccessStatusCode();
                        var responseString = await response.Content.ReadAsStringAsync();
                        PmisJsonResponse<Archive> dt = JsonConvert.DeserializeObject<PmisJsonResponse<Archive>>(responseString);
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
                if (ImportError != null)
                    ImportError(this, new ErrorEventArgs(ex));
            }
            finally
            {
                if (ImportComplete != null)
                    ImportComplete(this, EventArgs.Empty);
            }
        }

        protected virtual void OnImportComplete(EventArgs e)
        {
            EventHandler handler = ImportComplete;
            if (handler != null)
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

        protected virtual void OnArchiveDataImported(Archive d)
        {
            EventHandler<Archive> handler = ArchiveDataImported;
            if (handler != null)
            {
                handler(this, d);
            }
        }

        private void ImportData(List<Archive> docs)
        {
            try
            {
                foreach (Archive d in docs)
                {
                    dao.ImportArchiveData(d);
                    Console.WriteLine("Adding register data: {0}", d);
                    OnArchiveDataImported(d);
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
