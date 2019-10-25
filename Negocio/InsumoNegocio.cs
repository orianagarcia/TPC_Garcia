using System;
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
            SqlDataReader lector;
            SqlConnection cn = new SqlConnection();
            SqlCommand cm = new SqlCommand();
            Insumo aux;
            List<Insumo> lista = new ListInsumo>();
        }
    }
}
