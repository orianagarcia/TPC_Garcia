﻿using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class InsumoNegocio
    {
        public List<Insumo> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            Insumo aux;
            List<Insumo> lista = new List <Insumo> ();
            try
            {
                datos.setearQuery("SELECT id,nombre,stock,medida from insumos");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Insumo();
                    aux.id = datos.lector.GetInt64(0);
                    aux.nombre = datos.lector.GetString(1);
                    aux.stock = datos.lector.GetInt32(2);
                    aux.medida = datos.lector.GetString(3);
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
                datos.setearQuery("Insert into insumos values (@nombre,@stock, @Medida)");
                datos.agregarParametro("@nombre", aux.nombre);
                datos.agregarParametro("@stock", aux.stock);
                datos.agregarParametro("Medida", aux.medida);
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