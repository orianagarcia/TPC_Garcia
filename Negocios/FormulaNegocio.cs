using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio; 

namespace Negocio
{
    public class FormulaNegocio
    {
        public List<Formula> Listar(int id = 0)
        {
            AccesoDatos datos = new AccesoDatos();
            Formula aux;
            List<Formula> lista = new List<Formula>();
            try
            {
                string consulta = "select f.id,p.id,p.nombre,i.id,i.nombre,cantidad from formulas as f inner join productos as p on p.id = f.idProducto inner join insumos as i on f.idInsumo = i.id ";
                if (id != 0)
                    consulta = consulta + " where f.idProducto=" + id.ToString() ; 

                datos.setearQuery(consulta);
                datos.ejecutarLector();
               
                while (datos.lector.Read())
                {
                    aux = new Formula();
                    aux.id = datos.lector.GetInt64(0);
                    aux.producto = new Producto(); 
                    aux.producto.id = datos.lector.GetInt64(1);
                    aux.producto.nombre = datos.lector.GetString(2);
                    aux.insumo = new Insumo();
                    aux.insumo.id= datos.lector.GetInt64(3);
                    aux.insumo.nombre = datos.lector.GetString(4);
                    aux.cantidad = datos.lector.GetInt32(5);
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

        public void Agregar(Formula aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Insert into formulas values (@idProducto,@idInsumo, @cantidad,1)");
                datos.agregarParametro("@idProducto", aux.producto.id);
                datos.agregarParametro("@idInsumo", aux.insumo.id);
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
        public void Modificar(Formula aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update Formulas set idInsumo = @idInsumo, idProducto=@idProducto, cantidad=@cantidad where ID = @Id");
                datos.Clear();
                datos.agregarParametro("@Id", aux.id);
                datos.agregarParametro("@idInsumo", aux.insumo.id);
                datos.agregarParametro("@idProducto", aux.producto.id);
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
                datos.setearQuery("update formulas set estado = 0 where ID = @Id");
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
