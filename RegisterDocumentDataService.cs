using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;

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

        public void ImportCSVFile(string csvfile)
        {
            FileStream fs = new FileStream(csvfile, FileMode.Open, FileAccess.Read);

            string filepath = Path.Combine(projectFolder, @"db.register.import.sql");
            string sql = File.ReadAllText(filepath);

            using (StreamReader reader = new StreamReader(fs, Encoding.Default))
            {
                reader.ReadLine();  // skip header
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection);
                    cmd.Parameters.AddWithValue("@docno", values[4]);
                    cmd.Parameters.AddWithValue("@title", values[5]);
                    cmd.Parameters.AddWithValue("@discipline", values[6]);
                    cmd.Parameters.AddWithValue("@revision", values[7]);
                    cmd.Parameters.AddWithValue("@version", values[8]);
                    cmd.Parameters.AddWithValue("@status", values[10]);
                    cmd.Parameters.AddWithValue("@int_cd", values[11]);
                    cmd.Parameters.AddWithValue("@review_status", values[13]);
                    cmd.Parameters.AddWithValue("@modified_by", values[14]);
                    cmd.Parameters.AddWithValue("@modified", values[15]);
                    cmd.Parameters.AddWithValue("@organization", "N/A");
                    cmd.Parameters.AddWithValue("@descr", "N/A");
                    cmd.Parameters.AddWithValue("@type", "N/A");
                    cmd.Parameters.AddWithValue("@current", "0");

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    Console.WriteLine("Adding register data: {0}", line);
                }
            }
        }
    }
}
