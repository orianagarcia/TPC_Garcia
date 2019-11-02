using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EstadoNegocio
    {
        public List<Estado> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            Estado aux;
            List<Estado> lista = new List<Estado>();
            try
            {
                datos.setearQuery("SELECT id,nombre,descripcion from estados");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Estado();
                    aux.id = datos.lector.GetInt64(0);
                    aux.descripcion = datos.lector.GetString(1);
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
    }
}
