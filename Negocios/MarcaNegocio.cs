using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio; 
namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            Marca marca;
            List<Marca> lista = new List<Marca>();
            try
            {
                datos.setearQuery("Select id,nombre from marcas ");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    marca = new Marca();
                    marca.id = datos.lector.GetInt64(0);
                    marca.nombre = datos.lector.GetString(1);
                    lista.Add(marca);

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
        public void Agregar(Marca aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Insert into marcas values (@nombre)");
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
