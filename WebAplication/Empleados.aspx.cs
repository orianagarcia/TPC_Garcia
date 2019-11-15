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
    public partial class Empleados : System.Web.UI.Page
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
            List<Empleado> lista = (new EmpleadoNegocio().Listar());
            dgvEmpleados.DataSource = lista;
            dgvEmpleados.DataBind();
        }
        protected void dgvEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    EmpleadoNegocio EmpleadosNeg = new EmpleadoNegocio();
                    Empleado cli = new Empleado();
                    cli.dni = Convert.ToInt32((dgvEmpleados.FooterRow.FindControl("txbdniFooter") as TextBox).Text);
                    cli.nombre = (dgvEmpleados.FooterRow.FindControl("txbNombreFooter") as TextBox).Text;
                    cli.apellido = (dgvEmpleados.FooterRow.FindControl("txbApellidoFooter") as TextBox).Text;
                    cli.telefono = (dgvEmpleados.FooterRow.FindControl("txbTelefonoFooter") as TextBox).Text;
                    cli.cargo = (dgvEmpleados.FooterRow.FindControl("txbCargoFooter") as TextBox).Text;
                    EmpleadosNeg.Agregar(cli);
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

        protected void dgvEmpleados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvEmpleados.EditIndex = e.NewEditIndex;
            Cargardgv();

        }

        protected void dgvEmpleados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvEmpleados.EditIndex = -1;
            Cargardgv();
        }

        protected void dgvEmpleados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                EmpleadoNegocio EmpleadosNeg = new EmpleadoNegocio();
                Empleado cli = new Empleado();
                cli.id = Convert.ToInt64(dgvEmpleados.DataKeys[e.RowIndex].Value.ToString());
                cli.dni = Convert.ToInt32((dgvEmpleados.Rows[e.RowIndex].FindControl("txbdni") as TextBox).Text);
                cli.nombre = (dgvEmpleados.Rows[e.RowIndex].FindControl("txbNombre") as TextBox).Text;
                cli.apellido = (dgvEmpleados.Rows[e.RowIndex].FindControl("txbApellido") as TextBox).Text;
                cli.telefono = (dgvEmpleados.Rows[e.RowIndex].FindControl("txbTelefono") as TextBox).Text;
                cli.cargo = (dgvEmpleados.Rows[e.RowIndex].FindControl("txbCargo") as TextBox).Text;
                EmpleadosNeg.Modificar(cli);
                lblCorrecto.Text = "Modificado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("Empleados.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void dgvEmpleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                EmpleadoNegocio EmpleadosNeg = new EmpleadoNegocio();
                long id = Convert.ToInt64(dgvEmpleados.DataKeys[e.RowIndex].Value.ToString());
                EmpleadosNeg.ModificarEstado(id);
                lblCorrecto.Text = "Elminado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("Empleados.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }
    }
}