using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio; 
namespace Negocio
{
    public class CompraNegocio
    {
        public List<Compra> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            Compra compra;
            List<Compra> lista = new List<Compra>();
            try
            {
                datos.setearQuery("select id,proveedor,fecha,total,formaPago,estadoCompra from compras where estado=1");
                datos.ejecutarLector();
                while(datos.lector.Read())
                {
                    compra = new Compra();
                    compra.id = datos.lector.GetInt64(0);
                    compra.Proveedor = datos.lector.GetString(1);
                    compra.fechaCompra = datos.lector.GetDateTime(2);
                    compra.total = datos.lector.GetDouble(3);
                    compra.formaPago = datos.lector.GetString(4);
                    compra.estadoCompra = datos.lector.GetString(5);
                    lista.Add(compra);
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

        public void agregar(Compra aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Insert into compras values (@Proveedor,@fecha, @formaPago, @estado,@total,1) ");
                datos.agregarParametro("@Proveedor", aux.Proveedor);
                datos.agregarParametro("@fecha", DateTime.Now);
                datos.agregarParametro("@total", 0);
                datos.agregarParametro("@formaPago", aux.formaPago);
                datos.agregarParametro("@estado", aux.estadoCompra);
                datos.ejecutarAccion();

            }
            catch (Exception ex )
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
