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
        protected void Page_Load(object sender, EventArgs e)
        {
            cTiMov = new C_TipoMovimiento();
            cMov = new C_Movimientos();
            if (!IsPostBack)
            {
                buildListTipoMovimiento();
            }
        }

        public void buildListTipoMovimiento()
        {
            ddlTipoMov.DataSource = cTiMov.getTipoMovimiento();
            ddlTipoMov.DataTextField = "Nombre";
            ddlTipoMov.DataValueField = "IdTipoMovimiento";
            ddlTipoMov.DataBind();
        }
        protected void itemSelected(object sender, EventArgs e)
        {
            if (ddlTipoMov.DataValueField == "2")
            {
                PnlEntrada.Visible = true;
            }
            else  if (ddlTipoMov.DataValueField == "3")
            {
                PnlSalida.Visible = true;
            }
            else if (ddlTipoMov.DataValueField == "4")
            {
                PnlAjustePositivo.Visible = true;
            }
            else if (ddlTipoMov.DataValueField == "5")
            {
                PnlAjusteNegativo.Visible = true;
            }
        }
    }
}