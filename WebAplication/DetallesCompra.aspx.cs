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
        private BindingList<Detallecompra> Detalle = new BindingList<Detallecompra>();
        private CompraNegocio negocio = new CompraNegocio();
        private double PrecioFinal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarDGV();
            }
        }

        void CargarDGV()
        {
            dgvDetalles.DataSource = new List<DetalleCompra>();

            ddlProveedores.DataSource = new ProveedorNegocio().listar();
            ddlProveedores.DataTextField = "Nombre";
            ddlProveedores.DataValueField = "id";
            ddlProveedores.DataBind();

            ddlProductos.DataSource = new ProductoNegocio().Listar();
            ddlProductos.DataTextField = "Nombre";
            ddlProductos.DataValueField = "id";
            ddlProductos.DataBind();
            txbFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void cargarGrilla()
        {
            dgvDetalles.Visible = true;
            dgvDetalles.DataSource = Detalle;
            dgvDetalles.DataBind();
        }
        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Detallecompra aux = new Detallecompra();
            aux.idInsumo = Convert.ToInt64(ddlProductos.SelectedValue);
            aux.cantidad = Convert.ToInt32(txbCantidad.Text);
            aux.precioUnitario = Convert.ToDouble(txbPrecioU.Text);
            aux.totalProducto = Convert.ToDouble(aux.precioUnitario * aux.cantidad);
            PrecioFinal += aux.totalProducto;
            lblTotal.Text = PrecioFinal.ToString();
            Detalle.Add(aux);
            cargarGrilla(); 


        }

        protected void btnGuardarFactura_Click(object sender, EventArgs e)
        {
           
          
            Compra compra = new Compra();
            CompraNegocio compraNegocio = new CompraNegocio();
            compra.idProveedor = Convert.ToInt64(ddlProveedores.SelectedValue);
            compra.fechaCompra = Convert.ToDateTime(txbFecha.Text);
            compra.estadoCompra = (ddlEstados.SelectedValue).ToString();
            compra.formaPago = (ddlFormaPago.SelectedValue).ToString();
            compra.detalle = Detalle.ToList();
            DetalleCompraNegocio  det = new DetalleCompraNegocio();

            compraNegocio.agregar(compra);
            foreach (Detallecompra item in compra.detalle)
            {
                 compraNegocio.agregarProductosXCompra(1, item.idInsumo, item.cantidad,item.precioUnitario);
                
            }
           // restablecerControles();
            Detalle.Clear();

        }
    }
}