using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAO;
using System.Collections;

namespace Indexx.pages
{    
    public partial class WF_OrdenCompra  : System.Web.UI.UserControl 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.txtniombre = 
            if (!Page.IsPostBack)
            {
                //buildTableCompras();
                //buildListCotizacion();
            }
        }

        protected void gvOrdenCompra_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvComprasList.PageIndex = e.NewPageIndex;
        }

        public void buildTableCompras()
        {
            //DAO.DAO_Compras daoCompras = new DAO.DAO_Compras();
            //dgvComprasList.DataSource = daoCompras.ConsultarCompras();
            //dgvComprasList.DataBind();

        }

        protected void getItems(object sender , GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "verItems")
                {
                    DAO.DAO_Compras daoCompras = new DAO.DAO_Compras();
                    int idCompra = Convert.ToInt32(dgvComprasList.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdCompras"].ToString());
                    dgvProductosList.DataSource = daoCompras.GetProductosByCompra(idCompra);
                    dgvProductosList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        public void buildListCotizacion()
        {
            DAO.DAO_Compras daoCompras   = new DAO.DAO_Compras();
            ddlCotizacion.DataSource     = daoCompras.GetCotizacionesCreadas();
            ddlCotizacion.DataTextField  = "FechaRegistro";
            ddlCotizacion.DataValueField = "IdCotizacion";
            ddlCotizacion.DataBind();
        }
    }
}