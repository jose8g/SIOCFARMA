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
        E_Venta obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new E_Venta();
        }


        protected void registrar_Click(object sender, EventArgs e)
        {
            obj.registrar_venta(Text1.Value, DateTime.Now.ToString("MM/dd/yyyy"), Text3.Value, Text4.Value, Text5.Value, Text6.Value);
        }
    }
}