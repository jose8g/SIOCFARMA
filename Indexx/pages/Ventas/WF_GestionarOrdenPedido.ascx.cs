using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Entidad;
using CONTROL;

namespace Indexx.pages.Ventas
{
    public partial class WF_GestionarOrdenPedido : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //muestro pacientes pendientes

                MostrarPedido();
                //puedo agregar atributos a textboxes
                //Ejemplo: txtEmpresa.Attributes.Add("onKeyPress", "return SoloNumeros (event);");

            }

        }


        public void MostrarPedido()
        {
            CONTROL.C_Pedido con1 = new CONTROL.C_Pedido();
            DataTable dTable = con1.consultarPedido();
            gridGestionarPedidoPendiente.DataSource = dTable;
            gridGestionarPedidoPendiente.DataBind();
        }

        private void Alert(string srtMessage)
        {
            string script = "<script language = javascript> alert('" + srtMessage + "')</script>";
            Page.ClientScript.RegisterStartupScript(
            typeof(Page), "Alert", script);
        }

        protected void LoadCrearPedido(object sender, EventArgs e)
        {
            //abre página crear pedido


        }

        protected void LoadEditarPedido(object sender, EventArgs e)
        {
            //abre página crear pedido

        }

        protected void LoadEliminarPedido(object sender, EventArgs e)
        {
            //abre página crear pedido

        }

        protected void LoadConsultarPedido(object sender, EventArgs e)
        {
            //abre página crear pedido

        }
    }
}