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
        public List<Fabricacion> Listar(int id=0)
        {
            AccesoDatos datos = new AccesoDatos();
            Fabricacion aux;
            List<Fabricacion> lista = new List<Fabricacion>();
            try
            {
                string consulta = "select f.id,f.idProducto,p.nombre,f.idEmpleado,e.nombre,f.cantidad,f.estadoFabricacion from fabricaciones as f  inner join productos as p on p.id=f.idProducto inner join empleados as e on e.id=f.idEmpleado ";
                if (id != 0)
                    consulta = consulta + " where f.id=" + id.ToString();
               
                datos.setearQuery(consulta);
                datos.ejecutarLector();
               
                while (datos.lector.Read())
                {
                    aux = new Fabricacion();
                    aux.id = datos.lector.GetInt64(0);
                    aux.producto = new Producto();
                    aux.producto.id = datos.lector.GetInt64(1);
                    aux.producto.nombre = datos.lector.GetString(2);
                    aux.empleado = new Empleado();
                    aux.empleado.id = datos.lector.GetInt64(3);
                    aux.empleado.nombre = datos.lector.GetString(4);
                    aux.cantidad = datos.lector.GetDouble(5);
                    aux.estadoFab = datos.lector.GetString(6);
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
                datos.setearQuery("Insert into Fabricaciones values (@idProducto, @cantidad,@idEmpleado,@estadoFab,1)");
                datos.agregarParametro("@idProducto", aux.producto.id);
                datos.agregarParametro("@idEmpleado", aux.empleado.id);
                datos.agregarParametro("@cantidad", aux.cantidad);
                datos.agregarParametro("@estadoFab", aux.estadoFab);
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
                datos.setearQuery("update Fabricaciones set idProducto=@idProducto,idEmpleado=@idEmpleado, cantidad=@cantidad, estadoFabricacion=@estadoFab where id=@id ");
                datos.agregarParametro("@id", aux.id);
                datos.agregarParametro("@idProducto", aux.producto.id);
                datos.agregarParametro("@idEmpleado", aux.empleado.id);
                datos.agregarParametro("@cantidad", aux.cantidad);
                datos.agregarParametro("@estadoFab", aux.estadoFab);
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
        public void AgregarStock(long id, double cant)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("update productos set stock= stock+@cant where id=@id");
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
        public void DisminuirStock(long id, double cant)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("update insumos set stock= stock-@cant where id=@id");
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
        public int ContarInsumosXProd (long id)
        {
            AccesoDatos datos = new AccesoDatos();
            int cantReg=0;
            try
            {
                datos.setearQuery("select count(*) from formulas where idProducto = @id and estado=1");
                datos.Clear();
                datos.agregarParametro("@id", id);
                datos.ejecutarLector();
                while(datos.lector.Read())
                {
                    cantReg = datos.lector.GetInt32(0);
                }
                return cantReg; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool VerificarStock(long id,int cantInsumos, double cantFab)
        {
            AccesoDatos datos = new AccesoDatos();
            Insumo insumo;
            List<Insumo> lista = new List<Insumo>();
            try
            {
                datos.setearQuery("select i.id,i.stock,f.idProducto,f.cantidad from insumos as i inner join formulas as f on i.id = f.idInsumo where f.idProducto = @id and i.stock >= f.cantidad*@cant and f.estado=1");
                datos.agregarParametro("@id", id);
                datos.agregarParametro("@cant", cantFab);
                datos.ejecutarLector();
                while(datos.lector.Read())
                {
                    insumo = new Insumo();
                    insumo.id = datos.lector.GetInt64(0);
                    insumo.stock = datos.lector.GetDouble(1);
                    lista.Add(insumo);
                }
                if (lista.Count == cantInsumos)
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
    }
}
