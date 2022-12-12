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
using System.Text.RegularExpressions;

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
                    cbo_region_ag.ItemsSource = regiones;
                    cbo_region_ac.ItemsSource = regiones;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAbrirAgregarTours_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            dhTour_ag.IsOpen = true;
        }
        private void btn_Cancelar_Ag_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            dhTour_ag.IsOpen = false;
        }
        private void Limpiar()
        {
            txt_nombre_ag.Clear();
            txt_desc_ag.Clear();
            txt_precio_ag.Clear();
            cbo_region_ag.SelectedIndex = -1;
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
                if (!Int32.TryParse(txt_precio_ag.Text.Trim(), out int valor)) return;
                if (valor <= 0)
                {
                    this.MensajeError("El valor debe ser mayor a 0");
                    return;
                }
                Tour tour = new()
                {
                    NombreTour = txt_nombre_ag.Text.Trim(),
                    DescripcionTour = txt_desc_ag.Text.Trim(),
                    ValorTour = valor,
                    Region = (Region)cbo_region_ag.SelectedItem
                };
                int estado = CTour.IngresarTour(tour);
                MensajeOk("Tour agregado");
                ListarTour();
                Limpiar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
        }

        private void txt_string_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Zá-úÁ-Ú0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_int_ag_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        Tour? tourActualizar;
        private void dtgTours_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tourActualizar = (Tour)dtgTours.SelectedItem;
            if (tourActualizar == null) return;
            dhTour_ac.IsOpen = true;
            txt_nombre_ac.Text = tourActualizar.NombreTour;
            txt_desc_ac.Text = tourActualizar.DescripcionTour;
            txt_precio_ac.Text = tourActualizar.ValorTour.ToString();
            cbo_region_ac.SelectedValue = tourActualizar.Region.IdRegion;
        }

        private void btn_Actualizar_Tour_Click(object sender, RoutedEventArgs e)
        {
            tourActualizar.NombreTour = txt_nombre_ac.Text;
            tourActualizar.DescripcionTour = txt_desc_ac.Text;
            tourActualizar.ValorTour = int.Parse(txt_precio_ac.Text);
            tourActualizar.Region = (Region)cbo_region_ac.SelectedItem;
            int estado = CTour.ActualizarTour(tourActualizar);
            if (estado > 0)
            {
                MessageBox.Show("Tour actualizado");
                ListarTour();
            }
            dhTour_ac.IsOpen = false;
            tourActualizar = null;
        }

        private void btn_Cancelar_Ac_Click(object sender, RoutedEventArgs e)
        {
            txt_nombre_ac.Text = string.Empty;
            txt_desc_ac.Text = string.Empty;
            txt_precio_ac.Text = string.Empty;            
            cbo_region_ac.SelectedIndex = -1;
            tourActualizar = null;
            dhTour_ac.IsOpen = false;
        }        
    }
}
