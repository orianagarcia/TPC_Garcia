using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio; 
namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            Categoria categoria;
            List<Categoria> lista = new List<Categoria>();
            try
            {
                datos.setearQuery("Select id,nombre from categorias ");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                   categoria = new Categoria();
                    categoria.id = datos.lector.GetInt64(0);
                    categoria.nombre = datos.lector.GetString(1);
                    lista.Add(categoria);

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
        public void Agregar(Categoria aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Insert into categorias values (@nombre)");
                datos.agregarParametro("@nombre", aux.nombre);
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
