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
            if (!IsPostBack)
            {
                cargarEstado1();
                cargarEstado2();
            }

        }

        protected void ser_OnServerClick(object sender, EventArgs e)
        {
            obj.insertarItem(this.Nombre.Value, this.PrecioVenta.Value,this.DropDownList2.SelectedValue, this.DropDownList.SelectedValue, this.DropDownList1.SelectedValue);
      

        }

        public void cargarEstado1()
        {
            //DropDownList.DataSource = //METODOD_Tipo_Item.;
            DropDownList.DataTextField = "Nombre";
            DropDownList.DataValueField = "IdTipo";
            DropDownList.DataBind();
        }

        public void cargarEstado2()
        {
            //DropDownList1.DataSource = //METODOD_Marca_Item.;
            DropDownList.DataTextField = "Nombre";
            DropDownList.DataValueField = "IdMarca";
            DropDownList.DataBind();
        }

        private void cargarTodo()
        {
            Label2.Text = objI.Nombre;
            Label3.Text = objI.PrecioVenta.ToString();
            Label4.Text = objI.Estado.ToString();
            lbl1.Text = objI.IdTipo.ToString();
            Label5.Text = objI.IdMarca.ToString();
        }
    }
}