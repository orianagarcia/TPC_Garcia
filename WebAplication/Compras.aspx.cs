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
                //InsumoNegocio insNeg = new InsumoNegocio();
                //((DropDownList)dgvDetalles.FooterRow.FindControl("ddlInsumoFooter")).DataSource = insNeg.listar();
                //((DropDownList)dgvDetalles.FooterRow.FindControl("ddlInsumoFooter")).DataValueField = "id";
                //((DropDownList)dgvDetalles.FooterRow.FindControl("ddlInsumoFooter")).DataTextField = "nombre";
                //((DropDownList)dgvDetalles.FooterRow.FindControl("ddlInsumoFooter")).DataBind();
            }
            

        }
        protected void CargarCombos()
        {
            List<Compra> lista = (new CompraNegocio().listar());
            dgvCompras.DataSource = lista;
            dgvCompras.DataBind();
            //dgvCompras.Columns[0].Visible=false;
        }
        protected void CargarDetalle(int id)
        {
            List<Detallecompra> lista = (new DetalleCompraNegocio().Listar(id));
            dgvDetalles.DataSource = lista;
            dgvDetalles.DataBind();
            InsumoNegocio InsumoNeg = new InsumoNegocio();
            ((DropDownList)dgvDetalles.FooterRow.FindControl("ddlInsumosFooter")).DataValueField = "id";
            ((DropDownList)dgvDetalles.FooterRow.FindControl("ddlInsumosFooter")).DataTextField = "nombre";
            ((DropDownList)dgvDetalles.FooterRow.FindControl("ddlInsumosFooter")).DataSource = InsumoNeg.listar();
            ((DropDownList)dgvDetalles.FooterRow.FindControl("ddlInsumosFooter")).DataBind();
        }

        protected void dgvCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {   
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void dgvCompras_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvCompras.EditIndex = e.NewEditIndex;
            CargarCombos();
            ProveedorNegocio provNeg = new ProveedorNegocio();
            CompraNegocio compraNegocio = new CompraNegocio();
            Compra compra = new Compra();
            Estado estado = new Estado();
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlProveedor")).DataSource = provNeg.listar();
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlProveedor")).DataValueField = "id";
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlProveedor")).DataTextField = "nombre";
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlProveedor")).DataBind();
            compra = (compraNegocio.listar(e.NewEditIndex + 1))[0];
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlProveedor")).Items.FindByValue(compra.idProveedor.ToString()).Selected = true;

            EstadoNegocio estadoNeg = new EstadoNegocio();
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlEstado")).DataValueField = "nombre";
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlEstado")).DataTextField = "nombre";
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlEstado")).DataSource = estadoNeg.Listar();
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlEstado")).DataBind();
             //estado = (estadoNeg.Listar(1))[0];
          //  ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlEstado")).Items.FindByValue(compra.estadoCompra).Selected = true;

            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).Items.Add("Mercado pago");
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).Items.Add("Efectivo");
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).Items.Add("Tarjeta de Credito");
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).Items.Add("Tarjeta de Debito");
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).Items.Add("Transferencia");
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).Items.Add("Cuenta corriente");
            ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).DataBind();
          //  ((DropDownList)dgvCompras.Rows[e.NewEditIndex].FindControl("ddlPago")).Items.FindByValue(compra.formaPago).Selected = true;
        }

        protected void dgvCompras_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvCompras.EditIndex = -1;
            Response.Redirect("compras.aspx");
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
                compra.total = Convert.ToDouble((dgvCompras.Rows[e.RowIndex].FindControl("txbTotal") as TextBox).Text);
                ComprasNeg.Modificar(compra);
                lblCorrecto.Text = "Modificado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("compras.aspx");
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
                Response.Redirect("compras.aspx");
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

        protected void dgvCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = dgvCompras.SelectedRow;
            DetalleCompraNegocio detNegocio = new DetalleCompraNegocio();
            CompraNegocio comNeg = new CompraNegocio(); 
            int id ;
            id = Convert.ToInt32(dgvCompras.SelectedDataKey.Value.ToString());
            dgvDetalles.DataSource = detNegocio.Listar(id);
            dgvDetalles.DataBind();
            dgvDetalles.Visible = true;
            dgvCompras.DataSource = comNeg.listar(id);
            dgvCompras.DataBind();
            Session["idCompra"] = id;
            InsumoNegocio InsumoNeg = new InsumoNegocio();
            ((DropDownList)dgvDetalles.FooterRow.FindControl("ddlInsumosFooter")).DataSource = InsumoNeg.listar();
            ((DropDownList)dgvDetalles.FooterRow.FindControl("ddlInsumosFooter")).DataValueField = null;
            ((DropDownList)dgvDetalles.FooterRow.FindControl("ddlInsumosFooter")).DataValueField = "id";
            ((DropDownList)dgvDetalles.FooterRow.FindControl("ddlInsumosFooter")).DataTextField = "nombre";
            ((DropDownList)dgvDetalles.FooterRow.FindControl("ddlInsumosFooter")).DataBind();
            btnAtras.Visible = true;
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("compras.aspx");
        }
        protected void dgvDetalles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    DetalleCompraNegocio detNeg = new DetalleCompraNegocio();
                    Detallecompra det = new Detallecompra();
                    CompraNegocio cn = new CompraNegocio();
                    det.idInsumo = Convert.ToInt64((dgvDetalles.FooterRow.FindControl("ddlInsumosFooter") as DropDownList).Text);
                    det.cantidad = Convert.ToInt32((dgvDetalles.FooterRow.FindControl("txbCantidadFooter") as TextBox).Text);
                    det.precioUnitario = Convert.ToDouble((dgvDetalles.FooterRow.FindControl("txbPrecioFooter") as TextBox).Text);
                    det.idCompra = Convert.ToInt64(Session["idCompra"].ToString());
                    detNeg.Agregar(det);
                    cn.AgregarStock(det.idInsumo,det.cantidad);
                    lblCorrecto.Text = "Agregado correctamente.";
                    lblIncorrecto.Text = "";

                    CargarDetalle(Convert.ToInt32(det.idCompra));
                }
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }

        }

        protected void dgvDetalles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvDetalles.EditIndex = e.NewEditIndex;
            CargarDetalle(Convert.ToInt32(Session["idCompra"]));
            InsumoNegocio insNeg = new InsumoNegocio();
            DetalleCompraNegocio detNeg = new DetalleCompraNegocio();
            ((DropDownList)dgvDetalles.Rows[e.NewEditIndex].FindControl("ddlInsumo")).DataSource = insNeg.listar();
            ((DropDownList)dgvDetalles.Rows[e.NewEditIndex].FindControl("ddlInsumo")).DataValueField = "id";
            ((DropDownList)dgvDetalles.Rows[e.NewEditIndex].FindControl("ddlInsumo")).DataTextField = "nombre";
            ((DropDownList)dgvDetalles.Rows[e.NewEditIndex].FindControl("ddlInsumo")).DataBind();
            Detallecompra det = (detNeg.Listar(e.NewEditIndex +1))[0];
            ((DropDownList)dgvDetalles.Rows[e.NewEditIndex].FindControl("ddlInsumo")).Items.FindByValue(det.idInsumo.ToString()).Selected = true;


        }

        protected void dgvDetalles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvDetalles.EditIndex = -1;
            CargarDetalle(Convert.ToInt32(Session["idCompra"]));
        }

        protected void dgvDetalles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                DetalleCompraNegocio DetallecompraNeg = new DetalleCompraNegocio();
                Detallecompra det = new Detallecompra();
                det.id = 25;
                det.idCompra = Convert.ToInt64(Session["idCompra"]);
                det.idInsumo = Convert.ToInt64((dgvDetalles.Rows[e.RowIndex].FindControl("ddlInsumo") as DropDownList).Text);
                det.cantidad = Convert.ToInt32((dgvDetalles.Rows[e.RowIndex].FindControl("txbCantidad") as TextBox).Text);
                det.precioUnitario = Convert.ToDouble((dgvDetalles.Rows[e.RowIndex].FindControl("txbPrecio") as TextBox).Text);
                DetallecompraNeg.Modificar(det);
                lblCorrecto.Text = "Modificado correctamente.";
                lblIncorrecto.Text = "";
                CargarDetalle(Convert.ToInt32(det.idCompra));
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void dgvDetalles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DetalleCompraNegocio detNeg = new DetalleCompraNegocio();
                long id = Convert.ToInt64(dgvDetalles.DataKeys[e.RowIndex].Value.ToString());
                //detNeg.ModificarEstado(id);
                //detNeg.EliminarStock(idInsumo);
                lblCorrecto.Text = "Elminado correctamente.";
                lblIncorrecto.Text = "";
                CargarDetalle(Convert.ToInt32(Session["idCompra"]));
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }
    }
}