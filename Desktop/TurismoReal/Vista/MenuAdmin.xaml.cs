using System;
using System.Data;
using System.Windows;
using Vista.Pages;

namespace Vista
{
    public partial class MenuAdmin : Window
    {
        //variable para setear el tema de la app (dark or light)
        //private bool isLight = true;

        private readonly DataTable dt;
        public MenuAdmin(DataTable admin)
        {
            InitializeComponent();
            dt = admin;
            Default();
        }
        #region Barra de navegación
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
        private void btnReservas_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new Uri("Pages/MantenedorReservas.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btnDpto_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new Uri("Pages/MantenedorDpto.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btnServE_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new Uri("Pages/MantenedorServExtras.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btnUsuario_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new Uri("Pages/MantenedorUsuario.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btnServDpto_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new Uri("Pages/MantenedorServDpto.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btnTour_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new Uri("Pages/MantenedorTours.xaml", UriKind.RelativeOrAbsolute));
        }
        private void BtnReporteria_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new Uri("Pages/Reportes.xaml", UriKind.RelativeOrAbsolute));
        }
        #endregion

        //private void btnSwitch_Click(object sender, RoutedEventArgs e)
        //{
        //    isLight = !isLight;

        //    var tema = isLight ? "/Resources/Light.xaml" : "/Resources/Dark.xaml";
        //    var resources = Application.Current.Resources;

        //    resources.MergedDictionaries.RemoveAt(0);
        //    resources.MergedDictionaries.Insert(0,
        //        new ResourceDictionary { Source = new Uri(tema, UriKind.Relative) });
        //}
    }
}
