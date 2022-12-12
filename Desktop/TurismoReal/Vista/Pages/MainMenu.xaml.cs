using Controlador;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Vista.Pages
{
    public partial class MainMenu : Page
    {
        public MainMenu(DataTable dt)
        {
            InitializeComponent();
            lblAdmin.Content = dt.Rows[0][0].ToString();
            lblCantidad.Content = CDepartamento.ContarDpto();
        }
        private void btn_Dpto_Crud_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MantenedorDpto.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_ServE_Crud_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MantenedorServExtras.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_Usuarios_Crud_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MantenedorUsuario.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_Tours_Crud_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MantenedorTours.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_ServDeptos_Crud_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MantenedorServDpto.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btn_Reservas_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MantenedorReservas.xaml", UriKind.RelativeOrAbsolute));
        }

    }
}
