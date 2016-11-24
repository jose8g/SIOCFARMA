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
        DAO_Proveedor objp;
        DAO_ComposicionxItem objci;
        DAO_ProveedorxItem objpi;
        DAO_Composicion objcom;
        protected void Page_Load(object sender, EventArgs e)
        {
            objcom = new DAO_Composicion();
            obj = new DAO_Item();
            objp = new DAO_Proveedor();
            objci = new DAO_ComposicionxItem();
            objpi = new DAO_ProveedorxItem();
            objm = new DAO_Marca();
            if (!Page.IsPostBack)
            {
                buildListMarcas();
                buildListTipo();
                buildListComposicion();
                buildListProveedor();  
                this.btnAgregarMarca.Attributes.Add("OnClick", "javascript: return ocultar();");
                this.btnNewComposicion.Attributes.Add("OnClick", "javascript: return ocultar2();");
                this.btnNewProveedor1.Attributes.Add("OnClick", "javascript: return ocultar5();");
                
            }

        }



        public void buildListMarcas()
        {
            ddlMarca.DataSource = obj.getMarcasCreadas();
            ddlMarca.DataTextField = "Nombre";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("---Seleccionar marca---", "0"));
        }

        public void buildListTipo()
        {
            ddlTipo.DataSource = obj.getTipoItemCreadas();
            ddlTipo.DataTextField = "Nombre";
            ddlTipo.DataValueField = "IdTipo";
            ddlTipo.DataBind();
            ddlTipo.Items.Insert(0, new ListItem("---Seleccionar tipo---", "0"));
        }

        public void buildListComposicion()
        {
            ddlComposicion.DataSource = obj.getComposicionCreadas();
            ddlComposicion.DataTextField = "Nombre";
            ddlComposicion.DataValueField = "IdComposicion";
            ddlComposicion.DataBind();
            ddlComposicion.Items.Insert(0, new ListItem("---Seleccionar Composicion---", "0"));
        }
        public void buildListProveedor()
        {
            ddlProveedor.DataSource = objp.getProveedorCreadas();
            ddlProveedor.DataTextField = "Nombre";
            ddlProveedor.DataValueField = "IdProveedor";
            ddlProveedor.DataBind();
            ddlProveedor.Items.Insert(0, new ListItem("---Seleccionar Proveedor---", "0"));
        }

        protected void AgregarMarca(object sender, EventArgs e)
        {
        }
        protected void AgregarComposicion(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "cliclBtnShowPopup2()", true);
        }
        protected void AgregarProveedor(object sender, EventArgs e)
        {
        }
        protected void AñadirProductos(object sender, EventArgs e)
        {
            obj.insertarItem(this.txtProducto.Text, this.txtPreVenta.Text, this.ddlEstado.SelectedValue, this.ddlTipo.SelectedValue, this.ddlMarca.SelectedValue);
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

        protected void dgvProductoProveedor_RowCommand (object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dgvProductoProveedor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductoProveedor1.PageIndex = e.NewPageIndex;
        }
        protected void AgregarNewMarca(object sender, EventArgs e)
        {
            objm.insertarMarca(txtNombreMarca.Text, txtDescripcionMarca.Text);
            buildListMarcas();
            txtNombreMarca.Text = "";
            txtDescripcionMarca.Text = "";
        }
        protected void AgregarNewComposicion(object sender, EventArgs e)
        {
            objcom.insertarComposicion(txtAgrNombre.Text, txtAgrRestriccion.Text);
            buildListComposicion();
            txtAgrNombre.Text = "";
            txtAgrRestriccion.Text = "";
        }
        protected void AgregarComposicionItem(object sender, EventArgs e)
        {
            DataTable dgv = obj.ConsultarItemcreado(txtProducto.Text);
            int codigo = Convert.ToInt32(dgv.Rows[0]["IdItem"].ToString());
            objci.insertarComposicionxItem(txtMedidaComp.Text, Convert.ToInt32(txtCantidadComp.Text), codigo, Convert.ToInt32(ddlComposicion.SelectedValue));
            dgvProdictoComposicion.DataSource = objci.getComposicionesxItemCreadas(codigo);
            dgvProdictoComposicion.DataBind();
            Panel3.Visible = false;
        }

        protected void AgregarProveedorItem(object sender, EventArgs e)
        {
            DataTable dgv = obj.ConsultarItemcreado(txtProducto.Text);
            int codigo = Convert.ToInt32(dgv.Rows[0]["IdItem"].ToString());
            objpi.insertarProveedorxItem(Convert.ToInt32(ddlProveedor.SelectedValue), codigo, "1");
            dgvProductoProveedor1.DataSource = objpi.getProveedoresxItemCreadas(codigo);
            dgvProductoProveedor1.DataBind();
            Panel4.Visible = false;  
        }

        protected void AgregarNewProveedor(object sender, EventArgs e)
        {
            objp.insertarProveedores(Convert.ToInt32(txtAgrCodigo.Text), txtAgrNombrePro.Text, txtAgrDireccion.Text, Convert.ToInt32(txtAgrTelefono.Text), Convert.ToInt32(txtAgrRuc.Text), txtAgrCorreo.Text, txtAgrResponsable.Text, "1");
            buildListProveedor();
            txtAgrCodigo.Text = "";
            txtAgrNombrePro.Text = "";
            txtAgrDireccion.Text = "";
            txtAgrTelefono.Text = "";
            txtAgrRuc.Text = "";
            txtAgrCorreo.Text = "";
            txtAgrResponsable.Text = "";
        }
        protected void ddlComposicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNombreComp.Text = Convert.ToString(ddlComposicion.SelectedItem);
            DataTable dgv = objcom.ConsultarCompSeleccionar(Convert.ToString(ddlComposicion.SelectedValue));
            txtRestricionComp.Text = Convert.ToString(dgv.Rows[0]["Restricciones"].ToString());
            Panel3.Visible = true;

        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNombreComp.Text = Convert.ToString(ddlProveedor.SelectedItem);
            DataTable dgv = objp.ConsultarProvSeleccionar(Convert.ToInt32(ddlProveedor.SelectedValue));
            txtCodigoProv.Text = Convert.ToString(dgv.Rows[0]["CodigoProveedor"].ToString());
            txtNombreProv.Text = Convert.ToString(dgv.Rows[0]["Nombre"].ToString());
            txtDireccionProv.Text = Convert.ToString(dgv.Rows[0]["Direccion"].ToString());
            txtTelefonoProv.Text = Convert.ToString(dgv.Rows[0]["Telefono"].ToString());
            txtRucProv.Text = Convert.ToString(dgv.Rows[0]["RUC"].ToString());
            txtCorreoProv.Text = Convert.ToString(dgv.Rows[0]["Correo"].ToString());
            txtResponsableProv.Text = Convert.ToString(dgv.Rows[0]["Responsable"].ToString());
            Panel4.Visible = true;         
        }
       
    }
}