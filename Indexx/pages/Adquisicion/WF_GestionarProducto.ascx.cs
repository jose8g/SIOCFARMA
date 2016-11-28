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
                this.btnNewProveedor.Attributes.Add("OnClick", "javascript: return ocultar5();");
                this.btnNewComposicion.Attributes.Add("OnClick", "javascript: return ocultar3();");
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
            try
            {
            obj.insertarItem(this.txtProducto.Text, this.txtPreVenta.Text, this.ddlEstado.SelectedValue, this.ddlTipo.SelectedValue, this.ddlMarca.SelectedValue);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se registró con éxito.','success')", true);
        }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
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
            catch (Exception ex) {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
        }
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
            //dgvProductoProveedor.PageIndex = e.NewPageIndex;
            dgvProductoProveedor1.PageIndex = e.NewPageIndex;
        }
        protected void AgregarNewMarca(object sender, EventArgs e)
        {
            try
            {
            objm.insertarMarca(txtNombreMarca.Text, txtDescripcionMarca.Text);
            buildListMarcas();
            txtNombreMarca.Text = "";
            txtDescripcionMarca.Text = "";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se registró con éxito.','success')", true);
        }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }
        protected void AgregarNewComposicion(object sender, EventArgs e)
        {
            try
            {
            objcom.insertarComposicion(txtAgrNombre.Text, txtAgrRestriccion.Text);
            buildListComposicion();
            txtAgrNombre.Text = "";
            txtAgrRestriccion.Text = "";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se registró con éxito.','success')", true);
        }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }
        protected void AgregarComposicionItem(object sender, EventArgs e)
        {
            try{
            DataTable dgv = obj.ConsultarItemcreado(txtProducto.Text);
            int codigo = Convert.ToInt32(dgv.Rows[0]["IdItem"].ToString());
            objci.insertarComposicionxItem(txtMedidaComp.Text, Convert.ToInt32(txtCantidadComp.Text), codigo, Convert.ToInt32(ddlComposicion.SelectedValue));
            dgvProdictoComposicion.DataSource = objci.getComposicionesxItemCreadas(codigo);
            dgvProdictoComposicion.DataBind();
            Panel3.Visible = false;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se registró con éxito.','success')", true);
        }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }

        }
        protected void AgregarNewProveedor(object sender, EventArgs e)
        {
            try { 
            int AgrTelefono = Convert.ToInt32(txtAgrTelefono.Text);
            Int64 AgrRuc = Convert.ToInt64(txtAgrRuc.Text);

            if (txtAgrNombrePro.Text == "")
            {
                throw new Exception("Ingrese el nombre");
            }
            if (txtAgrDireccion.Text == "")
            {
                throw new Exception("Ingrese la dirección");
            }
            if (AgrTelefono.ToString() == null)
            {
                throw new Exception("Ingrese el teléfono");
            }
            if (AgrRuc.ToString() == null)
            {
                throw new Exception("Ingrese el ruc");
            }
            if (txtAgrCorreo.Text == "")
            {
                throw new Exception("Ingrese el correo");
            }
            if (txtAgrResponsable.Text == "")
            {
                throw new Exception("Ingrese el responsable");
            }
            if (AgrTelefono <= 10000000)
        {
            DataTable dgv = obj.ConsultarItemcreado(txtProducto.Text);
            int codigo = Convert.ToInt32(dgv.Rows[0]["IdItem"].ToString());
            objpi.insertarProveedorxItem(Convert.ToInt32(ddlProveedor.SelectedValue), codigo, "1");
            //dgvProductoProveedor.DataSource = objpi.getProveedoresxItemCreadas(codigo);
            //dgvProductoProveedor.DataBind();
                throw new Exception("El num. de teléfono debe ser mayor a 7 dígitos");
        }

            if (AgrRuc <= 10000000000)
        {
                throw new Exception("El num. de RUC debe ser de 11 dígitos");
            }

            objp.insertarProveedores(txtAgrNombrePro.Text, txtAgrDireccion.Text, AgrTelefono, AgrRuc, txtAgrCorreo.Text, txtAgrResponsable.Text);
            buildListProveedor();
            txtAgrNombrePro.Text = "";
            txtAgrDireccion.Text = "";
            txtAgrTelefono.Text = "";
            txtAgrRuc.Text = "";
            txtAgrCorreo.Text = "";
            txtAgrResponsable.Text = "";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se registró con éxito.','success')", true);
                }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }

        protected void ddlComposicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            txtNombreComp.Text = Convert.ToString(ddlComposicion.SelectedItem);
            DataTable dgv = objcom.ConsultarCompSeleccionar(Convert.ToString(ddlComposicion.SelectedValue));
            txtRestricionComp.Text = Convert.ToString(dgv.Rows[0]["Restricciones"].ToString());
            Panel3.Visible = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }

        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
            DataTable dgv = obj.ConsultarItemcreado(txtProducto.Text);
            int codigo = Convert.ToInt32(dgv.Rows[0]["IdItem"].ToString());
            objpi.insertarProveedorxItem(Convert.ToInt32(ddlProveedor.SelectedValue), codigo, "1");
            dgvProductoProveedor1.DataSource = objpi.getProveedoresxItemCreadas(codigo);
            dgvProductoProveedor1.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Proveedor Agregado','success')", true);
}
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }
       
    }
}