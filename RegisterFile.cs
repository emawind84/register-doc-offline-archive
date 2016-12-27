using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pmis
{
    public class RegisterFile
    {

        static string[] sizes = { "B", "KB", "MB", "GB" };

        public string FileName { get; set; }

        public long FileSize { get; set; }

        public string FileHumanSize {
            get{
                int order = 0;
                long len = this.FileSize;
                while (len >= 1024 && ++order < sizes.Length)
                {
                    len = len / 1024;
                }
                return String.Format("{0:0.##} {1}", len, sizes[order]); ;
            }
        }

        public string FilePath { get; set; }

        public RegisterFile(string filepath)
        {
            FileInfo f1 = new FileInfo(filepath);
            this.FileSize = f1.Length;
            this.FileName = f1.Name;
            this.FilePath = f1.FullName;
        }

        public override string ToString()
        {
            return this.FileName;
        }

        public static string SanitizeName(string name)
        {
            var sanitizedName = new StringBuilder();
            foreach (char c in name)
            {
                if (c == '/')
                {
                    sanitizedName.Append('_');
                }
                else if (c == ':')
                {
                    sanitizedName.Append('_');
                }
                else if (c == '*')
                {
                    sanitizedName.Append('_');
                }
                else if (c == '<')
                {
                    sanitizedName.Append('_');
                }
                else if (c == '>')
                {
                    sanitizedName.Append('_');
                }
                else if (c == '"')
                {
                    sanitizedName.Append('_');
                }
                else
                {
                    sanitizedName.Append(c);
                }
            }
            return sanitizedName.ToString();
        }
    }
}
