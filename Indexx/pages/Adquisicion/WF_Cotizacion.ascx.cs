using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using CONTROL;
using DAO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Indexx.pages.Adquisicion
{
    public partial class WF_Cotizacion1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                
            }
        }

        protected void dgvPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPedidos.PageIndex = e.NewPageIndex;
        }

        protected void dgvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvItems.PageIndex = e.NewPageIndex;
        }

        protected void dgvPedidoC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPedidoC.PageIndex = e.NewPageIndex;
        }

        protected void dgvPedidos_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if(e.CommandName=="Ver")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    txtIdPedido.Text = dgvPedidos.Rows[index].Cells[0].Text;
                    CargarItemsxPedido();
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void dgvItems_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Editar")
                {
                    //ModalPopupExtender1.Show();
                    //panel2.Visible = true;
                    int index = Convert.ToInt32(e.CommandArgument);
                    txtCantidad.Text = dgvItems.Rows[index].Cells[3].Text;
                    txtPrecio.Text = dgvItems.Rows[index].Cells[4].Text;
                    cargarComboMedidas();
                }
                else if (e.CommandName == "Eliminar")
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dgvPedidoC_RowComand(object sender, GridViewCommandEventArgs e)
        {
            //try
            //{
            //    if (e.CommandName == "Ver")
            //    {
            //        int index = Convert.ToInt32(e.CommandArgument);
            //        txtIdPedido.Text = dgvPedidos.Rows[index].Cells[0].Text;
            //        CargarItemsxPedido();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('" + ex.Message + "')</script>");
            //}
        }

        private void CargarPedidosxProveedor()
        {
            DAO.D_Pedido objD_Ped = new D_Pedido();
            int a = Convert.ToInt32(txtIdProveedor.Text.Trim());
            dgvPedidos.DataSource = objD_Ped.ListarPedidosxProveedor(a);
            dgvPedidos.DataBind();
        }

        private void CargarItemsxPedido()
        {
            C_PedidoxItem objC_PedxIt = new C_PedidoxItem();
            int a = Convert.ToInt32(txtIdPedido.Text.Trim());
            dgvItems.DataSource = objC_PedxIt.ListarItemsxPedido(a);
            dgvItems.DataBind();
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            txtIdProveedor.Visible = true;
        }

        protected void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            CargarPedidosxProveedor();
            txtIdProv.Text = txtIdProveedor.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //texto.InnerText = "asdasdasd";
            try
            {
                E_PedidoxCotizacion objE_PedC = new E_PedidoxCotizacion();
                C_PedidoxCotizacion objC_PedC = new C_PedidoxCotizacion();

                objE_PedC.IdPedido1 = Convert.ToInt32(txtIdPedido.Text);
                objE_PedC.IdProveedor1 = Convert.ToInt32(txtIdProv.Text);
                objE_PedC.IdLote1 = Convert.ToInt32(ddlMedida.SelectedValue.ToString());
                objE_PedC.Cantidad1 = Convert.ToInt32(txtCantidadM.Text.Trim());
                objE_PedC.PrecioUnitario1 = Convert.ToDouble(txtPrecio.Text);
                objC_PedC.insertarPedidoxCotizacion(objE_PedC);

                Response.Write("<script>alert('" + "Se guardaron los cambios satisfactoriamente." + "')</script>");
                return;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return;
            }
        }

        private void cargarComboMedidas()
        {
            try
            {
                C_Lote ctrl = new C_Lote();
                DataTable dtPrioridad = ctrl.ListarMedidas();
                ddlMedida.DataSource = dtPrioridad;
                ddlMedida.DataTextField = "Medida";
                ddlMedida.DataValueField = "IdLote";
                ddlMedida.DataBind();
                ddlMedida.Items.Insert(0, new ListItem("---Seleccionar---", "0"));
            }
            catch { }
        }

        protected void ddlMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt16(ddlMedida.SelectedValue.ToString());
                //int cantM = 0;
                switch (a)
                {
                    case 1:
                        //cantM = Convert.ToInt32(txtCantidad.Text)/12;
                        txtCantidadM.Text = (Convert.ToInt32(txtCantidad.Text) / 12).ToString();
                        break;
                    case 2:
                        //cantM = Convert.ToInt32(txtCantidad.Text) / 10;
                        txtCantidadM.Text = (Convert.ToInt32(txtCantidad.Text) / 10).ToString();
                        break;
                    case 3:
                        //cantM = Convert.ToInt32(txtCantidad.Text) / 12;
                        txtCantidadM.Text = (Convert.ToInt32(txtCantidad.Text) / 12).ToString();
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        protected void btnVerPanel_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

       
    }
}