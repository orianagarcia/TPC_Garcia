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
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarCombos();
            }
        }
        protected void CargarCombos()
        {
            List<Compra> lista = (new CompraNegocio().listar());
            dgvCompras.DataSource = lista;
            dgvCompras.DataBind();
            //dgvCompras.Columns[0].Visible=false;
        }
      
        protected void dgvCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dgvCompras_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvCompras.EditIndex = e.NewEditIndex;
            ProveedorNegocio provNeg = new ProveedorNegocio();
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlProveedor")).DataValueField = "id";
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlProveedor")).DataTextField = "nombre";
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlProveedor")).DataSource = provNeg.listar();
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlProveedor")).DataBind();

            EstadoNegocio estadoNeg = new EstadoNegocio();
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlEstado")).DataValueField = "id";
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlEstado")).DataTextField = "nombre";
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlEstado")).DataSource = estadoNeg.Listar();
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlEstado")).DataBind();
            Estado estado = (estadoNeg.Listar(e.NewEditIndex + 1))[0];

            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).Items.Add("Mercado pago");
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).Items.Add("Efectivo");
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).Items.Add("Tarjeta de Credito");
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).Items.Add("Tarjeta de Debito");
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).Items.Add("Transferencia");
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).Items.Add("Cuenta corriente");
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).DataBind();

        }

        protected void dgvCompras_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvCompras.EditIndex = -1;
            CargarCombos();
        }

        protected void dgvCompras_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                CompraNegocio ComprasNeg = new CompraNegocio();
                Compra compra = new Compra();
                compra.id = Convert.ToInt64(dgvCompras.DataKeys[e.RowIndex].Value.ToString());
                compra.idProveedor = Convert.ToInt64((dgvCompras.Rows[e.RowIndex].FindControl("ddlProveedor") as DropDownList).Text);
                compra.estadoCompra = (dgvCompras.Rows[e.RowIndex].FindControl("ddlEstado") as DropDownList).Text;
                compra.formaPago = (dgvCompras.Rows[e.RowIndex].FindControl("ddlPago") as DropDownList).Text;
                ComprasNeg.Modificar(compra);
                lblCorrecto.Text = "Modificado correctamente.";
                lblIncorrecto.Text = "";
                CargarCombos();
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void dgvCompras_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                CompraNegocio ComprasNeg = new CompraNegocio();
                long id = Convert.ToInt64(dgvCompras.DataKeys[e.RowIndex].Value.ToString());
                ComprasNeg.ModificarEstado(id);
                lblCorrecto.Text = "Elminado correctamente.";
                lblIncorrecto.Text = "";
                CargarCombos();
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }
        protected void btn_Detalle_Click(object sender, EventArgs e)
        {
            DetalleCompraNegocio detNegocio = new DetalleCompraNegocio();
            GridViewRow gr = dgvCompras.SelectedRow;
            int id= Convert.ToInt32(gr.Cells[0].Text);
            dgvDetalles.DataSource = detNegocio.Listar(id);
            dgvDetalles.DataBind();
            dgvDetalles.Visible = true;
        }
    }
}