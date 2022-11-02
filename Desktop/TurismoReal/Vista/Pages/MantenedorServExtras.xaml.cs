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
    public partial class MantenedorServExtras : Page
    {
        public MantenedorServExtras()
        {
            InitializeComponent();
            ListarSvE();
        }
        private void ItemError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }
        #region Agregar
        private void btnAbrirAgregarServ_Click(object sender, RoutedEventArgs e)
        {
            dhServ_ag.IsOpen = true;
        }
        private void btn_Agregar_Servicio_Click(object sender, RoutedEventArgs e)
        {
            if (!txt_nombre_ag.Text.Trim().Equals(""))
            {
                if (!txt_desc_ag.Text.Trim().Equals(""))
                {
                    if (int.TryParse(txt_precio_ag.Text, out int precio))
                    {
                        try
                        {
                            ServicioExtra servicioExtra = new()
                            {
                                NombreServicioExtra = txt_nombre_ag.Text,
                                DescripcionServicioExtra = txt_desc_ag.Text,
                                ValorServicioExtra = precio
                            };
                            int estado = CServicioExtra.IngresarServicio(servicioExtra);
                            MessageBox.Show("Servicio agregado");
                            ListarSvE();
                            Limpiar();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
        }
        private void Limpiar()
        {
            txt_nombre_ag.Clear();
            txt_desc_ag.Clear();
            txt_precio_ag.Clear();
        }

        private void btn_Cancelar_Ag_Click(object sender, RoutedEventArgs e)
        {
            dhServ_ag.IsOpen = false;
        }
        #endregion
        #region Listar
        private void ListarSvE()
        {
            try
            {
                DataTable dataTable = CServicioExtra.ListarServicios();
                if (dataTable != null)
                {
                    var Serv = (from rw in dataTable.AsEnumerable()
                                select new ServicioExtra()
                                {
                                    IdServicioExtra = Convert.ToInt32(rw[0]),
                                    NombreServicioExtra = rw[1].ToString(),
                                    DescripcionServicioExtra = rw[2].ToString(),
                                    ValorServicioExtra = Convert.ToInt32(rw[3])
                                }).ToList();
                    dtgServE.ItemsSource = Serv;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        private void DtgServUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ServicioExtra servicioExtra = (ServicioExtra)dtgServE.SelectedItem;
                try
                {
                    int estado = CServicioExtra.ActualizarServicio(servicioExtra);
                    MessageBox.Show("Servicio actualizado");
                    ListarSvE();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        private void DtgServDelete(object sender, RoutedEventArgs e)
        {
            ServicioExtra servicioExtra = (ServicioExtra)dtgServE.SelectedItem;
            try
            {
                int estado = CServicioExtra.EliminarServicio(servicioExtra.IdServicioExtra);
                MessageBox.Show("Servicio eliminado");
                ListarSvE();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
