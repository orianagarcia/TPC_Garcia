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
    public partial class ModificarCompra : System.Web.UI.Page
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
            long id = Convert.ToInt64(Session["idCompraMod"]);
            CompraNegocio compraNeg = new CompraNegocio();
            Compra compra = compraNeg.listar(Convert.ToInt32(id))[0];
            ddlProveedores.DataSource = new ProveedorNegocio().listar();
            ddlProveedores.DataTextField = "Nombre";
            ddlProveedores.DataValueField = "id";
            ddlProveedores.SelectedValue = compra.proveedor.id.ToString(); 
            ddlProveedores.DataBind();

            ddlEstados.SelectedValue = compra.estado.ToString();
            ddlPago.SelectedValue = compra.formaPago;
            txbTotal.Text = compra.total.ToString(); 
            txbPedido.Text = compra.fechaCompra.ToString("yyyy-MM-dd");
            dgvDetalles.DataSource = new DetalleCompraNegocio().Listar(Convert.ToInt32(id));
            dgvDetalles.DataBind();
        }

        protected void btnModCompra_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["idCompraMod"]);
            CompraNegocio CompraNeg = new CompraNegocio();
            Compra compra = new Compra();
            DetalleCompraNegocio detallesNeg = new DetalleCompraNegocio();
            compra.id = id; 
            compra.fechaCompra = Convert.ToDateTime(txbPedido.Text);
            compra.formaPago = ddlPago.SelectedValue;
            compra.proveedor = new Proveedor();
            compra.proveedor.id = Convert.ToInt64(ddlProveedores.SelectedValue);
            compra.estadoCompra = ddlEstados.SelectedValue;
            compra.total = Convert.ToDouble(txbTotal.Text.ToString());
            compra.detalle = detallesNeg.Listar(id);
            if (compra.estadoCompra.Equals("Devolucion"))
            {
                foreach (Detallecompra item in compra.detalle)
                {
                    detallesNeg.EliminarStock(item);
                }

            }
            else if (compra.estadoCompra.Equals("Entregado"))
            {
                foreach (Detallecompra item in compra.detalle)
                {
                    detallesNeg.AgregarStock(item.insumo.id, item.cantidad);
                }
            }
            CompraNeg.Modificar(compra);
            Response.Redirect("compras.aspx");
        }
    }
}