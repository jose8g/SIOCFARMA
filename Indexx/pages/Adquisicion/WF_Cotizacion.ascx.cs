using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using CONTROL;
using DAO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Indexx.pages.Adquisicion
{
    public partial class WF_Cotizacion1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtIdProveedor.Attributes.Add("onKeyPress", "return SoloNumeros (event);");
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

        protected void dgvExistente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPedidos.PageIndex = e.NewPageIndex;
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
                    ScriptManager.RegisterStartupScript(this.Page,Page.GetType(), "text", "cliclBtnShowPopup()",true);
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
                //    //ModalPopupExtender1.Show();
                //    //panel2.Visible = true;
                    int index = Convert.ToInt32(e.CommandArgument);
                    txtIdItem.Text = dgvItems.Rows[index].Cells[0].Text;
                    txtCantidadpopup.Text = dgvItems.Rows[index].Cells[3].Text;
                    txtPreciopopup.Text = dgvItems.Rows[index].Cells[4].Text;
                    cargarComboMedidas();
                    BuscarExistente();
                }
                if (e.CommandName == "Eliminar")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    txtIdItem.Text = dgvItems.Rows[index].Cells[0].Text;
                    E_PedidoxItem objE_PedI = new E_PedidoxItem();
                    C_PedidoxItem objC_PedI = new C_PedidoxItem();

                    objE_PedI.IdPedido1 = Convert.ToInt32(txtIdPedido.Text);
                    objE_PedI.IdItem1 = Convert.ToInt32(txtIdItem.Text);

                    objC_PedI.eliminarPedidoxItem(objE_PedI);
                    dgvItems.DataSource = objC_PedI.ListarItemsxPedido(Convert.ToInt32(txtIdPedido.Text));
                    dgvItems.DataBind();
                    Response.Write("<script>alert('" + "Se eliminó el item satisfactoriamente." + "')</script>");
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        private void BuscarExistente()
        {
            C_PedidoxCotizacion objC_PedC = new C_PedidoxCotizacion();
            int a = Convert.ToInt32(txtIdPedido.Text.Trim());
            int b = Convert.ToInt32(txtIdProv.Text.Trim());
            int c = Convert.ToInt32(txtIdItem.Text.Trim());
            dgvExistente.DataSource = objC_PedC.BuscarExistente(a,b,c);
            dgvExistente.DataBind();
            txtEx.Text = dgvExistente.Rows[0].Cells[0].Text;
        }

        private void MostrarPedidoxCotizacion()
        {
            C_PedidoxCotizacion objC_PedC = new C_PedidoxCotizacion();
            int a = Convert.ToInt32(txtIdPedido.Text.Trim());
            int b = Convert.ToInt32(txtIdProv.Text.Trim());
            int c = Convert.ToInt32(txtIdItem.Text.Trim());
            dgvPedidoC.DataSource = objC_PedC.MostrarPedidoxCotizacion(a,b,c);
            dgvPedidoC.DataBind();
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
            //try
            //{
            //    E_PedidoxCotizacion objE_PedC = new E_PedidoxCotizacion();
            //    C_PedidoxCotizacion objC_PedC = new C_PedidoxCotizacion();

            //    int exis = Convert.ToInt32(txtEx.Text);
            //    switch(exis)
            //    {
            //        case 0:
            //            objE_PedC.IdPedido1 = Convert.ToInt32(txtIdPedido.Text);
            //            objE_PedC.IdProveedor1 = Convert.ToInt32(txtIdProv.Text);
            //            objE_PedC.IdLote1 = Convert.ToInt32(txtIdDDL.Text);
            //            objE_PedC.IdItem1 = Convert.ToInt32(txtIdItem.Text);
            //            objE_PedC.Cantidad1 = Convert.ToInt32(txtCantidadMpopup.Text.Trim());
            //            objE_PedC.PrecioUnitario1 = Convert.ToDouble(txtPreciopopup.Text);

            //            objC_PedC.insertarPedidoxCotizacion(objE_PedC);
            //            Response.Write("<script>alert('" + "Se ingresaron los datos satisfactoriamente." + "')</script>");
            //            //MostrarPedidoxCotizacion();

            //            break;

            //        case 1:
            //            objE_PedC.IdPedido1 = Convert.ToInt32(txtIdPedido.Text);
            //            objE_PedC.IdProveedor1 = Convert.ToInt32(txtIdProv.Text);
            //            objE_PedC.IdLote1 = Convert.ToInt32(txtIdDDL.Text);
            //            objE_PedC.IdItem1 = Convert.ToInt32(txtIdItem.Text);
            //            objE_PedC.Cantidad1 = Convert.ToInt32(txtCantidadMpopup.Text.Trim());
            //            objE_PedC.PrecioUnitario1 = Convert.ToDouble(txtPreciopopup.Text);

            //            objC_PedC.actualizarPedidoxCotizacion(objE_PedC);
            //            Response.Write("<script>alert('" + "Se guardaron los cambios satisfactoriamente." + "')</script>");
            //            //MostrarPedidoxCotizacion();

            //            break;
            //            MostrarPedidoxCotizacion();
            //    }

            //    //Response.Write("<script>alert('" + "Se guardaron los cambios satisfactoriamente." + "')</script>");
            //    return;
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('" + ex.Message + "')</script>");
            //    return;
            //}
        }

        private void cargarComboMedidas()
        {
            try
            {
                //C_Lote ctrl = new C_Lote();
                //DataTable dtPrioridad = ctrl.ListarMedidas();
                //ddlMedida.DataSource = dtPrioridad;
                //ddlMedida.DataTextField = "Medida";
                //ddlMedida.DataValueField = "IdLote";
                //ddlMedida.DataBind();
                //ddlMedida.Items.Insert(0, new ListItem("---Seleccionar---", "0"));
            }
            catch { }
        }

        protected void ddlMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt16(ddlMedida.SelectedValue.ToString());
                txtIdDDL.Text = a.ToString();
                //int cantM = 0;
                switch (a)
                {
                    case 3:
                        //cantM = Convert.ToInt32(txtCantidad.Text)/12;
                        txtCantidadMpopup.Text = (Convert.ToInt32(txtCantidadpopup.Text) / 12).ToString();
                        break;
                    case 4:
                        //cantM = Convert.ToInt32(txtCantidad.Text) / 10;
                        txtCantidadMpopup.Text = (Convert.ToInt32(txtCantidadpopup.Text) / 10).ToString();
                        break;
                    case 5:
                        //cantM = Convert.ToInt32(txtCantidad.Text) / 12;
                        txtCantidadMpopup.Text = (Convert.ToInt32(txtCantidadpopup.Text) / 12).ToString();
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        protected void btnVerPanel_Click(object sender, EventArgs e)
        {
            //panel2.Visible = true;
        }

        protected void btnAceptarPopUp_Click(object sender, EventArgs e)
        {
            try
            {
                E_PedidoxCotizacion objE_PedC = new E_PedidoxCotizacion();
                C_PedidoxCotizacion objC_PedC = new C_PedidoxCotizacion();

                int exis = Convert.ToInt32(txtEx.Text);
                switch (exis)
                {
                    case 0:
                        objE_PedC.IdPedido1 = Convert.ToInt32(txtIdPedido.Text);
                        objE_PedC.IdProveedor1 = Convert.ToInt32(txtIdProv.Text);
                        objE_PedC.IdLote1 = Convert.ToInt32(txtIdDDL.Text);
                        objE_PedC.IdItem1 = Convert.ToInt32(txtIdItem.Text);
                        objE_PedC.Cantidad1 = Convert.ToInt32(txtCantidadMpopup.Text.Trim());
                        objE_PedC.PrecioUnitario1 = Convert.ToDouble(txtPreciopopup.Text);

                        objC_PedC.insertarPedidoxCotizacion(objE_PedC);
                        Response.Write("<script>alert('" + "Se ingresaron los datos satisfactoriamente." + "')</script>");
                        //MostrarPedidoxCotizacion();

                        break;

                    case 1:
                        objE_PedC.IdPedido1 = Convert.ToInt32(txtIdPedido.Text);
                        objE_PedC.IdProveedor1 = Convert.ToInt32(txtIdProv.Text);
                        objE_PedC.IdLote1 = Convert.ToInt32(txtIdDDL.Text);
                        objE_PedC.IdItem1 = Convert.ToInt32(txtIdItem.Text);
                        objE_PedC.Cantidad1 = Convert.ToInt32(txtCantidadMpopup.Text.Trim());
                        objE_PedC.PrecioUnitario1 = Convert.ToDouble(txtPreciopopup.Text);

                        objC_PedC.actualizarPedidoxCotizacion(objE_PedC);
                        Response.Write("<script>alert('" + "Se guardaron los cambios satisfactoriamente." + "')</script>");
                        //MostrarPedidoxCotizacion();

                        break;
                        MostrarPedidoxCotizacion();
                }

                //Response.Write("<script>alert('" + "Se guardaron los cambios satisfactoriamente." + "')</script>");
                return;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return;
            }
        }

       
    }
}