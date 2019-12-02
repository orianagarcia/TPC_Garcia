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
                Session["TotalCompra"] = 0;
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
            aux.insumo = new Insumo();
            aux.insumo.id = Convert.ToInt64(ddlProductos.SelectedValue);
            aux.insumo.nombre = ddlProductos.SelectedItem.ToString(); 
            aux.cantidad = Convert.ToInt32(txbCantidad.Text);
            aux.precioUnitario = Convert.ToDouble(txbPrecioU.Text);
            aux.totalProducto = Convert.ToDouble(aux.precioUnitario * aux.cantidad);
            List<Detallecompra> lista;
            List<double> listaPrecio= new List<double>();
            if (Session["DetalleCompra"] == null)
            {
                lista = new List<Detallecompra>();
                listaPrecio = new List<double>();
                lista.Add(aux);
                Session["DetalleCompra"] = lista;
                dgvDetalles.DataSource = lista;
                dgvDetalles.Visible = true;
                dgvDetalles.DataBind();
                txbTotal.Text = aux.totalProducto.ToString();
                txbTotal.DataBind();
                Session["TotalCompra"] = aux.totalProducto;
            }
            else
            {
                lista = (Session["DetalleCompra"] as List<Detallecompra>);
                //listaPrecio = (Session["TotalCompra"] as List<Double>);
                lista.Add(aux);
                Double PrecioAux = Convert.ToDouble(txbTotal.Text);
                PrecioAux += aux.totalProducto;
                //txbTotal.Text = PrecioAux.ToString();
                dgvDetalles.DataSource = lista;
                dgvDetalles.Visible = true;
                dgvDetalles.DataBind();
                double Total = Convert.ToDouble(Session["TotalCompra"]);
                Session["TotalCompra"] = Total + aux.totalProducto;
                txbTotal.Text = Session["TotalCompra"].ToString();
            }

        }
        protected void btnGuardarFactura_Click(object sender, EventArgs e)
        {
            Compra compra = new Compra();
            CompraNegocio compraNegocio = new CompraNegocio();
            compra.proveedor = new Proveedor();
            compra.proveedor.id = Convert.ToInt64(ddlProveedores.SelectedValue);
            compra.fechaCompra = Convert.ToDateTime(txbFecha.Text);
            compra.estadoCompra = (ddlEstados.SelectedValue).ToString();
            compra.formaPago = (ddlFormaPago.SelectedValue).ToString();
            compra.detalle = (Session["DetalleCompra"] as List<Detallecompra>);
            compra.total = Convert.ToDouble(txbTotal.Text);
            DetalleCompraNegocio det = new DetalleCompraNegocio();

            compraNegocio.agregar(compra);
            if(compra.estadoCompra.Equals("Entregado"))
            {
                foreach (Detallecompra item in compra.detalle)
                {
                    compraNegocio.agregarProductosXCompra(compraNegocio.BuscarIDCompra(), item.insumo.id, item.cantidad, item.precioUnitario);
                    compraNegocio.AgregarStock(item.insumo.id, item.cantidad);
                }
            }
            else
            {
                foreach (Detallecompra item in compra.detalle)
                {
                    compraNegocio.agregarProductosXCompra(compraNegocio.BuscarIDCompra(), item.insumo.id, item.cantidad, item.precioUnitario);
                }
            }
            
            Session["DetalleCompra"] = null;
            Session["Total"] = null;
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
                int index = Convert.ToInt32(dgvDetalles.DataKeys[e.RowIndex].Value.ToString());
                double PU = Convert.ToDouble((dgvDetalles.Rows[e.RowIndex].FindControl("LblTprod") as Label).Text);
                double Total = Convert.ToDouble(Session["TotalCompra"]);
                Session["TotalCompra"] = Total - PU;
                List<Detallecompra> lista = new List<Detallecompra>();
                lista = (Session["DetalleCompra"] as List<Detallecompra>);
                lista.RemoveAt(index);
                Session["DetalleCompra"] = lista;
                dgvDetalles.DataSource = lista;
                dgvDetalles.DataBind();
                txbTotal.Text = Session["TotalCompra"].ToString(); 
                //Session["TotalCompra"];
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;
            }
        }

       
    }
    }
