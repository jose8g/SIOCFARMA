using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CONTROL;
using DAO;
using Entidad;
using System.Data;
using System.Data.SqlClient;

namespace Indexx.pages.Adquisicion
{
    public partial class WF_GestionarMarca : System.Web.UI.UserControl
    {
        DAO_Marca obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new DAO.DAO_Marca();
            if (!Page.IsPostBack)
            {
                buildListMarca();
            }
        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            buildListMarca();
        }

        public void buildListMarca()
        {
            ddlMarca.DataSource     = obj.GetMarcasCreadas();
            ddlMarca.DataTextField  = "Nombre";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();
        }
    }
}