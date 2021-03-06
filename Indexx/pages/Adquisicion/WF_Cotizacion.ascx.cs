﻿using System;
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
                CargarPedidosxProveedor();
                txtDescuento.Attributes.Add("onKeyPress", "return SoloNumerosypunto (event);");
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

        protected void dgvLote_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvLote.PageIndex = e.NewPageIndex;
        }

        protected void dgvSubtotal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSubtotal.PageIndex = e.NewPageIndex;
        }

        protected void dgvTotal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvTotal.PageIndex = e.NewPageIndex;
        }

        protected void dgvPedidos_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if(e.CommandName=="Ver")
                {
                    int Usuario = Convert.ToInt32(Session["idUsuario"]);
                    DAO.D_Proveedor objD_Pro = new D_Proveedor();
                    DataTable dgv = objD_Pro.BuscarProveedor(Usuario); ;
                    int codigo = Convert.ToInt32(dgv.Rows[0]["IdProveedor"].ToString());
                    int idPedido = Convert.ToInt32(dgvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdPedido"].ToString());
                    Session["pedido"] = idPedido;
                    CargarItemsxPedido();
                    D_PedidoxCotizacion objD_PedC = new D_PedidoxCotizacion();
                    dgvPedidoC.DataSource = objD_PedC.MostrarPedidoxCotizacion(idPedido, codigo);
                    dgvPedidoC.DataBind();

                    dgvSubtotal.DataSource = objD_PedC.subTotalCotizar(Convert.ToInt32(idPedido), codigo);
                    dgvSubtotal.DataBind();
                    camposCotVis();
                    camposCot2();
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
                    int index = Convert.ToInt32(e.CommandArgument);
                    int idItem = Convert.ToInt32(dgvItems.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                    Session["item"] = idItem;
                    txtCantidadpopup.Text = dgvItems.Rows[index].Cells[3].Text;
                    txtPreciopopup.Text = dgvItems.Rows[index].Cells[4].Text;
                    cargarComboMedidas();
                    BuscarExistente();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "cliclBtnShowPopup()", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }

        protected void dgvPedidoC_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Eliminar")
                {
                    int Usuario = Convert.ToInt32(Session["idUsuario"]);
                    DAO.D_Proveedor objD_Pro = new D_Proveedor();
                    DataTable dgv = objD_Pro.BuscarProveedor(Usuario); ;
                    int codigo = Convert.ToInt32(dgv.Rows[0]["IdProveedor"].ToString());
                    D_PedidoxItem objD_PedI = new D_PedidoxItem();
                    D_PedidoxCotizacion objD_PedC = new D_PedidoxCotizacion();

                    String idPedido = (Session["pedido"] == null) ? null : Session["pedido"].ToString();
                    int idItem = Convert.ToInt32(dgvPedidoC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                    if (idPedido == null)
                    {
                        throw new Exception("Acción no permitida");
                    }

                    dgvPedidoC.DataSource = objD_PedC.eliminarPedidoxCotizacion(Convert.ToInt32(Session["pedido"]), codigo, idItem);
                    dgvPedidoC.DataBind();

                    dgvItems.DataSource = objD_PedI.ListarItemsxPedido(Convert.ToInt32(idPedido), codigo);
                    dgvItems.DataBind();

                    dgvSubtotal.DataSource = objD_PedC.subTotalCotizar(Convert.ToInt32(idPedido), codigo);
                    dgvSubtotal.DataBind();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se eliminó correctamente el item','success')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }

        protected void dgvSubtotal_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Cotizar")
                {
                    E_Cotizacion objE_Cot = new E_Cotizacion();
                    D_Cotizacion objD_Cot = new D_Cotizacion();
                    C_Cotizacion objC_Cot = new C_Cotizacion();
                    
                    double preTotal = Convert.ToDouble(dgvSubtotal.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["SubTotal"].ToString());
                    
                    double desc = Convert.ToDouble(txtDescuento.Text);
                    string nom = txtNombreCot.Text;

                    objE_Cot.PreTotal1 = preTotal;
                    objE_Cot.Descuento1 = Convert.ToDouble(txtDescuento.Text.Trim());
                    objE_Cot.Total1 = (preTotal - (preTotal * (Convert.ToDouble(txtDescuento.Text.Trim()) / 100)));
                    objE_Cot.NombreCotizacion1 = txtNombreCot.Text.Trim();

                    if (desc.ToString() == null)
                    {
                        throw new Exception("Ingrese el descuento");
                    }
                    if (desc <= 0)
                    {
                        throw new Exception("El descuento debe ser mayor a cero.");
                    }
                    if (txtNombreCot.Text == "")
                    {
                        throw new Exception("Ingrese un nombre a la cotización");
                    }
                    camposCot();
                    objC_Cot.insertarCotizacion(objE_Cot);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se registró correctamente la cotización','success')", true);
                }
                else if(e.CommandName == "Finalizar")
                {  
                    D_Cotizacion objD_Cot = new D_Cotizacion();
                    D_Pedido objD_Ped = new D_Pedido();
                    E_Pedido objE_Ped = new E_Pedido();

                    String idPedido = (Session["pedido"] == null) ? null : Session["pedido"].ToString();
                    objE_Ped.IdPedido1 = Convert.ToInt32(Session["pedido"]);
                    objD_Ped.actualizarPedido(objE_Ped);

                    dgvTotal.DataSource = objD_Cot.TotalCotizar();
                    dgvTotal.DataBind();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se finalizó la cotización.','success')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }

        private void camposCot()
        {
            lblNombreCot.Enabled = false;
            txtNombreCot.Enabled = false;
            lblDescuento.Enabled = false;
            txtDescuento.Enabled = false;
        }

        private void camposCot2()
        {
            lblNombreCot.Enabled = true;
            txtNombreCot.Enabled = true;
            lblDescuento.Enabled = true;
            txtDescuento.Enabled = true;
            txtNombreCot.Text = "";
            txtDescuento.Text = "";
        }

        private void camposCotVis()
        {
            lblNombreCot.Visible = true;
            txtNombreCot.Visible = true;
            lblDescuento.Visible = true;
            txtDescuento.Visible = true;
        }

        private void CargarPedidosxProveedor()
        {
            int Usuario = Convert.ToInt32(Session["idUsuario"]);
            DAO.D_Pedido objD_Ped = new D_Pedido();
            DAO.D_Proveedor objD_Pro = new D_Proveedor();
            DataTable dgv = objD_Pro.BuscarProveedor(Usuario); ;
            int codigo = Convert.ToInt32(dgv.Rows[0]["IdProveedor"].ToString());
            //a=ide proveedor
            dgvPedidos.DataSource = objD_Ped.ListarPedidosxProveedor(codigo);
            dgvPedidos.DataBind();
        }

        private void CargarItemsxPedido()
        {
            int Usuario = Convert.ToInt32(Session["idUsuario"]);
            C_PedidoxItem objC_PedxIt = new C_PedidoxItem();
            DAO.D_Proveedor objD_Pro = new D_Proveedor();
            DataTable dgv = objD_Pro.BuscarProveedor(Usuario); ;
            int codigo = Convert.ToInt32(dgv.Rows[0]["IdProveedor"].ToString());
            String idPedido = (Session["pedido"] == null) ? null : Session["pedido"].ToString();
            dgvItems.DataSource = objC_PedxIt.ListarItemsxPedido(Convert.ToInt32(Session["pedido"]),codigo);
            dgvItems.DataBind();
        }

        private void BuscarExistente()
        {
            int Usuario = Convert.ToInt32(Session["idUsuario"]);
            DAO.D_Proveedor objD_Pro = new D_Proveedor();
            DataTable dgv = objD_Pro.BuscarProveedor(Usuario); ;
            int codigo = Convert.ToInt32(dgv.Rows[0]["IdProveedor"].ToString());
            C_PedidoxCotizacion objC_PedC = new C_PedidoxCotizacion();
            String idPedido = (Session["pedido"] == null) ? null : Session["pedido"].ToString();
            String idItem = (Session["item"] == null) ? null : Session["item"].ToString();
            dgvExistente.DataSource = objC_PedC.BuscarExistente(Convert.ToInt32(Session["pedido"]), codigo, Convert.ToInt32(Session["item"]));
            dgvExistente.DataBind();
            txtEx.Text = dgvExistente.Rows[0].Cells[0].Text;
        }

        private void MostrarPedidoxCotizacion()
        {
            int Usuario = Convert.ToInt32(Session["idUsuario"]);
            DAO.D_Proveedor objD_Pro = new D_Proveedor();
            DataTable dgv = objD_Pro.BuscarProveedor(Usuario); ;
            int codigo = Convert.ToInt32(dgv.Rows[0]["IdProveedor"].ToString());
            C_PedidoxCotizacion objC_PedC = new C_PedidoxCotizacion();
            String idPedido = (Session["pedido"] == null) ? null : Session["pedido"].ToString();
            String idItem = (Session["item"] == null) ? null : Session["item"].ToString();
            dgvPedidoC.DataSource = objC_PedC.MostrarPedidoxCotizacion(Convert.ToInt32(Session["pedido"]), codigo);
            dgvPedidoC.DataBind();
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
        }

        protected void btnBuscarProveedor_Click(object sender, EventArgs e)
        
        {
            CargarPedidosxProveedor();
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
                D_Lote objD_Lo = new D_Lote();
                int i;
                int a = Convert.ToInt16(ddlMedida.SelectedValue.ToString());
                txtIdDDL.Text = a.ToString();
                for(i=1; i<10; i++)
                {
                    if(a == i)
                    {
                        dgvLote.DataSource = objD_Lo.MostrarCantidadLote(a);
                        dgvLote.DataBind();
                        txtCantidadMpopup.Text = dgvLote.Rows[0].Cells[0].Text;
                        txtResulCantMpopup.Text = (Convert.ToInt32(txtCantidadpopup.Text) / Convert.ToInt32(txtCantidadMpopup.Text)).ToString();
                    }
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
                int Usuario = Convert.ToInt32(Session["idUsuario"]);
                DAO.D_Proveedor objD_Pro = new D_Proveedor();
                DataTable dgv = objD_Pro.BuscarProveedor(Usuario); ;
                int codigo = Convert.ToInt32(dgv.Rows[0]["IdProveedor"].ToString());
                E_PedidoxCotizacion objE_PedC = new E_PedidoxCotizacion();
                C_PedidoxCotizacion objC_PedC = new C_PedidoxCotizacion();
                D_PedidoxCotizacion objD_PedC = new D_PedidoxCotizacion();
                D_PedidoxItem objD_PedI       = new D_PedidoxItem();

                int exis = Convert.ToInt32(txtEx.Text);
                String idPedido = (Session["pedido"] == null) ? null : Session["pedido"].ToString();
                String idItem = (Session["item"] == null) ? null : Session["item"].ToString();
                switch (exis)
                {
                    case 0:
                        objE_PedC.IdPedido1 = Convert.ToInt32(Session["pedido"]);
                        objE_PedC.IdProveedor1 = codigo;
                        objE_PedC.IdLote1 = Convert.ToInt32(txtIdDDL.Text);
                        objE_PedC.IdItem1 = Convert.ToInt32(Session["item"]);
                        objE_PedC.Cantidad1 = Convert.ToInt32(txtResulCantMpopup.Text.Trim());
                        objE_PedC.PrecioUnitario1 = Convert.ToDouble(txtPreciopopup.Text);

                        if (idPedido == null || idItem == null)
                        {
                            throw new Exception("No se puede registrar el item");
                        }
                        objC_PedC.insertarPedidoxCotizacion(objE_PedC);
                        dgvPedidoC.DataSource = objD_PedC.MostrarPedidoxCotizacion(Convert.ToInt32(Session["pedido"]), codigo);
                        dgvPedidoC.DataBind();
                        dgvItems.DataSource = objD_PedI.ListarItemsxPedido(Convert.ToInt32(idPedido), codigo);
                        dgvItems.DataBind();
                        dgvSubtotal.DataSource = objD_PedC.subTotalCotizar(Convert.ToInt32(idPedido), codigo);
                        dgvSubtotal.DataBind();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se ingresaron los datos correctamente','success')", true);

                        break;

                    case 1:
                        objE_PedC.IdPedido1 = Convert.ToInt32(Session["pedido"]);
                        objE_PedC.IdProveedor1 = codigo;
                        objE_PedC.IdLote1 = Convert.ToInt32(txtIdDDL.Text);
                        objE_PedC.IdItem1 = Convert.ToInt32(Session["item"]);
                        objE_PedC.Cantidad1 = Convert.ToInt32(txtResulCantMpopup.Text.Trim());
                        objE_PedC.PrecioUnitario1 = Convert.ToDouble(txtPreciopopup.Text);

                        if (idPedido == null || idItem == null)
                        {
                            throw new Exception("No se puede actualizar el item");
                        }

                        objC_PedC.actualizarPedidoxCotizacion(objE_PedC);
                        dgvPedidoC.DataSource = objD_PedC.MostrarPedidoxCotizacion(Convert.ToInt32(Session["pedido"]), codigo);
                        dgvPedidoC.DataBind();
                        dgvItems.DataSource = objD_PedI.ListarItemsxPedido(Convert.ToInt32(idPedido), codigo);
                        dgvItems.DataBind();
                        dgvSubtotal.DataSource = objD_PedC.subTotalCotizar(Convert.ToInt32(idPedido), codigo);
                        dgvSubtotal.DataBind();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se guardaron los cambios correctamente','success')", true);

                        break;
                }

                return;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }
    }
}