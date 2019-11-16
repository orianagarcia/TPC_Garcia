using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Insumo
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public double stock { get; set; }
        public string Medida { get; set; }
        public bool estado { get; set; }
    }
}
