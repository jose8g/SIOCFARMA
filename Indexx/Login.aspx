<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Indexx.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>CentroFarma Plus | </title>

    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- Animate.css -->
    <link href="https://colorlib.com/polygon/gentelella/css/animate.min.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet">
</head>

<body class="login">
    <div>
        <a class="hiddenanchor" id="signup"></a>
        <a class="hiddenanchor" id="signin"></a>

        <div class="login_wrapper">
            <div class="animate form login_form">
                <section class="login_content">
                    <form>
                        <h1>Bienvenido</h1>
                        <div>
                                    <input type="text" class="form-control" placeholder="Usuario" required="" />
                            <%--<asp:TextBox type="text" ID="txt_usuario" runat="server"></asp:TextBox>--%>
                           <%-- <asp:TextBox ID="txt_usuario" runat="server" Width="304px"  class="form-control"></asp:TextBox>--%>
                        </div>
                        <div>
                                            <input type="password" class="form-control" placeholder="Contraseña" required=""/>
                            <%--<asp:TextBox type="password" ID="txt_pass" runat="server"></asp:TextBox>--%>
                            <%--<asp:TextBox ID="txt_pass" runat="server" class="form-control"></asp:TextBox>--%>

                        </div>
                        <div>
                            <a class="btn btn-default submit" href="WF_Vendedora.aspx" onclick="btn_InicioSesion_Click">Iniciar sesión</a>
                           <%-- <asp:Button ID="btn_InicioSesion" type="submit" runat="server" Text="Iniciar Sesión" OnClick="btn_InicioSesion_Click" />--%>
                            <a class="reset_pass" href="#">¿Olvidaste tu contraseña?</a>
                        </div>

                        <div class="clearfix"></div>

                        <div class="separator">
                            <p class="change_link">
                                New to site?
                  <a href="#signup" class="to_register">Crear cuenta </a>
                            </p>

                            <div class="clearfix"></div>
                            <br />

                            <div>
                                <h1><i class="fa fa-medkit "></i>CentroFarma Plus</h1>
                                <p>©2016 All Rights Reserved. CentroFarma Plus </p>
                            </div>
                        </div>
                    </form>
                </section>
            </div>

            <div id="register" class="animate form registration_form">
                <section class="login_content">
                    <form>
                        <h1>Crear cuenta</h1>
                        <div>
                            <input type="text" class="form-control" placeholder="Usuario" required="" />
                        </div>
                        <div>
                            <input type="email" class="form-control" placeholder="Email" required="" />
                        </div>
                        <div>
                            <input type="password" class="form-control" placeholder="Contraseña" required="" />
                        </div>
                        <div>
                            <a class="btn btn-default submit" href="WF_Vendedora.aspx">Iniciar Sesión</a>
                        </div>

                        <div class="clearfix"></div>

                        <div class="separator">
                            <p class="change_link">
                                ¿Ya eres miembro?
                  <a href="#signin" class="to_register">Crear </a>
                            </p>

                            <div class="clearfix"></div>
                            <br />

                            <div>
                                <h1><i class="fa fa-medkit"></i>CentroFarma Plus</h1>
                                <p>©2016 All Rights Reserved. CentroFarma Plus </p>
                            </div>
                        </div>
                    </form>
                </section>
            </div>
        </div>
    </div>
</body>
</html>
