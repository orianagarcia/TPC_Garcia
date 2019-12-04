using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public long id { get; set; }
        public string descripcion { get; set; }
        public Cliente cliente { get; set; }
        public Empleado empleado { get; set; }
        public DateTime fechaEntrega { get; set; }
        public DateTime fechaPedido { get; set; }
        public List<DetalleVenta> detalle { get; set; }
        public double total { get; set; }
        public double seña { get; set; }
        public string formaPago { get; set; }
        public string estado { get; set; }
    }
}
