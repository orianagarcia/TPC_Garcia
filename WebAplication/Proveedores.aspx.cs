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
            if(!IsPostBack)
            {
                Cargardgv();
            }
            
        }

        void Cargardgv( )
        {
            List<Proveedor> lista = (new ProveedorNegocio().listar());
            dgvProveedores.DataSource = lista;
            dgvProveedores.DataBind();
        }
        protected void dgvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    ProveedorNegocio proveedorNeg = new ProveedorNegocio();
                    Proveedor prov = new Proveedor();
                    prov.nombre = (dgvProveedores.FooterRow.FindControl("txbNombreFooter") as TextBox).Text;
                    prov.telefono = (dgvProveedores.FooterRow.FindControl("txbTelefonoFooter") as TextBox).Text;
                    prov.direccion = (dgvProveedores.FooterRow.FindControl("txbDireccionFooter") as TextBox).Text;
                    proveedorNeg.agregar(prov);
                    lblCorrecto.Text = "Agregado correctamente.";
                    lblIncorrecto.Text = "";
                    Cargardgv();
                }
            }
            catch (Exception ex )
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;
                
            }
           
        }

        protected void dgvProveedores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvProveedores.EditIndex = e.NewEditIndex;
            Cargardgv();

        }

        protected void dgvProveedores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvProveedores.EditIndex = -1;
            Cargardgv();
        }

        protected void dgvProveedores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                    ProveedorNegocio proveedorNeg = new ProveedorNegocio();
                    Proveedor prov = new Proveedor();
                    prov.id = Convert.ToInt64(dgvProveedores.DataKeys[e.RowIndex].Value.ToString());
                    prov.nombre = (dgvProveedores.Rows[e.RowIndex].FindControl("txbNombre") as TextBox).Text;
                    prov.telefono = (dgvProveedores.Rows[e.RowIndex].FindControl("txbTelefono") as TextBox).Text;
                    prov.direccion = (dgvProveedores.Rows[e.RowIndex].FindControl("txbDireccion") as TextBox).Text;
                    proveedorNeg.Modificar(prov);
                    lblCorrecto.Text = "Modificado correctamente.";
                    lblIncorrecto.Text = "";
                    Response.Redirect("proveedores.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void dgvProveedores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ProveedorNegocio proveedorNeg = new ProveedorNegocio();
                long id = Convert.ToInt64(dgvProveedores.DataKeys[e.RowIndex].Value.ToString());
                proveedorNeg.ModificarEstado(id);
                lblCorrecto.Text = "Elminado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("proveedores.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }
    }
}