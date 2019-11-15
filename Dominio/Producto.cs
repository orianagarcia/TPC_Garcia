using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public long id { get; set; }
        public string nombre { get; set; }

        public long idMarca { get; set; }
        public long idCategoria { get; set; }
        public Double stock { get; set; }
        public Double costo { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public Double precioVenta { get; set; }
        public bool estado { get; set; } 

    }
}
