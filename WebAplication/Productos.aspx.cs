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
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Cargardgv();
            }
            MarcaNegocio MarcaNeg = new MarcaNegocio();
            ((DropDownList)dgvProductos.FooterRow.FindControl("ddlMarcaFooter")).DataValueField = "id";
            ((DropDownList)dgvProductos.FooterRow.FindControl("ddlMarcaFooter")).DataTextField = "nombre";
            ((DropDownList)dgvProductos.FooterRow.FindControl("ddlMarcaFooter")).DataSource = MarcaNeg.Listar();
            ((DropDownList)dgvProductos.FooterRow.FindControl("ddlMarcaFooter")).DataBind();
        }

        void Cargardgv()
        {
            List<Producto> lista = (new ProductoNegocio().Listar());
            dgvProductos.DataSource = lista;
            dgvProductos.DataBind();
        }
        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    ProductoNegocio ProductoNeg = new ProductoNegocio();
                    Producto prod = new Producto();
                    prod.nombre = (dgvProductos.FooterRow.FindControl("txbNombreFooter") as TextBox).Text;
                    prod.idMarca = Convert.ToInt64((dgvProductos.FooterRow.FindControl("ddlMarcaFooter") as DropDownList).Text);
                    prod.idCategoria = Convert.ToInt64((dgvProductos.FooterRow.FindControl("txbCategoriaFooter") as TextBox).Text);
                    prod.stock = Convert.ToDouble((dgvProductos.FooterRow.FindControl("txbStockFooter") as TextBox).Text);
                    prod.costo = Convert.ToDouble((dgvProductos.FooterRow.FindControl("txbCostoFooter") as TextBox).Text);
                    prod.precioVenta = Convert.ToDouble((dgvProductos.FooterRow.FindControl("txbPrecioFooter") as TextBox).Text);
                    ProductoNeg.Agregar(prod);
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

        protected void dgvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvProductos.EditIndex = e.NewEditIndex;
            Cargardgv();

             MarcaNegocio marcaNeg = new MarcaNegocio();
            ProductoNegocio prodNeg = new ProductoNegocio();
            ((DropDownList)dgvProductos.Rows[e.NewEditIndex].FindControl("ddlMarca")).DataValueField = "id";
            ((DropDownList)dgvProductos.Rows[e.NewEditIndex].FindControl("ddlMarca")).DataTextField = "nombre";
            ((DropDownList)dgvProductos.Rows[e.NewEditIndex].FindControl("ddlMarca")).DataSource = marcaNeg.Listar();
            ((DropDownList)dgvProductos.Rows[e.NewEditIndex].FindControl("ddlMarca")).DataBind();
            Producto pr = (prodNeg.Listar(e.NewEditIndex+1))[0];
            ((DropDownList)dgvProductos.Rows[e.NewEditIndex].FindControl("ddlMarca")).Items.FindByValue(pr.idMarca.ToString()).Selected=true;
           CategoriaNegocio catNeg = new CategoriaNegocio();
            ((DropDownList)dgvProductos.Rows[e.NewEditIndex].FindControl("ddlCategoria")).DataValueField = "id";
            ((DropDownList)dgvProductos.Rows[e.NewEditIndex].FindControl("ddlCategoria")).DataTextField = "nombre";
            ((DropDownList)dgvProductos.Rows[e.NewEditIndex].FindControl("ddlCategoria")).DataSource = catNeg.Listar();
            ((DropDownList)dgvProductos.Rows[e.NewEditIndex].FindControl("ddlCategoria")).DataBind();
             pr = (prodNeg.Listar(e.NewEditIndex + 1))[0];
            ((DropDownList)dgvProductos.Rows[e.NewEditIndex].FindControl("ddlCategoria")).Items.FindByValue(pr.idCategoria.ToString()).Selected = true;

        }

        protected void dgvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvProductos.EditIndex = -1;
            Cargardgv();
        }

        protected void dgvProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                ProductoNegocio ProductoNeg = new ProductoNegocio();
                Producto prod = new Producto();
                prod.id = Convert.ToInt64(dgvProductos.DataKeys[e.RowIndex].Value.ToString());
                prod.nombre = (dgvProductos.Rows[e.RowIndex].FindControl("txbNombre") as TextBox).Text;
                prod.idMarca = Convert.ToInt64((dgvProductos.Rows[e.RowIndex].FindControl("ddlMarca") as DropDownList).Text);
                prod.idCategoria = Convert.ToInt64((dgvProductos.Rows[e.RowIndex].FindControl("ddlCategoria") as DropDownList).Text);
                prod.stock = Convert.ToDouble((dgvProductos.Rows[e.RowIndex].FindControl("txbStock") as TextBox).Text);
                prod.costo = Convert.ToDouble((dgvProductos.Rows[e.RowIndex].FindControl("txbCosto") as TextBox).Text);
                prod.precioVenta = Convert.ToDouble((dgvProductos.Rows[e.RowIndex].FindControl("txbPrecio") as TextBox).Text);
                ProductoNeg.Modificar(prod);
                lblCorrecto.Text = "Modificado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("productos.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }

        protected void dgvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ProductoNegocio ProductoNeg = new ProductoNegocio();
                long id = Convert.ToInt64(dgvProductos.DataKeys[e.RowIndex].Value.ToString());
                ProductoNeg.ModificarEstado(id);
                lblCorrecto.Text = "Elminado correctamente.";
                lblIncorrecto.Text = "";
                Response.Redirect("productos.aspx");
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;

            }
        }
    }
}