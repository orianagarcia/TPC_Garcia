﻿using System;
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
            
            cboBuscar.DataSource = new ProductoNegocio().Listar();
            cboBuscar.DataTextField = "Nombre";
            cboBuscar.DataValueField = "id";
            cboBuscar.DataBind();

            InsumoNegocio InsumoNeg = new InsumoNegocio();
            ((DropDownList)dgvFormulas.FooterRow.FindControl("ddlInsumosFooter")).DataValueField = "id";
            ((DropDownList)dgvFormulas.FooterRow.FindControl("ddlInsumosFooter")).DataTextField = "nombre";
            ((DropDownList)dgvFormulas.FooterRow.FindControl("ddlInsumosFooter")).DataSource = InsumoNeg.listar();
            ((DropDownList)dgvFormulas.FooterRow.FindControl("ddlInsumosFooter")).DataBind();

            ProductoNegocio prodNeg = new ProductoNegocio();
            ((DropDownList)dgvFormulas.FooterRow.FindControl("ddlProductosFooter")).DataValueField = "id";
            ((DropDownList)dgvFormulas.FooterRow.FindControl("ddlProductosFooter")).DataTextField = "nombre";
            ((DropDownList)dgvFormulas.FooterRow.FindControl("ddlProductosFooter")).DataSource = prodNeg.Listar();
            ((DropDownList)dgvFormulas.FooterRow.FindControl("ddlProductosFooter")).DataBind();
        }
        protected void dgvFormulas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    FormulaNegocio FormulaNeg = new FormulaNegocio();
                    Formula formu= new Formula();
                    formu.idInsumo = Convert.ToInt64((dgvFormulas.FooterRow.FindControl("ddlInsumosFooter") as DropDownList).Text);
                    formu.idProducto = Convert.ToInt64((dgvFormulas.FooterRow.FindControl("ddlProductosFooter") as DropDownList).Text);
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
            InsumoNegocio InsumoNeg = new InsumoNegocio();
            FormulaNegocio formulaNeg = new FormulaNegocio();
            ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlInsumos")).DataValueField = "id";
            ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlInsumos")).DataTextField = "nombre";
            ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlInsumos")).DataSource = InsumoNeg.listar();
            ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlInsumos")).DataBind();
            Formula formu = (formulaNeg.Listar(e.NewEditIndex + 1))[0];
            ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlInsumos")).Items.FindByValue(formu.idInsumo.ToString()).Selected = true;

            ProductoNegocio ProdNeg = new ProductoNegocio();
            ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlProductos")).DataValueField = "id";
            ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlProductos")).DataTextField = "nombre";
            ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlProductos")).DataSource = ProdNeg.Listar();
            ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlProductos")).DataBind();
            formu = (formulaNeg.Listar(e.NewEditIndex + 1))[0];
            ((DropDownList)dgvFormulas.Rows[e.NewEditIndex].FindControl("ddlProductos")).Items.FindByValue(formu.idProducto.ToString()).Selected = true;

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
                formu.idInsumo = Convert.ToInt64((dgvFormulas.Rows[e.RowIndex].FindControl("ddlInsumos") as DropDownList).Text);
                formu.idProducto= Convert.ToInt64((dgvFormulas.Rows[e.RowIndex].FindControl("ddlProductos") as DropDownList).Text);
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
            
            dgvFormulas.DataSource= forNegocio.Listar(Convert.ToInt32(cboBuscar.SelectedValue));
            dgvFormulas.DataBind();
            btnCancelar.Visible = true;
        }
        protected void btnCancelar_Click1(object sender, EventArgs e)
        {
            cargardgv();

        }
    }
}