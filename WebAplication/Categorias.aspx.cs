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
                Cargardgv();
            }
           
        }
        public void Cargardgv()
        {
            List<Categoria> lista = (new CategoriaNegocio().Listar());
            dgvCategorias.DataSource = lista;
            dgvCategorias.DataBind();
        }
        protected void dgvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    CategoriaNegocio CategoriaNeg = new CategoriaNegocio();
                    Categoria Categ = new Categoria();
                    Categ.nombre = (dgvCategorias.FooterRow.FindControl("txbNombreFooter") as TextBox).Text;
                    CategoriaNeg.Agregar(Categ);
                    lblCorrecto.Text = "Agregado correctamente.";
                    lblIncorrecto.Text = "";
                    Cargardgv();
                }
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }

        }

        protected void dgvCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvCategorias.EditIndex = e.NewEditIndex;
            Cargardgv();

        }

        protected void dgvCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvCategorias.EditIndex = -1;
            Cargardgv();
        }

        protected void dgvCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                CategoriaNegocio CategoriaNeg = new CategoriaNegocio();
                Categoria Categ = new Categoria();
                Categ.id = Convert.ToInt64(dgvCategorias.DataKeys[e.RowIndex].Value.ToString());
                Categ.nombre = (dgvCategorias.Rows[e.RowIndex].FindControl("txbNombre") as TextBox).Text;
                CategoriaNeg.Modificar(Categ);
                lblCorrecto.Text = "Modificado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("categorias.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void dgvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                CategoriaNegocio CategoriaNeg = new CategoriaNegocio();
                long id = Convert.ToInt64(dgvCategorias.DataKeys[e.RowIndex].Value.ToString());
                CategoriaNeg.ModificarEstado(id);
                lblCorrecto.Text = "Elminado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("categorias.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }
    }
}