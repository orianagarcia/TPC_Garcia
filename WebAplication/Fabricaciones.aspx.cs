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
    public partial class Fabricaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargardgv();
            }

        }

        void Cargardgv()
        {
            List<Fabricacion> lista = (new FabricacionNegocio().Listar());
            dgvFabricaciones.DataSource = lista;
            dgvFabricaciones.DataBind();
        }
        protected void dgvFabricaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    FabricacionNegocio FabricacionesNeg = new FabricacionNegocio();
                    Fabricacion fab = new Fabricacion();
                    fab.idProducto = Convert.ToInt64((dgvFabricaciones.FooterRow.FindControl("txbidProductoFooter") as TextBox).Text);
                    fab.idEmpleado = Convert.ToInt64((dgvFabricaciones.FooterRow.FindControl("txbidEmpleadoFooter") as TextBox).Text);
                    fab.cantidad = Convert.ToDouble((dgvFabricaciones.FooterRow.FindControl("txbCantidadFooter") as TextBox).Text);
                    FabricacionesNeg.Agregar(fab);
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

        protected void dgvFabricaciones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvFabricaciones.EditIndex = e.NewEditIndex;
            Cargardgv();

        }

        protected void dgvFabricaciones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvFabricaciones.EditIndex = -1;
            Cargardgv();
        }

        protected void dgvFabricaciones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                FabricacionNegocio FabricacionesNeg = new FabricacionNegocio();
                Fabricacion fab = new Fabricacion();
                fab.id = Convert.ToInt64(dgvFabricaciones.DataKeys[e.RowIndex].Value.ToString());
                fab.idProducto = Convert.ToInt64((dgvFabricaciones.Rows[e.RowIndex].FindControl("txbidProducto") as TextBox).Text);
                fab.idEmpleado = Convert.ToInt64((dgvFabricaciones.Rows[e.RowIndex].FindControl("txbidEmpleado") as TextBox).Text);
                fab.cantidad = Convert.ToDouble((dgvFabricaciones.Rows[e.RowIndex].FindControl("txbCantidad") as TextBox).Text);
                FabricacionesNeg.Modificar(fab);
                lblCorrecto.Text = "Modificado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("Fabricaciones.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void dgvFabricaciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                FabricacionNegocio FabricacionesNeg = new FabricacionNegocio();
                long id = Convert.ToInt64(dgvFabricaciones.DataKeys[e.RowIndex].Value.ToString());
                FabricacionesNeg.ModificarEstado(id);
                lblCorrecto.Text = "Elminado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("Fabricaciones.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }
    }
}