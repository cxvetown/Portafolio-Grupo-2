namespace Modelo
{
    public class Region
    {
        private int idRegion;
        private string nombreRegion;
        private List<Comuna> comunas;

        public int IdRegion { get => idRegion; set => idRegion = value; }
        public string NombreRegion { get => nombreRegion; set => nombreRegion = value; }
        public List<Comuna> Comunas { get => comunas; set => comunas = value; }
    }
}
