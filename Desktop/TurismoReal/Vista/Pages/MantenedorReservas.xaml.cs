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
    public partial class MantenedorReservas : Page
    {
        public MantenedorReservas()
        {
            InitializeComponent();
            ListarReservas();
        }
        private void ItemError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }

        private void btn_planificar_Click(object sender, RoutedEventArgs e)
        {
            dhCorreo.IsOpen = true;
        }

        private void btn_Enviar_Correo_Click(object sender, RoutedEventArgs e)
        {
            Reserva reserva = (Reserva)dtgReservas.SelectedItem;
            if (reserva != null)
            {
                string email = txtEmailAg.Text;
                string asunto = txtAsunto.Text;
                string lugar = txtTerminal.Text;
                if (email == null || asunto == null || lugar == null)
                {
                    return;
                }
                Mensajeria.PlanificarTransporte(email, asunto, reserva.CantidadAcompanantes.ToString(), lugar, reserva.CheckIn.ToString(), reserva.CheckOut.ToString(), reserva.Dpto.NombreDpto, reserva.Dpto.Direccion);
                MensajeOk("Correo de planificación enviado");
                dhCorreo.IsOpen = false;
            }
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            dhCorreo.IsOpen = false;
        }
        private void ListarReservas()
        {
            try
            {
                DataTable dataTable = CReserva.ListarReservas(2);
                if (dataTable != null)
                {
                    foreach (var row in dataTable.AsEnumerable())
                    {
                        if (row[3].ToString() == "X")
                            row[3] = "En curso";
                    }
                    var reservas = (from rw in dataTable.AsEnumerable()
                                 select new Reserva()
                                 {
                                     IdReserva = Convert.ToInt32(rw[0]),
                                     IdDepto = Convert.ToInt32(rw[1]),
                                     IdCliente = Convert.ToInt32(rw[2]),
                                     EstadoReserva = rw[3].ToString(),
                                     EstadoPago = rw[4].ToString(),
                                     CheckIn = DateTime.Parse(rw[5].ToString()),
                                     CheckOut = DateTime.Parse(rw[6].ToString()),
                                     Firma = rw[7].ToString(),
                                     CantidadAcompanantes = Convert.ToInt32(rw[8]),
                                     Transporte = rw[9].ToString(),
                                     ValorTotal = Convert.ToInt32(rw[10]),
                                     Cliente = new Cliente { Rut = rw[11].ToString(), Nombres = rw[12].ToString(), Apellidos = rw[13].ToString() },
                                     Dpto = new Departamento { NombreDpto = rw[15].ToString(), Direccion = rw[17].ToString() }
                                 }).ToList();
                    dtgReservas.ItemsSource = reservas;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Reservas", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Reservas", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    string valor = TxtBuscar.Text.ToString();
                    DataTable dataTable = CReserva.Buscar(valor);

                    if (dataTable != null)
                    {
                        foreach (var row in dataTable.AsEnumerable())
                        {
                            if (row[3].ToString() == "X")
                                row[3] = "En curso";
                        }
                        var reservas = (from rw in dataTable.AsEnumerable()
                                        select new Reserva()
                                        {
                                            IdReserva = Convert.ToInt32(rw[2]),
                                            IdDepto = Convert.ToInt32(rw[0]),
                                            IdCliente = Convert.ToInt32(rw[1]),
                                            EstadoReserva = rw[3].ToString(),
                                            EstadoPago = rw[4].ToString(),
                                            CheckIn = DateTime.Parse(rw[5].ToString()),
                                            CheckOut = DateTime.Parse(rw[6].ToString()),
                                            Firma = rw[7].ToString(),
                                            CantidadAcompanantes = Convert.ToInt32(rw[8]),
                                            Transporte = rw[9].ToString(),
                                            ValorTotal = Convert.ToInt32(rw[10]),
                                            Cliente = new Cliente { Rut = rw[11].ToString(), Nombres = rw[12].ToString(), Apellidos = rw[13].ToString() },
                                            Dpto = new Departamento { NombreDpto = rw[15].ToString(), Direccion = rw[17].ToString() }
                                        }).ToList();
                        dtgReservas.ItemsSource = reservas;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
        }
    }
}
