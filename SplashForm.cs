using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pmis
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();

            productInfoLabel.Text = string.Format("{0} - Build {1}", Application.ProductName, AppConfig.ProductVersion);
        }

        private static SplashForm splash;

        public static void ShowSplash()
        {
            Thread t = new Thread(new ThreadStart(delegate ()
            {
                if(splash == null)
                    splash = new SplashForm();

                //splash.Show();
                Application.Run(splash);
            }));
            t.Start();
        }

        public static void HideSplash(int delay = 0)
        {
            Thread t = new Thread(new ThreadStart(delegate ()
            {
                Thread.Sleep(delay);
                splash.Invoke(new Action(splash.Hide));
            }));
            t.Start();
        }
    }
}
