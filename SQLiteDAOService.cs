using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis
{
    class SQLiteDAOService : register.RegisterDocumentDaoService
    {
        private static string projectFolder = AppDomain.CurrentDomain.BaseDirectory;

        private string db_filename;
        private SQLiteConnection m_dbConnection;

        public SQLiteDAOService(string db_filename)
        {
            this.db_filename = db_filename;
        }

        public SQLiteConnection InitDB()
        {
            string connectionString = string.Format("Data Source={0};Version=3;", db_filename);

            if (!File.Exists(db_filename))
            {
                SQLiteConnection.CreateFile(db_filename);
                m_dbConnection = new SQLiteConnection(connectionString);
                m_dbConnection.Open();

                Console.WriteLine("Creating Database file...");

                //string setupfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"setup.sqlite.sql");
                string sql = File.ReadAllText(@"setup.sqlite.sql");
                Console.WriteLine("Executing query: {0}", sql);
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                command.Dispose();
            }

            m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            return m_dbConnection;
        }

        public void DeleteRegisterData()
        {
            throw new NotImplementedException();
        }

        public void ImportDocumentData(List<RegisterDocument> docs)
        {
            string filepath = Path.Combine(projectFolder, @"register.import.sqlite.sql");
            string sql = File.ReadAllText(@"register.import.sqlite.sql");

            foreach (RegisterDocument d in docs)
            {
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

                Console.WriteLine("Adding register data: {0}", d);
            }
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
                sql += " AND current = 1 ";
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
                            Note = reader["descr"].ToString()
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

            if (criteria.ContainsKey("from_date"))
                sql += " AND registered >= @from_date ";

            if (criteria.ContainsKey("to_date"))
                sql += " AND registered >= @to_date ";

            DataTable dt = new DataTable();
            using (var cmd = new SQLiteCommand(sql, m_dbConnection))
            {
                if (criteria.ContainsKey("from_date"))
                    cmd.Parameters.AddWithValue("@from_date", criteria["from_date"]);

                if (criteria.ContainsKey("to_date"))
                    cmd.Parameters.AddWithValue("@to_date", criteria["to_date"]);

                if (criteria.ContainsKey("docno"))
                    cmd.Parameters.AddWithValue("@docno", criteria["docno"]);

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
    }
}
