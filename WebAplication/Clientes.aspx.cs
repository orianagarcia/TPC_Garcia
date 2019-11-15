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
    public partial class Clientes : System.Web.UI.Page
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
            List<Cliente> lista = (new ClienteNegocio().Listar());
            dgvClientes.DataSource = lista;
            dgvClientes.DataBind();
        }
        protected void dgvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    ClienteNegocio ClientesNeg = new ClienteNegocio();
                    Cliente cli = new Cliente();
                    cli.dni = Convert.ToInt32((dgvClientes.FooterRow.FindControl("txbdniFooter") as TextBox).Text);
                    cli.nombre = (dgvClientes.FooterRow.FindControl("txbNombreFooter") as TextBox).Text;
                    cli.apellido = (dgvClientes.FooterRow.FindControl("txbApellidoFooter") as TextBox).Text;
                    cli.telefono = (dgvClientes.FooterRow.FindControl("txbTelefonoFooter") as TextBox).Text;
                    cli.direccion = (dgvClientes.FooterRow.FindControl("txbDireccionFooter") as TextBox).Text;
                    cli.localidad = (dgvClientes.FooterRow.FindControl("txbLocalidadFooter") as TextBox).Text;
                    ClientesNeg.Agregar(cli);
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

        protected void dgvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvClientes.EditIndex = e.NewEditIndex;
            Cargardgv();

        }

        protected void dgvClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvClientes.EditIndex = -1;
            Cargardgv();
        }

        protected void dgvClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                ClienteNegocio ClientesNeg = new ClienteNegocio();
                Cliente cli = new Cliente();
                cli.id = Convert.ToInt64(dgvClientes.DataKeys[e.RowIndex].Value.ToString());
                cli.dni = Convert.ToInt32((dgvClientes.Rows[e.RowIndex].FindControl("txbdni") as TextBox).Text);
                cli.nombre = (dgvClientes.Rows[e.RowIndex].FindControl("txbNombre") as TextBox).Text;
                cli.apellido = (dgvClientes.Rows[e.RowIndex].FindControl("txbApellido") as TextBox).Text;
                cli.telefono = (dgvClientes.Rows[e.RowIndex].FindControl("txbTelefono") as TextBox).Text;
                cli.direccion = (dgvClientes.Rows[e.RowIndex].FindControl("txbDireccion") as TextBox).Text;
                cli.localidad = (dgvClientes.Rows[e.RowIndex].FindControl("txbLocalidad") as TextBox).Text;
                ClientesNeg.Modificar(cli);
                lblCorrecto.Text = "Modificado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("Clientes.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void dgvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ClienteNegocio ClientesNeg = new ClienteNegocio();
                long id = Convert.ToInt64(dgvClientes.DataKeys[e.RowIndex].Value.ToString());
                ClientesNeg.ModificarEstado(id);
                lblCorrecto.Text = "Elminado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("clientes.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }
    }
}