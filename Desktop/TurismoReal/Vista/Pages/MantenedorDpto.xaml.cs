using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Vista.Pages
{
    public partial class MantenedorDpto : Page
    {
        public MantenedorDpto()
        {
            InitializeComponent();
            ListarComunas();
            ListarDpto();
        }

        private void ItemError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }

        #region Ubicacion
        public void ListarComunas()
        {
            try
            {
                List<Comuna> comunas = CComuna.ListarComuna();
                if (comunas != null)
                {
                    (Resources["comunas"] as CollectionViewSource).Source = comunas;
                    cbo_comuna_ag.ItemsSource = comunas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Departamento 
        private void ListarDpto()
        {
            try
            {
                DataTable dataTable = CDepartamento.ListarDpto();
                if (dataTable != null)
                {
                    var Dptos = (from rw in dataTable.AsEnumerable()
                                 select new Departamento()
                                 {
                                     IdDepto = Convert.ToInt32(rw[0]),
                                     NombreDpto = rw[1].ToString(),
                                     TarifaDiara = Convert.ToInt32(rw[2]),
                                     Direccion = rw[3].ToString(),
                                     NroDpto = Convert.ToInt32(rw[4]),
                                     Capacidad = Convert.ToInt32(rw[5]),
                                     Comuna = new Comuna
                                     {
                                         IdComuna = Convert.ToInt32(rw[6]),
                                         NombreComuna = rw[9].ToString()
                                     },
                                     Disponibilidad = Convert.ToBoolean(rw[7])
                                 }).ToList();
                    dtgDptos.ItemsSource = Dptos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAbrirAgregarDpto_Click(object sender, RoutedEventArgs e)
        {
            dhDpto_ag.IsOpen = true;
        }
        private void btn_Cancelar_Ag_Click(object sender, RoutedEventArgs e)
        {
            dhDpto_ag.IsOpen = false;
        }
        private void btn_Agregar_Dpto_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                if(txt_tarifa_ag.Text == string.Empty || txt_cap_ag.Text == string.Empty || txt_direccion_ag.Text == string.Empty || 
                    txt_nro_ag.Text == string.Empty || cbo_comuna_ag.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos");
                }
                else
                {
                    Departamento dpto = new Departamento
                    {
                        NombreDpto = txt_nombre_ag.Text.Trim(),
                        TarifaDiara = Int32.Parse(txt_tarifa_ag.Text.Trim()),
                        Capacidad = Int32.Parse(txt_cap_ag.Text.Trim()),
                        Direccion = txt_direccion_ag.Text.Trim(),
                        NroDpto = Int32.Parse(txt_nro_ag.Text.Trim()),
                        Comuna = (Comuna)cbo_comuna_ag.SelectedItem,
                        Disponibilidad = false
                    };

                    int estado = CDepartamento.CrearDepto(dpto);
                    MensajeOk("Departamento agregado");
                    ListarDpto();
                    Limpiar();
                }                          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }                       
        }
        private void Limpiar()
        {
            txt_tarifa_ag.Clear();
            txt_direccion_ag.Clear();
            txt_nro_ag.Clear();
            txt_cap_ag.Clear();
            cbo_comuna_ag.SelectedIndex = -1;
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Departamentos", MessageBoxButton.OK, MessageBoxImage.Error);
        }        
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Departamentos", MessageBoxButton.OK, MessageBoxImage.Information);
        }        
        private void DtgDptosUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    Departamento departamento = (Departamento)dtgDptos.SelectedItem;
                    try
                    {
                        int estado = CDepartamento.ActualizarDepto(departamento);
                        MensajeOk("Departamento actualizado");
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
        private void DtgDptosUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Departamento departamento = (Departamento)dtgDptos.SelectedItem;
            if (departamento != null)
            {
                try
                {
                    MessageBox.Show(departamento.Disponibilidad.ToString());
                    int estado = CDepartamento.ActualizarDepto(departamento);
                    MensajeOk("Departamento actualizado");
                    ListarDpto();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void CheckBoxEstado_Click(object sender, RoutedEventArgs e)
        {
            Departamento departamento = (Departamento)dtgDptos.SelectedItem;
            if (departamento != null)
            {
                try
                {
                    int estado = CDepartamento.ActualizarDepto(departamento);
                    MensajeOk("Departamento actualizado");
                    ListarDpto();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void DtgDptoDelete_Click(object sender, RoutedEventArgs e)
        {
            Departamento departamento = (Departamento)dtgDptos.SelectedItem;
            try
            {
                MessageBoxResult result = MessageBox.Show("Estás seguro de querer eliminar este departamento y su inventario?", "Departamentos", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int estado = CDepartamento.EliminarDpto(departamento.IdDepto);
                    MensajeOk("Departamento eliminado");
                    ListarDpto();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DtgDptoDetalles_Click(object sender, RoutedEventArgs e)
        {
            Departamento departamento = (Departamento)dtgDptos.SelectedItem;
            NavigationService ns = NavigationService.GetNavigationService(this);
            PerfilDepto perfilDepto = new(departamento);
            ns.Navigate(perfilDepto);
        }
        #endregion
        private void DtgDptoMantencion_Click(object sender, RoutedEventArgs e)
        {
            Departamento departamento = (Departamento)dtgDptos.SelectedItem;
            NavigationService ns = NavigationService.GetNavigationService(this);
            MantenedorMantenimientoDpto mantenedorMantenimientoDpto = new(departamento);
            ns.Navigate(mantenedorMantenimientoDpto);                        
        }

    }
}
