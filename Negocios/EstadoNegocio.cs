﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EstadoNegocio
    {
        public List<Estado> Listar(int id = 0)
        {
            AccesoDatos datos = new AccesoDatos();
            Estado aux;
            List<Estado> lista = new List<Estado>();
            try
            {
                string consulta = "select id, nombre from Estados ";
                if (id != 0)
                    consulta = consulta + "where id=" + id.ToString();

                datos.setearQuery(consulta);
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Estado();
                    aux.id = datos.lector.GetInt64(0);
                    aux.nombre = datos.lector.GetString(1);
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
    }
}
