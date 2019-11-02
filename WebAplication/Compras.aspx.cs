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
            cboProveedores.DataSource = new ProveedorNegocio().listar();
            cboProveedores.DataTextField = "Nombre";
            cboProveedores.DataValueField = "id";
            cboProveedores.DataBind();
         //  cboInsumos.DataSource = new InsumoNegocio().listar();
         //  cboInsumos.DataTextField = "Nombre";
         //  cboInsumos.DataBind();
            cboEstado.Items.Add("");
            cboEstado.Items.Add("Entregado");
            cboEstado.Items.Add("En espera");
            cboEstado.Items.Add("Devolucion");
            cboPago.Items.Add("");
            cboPago.Items.Add("Efectivo");
            cboPago.Items.Add("Mercado Pago");
            cboPago.Items.Add("Tarjeta de credito");
            cboPago.Items.Add("Transferencia");
        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            CompraNegocio compraNeg = new CompraNegocio();
            Compra compra = new Compra();
            compra.Proveedor = cboProveedores.SelectedValue;
            compra.estado = cboEstado.SelectedValue;
            compra.formaPago = cboPago.SelectedValue;
            compra.fechaCompra = DateTime.Now;
            compraNeg.agregar(compra);

        }
    }
}