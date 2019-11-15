using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Fabricacion
    {
        public long id { get; set; }
        public long idProducto { get; set; }
        public long idEmpleado { get; set;  }
        public double cantidad { get; set; }
        public bool estado { get; set; }
            
    }
}
