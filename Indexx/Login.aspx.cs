using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using CONTROL;

namespace Indexx
{
    public partial class Login : System.Web.UI.Page
    {
        E_Usuario objUsuarioBE = new E_Usuario();
        C_Usuario objUsuarioBL = new C_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {

         }
protected void btn_InicioSesion_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    if (txt_usuario.Text.Trim() == "" && txt_pass.Text.Trim() == "")
        //    {
        //        Response.Write("<script language=javascript>alert('Falta ingresar el nombre de Usuario y contraseña')</script>");
        //        txt_usuario.Focus();
        //        return;
        //    }


        //    if (txt_usuario.Text.Trim() == "")
        //    {
        //        Response.Write("<script language=javascript>alert('Falta ingresar el nombre de Usuario')</script>");
        //        txt_usuario.Focus();
        //        return;
        //    }

        //    if (txt_pass.Text.Trim() == "")
        //    {
        //        Response.Write("<script language=javascript>alert('Falta ingresar la contraseña')</script>");
        //        txt_pass.Focus();
        //        return;
        //    }

        //    if (txt_usuario.Text.Trim() != "" && txt_pass.Text.Trim() != "")
        //    {
        //        String existe = "";

        //        objUsuarioBE.Usuario = txt_usuario.Text.Trim();
        //        objUsuarioBE.Password = Convert.ToInt32(txt_pass.Text.Trim());

        //        existe = objUsuarioBL.ConsultarUsuario(objUsuarioBE);

        //        if (existe.Equals("1"))
        //        {
        //            string[] datoUsuario = new string[2];                    

        //            objUsuarioBL.IniciarSesion(objUsuarioBE, datoUsuario);

        //            if (!datoUsuario[0].ToString().Equals(""))
        //            {
        //                if (datoUsuario[0].ToString() == "1")
        //                {
        //                    Session["usuario"] = txt_usuario.Text.ToString();
        //                    Session["usuarioRol"] = datoUsuario[0].ToString();
        //                    Session["idUsuario"] = datoUsuario[1].ToString();
        //                    Response.Redirect("WF_Administrador.aspx");
        //                }
        //                if (datoUsuario[0].ToString() == "2")
        //                {
        //                    Session["usuario"] = txt_usuario.Text.ToString();
        //                    Session["usuarioRol"] = datoUsuario[0].ToString();
        //                    Session["idUsuario"] = datoUsuario[1].ToString();
        //                    Response.Redirect("WF_JefeDeInventario.aspx");
        //                }
        //                if (datoUsuario[0].ToString() == "3")
        //                {
        //                    Session["usuario"] = txt_usuario.Text.ToString();
        //                    Session["usuarioRol"] = datoUsuario[0].ToString();
        //                    Session["idUsuario"] = datoUsuario[1].ToString();
        //                    Response.Redirect("Principal_Vendedor.aspx");
        //                }

        //            }
        //            else
        //            {

        //                Response.Write("<script language=javascript>alert('El usuario no existe o contraseña invalida.')</script>");
        //                txt_usuario.Focus();
        //                return;
        //            }


        //        }
        //        else
        //        {

        //            Response.Write("<script language=javascript>alert('El usuario no existe o contraseña invalida.')</script>");
        //            txt_usuario.Focus();
        //            return;
        //        }
        //    }
        //}

        //catch (Exception ex)
        //{
        //    Response.Write("<script language=javascript>alert('Error: " + ex.Message.ToString() + "')</script>" + ex.Message);
        //    return;
        //    //txtUsuario.Text = "";
        //    //txtUsuario.Focus();
        //}
    }
    }
}