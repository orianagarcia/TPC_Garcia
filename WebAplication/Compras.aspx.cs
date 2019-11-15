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
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            CompraNegocio compraNeg = new CompraNegocio();
            Compra compra = new Compra();
            compra.Proveedor =cboProveedores.SelectedValue;
            compra.estadoCompra = cboEstado.SelectedValue;
            compra.formaPago = cboPago.SelectedValue;
            compra.fechaCompra = DateTime.Now;
            compraNeg.agregar(compra);

        }
        protected void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            DetalleCompraNegocio detalleNegocio = new DetalleCompraNegocio();
            DetalleCompra detalle = new DetalleCompra();
            detalle.idCompra = Convert.ToInt64(cboCompra.SelectedValue);
            detalle.idInsumo = Convert.ToInt64(cboInsumos.SelectedValue);
            detalle.precioUnitario = float.Parse(txbPrecio.Text);
            detalle.cantidad = Convert.ToInt32(txbCantidad.Text);
            detalleNegocio.Agregar(detalle);

        }
        protected void CargarCombos()
        {

            List<Compra> lista = (new CompraNegocio().listar());
            dgvCompras.DataSource = lista;
            dgvCompras.DataBind();
            cboProveedores.DataSource = new ProveedorNegocio().listar();
            cboProveedores.DataTextField = "Nombre";
            cboProveedores.DataValueField = "id";
            cboProveedores.DataBind();
            cboEstado.Items.Add(" ");
            cboEstado.Items.Add("Entregado");
            cboEstado.Items.Add("En espera");
            cboEstado.Items.Add("Devolucion");
            cboPago.Items.Add("");
            cboPago.Items.Add("Efectivo");
            cboPago.Items.Add("Mercado Pago");
            cboPago.Items.Add("Tarjeta de credito");
            cboPago.Items.Add("Transferencia");
            cboInsumos.DataSource = new InsumoNegocio().listar();
            cboInsumos.DataTextField = "Nombre";
            cboInsumos.DataValueField = "id";
            cboInsumos.DataBind();
            cboCompra.DataSource = new CompraNegocio().listar();
            cboCompra.DataTextField = "id";
            cboCompra.DataValueField = "id";
            cboCompra.DataBind();
            List<DetalleCompra> list = new List<DetalleCompra>();
            dgvDetalles.DataSource = new DetalleCompraNegocio().Listar();
            dgvDetalles.DataBind(); 
        }
      
        protected void dgvDetalles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    DetalleCompraNegocio DetallesNeg = new DetalleCompraNegocio();
                    DetalleCompra detalle = new DetalleCompra();
                    detalle.idInsumo = Convert.ToInt64((dgvDetalles.FooterRow.FindControl("txbNombreFooter") as TextBox).Text);
                    detalle.cantidad = Convert.ToInt32((dgvDetalles.FooterRow.FindControl("txbStockFooter") as TextBox).Text);
                    detalle.precioUnitario = Convert.ToDouble((dgvDetalles.FooterRow.FindControl("txbMedidaFooter") as TextBox).Text);
                    DetallesNeg.Agregar(detalle);
                    lblCorrecto.Text = "Agregado correctamente.";
                    lblIncorrecto.Text = "";

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
            CargarCombos();

        }

        protected void dgvDetalles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvDetalles.EditIndex = -1;
            CargarCombos();
        }

        protected void dgvDetalles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                DetalleCompraNegocio DetallesNeg = new DetalleCompraNegocio();
                DetalleCompra detalle = new DetalleCompra();
                detalle.id = Convert.ToInt64(dgvDetalles.DataKeys[e.RowIndex].Value.ToString());
                detalle.idInsumo = Convert.ToInt64((dgvDetalles.Rows[e.RowIndex].FindControl("txbInsumo") as TextBox).Text);
                detalle.cantidad = Convert.ToInt32((dgvDetalles.Rows[e.RowIndex].FindControl("txbCantidad") as TextBox).Text);
                detalle.precioUnitario = Convert.ToDouble((dgvDetalles.Rows[e.RowIndex].FindControl("txbPrecio") as TextBox).Text);
                //DetallesNeg.Modificar(detalle);
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

        protected void dgvDetalles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DetalleCompraNegocio DetallesNeg = new DetalleCompraNegocio();
                long id = Convert.ToInt64(dgvDetalles.DataKeys[e.RowIndex].Value.ToString());
                //DetallesNeg.ModificarEstado(id);
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
    }
}