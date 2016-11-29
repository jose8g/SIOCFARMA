using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using CONTROL;
using Entidad;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace Indexx.pages.Almacen
{
    public partial class WF_AdministrarMovimientos : System.Web.UI.UserControl
    {
        C_TipoMovimiento cTiMov;
        C_Movimientos cMov;
        DAO_Movimientos dmov;
        DAO_Compras dcom;
        DAO_Venta obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            dmov = new DAO_Movimientos();
            obj = new DAO_Venta();
            dcom = new DAO_Compras();
            cTiMov = new C_TipoMovimiento();
            cMov = new C_Movimientos();
            if (!IsPostBack)
            {
                buildListMarca();
                buildListTipo();
                buildListMarcan();
                buildListTipon();
                buildListOrdenCompra();
                buildListTipoMovimiento();
            }
        }

        public void buildListTipoMovimiento()
        {
            ddlTipoMov.DataSource = cTiMov.getTipoMovimiento();
            ddlTipoMov.DataTextField = "Nombre";
            ddlTipoMov.DataValueField = "IdTipoMovimiento";
            ddlTipoMov.DataBind();
            ddlTipoMov.Items.Insert(0, new ListItem("-Seleccionar Movimiento-", "0"));

        }
        protected void itemSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoMov.SelectedIndex == 1)
            {
                PnlEntrada.Visible = true;
                PnlSalida.Visible= false;
                PnlAjustePositivo.Visible= false;
                PnlAjusteNegativo.Visible = false;
                
            }
            else if (ddlTipoMov.SelectedIndex == 2)
            {
                PnlEntrada.Visible = false;
                PnlSalida.Visible = true;
                PnlAjustePositivo.Visible = false;
                PnlAjusteNegativo.Visible = false;
                
            }
            else if (ddlTipoMov.SelectedIndex == 3)
            {
                PnlEntrada.Visible = false;
                PnlSalida.Visible = false;
                PnlAjustePositivo.Visible = true;
                PnlAjusteNegativo.Visible = false;
            }
            else if (ddlTipoMov.SelectedIndex == 4)
            {
                PnlEntrada.Visible = false;
                PnlSalida.Visible = false;
                PnlAjustePositivo.Visible = false;
                PnlAjusteNegativo.Visible = true;
            }
        }

        #region entrada de productos
        public void buildListOrdenCompra()
        {
            ddlCompras.DataSource = dcom.getCompras();
            ddlCompras.DataTextField = "IdCompras";
            ddlCompras.DataValueField = "IdCompras";
            ddlCompras.DataBind();
            ddlCompras.Items.Insert(0, new ListItem("-Seleccionar Codigo de la Orden-", "0"));

        }
        protected void dgvProductosList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductosList.PageIndex = e.NewPageIndex;
        }

        protected void dgvProductosList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
        protected void itemSelected(object sender, EventArgs e)
        {
            try
            {
                int idCompras = Convert.ToInt32(ddlCompras.SelectedValue);
                dgvProductosList.DataSource = dcom.ItemxCompras(idCompras);
                dgvProductosList.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void insertItems(object sender, EventArgs e)
        {
            try
            {
                int a = 0;
                foreach (GridViewRow row in dgvProductosList.Rows)
                {
                    CheckBox check = (CheckBox)(row.Cells[7].FindControl("CheckBox1"));

                    if (check.Checked)
                    {
                    }

                    else
                    {
                        a++;
                    }
                }
                int b = Convert.ToInt32(ddlCompras.SelectedValue);
                if (a == 0)
                {
                    DataTable dv = dcom.ItemxCompras(b);
                    foreach (DataRow row in dv.Rows)
                    {
                        int iditem = Convert.ToInt32(row[1].ToString());
                       int cantidad = Convert.ToInt32( row[7].ToString());
                        dcom.ActualizarStockxMovimiento(Convert.ToString(b), iditem, cantidad);
                    }
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','movimiento Realizado y Stock Actualizado','success')", true);
                }
                else
                {
                    throw new Exception("El Pedido se encuentra Incompleto");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }
        #endregion

        #region Salida

        #endregion

        #region Ajuste postivo
        protected void gvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvItems.PageIndex = e.NewPageIndex;
        }
        protected void gvItems_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "verItems")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    int iditem = Convert.ToInt32(dgvItems.Rows[index].Cells[0].Text);
                    Session["iditem"] = iditem;
                    Panel1.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void buildListMarca()
        {
            ddlMarca.DataSource = obj.GetMarcasCreadas();
            ddlMarca.DataTextField = "Nombre";
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
        protected void buscaAP(object sender, EventArgs e)
        {
            int idMarca = Convert.ToInt32(ddlMarca.SelectedValue);
            int idTipo = Convert.ToInt32(ddlTipo.SelectedValue);
            dgvItems.DataSource = obj.getItemsByNombre(Text7.Value, idMarca, idTipo);
            dgvItems.DataBind();
            Session["Nombre"] = Convert.ToString(Text7.Value);

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
        
        protected void AceptarMov_click(object sender, EventArgs e)
        {
            DataTable dv = dmov.ActualizarStockxAjustePositivo(Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(Session["iditem"]));
            txtnewStock.Text = Convert.ToString(dv.Rows[0]["stock"].ToString());
            txtCantidad.Enabled = false;
            int a = Convert.ToInt32(Session["IdUsuario"]);
            DataTable dv2 = dmov.TrabajadorXUsuario(a);
            string w= Convert.ToString(dv2.Rows[0]["Nombres"].ToString());
            string b= Convert.ToString(dv2.Rows[0]["ApellidosPaterno"].ToString());
            string c=Convert.ToString(dv2.Rows[0]["ApellidosMaternos"].ToString());
            txtRes.Text =""+w+" "+b+" "+c ;
            txtAuto.Text = "" + w + " " + b + " " + c;
            dmov.InsertarMoviminento(Convert.ToInt32(txtCantidad), txtRes.Text, txtObservacion.Text, txtAuto.Text, Convert.ToInt32(ddlTipoMov.SelectedValue), Convert.ToInt32(Session["iditem"]));
        }
        protected void EliminarMov_click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Ajuste Negativo
        protected void gvItemsn_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvItemsn.PageIndex = e.NewPageIndex;
        }
        protected void gvItemsn_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "verItems")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    int iditem = Convert.ToInt32(dgvItemsn.Rows[index].Cells[0].Text);
                    Session["iditem"] = iditem;
                    Panel2.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void buildListMarcan()
        {
            ddlMarcan.DataSource = obj.GetMarcasCreadas();
            ddlMarcan.DataTextField = "Nombre";
            ddlMarcan.DataValueField = "IdMarca";
            ddlMarcan.DataBind();
            ddlMarcan.Items.Insert(0, new ListItem("Selec. Marca", "0"));
        }

        public void buildListTipon()
        {
            ddlTipon.DataSource = obj.GetTiposCreados();
            ddlTipon.DataTextField = "Nombre";
            ddlTipon.DataValueField = "IdTipo";
            ddlTipon.DataBind();
            ddlTipon.Items.Insert(0, new ListItem("Selec. Tipo", "0"));
        }
        protected void buscaAPn(object sender, EventArgs e)
        {
            int idMarca = Convert.ToInt32(ddlMarcan.SelectedValue);
            int idTipo = Convert.ToInt32(ddlTipon.SelectedValue);
            dgvItemsn.DataSource = obj.getItemsByNombre(Text7n.Value, idMarca, idTipo);
            dgvItemsn.DataBind();
            Session["Nombre"] = Convert.ToString(Text7n.Value);

        }
        protected void marcaSelectedn(object sender, EventArgs e)
        {
            int idMarca = Convert.ToInt32(ddlMarcan.SelectedValue);
            if (idMarca != 0)
            {
                dgvItemsn.DataSource = obj.getItemsByMarca(idMarca);
                dgvItemsn.DataBind();
            }
            else
            {
                dgvItemsn.DataSource = null;
                dgvItemsn.DataBind();
            }
        }

        protected void tipoSelectedn(object sender, EventArgs e)
        {
            int idTipo = Convert.ToInt32(ddlTipon.SelectedValue);
            if (idTipo != 0)
            {
                dgvItemsn.DataSource = obj.getItemsByMarca(idTipo);
                dgvItemsn.DataBind();
            }
            else
            {
                dgvItemsn.DataSource = null;
                dgvItemsn.DataBind();
            }
        }

        protected void AceptarnMov_Click(object sender, EventArgs e)
        {
            DataTable dv = dmov.ActualizarStockxAjusteNegativo(Convert.ToInt32(txtCantidadn.Text), Convert.ToInt32(Session["iditem"]));
            txtnewStockn.Text = Convert.ToString(dv.Rows[0]["stock"].ToString());
            txtCantidadn.Enabled = false;
            int a = Convert.ToInt32(Session["IdUsuario"]);
            DataTable dv2 = dmov.TrabajadorXUsuario(a);
            string w = Convert.ToString(dv2.Rows[0]["Nombres"].ToString());
            string b = Convert.ToString(dv2.Rows[0]["ApellidosPaterno"].ToString());
            string c = Convert.ToString(dv2.Rows[0]["ApellidosMaternos"].ToString());
            txtResn.Text = "" + w + " " + b + " " + c;
            txtAuton.Text = "" + w + " " + b + " " + c;
            dmov.InsertarMoviminentoneg(Convert.ToInt32(txtCantidadn.Text), txtResn.Text, txtObservacionn.Text, Convert.ToInt32(ddlTipoMov.SelectedValue), Convert.ToInt32(Session["iditem"]));
            
        }

        protected void EliminarnMov_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}