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
                string consulta = "select id,idProducto,idInsumo,cantidad from formulas ";
                if (id != 0)
                    consulta = consulta + "where idProducto=" + id.ToString()+ "and estado=1" ;
                else
                    consulta = consulta + "where estado=1"; 

                datos.setearQuery(consulta);
                datos.ejecutarLector();
               
                while (datos.lector.Read())
                {
                    aux = new Formula();
                    aux.id = datos.lector.GetInt64(0);
                    aux.idProducto = datos.lector.GetInt64(1);
                    aux.idInsumo= datos.lector.GetInt64(2);
                    aux.cantidad = datos.lector.GetInt32(3);
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
                datos.agregarParametro("@idProducto", aux.idProducto);
                datos.agregarParametro("@idInsumo", aux.idInsumo);
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
                datos.agregarParametro("@idInsumo", aux.idInsumo);
                datos.agregarParametro("@idProducto", aux.idProducto);
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
