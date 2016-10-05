using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using Entidad;


namespace Indexx.pages.Adquision
{
    public partial class WF_GestionarProducto : System.Web.UI.UserControl
    {
        E_Item objI;
        DAO_Item obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new DAO_Item();
            if (!Page.IsPostBack)
            {
                buildListMarcas();
                buildListTipo();

            }

        }

        protected void serM_OnServerClick(object sender, EventArgs e)
        {
            obj.insertarItem(this.Nombre.Value, this.PrecioVenta.Value,this.ddlEstado.SelectedValue, this.ddlTipo.SelectedValue, this.ddlMarca.SelectedValue);
      

        }

        protected void ser_OnServerClick(object sender, EventArgs e)
        {
            


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
    }
}