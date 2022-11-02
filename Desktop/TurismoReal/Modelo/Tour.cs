namespace Modelo
{
    public class Tour
    {
        private int idTour;
        private string nombreTour;
        private string descripcionTour;
        private int valorTour;
        private Region region;

        public int IdTour { get => idTour; set => idTour = value; }
        public string NombreTour { get => nombreTour; set => nombreTour = value; }
        public string DescripcionTour { get => descripcionTour; set => descripcionTour = value; }
        public int ValorTour { get => valorTour; set => valorTour = value; }
        public Region Region { get => region; set => region = value; }
    }
}
