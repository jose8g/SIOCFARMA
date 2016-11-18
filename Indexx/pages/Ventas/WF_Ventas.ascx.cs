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
                buildListTipo();
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
            int idMarca = Convert.ToInt32(ddlMarca.SelectedValue);
            int idTipo = Convert.ToInt32(ddlTipo.SelectedValue);
            dgvItems.DataSource = obj.getItemsByNombre(Text7.Value, idMarca, idTipo);
            dgvItems.DataBind();
        }
        
        protected void gvItems_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "selecItem")
                {
                    int idItem = Convert.ToInt32(dgvItems.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                    if (idItem.ToString() == null)
                    {
                        throw new Exception("Acción no permitida");
                    }
                    if (Session["venta"] == null)
                    {
                        int idVenta = obj.registrar_venta();
                        dgvCarrito.DataSource = obj.registarItemXVenta(idVenta.ToString(), idItem.ToString());
                        dgvCarrito.DataBind();
                        Session["venta"] = idVenta;
                        tituloVenta.InnerText = "Venta " + idVenta.ToString();
                    }
                    else
                    {
                        dgvCarrito.DataSource = obj.registarItemXVenta(Session["venta"].ToString(), idItem.ToString());;
                        dgvCarrito.DataBind();
                        tituloVenta.InnerText = "Venta " + Session["venta"].ToString();
                    }
                    buildTableVentasPendientes();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
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

        public void buildListTipo()
        {
            ddlTipo.DataSource = obj.GetTiposCreados();
            ddlTipo.DataTextField = "Nombre";
            ddlTipo.DataValueField = "IdTipo";
            ddlTipo.DataBind();
            ddlTipo.Items.Insert(0, new ListItem("Selec. Tipo", "0"));
        }

        protected void marcaSelected(object sender, EventArgs e)
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

        protected void tipoSelected(object sender, EventArgs e)
        {
            int idTipo = Convert.ToInt32(ddlTipo.SelectedValue);
            if (idTipo != 0)
            {
                dgvItems.DataSource = obj.getItemsByMarca(idTipo);
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
                    if (cantidadVenta == null)
                    {
                        throw new Exception("Debe especificar una cantidad");
                    }
                    if (cantidadVenta.Length != 0 && Convert.ToInt32(cantidadVenta) > 0)
                    {
                        int idItem = Convert.ToInt32(dgvCarrito.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                        if (idItem.ToString() == null)
                        {
                            throw new Exception("Acción no permitida");
                        }
                        int salida = obj.updateCantidad(Convert.ToInt32(Session["venta"]), idItem, Convert.ToInt32(cantidadVenta));
                        if (salida != 0)
                        {
                            int idMarca = Convert.ToInt32(ddlMarca.SelectedValue);
                            int idTipo = Convert.ToInt32(ddlTipo.SelectedValue);
                            dgvItems.DataSource = obj.getItemsByNombre(Text7.Value, idMarca, idTipo);
                            dgvItems.DataBind();
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se actualizó correctamente la cantidad','success')", true);
                        }
                        else
                        {
                            throw new Exception("La cantidad sobrepasa el stock");
                        }
                    }
                    else
                    {
                        throw new Exception("La cantidad debe ser mayor a 0");
                    }
                }
                else if (e.CommandName == "deleteItem")
                {
                    int idItem = Convert.ToInt32(dgvCarrito.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                    if (idItem.ToString() == null)
                    {
                        throw new Exception("Acción no permitida");
                    }
                    DataTable ventaXItem = obj.deleteItemxVenta(Convert.ToInt32(Session["venta"]), idItem);
                    dgvCarrito.DataSource = ventaXItem;
                    dgvCarrito.DataBind();
                    if (ventaXItem.Rows.Count == 0)
                    {
                        obj.deleteVenta(Convert.ToInt32(Session["venta"]));
                        buildTableVentasPendientes();
                        int idMarca = Convert.ToInt32(ddlMarca.SelectedValue);
                        int idTipo = Convert.ToInt32(ddlTipo.SelectedValue);
                        dgvItems.DataSource = obj.getItemsByNombre(Text7.Value, idMarca, idTipo);
                        dgvItems.DataBind();
                        Session["venta"] = null;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se eliminó correctamente la venta','success')", true);
                        tituloVenta.InnerText = "";
                    }
                    int idMarcaCombo = Convert.ToInt32(ddlMarca.SelectedValue);
                    int idTipoCombo = Convert.ToInt32(ddlTipo.SelectedValue);
                    dgvItems.DataSource = obj.getItemsByNombre(Text7.Value, idMarcaCombo, idTipoCombo);
                    dgvItems.DataBind();
                }
                buildTableVentasPendientes();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }


        protected void gvVenta_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int idVenta = Convert.ToInt32(dgvVentas.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdVenta"].ToString());
                if(e.CommandName == "deleteVenta")
                {
                    obj.deleteVenta(idVenta);
                    buildTableVentasPendientes();
                    int idMarca = Convert.ToInt32(ddlMarca.SelectedValue);
                    int idTipo = Convert.ToInt32(ddlTipo.SelectedValue);
                    dgvItems.DataSource = obj.getItemsByNombre(Text7.Value, idMarca, idTipo);
                    dgvItems.DataBind();
                    if (idVenta == Convert.ToInt32(Session["venta"]))
                    {
                        Session["venta"] = null;
                        dgvCarrito.DataSource = null;
                        dgvCarrito.DataBind();
                        tituloVenta.InnerText = "";
                    }
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se eliminó correctamente la venta','success')", true);
                }
                else if (e.CommandName == "editVenta")
                {
                    Session["venta"] = idVenta;
                    getItemsByVenta(idVenta);
                    tituloVenta.InnerText = "Venta " + Session["venta"];
                }
                else if (e.CommandName == "finalizarVenta")
                {
                    decimal precioTotal = Convert.ToDecimal(dgvVentas.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["PrecioTotal"].ToString());
                    if (precioTotal > 0)
                    {
                        int salida  = obj.finalizarVenta(idVenta);
                        if (salida == 1)
                        {
                            buildTableVentasPendientes();
                            if (Convert.ToInt32(Session["venta"]) == idVenta)
                            {
                                Session["venta"] = null;
                                dgvCarrito.DataSource = null;
                                dgvCarrito.DataBind();
                                tituloVenta.InnerText = "";
                            }
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se realizó correctamente la venta','success')", true);
                        }
                        else if(salida == 0)
                        {
                            throw new Exception("Un producto de la lista tiene cantidad igual a 0");
                        }
                    }
                    else
                    {
                        throw new Exception("El precio total no puede ser igual a 0");
                    }
                }

            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.Message + "')</script>");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }

        public void buildTableVentasPendientes()
        {
            dgvVentas.DataSource = obj.getVentasPendientes();
            dgvVentas.DataBind();
        }

        public void getItemsByVenta(int IdVenta)
        {
            dgvCarrito.DataSource = obj.getItemsByVenta(IdVenta);
            dgvCarrito.DataBind();
        }
    }
}