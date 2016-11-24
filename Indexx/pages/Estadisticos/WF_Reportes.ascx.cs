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
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        DAO.DAO_Reportes daoReportes;
        protected void Page_Load(object sender, EventArgs e)
        {
            daoReportes = new DAO.DAO_Reportes();
            DataTable data = daoReportes.ventasXVendedor();
            buildSeriesChart(data);
        }

        public void buildSeriesChart(DataTable data)
        {            
            ArrayList arrData1 = new ArrayList();
            ArrayList arrData2 = new ArrayList();
            ArrayList arrCate  = new ArrayList();
            //arrCate.Add("Prueba");
            //arrCate.Add("Prueba2");
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
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "initBarChart(\'" + jsonData1 + "\',\'" + jsonData2 + "\', \'" + jsonCate + "\')", true);
        }

    }
}