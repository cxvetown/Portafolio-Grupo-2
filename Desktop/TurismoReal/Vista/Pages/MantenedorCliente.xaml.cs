using Controlador;
using Modelo;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Vista.Pages.Validaciones;

namespace Vista.Pages
{
    public partial class MantenedorCliente : Page
    {
        public MantenedorCliente()
        {
            InitializeComponent();
            ListarCliente();
        }
        private void ItemError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }
        private void ListarCliente()
        {
            try
            {
                DataTable dataTable = CCliente.ListarCliente();
                if (dataTable != null)
                {
                    var cliente = (from rw in dataTable.AsEnumerable()
                                   select new Cliente()
                                   {
                                       IdUsuario = Convert.ToInt32(rw[0]),
                                       Rut = rw[8].ToString(),
                                       Nombres = rw[9].ToString(),
                                       Apellidos = rw[10].ToString(),
                                       Email = rw[1].ToString(),
                                       Telefono = Convert.ToInt32(rw[3])
                                   }).ToList();
                    dtgCliente.ItemsSource = cliente;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_Agregar_Cliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (validarForm())
                {
                    string pattern = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
                    if (txt_pass_ag.Password.Length >= 8 && txt_pass_ag.Password.Length <= 30)
                    {
                        if (!Regex.IsMatch(txt_pass_ag.Password, pattern) || txt_pass_ag.Password != txt_passConfirm_ag.Password)
                        {
                            MessageBox.Show("Las contraseñas no coinciden o no son lo suficientemente seguras");
                            return;
                        }
                        string nRut = txt_rut_ag.Text.Split('-').First();
                        string dvRut = txt_rut_ag.Text.Split('-').Last();
                        if (!Rut.ValidaRut(nRut, dvRut))
                        {
                            MessageBox.Show("El RUT ingresado no es válido");
                            return;
                        }
                        pattern = "^\\S+@\\S+\\.\\S+$";
                        if (!Regex.IsMatch(txt_email_ag.Text, pattern))
                        {
                            MessageBox.Show("Ingrese un correo con formato válido");
                            return;
                        }
                        Cliente userCliente = new()
                        {
                            Email = txt_email_ag.Text.Trim(),
                            Contraseña = txt_pass_ag.Password.Trim(),
                            Telefono = Convert.ToInt32(txt_fono_ag.Text.Trim()),
                            Rut = txt_rut_ag.Text.Trim(),
                            Nombres = txt_nombres_ag.Text.Trim(),
                            Apellidos = txt_apellidos_ag.Text.Trim(),
                        };

                        int estado = CCliente.CrearUsuarioCliente(userCliente);
                        MensajeOk("Cliente agregado");
                        ListarCliente();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("La contraseña debe tener entre 8 y 30 caracteres");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }            
        }
        private bool validarForm()
        {
            try
            {
                if (txt_rut_ag.Text != string.Empty)
                {
                    if (txt_nombres_ag.Text != string.Empty)
                    {
                        if (txt_apellidos_ag.Text != string.Empty)
                        {
                            if (txt_email_ag.Text != string.Empty)
                            {
                                if (txt_fono_ag.Text != string.Empty)
                                {
                                    if (txt_pass_ag.Password != string.Empty)
                                    {
                                        if (txt_passConfirm_ag.Password != string.Empty)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            MensajeError("La confirmación de contraseña es requerida");
                                        }
                                    }
                                    else
                                    {
                                        MensajeError("La contraseña es requerida");
                                    }
                                }
                                else
                                {
                                    MensajeError("El teléfono es requerido");
                                }
                            }
                            else
                            {
                                MensajeError("El correo es requerido");
                            }
                        }
                        else
                        {
                            MensajeError("Los apellidos son requeridos");
                        }
                    }
                    else
                    {
                        MensajeError("Los nombres son requeridos");
                    }
                }
                else
                {
                    MensajeError("El RUT es requerido");
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void DtgClienteUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    string nRut = txt_rut_ag.Text.Split('-').First();
                    string dvRut = txt_rut_ag.Text.Split('-').Last();
                    if (!Rut.ValidaRut(nRut, dvRut))
                    {
                        MessageBox.Show("El rut ingresado no es válido");
                        return;
                    }
                    string pattern = "^\\S+@\\S+\\.\\S+$";
                    if (!Regex.IsMatch(txt_email_ag.Text, pattern))
                    {
                        MessageBox.Show("Ingrese un correo con formato válido");
                        return;
                    }
                    Cliente userCliente = (Cliente)dtgCliente.SelectedItem;
                    try
                    {
                        int estado = CCliente.ActualizarCliente(userCliente);
                        MensajeOk("Cliente actualizado");
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
        private void DtgClienteDelete_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = (Cliente)dtgCliente.SelectedItem;
            try
            {
                MessageBoxResult result = MessageBox.Show("Estás seguro de querer eliminar este usuario cliente?", "Clientes", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int estado = CCliente.EliminarCliente(cliente.IdUsuario);
                    MensajeOk("Cliente eliminado");
                    ListarCliente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Limpiar()
        {
            txt_email_ag.Clear();
            txt_pass_ag.Clear();
            txt_passConfirm_ag.Clear();
            txt_fono_ag.Clear();
            txt_rut_ag.Clear();
            txt_nombres_ag.Clear();
            txt_apellidos_ag.Clear();
        }
        private void btnAbrirAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            dhCliente_ag.IsOpen = true;
        }
        private void btn_Cancelar_Ag_Click(object sender, RoutedEventArgs e)
        {
            dhCliente_ag.IsOpen = false;
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Clientes", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Clientes", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void txt_fono_ag_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void txt_rut_ag_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length >= 2)
            {
                textBox.Text = textBox.Text.ToString().Insert(textBox.Text.Length - 1, "-");
            }
        }

        private void txt_rut_ag_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = textBox.Text.Replace("-", "");
        }

        private void txt_rut_ag_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9k]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_nombres_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Zá-úÁ-Ú]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_Email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@" + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                    [0-9]{1,2}|25[0-5]|2[0-4][0-9])\." + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                    [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|" + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
            Regex regex = new Regex(pattern);
            e.Handled = regex.IsMatch(e.Text);
        }


        Cliente? clienteActualizar;
        private void dtgCliente_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            clienteActualizar = (Cliente)dtgCliente.SelectedItem;
            if (clienteActualizar == null) return;
            dhCliente_ac.IsOpen = true;
            txt_rut_ac.Text = clienteActualizar.Rut;
            txt_nombres_ac.Text = clienteActualizar.Nombres;
            txt_apellidos_ac.Text = clienteActualizar.Apellidos;
            txt_fono_ac.Text = clienteActualizar.Telefono.ToString();
            txt_email_ac.Text = clienteActualizar.Email;
        }

        private void btn_Ac_Funcionario_Click(object sender, RoutedEventArgs e)
        {
            clienteActualizar.Nombres = txt_nombres_ac.Text;
            clienteActualizar.Apellidos = txt_apellidos_ac.Text;
            clienteActualizar.Telefono = int.Parse(txt_fono_ac.Text);
            clienteActualizar.Email = txt_email_ac.Text;
            int estado = CCliente.ActualizarCliente(clienteActualizar);
            if (estado > 0)
            {
                MessageBox.Show("Funcionario actualizado");
                ListarCliente();
            }
            dhCliente_ac.IsOpen = false;
            clienteActualizar = null;
        }

        private void btn_Cancelar_Ac_Click(object sender, RoutedEventArgs e)
        {
            txt_rut_ac.Text = string.Empty;
            txt_nombres_ac.Text = string.Empty;
            txt_apellidos_ac.Text = string.Empty;
            txt_fono_ac.Text = string.Empty;
            txt_email_ac.Text = string.Empty;
            clienteActualizar = null;
            dhCliente_ac.IsOpen = false;
        }
    }
}
