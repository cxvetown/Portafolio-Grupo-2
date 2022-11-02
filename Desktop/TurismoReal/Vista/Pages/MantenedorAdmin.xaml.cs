using Controlador;
using Modelo;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Vista.Pages
{
    public partial class MantenedorAdmin : Page
    {
        public MantenedorAdmin()
        {
            InitializeComponent();
            ListarAdmin();
        }
        private void ItemError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }
        private void ListarAdmin()
        {
            try
            {
                DataTable dataTable = CAdmin.ListarAdmin();
                if (dataTable != null)
                {
                    var admin = (from rw in dataTable.AsEnumerable()
                                 select new Administrador()
                                 {
                                     IdUsuario = Convert.ToInt32(rw[0]),
                                     Rut = rw[8].ToString(),
                                     Nombres = rw[9].ToString(),
                                     Apellidos = rw[10].ToString(),
                                     Email = rw[1].ToString(),
                                     Telefono = Convert.ToInt32(rw[3])
                                 }).ToList();
                    dtgAdmin.ItemsSource = admin;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_Agregar_Admin_Click(object sender, RoutedEventArgs e)
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
                    Administrador userAdmin = new()
                    {
                        Email = txt_email_ag.Text.Trim(),
                        Contraseña = txt_pass_ag.Text.Trim(),
                        Telefono = Convert.ToInt32(txt_fono_ag.Text.Trim()),
                        Rut = txt_rut_ag.Text.Trim(),
                        Nombres = txt_nombres_ag.Text.Trim(),
                        Apellidos = txt_apellidos_ag.Text.Trim(),
                    };

                    int estado = CAdmin.CrearUsuarioAdmin(userAdmin);
                    MensajeOk("Administrador agregado");
                    ListarAdmin();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
        }
        private void DtgAdminUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    Administrador userAdmin = (Administrador)dtgAdmin.SelectedItem;
                    try
                    {
                        int estado = CAdmin.ActualizarAdmin(userAdmin);
                        MensajeOk("Administrador actualizado");
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
        private void DtgAdminDelete_Click(object sender, RoutedEventArgs e)
        {
            Administrador admin = (Administrador)dtgAdmin.SelectedItem;
            try
            {
                MessageBoxResult result = MessageBox.Show("Estás seguro de querer eliminar este usuario administrador?", "Administrador", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int estado = CAdmin.EliminarAdmin(admin.IdUsuario);
                    MensajeOk("Administrador eliminado");
                    ListarAdmin();
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
        private void btnAbrirAgregarAdmin_Click(object sender, RoutedEventArgs e)
        {
            dhAdmin_ag.IsOpen = true;
        }
        private void btn_Cancelar_Ag_Click(object sender, RoutedEventArgs e)
        {
            dhAdmin_ag.IsOpen = false;
        }       
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Administradores", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Administradores", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        

        
    }
}
