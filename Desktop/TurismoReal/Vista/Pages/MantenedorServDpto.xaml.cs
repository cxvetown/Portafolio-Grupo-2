using Controlador;
using Modelo;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Vista.Pages
{
    public partial class MantenedorServDpto : Page
    {
        public MantenedorServDpto()
        {
            InitializeComponent();
            ListarServicioDpto();
        }
        private void ItemError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Servicios Departamento", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Servicios Departamento", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void Limpiar()
        {
            txt_nombre_ag.Clear();
            txt_desc_ag.Clear();
        }
        private void btnAbrirAgregarServDpto_Click(object sender, RoutedEventArgs e)
        {
            dhServDpto_ag.IsOpen = true;
        }

        private void DtgServDptoDelete(object sender, RoutedEventArgs e)
        {
            Servicio servicioDpto = (Servicio)dtgServDpto.SelectedItem;
            try
            {
                int estado = CServicio.EliminarServicio(servicioDpto.IdServDpto);
                MensajeOk("Servicio eliminado");
                ListarServicioDpto();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btn_Agregar_ServicioDpto_Click(object sender, RoutedEventArgs e)
        {
            if (!txt_nombre_ag.Text.Trim().Equals(""))
            {
                if (!txt_desc_ag.Text.Trim().Equals(""))
                {
                    try
                    {
                        Servicio servicioDpto = new()
                        {
                            NombreServDpto = txt_nombre_ag.Text.Trim(),
                            DescServDpto = txt_desc_ag.Text.Trim()
                        };
                        int estado = CServicio.IngresarServicioDpto(servicioDpto);
                        MensajeOk("Servicio agregado");
                        ListarServicioDpto();
                        Limpiar();
                    }
                    catch (Exception)
                    {
                        throw;
                    }                    
                }
                else
                {
                    MensajeError("La descripción es requerida");
                }
            }
            else
            {
                MensajeError("El nombre es requerido");
            }
        }
        private void ListarServicioDpto()
        {
            try
            {
                DataTable dataTable = CServicio.ListarServiciosDpto();
                if (dataTable != null)
                {
                    var ServDpto = (from rw in dataTable.AsEnumerable()
                                select new Servicio()
                                {
                                    IdServDpto = Convert.ToInt32(rw[0]),
                                    NombreServDpto = rw[1].ToString(),
                                    DescServDpto = rw[2].ToString(),
                                }).ToList();
                    dtgServDpto.ItemsSource = ServDpto;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btn_Cancelar_Ag_Click(object sender, RoutedEventArgs e)
        {
            dhServDpto_ag.IsOpen = false;
        }

        private void DtgServDptoUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Servicio servicio = (Servicio)dtgServDpto.SelectedItem;
                if (e.Key == Key.Enter && ValidarCamposDataGrid(servicio))
                {
                    try
                    {
                        int estado = CServicio.ActualizarServicioDpto(servicio);
                        MensajeOk("Servicio actualizado");
                        ListarServicioDpto();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }           
        }
        private bool ValidarCamposDataGrid(Servicio servicio)
        {
            try
            {
                if (servicio.NombreServDpto.Trim() != string.Empty)
                {
                    if (servicio.DescServDpto.Trim() != string.Empty)
                    {
                        return true;
                    }
                    else
                    {
                        MensajeError("Descripción es un campo requerido");
                    }
                }
                else
                {
                    MensajeError("Nombre es un campo requerido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
            return false;
        }

        private void txt_nombre_ag_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Zá-úÁ-Ú0-9, ]*$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void txt_desc_ag_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Zá-úÁ-Ú0-9, ]*$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        Servicio? servActualizar;
        private void dtgServDpto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            servActualizar = (Servicio)dtgServDpto.SelectedItem;
            if (servActualizar == null) return;
            dhServDpto_ac.IsOpen = true;
            txt_nombre_ac.Text = servActualizar.NombreServDpto;
            txt_desc_ac.Text = servActualizar.DescServDpto;
        }

        private void btn_Actualizar_ServD_Click(object sender, RoutedEventArgs e)
        {
            servActualizar.NombreServDpto = txt_nombre_ac.Text;
            servActualizar.DescServDpto = txt_desc_ac.Text;
            int estado = CServicio.ActualizarServicioDpto(servActualizar);
            if (estado > 0)
            {
                MensajeOk("Servicio actualizado");
                ListarServicioDpto();
            }
            dhServDpto_ac.IsOpen = false;
            servActualizar = null;
        }

        private void btn_Cancelar_Ac_Click(object sender, RoutedEventArgs e)
        {
            txt_nombre_ac.Text = string.Empty;
            txt_desc_ac.Text = string.Empty;
            servActualizar = null;
            dhServDpto_ac.IsOpen = false;
        }
    }
}
