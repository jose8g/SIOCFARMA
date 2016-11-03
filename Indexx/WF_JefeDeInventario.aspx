<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF_JefeDeInventario.aspx.cs" Inherits="Indexx.Formulario_web12" %>

<%@ Register Src="~/pages/Adquisicion/WF_OrdenCompra.ascx" TagPrefix="uc1" TagName="WF_OrdenCompra" %>
<%@ Register Src="~/pages/Adquisicion/WF_Cotizacion.ascx" TagPrefix="uc2" TagName="WF_Cotizacion" %>




<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        
        <script type="text/javascript" >
            jQuery(document).ready(function () {
                jQuery(".opcion1").text("Orden Compra");
                jQuery(".opcion2").text("Cotizacion");

                jQuery(".opcion1").click(function () {
                    jQuery("#ContentOrdenCompra").fadeIn('slow');
                    jQuery("#ContentCotizacion").hide();
                });

                jQuery(".opcion2").click(function () {
                    jQuery("#ContentOrdenCompra").hide();
                    jQuery("#ContentCotizacion").fadeIn('slow');
                });

            });

	</script>

        
        <div id="ContentOrdenCompra" style="display:;">
            <uc1:WF_OrdenCompra runat="server" ID="WF_OrdenCompra" />
        </div>
        <div id="ContentCotizacion" style="display:;">
            <uc2:WF_Cotizacion runat="server" ID="WF_Cotizacion" />
        </div>
</form>
                   
        </asp:Content>