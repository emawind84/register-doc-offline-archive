using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace pmis
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int MINIMUM_SPLASH_TIME = 2000; // Miliseconds  

        protected override void OnStartup(StartupEventArgs e)
        {
            // configure user folder in appdata
            try
            {
                AppConfig.InitConfig();
            }
            catch (Exception ex)
            {
                ex.Log();
                throw new ApplicationException("Application didn't start correctly, please check the log.", ex)
                    .Display();
            }

            SplashWindow splash = new SplashWindow();
            splash.Show();
            // Step 2 - Start a stop watch  
            Stopwatch timer = new Stopwatch();
            timer.Start();

            // Step 3 - Load your windows but don't show it yet  
            base.OnStartup(e);
            timer.Stop();

            int remainingTimeToShowSplash = MINIMUM_SPLASH_TIME - (int)timer.ElapsedMilliseconds;
            if (remainingTimeToShowSplash > 0)
                Thread.Sleep(remainingTimeToShowSplash);

            splash.Close();
        }

    }
}
