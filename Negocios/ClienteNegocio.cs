using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente aux;
            List<Cliente> lista = new List<Cliente>();
            try
            {
                datos.setearQuery("select dni,nombre,apellido,direccion,localidad,telefono from clientes where estado=1");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Cliente();
                    aux.dni = datos.lector.GetInt32(0);
                    aux.nombre = datos.lector.GetString(1);
                    aux.apellido = datos.lector.GetString(2);
                    aux.direccion = datos.lector.GetString(3);
                    aux.localidad = datos.lector.GetString(4);
                    aux.telefono = datos.lector.GetString(5);
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
        public void Agregar(Cliente aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Insert into clientes values (@dni,@nombre, @apellido, @direccion, @localidad, @telefono,1)");
                datos.agregarParametro("@dni", aux.dni);
                datos.agregarParametro("@nombre", aux.nombre);
                datos.agregarParametro("@apellido", aux.apellido);
                datos.agregarParametro("@direccion", aux.direccion);
                datos.agregarParametro("@localidad", aux.localidad);
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
        public void Modificar(Cliente aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update clientes set dni=@dni,nombre=@nombre, apellido=@apellido,direccion=@direccion, localidad=@localidad, telefono=@telefono where id=@id");
                datos.agregarParametro("id", aux.id);
                datos.agregarParametro("@dni", aux.dni);
                datos.agregarParametro("@nombre", aux.nombre);
                datos.agregarParametro("@apellido", aux.apellido);
                datos.agregarParametro("@direccion", aux.direccion);
                datos.agregarParametro("@localidad", aux.localidad);
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
                datos.setearQuery("update clientes set estado = 0 where ID = @Id");
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
