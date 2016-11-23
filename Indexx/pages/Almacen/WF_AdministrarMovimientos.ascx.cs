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


    }
}