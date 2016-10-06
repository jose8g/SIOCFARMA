<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF_JefeDeLogistica.aspx.cs" Inherits="Indexx.Formulario_web15" %>

<%@ Register Src="~/pages/Adquisicion/WF_GestionarProducto.ascx" TagPrefix="uc1" TagName="WF_GestionarProducto" %>
<%@ Register Src="~/pages/Adquisicion/WF_GestionarMarca.ascx" TagPrefix="uc2" TagName="WF_GestionarMarca" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>


        <script type="text/javascript">
            jQuery(document).ready(function () {
                jQuery(".opcion4").text("Gestionar Productos");
                jQuery(".opcion3").text("Gestionar Marca");

                jQuery(".opcion4").click(function () {
                    jQuery("#contentGestionProductos").fadeIn('slow');
                    jQuery("#contentGestionMarca").hide();

                });

                jQuery(".opcion3").click(function () {
                    jQuery("#contentGestionProductos").hide();
                    jQuery("#contentGestionMarca").fadeIn('slow');
                });

                jQuery(".opcion4").click(function () {
                    jQuery("#contentGestionProductos").hide();
                    jQuery("#contentGestionMarca").fadeIn('slow');
                });
            });
        </script>
        <div id="contentGestionProductos" style="display: ;">
            <uc1:WF_GestionarProducto runat="server" ID="WF_GestionarProducto1" />
        </div>
        <div id="contentGestionMarcas" style="display: ;">
            <uc2:WF_GestionarMarca runat="server" ID="WF_GestionarMarca" />
        </div>
    </form>
</asp:Content>
