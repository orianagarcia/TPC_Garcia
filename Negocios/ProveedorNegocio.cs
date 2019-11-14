using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProveedorNegocio
    {
        public List <Proveedor> listar( )
        {
            AccesoDatos datos= new AccesoDatos();
            Proveedor aux;
            List<Proveedor> lista = new List<Proveedor>();
            try
            {
                datos.setearQuery("select id, nombre,telefono,direccion from proveedores where estado=1");
                datos.ejecutarLector();
                while(datos.lector.Read())
                {
                    aux = new Proveedor();
                    aux.id = datos.lector.GetInt64(0);
                    aux.nombre = datos.lector.GetString(1);
                    aux.telefono = datos.lector.GetString(2);
                    aux.direccion = datos.lector.GetString(3);
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

        public void agregar(Proveedor aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Insert into proveedores values (@nombre,@telefono, @direccion,1)");
                datos.agregarParametro("@nombre", aux.nombre);
                datos.agregarParametro("@telefono", aux.telefono);
                datos.agregarParametro("@direccion",aux.direccion);
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
        public void Modificar(Proveedor aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update proveedores set nombre = @nombre, direccion=@direccion, telefono=@telefono where ID = @Id");
                datos.Clear();
                datos.agregarParametro("@Id", aux.id);
                datos.agregarParametro("@nombre", aux.nombre);
                datos.agregarParametro("@direccion", aux.direccion);
                datos.agregarParametro("@telefono", aux.telefono);
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
                datos.setearQuery("update proveedores set estado = 0 where ID = @Id");
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
