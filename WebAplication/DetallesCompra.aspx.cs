using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using Dominio;
using Negocio;

namespace WebAplication
{
    public partial class DetalleCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDGV();
                List<Detallecompra> Detalle = new List<Detallecompra>();
                dgvDetalles.DataSource = Detalle;
            }
        }

        void CargarDGV()
        {
            ddlProveedores.DataSource = new ProveedorNegocio().listar();
            ddlProveedores.DataTextField = "Nombre";
            ddlProveedores.DataValueField = "id";
            ddlProveedores.DataBind();
            ddlProductos.DataSource = new InsumoNegocio().listar();
            ddlProductos.DataTextField = "Nombre";
            ddlProductos.DataValueField = "id";
            ddlProductos.DataBind();
            txbFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void cargarGrilla()
        {
            dgvDetalles.Visible = true;
            dgvDetalles.DataBind();
        }
        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Detallecompra aux = new Detallecompra();

            aux.idInsumo = Convert.ToInt64(ddlProductos.SelectedValue);
            aux.cantidad = Convert.ToInt32(txbCantidad.Text);
            aux.precioUnitario = Convert.ToDouble(txbPrecioU.Text);
            aux.totalProducto = Convert.ToDouble(aux.precioUnitario * aux.cantidad);
            //double PrecioAux;
            //lblTotal.Text = Session["PrecioFinal"].ToString();
            List<Detallecompra> lista;
            if (Session["DetalleCompra"] == null)
            {
                lista = new List<Detallecompra>();
                lista.Add(aux);
                Session["DetalleCompra"] = lista;
                dgvDetalles.DataSource = lista;
                dgvDetalles.Visible = true;
                dgvDetalles.DataBind();
                Session["Total"] = aux.totalProducto;
            }
            else
            {
                lista = (Session["DetalleCompra"] as List<Detallecompra>);
                lista.Add(aux);
                //PrecioAux = Convert.ToDouble(Session["Total"]);
                //PrecioAux += aux.totalProducto;
                //Session["Total"] = PrecioAux;

                dgvDetalles.DataSource = lista;
                dgvDetalles.Visible = true;
                dgvDetalles.DataBind();
                //lblTotal.Text = PrecioAux.ToString();
            }

        }
        protected void btnGuardarFactura_Click(object sender, EventArgs e)
        {
            Compra compra = new Compra();
            CompraNegocio compraNegocio = new CompraNegocio();
            compra.idProveedor = Convert.ToInt64(ddlProveedores.SelectedValue);
            compra.fechaCompra = Convert.ToDateTime(txbFecha.Text);
            compra.estadoCompra = (ddlEstados.SelectedValue).ToString();
            compra.formaPago = (ddlFormaPago.SelectedValue).ToString();
            compra.detalle = (Session["DetalleCompra"] as List<Detallecompra>);
            compra.total = Convert.ToDouble(txbTotal.Text);
            DetalleCompraNegocio det = new DetalleCompraNegocio();

            compraNegocio.agregar(compra);
            foreach (Detallecompra item in compra.detalle)
            {
                compraNegocio.agregarProductosXCompra(compraNegocio.BuscarIDCompra(), item.idInsumo, item.cantidad, item.precioUnitario);
                compraNegocio.AgregarStock(item.idInsumo, item.cantidad);

            }
            Session["DetalleCompra"] = null;
            //Session["Total"] = null;
            Response.Redirect("DetallesCompra.aspx");
        }


        protected void dgvDetalles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvDetalles.EditIndex = e.NewEditIndex;

        }

        protected void dgvDetalles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvDetalles.EditIndex = -1;
        }

        protected void dgvDetalles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                DetalleCompraNegocio DetallesNeg = new DetalleCompraNegocio();
                Detallecompra Detalle = new Detallecompra();
                Detalle.id = Convert.ToInt64(dgvDetalles.DataKeys[e.RowIndex].Value.ToString());
                Detalle.cantidad = Convert.ToInt32((dgvDetalles.Rows[e.RowIndex].FindControl("txbCantidad") as TextBox).Text);
                Detalle.precioUnitario = Convert.ToDouble((dgvDetalles.Rows[e.RowIndex].FindControl("ddlPago") as DropDownList).Text);

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
                long AYUDA = id;
                int index = Convert.ToInt32(dgvDetalles.DataKeys[e.RowIndex].Value.ToString());
                List<Detallecompra> lista = new List<Detallecompra>();
                lista = (Session["DetalleCompra"] as List<Detallecompra>);
                lista.RemoveAt(index);
                Session["DetalleCompra"] = lista;
                dgvDetalles.DataSource = lista;
                dgvDetalles.DataBind();
                //Double PrecioAux;
                //PrecioAux = Convert.ToDouble(Session["Total"]);
                //Session["Total"] = PrecioAux;
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void BtnListar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Compras.aspx");
        }
    }
    }
