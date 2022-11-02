namespace Modelo
{
    public class Reserva
    {
        private int idReserva;
        private int idDepto;
        private int idCliente;
        private string estadoReserva;
        private string estadoPago;
        private DateTime checkIn;
        private DateTime checkOut;
        private string firma;
        private int cantidadAcompanantes;
        private string transporte;
        private int valorTotal;
        private Departamento dpto;
        private Cliente cliente;

        public int IdReserva { get => idReserva; set => idReserva = value; }
        public int IdDepto { get => idDepto; set => idDepto = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string EstadoReserva { get => estadoReserva; set => estadoReserva = value; }
        public string EstadoPago { get => estadoPago; set => estadoPago = value; }
        public DateTime CheckIn { get => checkIn; set => checkIn = value; }
        public DateTime CheckOut { get => checkOut; set => checkOut = value; }
        public string Firma { get => firma; set => firma = value; }
        public int CantidadAcompanantes { get => cantidadAcompanantes; set => cantidadAcompanantes = value; }
        public string Transporte { get => transporte; set => transporte = value; }
        public int ValorTotal { get => valorTotal; set => valorTotal = value; }
        public Departamento Dpto { get => dpto; set => dpto = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
    }
}
