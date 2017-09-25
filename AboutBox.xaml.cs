using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            this.labelVersion.Content = String.Format("Version {0}", AppConfig.AssemblyVersion);
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
