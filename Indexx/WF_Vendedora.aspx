<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF_Vendedora.aspx.cs" Inherits="Indexx.Formulario_web1" %>
<%@ Register Src="~/pages/Ventas/WF_Ventas.ascx" TagPrefix="uc1" TagName="WF_Ventas" %>
<%@ Register Src="~/pages/Ventas/WF_Pedidos.ascx" TagPrefix="uc2" TagName="WF_Pedidos" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager> 

    
     <script type="text/javascript" >
         jQuery(document).ready(function () {
             jQuery(".Opcion5").text("Gestionar Venta");
             jQuery(".Opcion6").text("Gestionar Pedidos");

             jQuery(".Opcion5").click(function () {
                 jQuery("#ContentGestionarVenta").fadeIn('slow');
                 jQuery("#ContentGestionarPedido").hide;
             });
             jQuery(".Opcion5").click(function () {
                 jQuery("#ContentGestionarVenta").hide;
                 jQuery("#ContentGestionarPedido").fadeIn('slow');
             });
         });
	</script>

    <div id="ContentGestionarVenta" style="display: block;">
        <uc1:WF_Ventas runat="server" ID="WF_Ventas" />
    </div>
        <div id="ContentGestionarPedido" style="display: block;">
        <uc2:WF_Pedidos runat="server" id="WF_Pedidos" />
    </div>
    </form>
</asp:Content>
