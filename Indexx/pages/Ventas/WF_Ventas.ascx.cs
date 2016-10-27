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
    public partial class WF_Ventas : System.Web.UI.UserControl
    {
        DAO_Venta obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new DAO_Venta();
            if (!Page.IsPostBack)
            {
                buildListMarca();
                Session["venta"] = null;
                buildTableVentasPendientes();
            }
        }

        protected void gvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvItems.PageIndex = e.NewPageIndex;
        }

        protected void getItemsByNombre(object sender, EventArgs e)
        {
            dgvItems.DataSource = obj.getItemsByNombre(Text7.Value);
            dgvItems.DataBind();
        }
        
        protected void gvItems_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "selecItem")
                {
                    int idItem = Convert.ToInt32(dgvItems.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                    
                    if (Session["venta"] == null)
                    {
                        int idVenta = obj.registrar_venta();
                        dgvCarrito.DataSource = obj.registarItemXVenta(idVenta.ToString(), idItem.ToString());
                        dgvCarrito.DataBind();
                        Session["venta"] = idVenta;
                    }
                    else
                    {
                        dgvCarrito.DataSource = obj.registarItemXVenta(Session["venta"].ToString(), idItem.ToString());;
                        dgvCarrito.DataBind();
                    }
                    buildTableVentasPendientes();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        public void buildListMarca()
        {
            ddlMarca.DataSource     = obj.GetMarcasCreadas();
            ddlMarca.DataTextField  = "Nombre";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Selec. Marca", "0"));
        }

        protected void itemSelected(object sender, EventArgs e)
        {
            int idMarca = Convert.ToInt32(ddlMarca.SelectedValue);
            if (idMarca != 0)
            {
                dgvItems.DataSource = obj.getItemsByMarca(idMarca);
                dgvItems.DataBind();
            }
            else
            {
                dgvItems.DataSource = null;
                dgvItems.DataBind();
            }
        }

        protected void gvCarrito_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "editItem")
                {
                    GridViewRow row = (GridViewRow)(((System.Web.UI.WebControls.Button)e.CommandSource).NamingContainer);
                    String cantidadVenta = ((System.Web.UI.WebControls.TextBox)row.FindControl("cantidadVenta")).Text;
                    if (cantidadVenta.Length != 0)
                    {
                        int idItem = Convert.ToInt32(dgvCarrito.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());

                        int salida = obj.updateCantidad(Convert.ToInt32(Session["venta"]), idItem, Convert.ToInt32(cantidadVenta));
                        if (salida != 0)
                        {
                            dgvItems.DataSource = obj.getItemsByNombre(Text7.Value);
                            dgvItems.DataBind();
                        }
                        else
                        {
                            MessageBox.Show("La cantidad no es correcta", "",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad no es correcta", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (e.CommandName == "deleteItem")
                {
                    int idItem = Convert.ToInt32(dgvCarrito.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());

                    dgvCarrito.DataSource = obj.deleteItemxVenta(Convert.ToInt32(Session["venta"]), idItem);
                    dgvCarrito.DataBind();

                    dgvItems.DataSource = obj.getItemsByNombre(Text7.Value);
                    dgvItems.DataBind();
                }
                buildTableVentasPendientes();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }


        protected void gvVenta_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        public void buildTableVentasPendientes()
        {
            dgvVentas.DataSource = obj.getVentasPendientes();
            dgvVentas.DataBind();
        }
    }
}