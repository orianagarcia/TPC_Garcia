using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebAplication
{
    public partial class Stock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Marca> lista = (new MarcaNegocio().Listar());
            dgvMarcas.DataSource = lista;
            dgvMarcas.DataBind();
        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNeg = new MarcaNegocio();
            Marca marca = new Marca();
            marca.nombre = txbMarca.Text;
            marcaNeg.Agregar(marca);

        }
    }
}