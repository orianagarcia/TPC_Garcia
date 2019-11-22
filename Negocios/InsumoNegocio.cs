using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class InsumoNegocio
    {
        public List<Insumo> listar(int id = 0)
        {
            AccesoDatos datos = new AccesoDatos();
            Insumo aux;
            List<Insumo> lista = new List <Insumo> ();
            try
            {
                string consulta = "SELECT id,nombre,stock,medida from insumos ";
                if (id != 0)
                    {
                    consulta = consulta + "where id=" + id.ToString() + " and estado=1";
                }
                else
                {
                    consulta = consulta + "where estado=1";
                }
                   

                datos.setearQuery(consulta);
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Insumo();
                    aux.id = datos.lector.GetInt64(0);
                    aux.nombre = datos.lector.GetString(1);
                    aux.stock = datos.lector.GetDouble(2);
                    aux.Medida = datos.lector.GetString(3);
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

        public void agregar(Insumo aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Insert into insumos values (@nombre,@stock, @Medida,1)");
                datos.agregarParametro("@nombre", aux.nombre);
                datos.agregarParametro("@stock", aux.stock);
                datos.agregarParametro("Medida", aux.Medida);
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

        public void ModificarEstado(long cod)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update insumos set estado = 0 where ID = @Id");
                datos.Clear();
                datos.agregarParametro("@ID", cod);
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

        public void Modificar(Insumo aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update insumos set nombre = @nombre, stock= @stock, Medida = @medida where ID = @Id");
                datos.Clear();
                datos.agregarParametro("@Id",aux.id);
                datos.agregarParametro("@nombre", aux.nombre);
                datos.agregarParametro("@stock", aux.stock);
                datos.agregarParametro("@medida", aux.Medida);
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
