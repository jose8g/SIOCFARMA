using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Indexx.pages.Ventas
{
    public partial class WF_CrearOrdenPedido : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }

        }

        protected void btnGenerarOrden_Click(object sender, EventArgs e)
        {

        }
        /*aqui van las llamadas a control 
        public void MostrarDepa()
        {
            CONTROL.C_Pedido con1 = new CONTROL.C_Pedido();
            DataTable dttPed = con1.consultarPedido();
        }*/

    }
}