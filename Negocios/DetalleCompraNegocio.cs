using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class DetalleCompraNegocio
    {
        public List<Detallecompra> Listar(int id=0)
        {
            List<Detallecompra> lista = new List<Detallecompra>();
            AccesoDatos datos = new AccesoDatos();
            Detallecompra aux;

            try
            {
                string consulta = "select id, idcompra, idinsumo, cantidad, precioUnitario  from detalleCompra ";
                if (id != 0)
                    consulta = consulta + "where idCompra=" + id.ToString();

                datos.setearQuery(consulta);
                datos.ejecutarLector();
                while(datos.lector.Read())
                {
                    aux = new Detallecompra();
                    aux.id = datos.lector.GetInt64(0);
                    aux.idCompra = datos.lector.GetInt64(1);
                    aux.idInsumo = datos.lector.GetInt64(2);
                    aux.cantidad = datos.lector.GetInt32(3);
                    aux.precioUnitario = datos.lector.GetDouble(4);
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

        public void Agregar(Detallecompra aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Insert into detalleCompra values (@idCompra,@idIns, @cant,@precioUnitario,1)");
                datos.agregarParametro("@idCompra", aux.idCompra);
                datos.agregarParametro("@idIns", aux.idInsumo);
                datos.agregarParametro("@cant", aux.cantidad);
                datos.agregarParametro("@precioUnitario", aux.precioUnitario);
                datos.ejecutarAccion();
                datos.setearQuery("update insumos set stock=@cantidad where id=@idInsumo ");
                datos.agregarParametro("@cantidad", aux.cantidad);
                datos.agregarParametro("@idInsumo", aux.idInsumo);
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
        public void Modificar(Detallecompra aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update detallecompra set idInsumo=@idIns,cantidad=@cant , precioUnitario=@precio  where id= @id");
                datos.agregarParametro("@id", aux.id);
                datos.agregarParametro("@idIns", aux.idInsumo);
                datos.agregarParametro("@cant", aux.cantidad);
                datos.agregarParametro("@precio", aux.precioUnitario);
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
        public void AgregarStock(long id, int cant)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("update insumos set stock= stock+@cant where id=@id");
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
    }
}
