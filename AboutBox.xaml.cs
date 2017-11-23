using System;
using System.ComponentModel;
using System.Windows;

namespace pmis
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AboutBox : Window
    {
        public AboutBox()
        {
            InitializeComponent();
            this.Title = String.Format("About {0}", AppConfig.AssemblyTitle);
            this.labelProductName.Content = AppConfig.AssemblyProduct;
            this.labelVersion.Content = String.Format("Version {0}, build {1}", AppConfig.AssemblyVersion, AppConfig.PublishVersion);
            this.labelCopyright.Content = AppConfig.AssemblyCopyright;
            this.labelCompanyName.Content = AppConfig.AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //base.OnClosing(e);
            this.Hide();
            e.Cancel = true;
        }

        private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
