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
                    int idAlmacen = obj.getAlmacenByVendedor(1);
                    int idAlmacenItem = Convert.ToInt32(dgvItems.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdAlmacen"].ToString());
                    if (idAlmacen != idAlmacenItem)
                    {
                        throw new Exception("Solo puedes seleccionar items de tu almacén");
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
            //ddlMarca.DataSource     = obj.GetMarcasCreadas();
            ddlMarca.DataTextField  = "Nombre";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Selec. Marca", "0"));
        }

        public void buildListTipo()
        {
            //ddlTipo.DataSource = obj.GetTiposCreados();
            ddlTipo.DataTextField = "Nombre";
            ddlTipo.DataValueField = "IdTipo";
            ddlTipo.DataBind();
            ddlTipo.Items.Insert(0, new ListItem("Selec. Tipo", "0"));
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
                        int idAlmacen = obj.getAlmacenByVendedor(1);
                        int salida = obj.updateCantidad(Convert.ToInt32(Session["venta"]), idAlmacen, idItem, Convert.ToInt32(cantidadVenta));
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
                    int idAlmacen = obj.getAlmacenByVendedor(1);
                    DataTable ventaXItem = obj.deleteItemxVenta(Convert.ToInt32(Session["venta"]), idAlmacen, idItem);
                    dgvCarrito.DataSource = ventaXItem;
                    dgvCarrito.DataBind();
                    if (ventaXItem.Rows.Count == 0)
                    {
                        obj.deleteVenta(Convert.ToInt32(Session["venta"]), idAlmacen);
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

                    int idAlmacenVenta = Convert.ToInt32(dgvVentas.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdAlmacen"].ToString());
                    int idAlmacen = obj.getAlmacenByVendedor(1);
                    if (idAlmacen != idAlmacenVenta)
                    {
                        throw new Exception("Solo puedes eliminar ventas de tu almacén");
                    }
                    obj.deleteVenta(idVenta,idAlmacen);
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
                    int idAlmacenVenta = Convert.ToInt32(dgvVentas.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdAlmacen"].ToString());
                    int idAlmacen = obj.getAlmacenByVendedor(1);
                    if (idAlmacen != idAlmacenVenta)
                    {
                        throw new Exception("Solo puedes editar ventas de tu almacén");
                    }
                    Session["venta"] = idVenta;
                    getItemsByVenta(idVenta);
                    tituloVenta.InnerText = "Venta " + Session["venta"];
                }
                else if (e.CommandName == "finalizarVenta")
                {
                    int idAlmacenVenta = Convert.ToInt32(dgvVentas.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdAlmacen"].ToString());
                    int idAlmacen = obj.getAlmacenByVendedor(1);
                    if (idAlmacen != idAlmacenVenta)
                    {
                        throw new Exception("Solo puedes finalizar ventas de tu almacén");
                    }
                    decimal precioTotal = Convert.ToDecimal(dgvVentas.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["PrecioTotal"].ToString());
                    if (precioTotal > 0)
                    {
                        FinalizarVenta(idVenta);
                    }
                    else
                    {
                        throw new Exception("El precio total no puede ser igual a 0");
                    }
                }
                else if (e.CommandName == "generarPDF")
                {
                    int idAlmacenVenta = Convert.ToInt32(dgvVentas.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdAlmacen"].ToString());
                    int idAlmacen = obj.getAlmacenByVendedor(1);
                    if (idAlmacen != idAlmacenVenta)
                    {
                        throw new Exception("Solo puedes seleccionar ventas de tu almacén");
                    }
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
            dt = obj.getItemsByVentaPDF(idVenta);

            for (int rows = 0; rows < dt.Rows.Count; rows++)
            {
                for (int column = 0; column < dt.Columns.Count; column++)
                {
                    {
                        if (column == 0)
                        {
                            if (rows < 9)
                            {
                                stamp.AcroFields.SetField("txtCant" + (rows + 1), dt.Rows[rows][column].ToString());
                            }
                        }
                        else if (column == 1)
                        {
                            if (rows < 9)
                            {
                                stamp.AcroFields.SetField("txtDesc" + (rows + 1), dt.Rows[rows][column].ToString());
                            }
                        }
                        else if (column == 2)
                        {
                            if (rows < 9)
                            {
                                stamp.AcroFields.SetField("txtPUnitario" + (rows + 1), dt.Rows[rows][column].ToString());
                            }
                        }

                        else if (column == 3)
                        {
                            if (rows < 9)
                            {
                                stamp.AcroFields.SetField("txtImporte" + (rows + 1), dt.Rows[rows][column].ToString());
                            }
                        }
                    }
                }
            }
            stamp.FormFlattening = true;
            stamp.Close();

            this.textNombre.Text = "";
            this.textDni.Text = "";
            this.textRuc.Text = "";
            this.textDirec.Text = "";
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