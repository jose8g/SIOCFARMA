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
        DAO.DAO_Compras daoCompras;
        protected void Page_Load(object sender, EventArgs e)
        {
            daoCompras = new DAO.DAO_Compras();
            if (!Page.IsPostBack)
            {
                buildTableCompras();
                buildListCotizacion();
            }
        }

        protected void gvOrdenCompra_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvComprasList.PageIndex = e.NewPageIndex;
        }


        public void buildTableCompras() {
            dgvComprasList.DataSource = daoCompras.ConsultarCompras();
            dgvComprasList.DataBind();

        }

        protected void getItems(object sender , GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "verItems")
                {
                    int idCompra = Convert.ToInt32(dgvComprasList.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdCompras"].ToString());
                    dgvProductosList.DataSource = daoCompras.GetProductosByCompra(idCompra);
                    dgvProductosList.DataBind();
                    containerItemsCompra.Visible  = true;
                    containterItemsPedido.Visible = false;
                }
                else if (e.CommandName == "verPrecios11")
                {
                    int idItem   = Convert.ToInt32(dgvProductPedido.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                    int idPedido = Convert.ToInt32(ddlPedido.SelectedValue);
                    dgvPreciosItem.DataSource = daoCompras.GetPreciosByItemCotizacion(idItem,idPedido);
                    dgvPreciosItem.DataBind();
                }
                else if (e.CommandName == "verPrecios")
                {
                    GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    String cantCompra = ((TextBox)row.FindControl("cantCompra")).Text;
                    Response.Write("<script>alert('" + cantCompra + "')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        public void buildListCotizacion()
        {
            ddlPedido.DataSource     = daoCompras.GetCotizacionesCreadas();
            ddlPedido.DataTextField  = "FechaRegistro";
            ddlPedido.DataValueField = "IdPedido";
            ddlPedido.DataBind();
            ddlPedido.Items.Insert(0, new ListItem("Selec. Pedido", ""));
        }
        protected void itemSelected(object sender, EventArgs e)
        {
            try
            {
                int idPedido = Convert.ToInt32(ddlPedido.SelectedValue);
                dgvProductPedido.DataSource = daoCompras.GetProductosByPedido(idPedido);
                dgvProductPedido.DataBind();
                containterItemsPedido.Visible = true;
                containerItemsCompra.Visible = false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        protected void insertCompra(object sender, EventArgs e)
        {
            int idCotizacion              = Convert.ToInt32(ddlPedido.SelectedValue);
            if (idCotizacion != null && idCotizacion != 0) {
                dgvComprasList.DataSource = daoCompras.InsertCompraByCotizacion(idCotizacion);
                dgvComprasList.DataBind();

            }
        }

    }
}

