using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleVenta
    {
        public long id { get; set; }
        public Venta venta { get; set; }
        public Producto producto { get; set; }
        public double precio { get; set; }
        public double cantidad { get; set; }
        public double totalProducto { get; set; }
        public bool estado { get; set; }
    }
}
