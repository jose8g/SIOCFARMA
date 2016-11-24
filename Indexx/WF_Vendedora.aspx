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
             jQuery(".Opcion10").text("Gestionar Cliente");

             jQuery(".Opcion5").click(function () {
                 jQuery("#ContentGestionarVenta").fadeIn('slow');
                 jQuery("#ContentGestionarPedido").hide();
                 jQuery("#ContentGestionarCliente").hide();
             });
             jQuery(".Opcion6").click(function () {
                 jQuery("#ContentGestionarCliente").hide();
                 jQuery("#ContentGestionarVenta").hide();
                 jQuery("#ContentGestionarPedido").fadeIn('slow');
             });
             jQuery(".Opcion10").click(function () {
                 jQuery("#ContentGestionarPedido").hide();
                 jQuery("#ContentGestionarVenta").hide();
                 jQuery("#ContentGestionarCliente").fadeIn('slow');
             });
         });
	</script>
    <div id="ContentGestionarVenta" style="display:none;">
        <uc1:WF_Ventas runat="server" ID="WF_Ventas1" />
    </div>

    <div id="ContentGestionarPedido" style="display:none;">
        <uc2:WF_Pedidos runat="server" ID="WF_Pedidos1" />
    </div>

    </form>
</asp:Content>