using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAO;
using System.Collections;

namespace Indexx.pages.Estadisticos
{
    public partial class WF_Reportes : System.Web.UI.UserControl
    {
        DAO.DAO_Reportes daoReportes;
        protected void Page_Load(object sender, EventArgs e)
        {
            daoReportes = new DAO.DAO_Reportes();
            if (!Page.IsPostBack)
            {
                //VENTAS POR VENDEDOR
                DataTable data = daoReportes.ventasXVendedor(null, null);
                buildSeriesChartVendedor(data);

                //ITEMS MAS VENDIDOS
                DataTable data1 = daoReportes.itemsMasVendidos(null, null);
                buildSeriesChartItems(data1);
            }
        }

        public void buildSeriesChartVendedor(DataTable data)
        {            
            ArrayList arrData1 = new ArrayList();
            ArrayList arrData2 = new ArrayList();
            ArrayList arrCate  = new ArrayList();
            foreach (DataRow row in data.Rows)
            {
                arrData1.Add(row["CantItems"]);
                arrData2.Add(row["CantVentas"]);
                arrCate.Add(row["Nombre"]);
            }
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string jsonCate  = oSerializer.Serialize(arrCate);
            string jsonData1 = oSerializer.Serialize(arrData1);
            string jsonData2 = oSerializer.Serialize(arrData2);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "initBarChart(\'" + jsonData1 + "\',\'" + jsonData2 + "\', \'" + jsonCate + "\');", true);
        }
        public void buildSeriesChartItems(DataTable data)
        {
            ArrayList arrData1 = new ArrayList();
            ArrayList arrCate = new ArrayList();
            foreach (DataRow row in data.Rows)
            {
                arrData1.Add(row["total"]);
                arrCate.Add(row["Nombre"]);
            }
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string jsonCate = oSerializer.Serialize(arrCate);
            string jsonData1 = oSerializer.Serialize(arrData1);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text1", "initBarChart2(\'" + jsonData1 + "\', \'" + jsonCate + "\')", true);
        }

        protected void getGraficosByFiltro(object sender, EventArgs e)
        {
            try
            {
                String fecInicio = this.fecInicio.Text;
                String fecFin    = this.fecFin.Text;
                if (fecFin == "")
                {
                    fecFin = null;
                }
                if (fecInicio == "")
                {
                    fecInicio = null;
                }
                //VENTAS POR VENDEDOR
                DataTable data = daoReportes.ventasXVendedor(fecInicio, fecFin);
                buildSeriesChartVendedor(data);

                //ITEMS MAS VENDIDOS
                DataTable data1 = daoReportes.itemsMasVendidos(fecInicio, fecFin);
                buildSeriesChartItems(data1);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

    }
}