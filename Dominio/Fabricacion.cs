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
        public Producto producto { get; set; }
        public Empleado empleado { get; set;  }
        public double cantidad { get; set; }
        public string estadoFab { get; set; }
        public bool estado { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
            
    }
}
