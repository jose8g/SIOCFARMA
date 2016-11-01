using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAO;
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
            }
        }
        protected void gvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvItems.PageIndex = e.NewPageIndex;
            dgvPedidos.PageIndex = e.NewPageIndex;
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
                    String cantidadVenta = ((System.Web.UI.WebControls.TextBox)row.FindControl("Cantidad")).Text;
                    if (cantidadVenta.Length != 0)
                    {
                        int idItem = Convert.ToInt32(dgvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());

                        int salida = objP.updateCantidadPedido(Convert.ToInt32(Session["pedido"]), idItem, Convert.ToInt32(cantidadVenta));
                        if (salida != 0)
                        {
                            dgvItems.DataSource = obj.getItemsByNombre(txtBuscarItems.Value);
                            dgvItems.DataBind();
                        }
                        else
                        {
                            MessageBox.Show("La cantidad no es correcta", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad no es correcta", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (e.CommandName == "eliminarItemxStock")
                {
                    int idItem = Convert.ToInt32(dgvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());

                    dgvPedidos.DataSource = objP.deleteItemxPedido(Convert.ToInt32(Session["pedido"]), idItem);
                    dgvPedidos.DataBind();

                    dgvItems.DataSource = obj.getItemsByNombre(txtBuscarItems.Value);
                    dgvItems.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void GuardarPedidosxItem(object sender, EventArgs e)
        {
            try
            {
                /*int idItem = Convert.ToInt32(IdItemtext.Text);
                int cantidad = Convert.ToInt32(Cantidadtxt.Text);

                if (Session["idPedido"] == null)
                {
                    int idPedido = obj.insertarPedido();
                    obj.insertarPedidoxItem(idPedido.ToString(), idItem.ToString(), cantidad.ToString());
                    Session["idPedido"] = idPedido;
                }
                else
                {
                    obj.insertarPedidoxItem(Session["idPedido"].ToString(), idItem.ToString(), cantidad.ToString());
                }*/
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        protected void registrarPedidosxItem(object sender, EventArgs e)
        {
            
        }
    }
}