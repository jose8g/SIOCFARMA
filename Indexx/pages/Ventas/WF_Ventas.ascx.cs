using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAO;
using System.Collections;
using itexS = iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Diagnostics;
using System.Drawing;
  

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
                Session["ventaBoleta"] = null;
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
            Session["Nombre"] = Convert.ToString(Text7.Value);
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
                if (idVenta.ToString() == null)
                {
                    throw new Exception("Acción no permitida");
                }
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
                        //Session["ventaFinalizar"] = idVenta;
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "mostrar()", true);
                        FinalizarVenta(idVenta);
                        //int salida  = obj.finalizarVenta(idVenta);
                        //if (salida == 1)
                        //{
                        //    buildTableVentasPendientes();
                        //    if (Convert.ToInt32(Session["venta"]) == idVenta)
                        //    {
                        //        Session["venta"] = null;
                        //        dgvCarrito.DataSource = null;
                        //        dgvCarrito.DataBind();
                        //        tituloVenta.InnerText = "";
                        //    }
                        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se realizó correctamente la venta','success')", true);
                        //}
                        //else if(salida == 0)
                        //{
                        //    throw new Exception("Un producto de la lista tiene cantidad igual a 0");
                        //}
                    }
                    else
                    {
                        throw new Exception("El precio total no puede ser igual a 0");
                    }
                }
                else if (e.CommandName == "generarPDF")
                {
                    decimal precioTotal = Convert.ToDecimal(dgvVentas.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["PrecioTotal"].ToString());
                    if (precioTotal > 0)
                    {

                        Session["ventaBoleta"] = idVenta;
                        if (idVenta.ToString() == null)
                        {
                            throw new Exception("Acción no permitida");
                        }
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "mostrar()", true);
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
        public void btnPdf_Click(object sender, EventArgs e)
        {
            
            try{
                if (Session["ventaBoleta"].ToString() == null)
                {
                    throw new Exception("Acción no permitida");
                }
                Response.Clear();
                Response.ContentType = "boletaFarma/pdf";
                Response.AddHeader("content-disposition", "attachment; filename=boletaFarma.pdf");
                FillPDF(Server.MapPath("pdf/boletaFarma.pdf"), Response.OutputStream, Convert.ToInt32(Session["ventaBoleta"]));
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "cerrar()", true);
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.Message + "')</script>");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }

        public void FinalizarVenta(int idVenta)
        {
            if (Convert.ToString(idVenta) == null)
            {
                throw new Exception("Acción no permitida");
            }
            int salida = obj.finalizarVenta(idVenta);
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
            else if (salida == 0)
            {
                throw new Exception("Un producto de la lista tiene cantidad igual a 0");
            }
        }

        public void FillPDF(string templateFile, Stream stream, int idVenta)
        {
            PdfReader reader = new PdfReader(templateFile);
            PdfStamper stamp = new PdfStamper(reader, stream);
            stamp.AcroFields.SetField("txtCliente", this.textNombre.Text);
            stamp.AcroFields.SetField("txtDNI", this.textDni.Text);
            stamp.AcroFields.SetField("txtRuc", this.textRuc.Text);
            stamp.AcroFields.SetField("txtDirec", this.textDirec.Text);
            System.DateTime moment = DateTime.Today;
            stamp.AcroFields.SetField("txtDia", Convert.ToString(moment.Day));
            stamp.AcroFields.SetField("txtMes", Convert.ToString(moment.Month));
            stamp.AcroFields.SetField("txtYear", Convert.ToString(moment.Year));

            DataTable dtVenta = new DataTable();
            dtVenta = obj.getDetalleVenta(idVenta);
            stamp.AcroFields.SetField("txtPreTotal", dtVenta.Rows[0][0].ToString());
            stamp.AcroFields.SetField("txtTotal", dtVenta.Rows[0][1].ToString());

            DataTable dt = new DataTable();
            dt = obj.getItemsByVenta(idVenta);

            for (int rows = 0; rows < dt.Rows.Count; rows++)
            {
                for (int column = 0; column < dt.Columns.Count; column++)
                {
                    {
                        if (column == 0)
                        {
                            if (rows == 0)
                            {
                                stamp.AcroFields.SetField("txtCant1", dt.Rows[0][column].ToString());
                            }

                            if (rows == 1)
                            {
                                stamp.AcroFields.SetField("txtCant2", dt.Rows[1][column].ToString());
                            }

                            if (rows == 2)
                            {
                                stamp.AcroFields.SetField("txtCant3", dt.Rows[2][column].ToString());
                            }

                            if (rows == 3)
                            {
                                stamp.AcroFields.SetField("txtCant4", dt.Rows[3][column].ToString());
                            }
                            if (rows == 4)
                            {
                                stamp.AcroFields.SetField("txtCant5", dt.Rows[4][column].ToString());
                            }

                            if (rows == 5)
                            {
                                stamp.AcroFields.SetField("txtCant6", dt.Rows[5][column].ToString());
                            }

                            if (rows == 6)
                            {
                                stamp.AcroFields.SetField("txtCant7", dt.Rows[6][column].ToString());
                            }

                            if (rows == 7)
                            {
                                stamp.AcroFields.SetField("txtCant8", dt.Rows[7][column].ToString());
                            }
                            if (rows == 8)
                            {
                                stamp.AcroFields.SetField("txtCant9", dt.Rows[8][column].ToString());
                            }

                        }
                        else if (column == 1)
                        {
                            if (rows == 0)
                            {
                                stamp.AcroFields.SetField("txtDesc1", dt.Rows[0][column].ToString());
                            }
                            if (rows == 1)
                            {
                                stamp.AcroFields.SetField("txtDesc2", dt.Rows[1][column].ToString());

                            }
                            if (rows == 2)
                            {
                                stamp.AcroFields.SetField("txtDesc3", dt.Rows[2][column].ToString());

                            }
                            if (rows == 3)
                            {
                                stamp.AcroFields.SetField("txtDesc4", dt.Rows[3][column].ToString());
                            }
                            if (rows == 4)
                            {
                                stamp.AcroFields.SetField("txtDesc5", dt.Rows[4][column].ToString());
                            }
                            if (rows == 5)
                            {
                                stamp.AcroFields.SetField("txtDesc6", dt.Rows[5][column].ToString());

                            }
                            if (rows == 6)
                            {
                                stamp.AcroFields.SetField("txtDesc7", dt.Rows[6][column].ToString());

                            }
                            if (rows == 7)
                            {
                                stamp.AcroFields.SetField("txtDesc8", dt.Rows[7][column].ToString());
                            }
                            if (rows == 8)
                            {
                                stamp.AcroFields.SetField("txtDesc9", dt.Rows[8][column].ToString());

                            }
                        }
                        else if (column == 2)
                        {
                            if (rows == 0)
                            {
                                stamp.AcroFields.SetField("txtPUnitario1", dt.Rows[0][column].ToString());
                            }
                            if (rows == 1)
                            {
                                stamp.AcroFields.SetField("txtPUnitario2", dt.Rows[1][column].ToString());
                            }
                            if (rows == 2)
                            {
                                stamp.AcroFields.SetField("txtPUnitario3", dt.Rows[2][column].ToString());

                            }
                            if (rows == 3)
                            {
                                stamp.AcroFields.SetField("txtPUnitario4", dt.Rows[3][column].ToString());
                            }
                            if (rows == 4)
                            {
                                stamp.AcroFields.SetField("txtPUnitario5", dt.Rows[4][column].ToString());
                            }
                            if (rows == 5)
                            {
                                stamp.AcroFields.SetField("txtPUnitario6", dt.Rows[5][column].ToString());
                            }
                            if (rows == 6)
                            {
                                stamp.AcroFields.SetField("txtPUnitario7", dt.Rows[6][column].ToString());

                            }
                            if (rows == 7)
                            {
                                stamp.AcroFields.SetField("txtPUnitario8", dt.Rows[7][column].ToString());
                            }
                            if (rows == 8)
                            {
                                stamp.AcroFields.SetField("txtPUnitario9", dt.Rows[8][column].ToString());
                            }
                        }

                        else if (column == 3)
                        {
                            if (rows == 0)
                            {
                                stamp.AcroFields.SetField("txtImporte1", dt.Rows[0][column].ToString());
                            }
                            if (rows == 1)
                            {
                                stamp.AcroFields.SetField("txtImporte2", dt.Rows[1][column].ToString());
                            }
                            if (rows == 2)
                            {
                                stamp.AcroFields.SetField("txtImporte3", dt.Rows[2][column].ToString());
                            }
                            if (rows == 3)
                            {
                                stamp.AcroFields.SetField("txtImporte4", dt.Rows[3][column].ToString());
                            }
                            if (rows == 4)
                            {
                                stamp.AcroFields.SetField("txtImporte5", dt.Rows[4][column].ToString());
                            }
                            if (rows == 5)
                            {
                                stamp.AcroFields.SetField("txtImporte6", dt.Rows[5][column].ToString());
                            }
                            if (rows == 6)
                            {
                                stamp.AcroFields.SetField("txtImporte7", dt.Rows[6][column].ToString());
                            }
                            if (rows == 7)
                            {
                                stamp.AcroFields.SetField("txtImporte8", dt.Rows[7][column].ToString());
                            }
                            if (rows == 8)
                            {
                                stamp.AcroFields.SetField("txtImporte9", dt.Rows[8][column].ToString());
                            }
                        }
                    }
                }
            }
            stamp.FormFlattening = true;
            stamp.Close();
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