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

namespace Vista.PagesFuncionario
{
    public partial class CheckList : Page
    {
        Reserva reserva;
        public CheckList(Reserva res)
        {
            InitializeComponent();
            reserva = res;
            ListarObjetos();
        }
        private void ListarObjetos()
        {
            try
            {
                DataTable dataTable = CInventario.ListarInventario(reserva.IdDepto);
                if (dataTable != null)
                {
                    var Objetos = (from rw in dataTable.AsEnumerable()
                                   select new Objeto()
                                   {
                                       IdObjeto = Convert.ToInt32(rw[0]),
                                       NombreObjeto = rw[2].ToString(),
                                       CantidadObjeto = Convert.ToInt32(rw[3]),
                                       ValorUnitarioObjeto = Convert.ToInt32(rw[4])
                                   }).ToList();
                    foreach (var item in Objetos)
                    {
                        List<int> lista = new();
                        for (int i = 0; i <= item.CantidadObjeto; i++) lista.Add(i);
                        item.AuxCant = lista;
                    }
                    dtgItems.ItemsSource = Objetos;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb == null) return;
            Objeto objeto = (Objeto)dtgItems.SelectedItem;
            if (objeto == null) return;
            for (int i = 0; i < dtgObjetosAfectados.Items.Count; i++)
            {
                Objeto auxObj = (Objeto)dtgObjetosAfectados.Items[i];
                if (auxObj.IdObjeto == objeto.IdObjeto)
                {
                    if (cb.SelectedIndex > 0)
                    {
                        auxObj.CantidadObjeto = (int)cb.SelectedValue;
                        int costo = objeto.ValorUnitarioObjeto * (int)cb.SelectedValue;
                        auxObj.ValorUnitarioObjeto = costo;
                        PrecioTotal();
                        dtgObjetosAfectados.Items.Refresh();
                        return;
                    }
                    else
                    {
                        dtgObjetosAfectados.Items.Remove(auxObj);
                        PrecioTotal();
                        return;
                    }
                }
            }
            Objeto multaObjeto = new()
            {
                IdObjeto = objeto.IdObjeto,
                NombreObjeto = objeto.NombreObjeto,
                CantidadObjeto = (int)cb.SelectedValue,
                ValorUnitarioObjeto = objeto.ValorUnitarioObjeto * (int)cb.SelectedValue
            };
            dtgObjetosAfectados.Items.Add(multaObjeto);
            PrecioTotal();

        }
        private void PrecioTotal()
        {
            int costo = 0;
            foreach (var item in dtgObjetosAfectados.Items)
            {
                Objeto objeto = (Objeto)item;
                costo += objeto.ValorUnitarioObjeto;
            }
            lblCostoObj.Content = costo;
            lblCostoTotal.Content = int.Parse(txtOtrosCostos.Text) + int.Parse(lblCostoObj.Content.ToString());
        }
        private void txtOtrosCostos_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void txtOtrosCostos_KeyUp(object sender, KeyEventArgs e)
        {
            if (int.TryParse(txtOtrosCostos.Text, out int costos))
            {
                lblCostoTotal.Content = costos + int.Parse(lblCostoObj.Content.ToString());
            }
            else
            {
                lblCostoTotal.Content = int.Parse(lblCostoObj.Content.ToString());
            }
        }

        private void txtOtrosCostos_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtOtrosCostos.Text == "0")
            {
                txtOtrosCostos.Text = "";
            }
        }

        private void txtOtrosCostos_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtOtrosCostos.Text == "")
            {
                txtOtrosCostos.Text = "0";
            }
        }
        private void btnGenerarMulta_Click(object sender, RoutedEventArgs e)
        {
            Multa multa = new()
            {
                RazonMulta = txtRazonMulta.Text,
                DescMulta = txtDescripción.Text,
                ValorMulta = int.Parse(lblCostoTotal.Content.ToString())
            };
            char FirmaFunc = '1';
            char EstadoR = 'T';
            char EstadoP = 'L';
            int estado = CReserva.ConfirmarFirma(reserva.IdReserva, FirmaFunc, EstadoR, EstadoP);
            if (estado <= 0) return; 
            estado = CMulta.GenerarMulta(multa, reserva.IdReserva, reserva.IdDepto, reserva.IdCliente);
            if (estado > 0)
            {
                foreach (var item in dtgObjetosAfectados.Items)
                {
                    Objeto objeto = (Objeto)item;
                    int estado2 = CMulta.ObjetoAfectado(estado, objeto.IdObjeto, objeto.CantidadObjeto);
                    if (estado2 > 0) MessageBox.Show("Ag");
                }
            }
        }

    }
}
