using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pmis
{
    public static class ExceptionExtension
    {

        public static string LogRootFolder { get; set; }

        internal static Exception Log(this Exception ex)
        {
            if(LogRootFolder != null)
                Directory.CreateDirectory(LogRootFolder);

            var log = Path.Combine(LogRootFolder ?? "", "CaughtExceptions_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log");
            File.AppendAllText(log, DateTime.Now.ToString("HH:mm:ss") + ": " + ex.Message + "\n" + ex.ToString() + "\n");
            return ex;
        }

        internal static Exception Display(this Exception ex, string msg = null, MessageBoxIcon icon = MessageBoxIcon.Error)
        {
            MessageBox.Show(msg ?? ex.Message, "", MessageBoxButtons.OK, icon);
            return ex;
        }
    }
}
