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
    public partial class ModificarVenta : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
                CargarVenta();
            }
        }
        private void CargarVenta()
        {
            long idVenta = Convert.ToInt64(Session["idVenta"]);
            Venta venta = new Venta();
            VentaNegocio ventaNegocio = new VentaNegocio();
            DetalleVentaNegocio detNeg = new DetalleVentaNegocio();
            venta = ventaNegocio.listar(Convert.ToInt32(idVenta))[0];
            ddlClientes.DataSource = new ClienteNegocio().Listar();
            ddlClientes.DataTextField = "Nombre";
            ddlClientes.DataValueField = "id";
            ddlClientes.DataBind();
            ddlClientes.SelectedValue = venta.cliente.id.ToString(); 
            ddlProducto.DataSource = new ProductoNegocio().Listar();
            ddlProducto.DataTextField = "Nombre";
            ddlProducto.DataValueField = "id";
            ddlProducto.DataBind();
            ddlEmpleados.DataSource = new EmpleadoNegocio().Listar();
            ddlEmpleados.DataValueField = "id";
            ddlEmpleados.DataTextField = "Nombre";
            ddlEmpleados.DataBind();
            ddlEmpleados.SelectedValue = venta.empleado.id.ToString();
            ddlEstados.SelectedValue = venta.estado;
            ddlFormaPago.SelectedValue = venta.formaPago;
            txbEntrega.Text  = venta.fechaEntrega.ToString("yyyy-MM-dd");
            txbPedido.Text = venta.fechaPedido.ToString("yyyy-MM-dd");
            txbTotal.Text = venta.total.ToString();
            txbSeña.Text = venta.seña.ToString();
            txbDesc.Text = venta.descripcion;
            dgvDetalles.DataSource = detNeg.Listar(Convert.ToInt32(idVenta));
            dgvDetalles.DataBind();
        }

    }
}