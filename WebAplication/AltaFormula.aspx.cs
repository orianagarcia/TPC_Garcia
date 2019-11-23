using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
namespace WebAplication
{
    public partial class AltaFormula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarDGV();
            }
        }

        public void CargarDGV()
        {
            List<Formula> lista = new List<Formula>(); 
            dgvFormulas.DataSource = lista;
            dgvFormulas.DataBind();
            ddlInsumos.DataSource = new InsumoNegocio().listar();
            ddlInsumos.DataTextField = "Nombre";
            ddlInsumos.DataValueField = "id";
            ddlInsumos.DataBind();
            ddlProductos.DataSource = new ProductoNegocio().Listar();
            ddlProductos.DataTextField = "Nombre";
            ddlProductos.DataValueField = "id";
            ddlProductos.DataBind();
            MedidaNegocio medida = new MedidaNegocio();
            txbFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        protected void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            Formula formu = new Formula();
            ddlProductos.Enabled = false; 
            formu.idProducto = Convert.ToInt64(ddlProductos.SelectedValue);
            formu.idInsumo = Convert.ToInt64(ddlInsumos.SelectedValue);
            formu.cantidad = Convert.ToDouble(txbCantidad.Text);
            List<Formula> lista;
            if (Session["ListaFormula"] == null)
            {
                lista = new List<Formula>();
                lista.Add(formu);
                Session["ListaFormula"] = lista;
                dgvFormulas.DataSource = lista;
                dgvFormulas.Visible = true;
                dgvFormulas.DataBind();
            }
            else
            {
                lista = (Session["ListaFormula"] as List<Formula>);
                lista.Add(formu);
                dgvFormulas.DataSource = lista;
                dgvFormulas.Visible = true;
                dgvFormulas.DataBind();
            }
        }
            protected void btnGuardarFormula_Click(object sender, EventArgs e)
        {
            Formula formu = new Formula();
            FormulaNegocio formNeg = new FormulaNegocio();
            List<Formula> list = new List<Formula>();
            list = Session["ListaFormula"] as List<Formula>; 
            foreach (Formula item in list)
            {
                formNeg.Agregar(item);
            }
            Session["ListaFormula"] = null;
            Response.Redirect("AltaFormula.aspx");
        }
    }
}