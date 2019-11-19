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
    public partial class Stock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Cargardgv();
            }
        }
        void Cargardgv()
        {
            List<Marca> lista = (new MarcaNegocio().Listar());
            dgvMarcas.DataSource = lista;
            dgvMarcas.DataBind();
        }
        protected void dgvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    MarcaNegocio MarcaNeg = new MarcaNegocio();
                    Marca marca = new Marca();
                    marca.nombre = (dgvMarcas.FooterRow.FindControl("txbNombreFooter") as TextBox).Text;
                    MarcaNeg.Agregar(marca);
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

        protected void dgvMarcas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvMarcas.EditIndex = e.NewEditIndex;
            Cargardgv();

        }

        protected void dgvMarcas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvMarcas.EditIndex = -1;
            Cargardgv();
        }

        protected void dgvMarcas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                MarcaNegocio MarcaNeg = new MarcaNegocio();
                Marca marca = new Marca();
                marca.id = Convert.ToInt64(dgvMarcas.DataKeys[e.RowIndex].Value.ToString());
                marca.nombre = (dgvMarcas.Rows[e.RowIndex].FindControl("txbNombre") as TextBox).Text;
                MarcaNeg.Modificar(marca);
                lblCorrecto.Text = "Modificado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("marcas.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void dgvMarcas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                MarcaNegocio MarcaNeg = new MarcaNegocio();
                long id = Convert.ToInt64(dgvMarcas.DataKeys[e.RowIndex].Value.ToString());
               if( MarcaNeg.ContarRegistros(Convert.ToInt32(id))==true)
                {
                    lblCorrecto.Visible = true;
                    lblCorrecto.Text = "NO SE PUEDE ELIMINAR LA MARCA. TIENE PRODUCTOS ASIGNADOS. ";
                    lblIncorrecto.Text = "";
                }
                else
                {
                    MarcaNeg.ModificarEstado(id);
                    lblCorrecto.Text = "Elminado correctamente.";
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

    }
}