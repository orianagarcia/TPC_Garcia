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
         public long idProducto { get; set; }

        //public Producto Producto;
        public long idInsumo { get; set; }
        public float cantidad { get; set; }
    }
}
