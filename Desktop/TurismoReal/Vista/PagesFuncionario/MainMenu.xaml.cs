using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Vista.PagesFuncionario
{
    public partial class MainMenu : Page
    {
        public MainMenu(DataTable dt)
        {
            InitializeComponent();
            lblFunc.Content = dt.Rows[0][0].ToString();
        }

        private void btn_Checkout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("PagesFuncionario/CheckOut.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_CheckIn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("PagesFuncionario/CheckIn.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
