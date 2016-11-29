<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginn.aspx.cs" Inherits="Indexx.Loginn" %>

<!DOCTYPE html>

<html lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>
        CentroFarma Plus | 
    </title>

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
                    <form id="form1" runat="server">
                        <h1>Bienvenido</h1>
                        <div>
                            <div class="Login_form">
                                <div>
                                    <asp:TextBox ID="TextBox1" runat="Server" placeHolder="Usuario" class="form-control"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:TextBox ID="TextBox" runat="Server" placeHolder="Contraseña" TextMode="Password" class="form-control"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:Button ID="Button" runat="Server" Text="Iniciar Sesión" class="btn btn-default submit" OnClick="Button_Click"></asp:Button>
                                    <a class="reset_pass" href="#">¿Olvidaste tu contraseña?</a>
                                </div>
                            </div>
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
        </div>
    </div>
        
</body>
                    
</html>
