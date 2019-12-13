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
            ddlEstados.SelectedValue = compra.estadoCompra.ToString();
            ddlPago.SelectedValue = compra.formaPago;
            txbTotal.Text = compra.total.ToString(); 
            txbPedido.Text = compra.fechaCompra.ToString("yyyy-MM-dd");
            DetalleCompraNegocio detNeg = new DetalleCompraNegocio();
            Session["DetalleCompra"] = detNeg.Listar(Convert.ToInt32(id));
            dgvDetalles.DataSource = detNeg.Listar(Convert.ToInt32(id)); 
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
                txbDescripcion.Visible = true;
                btnAgregarDesc.Visible = true;
                CompraNeg.Modificar(compra);
            }
            else if (compra.estadoCompra.Equals("Entregado"))
            {
                foreach (Detallecompra item in compra.detalle)
                {
                    detallesNeg.AgregarStock(item.insumo.id, item.cantidad);
                }
                CompraNeg.Modificar(compra);
                Response.Redirect("compras.aspx");
            }
           

        }

        protected void btnAgregarDesc_Click(object sender, EventArgs e)
        {
            DetalleCompraNegocio detNeg = new DetalleCompraNegocio();
            Detallecompra detalle = new Detallecompra();
            CompraNegocio comNeg = new CompraNegocio();
            List<Detallecompra> listaDetalle = new List<Detallecompra>();
            string descripcion = txbDescripcion.Text;
            if (descripcion != "")
            {
                long idCompra = Convert.ToInt64(Session["idCompraMod"]);
                listaDetalle = detNeg.Listar(Convert.ToInt32(idCompra));
                detNeg.AgregarComentario(idCompra, descripcion);
                foreach (Detallecompra item in listaDetalle)
                {
                    detNeg.ModificarEstado(item.id);
                    detalle = detNeg.BuscarDetalle(Convert.ToInt32(item.id));
                    detNeg.EliminarStock(detalle);
                }

                lblCorrecto.Text = "Elminado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("compras.aspx");
            }
        }

        //protected void dgvDetalles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    try
        //    {
        //        DetalleCompraNegocio DetallesNeg = new DetalleCompraNegocio();
        //        long id = Convert.ToInt64(dgvDetalles.DataKeys[e.RowIndex].Value.ToString());
        //        double PU = Convert.ToDouble((dgvDetalles.Rows[e.RowIndex].FindControl("LblTprod") as Label).Text);
        //        double Total = Convert.ToDouble(Session["TotalCompra"]);
        //        Session["TotalCompra"] = Total - PU;
        //        List<Detallecompra> lista = new List<Detallecompra>();
        //        lista = (Session["DetalleCompra"] as List<Detallecompra>);
        //        lista.RemoveAt(e.RowIndex);
        //        Session["DetalleCompra"] = lista;
        //        dgvDetalles.DataSource = lista;
        //        dgvDetalles.DataBind();
        //        txbTotal.Text = Session["TotalCompra"].ToString();
        //        //Session["TotalCompra"];
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCorrecto.Text = "";
        //        lblIncorrecto.Text = ex.Message;
        //    }
        //}
    }
}