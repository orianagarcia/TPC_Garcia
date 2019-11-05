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
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cboMarca.DataSource = new MarcaNegocio().Listar();
            cboMarca.DataTextField = "Nombre";
            cboMarca.DataValueField = "id";
            cboMarca.DataBind();

        }
    }
}