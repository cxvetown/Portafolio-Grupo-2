using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ServDpto
    {
        private int idServDpto;
        private int idDpto;
        private int estado;
        private string nombreServDpto;
        private string descServDpto;

        public int IdServDpto { get => idServDpto; set => idServDpto = value; }
        public string NombreServDpto { get => nombreServDpto; set => nombreServDpto = value; }
        public string DescServDpto { get => descServDpto; set => descServDpto = value; }
        public int IdDpto { get => idDpto; set => idDpto = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
