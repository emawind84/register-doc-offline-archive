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
            InitializeComponent();
            this.Owner = App.Current.MainWindow;
        }

        private void CreateProfileCreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var profile = ProfileService.CreateProfile(profileNameTextBox.Text);
                ProfileService.ChangeProfile(profile);
                AfterProfileCreated?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void profileNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
