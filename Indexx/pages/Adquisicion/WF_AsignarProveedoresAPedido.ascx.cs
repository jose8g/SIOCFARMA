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

namespace Indexx.pages.Adquisicion
{
    public partial class WF_AsignarProveedoresAPedido : System.Web.UI.UserControl
    {
        DAO_Pedido obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new DAO_Pedido();
            if (!Page.IsPostBack)
            {
                Session["Proveedor"] = null;
                buildListPedido();
                buildListProveedor();
                getProveedorxPedido();
            }

        }

        protected void gvPedidos1_RowComand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void pedidoSelected(object sender, EventArgs e)
        {
            try
            {
                int idPedido = Convert.ToInt32(ddlpedido.SelectedValue);
                dgvPedidos1.DataSource = obj.getItemsDePedido(idPedido);
                dgvPedidos1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void proveedorSelected(object sender, EventArgs e)
        {
            try
            {
                int idProveedor = Convert.ToInt16(ddlproveedor.SelectedValue);
                dgvProveedor.DataSource = obj.getAllProveedor(idProveedor);

                dgvProveedor.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        public void buildListPedido()
        {
            ddlpedido.DataSource = obj.getIdPedido();
            ddlpedido.DataTextField = "NumeroPedido";
            ddlpedido.DataValueField = "IdPedido";
            ddlpedido.DataBind();
            ddlpedido.Items.Insert(0, new ListItem("Selec. Pedido", "0"));

        }

        public void buildListProveedor()
        {
            ddlproveedor.DataSource = obj.getIdProveedor();
            ddlproveedor.DataTextField = "Nombre";
            ddlproveedor.DataValueField = "IdProveedor";
            ddlproveedor.DataBind();
            ddlproveedor.Items.Insert(0, new ListItem("Selec. Proveedor", "0"));

        }

        protected void gvPeoveedores_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "GuardarPedido")
                {
                    int idPedido = Convert.ToInt32(ddlpedido.SelectedValue);
                    int idProveedor = Convert.ToInt32(dgvProveedor.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdProveedor"].ToString());
                    if (idPedido.ToString() == null)
                    {
                        throw new Exception("Acción no permitida");
                    }
                    obj.InsertarProveedorxPedido(idPedido, idProveedor);
                    getProveedorxPedido();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se insertó correctamente','success')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }

        protected void getProveedorxPedido()
        {
            dgvProveedorxPedido.DataSource = obj.getProveedorxPedidos();
            dgvProveedorxPedido.DataBind();
        }

        protected void gvPedidosxPeoveedor_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "eliminarPedidoxProveedor")
                {
                    int idPedido = Convert.ToInt32(dgvProveedorxPedido.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdPedido"].ToString());
                    int idProveedor = Convert.ToInt32(dgvProveedorxPedido.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdProveedor"].ToString());
                    if (idProveedor.ToString() == null)
                    {
                        throw new Exception("Acción no permitida");
                    }

                    dgvProveedorxPedido.DataSource = obj.deleteProveedorxPedido(idPedido,idProveedor);
                    dgvProveedorxPedido.DataBind();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se elimino correctamente','success')", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }
    }
}