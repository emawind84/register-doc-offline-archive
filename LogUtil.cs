using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis
{
    public class LogUtil
    {
        public static string LogRootFolder { get; set; }

        public static void Log(string message="<empty>", string filename=null)
        {
            if (LogRootFolder != null)
                Directory.CreateDirectory(LogRootFolder);

            var log = Path.Combine(LogRootFolder ?? "", filename ?? "Log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log" );
            File.AppendAllText(log, DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]") + ": " + message + "\n");
        }

    }
}
