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
                    dgvProductosList.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        public void buildListCotizacion()
        {
            ddlCotizacion.DataSource     = daoCompras.GetCotizacionesCreadas();
            ddlCotizacion.DataTextField  = "FechaRegistro";
            ddlCotizacion.DataValueField = "IdCotizacion";
            ddlCotizacion.DataBind();
            ddlCotizacion.Items.Insert(0, new ListItem("Selec. Cotizacion", ""));
        }
        protected void itemSelected(object sender, EventArgs e)
        {
            int idCotizacion                = Convert.ToInt32(ddlCotizacion.SelectedValue);
            dgvProductCotizacion.DataSource = daoCompras.GetProductosByCotizacion(idCotizacion);
            dgvProductCotizacion.DataBind();
            contentCotizacionProd.Visible = true;
            dgvProductosList.Visible = false;
        }
        protected void insertCompra(object sender, EventArgs e)
        {
            int idCotizacion              = Convert.ToInt32(ddlCotizacion.SelectedValue);
            dgvComprasList.DataSource     = daoCompras.InsertCompraByCotizacion(idCotizacion);
            dgvComprasList.DataBind();
            contentCotizacionProd.Visible = false;
            dgvProductosList.Visible      = false;
        }

    }
}

