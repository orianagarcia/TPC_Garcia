using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class EmpleadoNegocio
    {
        public List<Empleado> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            Empleado aux;
            List<Empleado> lista = new List<Empleado>();
            try
            {
                datos.setearQuery("select id,dni,nombre,apellido,cargo,telefono from Empleados where estado=1");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Empleado();
                    aux.id = datos.lector.GetInt64(0);
                    aux.dni = datos.lector.GetInt32(1);
                    aux.nombre = datos.lector.GetString(2);
                    aux.apellido = datos.lector.GetString(3);
                    aux.cargo = datos.lector.GetString(4);
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
        public void Agregar(Empleado aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Insert into Empleados values (@dni,@nombre, @apellido, @telefono,@cargo,1)");
                datos.agregarParametro("@dni", aux.dni);
                datos.agregarParametro("@nombre", aux.nombre);
                datos.agregarParametro("@apellido", aux.apellido);
                datos.agregarParametro("@cargo", aux.cargo);
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
        public void Modificar(Empleado aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update Empleados set dni=@dni,nombre=@nombre, apellido=@apellido,cargo=@cargo, telefono=@telefono where id=@id");
                datos.agregarParametro("@id", aux.id);
                datos.agregarParametro("@dni", aux.dni);
                datos.agregarParametro("@nombre", aux.nombre);
                datos.agregarParametro("@apellido", aux.apellido);
                datos.agregarParametro("@cargo", aux.cargo);
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
                datos.setearQuery("update Empleados set estado = 0 where ID = @id");
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
