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
    public partial class Ventas : System.Web.UI.Page
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
            List<Venta> lista = (new VentaNegocio().listar());
            dgvVentas.DataSource = lista;
            dgvVentas.DataBind();
        }

        protected void dgvVentas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvVentas.EditIndex = e.NewEditIndex;
            long idVenta = Convert.ToInt64((dgvVentas.Rows[e.NewEditIndex].FindControl("lblID") as Label).Text);
            Session["idVenta"] = idVenta;
            Response.Redirect("ModificarVenta.aspx");
        }

        protected void dgvVentas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvVentas.EditIndex = -1;
            Response.Redirect("ventas.aspx");
        }

        protected void dgvVentas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }


    }
}