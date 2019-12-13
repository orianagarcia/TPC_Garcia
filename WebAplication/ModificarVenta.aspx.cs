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
                Session["TotalModVenta"] = 0;
                Session["DetalleModVenta"] = null; 
                CargarVenta();
                dgvDetalles.Columns[0].Visible = false; 
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
            double deuda = venta.total - venta.seña; 
            txbAdeuda.Text = deuda.ToString();
            List<DetalleVenta> lista= detNeg.Listar(Convert.ToInt32(idVenta));
            dgvDetalles.DataSource = lista;
            Session["ListaVenta"] = lista;
            dgvDetalles.DataBind();
            dgvNueva.Visible = false; 
        }

        protected void btnModVenta_Click(object sender, EventArgs e)
        {
            VentaNegocio ventaNeg = new VentaNegocio();
            Venta venta = new Venta();
            DetalleVentaNegocio detalleNeg = new DetalleVentaNegocio();
            venta.id = Convert.ToInt64(Session["idVenta"]); 
            venta.fechaEntrega = Convert.ToDateTime(txbEntrega.Text);
            venta.fechaPedido = Convert.ToDateTime(txbPedido.Text);
            venta.formaPago = ddlFormaPago.SelectedValue;
            venta.empleado = new Empleado();
            venta.empleado.id = Convert.ToInt64(ddlEmpleados.SelectedValue);
            venta.cliente = new Cliente();
            venta.cliente.id = Convert.ToInt64(ddlClientes.SelectedValue);
            venta.detalle = new List<DetalleVenta>();
            venta.total = Convert.ToDouble(txbTotal.Text);
            venta.seña = Convert.ToDouble(txbNuevoPago.Text);
            venta.detalle = Session["DetalleModVenta"] as List<DetalleVenta>;
            venta.estado = ddlEstados.SelectedValue;
            venta.descripcion = txbDesc.Text;
            
            if (venta.detalle!=null)
            {
                int cantProductos = venta.detalle.Count; int cont = 0;
                foreach (DetalleVenta item in venta.detalle)
                {
                    detalleNeg.Agregar(item);
                    if(detalleNeg.VerificarStock(item))
                    {
                        cont++;
                    }
                }
                if(cont==cantProductos)
                {
                    venta.estado = ddlEstados.SelectedValue;
                }
                else
                {
                    venta.estado = "Pedido";
                }
                if (venta.estado.Equals("Entregado"))
                {
                    foreach (DetalleVenta item in venta.detalle)
                    {
                        detalleNeg.DisminuirStock(item);
                    }
                    List<DetalleVenta> lista = new List<DetalleVenta>();
                    lista = Session["ListaVenta"] as List<DetalleVenta>;
                    cantProductos = lista.Count; cont = 0;
                    foreach (DetalleVenta item in lista)
                    {
                        detalleNeg.DisminuirStock(item);
                    }
                }
            }
            else
            {
                List<DetalleVenta> lista = new List<DetalleVenta>();
                lista = Session["ListaVenta"] as List<DetalleVenta>;
                int cantProductos = lista.Count; int cont = 0;
                foreach (DetalleVenta item in lista )
                {
                    if (detalleNeg.VerificarStock(item))
                    {
                        cont++;
                    }
                }
                if (cont == cantProductos)
                {
                    venta.estado = ddlEstados.SelectedValue;
                }
                else
                {
                    venta.estado = "Pedido";
                }
                if (venta.estado.Equals("Entregado"))
                {
                    foreach (DetalleVenta item in lista)
                    {
                        detalleNeg.DisminuirStock(item);
                    }
                }
            }
            ventaNeg.Modificar(venta);
            Response.Redirect("Ventas.aspx"); 
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            long idVenta = Convert.ToInt64(Session["idVenta"]);
            DetalleVenta aux = new DetalleVenta();
            DetalleVentaNegocio DVentaneg = new DetalleVentaNegocio();
            ProductoNegocio neg = new ProductoNegocio();
            aux.producto = new Producto();
            aux.venta = new Venta();
            aux.venta.id = idVenta; 
            aux.producto.id = Convert.ToInt64(ddlProducto.SelectedValue);
            aux.producto.nombre = ddlProducto.SelectedItem.ToString();
            aux.cantidad = Convert.ToInt32(txbCantidad.Text);
            Producto pr = neg.Listar(Convert.ToInt32(aux.producto.id))[0];
            aux.producto.precioVenta = pr.precioVenta;
            aux.totalProducto = Convert.ToDouble(aux.producto.precioVenta * aux.cantidad);
            List<DetalleVenta> lista;
            List<double> listaPrecio = new List<double>();
            if (Session["DetalleModVenta"] == null)
            {
                lista = new List<DetalleVenta>();
                listaPrecio = new List<double>();
                lista.Add(aux);
                Session["DetalleModVenta"] = lista;
                dgvNueva.DataSource = lista;
                dgvNueva.Visible = true;
                dgvNueva.DataBind();
                Double PrecioAux = Convert.ToDouble(txbTotal.Text);
                PrecioAux += aux.totalProducto;
                txbTotal.Text = PrecioAux.ToString(); 
                Session["TotalModVenta"] = txbTotal.Text;
                double auxi = Convert.ToDouble(txbAdeuda.Text);
                auxi += aux.totalProducto;
                txbAdeuda.Text = auxi.ToString();
            }
            else
            {
                lista = (Session["DetalleModVenta"] as List<DetalleVenta>);
                lista.Add(aux);
                //Double PrecioAux = Convert.ToDouble(txbTotal.Text);
                dgvNueva.DataSource = lista;
                dgvNueva.Visible = true;
                dgvNueva.DataBind();
                txbTotal.Text += aux.totalProducto;
                Double PrecioAux = Convert.ToDouble(txbTotal.Text);
                PrecioAux += aux.totalProducto;
                double Total = Convert.ToDouble(Session["TotalModVenta"]);
                Session["TotalModVenta"] = Total + aux.totalProducto;
                txbTotal.Text = Session["TotalModVenta"].ToString();
                double auxi = Convert.ToDouble(txbAdeuda.Text);
                auxi += aux.totalProducto;
                txbAdeuda.Text = auxi.ToString();
            }
        }

        protected void dgvDetalles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DetalleVentaNegocio DetallesNeg = new DetalleVentaNegocio();
                long ID = Convert.ToInt64((dgvDetalles.Rows[e.RowIndex].FindControl("LblID") as Label).Text);
                double PU = Convert.ToDouble((dgvDetalles.Rows[e.RowIndex].FindControl("LblTprod") as Label).Text);
                double Total = Convert.ToDouble(txbTotal.Text); 
                Session["TotalModVenta"] = Total - PU;
                List<DetalleVenta> lista = new List<DetalleVenta>();
                lista = (Session["ListaVenta"] as List<DetalleVenta>);
                lista.RemoveAt(e.RowIndex);
                Session["ListaVenta"] = lista;
                dgvDetalles.DataSource = lista;
                dgvDetalles.DataBind();
                txbTotal.Text = Session["TotalModVenta"].ToString();
                DetallesNeg.Modificar(ID);
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;
            }
        }
    }
}