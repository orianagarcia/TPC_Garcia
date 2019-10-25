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
        public int stock { get; set; }
        public long idMedida { get; set; }
    }
}
