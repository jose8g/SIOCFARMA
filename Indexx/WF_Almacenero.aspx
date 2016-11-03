<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF_Almacenero.aspx.cs" Inherits="Indexx.Formulario_web14" %>

<%@ Register Src="~/pages/Almacen/WF_AdministrarMovimientos.ascx" TagPrefix="uc1" TagName="WF_AdministrarMovimientos" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        
        <script type="text/javascript" >
            jQuery(document).ready(function () {
                jQuery(".opcion4").text("ContentAdministrarAlmacen");

                jQuery(".opcion4").click(function () {
                    jQuery("#ContentAdministrarAlmacen").fadeIn('slow');
                });

            });

	</script>
    

        <div id="ContentAdministrarAlmacen" style="display:;">
            <uc1:WF_AdministrarMovimientos runat="server" ID="WF_AdministrarMovimientos" />
        </div>
    </form>
</asp:Content>