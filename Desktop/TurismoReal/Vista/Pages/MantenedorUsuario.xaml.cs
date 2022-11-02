using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Vista.Pages
{
    public partial class MantenedorUsuario : Page
    {
        public MantenedorUsuario()
        {
            InitializeComponent();
        }
        private void btnVistaAdmin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MantenedorAdmin.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnVistaFuncionarios_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MantenedorFuncionario.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnVistaClientes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MantenedorCliente.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
