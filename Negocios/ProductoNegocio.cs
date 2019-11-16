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
        public List<Producto> Listar(int id = 0)
        {
            AccesoDatos datos = new AccesoDatos();
            Producto aux;
            List<Producto> lista = new List<Producto>();
            try
            {
                string consulta = "select id, nombre,idMarca as 'Marca',idCategoria as 'Categoria',stock,costo,precioVenta,ultimaActualizacion from productos ";
                if (id != 0)
                    consulta = consulta + "where id=" + id.ToString();

                datos.setearQuery(consulta);
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Producto();
                    aux.id = datos.lector.GetInt64(0);
                    aux.nombre = datos.lector.GetString(1);
                    aux.idMarca = datos.lector.GetInt64(2);
                    aux.idCategoria = datos.lector.GetInt64(3);
                    aux.stock = datos.lector.GetDouble(4);
                    aux.costo = datos.lector.GetDouble(5);
                    aux.precioVenta = datos.lector.GetDouble(6);
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
                datos.setearQuery("Insert into productos values (@nombreProd,@marca, @categoria, @stock, @costo, @precioVenta,@fecha, @estado)");
                datos.agregarParametro("@nombreProd", aux.nombre);
                datos.agregarParametro("@marca", aux.idMarca);
                datos.agregarParametro("@categoria", aux.idCategoria);
                datos.agregarParametro("@stock", aux.stock);
                datos.agregarParametro("@costo", aux.costo);
                datos.agregarParametro("@precioVenta", aux.precioVenta);
                datos.agregarParametro("@fecha",DateTime.Now);
                datos.agregarParametro("@estado", 1);
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
        public void Modificar(Producto aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update productos set nombre=@nombre, idMarca=@idMarca, idCategoria=@idCategoria, stock=@stock, costo=@costo, precioVenta=@precio, ultimaActualizacion=@fecha where id=@id");
                datos.Clear();
                datos.agregarParametro("@Id", aux.id);
                datos.agregarParametro("@nombre", aux.nombre);
                datos.agregarParametro("@idMarca", aux.idMarca);
                datos.agregarParametro("@idCategoria", aux.idCategoria);
                datos.agregarParametro("@stock", aux.stock);
                datos.agregarParametro("@costo", aux.costo);
                datos.agregarParametro("@precio", aux.precioVenta);
                datos.agregarParametro("@fecha", DateTime.Now);
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
        public void ModificarEstado(long id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update productos set estado = 0 where ID = @Id");
                datos.Clear();
                datos.agregarParametro("@Id", id);
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
