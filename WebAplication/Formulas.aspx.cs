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
    public partial class prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargardgv();
            }
        }

        void cargardgv()
        {
            List<Formula> lista = (new FormulaNegocio().Listar());
            dgvFormulas.DataSource = lista;
            dgvFormulas.DataBind();
        }
        protected void dgvFormulas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    FormulaNegocio FormulaNeg = new FormulaNegocio();
                    Formula formu= new Formula();
                    formu.idInsumo = Convert.ToInt64((dgvFormulas.FooterRow.FindControl("txbidInsumoFooter") as TextBox).Text);
                    formu.idProducto = Convert.ToInt64((dgvFormulas.FooterRow.FindControl("txbidProductoFooter") as TextBox).Text);
                    formu.cantidad = Convert.ToInt32((dgvFormulas.FooterRow.FindControl("txbCantidadFooter") as TextBox).Text);
                    FormulaNeg.Agregar(formu);
                    lblCorrecto.Text = "Agregado correctamente.";
                    lblIncorrecto.Text = "";
                    cargardgv();
                }
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }

        }

        protected void dgvFormulas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvFormulas.EditIndex = e.NewEditIndex;
            cargardgv();

        }

        protected void dgvFormulas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvFormulas.EditIndex = -1;
            cargardgv();
        }

        protected void dgvFormulas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                FormulaNegocio FormulaNeg = new FormulaNegocio();
                Formula formu = new Formula();
                formu.id = Convert.ToInt64(dgvFormulas.DataKeys[e.RowIndex].Value.ToString());
                formu.idInsumo = Convert.ToInt64((dgvFormulas.Rows[e.RowIndex].FindControl("txbidInsumo") as TextBox).Text);
                formu.idProducto= Convert.ToInt64((dgvFormulas.Rows[e.RowIndex].FindControl("txidProducto") as TextBox).Text);
                formu.cantidad = Convert.ToInt32((dgvFormulas.Rows[e.RowIndex].FindControl("txbCantidad") as TextBox).Text);
                FormulaNeg.Modificar(formu);
                lblCorrecto.Text = "Modificado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("formulas.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void dgvFormulas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                FormulaNegocio FormulaNeg = new FormulaNegocio();
                long id = Convert.ToInt64(dgvFormulas.DataKeys[e.RowIndex].Value.ToString());
                FormulaNeg.ModificarEstado(id);
                lblCorrecto.Text = "Elminado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("formulas.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }
    }
}