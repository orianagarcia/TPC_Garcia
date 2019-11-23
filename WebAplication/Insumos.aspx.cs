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
    public partial class Insumos : System.Web.UI.Page
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
            List<Insumo> lista = (new InsumoNegocio().listar());
            dgvInsumos.DataSourceID = null;
            dgvInsumos.DataSource = lista;
            dgvInsumos.DataBind();
            MedidaNegocio MedidaNeg = new MedidaNegocio();
            ((DropDownList)dgvInsumos.FooterRow.FindControl("ddlMedidaFooter")).DataValueField = "id";
            ((DropDownList)dgvInsumos.FooterRow.FindControl("ddlMedidaFooter")).DataTextField = "nombre";
            ((DropDownList)dgvInsumos.FooterRow.FindControl("ddlMedidaFooter")).DataSource = MedidaNeg.Listar();
            ((DropDownList)dgvInsumos.FooterRow.FindControl("ddlMedidaFooter")).DataBind();
        }

        protected void dgvInsumos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    InsumoNegocio InsumoNeg = new InsumoNegocio();
                    Insumo ins = new Insumo();
                    ins.nombre = (dgvInsumos.FooterRow.FindControl("txbNombreFooter") as TextBox).Text;
                    ins.stock = Convert.ToInt32((dgvInsumos.FooterRow.FindControl("txbStockFooter") as TextBox).Text);
                    ins.Medida = (dgvInsumos.FooterRow.FindControl("ddlMedidaFooter") as DropDownList).Text;

                    InsumoNeg.agregar(ins);
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

        protected void dgvInsumos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvInsumos.EditIndex = e.NewEditIndex;
            Cargardgv();
            MedidaNegocio MedidaNeg = new MedidaNegocio();
            InsumoNegocio insNegocio = new InsumoNegocio();
            Insumo In = new Insumo();
           //int id = Convert.ToInt32(dgvInsumos.SelectedDataKey.Value.ToString());
            // Convert.ToInt64(((DropDownList)dgvInsumos.Rows[e.NewEditIndex].FindControl("ddlMedida")).DataValueField);
            ((DropDownList)dgvInsumos.Rows[e.NewEditIndex].FindControl("ddlMedida")).DataValueField = "id";
            ((DropDownList)dgvInsumos.Rows[e.NewEditIndex].FindControl("ddlMedida")).DataTextField = "nombre";
            ((DropDownList)dgvInsumos.Rows[e.NewEditIndex].FindControl("ddlMedida")).DataSource = MedidaNeg.Listar();
            ((DropDownList)dgvInsumos.Rows[e.NewEditIndex].FindControl("ddlMedida")).DataBind();
            //In = (insNegocio.listar(id))[0];
           //((DropDownList)dgvInsumos.Rows[e.NewEditIndex].FindControl("ddlMedida")).Items.FindByValue(In.Medida).Selected = true;

        }

        protected void dgvInsumos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvInsumos.EditIndex = -1;
            Cargardgv();
        }

        protected void dgvInsumos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                InsumoNegocio InsumoNeg = new InsumoNegocio();
                Insumo ins = new Insumo();
                ins.id = Convert.ToInt64(dgvInsumos.DataKeys[e.RowIndex].Value.ToString());
                ins.nombre = (dgvInsumos.Rows[e.RowIndex].FindControl("txbNombre") as TextBox).Text;
                ins.stock = Convert.ToInt32((dgvInsumos.Rows[e.RowIndex].FindControl("txbStock") as TextBox).Text);
                ins.Medida =(dgvInsumos.Rows[e.RowIndex].FindControl("ddlMedida") as DropDownList).SelectedValue;
                InsumoNeg.Modificar(ins);
                lblCorrecto.Text = "Modificado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("insumos.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void dgvInsumos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                InsumoNegocio InsumoNeg = new InsumoNegocio();
                long id = Convert.ToInt64(dgvInsumos.DataKeys[e.RowIndex].Value.ToString());
                if(InsumoNeg.ContarRegistros(Convert.ToInt32(id))==true)
                {
                    lblCorrecto.Visible = true;
                    lblCorrecto.Text = "NO SE PUEDE ELIMINAR EL INSUMO. TIENE PRODUCTOS ASIGNADOS. ";
                    lblIncorrecto.Text = "";
                }
                else
                {
                    InsumoNeg.ModificarEstado(id);
                    lblCorrecto.Text = "Elminado correctamente.";
                    lblIncorrecto.Text = "";
                    Response.Redirect("insumos.aspx");
                }

            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void dgvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            DropDownList dd = new DropDownList();
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    try
            //    {
            //        InsumoNegocio insumoNeg = new InsumoNegocio();
            //        List <Insumo> lista = new List<Insumo>();
            //        lista = insumoNeg.listar();
            //        dd = (e.Row.FindControl() as DropDownList);
            //        //dd.DataValueField = "Id";
            //        //dd.DataTextField = "Nombre";
            //        dd.DataSource = lista;
            //        dd.DataBind();
            //        dd.SelectedIndex = -1;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}
        }
    }
}