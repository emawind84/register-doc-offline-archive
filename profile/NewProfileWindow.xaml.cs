using pmis.i18n;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace pmis.profile
{

    /// <summary>
    /// Interaction logic for NewProfileWindow.xaml
    /// </summary>
    public partial class NewProfileWindow : Window
    {
        public event EventHandler AfterProfileCreated;

        public NewProfileWindow()
        {
            try
            {
                InitializeComponent();
                this.Owner = App.Current.MainWindow;
                this.profileNameTextBox.Focus();
                LoadLanguage();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void CreateProfileCreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var profile = ProfileService.CreateProfile(profileNameTextBox.Text);
                ProfileService.ApplyProfile(profile);
                AfterProfileCreated?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void LoadLanguage(object sender = null, EventArgs args = null)
        {
            LanguageSupport i18n = new LanguageSupport();
            i18n.SetNewProfileFormLanguage(this);
        }
    }
}
