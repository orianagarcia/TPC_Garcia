﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio; 

namespace Negocio
{
    public class FormulaNegocio
    {
        public List<Formula> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            Formula aux;
            List<Formula> lista = new List<Formula>();
            try
            {
                datos.setearQuery("SELECT id,idProducto,idInsumo,cantidad from formulas group by id,idProducto,idInsumo,cantidad");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Formula();
                    aux.id = datos.lector.GetInt64(0);
                    aux.idProducto = datos.lector.GetInt64(1);
                    aux.idInsumo= datos.lector.GetInt64(2);
                    aux.cantidad = datos.lector.GetInt32(3);
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

        public void Agregar(Formula aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Insert into formulas values (@idProducto,@idInsumo, @cantidad)");
                datos.agregarParametro("@idProducto", aux.idProducto);
                datos.agregarParametro("@idInsumo", aux.idInsumo);
                datos.agregarParametro("@cantidad", aux.cantidad);
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