﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> Listar(int id = 0)
        {
            AccesoDatos datos = new AccesoDatos();
            Producto aux;
            List<Producto> lista = new List<Producto>();
            try
            {
                string consulta = "select p.id,p.nombre,m.id,m.nombre,c.id,c.nombre,p.stock,p.costo, p.precioVenta,p.ultimaActualizacion from productos as p inner join marcas as m on p.idMarca = m.id inner join categorias as c on c.id= p.idCategoria where p.estado=1 ";
                if (id != 0)
                    consulta = consulta + "and p.id=" + id.ToString();

                datos.setearQuery(consulta);
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Producto();
                    aux.id = datos.lector.GetInt64(0);
                    aux.nombre = datos.lector.GetString(1);
                    aux.marca = new Marca();
                    aux.marca.id = datos.lector.GetInt64(2);
                    aux.marca.nombre = datos.lector.GetString(3);
                    aux.categoria = new Categoria(); 
                    aux.categoria.id = datos.lector.GetInt64(4);
                    aux.categoria.nombre = datos.lector.GetString(5);
                    aux.stock = datos.lector.GetDouble(6);
                    aux.costo = datos.lector.GetDouble(7);
                    aux.precioVenta = datos.lector.GetDouble(8);
                    aux.fechaActualizacion = datos.lector.GetDateTime(9);
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
        public void Agregar(Producto aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Insert into productos values (@nombreProd,@marca, @categoria, @stock, @costo, @precioVenta,@fecha, @estado)");
                datos.agregarParametro("@nombreProd", aux.nombre);
                datos.agregarParametro("@marca", aux.marca.id);
                datos.agregarParametro("@categoria", aux.categoria.id);
                datos.agregarParametro("@stock", aux.stock);
                datos.agregarParametro("@costo", aux.costo);
                datos.agregarParametro("@precioVenta", aux.precioVenta);
                datos.agregarParametro("@fecha",DateTime.Now);
                datos.agregarParametro("@estado", 1);
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
        public void Modificar(Producto aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("update productos set nombre=@nombre, idMarca=@idMarca, idCategoria=@idCategoria, stock=@stock, costo=@costo, precioVenta=@precio, ultimaActualizacion=@fecha where id=@id");
                datos.Clear();
                datos.agregarParametro("@Id", aux.id);
                datos.agregarParametro("@nombre", aux.nombre);
                datos.agregarParametro("@idMarca", aux.marca.id);
                datos.agregarParametro("@idCategoria", aux.categoria.id);
                datos.agregarParametro("@stock", aux.stock);
                datos.agregarParametro("@costo", aux.costo);
                datos.agregarParametro("@precio", aux.precioVenta);
                datos.agregarParametro("@fecha", DateTime.Now);
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
                datos.setearQuery("update productos set estado = 0 where ID = @Id");
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

        public void AgregarStock(long id, int cant)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("update productos set stock= stock+@cant where id=@id");
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
        public bool ContarRegistros(long id)
        {
            
            AccesoDatos datos = new AccesoDatos();
            Producto pr;
            List<Producto> lista = new List<Producto>();
            try
            {
                datos.setearQuery("select p.id,p.nombre from productos as p inner join fabricaciones as f on f.idProducto = p.id where f.idProducto=@id");
                datos.agregarParametro("@id", id);
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    pr = new Producto();
                    pr.id = datos.lector.GetInt64(0);
                    pr.nombre = datos.lector.GetString(1);
                    lista.Add(pr);

                }
                if (lista.Count > 0) { return true; }

                else { return false; }

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
