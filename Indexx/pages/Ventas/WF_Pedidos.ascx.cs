using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAO;
using System.Collections;
using System.Windows.Forms;

namespace Indexx.pages.Ventas
{
    public partial class WF_Pedidos : System.Web.UI.UserControl
    {
        DAO_Item obj;
        DAO_Pedido objP;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new DAO_Item();
            objP = new DAO_Pedido();
            if (!Page.IsPostBack)
            {
                Session["pedido"] = null;
                getItemxStock();
                getPedidos();
            }
        }
        protected void gvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvItems.PageIndex = e.NewPageIndex;
            dgvPedidos.PageIndex = e.NewPageIndex;
            dgvPedidos1.PageIndex = e.NewPageIndex;
        }


        protected void getItemxStock()
        {
            dgvItems.DataSource = obj.getItemxStock();
            dgvItems.DataBind();
        }

        protected void getItemsByNombre(object sender, EventArgs e)
        {
            dgvItems.DataSource = obj.getItemsByNombre(txtBuscarItems.Value);
            dgvItems.DataBind();
        }

        protected void gvItems_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "agregarItemxStock")
                {
                    int idItem = Convert.ToInt32(dgvItems.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                    decimal precio = Convert.ToDecimal(dgvItems.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["PrecioVenta"].ToString());

                    if (Session["pedido"] == null)
                    {
                        int idPedido = obj.insertarPedido();
                        dgvPedidos.DataSource = obj.insertarPedidoxItem(idPedido.ToString(), idItem.ToString(), precio);
                        dgvPedidos.DataBind();
                        Session["pedido"] = idPedido;
                    }
                    else
                    {
                        dgvPedidos.DataSource = obj.insertarPedidoxItem(Session["pedido"].ToString(), idItem.ToString(), precio);
                        dgvPedidos.DataBind();
                    }

                    getPedidos();
                    //dgvPedidos.DataSource = obj.getCopyPedidoxItem();
                    //dgvPedidos.DataBind();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void gvPedidos_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditarItemxStock")
                {
                    GridViewRow row = (GridViewRow)(((System.Web.UI.WebControls.Button)e.CommandSource).NamingContainer);
                    String cantidadVenta = ((System.Web.UI.WebControls.TextBox)row.FindControl("CantidadPedido")).Text;
                    if (Convert.ToInt32(cantidadVenta) <= 0)
                    {
                        throw new Exception("La cantidad debe ser mayor a 0");
                    }
                    if (cantidadVenta.Length != 0)
                    {
                        int idItem = Convert.ToInt32(dgvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                        if (idItem.ToString() == null)
                        {
                            throw new Exception("Acción no permitida");
                        }
                        objP.updateCantidadPedido(Convert.ToInt32(Session["pedido"]), idItem, Convert.ToInt32(cantidadVenta));
                        dgvItems.DataSource = obj.getItemsByNombre(txtBuscarItems.Value);
                        dgvItems.DataBind();
                        getPedidos();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se actualizó correctamente la cantidad','success')", true);
                    }
                    else
                    {
                        throw new Exception("La cantidad debe ser mayor a 0");
                    }
                }
                else if (e.CommandName == "eliminarItemxStock")
                {
                    int idItem = Convert.ToInt32(dgvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                    if (idItem.ToString() == null)
                    {
                        throw new Exception("Acción no permitida");
                    }

                    dgvPedidos.DataSource = objP.deleteItemxPedido(Convert.ToInt32(Session["pedido"]), idItem);
                    dgvPedidos.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }

        protected void getPedidos()
        {
            dgvPedidos1.DataSource = objP.getPedido();
            dgvPedidos1.DataBind();
        }

        protected void gvPedidosMostrar_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int idPedido = Convert.ToInt32(dgvPedidos1.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdPedido"].ToString());
                if (e.CommandName == "eliminarPedido")
                {
                    dgvPedidos1.DataSource = objP.deletePedido(idPedido);
                    dgvPedidos1.DataBind();
                    if (idPedido == Convert.ToInt32(Session["pedido"]))
                    {
                        Session["pedido"] = null;
                        dgvPedidos.DataSource = null;
                        dgvPedidos.DataBind();
                    }
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se eliminó correctamente la venta','success')", true);
                }
                else if (e.CommandName == "finalizarPedido")
                {
                    //int salida = objP.finalizarPedido(idPedido);
                    //if (salida == 1)
                    //{
                    //    if (Convert.ToInt32(Session["pedido"]) == idPedido)
                    //    {
                    //        Session["pedido"] = null;
                    //        dgvPedidos.DataSource = null;
                    //        dgvPedidos.DataBind();
                    //    }
                    //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se realizó correctamente la venta','success')", true);
                    //}
                    //else if (salida == 0)
                    //{
                    //    throw new Exception("Un producto de la lista tiene cantidad igual a 0");
                    //}
                }
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.Message + "')</script>");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }
    }
}