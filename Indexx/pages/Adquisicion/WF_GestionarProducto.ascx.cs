using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using Entidad;
using CONTROL;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Drawing;



namespace Indexx.pages.Adquision
{
    public partial class WF_GestionarProducto : System.Web.UI.UserControl
    {
        E_Item objI;
        DAO_Item obj;
        DAO_Marca objm;
        DAO_ComposicionxItem objci;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new DAO_Item();
            objci = new DAO_ComposicionxItem();
            objm = new DAO_Marca();
            if (!Page.IsPostBack)
            {
                buildListMarcas();
                buildListTipo();
                buildListComposicion();
                this.btnAgregarMarca.Attributes.Add("OnClick", "javascript: return ocultar();");
            }

        }



        public void buildListMarcas()
        {
            ddlMarca.DataSource = obj.getMarcasCreadas();
            ddlMarca.DataTextField = "Nombre";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();
        }

        public void buildListTipo()
        {
            ddlTipo.DataSource = obj.getTipoItemCreadas();
            ddlTipo.DataTextField = "Nombre";
            ddlTipo.DataValueField = "IdTipo";
            ddlTipo.DataBind();
        }

        public void buildListComposicion()
        {
            ddlComposicion.DataSource = obj.getComposicionCreadas();
            ddlComposicion.DataTextField = "Nombre";
            ddlComposicion.DataValueField = "IdComposicion";
            ddlComposicion.DataBind();
        }

        protected void AgregarMarca(object sender, EventArgs e)
        {
        }

        protected void AñadirProductos(object sender, EventArgs e)
        {
            obj.insertarItem(this.txtProducto.Text, this.txtPreVenta.Text, this.ddlEstado.SelectedValue, this.ddlTipo.SelectedValue, this.ddlMarca.SelectedValue);
        }

        protected void AñadirComposicion(object sender, EventArgs e)
        {
           
        }
        protected void dgvProdictoComposicion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "verItems")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    int iditem = Convert.ToInt32(dgvProdictoComposicion.Rows[index].Cells[1].Text);
                    dgvProdictoComposicion.DataSource = objci.getComposicionesxItemCreadas(iditem);
                    dgvProdictoComposicion.DataBind();
                }
            }
            catch (Exception ex) { }

        }
        protected void dgvProdictoComposicion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProdictoComposicion.PageIndex = e.NewPageIndex;
        }

        protected void AñadirNewComposicion(object sender, EventArgs e)
        {
        }

        protected void AgregarNewMarca(object sender, EventArgs e)
        {
            objm.insertarMarca(txtNombreMarca.Text, txtDescripcionMarca.Text);
            buildListMarcas();
        }

        protected void AgregarComposicion(object sender, EventArgs e)
        {
            DataTable dgv = obj.ConsultarItemcreado(txtProducto.Text);
            int codigo = Convert.ToInt32(dgv.Rows[0]["IdItem"].ToString());
            objci.insertarComposicionxItem(txtMedidaComp.Text, Convert.ToInt32(txtCantidadComp.Text), codigo, Convert.ToInt32(ddlComposicion.SelectedValue));
            dgvProdictoComposicion.DataSource = objci.getComposicionesxItemCreadas(codigo);
            dgvProdictoComposicion.DataBind();
        }
    }
}