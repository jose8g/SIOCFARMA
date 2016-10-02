<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF_Vendedora.aspx.cs" Inherits="Indexx.Formulario_web1" %>
<%@ Register Src="~/pages/Ventas/WF_Ventas.ascx" TagPrefix="uc1" TagName="WF_Ventas" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager> 

    
     <script type="text/javascript" >
         jQuery(document).ready(function () {
             jQuery(".Opcion5").text("Gestionar Venta");

             jQuery(".Opcion5").click(function () {
                 jQuery("#ContentGestionarVenta").fadeIn('slow');
             });
         });
	</script>

    <div id="ContentGestionarVenta" style="display: block;">
        <uc1:WF_Ventas runat="server" ID="WF_Ventas" />
    </div>
    </form>
</asp:Content>
