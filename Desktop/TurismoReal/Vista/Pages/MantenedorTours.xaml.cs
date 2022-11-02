using System.Collections.Generic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Controlador;
using Modelo;
using System.Data;
using System.Linq;
using System.Windows.Input;

namespace Vista.Pages
{
    public partial class MantenedorTours : Page
    {
        public MantenedorTours()
        {
            InitializeComponent();
            ListarTour();
            ListarRegiones();
        }
        private void ItemError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }
        public void ListarRegiones()
        {
            try
            {
                List<Region> regiones = CRegion.ListarRegion();
                if (regiones != null)
                {
                    (Resources["regiones"] as CollectionViewSource).Source = regiones;
                    cbo_region_ag.ItemsSource = regiones;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAbrirAgregarTours_Click(object sender, RoutedEventArgs e)
        {
            dhTour_ag.IsOpen = true;
        }
        private void btn_Cancelar_Ag_Click(object sender, RoutedEventArgs e)
        {
            dhTour_ag.IsOpen = false;
        }
        private void Limpiar()
        {
            txt_nombre_ag.Clear();
            txt_desc_ag.Clear();
            txt_precio_ag.Clear();
            cbo_region_ag.SelectedIndex = -1;
        }
        private void DtgToursUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tour tour = (Tour)dtgTours.SelectedItem;
            if (tour != null)
            {
                try
                {
                    int estado = CTour.ActualizarTour(tour);
                    MensajeOk("Tour actualizado");
                    ListarTour();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DtgTourUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    Tour tour = (Tour)dtgTours.SelectedItem;
                    try
                    {
                        int estado = CTour.ActualizarTour(tour);
                        MensajeOk("Tour actualizado");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
        }

        private void DtgTourDelete(object sender, RoutedEventArgs e)
        {
            Tour tour = (Tour)dtgTours.SelectedItem;
            try
            {
                MessageBoxResult result = MessageBox.Show("Estás seguro de querer eliminar este tour?", "Tours", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int estado = CTour.EliminarTour(tour.IdTour);
                    MensajeOk("Tour eliminado");
                    ListarTour();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ListarTour()
        {
            try
            {
                DataTable dataTable = CTour.ListarTours();
                if (dataTable != null)
                {
                    var tours = (from rw in dataTable.AsEnumerable()
                                 select new Tour()
                                 {
                                     IdTour = Convert.ToInt32(rw[0]),
                                     NombreTour = rw[1].ToString(),
                                     DescripcionTour = rw[2].ToString(),
                                     ValorTour = Convert.ToInt32(rw[3]),
                                     Region = new()
                                     {
                                         IdRegion = Convert.ToInt32(rw[4]),
                                         NombreRegion = rw[6].ToString()
                                     }
                                 }).ToList();
                    dtgTours.ItemsSource = tours;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Tours", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Tours", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btn_Agregar_Tour_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_nombre_ag.Text == string.Empty || txt_desc_ag.Text == string.Empty || txt_precio_ag.Text == string.Empty ||
                    cbo_region_ag.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos");
                }
                else
                {
                    Tour tour = new()
                    {
                        NombreTour = txt_nombre_ag.Text.Trim(),
                        DescripcionTour = txt_desc_ag.Text.Trim(),
                        ValorTour = Int32.Parse(txt_precio_ag.Text.Trim()),
                        Region = (Region)cbo_region_ag.SelectedItem
                    };

                    int estado = CTour.IngresarTour(tour);
                    MensajeOk("Tour agregado");
                    ListarTour();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
        }
    }
}
