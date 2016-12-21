using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Net;
using Newtonsoft.Json;

namespace db_test
{
    class RegisterDocumentDataService
    {

        private static string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
        private SQLiteConnection _dbConnection;

        public RegisterDocumentDataService(SQLiteConnection dbConnection) {
            this._dbConnection = dbConnection;
        }

        public DataTable SearchDocument(string searchvalue = null)
        {
            string filepath = Path.Combine(projectFolder, @"db.register.load.sql");
            string sql = File.ReadAllText(filepath);

            if (!string.IsNullOrEmpty(searchvalue))
                sql += " AND upper(docno) like upper('%'||@searchvalue||'%') ";

            DataTable dt = new DataTable();
            using (var cmd = new SQLiteCommand(sql, _dbConnection))
            {
                if(!string.IsNullOrEmpty(searchvalue))
                    cmd.Parameters.AddWithValue("@searchvalue", searchvalue);

                SQLiteDataAdapter da = new SQLiteDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(dt);
            }

            //SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            //SQLiteDataReader reader = command.ExecuteReader();
            //command.Dispose();

            //while (reader.Read())
            //    Console.WriteLine("docno: " + reader["docno"]);

            return dt;
        }

        public RegisterDocument GetByDocumentNumber(string docno) {
            string filepath = Path.Combine(projectFolder, @"db.register.load.sql");
            string sql = File.ReadAllText(filepath);
            sql += " AND docno = @docno ";

            RegisterDocument doc = null;

            using (var cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.Parameters.AddWithValue("@docno", docno);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        doc = new RegisterDocument
                        {
                            DocumentNumber = reader["docno"].ToString(),
                            Title = reader["title"].ToString(),
                            Discipline = reader["discipline"].ToString(),
                            Modified = reader["modified"].ToString(),
                            ModifiedBy = reader["modified_by"].ToString(),
                            ReviewStatus = reader["review_status"].ToString(),
                            Revision = reader["revision"].ToString(),
                            Status = reader["doc_status"].ToString(),
                            Version = reader["doc_version"].ToString()
                        };
                    }
                }

                //cmd.Dispose();
            }
            
            return doc;
        }

        public void ImportData(List<RegisterDocument> docs)
        {
            string filepath = Path.Combine(projectFolder, @"db.register.import.sql");
            string sql = File.ReadAllText(filepath);

            foreach(RegisterDocument d in docs)
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection);
                cmd.Parameters.AddWithValue("@docno", d.DocumentNumber);
                cmd.Parameters.AddWithValue("@title", d.Title);
                cmd.Parameters.AddWithValue("@discipline", d.Discipline);
                cmd.Parameters.AddWithValue("@revision", d.Revision);
                cmd.Parameters.AddWithValue("@version", d.Version);
                cmd.Parameters.AddWithValue("@status", d.Status);
                cmd.Parameters.AddWithValue("@int_cd", d.InternalNumber);
                cmd.Parameters.AddWithValue("@review_status", d.ReviewStatus);
                cmd.Parameters.AddWithValue("@modified_by", d.ModifiedBy);
                cmd.Parameters.AddWithValue("@modified", d.Modified);
                cmd.Parameters.AddWithValue("@organization", "N/A");
                cmd.Parameters.AddWithValue("@descr", "N/A");
                cmd.Parameters.AddWithValue("@type", "N/A");
                cmd.Parameters.AddWithValue("@current", "0");

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                Console.WriteLine("Adding register data: {0}", d);
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

        public String ImportFromWebService() {
            string url = "http://dev.sangah.com/Doc/Register/loadDocList.action?forward=json&pjt_cd=GLB_PMIS&access_token=ZGlzY28xMjM0OltCQDZkMDhhNzg1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    //Console.WriteLine(result);
                    PmisJsonResponse<RegisterDocument> dt = JsonConvert.DeserializeObject<PmisJsonResponse<RegisterDocument>>(result);
                    ImportData(dt.List);

                    return result;
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

        public void DeleteRegisterData() {
            string sql = "delete from register";
            SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
            command.ExecuteNonQuery();
            command.Dispose();
        }
    }
}
