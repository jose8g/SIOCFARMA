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
            if (!Page.IsPostBack)
            {
                buildTableCompras();
            }
        }

        protected void gvOrdenCompra_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvComprasList.PageIndex = e.NewPageIndex;
        }

        public void buildTableCompras() {
            DAO.DAO_Compras daoCompras = new DAO.DAO_Compras();
            dgvComprasList.DataSource = daoCompras.ConsultarCompras();
            dgvComprasList.DataBind();
            
        }

        public void getItems(object sender , GridViewCommandEventArgs e)
        {
            if (e.CommandName == "verItems")
            {
                DAO.DAO_Compras daoCompras = new DAO.DAO_Compras();
                int idCompra = Convert.ToInt32(dgvComprasList.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdCompra"].ToString());
                dgvProductosList.DataSource = daoCompras.GetProductosByCompra(2);
                dgvProductosList.DataBind();
            }
        }

        
    }
}