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
                datos.setearQuery("Select id,nombre from categorias where estado=1 ");
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
                datos.setearQuery("Insert into categorias values (@nombre,1)");
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
        public void Modificar(Categoria aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update Categorias set nombre = @nombre where ID = @Id");
                datos.Clear();
                datos.agregarParametro("@Id", aux.id);
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
        public void ModificarEstado(long id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update Categorias set estado = 0 where ID = @Id");
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

        public bool ContarRegistros(int id)
        {
            bool existe;
            AccesoDatos datos = new AccesoDatos();
            Categoria categoria;
            List<Categoria> lista = new List<Categoria>();
            try
            {
                datos.setearQuery("select c.id,c.nombre from categorias as c inner join productos as p on p.idCategoria=c.id where p.idCategoria=@id");
                datos.agregarParametro("@id", id);
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    categoria = new Categoria();
                    categoria.id = datos.lector.GetInt64(0);
                    categoria.nombre = datos.lector.GetString(1);
                    lista.Add(categoria);

                }
                if (lista.Count > 0) { existe = true; }

                else { existe = false; }

                return existe;
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
