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
            ServicioDpto servicioDpto = (ServicioDpto)dtgServDpto.SelectedItem;
            try
            {
                int estado = CServicioDpto.EliminarServicio(servicioDpto.IdServDpto);
                MessageBox.Show("Servicio eliminado");
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
                        ServicioDpto servicioDpto = new()
                        {
                            NombreServDpto = txt_nombre_ag.Text.Trim(),
                            DescServDpto = txt_desc_ag.Text.Trim()
                        };
                        int estado = CServicioDpto.IngresarServicioDpto(servicioDpto);
                        MessageBox.Show("Servicio agregado");
                        ListarServicioDpto();
                        Limpiar();
                    }
                    catch (Exception)
                    {
                        throw;
                    }                    
                }
            }
        }
        private void ListarServicioDpto()
        {
            try
            {
                DataTable dataTable = CServicioDpto.ListarServiciosDpto();
                if (dataTable != null)
                {
                    var ServDpto = (from rw in dataTable.AsEnumerable()
                                select new ServicioDpto()
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

        private void DtgServDptoUpdate_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ServicioDpto servicioDpto = (ServicioDpto)dtgServDpto.SelectedItem;
                try
                {
                    int estado = CServicioDpto.ActualizarServicioDpto(servicioDpto);
                    MessageBox.Show("Servicio actualizado");
                    ListarServicioDpto();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
