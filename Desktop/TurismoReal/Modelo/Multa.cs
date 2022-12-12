using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Multa
    {
        private int idMulta;
        private string razonMulta;
        private string descMulta;
        private int valorMulta;

        public string RazonMulta { get => razonMulta; set => razonMulta = value; }
        public string DescMulta { get => descMulta; set => descMulta = value; }
        public int ValorMulta { get => valorMulta; set => valorMulta = value; }
        public int IdMulta { get => idMulta; set => idMulta = value; }
    }
}
