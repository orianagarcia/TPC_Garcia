using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class FabricacionNegocio
    {
        public List<Fabricacion> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            Fabricacion aux;
            List<Fabricacion> lista = new List<Fabricacion>();
            try
            {
                datos.setearQuery("select id,idProducto,idEmpleado, cantidad from Fabricaciones where estado=1");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Fabricacion();
                    aux.id = datos.lector.GetInt64(0);
                    aux.idProducto = datos.lector.GetInt64(1);
                    aux.idEmpleado = datos.lector.GetInt64(2);
                    aux.cantidad = datos.lector.GetDouble(3);
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
        public void Agregar(Fabricacion aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Insert into Fabricaciones values (@idProducto, @cantidad,@idEmpleado,1)");
                datos.agregarParametro("@idProducto", aux.idProducto);
                datos.agregarParametro("@idEmpleado", aux.idEmpleado);
                datos.agregarParametro("@cantidad", aux.cantidad);
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
        public void Modificar(Fabricacion aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update Fabricaciones set idProducto=@idProducto,idEmpleado=@idEmpleado, cantidad=@cantidad where id=@id )");
                datos.agregarParametro("@id", aux.id);
                datos.agregarParametro("@idProducto", aux.idProducto);
                datos.agregarParametro("@idEmpleado", aux.idEmpleado);
                datos.agregarParametro("@cantidad", aux.cantidad);
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
                datos.setearQuery("update Fabricaciones set estado = 0 where ID = @id");
                datos.Clear();
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
    }
}
