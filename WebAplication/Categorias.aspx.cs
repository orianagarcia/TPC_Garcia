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
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<Categoria> lista = (new CategoriaNegocio().Listar());
                dgvCategorias.DataSource = lista;
                dgvCategorias.DataBind();
                
            }
           
        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio CategoriaNeg = new CategoriaNegocio();
            Categoria categoria = new Categoria();
            categoria.nombre = txbCategoria.Text;
            CategoriaNeg.Agregar(categoria);

        }
    }
}