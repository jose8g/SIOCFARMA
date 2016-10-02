using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace Indexx.pages.Ventas
{
    public partial class WF_Ventas : System.Web.UI.UserControl
    {
        DAO_Venta obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                obj = new DAO_Venta();
            }   
        }


        protected void registrar_Click(object sender, EventArgs e)
        {
            obj.registrar_venta(Text1.Value, DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), Text3.Value, Text4.Value, Text5.Value, Text6.Value);
        }

        protected void gvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvItems.PageIndex = e.NewPageIndex;
        }

        protected void getItemsByNombre(object sender, EventArgs e)
        {

            dgvItems.DataSource = obj.getItemsByNombre(Text7.Value);
            dgvItems.DataBind();
        }

        protected void gvItems_RowComand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}