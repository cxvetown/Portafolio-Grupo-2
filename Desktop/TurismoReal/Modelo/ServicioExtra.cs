namespace Modelo
{
    public class ServicioExtra
    {
        private int idServicioExtra;
        private string nombreServicioExtra;
        private string descripcionServicioExtra;
        private int valorServicioExtra;

        public int IdServicioExtra { get => idServicioExtra; set => idServicioExtra = value; }
        public string NombreServicioExtra { get => nombreServicioExtra; set => nombreServicioExtra = value; }
        public string DescripcionServicioExtra { get => descripcionServicioExtra; set => descripcionServicioExtra = value; }
        public int ValorServicioExtra { get => valorServicioExtra; set => valorServicioExtra = value; }
    }
}
