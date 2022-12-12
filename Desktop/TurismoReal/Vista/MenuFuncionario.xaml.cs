using System;
using System.Data;
using System.Windows;
using Vista.PagesFuncionario;

namespace Vista
{
    public partial class MenuFuncionario : Window
    {
        private readonly DataTable dt;
        public MenuFuncionario(DataTable funcionario)
        {
            InitializeComponent();
            dt = funcionario;
            Default();
        }
        private void Default()
        {
            MainMenu mainMenu = new(dt);
            PagesNavigation.Navigate(mainMenu);
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new(dt);
            PagesNavigation.Navigate(mainMenu);
        }

        private void btnCheckIn_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new Uri("PagesFuncionario/CheckIn.xaml", UriKind.RelativeOrAbsolute));

        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new Uri("PagesFuncionario/CheckOut.xaml", UriKind.RelativeOrAbsolute));

        }
    }
}
