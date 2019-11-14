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
                    ins.medida = (dgvInsumos.FooterRow.FindControl("txbMedidaFooter") as TextBox).Text;
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
                ins.medida = (dgvInsumos.Rows[e.RowIndex].FindControl("txbMedida") as TextBox).Text;
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
                InsumoNeg.ModificarEstado(id);
                lblCorrecto.Text = "Elminado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("insumos.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void dgvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            DropDownList DropDownList1 = new DropDownList();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                try
                {
                    InsumoNegocio insumoNeg = new InsumoNegocio();
                    List <Insumo> lista = new List<Insumo>();
                    lista = insumoNeg.listar();
                    DropDownList1.DataBind();
                    DropDownList1.DataSource = lista;
                   // DropDownList1 = (e.Row.FindControl("DropDownList1") as DropDownList);
                    DropDownList1.DataValueField = "Id";
                    DropDownList1.DataTextField = "Nombre";
                    DropDownList1.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}