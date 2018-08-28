using pmis.i18n;
using System;
using System.Collections;
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

namespace pmis.archive
{
    /// <summary>
    /// Interaction logic for ArchiveDetail.xaml
    /// </summary>
    public partial class ArchiveDetailWindow : Window
    {

        public ArchiveDetailView ArchiveDetailView { get; set; }

        public IEnumerable FileManagerItemsSource
        {
            set { fileManagerDataGridView.ItemsSource = value; }
        }

        public ArchiveDetailWindow(ArchiveDataService service, String archiveId)
        {
            InitializeComponent();

            try
            {
                ArchiveDetailView = new ArchiveDetailView(this);

                ArchivePresenter presenter = new ArchivePresenter(this, service);

                presenter.ShowArchiveDetail(archiveId);

                LanguageSupport i18n = new LanguageSupport();
                i18n.SetArchiveDetailWindowLanguage(this);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void fileManagerDataGridView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AppUtil.FileManagerOnSingleClick(sender, e);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private void fileManagerDataGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AppUtil.FileManagerOnDoubleClick(sender, e);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }
    }
}
