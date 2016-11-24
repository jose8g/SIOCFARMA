using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using CONTROL;
using DAO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Indexx.pages.Seguridad
{
    public partial class WF_AdministrarProveedores : System.Web.UI.UserControl
    {
        E_Proveedor objE_Prov = new E_Proveedor();
        Boolean estad;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                MostrarProveedor();
            }
        }

        protected void dgvProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProveedores.PageIndex = e.NewPageIndex;
        }

        protected void dgvProveedores_RowComand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Editar")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    int idProveedor = Convert.ToInt32(dgvProveedores.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdProveedor"].ToString());
                    Session["proveedor"] = idProveedor;

                    txtNombrepopup.Text = dgvProveedores.Rows[index].Cells[2].Text;
                    txtDireccionpopup.Text = dgvProveedores.Rows[index].Cells[3].Text;
                    txtTelefonopopup.Text = dgvProveedores.Rows[index].Cells[4].Text;
                    txtRucpopup.Text = dgvProveedores.Rows[index].Cells[5].Text;
                    txtCorreopopup.Text = dgvProveedores.Rows[index].Cells[6].Text;
                    txtResponsablepopup.Text = dgvProveedores.Rows[index].Cells[7].Text;

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "cliclBtnShowPopup()", true);
                }
                else if (e.CommandName == "Eliminar")
                {
                    D_Proveedor objD_Prov = new D_Proveedor();
                    int idProveedor = Convert.ToInt32(dgvProveedores.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["IdProveedor"].ToString());
                    //String idProveedor = (Session["proveedor"] == null) ? null : Session["proveedor"].ToString();

                    if (idProveedor.ToString() == null)
                    {
                        throw new Exception("Acción no permitida");
                    }


                    dgvProveedores.DataSource = objD_Prov.eliminarProveedor(idProveedor);
                    dgvProveedores.DataBind();

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se eliminó correctamente el proveedor','success')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt16(ddlEstado.SelectedValue.ToString());
                estad = Convert.ToBoolean(a);
                
            }
            catch { }
        }

        protected void btnAceptarPopUp_Click(object sender, EventArgs e)
        {
            try
            {
                E_Proveedor objE_Prov = new E_Proveedor();
                D_Proveedor objD_Prov = new D_Proveedor();

                int a = Convert.ToInt16(ddlEstado.SelectedValue.ToString());
                estad = Convert.ToBoolean(a);

                String idProveedor = (Session["proveedor"] == null) ? null : Session["proveedor"].ToString();

                objE_Prov.IdProveedor1 = Convert.ToInt32(Session["proveedor"]);
                objE_Prov.Nombre1 = txtNombrepopup.Text.Trim();
                objE_Prov.Direccion1 = txtDireccionpopup.Text.Trim();
                objE_Prov.Telefono1 = Convert.ToInt32(txtTelefonopopup.Text.Trim());
                objE_Prov.RUC1 = Convert.ToInt64(txtRucpopup.Text.Trim());
                objE_Prov.Correo1 = txtCorreopopup.Text.Trim();
                objE_Prov.Responsable1 = txtResponsablepopup.Text.Trim();
                objE_Prov.Estado1 = estad;

                int telefono = Convert.ToInt32(txtTelefonopopup.Text);
                Int64 ruc = Convert.ToInt64(txtRucpopup.Text.ToString());

                if (txtNombrepopup.Text == "")
                {
                    throw new Exception("Ingrese el nombre");
                }
                if (txtDireccionpopup.Text == "")
                {
                    throw new Exception("Ingrese la dirección");
                }
                if (telefono.ToString() == null)
                {
                    throw new Exception("Ingrese el teléfono");
                }
                if (ruc.ToString() == null)
                {
                    throw new Exception("Ingrese el ruc");
                }
                if (txtCorreopopup.Text == "")
                {
                    throw new Exception("Ingrese el correo");
                }
                if (txtResponsablepopup.Text == "")
                {
                    throw new Exception("Ingrese el responsable");
                }
                if (telefono <= 10000000)
                {
                    throw new Exception("El num. de teléfono debe ser mayor a 7 dígitos");
                }

                if (ruc <= 10000000000)
                {
                    throw new Exception("El num. de RUC debe ser de 11 dígitos");
                }
                if (idProveedor == null)
                {
                    throw new Exception("No se puede registrar el proveedor");
                }

                objD_Prov.actualizarProveedor(objE_Prov);

                dgvProveedores.DataSource = objD_Prov.MostrarProveedor();
                dgvProveedores.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se guardaron los cambios correctamente','success')", true);
                return;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                objE_Prov.Nombre1 = txtNombreProv.Text.Trim();
                objE_Prov.Direccion1 = txtDireccionProv.Text.Trim();
                objE_Prov.Telefono1 = Convert.ToInt32(txtTelefonoProv.Text.Trim());
                objE_Prov.RUC1 = Convert.ToInt64(txtRucProv.Text.Trim());
                objE_Prov.Correo1 = txtCorreoProv.Text.Trim();
                objE_Prov.Responsable1 = txtResponsableProv.Text.Trim();

                int telefono = Convert.ToInt32(txtTelefonoProv.Text);
                Int64 ruc = Convert.ToInt64(txtRucProv.Text);

                if (txtNombreProv.Text == "")
                {
                    throw new Exception("Ingrese el nombre");
                }
                if (txtDireccionProv.Text == "")
                {
                    throw new Exception("Ingrese la dirección");
                }
                if (telefono.ToString() == null)
                {
                    throw new Exception("Ingrese el teléfono");
                }
                if (ruc.ToString() == null)
                {
                    throw new Exception("Ingrese el ruc");
                }
                if (txtCorreoProv.Text == "")
                {
                    throw new Exception("Ingrese el correo");
                }
                if (txtResponsableProv.Text == "")
                {
                    throw new Exception("Ingrese el responsable");
                }
                if (telefono <= 10000000)
                {
                    throw new Exception("El num. de teléfono debe ser mayor a 7 dígitos");
                }

                if (ruc <= 10000000000)
                {
                    throw new Exception("El num. de RUC debe ser de 11 dígitos");
                }

                DAO.D_Proveedor objD_Prov = new D_Proveedor();
                objD_Prov.insertarProveedor(objE_Prov);



                dgvProveedores.DataSource = objD_Prov.MostrarProveedor();
                dgvProveedores.DataBind();
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Ok','Se registró con éxito.','success')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Error','" + ex.Message + "','error')", true);
            }
            
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void MostrarProveedor()
        {
            DAO.D_Proveedor objD_Prov = new D_Proveedor();
            dgvProveedores.DataSource = objD_Prov.MostrarProveedor();
            dgvProveedores.DataBind();
        }

        private void LimpiarCampos()
        {
            txtNombreProv.Text = "";
            txtDireccionProv.Text = "";
            txtTelefonoProv.Text = "";
            txtRucProv.Text = "";
            txtCorreoProv.Text = "";
            txtResponsableProv.Text = "";
            txtNombreProv.Focus();
        }
    }
}