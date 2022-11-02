namespace Modelo
{
    public class Inventario
    {
        private int idInventario;
        private int valorTotal;
        private List<Objeto> objetos;
        public int IdInventario { get => idInventario; set => idInventario = value; }
        public int ValorTotal { get => valorTotal; set => valorTotal = value; }
        public List<Objeto> Objetos { get => objetos; set => objetos = value; }
    }
}
