using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Indexx.pages.Ventas
{
    public partial class WF_Pedidos : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarPendientes();
        }


        protected void mostrarPendientes()
        {
            DAO.DAO_Pedido obj = new DAO.DAO_Pedido();

            gridMostrarPendientes.DataSource=obj.ConsultarPedidosPendientes();
            gridMostrarPendientes.DataBind();
            
        }

        protected void btnRefrescar_Click(object sender, EventArgs e)
        {
            mostrarPendientes();
        }

    }
}