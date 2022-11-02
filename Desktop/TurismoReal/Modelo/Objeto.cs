namespace Modelo
{
    public class Objeto
    {
        private int idObjeto;
        private string nombreObjeto;
        private int cantidadObjeto;
        private int valorUnitarioObjeto;

        public int IdObjeto { get => idObjeto; set => idObjeto = value; }
        public string NombreObjeto { get => nombreObjeto; set => nombreObjeto = value; }
        public int CantidadObjeto { get => cantidadObjeto; set => cantidadObjeto = value; }
        public int ValorUnitarioObjeto { get => valorUnitarioObjeto; set => valorUnitarioObjeto = value; }
    }
}
