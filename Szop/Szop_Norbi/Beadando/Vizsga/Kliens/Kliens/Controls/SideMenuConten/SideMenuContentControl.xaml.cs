using Kliens.Core;
using System.Windows.Controls;


namespace Kliens
{
    /// <summary>
    /// Interaction logic for SideMenuContentControl.xaml
    /// </summary>
    public partial class SideMenuContentControl : UserControl
    {
        public SideMenuContentControl()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Add);
        }

        private void Home_click(object sender, System.Windows.RoutedEventArgs e)
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Home);
        }

        private void Upd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Upd);
        }

        private void Del_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Del);
        }

        private void Fuel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Fuel);
        }

        private void Doc_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Doc);
        }
    }
}
