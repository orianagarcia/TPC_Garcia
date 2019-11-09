using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            Producto aux;
            List<Producto> lista = new List<Producto>();
            try
            {
                datos.setearQuery("select p.id,p.nombre,m.nombre as 'Marca',c.nombre as 'Categoria',stock,costo,precioVenta,ultimaActualizacion from productos as p inner join marcas as m on p.idMarca=m.id inner join categorias as c on p.idCategoria=c.id");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Producto();
                    aux.id = datos.lector.GetInt64(0);
                    aux.nombre = datos.lector.GetString(1);
                    aux.marca = new Marca();
                    aux.marca.nombre = datos.lector.GetString(2);
                    aux.categoria = new Categoria();
                    aux.categoria.nombre = datos.lector.GetString(3);
                    aux.stock = datos.lector.GetFloat(4);
                    aux.costo = datos.lector.GetFloat(5);
                    aux.precioVenta = datos.lector.GetFloat(6);
                    aux.fechaActualizacion = datos.lector.GetDateTime(7);
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Agregar(Producto aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Insert into productos values (@nombre,@marca, @categoria, @stock, @costo, @precioVenta,@fecha, @estado)");
                datos.agregarParametro("@nombre", aux.nombre);
                datos.agregarParametro("@marca", aux.marca.id);
                datos.agregarParametro("@categoria", aux.categoria.id);
                datos.agregarParametro("@stock", aux.stock);
                datos.agregarParametro("@costo", aux.costo);
                datos.agregarParametro("@precioVenta", aux.precioVenta);
                datos.agregarParametro("@fecha", aux.fechaActualizacion);
                datos.agregarParametro("@estado", aux.estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }

}
