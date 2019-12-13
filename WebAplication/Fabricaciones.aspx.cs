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
            ProductoNegocio ProductoNeg = new ProductoNegocio();
            ddlProductos.DataValueField = "id";
            ddlProductos.DataTextField = "nombre";
            ddlProductos.DataSource = ProductoNeg.Listar();
            ddlProductos.DataBind();
            EmpleadoNegocio EmpleadoNeg = new EmpleadoNegocio();
            ddlEmpleados.DataValueField = "id";
            ddlEmpleados.DataTextField = "nombre";
            ddlEmpleados.DataSource = EmpleadoNeg.Listar();
            ddlEmpleados.DataBind();
        }
        protected void dgvFabricaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    FabricacionNegocio FabricacionesNeg = new FabricacionNegocio();
                    Fabricacion fab = new Fabricacion();
                    fab.producto = new Producto();
                    fab.empleado = new Empleado();
                    fab.producto.id = Convert.ToInt64((dgvFabricaciones.FooterRow.FindControl("ddlProductosFooter") as DropDownList).Text);
                    fab.empleado.id = Convert.ToInt64((dgvFabricaciones.FooterRow.FindControl("ddlEmpleadosFooter") as DropDownList).Text);
                    fab.cantidad = Convert.ToDouble((dgvFabricaciones.FooterRow.FindControl("txbCantidadFooter") as TextBox).Text);
                    fab.estadoFab = ((dgvFabricaciones.FooterRow.FindControl("ddlEstadosFooter") as DropDownList).Text);
                    fab.fechaInicio = Convert.ToDateTime(txbInicio.Text);
                    fab.fechaFin = Convert.ToDateTime(txbFin.Text); 
                    FabricacionesNeg.Agregar(fab);
                    FabricacionesNeg.AgregarStock(fab.producto.id, fab.cantidad);
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
            FabricacionNegocio fabNeg = new FabricacionNegocio();
            ProductoNegocio prodNeg = new ProductoNegocio();
            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlProductos")).DataValueField = "id";
            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlProductos")).DataTextField = "nombre";
            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlProductos")).DataSource = prodNeg.Listar();
            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlProductos")).DataBind();
            Producto pr = (prodNeg.Listar(e.NewEditIndex + 1))[0];
            Fabricacion fab = (fabNeg.Listar(e.NewEditIndex + 1))[0];
            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlProductos")).Items.FindByValue(fab.producto.id.ToString()).Selected = true;
             fabNeg = new FabricacionNegocio();
            EmpleadoNegocio empNeg = new EmpleadoNegocio();
            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlEmpleados")).DataValueField = "id";
            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlEmpleados")).DataTextField = "nombre";
            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlEmpleados")).DataSource = empNeg.Listar();
            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlEmpleados")).DataBind();
            //Fabricacion fab = (fabNeg.Listar(e.NewEditIndex + 1))[0];               
            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlEmpleados")).Items.FindByValue(fab.empleado.id.ToString()).Selected = true;

            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlEstadoEdit")).Items.Add("Pendiente");
            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlEstadoEdit")).Items.Add("Completado");
            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlEstadoEdit")).Items.Add("Cancelado");
            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlEstadoEdit")).DataBind();
            ((DropDownList)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("ddlEstadoEdit")).Items.FindByValue(fab.estadoFab).Selected = true;
            ((TextBox)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("txbFechaI")).Text = fab.fechaInicio.ToString("yyyy-MM-dd");
            ((TextBox)dgvFabricaciones.Rows[e.NewEditIndex].FindControl("txbFechaFin")).Text = fab.fechaFin.ToString("yyyy-MM-dd");
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
                fab.producto = new Producto();
                fab.empleado = new Empleado();
                fab.id = Convert.ToInt64(dgvFabricaciones.DataKeys[e.RowIndex].Value.ToString());
                fab.producto.id = Convert.ToInt64((dgvFabricaciones.Rows[e.RowIndex].FindControl("ddlProductos") as DropDownList).Text);
                fab.empleado.id = Convert.ToInt64((dgvFabricaciones.Rows[e.RowIndex].FindControl("ddlEmpleados") as DropDownList).Text);
                fab.cantidad = Convert.ToDouble((dgvFabricaciones.Rows[e.RowIndex].FindControl("txbCantidad") as TextBox).Text);
                fab.estadoFab = (dgvFabricaciones.Rows[e.RowIndex].FindControl("ddlEstadoEdit") as DropDownList).Text;
                fab.fechaInicio = Convert.ToDateTime((dgvFabricaciones.Rows[e.RowIndex].FindControl("txbFechaI") as TextBox).Text);
                fab.fechaFin = Convert.ToDateTime((dgvFabricaciones.Rows[e.RowIndex].FindControl("txbFechaFin") as TextBox).Text);
                List<Formula> listaFormula;
                FormulaNegocio formuNeg = new FormulaNegocio();
                listaFormula = formuNeg.Listar(Convert.ToInt32(fab.producto.id)); 
                if(fab.estadoFab.Equals("Completado"))
                {
                    int cant = FabricacionesNeg.ContarInsumosXProd(fab.producto.id);
                    if (FabricacionesNeg.VerificarStock(fab.producto.id, cant, fab.cantidad))
                    {
                        FabricacionesNeg.AgregarStock(fab.producto.id, fab.cantidad);
                        FabricacionesNeg.Modificar(fab);
                        foreach(Formula item in listaFormula)
                        {
                            FabricacionesNeg.DisminuirStock(item.insumo.id, item.cantidad, fab.cantidad);
                        }
                        lblCorrecto.Text = "Modificado correctamente.";
                        lblIncorrecto.Text = "";
                        Response.Redirect("Fabricaciones.aspx");
                    }
                    else
                    {
                        Cargardgv();
                        lblCorrecto.Text = "";
                        lblIncorrecto.Text = "No se modifico";
                        Response.Redirect("Fabricaciones.aspx");
                    }
                    
                }
                else 
                {
                    FabricacionesNeg.Modificar(fab);
                    Response.Redirect("Fabricaciones.aspx");
                }
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            FabricacionNegocio FabricacionesNeg = new FabricacionNegocio();
            Fabricacion fab = new Fabricacion();
            fab.producto = new Producto();
            fab.empleado = new Empleado();
            fab.producto.id = Convert.ToInt64(ddlProductos.SelectedValue);
            fab.empleado.id = Convert.ToInt64(ddlEmpleados.SelectedValue);
            fab.cantidad = Convert.ToDouble(txbCantidad.Text);
            fab.estadoFab = ddlEstados.SelectedValue;
            fab.fechaInicio = Convert.ToDateTime(txbInicio.Text);
            fab.fechaFin = Convert.ToDateTime(txbFin.Text);
            List<Formula> listaFormula;
            FormulaNegocio formuNeg = new FormulaNegocio();
            listaFormula = formuNeg.Listar(Convert.ToInt32(fab.producto.id));
            if (fab.estadoFab.Equals("Completado"))
            {
                int cant = FabricacionesNeg.ContarInsumosXProd(fab.producto.id);
                if (FabricacionesNeg.VerificarStock(fab.producto.id, cant, fab.cantidad))
                {
                    FabricacionesNeg.AgregarStock(fab.producto.id, fab.cantidad);
                    lblCorrecto.Text = "Tenemos los insumos!";
                    lblIncorrecto.Text = " ";
                    FabricacionesNeg.Agregar(fab);
                    foreach (Formula item in listaFormula)
                    {
                        FabricacionesNeg.DisminuirStock(item.insumo.id, item.cantidad,fab.cantidad);
                    }
                    Cargardgv();
                }
                else
                {
                    lblIncorrecto.Text = "No hay insumos suficientes. Se asignara estado Pendiente";
                    lblCorrecto.Text = " ";
                    fab.estadoFab = "Pendiente";
                    FabricacionesNeg.Agregar(fab);
                    Cargardgv();

                }  
            }
            else if(fab.estadoFab.Equals("Pendiente"))
            {
                int cant = FabricacionesNeg.ContarInsumosXProd(fab.producto.id);
               if( FabricacionesNeg.VerificarStock(fab.producto.id, cant,fab.cantidad))
                {
                    lblCorrecto.Text = "Tenemos los insumos!";
                    lblIncorrecto.Text = " "; 
                    FabricacionesNeg.Agregar(fab);
                    Cargardgv();
                }
               else
                {
                    lblIncorrecto.Text = "No hay insumos suficientes.";
                    lblCorrecto.Text = " ";
                    FabricacionesNeg.Agregar(fab);
                    Cargardgv();
                }
            }
            else
            {
                lblCorrecto.Text = "Agregado correctamente.";
                lblIncorrecto.Text = "";
                FabricacionesNeg.Agregar(fab);
                Cargardgv();
            }
           
        }
    }
}