using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAO;

namespace Indexx.pages.Seguridad
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        DAO_Almacen obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new DAO_Almacen();
            if (!Page.IsPostBack)
            {
                buildTableAlmacenes();
            }
        }

        public void buildTableAlmacenes()
        {
            dgvAlmacenes.DataSource = obj.getAlmacenes();
            dgvAlmacenes.DataBind();
        }

        protected void gvItems_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "editAlmacen")
                {
                    textDirec.ReadOnly = false;
                    txtResp.ReadOnly = false;
                    txtCapac.ReadOnly = false;
                    textDirec2.ReadOnly = true;
                    txtResp2.ReadOnly = true;
                    txtCapac2.ReadOnly = true;
                    textDirec.Text = "";
                    txtResp.Text = "";
                    txtCapac.Text = "";
                    textDirec2.Text = "";
                    txtResp2.Text = "";
                    txtCapac2.Text = "";
                }
                else if (e.CommandName == "deleteAlmacen")
                {
                    textDirec.ReadOnly = true;
                    txtResp.ReadOnly = true;
                    txtCapac.ReadOnly = true;
                    textDirec2.ReadOnly = true;
                    txtResp2.ReadOnly = true;
                    txtCapac2.ReadOnly = true;
                    textDirec.Text = "";
                    txtResp.Text = "";
                    txtCapac.Text = "";
                    textDirec2.Text = "";
                    txtResp2.Text = "";
                    txtCapac2.Text = "";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }
    }
}