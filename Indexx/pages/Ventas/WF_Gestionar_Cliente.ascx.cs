using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAO;
using System.Collections;
using System.Windows.Forms;

namespace Indexx.pages.Ventas
{
    public partial class WF_Gestionar_Cliente : System.Web.UI.UserControl
    {
        DAO_Venta objV;
        protected void Page_Load(object sender, EventArgs e)
        {
            objV = new DAO_Venta();
            if (!Page.IsPostBack)
            {
            }
        }

        protected void gvCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvClientes.PageIndex = e.NewPageIndex;
        }

        protected void deleteCliente(object sender, EventArgs e)
        {

        }

        protected void insertCliente(object sender, EventArgs e)
        {
            string Nombre = Convert.ToString(NombreCliente.Value);
            string Direccion = Convert.ToString(DireccionCliente.Value);
            int Telefono = Convert.ToInt32(TelefonoCliente.Value);
            string Correo = Convert.ToString(CorreoCliente.Value);
            int DNI = Convert.ToInt32(Dni.Value);
            string empresa = Convert.ToString(Empresa.Value);
            dgvClientes.DataSource = objV.RegistrarCliente(Nombre, Direccion, Telefono, Correo, DNI, empresa);
            dgvClientes.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se inserto correctamente el cliente','success')", true);
        }

        protected void gvClientes_RowComand(object sender, GridViewCommandEventArgs e)
        {
            
        }
    }
}