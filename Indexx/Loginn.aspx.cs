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
    public partial class Loginn : System.Web.UI.Page
    {
        E_Usuario objUsuarioBE = new E_Usuario();
        C_Usuario objUsuarioBL = new C_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
      
        try
        {
            if (TextBox1.Text.Trim() == "" && TextBox.Text.Trim() == "")
            {
                Response.Write("<script language=javascript>alert('Falta ingresar el nombre de Usuario y contraseña')</script>");
                TextBox1.Focus();
                return;
            }


            if (TextBox1.Text.Trim() == "")
            {
                Response.Write("<script language=javascript>alert('Falta ingresar el nombre de Usuario')</script>");
                TextBox1.Focus();
                return;
            }

            if (TextBox.Text.Trim() == "")
            {
                Response.Write("<script language=javascript>alert('Falta ingresar la contraseña')</script>");
                TextBox.Focus();
                return;
            }

            if (TextBox1.Text.Trim() != "" && TextBox.Text.Trim() != "")
            {
                String existe = "";

                objUsuarioBE.Usuario = TextBox1.Text.Trim();
                objUsuarioBE.Password = Convert.ToInt32(TextBox.Text.Trim());

                existe = objUsuarioBL.ConsultarUsuario(objUsuarioBE);

                if (existe.Equals("1"))
                {
                    string[] datoUsuario = new string[2];                    

                    objUsuarioBL.IniciarSesion(objUsuarioBE, datoUsuario);

                    if (!datoUsuario[0].ToString().Equals(""))
                    {
                        if (datoUsuario[0].ToString() == "1")
                        {
                            Session["usuario"] = TextBox1.Text.ToString();
                            Session["usuarioRol"] = datoUsuario[0].ToString();
                            Session["idUsuario"] = datoUsuario[1].ToString();
                            Response.Redirect("WF_Administrador.aspx");
                        }
                        if (datoUsuario[0].ToString() == "2")
                        {
                            Session["usuario"] = TextBox1.Text.ToString();
                            Session["usuarioRol"] = datoUsuario[0].ToString();
                            Session["idUsuario"] = datoUsuario[1].ToString();
                            Response.Redirect("WF_Proveedor.aspx");
                        }
                        if (datoUsuario[0].ToString() == "3")
                        {
                            Session["usuario"] = TextBox1.Text.ToString();
                            Session["usuarioRol"] = datoUsuario[0].ToString();
                            Session["idUsuario"] = datoUsuario[1].ToString();
                            Response.Redirect("WF_Almacenero.aspx");
                        }
                        if (datoUsuario[0].ToString() == "4")
                        {
                            Session["usuario"] = TextBox1.Text.ToString();
                            Session["usuarioRol"] = datoUsuario[0].ToString();
                            Session["idUsuario"] = datoUsuario[1].ToString();
                            Response.Redirect("WF_Cliente.aspx");
                        }
                        if (datoUsuario[0].ToString() == "5")
                        {
                            Session["usuario"] = TextBox1.Text.ToString();
                            Session["usuarioRol"] = datoUsuario[0].ToString();
                            Session["idUsuario"] = datoUsuario[1].ToString();
                            Response.Redirect("WF_JefeDeLogistica.aspx");
                        }
                        if (datoUsuario[0].ToString() == "6")
                        {
                            Session["usuario"] = TextBox1.Text.ToString();
                            Session["usuarioRol"] = datoUsuario[0].ToString();
                            Session["idUsuario"] = datoUsuario[1].ToString();
                            Response.Redirect("WF_Vendedora.aspx");
                        }
                        if (datoUsuario[0].ToString() == "7")
                        {
                            Session["usuario"] = TextBox1.Text.ToString();
                            Session["usuarioRol"] = datoUsuario[0].ToString();
                            Session["idUsuario"] = datoUsuario[1].ToString();
                            Response.Redirect("WF_JefeDeInventario.aspx");
                        }
                    }
                    else
                    {

                        Response.Write("<script language=javascript>alert('El usuario no existe o contraseña invalida.')</script>");
                        TextBox1.Focus();
                        return;
                    }


                }
                else
                {

                    Response.Write("<script language=javascript>alert('El usuario no existe o contraseña invalida.')</script>");
                    TextBox1.Focus();
                    return;
                }
            }
        }

        catch (Exception ex)
        {
            Response.Write("<script language=javascript>alert('Error: " + ex.Message.ToString() + "')</script>" + ex.Message);
            return;
            //txtUsuario.Text = "";
            //txtUsuario.Focus();
        }
    }
}
        }
   