using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class VentaNegocio
    {
        public List<Venta> listar(int id = 0)
        {
            AccesoDatos datos = new AccesoDatos();
            Venta venta;
            List<Venta> lista = new List<Venta>();
            try
            {
                string consulta = "select v.id,v.descripcion,v.idCliente,c.nombre,v.idEmpleado,e.nombre,v.fechaPedido,v.fechaEntrega,v.total,v.seña,v.estadoventa,v.formaPago from ventas as v inner join clientes as c on c.id=v.idCliente inner join empleados as e on e.id=v.idEmpleado ";
                if (id != 0)
                    consulta = consulta + " where v.id=" + id.ToString();
                datos.setearQuery(consulta);
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    venta = new Venta();
                    venta.id = datos.lector.GetInt64(0);
                    venta.descripcion = datos.lector.GetString(1);
                    venta.cliente = new Cliente();
                    venta.cliente.id = datos.lector.GetInt64(2);
                    venta.cliente.nombre = datos.lector.GetString(3);
                    venta.empleado = new Empleado();
                    venta.empleado.id = datos.lector.GetInt64(4);
                    venta.empleado.nombre = datos.lector.GetString(5);
                    venta.fechaPedido = datos.lector.GetDateTime(6);
                    venta.fechaEntrega = datos.lector.GetDateTime(7);
                    venta.total = datos.lector.GetDouble(8);
                    venta.seña = datos.lector.GetDouble(9);
                    venta.estado = datos.lector.GetString(10);
                    venta.formaPago = datos.lector.GetString(11);
                    
                    lista.Add(venta);
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

        public void agregar(Venta aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("insert into ventas values (@desc,@idCliente,@idEmpleado,@fechaPedido,@fechaEntrega,@total,@seña,@estado,@formaPago) ");
                datos.agregarParametro("@desc", aux.descripcion);
                datos.agregarParametro("@idCliente", aux.cliente.id);
                datos.agregarParametro("@idEmpleado", aux.empleado.id);
                datos.agregarParametro("@fechaPedido", aux.fechaPedido);
                datos.agregarParametro("@fechaEntrega", aux.fechaEntrega);
                datos.agregarParametro("@total", aux.total);
                datos.agregarParametro("@seña", aux.seña);
                datos.agregarParametro("@estado", aux.estado);
                datos.agregarParametro("@formaPago", aux.formaPago);
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
