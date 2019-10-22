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
        public Marca marca;
        public CategoriaProducto categoria;
        public Tipo tipo;
        public int stock { get; set; }
        public float costo { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public float precioVenta { get; set; }
        bool estado { get; set; } 

    }
}
