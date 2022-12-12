using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
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
                    cbo_comuna_ag.ItemsSource = comunas;
                    cbo_comuna_ac.ItemsSource = comunas;
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
                if (txt_nombre_ag.Text != string.Empty)
                {
                    if (txt_tarifa_ag.Text != string.Empty)
                    {
                        if (txt_direccion_ag.Text != string.Empty)
                        {
                            if (txt_nro_ag.Text != string.Empty)
                            {
                                if (txt_cap_ag.Text != string.Empty)
                                {
                                    if (cbo_comuna_ag.Text != string.Empty)
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
                                    else
                                    {
                                        this.MensajeError("Comuna es un campo requerido");
                                    }
                                }
                                else
                                {
                                    this.MensajeError("Capacidad es un campo requerido");
                                }
                            }
                            else
                            {
                                this.MensajeError("Nro. Departamento es un campo requerido");
                            }
                        }
                        else
                        {
                            this.MensajeError("Dirección es un campo requerido");
                        }
                    }
                    else
                    {
                        this.MensajeError("Tarifa es un campo requerido");
                    }
                }
                else
                {
                    this.MensajeError("Nombre es un campo requerido");
                }                                     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }                       
        }
        private void Limpiar()
        {
            txt_nombre_ag.Clear();
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
                Departamento departamento = (Departamento)dtgDptos.SelectedItem;
                if (e.Key == Key.Enter && ValidarCamposDataGrid(departamento))
                {
                    try
                    {
                        if (departamento.NombreDpto.Length > 0 || departamento.NombreDpto != null)
                        {
                            int estado = CDepartamento.ActualizarDepto(departamento);
                            MensajeOk("Departamento actualizado");
                        }
                        else
                        {
                            MensajeError("Debe ingresar un nombre de departamento");
                        }
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
            if (departamento != null && ValidarCamposDataGrid(departamento))
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
            if (departamento != null && ValidarCamposDataGrid(departamento))
            {
                try
                {
                    int estado = CDepartamento.ActualizarDisponibilidad(departamento.IdDepto, departamento.Disponibilidad);
                    if (estado == -20405)
                    {
                        MensajeError("No hay imagen");
                        CheckBox cb = (CheckBox)sender;
                        cb.IsChecked = false;
                        return;
                    }
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
        private void btnSecreto_Click(object sender, RoutedEventArgs e)
        {
            Departamento departamento = (Departamento)dtgDptos.SelectedItem;
            NavigationService ns = NavigationService.GetNavigationService(this);
            MantenedorServiciosDepto msd = new(departamento);
            ns.Navigate(msd);
        }

        private void txt_nombre_ag_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Zá-úÁ-Ú]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_tarifa_ag_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_nro_ag_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_cap_ag_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_direccion_ag_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Zá-úÁ-Ú0-9, ]*$");
            e.Handled = !regex.IsMatch(e.Text);            
        }

        private void txt_NombreDpto_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Zá-úÁ-Ú]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_TarifaDiaria_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_Direccion_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Zá-úÁ-Ú0-9, ]*$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void txt_NroDpto_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_Capacidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private bool ValidarCamposDataGrid(Departamento departamento)
        {
            try
            {
                if (departamento.NombreDpto.Trim() != string.Empty)
                {
                    if (departamento.TarifaDiara > 0)
                    {
                        if (departamento.Direccion.Trim() != string.Empty)
                        {
                            if (departamento.NroDpto >0)
                            {
                                if (departamento.Capacidad > 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    this.MensajeError("Capacidad es un campo requerido");
                                }
                            }
                            else
                            {
                                this.MensajeError("Nro. Departamento es un campo requerido");
                            }
                        }
                        else
                        {
                            this.MensajeError("Dirección es un campo requerido");
                        }
                    }
                    else
                    {
                        this.MensajeError("Tarifa es un campo requerido");
                    }
                }
                else
                {
                    this.MensajeError("Nombre es un campo requerido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
            return false;
        }

        Departamento? dptoActualizar;
        private void dtgDptos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dptoActualizar = (Departamento)dtgDptos.SelectedItem;
            if (dptoActualizar == null) return;
            dhDpto_ac.IsOpen = true;
            txt_nombre_ac.Text = dptoActualizar.NombreDpto;
            txt_direccion_ac.Text = dptoActualizar.Direccion;
            txt_tarifa_ac.Text = dptoActualizar.TarifaDiara.ToString();
            txt_cap_ac.Text = dptoActualizar.Capacidad.ToString();
            txt_nro_ac.Text = dptoActualizar.NroDpto.ToString();
            cbo_comuna_ac.SelectedValue = dptoActualizar.Comuna.IdComuna;
        }

        private void btn_Actualizar_Dpto_Click(object sender, RoutedEventArgs e)
        {
            dptoActualizar.NombreDpto = txt_nombre_ac.Text;
            dptoActualizar.Direccion = txt_direccion_ac.Text;
            dptoActualizar.TarifaDiara = int.Parse(txt_tarifa_ac.Text);
            dptoActualizar.Capacidad = int.Parse(txt_cap_ac.Text);
            dptoActualizar.NroDpto = int.Parse(txt_nro_ac.Text);
            dptoActualizar.Comuna = (Comuna)cbo_comuna_ac.SelectedItem;
            int estado = CDepartamento.ActualizarDepto(dptoActualizar);
            if (estado > 0)
            {
                MensajeOk("Departamento actualizado");
                ListarDpto();
            }
            dhDpto_ac.IsOpen = false;
            dptoActualizar = null;
        }

        private void btn_Cancelar_Ac_Click(object sender, RoutedEventArgs e)
        {
            txt_nombre_ac.Text = string.Empty;
            txt_direccion_ac.Text = string.Empty;
            txt_tarifa_ac.Text = string.Empty;
            txt_cap_ac.Text = string.Empty;
            txt_nro_ac.Text = string.Empty;
            cbo_comuna_ac.SelectedIndex = -1;
            dptoActualizar = null;
            dhDpto_ac.IsOpen = false;
        }
    }
}
