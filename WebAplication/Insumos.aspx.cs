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
        public List<Insumo> lista = new List<Insumo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Insumo> lista = (new InsumoNegocio().listar());
            dgvInsumos.DataSource = lista;
            dgvInsumos.DataBind();
            cboMedidas.SelectedValue = null;
            cboMedidas.Items.Add("Kilos");
            cboMedidas.Items.Add("Gramos");
            cboMedidas.Items.Add("Miligramos");
            cboMedidas.Items.Add("Litros");
            cboMedidas.Items.Add("Mililitros");
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            InsumoNegocio insumoNeg = new InsumoNegocio();
            Insumo insumo = new Insumo();

            insumo.nombre = txbNombre.Text;
            insumo.stock = 0;
            insumo.medida = cboMedidas.SelectedItem.ToString();
            insumoNeg.agregar(insumo);
        }
    }
}