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
                datos.setearQuery("select id, nombre,telefono,direccion from proveedores");
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
                datos.setearQuery("Insert into proveedores values (@nombre,@telefono, @direccion)");
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
    }
}
