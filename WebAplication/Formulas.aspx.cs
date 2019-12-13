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
                cboBuscar.DataSource = new ProductoNegocio().Listar();
                cboBuscar.DataTextField = "Nombre";
                cboBuscar.DataValueField = "id";
                cboBuscar.DataBind();
                dgvFormulas.Columns[0].Visible = false;
            }


        }

        void cargardgv()
        {
            int algo = Convert.ToInt32(Session["idProducto"]);
            List<Formula> lista = (new FormulaNegocio().Listar(algo));
            dgvFormulas.DataSource = lista;
            dgvFormulas.DataBind();
            ((TextBox)dgvFormulas.FooterRow.FindControl("txbProductosFooter")).Text = cboBuscar.SelectedItem.ToString();
            InsumoNegocio insNeg = new InsumoNegocio();
            ((DropDownList)dgvFormulas.FooterRow.FindControl("ddlInsumosFooter")).DataSource = insNeg.listar();
            ((DropDownList)dgvFormulas.FooterRow.FindControl("ddlInsumosFooter")).DataValueField = "id";
            ((DropDownList)dgvFormulas.FooterRow.FindControl("ddlInsumosFooter")).DataTextField = "nombre";
            ((DropDownList)dgvFormulas.FooterRow.FindControl("ddlInsumosFooter")).DataBind();

        }
        protected void dgvFormulas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    FormulaNegocio FormulaNeg = new FormulaNegocio();
                    Formula formu= new Formula();
                    formu.insumo = new Insumo();
                    formu.insumo.id = Convert.ToInt64((dgvFormulas.FooterRow.FindControl("ddlInsumosFooter") as DropDownList).Text);
                    formu.insumo.nombre = (dgvFormulas.FooterRow.FindControl("ddlInsumosFooter") as DropDownList).SelectedItem.ToString();
                    formu.producto = new Producto();
                    formu.producto.id = Convert.ToInt64(Session["idProducto"]) ;
                    formu.producto.nombre = ((TextBox)dgvFormulas.FooterRow.FindControl("txbProductosFooter")).Text;
                    formu.cantidad = Convert.ToInt32((dgvFormulas.FooterRow.FindControl("txbCantidadFooter") as TextBox).Text);
                    FormulaNeg.Agregar(formu);
                    lblCorrecto.Text = "Agregado correctamente.";
                    lblIncorrecto.Text = "";
                    cargardgv();
                    // Response.Redirect("formulas.aspx");
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
            try
            {
                dgvFormulas.EditIndex = e.NewEditIndex;
                cargardgv();
               
                //((TextBox)dgvFormulas.Rows[e.NewEditIndex].FindControl("txbInsumos")).Text = dgvFormulas.Rows[e.NewEditIndex].Cells[1].Text.ToString();
                FormulaNegocio formulaNeg = new FormulaNegocio();
                InsumoNegocio insNeg = new InsumoNegocio();
                ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlInsumos")).DataSource = insNeg.listar();
                ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlInsumos")).DataValueField = "id";
                ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlInsumos")).DataTextField = "nombre";
                ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlInsumos")).DataBind();
                //Insumo insumo = new Insumo();
                //insumo.nombre = ((Label)dgvFormulas.Rows[e.NewEditIndex].FindControl("lblInsumo")).Text;
                int idFormu = Convert.ToInt32((dgvFormulas.Rows[e.NewEditIndex].FindControl("lblId") as Label).Text);
                Formula formu = (formulaNeg.ListarXidFormula(idFormu));
                ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlInsumos")).Items.FindByValue(formu.insumo.id.ToString()).Selected = true;

            }
            catch (Exception ex)
            {

                lblIncorrecto.Text = ex.ToString();
            }
            
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
                formu.insumo = new Insumo();
                formu.insumo.id = Convert.ToInt64((dgvFormulas.Rows[e.RowIndex].FindControl("ddlInsumos") as DropDownList).Text);
                formu.insumo.nombre = (dgvFormulas.Rows[e.RowIndex].FindControl("ddlInsumos") as DropDownList).SelectedItem.ToString();
                formu.cantidad = Convert.ToInt32((dgvFormulas.Rows[e.RowIndex].FindControl("txbCantidad") as TextBox).Text);
                FormulaNeg.Modificar(formu);
                lblCorrecto.Text = "Modificado correctamente.";
                lblIncorrecto.Text = "";
                cargardgv();
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
                cargardgv();
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            FormulaNegocio forNegocio = new FormulaNegocio();
            Formula formula = new Formula();
            var algo = cboBuscar.SelectedValue.ToString();
            Session["idProducto"] = algo; 
            dgvFormulas.DataSource= forNegocio.Listar(Convert.ToInt32(cboBuscar.SelectedValue.ToString()));
            dgvFormulas.DataBind();
            cargardgv();
            btnCancelar.Visible = true;
        }
        protected void btnCancelar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("formulas.aspx");
        }

      
    }
}