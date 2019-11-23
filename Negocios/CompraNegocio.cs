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
        public List<Compra> listar(int id= 0)
        {
            AccesoDatos datos = new AccesoDatos();
            Compra compra;
            List<Compra> lista = new List<Compra>();
            try
            {
                string consulta = "select id,idproveedor,fecha,total,formaPago,estadoCompra from compras ";
                if (id != 0)
                    consulta = consulta + "where id=" + id.ToString()+ " and estado = 1";
                else
                    consulta = consulta + "where estado = 1";
                datos.setearQuery(consulta);
                datos.ejecutarLector();
                while(datos.lector.Read())
                {
                    compra = new Compra();
                    compra.id = datos.lector.GetInt64(0);
                    compra.idProveedor = datos.lector.GetInt64(1);
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
                datos.agregarParametro("@Proveedor", aux.idProveedor);
                datos.agregarParametro("@fecha", aux.fechaCompra);
                datos.agregarParametro("@total", aux.total);
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
        public void Modificar(Compra aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update compras set idproveedor=@Proveedor,formaPago=@formaPago, estadoCompra=@estado,total=@total where id= @id");
                datos.agregarParametro("@id", aux.id);
                datos.agregarParametro("@Proveedor", aux.idProveedor);
                datos.agregarParametro("@total", aux.total);
                datos.agregarParametro("@formaPago", aux.formaPago);
                datos.agregarParametro("@estado", aux.estadoCompra);
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
                datos.setearQuery("update compras set estadoCompra = 'Devolucion' where ID = @Id");
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
        public void agregarProductosXCompra(long IDCompra, long IDInsumo, int Cantidad,double precioUnitario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("INSERT INTO detalleCompra VALUES(@idCompra, @idIns, @cant,@precioUnitario,1)");
                datos.agregarParametro("@idCompra", IDCompra);
                datos.agregarParametro("@idIns", IDInsumo);
                datos.agregarParametro("@cant", Cantidad);
                datos.agregarParametro("@precioUnitario", precioUnitario);
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
        public void AgregarStock(long id,int cant )
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
        public long BuscarIDCompra()
        {
            AccesoDatos datos = new AccesoDatos();
            long id=0;
            try
            {
                datos.setearQuery("SELECT TOP 1 ID FROM COMPRAS ORDER BY ID DESC");
                datos.ejecutarLector();
                while(datos.lector.Read())
                {
                    id = datos.lector.GetInt64(0);
                }
                return id;
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

        public void DisminuirStock(long id, int cant)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("update insumos set stock= stock-@cant where id=@id");
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

    