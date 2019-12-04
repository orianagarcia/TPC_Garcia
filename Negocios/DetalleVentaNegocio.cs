using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class DetalleVentaNegocio
    {
        public List<DetalleVenta> Listar(int id = 0)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            AccesoDatos datos = new AccesoDatos();
            DetalleVenta aux;

            try
            {
                string consulta = "select d.id, d.idVenta,d.idProducto,p.nombre, d.cantidad, d.precio, d.totalProducto  from detalleVenta as d inner join Ventas as v on v.id=d.idVenta inner join productos as p on p.id=d.idproducto where d.estado=1 ";
                if (id != 0)
                    consulta = consulta + " and d.idVenta= " + id.ToString();

                datos.setearQuery(consulta);
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux = new DetalleVenta();
                    aux.id = datos.lector.GetInt64(0);
                    aux.venta = new Venta();
                    aux.venta.id = datos.lector.GetInt64(1);
                    aux.producto = new Producto();
                    aux.producto.id = datos.lector.GetInt64(2);
                    aux.producto.nombre = datos.lector.GetString(3);
                    aux.cantidad = datos.lector.GetDouble(4);
                    aux.precio = datos.lector.GetDouble(5);
                    aux.totalProducto = datos.lector.GetDouble(6);
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

        public void Agregar(DetalleVenta aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("insert into detalleVenta values (@idVenta,@idProducto,@cant,@precio,@total,1)");
                datos.agregarParametro("@idVenta", aux.venta.id);
                datos.agregarParametro("@idProducto", aux.producto.id);
                datos.agregarParametro("@cant", aux.cantidad);
                datos.agregarParametro("@precio", aux.precio);
                datos.agregarParametro("@total", aux.totalProducto);
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
        public void DisminuirStock(DetalleVenta aux)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearQuery("update productos set stock=stock-@cant where id=@id ");
                datos.agregarParametro("@cant", aux.cantidad);
                datos.agregarParametro("@id", aux.producto.id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool VerificarStock(DetalleVenta aux)
        {
            AccesoDatos datos = new AccesoDatos();
            Producto pr = null;
            try
            {
                datos.setearQuery("select p.id,p.nombre,p.stock from productos as p where p.stock>=@cant and p.id=@id");
                datos.agregarParametro("@id", aux.producto.id);
                datos.agregarParametro("@cant", aux.cantidad);
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    pr = new Producto();
                    pr.id = datos.lector.GetInt64(0);
                    pr.nombre = datos.lector.GetString(1);
                    pr.stock = datos.lector.GetDouble(2);
                }
                if (pr != null)
                {
                    return true;
                }
                else return false;
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

        public long BuscarID()
        {
            AccesoDatos datos = new AccesoDatos();
            long id = 0;
            try
            {
                datos.setearQuery("SELECT TOP 1 ID FROM VENTAS ORDER BY ID DESC");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    id = datos.lector.GetInt64(0);
                }
                return id;
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
