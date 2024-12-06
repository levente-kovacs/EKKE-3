using Kliens.Core;
using System.Windows;
using System.Windows.Controls;


namespace Kliens
{
    /// <summary>
    /// Interaction logic for SideMenuControl.xaml
    /// </summary>
    public partial class SideMenuControl : UserControl
    {
        public SideMenuControl()
        {
            InitializeComponent();
        }

        private void GoToLogin_Click(object sender, RoutedEventArgs e)
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);
        }
    }
}
