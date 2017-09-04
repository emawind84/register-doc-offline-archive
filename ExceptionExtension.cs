using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pmis
{
    public static class ExceptionExtension
    {

        internal static Exception Log(this Exception ex)
        {
            LogUtil.Log(ex.Message + "\n" + ex.ToString(), "CaughtExceptions_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log");
            
            return ex;
        }

        internal static Exception Display(this Exception ex, string msg = null, System.Windows.MessageBoxImage icon = System.Windows.MessageBoxImage.Error)
        {
            MessageBox.Show(msg ?? ex.Message, "", System.Windows.MessageBoxButton.OK, icon);
            return ex;
        }
    }
}
