using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Formula
    {
        public long id { get; set; }
         
        public Producto producto { get; set; }
        public Insumo insumo { get; set; }
        public double cantidad { get; set; }
    }
}
