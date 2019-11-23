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
                string consulta = "select id,idProducto,idEmpleado, cantidad,estadoFabricacion from Fabricaciones ";
                if (id != 0)
                    consulta = consulta + "where id=" + id.ToString() + " and estado = 1";
                else
                    consulta = consulta + "where estado = 1";

                datos.setearQuery(consulta);
                datos.ejecutarLector();
               
                while (datos.lector.Read())
                {
                    aux = new Fabricacion();
                    aux.id = datos.lector.GetInt64(0);
                    aux.idProducto = datos.lector.GetInt64(1);
                    aux.idEmpleado = datos.lector.GetInt64(2);
                    aux.cantidad = datos.lector.GetDouble(3);
                    aux.estadoFab = datos.lector.GetString(4);
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
                datos.agregarParametro("@idProducto", aux.idProducto);
                datos.agregarParametro("@idEmpleado", aux.idEmpleado);
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
                datos.agregarParametro("@idProducto", aux.idProducto);
                datos.agregarParametro("@idEmpleado", aux.idEmpleado);
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
        public int ContarInsumosXProd (long id)
        {
            AccesoDatos datos = new AccesoDatos();
            int cantReg=0;
            try
            {
                datos.setearQuery("select count(*) from formulas where idProducto = @id");
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
                datos.setearQuery("select i.id,i.stock,f.idProducto,f.cantidad from insumos as i inner join formulas as f on i.id = f.idInsumo where f.idProducto = @id and i.stock > f.cantidad*@cant");
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
