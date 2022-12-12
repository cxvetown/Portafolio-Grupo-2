using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Vista.Pages
{
    public partial class MantenedorMantenimientoDpto : Page
    {
        private Departamento departamento;
        private List<DateTime> fechasInicio = new();
        private List<DateTime> fechasTermino = new();
        public MantenedorMantenimientoDpto(Departamento depto)
        {
            InitializeComponent();
            departamento = depto;
            ListarMantencion();
        }
        private void ItemError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }

        private void btnAbrirAgregarMantDpto_Click(object sender, RoutedEventArgs e)
        {
            dhMantDpto_ag.IsOpen = true;
        }

        private void DtgMantDptosUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Mantencion mantencion = (Mantencion)dtgMantDptos.SelectedItem;
                try
                {
                    int estado = CMantenimientoDpto.ActualizarMantDepto(mantencion);
                    MessageBox.Show("Mantención actualizada");
                    ListarMantencion();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void DtgMantDptoDelete_Click(object sender, RoutedEventArgs e)
        {
            Mantencion mantencion = (Mantencion)dtgMantDptos.SelectedItem;
            try
            {
                MessageBoxResult result = MessageBox.Show("Estás seguro de querer eliminar esta mantención?", "Mantenimiento", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int estado = CMantenimientoDpto.EliminarMantDpto(mantencion.IdMantencion);
                    MensajeOk("Mantención eliminada");
                    ListarMantencion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Mantención", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Mantención", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ListarMantencion()
        {
            try
            {
                DataTable dataTable = CMantenimientoDpto.ListarMantenimiento(departamento.IdDepto);
                if (dataTable != null)
                {
                    var mantenciones = (from rw in dataTable.AsEnumerable()
                                        select new Mantencion()
                                        {
                                            IdMantencion = Convert.ToInt32(rw[0]),
                                            IdDepto = departamento.IdDepto,
                                            NombreMantenimiento = rw[1].ToString(),
                                            DescripcionMantenimiento = rw[2].ToString(),
                                            FechaInicio = DateTime.Parse(rw[3].ToString()),
                                            FechaTermino = DateTime.Parse(rw[4].ToString()),
                                            CostoMantencion = Convert.ToInt32(rw[5]),
                                            Estado = rw[6].ToString()
                                        }).ToList();
                    foreach (Mantencion item in mantenciones)
                    {
                        fechasInicio.Add(item.FechaInicio);
                        fechasTermino.Add(item.FechaTermino);
                        dp_inicio_ag.BlackoutDates.Add(new CalendarDateRange(item.FechaInicio, item.FechaTermino));
                        dp_termino_ag.BlackoutDates.Add(new CalendarDateRange(item.FechaInicio, item.FechaTermino));
                    }
                    dtgMantDptos.ItemsSource = mantenciones;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_Agregar_MantDpto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mantencion mant = new Mantencion
                {
                    NombreMantenimiento = txt_nombre_ag.Text.Trim(),
                    DescripcionMantenimiento = txt_desc_ag.Text.Trim(),
                    FechaInicio = Convert.ToDateTime(dp_inicio_ag.SelectedDate.Value.Date.ToString("dd-MM-yyyy")),
                    FechaTermino = Convert.ToDateTime(dp_termino_ag.SelectedDate.Value.Date.ToString("dd-MM-yyyy")),
                    Estado = "p",
                    CostoMantencion = Convert.ToInt32(txt_costo_ag.Text.Trim())
                };

                int estado = CMantenimientoDpto.CrearMantDepto(mant, departamento.IdDepto);
                MensajeOk("Mantención agregada");
                Limpiar();
                ListarMantencion();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
        }

        private void Limpiar()
        {
            txt_nombre_ag.Clear();
            txt_desc_ag.Clear();
            txt_costo_ag.Clear();
            dp_inicio_ag.SelectedDate = null;
            dp_termino_ag.SelectedDate = null;
        }

        private void btn_Cancelar_Ag_Click(object sender, RoutedEventArgs e)
        {
            dhMantDpto_ag.IsOpen = false;
        }

        private void txt_string_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Zá-úÁ-Ú0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_costo_ag_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_Nombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Zá-úÁ-Ú]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_descripcion_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Zá-úÁ-Ú0-9, ]*$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void txt_Costo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void dp_inicio_ag_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dp_termino_ag.IsEnabled = true;
            dp_termino_ag.DisplayDateStart = dp_inicio_ag.SelectedDate;
            if (dp_inicio_ag.SelectedDate > dp_termino_ag.SelectedDate)
            {
                dp_termino_ag.SelectedDate = dp_inicio_ag.SelectedDate;
            }
        }

        private void dp_inicio_ac_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dp_inicio_ac.SelectedDate > dp_termino_ac.SelectedDate)
            {
                dp_termino_ac.SelectedDate = dp_inicio_ac.SelectedDate;
            }
        }

        Mantencion? mantActualizar;
        private void dtgMantDptos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            mantActualizar = (Mantencion)dtgMantDptos.SelectedItem;
            if (mantActualizar == null) return;
            dhMantDpto_ac.IsOpen = true;
            txt_nombre_ac.Text = mantActualizar.NombreMantenimiento;
            txt_desc_ac.Text = mantActualizar.DescripcionMantenimiento;
            txt_costo_ac.Text = mantActualizar.CostoMantencion.ToString();
            DisplayFechas(mantActualizar.FechaInicio, mantActualizar.FechaTermino);
            dp_inicio_ac.SelectedDate = mantActualizar.FechaInicio;
            dp_termino_ac.SelectedDate = mantActualizar.FechaTermino;
        }
        private void DisplayFechas(DateTime inicio, DateTime termino)
        {
            dp_inicio_ac.DisplayDateStart = default(DateTime);
            dp_termino_ac.DisplayDateEnd = new DateTime(9999, 12, 31);
            fechasInicio.Sort((a, b) => a.CompareTo(b));
            DateTime fechaSiguiente = fechasInicio.SkipWhile(x => x < termino).FirstOrDefault();
            fechasTermino.Sort((a, b) => a.CompareTo(b));
            DateTime fechaAnterior = fechasTermino.SkipWhile(x => x > inicio).FirstOrDefault();
            dp_inicio_ac.DisplayDateEnd = termino;
            if (!fechaAnterior.Equals(default(DateTime)))
            {
                dp_inicio_ac.DisplayDateStart = fechaAnterior.AddDays(1);
            }
            dp_termino_ac.DisplayDateStart = inicio;
            if (!fechaSiguiente.Equals(default(DateTime)))
            {
                dp_termino_ac.DisplayDateEnd = fechaSiguiente.AddDays(-1);
            }

        }
        private void btn_Actualizar_MantDpto_Click(object sender, RoutedEventArgs e)
        {
            mantActualizar.NombreMantenimiento = txt_nombre_ac.Text;
            mantActualizar.DescripcionMantenimiento = txt_desc_ac.Text;
            mantActualizar.CostoMantencion = int.Parse(txt_costo_ac.Text);
            mantActualizar.FechaInicio = (DateTime)dp_inicio_ac.SelectedDate;
            mantActualizar.FechaTermino = (DateTime)dp_termino_ac.SelectedDate;
            int estado = CMantenimientoDpto.ActualizarMantDepto(mantActualizar);
            if (estado > 0)
            {
                MessageBox.Show("Tour actualizado");
                ListarMantencion();
            }
            dhMantDpto_ac.IsOpen = false;
            mantActualizar = null;
        }

        private void btn_Cancelar_Ac_Click(object sender, RoutedEventArgs e)
        {
            txt_nombre_ac.Text = string.Empty;
            txt_desc_ac.Text = string.Empty;
            txt_costo_ac.Text = string.Empty;
            dp_inicio_ac.SelectedDate = null;
            dp_termino_ac.SelectedDate = null;
            mantActualizar = null;
            dhMantDpto_ac.IsOpen = false;
        }

    }
}
