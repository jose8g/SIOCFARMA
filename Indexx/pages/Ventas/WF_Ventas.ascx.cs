﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAO;

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
            }
        }


        protected void registrar_Click(object sender, EventArgs e)
        {
            //obj.registrar_venta(Text1.Value, DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), Text3.Value, Text4.Value, Text5.Value, Text6.Value);
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
                if (e.CommandName == "agregarItems")
                {
                    int idItem = Convert.ToInt32(dgvItems.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdItem"].ToString());
                    /*obj.addArrayVenta(idItem.ToString());
                    
                    Text8.Value = idItem.ToString();
                    dgvItems.Visible = true;*/

                    List<string> carrito = (List<string>)Session["venta"];
                    carrito.Add(idItem.ToString());
                    
                    DataTable table = ConvertListToDataTable(carrito);
                    dgvCarrito.DataSource = table;
                    dgvCarrito.DataBind();
                    dgvCarrito.Visible = true;
                    Session["venta"] = carrito;
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
        }
        protected void itemSelected(object sender, EventArgs e)
        {
            int idMarca = ddlMarca.SelectedIndex;
            dgvItems.DataSource = obj.getItemsByMarca(idMarca);
            dgvItems.DataBind();
        }

        public void agregarProducto()
        {
            
            /*int cantidad = 0;
            if (carrito != null)
            {
                foreach (var item in carrito)
                {
                    cantidad += item.cantidad;
                }
            }
            lblCantidadCarrito.Text = "Ahora en tu carrito tienes (" + cantidad.ToString() + ") productos";*/
        }

        protected void gvItems2_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "agregarItems")
                {
                   
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        static DataTable ConvertListToDataTable(List<string> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }
    }
}