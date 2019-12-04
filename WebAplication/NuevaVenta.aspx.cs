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
    public partial class NuevaVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
           {
                CargarDGV();
                Session["TotalVenta"] = 0;
              //Session["DetalleVenta"] = 0;
            }
        }
        void CargarDGV()
        {
            ddlClientes.DataSource = new ClienteNegocio().Listar();
            ddlClientes.DataTextField = "Nombre";
            ddlClientes.DataValueField = "id";
            ddlClientes.DataBind();
            ddlProducto.DataSource = new ProductoNegocio().Listar();
            ddlProducto.DataTextField = "Nombre";
            ddlProducto.DataValueField = "id";
            ddlProducto.DataBind();
            ddlEmpleados.DataSource = new EmpleadoNegocio().Listar();
            ddlEmpleados.DataValueField = "id";
            ddlEmpleados.DataTextField = "Nombre";
            ddlEmpleados.DataBind();
            //txbPrecioU.Text = "0"; 
            //txbFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void cargarGrilla()
        {
            dgvDetalles.Visible = true;
            dgvDetalles.DataBind();
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            DetalleVenta aux = new DetalleVenta();
            DetalleVentaNegocio DVentaneg = new DetalleVentaNegocio();
            ProductoNegocio neg = new ProductoNegocio();
            aux.producto = new Producto();
            aux.venta = new Venta();
            aux.venta.id = DVentaneg.BuscarID()+1;//NO SE SI FUNCA
            aux.producto.id = Convert.ToInt64(ddlProducto.SelectedValue);
            aux.producto.nombre = ddlProducto.SelectedItem.ToString();
            aux.cantidad = Convert.ToInt32(txbCantidad.Text);
            Producto pr = neg.Listar(Convert.ToInt32(aux.producto.id))[0];
            aux.producto.precioVenta = pr.precioVenta;
            aux.totalProducto = Convert.ToDouble(aux.producto.precioVenta * aux.cantidad);
            List<DetalleVenta> lista;
            List<double> listaPrecio = new List<double>();
            if (Session["DetalleVenta"] == null)
            {
                lista = new List<DetalleVenta>();
                listaPrecio = new List<double>();
                lista.Add(aux);
                Session["DetalleVenta"] = lista;
                dgvDetalles.DataSource = lista;
                dgvDetalles.Visible = true;
                dgvDetalles.DataBind();
                txbTotal.Text = aux.totalProducto.ToString();
                Session["TotalVenta"] = aux.totalProducto;
            }
            else
            {
                lista = (Session["DetalleVenta"] as List<DetalleVenta>);
                lista.Add(aux);
                //Double PrecioAux = Convert.ToDouble(txbTotal.Text);
                dgvDetalles.DataSource = lista;
                dgvDetalles.Visible = true;
                dgvDetalles.DataBind();
                double Total = Convert.ToDouble(Session["TotalVenta"]);
                Session["TotalVenta"] = Total + aux.totalProducto;
                txbTotal.Text = Session["TotalVenta"].ToString();
            }
        }

        protected void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();
            VentaNegocio ventaNegocio = new VentaNegocio();
            venta.cliente = new Cliente();
            venta.cliente.id = Convert.ToInt64(ddlClientes.SelectedValue);
            venta.empleado = new Empleado();
            venta.empleado.id = Convert.ToInt64(ddlEmpleados.SelectedValue);
            venta.descripcion = txbDesc.Text; 
            venta.fechaPedido = Convert.ToDateTime(txbPedido.Text);
            venta.fechaEntrega = Convert.ToDateTime(txbEntrega.Text);
            venta.estado= (ddlEstados.SelectedValue).ToString();
            venta.formaPago = (ddlFormaPago.SelectedValue).ToString();
            venta.detalle = new List<DetalleVenta>(); 
            venta.detalle = (Session["DetalleVenta"] as List<DetalleVenta>);
            venta.total = Convert.ToDouble(txbTotal.Text);
            venta.seña = Convert.ToDouble(txbSeña.Text);
           DetalleVentaNegocio detalleNeg = new DetalleVentaNegocio();
            
            if (venta.estado.Equals("Entregado"))
            {
                foreach (DetalleVenta item in venta.detalle)
                {
                    if(detalleNeg.VerificarStock(item))
                    {
                        ventaNegocio.agregar(venta);
                        detalleNeg.Agregar(item);
                        detalleNeg.DisminuirStock(item);
                    }
                    
                }
            }
            else
            {
                foreach (DetalleVenta item in venta.detalle)
                {
                    detalleNeg.Agregar(item);
                }
            }

            Session["DetalleVenta"] = null;
            Session["Total"] = null;
            Response.Redirect("NuevaVenta.aspx");
        }

        protected void dgvDetalles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DetalleVentaNegocio DetallesNeg = new DetalleVentaNegocio();
                int index = Convert.ToInt32(dgvDetalles.DataKeys[e.RowIndex].Value.ToString());
                double PU = Convert.ToDouble((dgvDetalles.Rows[e.RowIndex].FindControl("LblTprod") as Label).Text);
                double Total = Convert.ToDouble(Session["TotalVenta"]);
                Session["TotalVenta"] = Total - PU;
                List<DetalleVenta> lista = new List<DetalleVenta>();
                lista = (Session["DetalleVenta"] as List<DetalleVenta>);
                lista.RemoveAt(index);
                Session["DetalleVenta"] = lista;
                dgvDetalles.DataSource = lista;
                dgvDetalles.DataBind();
                txbTotal.Text = Session["TotalVenta"].ToString();
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;
            }
        }
    }
}