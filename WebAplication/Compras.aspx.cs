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
        }
        protected void CargarDetalle(int id)
        {
            List<Detallecompra> lista = (new DetalleCompraNegocio().Listar(id));
            dgvDetalles.DataSource = lista;
            dgvDetalles.DataBind();
        }

        protected void dgvCompras_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvCompras.EditIndex = e.NewEditIndex;
            CompraNegocio compraNegocio = new CompraNegocio(); 
            long idCompra = Convert.ToInt64((dgvCompras.Rows[e.NewEditIndex].FindControl("lblID") as Label).Text);
            Compra compra = compraNegocio.listar(Convert.ToInt32(idCompra))[0];
            string estado = compra.estadoCompra; 
            if (estado!="Devolucion")
            {
                Session["idCompraMod"] = idCompra;
                Response.Redirect("ModificarCompra.aspx");
            }
            else
            {
                lblIncorrecto.Text = "No se puede editar.";
            }

        }

        protected void dgvCompras_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                CompraNegocio ComprasNeg = new CompraNegocio();
                DetalleCompraNegocio detallesNeg = new DetalleCompraNegocio();
                Compra compra = new Compra();
                compra.proveedor = new Proveedor();
                compra.id = Convert.ToInt64(dgvCompras.DataKeys[e.RowIndex].Value.ToString());
                compra.proveedor.id = Convert.ToInt64((dgvCompras.Rows[e.RowIndex].FindControl("ddlProveedor") as DropDownList).Text);
                compra.estadoCompra = (dgvCompras.Rows[e.RowIndex].FindControl("ddlEstado") as DropDownList).Text;
                compra.formaPago = (dgvCompras.Rows[e.RowIndex].FindControl("ddlPago") as DropDownList).Text;
                compra.total = Convert.ToDouble((dgvCompras.Rows[e.RowIndex].FindControl("txbTotal") as TextBox).Text);
                compra.detalle = detallesNeg.Listar(Convert.ToInt32(compra.id));
                if (compra.estadoCompra.Equals("Devolucion"))
                {
                    foreach (Detallecompra item in compra.detalle)
                    {
                        detallesNeg.EliminarStock(item);
                    }

                }
                else if(compra.estadoCompra.Equals("Entregado"))
                {
                    foreach (Detallecompra item in compra.detalle)
                    {
                        detallesNeg.AgregarStock(item.insumo.id,item.cantidad);
                    }
                }
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
            int id;
            id = Convert.ToInt32(dgvCompras.SelectedDataKey.Value.ToString());
            dgvDetalles.DataSource = detNegocio.Listar(id);
            dgvDetalles.DataBind();
            dgvDetalles.Visible = true;
            dgvCompras.DataSource = comNeg.listar(id);
            dgvCompras.DataBind();
            Session["idCompra"] = id;
            CargarDetalle(id);
            btnAtras.Visible = true;
            if (comNeg.listar(id)[0].estadoCompra.Equals("Devolucion"))
            {
                txbDesc.Visible = true;
                lblDesc.Visible = true;
                txbDesc.Text = comNeg.BuscarMotivo(id); 
            }
            
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
                    det.insumo = new Insumo();
                    det.insumo.id = Convert.ToInt64((dgvDetalles.FooterRow.FindControl("ddlInsumosFooter") as DropDownList).Text);
                    det.insumo.nombre = (dgvDetalles.FooterRow.FindControl("ddlInsumosFooter") as DropDownList).SelectedItem.ToString();                    det.cantidad = Convert.ToInt32((dgvDetalles.FooterRow.FindControl("txbCantidadFooter") as TextBox).Text);
                    det.precioUnitario = Convert.ToDouble((dgvDetalles.FooterRow.FindControl("txbPrecioFooter") as TextBox).Text);
                    det.cantidad = Convert.ToInt32((dgvDetalles.FooterRow.FindControl("txbCantidadFooter") as TextBox).Text);
                    det.totalProducto = det.precioUnitario * det.cantidad;
                    det.compra = new Compra();
                    det.compra.id = Convert.ToInt64(Session["idCompra"].ToString());
                    detNeg.Agregar(det);
                    detNeg.AgregarStock(det.insumo.id,det.cantidad);
                    cn.ModificarTotal(det.compra.id, det.totalProducto);
                    lblCorrecto.Text = "Agregado correctamente.";
                    lblIncorrecto.Text = "";

                    CargarDetalle(Convert.ToInt32(det.compra.id));
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
            ((DropDownList)dgvDetalles.Rows[e.NewEditIndex].FindControl("ddlInsumo")).Items.FindByValue(det.insumo.id.ToString()).Selected = true;


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
                det.compra = new Compra();
                det.insumo = new Insumo();
                det.compra.id = Convert.ToInt64(Session["idCompra"]);
                det.insumo.id = Convert.ToInt64((dgvDetalles.Rows[e.RowIndex].FindControl("ddlInsumo") as DropDownList).Text);
                det.insumo.nombre = (dgvDetalles.Rows[e.RowIndex].FindControl("ddlInsumo") as DropDownList).Text.ToString();
                det.cantidad = Convert.ToInt32((dgvDetalles.Rows[e.RowIndex].FindControl("txbCantidad") as TextBox).Text);
                det.precioUnitario = Convert.ToDouble((dgvDetalles.Rows[e.RowIndex].FindControl("txbPrecio") as TextBox).Text);
                DetallecompraNeg.Modificar(det);
                lblCorrecto.Text = "Modificado correctamente.";
                lblIncorrecto.Text = "";
                CargarDetalle(Convert.ToInt32(det.compra.id));
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
                Session["idDetalle"] = id;
                txbDescripcion.Visible = true;
                btnAgregarDesc.Visible = true; 
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void btnAgregarDesc_Click(object sender, EventArgs e)
        {
            try
            {
                DetalleCompraNegocio detNeg = new DetalleCompraNegocio();
                Detallecompra detalle = new Detallecompra();
                string descripcion = txbDescripcion.Text;
                if (descripcion != "")
                {
                    long idCompra = Convert.ToInt64(Session["idCompra"]);
                    long idDetalle = Convert.ToInt64(Session["idDetalle"]);
                    detNeg.AgregarComentario(idCompra, descripcion);
                    CargarDetalle(Convert.ToInt32(Session["idCompra"]));
                    detNeg.ModificarEstado(idDetalle);
                    detalle = detNeg.BuscarDetalle(Convert.ToInt32(idDetalle));
                    detNeg.EliminarStock(detalle);
                    lblCorrecto.Text = "Elminado correctamente.";
                    lblIncorrecto.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblCorrecto2.Text = "";
                lblIncorrecto2.Text = ex.Message;
            }
         
        }

     
    }
}