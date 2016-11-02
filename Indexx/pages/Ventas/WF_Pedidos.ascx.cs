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
            //DAO.D_Pedido obj = new DAO.D_Pedido();
            //gridMostrarPendientes.DataSource=obj.ConsultarPedidosPendientes();
            //gridMostrarPendientes.DataBind();
            
        }
        
        protected void btnRefrescar_Click(object sender, EventArgs e)
        {
            mostrarPendientes();
        }





        protected void gvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvItems.PageIndex = e.NewPageIndex;
        }


        protected void gvItems_RowComand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnNombre_Click(object sender, EventArgs e)
        {
            //DAO.DAO_Item obj = new DAO.DAO_Item();
            //dgvItems.DataSource = obj.getItemsByNombre(txtNombre.Value);
            //dgvItems.DataBind();
        }




    }
}