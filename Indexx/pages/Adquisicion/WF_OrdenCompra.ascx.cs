using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAO;
using System.Collections;
using System.Net.Mail;

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
                Session["compra"]    = null;
                Session["proveedor"] = null;
                Session["pedido"]    = null;
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
                    contentProductCompra.Visible  = false;
                }
                else if (e.CommandName == "registrar")
                {
                    int idItem      = Convert.ToInt32(dgvProductPedido.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                    int idPedido    = Convert.ToInt32(Session["pedido"].ToString());//Convert.ToInt32(ddlPedido.SelectedValue);
                    int idProveedor = Convert.ToInt32(Session["proveedor"].ToString());//Convert.ToInt32(ddlProveedores.SelectedValue);
                    GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    int cantidad    = Convert.ToInt32(((TextBox)row.FindControl("cantCompra")).Text);
                    if (idProveedor.ToString() == null)
                    {
                        throw new Exception("Seleccione un proveedor");
                    }
                    if (cantidad.ToString() == null)
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
                    Session["pedido"]    = idPedido;
                    //REFRESCA TABLA DE COMPRAS
                    dgvComprasList.DataSource = daoCompras.ConsultarCompras();
                    dgvComprasList.DataBind();
                    //REFRESCA TABLA DE EDITAR ITEMS POR COMPRA
                    dgvProductoCompra.DataSource = daoCompras.GetProductosByCompra(Convert.ToInt32(Session["compra"]));
                    dgvProductoCompra.DataBind();
                    contentProductCompra.Visible = true;
                    //REFRESCA TABLA DE ITEMS POR PEDIDO
                    dgvProductPedido.DataSource = daoCompras.GetProductosByPedido(idPedido);
                    dgvProductPedido.DataBind();
                    //CONFIRMACION
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se registró correctamente','success')", true);
                } else if (e.CommandName == "editar") {
                    String idCompra = (Session["compra"] == null) ? null : Session["compra"].ToString();
                    int idItem      = Convert.ToInt32(dgvProductoCompra.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                    GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    int cantidad = Convert.ToInt32(((TextBox)row.FindControl("cantCompraEdit")).Text);
                    if(idCompra == null || idItem.ToString() == null){
                        throw new Exception("No se puede actualizar el item");
                    }
                    if (cantidad <= 0) {
                        throw new Exception("La cantidad debe ser mayor a 0");
                    }
                    daoCompras.UpdateItemByCompra(idCompra, idItem,cantidad);
                    //CONFIRMACION
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se editó correctamente','success')", true);
                } else if (e.CommandName == "eliminar") {
                    String idCompra = (Session["compra"] == null) ? null : Session["compra"].ToString();
                    String idPedido = (Session["pedido"] == null) ? null : Session["pedido"].ToString();
                    int idItem      = Convert.ToInt32(dgvProductoCompra.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                    if(idCompra == null){
                        throw new Exception("Acción no permitida");
                    }
                    //REFRESCA TABLA DE EDITAR ITEMS POR PRODUCTO
                    dgvProductoCompra.DataSource = daoCompras.DeleteItemCompra(Convert.ToInt32(Session["compra"]), idItem);
                    dgvProductoCompra.DataBind();
                    //REFRESCA TABLA DE ITEMS POR PEDIDO
                    dgvProductPedido.DataSource = daoCompras.GetProductosByPedido(Convert.ToInt32(idPedido));
                    dgvProductPedido.DataBind();
                    //REFRESCA TABLA DE COMPRAS
                    dgvComprasList.DataSource = daoCompras.ConsultarCompras();
                    dgvComprasList.DataBind();
                    //REEMPLAZA ID COMPRA
                    Session["compra"] = ((Convert.ToInt32(daoCompras.VerifyIfCompraExists(idCompra).Rows[0]["existe"].ToString())) == 0) ? null : Session["compra"];
                    //CONFIRMACION
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se eliminó correctamente','success')", true);
                } else if(e.CommandName == "editarCompra") {
                    int idCompra = Convert.ToInt32(dgvComprasList.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdCompras"].ToString());
                    DataRow row = daoCompras.GetDataCompra(idCompra.ToString()).Rows[0];
                    Session["proveedor"] = row["IdProveedor"];
                    Session["pedido"]    = row["IdPedido"];
                    String pedidoAux = row["IdPedido"].ToString();
                    Session["compra"]    = idCompra;
                    dgvProductPedido.DataSource = daoCompras.GetProductosByPedido(Convert.ToInt32(row["IdPedido"].ToString()));
                    dgvProductPedido.DataBind();
                    dgvProductoCompra.DataSource = daoCompras.GetProductosByCompra(idCompra);
                    dgvProductoCompra.DataBind();
                    buildListCotizacion();
                    ddlProveedores.Visible        = false;
                    containterItemsPedido.Visible = true;
                    contentProductCompra.Visible  = true;
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
                int idPedido      = Convert.ToInt32(ddlPedido.SelectedValue);
                Session["pedido"]    = idPedido;
                Session["compra"]    = null;
                Session["proveedor"] = null;
                dgvProductPedido.DataSource = daoCompras.GetProductosByPedido(idPedido);
                dgvProductPedido.DataBind();
                buildListPedido(idPedido);
                ddlProveedores.Visible        = true;
                containterItemsPedido.Visible = true;
                containerItemsCompra.Visible  = false;
                contentProductCompra.Visible  = false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        protected void itemSelectedProveedor(object sender, EventArgs e)
        {
            try
            {
                int idProveedor   = Convert.ToInt32(ddlProveedores.SelectedValue);
                Session["proveedor"] = idProveedor;
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
                if (Session["compra"] == null)
                {
                    throw new Exception("No hay ninguna compra en proceso");
                }
                String idCompra = Session["compra"].ToString();
                Session["compra"]    = null;
                Session["pedido"]    = null;
                Session["proveedor"] = null;
                buildListCotizacion();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','Se finalizó la compra','success')", true);
                dgvComprasList.DataSource = daoCompras.FinalizarCompra(idCompra);
                dgvComprasList.DataBind();
                containterItemsPedido.Visible = false;
                containerItemsCompra.Visible  = false;
            } catch(Exception ex){
                Response.Write("<script>alert('asdas')</script>");
            }
        }

        protected void sendMail(object sender, EventArgs e) {
            MailMessage mail = new MailMessage();
            mail.To.Add("cesar.villarrreal@gmail.com");
            mail.From = new MailAddress("cesar.villarrreal@gmail.com");
            mail.Subject = "sub";

            mail.Body = "Hola";

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential
                 ("cesar.villarrreal@gmail.com", "1231231231"); // ***use valid credentials***
            smtp.Port = 587;

            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

    }
}
