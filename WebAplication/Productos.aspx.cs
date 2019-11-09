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
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cboMarca.SelectedIndex = -1;
                cboMarca.DataSource = new MarcaNegocio().Listar();
                cboMarca.DataTextField = "Nombre";
                cboMarca.DataValueField = "id";
                cboMarca.DataBind();
                cboCategoria.DataSource = new CategoriaNegocio().Listar();
                cboCategoria.DataTextField = "Nombre";
                cboCategoria.DataValueField = "id";
                cboCategoria.DataBind();
                
                List<Producto> lista = (new ProductoNegocio().Listar());
                dgvProductos.DataSource = lista;
                dgvProductos.DataBind();
            }
        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            ProductoNegocio ProductoNeg = new ProductoNegocio();
            Marca marca = new Marca();
            Producto prod = new Producto();
            prod.nombre = txbNombre.Text;
            prod.marca = new Marca();
            prod.marca.id = Convert.ToInt64(cboMarca.SelectedValue);
            prod.categoria = new Categoria();
            prod.categoria.id = Convert.ToInt64(cboCategoria.SelectedValue);
            prod.stock = 0;
            prod.costo = 0;
            prod.precioVenta = float.Parse(txbPrecio.Text);
            prod.fechaActualizacion = DateTime.Now;
            prod.estado = true; 
            ProductoNeg.Agregar(prod);
        }
    }
}