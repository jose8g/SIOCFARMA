using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using CONTROL;
using DAO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Indexx.pages.Adquisicion
{
    public partial class WF_Cotizacion : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //CargarPedidos();
            }
        }

        protected void gvPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPedido.PageIndex = e.NewPageIndex;
        }

        protected void gvPedidos_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try 
            {
                if (e.CommandName == "Cotizar")
                {

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /*private void CargarPedidos()
        {
            DAO.DAO_Pedido objD_Ped = new DAO_Pedido();
            dgvPedido.DataSource = objD_Ped.ListarPedidos();
            dgvPedido.DataBind();
        }*/
    }
}