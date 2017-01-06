using pmis.register;
using pmis.reviewinfo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis
{
    public class SQLiteDaoService : IDbConnection, IRegisterDocumentDao, IReviewInfoDao
    {
        private static string projectFolder = AppDomain.CurrentDomain.BaseDirectory;

        private string databaseFilePath;
        private SQLiteConnection m_dbConnection;

        public string DatabaseFilePath {
            get { return databaseFilePath; }
            set { this.databaseFilePath = value; }
        }

        private SQLiteConnection InitDB()
        {
            LogUtil.Log("Connecting database...");
            ConfigureDatabasePath();

            string connectionString = string.Format("Data Source={0};Version=3;", databaseFilePath);

            if (!File.Exists(databaseFilePath))
            {
                LogUtil.Log(String.Format("Creating new database... {0}", connectionString));
                SQLiteConnection.CreateFile(databaseFilePath);
                m_dbConnection = new SQLiteConnection(connectionString);
                m_dbConnection.Open();

                //string setupfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"setup.sqlite.sql");
                string sql = File.ReadAllText(@"setup.sqlite.sql");
                LogUtil.Log(String.Format("Executing query: {0}", sql));
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                command.Dispose();
            }
            else
            {
                m_dbConnection = new SQLiteConnection(connectionString);
                m_dbConnection.Open();
                using (var transaction = m_dbConnection.BeginTransaction())
                {
                    transaction.Rollback();
                }
            }

            LogUtil.Log(String.Format("New Connection {0}", m_dbConnection));
            
            return m_dbConnection;
        }

        public void Open()
        {
            Close();
            InitDB();
        }

        public void Close()
        {
            if (m_dbConnection != null)
            {
                LogUtil.Log(String.Format("Closing db connection... {0}", m_dbConnection));
                m_dbConnection.Close();
            }
        }

        public Boolean IsOpen()
        {
            return m_dbConnection.State == ConnectionState.Open;
        }

        public void DeleteRegisterData()
        {
            SQLiteCommand command = new SQLiteCommand("delete from register", m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            command.Dispose();
        }

        public void ImportDocumentData(RegisterDocument d)
        {
            string filepath = Path.Combine(projectFolder, @"register.import.sqlite.sql");
            string sql = File.ReadAllText(@"register.import.sqlite.sql");

            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            cmd.Parameters.AddWithValue("@docno", d.DocumentNumber);
            cmd.Parameters.AddWithValue("@title", d.Title);
            cmd.Parameters.AddWithValue("@discipline", d.Discipline);
            cmd.Parameters.AddWithValue("@revision", d.Revision);
            cmd.Parameters.AddWithValue("@revision_date", d.RevisionDate);
            cmd.Parameters.AddWithValue("@version", d.Version);
            cmd.Parameters.AddWithValue("@status", d.Status);
            cmd.Parameters.AddWithValue("@int_cd", d.InternalNumber);
            cmd.Parameters.AddWithValue("@review_status", d.ReviewStatus);
            cmd.Parameters.AddWithValue("@registered_by", d.RegisteredBy);
            cmd.Parameters.AddWithValue("@registered", d.Registered);
            cmd.Parameters.AddWithValue("@organization", d.Organization);
            cmd.Parameters.AddWithValue("@descr", d.Note);
            cmd.Parameters.AddWithValue("@type", d.Type);
            cmd.Parameters.AddWithValue("@current", d.Current);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            
        }

        public RegisterDocument LoadDocument(string docno, string version = null)
        {
            string filepath = Path.Combine(projectFolder, @"register.load.sqlite.sql");
            string sql = File.ReadAllText(filepath);
            sql += " AND docno = @docno ";

            if (version != null)
            {
                sql += " AND doc_version = @version ";
            }
            else {
                sql += " AND doc_current = 1 ";
            }

            RegisterDocument doc = null;

            using (var cmd = new SQLiteCommand(sql, m_dbConnection))
            {
                cmd.Parameters.AddWithValue("@docno", docno);

                if (version != null)
                {
                    cmd.Parameters.AddWithValue("@version", version);
                }

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        doc = new RegisterDocument
                        {
                            DocumentNumber = reader["docno"].ToString(),
                            Title = reader["title"].ToString(),
                            Discipline = reader["discipline"].ToString(),
                            Registered = reader["registered"].ToString(),
                            RegisteredBy = reader["registered_by"].ToString(),
                            ReviewStatus = reader["review_status"].ToString(),
                            Revision = reader["revision"].ToString(),
                            RevisionDate = reader["revision_date"].ToString(),
                            Status = reader["doc_status"].ToString(),
                            Version = reader["doc_version"].ToString(),
                            Note = reader["descr"].ToString(),
                            Organization = reader["organization"].ToString(),
                            Current = reader["doc_current"].ToString(),
                            Type = reader["doc_type"].ToString(),
                            InternalNumber = reader["int_cd"].ToString()
                        };
                    }
                }

                //cmd.Dispose();
            }

            return doc;
        }

        public DataTable SearchDocument(Dictionary<string, object> criteria = null)
        {
            string filepath = Path.Combine(projectFolder, @"register.load.sqlite.sql");
            string sql = File.ReadAllText(filepath);

            if (criteria.ContainsKey("docno"))
                sql += " AND upper(docno) like upper('%'||@docno||'%') ";

            if (criteria.ContainsKey("title"))
                sql += " AND upper(title) like upper('%'||@title||'%') ";

            if (criteria.ContainsKey("from_date"))
                sql += " AND registered >= @from_date ";

            if (criteria.ContainsKey("to_date"))
                sql += " AND registered <= @to_date ";

            if (criteria.ContainsKey("status"))
                sql += " AND doc_status = @status ";

            if (criteria.ContainsKey("discipline"))
                sql += " AND discipline = @discipline ";

            if (criteria.ContainsKey("type"))
                sql += " AND discipline = @type ";

            if (criteria.ContainsKey("top_version"))
                sql += " AND doc_current = 1 ";

            sql += "order by upper(docno)";
            sql += "limit 1000";

            DataTable dt = new DataTable();
            using (var cmd = new SQLiteCommand(sql, m_dbConnection))
            {
                if (criteria.ContainsKey("from_date"))
                    cmd.Parameters.AddWithValue("@from_date", criteria["from_date"]);

                if (criteria.ContainsKey("to_date"))
                    cmd.Parameters.AddWithValue("@to_date", criteria["to_date"]);

                if (criteria.ContainsKey("docno"))
                    cmd.Parameters.AddWithValue("@docno", criteria["docno"]);

                if (criteria.ContainsKey("status"))
                    cmd.Parameters.AddWithValue("@status", criteria["status"]);

                if (criteria.ContainsKey("discipline"))
                    cmd.Parameters.AddWithValue("@discipline", criteria["discipline"]);

                if (criteria.ContainsKey("type"))
                    cmd.Parameters.AddWithValue("@type", criteria["type"]);

                if (criteria.ContainsKey("title"))
                    cmd.Parameters.AddWithValue("@title", criteria["title"]);

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

        public DataTable LoadReviewInfo(RegisterDocument doc)
        {
            Console.WriteLine("Loading review info...");
            string filepath = Path.Combine(projectFolder, @"review.load.sqlite.sql");
            string sql = File.ReadAllText(filepath);

            sql += " AND docno = @docno ";
            sql += " AND doc_version = @version ";
            sql += "order by review_date desc";

            DataTable dt = new DataTable();
            using (var cmd = new SQLiteCommand(sql, m_dbConnection))
            {
                cmd.Parameters.AddWithValue("@docno", doc.DocumentNumber);
                cmd.Parameters.AddWithValue("@version", doc.Version);

                SQLiteDataAdapter da = new SQLiteDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(dt);
            }

            Console.WriteLine("Found {0} review info", dt.Rows.Count);
            return dt;
        }

        public void DeleteReviewInfo()
        {
            SQLiteCommand command = new SQLiteCommand("delete from review_info", m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            command.Dispose();
        }

        public void ImportReviewInfoData(ReviewInfo d)
        {
            string filepath = Path.Combine(projectFolder, @"review.import.sqlite.sql");
            string sql = File.ReadAllText(filepath);
            
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            cmd.Parameters.AddWithValue("@docno", d.DocumentNumber);
            cmd.Parameters.AddWithValue("@version", d.DocumentVersion);
            cmd.Parameters.AddWithValue("@review_date", d.ReviewDate);
            cmd.Parameters.AddWithValue("@review_status", d.ReviewStatus);
            cmd.Parameters.AddWithValue("@review_note", d.ReviewNote);
            cmd.Parameters.AddWithValue("@reviewed_by", d.ReviewedBy);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        private void ConfigureDatabasePath()
        {
            databaseFilePath = Properties.Settings.Default.sqlite_db_location;
            
            if (!Path.IsPathRooted(databaseFilePath))
            {
                databaseFilePath = Path.Combine(AppConfig.AppDataFullPath, databaseFilePath);
                Console.WriteLine(Path.GetFullPath(databaseFilePath));
            }
            Console.WriteLine("Setting db path: {0}", databaseFilePath);
        }
        
    }
}
