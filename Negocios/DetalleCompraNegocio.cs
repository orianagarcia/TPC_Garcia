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
        public List<DetalleCompra> Listar()
        {
            List<DetalleCompra> lista = new List<DetalleCompra>();
            AccesoDatos datos = new AccesoDatos();
            DetalleCompra aux;
            try
            {
                datos.setearQuery("select * from detalleCompra");
                datos.ejecutarLector();
                while(datos.lector.Read())
                {
                    aux = new DetalleCompra();
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

        public void Agregar(DetalleCompra aux)
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
    }
}
