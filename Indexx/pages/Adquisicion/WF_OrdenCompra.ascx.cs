using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAO;

namespace Indexx.pages
{    
    public partial class WF_OrdenCompra  : System.Web.UI.UserControl 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.txtniombre = 

        }

        public void buildTableCompras() {
            DAO.DAO_Compras daoCompras = new DAO.DAO_Compras();
            DataSet table = daoCompras.ConsultarCompras();
            
        }
        //DAO.Class1 docla = new DAO.Class1 

        
        
    }
}