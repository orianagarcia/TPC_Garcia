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
    public partial class prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cboInsumos.DataSource = new InsumoNegocio().listar();
            cboInsumos.SelectedIndex = -1; 
            cboInsumos.DataTextField = "Nombre";
            cboInsumos.DataValueField = "id";
            cboInsumos.DataBind();
            cboProductos.SelectedIndex = -1;
            cboProductos.DataSource = new ProductoNegocio().Listar();
            cboProductos.DataTextField = "Nombre";
            cboProductos.DataValueField = "id";
            cboProductos.DataBind();
            List<Formula> lista = new FormulaNegocio().Listar();
            dgvFormulas.DataSource = lista;
            dgvFormulas.DataBind();
        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            FormulaNegocio FormulaNegocio = new FormulaNegocio();
            Formula formula = new Formula();
            formula.idProducto = Convert.ToInt64(cboProductos.SelectedValue);
            formula.idInsumo = Convert.ToInt64(cboInsumos.SelectedValue);
            formula.cantidad = Convert.ToInt32(txbCantidad.Text);
            FormulaNegocio.Agregar(formula);

        }
    }
}