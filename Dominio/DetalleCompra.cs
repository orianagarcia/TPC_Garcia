using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleCompra
    {
        public long id { get; set; }
        public long idCompra { get; set; }
        public long idInsumo { get; set; }
        public int cantidad { get; set; }
        public double precioUnitario { get; set; }
        public double totalProducto { get; set; } 
        public bool estado { get; set; }
    }
}
