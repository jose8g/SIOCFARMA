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
                else if (e.CommandName == "registrar")
                {
                    int idItem      = Convert.ToInt32(dgvProductPedido.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                    int idPedido    = Convert.ToInt32(ddlPedido.SelectedValue);
                    int idProveedor = Convert.ToInt32(ddlProveedores.SelectedValue);
                    GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    int cantidad    = Convert.ToInt32(((TextBox)row.FindControl("cantCompra")).Text);
                    if(idProveedor == null){
                        throw new Exception("Seleccione un proveedor");
                    }
                    if (cantidad == null)
                    {
                        throw new Exception("Ingrese la cantidad");
                    }
                    if(cantidad <= 0){
                        throw new Exception("La cantidad debe ser mayor que cero");
                    }
                    String proveedorSession = (Session["proveedor"] == null) ? null : Session["proveedor"].ToString();
                    if (proveedorSession != null && proveedorSession != idProveedor.ToString())
                    {
                        throw new Exception("No puedes cambiar de proveedor para esta compra");
                    }
                    String idCompra      = (Session["compra"] == null) ? null : Session["compra"].ToString();
                    Session["compra"]    = Convert.ToInt32(daoCompras.InsertCompra(idCompra, idPedido, idProveedor, idItem, cantidad).Rows[0]["IdCompra"].ToString());
                    Session["proveedor"] = idProveedor;

                    dgvComprasList.DataSource = daoCompras.ConsultarCompras();
                    dgvComprasList.DataBind();

                    dgvProductPedido.DataSource = daoCompras.GetProductosByPedido(idPedido);
                    dgvProductPedido.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','"+ex.Message+"','error')", true);
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
        public void buildListPedido(int idPedido)
        {
            ddlProveedores.DataSource = daoCompras.GetProveedoresPedido(idPedido);
            ddlProveedores.DataTextField  = "Nombre";
            ddlProveedores.DataValueField = "IdProveedor";
            ddlProveedores.DataBind();
            ddlProveedores.Items.Insert(0, new ListItem("Selec. Proveedor", ""));
        }
        protected void itemSelected(object sender, EventArgs e)
        {
            try
            {
                int idPedido = Convert.ToInt32(ddlPedido.SelectedValue);
                dgvProductPedido.DataSource = daoCompras.GetProductosByPedido(idPedido);
                dgvProductPedido.DataBind();
                buildListPedido(idPedido);
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
            try
            {
                //if (Session["compra"] == null)
                //{
                //    throw new Exception("No hay ninguna compra en proceso");
                //}
                Session["compra"]    = null;
                Session["proveedor"] = null;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','Hubo un error','info')", true);
            } catch(Exception ex){
                Response.Write("<script>alert('asdas')</script>");
            }
        }

    }
}
