<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF_Administrador.aspx.cs" Inherits="Indexx.Formulario_web11" %>

<%@ Register Src="~/pages/Seguridad/WF_AdministrarProveedores.ascx" TagPrefix="uc1" TagName="WF_AdministrarProveedores" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        
        <script type="text/javascript" >
            jQuery(document).ready(function ()
            {
                jQuery(".Opcion8").text("Administrar Proveedor");
                

                jQuery(".Opcion8").click(function ()
                {
                    jQuery("#ContentAdministrarProveedor").fadeIn('slow');
                    
                });
            });

	    </script>
        
        <div id="ContentAdministrarProveedor" style="display:;">
            <uc1:WF_AdministrarProveedores runat="server" id="WF_AdministrarProveedores" />
        </div>

    </form>
                   
</asp:Content>