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
        public Empleado empeado { get; set; }
        public DateTime fechaEntrega { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public List<DetalleVenta> detalle { get; set; }
        public decimal Total { get; set; }
        public decimal seña { get; set; }
        public string formaPago { get; set; }
        public string estado { get; set; }
    }
}
