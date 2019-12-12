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
        protected void CargarDetalle(int id)
        {
            List<DetalleVenta> lista = (new DetalleVentaNegocio().Listar(id));
            dgvDetalle.DataSource = lista;
            dgvDetalle.DataBind();
            
        }
        protected void dgvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = dgvVentas.SelectedRow;
            DetalleVentaNegocio detNegocio = new DetalleVentaNegocio();
            VentaNegocio ventaNeg = new VentaNegocio();
            int id;
            id = Convert.ToInt32(dgvVentas.SelectedDataKey.Value.ToString());
            dgvDetalle.DataSource = detNegocio.Listar(id);
            dgvDetalle.DataBind();
            dgvDetalle.Visible = true;
            dgvVentas.DataSource = ventaNeg.listar(id);
            dgvVentas.DataBind();
            Session["idCompra"] = id;
            CargarDetalle(id);
            btnAtras.Visible = true;
        }


        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("ventas.aspx"); 
        }
    }
}