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
        internal static Exception Log(this Exception ex)
        {
            File.AppendAllText("CaughtExceptions_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log", DateTime.Now.ToString("HH:mm:ss") + ": " + ex.Message + "\n" + ex.ToString() + "\n");
            return ex;
        }

        internal static Exception Display(this Exception ex, string msg = null, MessageBoxIcon icon = MessageBoxIcon.Error)
        {
            MessageBox.Show(msg ?? ex.Message, "", MessageBoxButtons.OK, icon);
            return ex;
        }
    }
}
