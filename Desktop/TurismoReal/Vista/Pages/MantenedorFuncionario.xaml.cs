using Controlador;
using Modelo;
using System.Data;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;

namespace Vista.Pages
{
    public partial class MantenedorFuncionario : Page
    {
        public MantenedorFuncionario()
        {
            InitializeComponent();
            ListarFuncionario();
        }
        private void ItemError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }
        private void ListarFuncionario()
        {
            try
            {
                DataTable dataTable = CFuncionario.ListarFuncionario();
                if (dataTable != null)
                {
                    var funcionario = (from rw in dataTable.AsEnumerable()
                                   select new Funcionario()
                                   {
                                       IdUsuario = Convert.ToInt32(rw[0]),
                                       Rut = rw[8].ToString(),
                                       Nombres = rw[9].ToString(),
                                       Apellidos = rw[10].ToString(),
                                       Email = rw[1].ToString(),
                                       Telefono = Convert.ToInt32(rw[3])
                                   }).ToList();
                    dtgFuncionario.ItemsSource = funcionario;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_Agregar_Funcionario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_rut_ag.Text == string.Empty || txt_nombres_ag.Text == string.Empty || txt_apellidos_ag.Text == string.Empty ||
                    txt_fono_ag.Text == string.Empty || txt_email_ag.Text == string.Empty || txt_pass_ag.Text == string.Empty || txt_passConfirm_ag.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos");
                }
                else
                {
                    Funcionario userFuncionario = new()
                    {
                        Email = txt_email_ag.Text.Trim(),
                        Contraseña = txt_pass_ag.Text.Trim(),
                        Telefono = Convert.ToInt32(txt_fono_ag.Text.Trim()),
                        Rut = txt_rut_ag.Text.Trim(),
                        Nombres = txt_nombres_ag.Text.Trim(),
                        Apellidos = txt_apellidos_ag.Text.Trim(),
                    };

                    int estado = CFuncionario.CrearUsuarioFuncionario(userFuncionario);
                    MensajeOk("Funcionario agregado");
                    ListarFuncionario();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
        }
        private void DtgFuncionarioUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    Funcionario userFuncionario = (Funcionario)dtgFuncionario.SelectedItem;
                    try
                    {
                        int estado = CFuncionario.ActualizarFuncionario(userFuncionario);
                        MensajeOk("Funcionario actualizado");
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
        private void DtgFuncionarioDelete_Click(object sender, RoutedEventArgs e)
        {
            Funcionario funcionario = (Funcionario)dtgFuncionario.SelectedItem;
            try
            {
                MessageBoxResult result = MessageBox.Show("Estás seguro de querer eliminar este usuario funcionario?", "Funcionarios", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int estado = CFuncionario.EliminarFuncionario(funcionario.IdUsuario);
                    MensajeOk("Funcionario eliminado");
                    ListarFuncionario();
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
        private void btnAbrirAgregarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            dhFuncionario_ag.IsOpen = true;
        }
        private void btn_Cancelar_Ag_Click(object sender, RoutedEventArgs e)
        {
            dhFuncionario_ag.IsOpen = false;
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Funcionarios", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Funcionarios", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
