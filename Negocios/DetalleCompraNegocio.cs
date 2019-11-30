using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class DetalleCompraNegocio
    {
        public List<Detallecompra> Listar(int id=0)
        {
            List<Detallecompra> lista = new List<Detallecompra>();
            AccesoDatos datos = new AccesoDatos();
            Detallecompra aux;

            try
            {
                string consulta = "select d.id, d.idcompra,d.idInsumo,i.nombre, d.cantidad, d.precioUnitario, d.totalProducto  from detalleCompra as d inner join compras as c on c.id=d.idCompra inner join insumos as i on i.id=d.idinsumo where d.estado=1 ";
                if (id != 0)
                    consulta = consulta + " and idCompra=" + id.ToString();

                datos.setearQuery(consulta);
                datos.ejecutarLector();
                while(datos.lector.Read())
                {
                    aux = new Detallecompra();
                    aux.id = datos.lector.GetInt64(0);
                    aux.compra = new Compra();
                    aux.compra.id = datos.lector.GetInt64(1);
                    aux.insumo = new Insumo();
                    aux.insumo.id = datos.lector.GetInt64(2);
                    aux.insumo.nombre = datos.lector.GetString(3);
                    aux.cantidad = datos.lector.GetInt32(4);
                    aux.precioUnitario = datos.lector.GetDouble(5);
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

        public void Agregar(Detallecompra aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Insert into detalleCompra values (@idCompra,@idIns, @cant,@precioUnitario,@totalProducto,1)");
                datos.agregarParametro("@idCompra", aux.compra.id);
                datos.agregarParametro("@idIns", aux.insumo.id);
                datos.agregarParametro("@cant", aux.cantidad);
                datos.agregarParametro("@precioUnitario", aux.precioUnitario);
                datos.agregarParametro("@totalProducto", aux.totalProducto); 
                datos.ejecutarAccion();
                datos.setearQuery("update insumos set stock=@cantidad where id=@idInsumo ");
                datos.agregarParametro("@cantidad", aux.cantidad);
                datos.agregarParametro("@idInsumo", aux.insumo.id);
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
        public void Modificar(Detallecompra aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update detallecompra set idInsumo=@idIns,cantidad=@cant , precioUnitario=@precio, totalProducto=@totalProducto where id= @id");
                datos.agregarParametro("@id", aux.id);
                datos.agregarParametro("@idIns", aux.insumo.id);
                datos.agregarParametro("@cant", aux.cantidad);
                datos.agregarParametro("@precio", aux.precioUnitario);
                datos.agregarParametro("@totalProducto", aux.totalProducto);
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
        public void AgregarStock(long id, int cant)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("update insumos set stock= stock+@cant where id=@id");
                datos.agregarParametro("@cant", cant);
                datos.agregarParametro("@id", id);
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
        public void AgregarComentario(long id,string desc)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("insert into comentariosXcompra values (@id,@desc,@dia) ");
                datos.agregarParametro("@id", id);
                datos.agregarParametro("@desc", desc);
                datos.agregarParametro("@dia", DateTime.Now);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public void EliminarStock(Detallecompra aux)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearQuery("update insumos set stock=stock-@cant where id=@id ");
                datos.agregarParametro("@cant", aux.cantidad);
                datos.agregarParametro("@id", aux.insumo.id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }
        public void ModificarEstado(long id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update detallecompra set estado=0 where id= @id");
                datos.agregarParametro("@id",id);
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
        public Detallecompra BuscarDetalle(int id)
        {
             AccesoDatos datos = new AccesoDatos();
             Detallecompra aux =  new Detallecompra(); ;

            try
            {
                string consulta = "select d.id, d.idcompra,d.idInsumo,i.nombre, d.cantidad, d.precioUnitario, d.totalProducto  from detalleCompra as d inner join compras as c on c.id=d.idCompra inner join insumos as i on i.id=d.idinsumo where d.id=@id";
                datos.agregarParametro("@id", id);
                datos.setearQuery(consulta);
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux.id = datos.lector.GetInt64(0);
                    aux.compra = new Compra();
                    aux.compra.id = datos.lector.GetInt64(1);
                    aux.insumo = new Insumo();
                    aux.insumo.id = datos.lector.GetInt64(2);
                    aux.insumo.nombre = datos.lector.GetString(3);
                    aux.cantidad = datos.lector.GetInt32(4);
                    aux.precioUnitario = datos.lector.GetDouble(5);
                    aux.totalProducto = datos.lector.GetDouble(6);
                }
                return aux;
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
