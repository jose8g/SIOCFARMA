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
                int IdAlmacen = Convert.ToInt32(dgvAlmacenes.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdAlmacen"].ToString());
                if (IdAlmacen.ToString() == null)
                {
                    throw new Exception("Acción no permitida");
                }
                if (e.CommandName == "editAlmacen")
                {
                    Session["IdAlmacen"] = IdAlmacen;
                    DataTable dtAlmacen = new DataTable();
                    dtAlmacen = obj.getDetalleAlmacen(IdAlmacen);
                    textDirec.ReadOnly = false;
                    txtResp.ReadOnly = false;
                    txtCapac.ReadOnly = false;
                    textDirec2.ReadOnly = true;
                    txtResp2.ReadOnly = true;
                    txtCapac2.ReadOnly = true;
                    textDirec.Text = dtAlmacen.Rows[0][0].ToString();
                    txtResp.Text = dtAlmacen.Rows[0][1].ToString();
                    txtCapac.Text = dtAlmacen.Rows[0][2].ToString();
                    textDirec2.Text = "";
                    txtResp2.Text = "";
                    txtCapac2.Text = "";
                }
                else if (e.CommandName == "deleteAlmacen")
                {
                    obj.eliminarAlmacen(IdAlmacen);
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
                    buildTableAlmacenes();
                    Session["IdAlmacen"] = null;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }

        protected void registrarAlmacen(object sender, EventArgs e)
        {
            obj.registrarAlmacen(textDirec2.Text, txtResp2.Text, Convert.ToInt32(txtCapac2.Text));
            buildTableAlmacenes();
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
            Session["IdAlmacen"] = null;
        }

        protected void habilitarNuevoAlmacen(object sender, EventArgs e)
        {
            //obj.registrarAlmacen(textDirec2.Text, txtResp2.Text, Convert.ToInt32(txtCapac2.Text));
            //buildTableAlmacenes();
            textDirec.ReadOnly = true;
            txtResp.ReadOnly = true;
            txtCapac.ReadOnly = true;
            textDirec2.ReadOnly = false;
            txtResp2.ReadOnly = false;
            txtCapac2.ReadOnly = false;
            textDirec.Text = "";
            txtResp.Text = "";
            txtCapac.Text = "";
            textDirec2.Text = "";
            txtResp2.Text = "";
            txtCapac2.Text = "";
            Session["IdAlmacen"] = null;
        }

        protected void editarDatosAlmacen(object sender, EventArgs e)
        {

            if(Session["IdAlmacen"] != null){
                obj.editarDatosAlmacen(Convert.ToInt32(Session["IdAlmacen"]), textDirec.Text, txtResp.Text, Convert.ToInt32(txtCapac.Text));
                buildTableAlmacenes();
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
                Session["IdAlmacen"] = null;
            }
        }
    }
}