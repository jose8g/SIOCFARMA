using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAO;

namespace Indexx.pages.Ventas
{
    public partial class WF_Pedidos : System.Web.UI.UserControl
    {
        DAO_Item obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new DAO_Item();
            if (!Page.IsPostBack)
            {
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
            /*dgvItems.DataSource = obj.getItemxStock();
            dgvItems.DataBind();*/
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
                    //string nombre = (dgvItems.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["Nombre"].ToString());
                    //double precioVenta = Convert.ToDouble(dgvItems.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["PrecioVenta"].ToString());

                    //IdItemtext.Text = idItem.ToString();
                    //Nombretxt.Text = nombre;
                    //Preciotxt.Text = precioVenta.ToString();

                    dgvPedidos.DataSource = obj.getCopyPedidoxItem();
                    dgvPedidos.DataBind();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void gvPedidos_RowComand(object sender, GridViewCommandEventArgs e)
        {
            
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