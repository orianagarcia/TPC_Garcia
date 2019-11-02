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
    public partial class Proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Proveedor> lista = (new ProveedorNegocio().listar());
            dgvProveedores.DataSource = lista;
            dgvProveedores.DataBind();
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            ProveedorNegocio proveedorNeg = new ProveedorNegocio();
            Proveedor prov = new Proveedor();
            //prov.nombre = txbNombre.Text;
            //prov.telefono = txbTelefono.Text;
            //prov.direccion = txbDireccion.Text;
            proveedorNeg.agregar(prov);
        }
    }
}