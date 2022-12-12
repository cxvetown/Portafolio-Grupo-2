using Controlador;
using Modelo;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Vista.PagesFuncionario
{
    public partial class CheckIn : Page
    {
        public CheckIn()
        {
            InitializeComponent();
            ListarReservas();
        }

        private void btnCheckIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Reserva reserva = (Reserva)dtgReservas.SelectedItem;
                int IdReserva = reserva.IdReserva;
                char FirmaFunc = '1';
                char EstadoR = 'E';
                char EstadoP = 'L';
                MessageBoxResult result = MessageBox.Show("Quieres confirmar la firma?", "Reservas", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int estado = CReserva.ConfirmarFirma(IdReserva, FirmaFunc, EstadoR, EstadoP);
                    MensajeOk("Check-in realizado con éxito");
                    ListarReservas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Reservas", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ListarReservas()
        {
            try
            {
                DataTable dataTable = CReserva.ListarReservas(0);
                if (dataTable != null)
                {
                    foreach (var row in dataTable.AsEnumerable())
                    {
                        if (row[3].ToString() == "I")
                            row[3] = "Iniciada";
                        if (row[4].ToString() == "A")
                        {
                            row[4] = "Abonada";
                        }
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
