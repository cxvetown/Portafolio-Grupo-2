namespace Modelo
{
    public class Comuna
    {
        private int idComuna;
        private string nombreComuna;
        private Region region;

        public int IdComuna { get => idComuna; set => idComuna = value; }
        public string NombreComuna { get => nombreComuna; set => nombreComuna = value; }
        public Region Region { get => region; set => region = value; }
    }
}
