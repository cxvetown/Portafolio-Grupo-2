namespace Modelo
{
    public class Fotografia
    {
        private int id_foto;
        private int id_dpto;
        private string alt;

        public int Id_foto { get => id_foto; set => id_foto = value; }
        public int Id_dpto { get => id_dpto; set => id_dpto = value; }
        public string Alt { get => alt; set => alt = value; }
    }
}
