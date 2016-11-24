<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF_Administrador.aspx.cs" Inherits="Indexx.Formulario_web11" %>

<%@ Register Src="~/pages/Adquisicion/WF_AsignarProveedoresAPedido.ascx" TagPrefix="uc1" TagName="WF_AsignarProveedoresAPedido" %>
<%@ Register Src="~/pages/Seguridad/WF_Configuracion_Almacen.ascx"  TagPrefix="uc2" TagName="WF_Configuracion_Almacen" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
     <form runat="server">
         <asp:ScriptManager ID="ScriptManager3" runat="server">
        </asp:ScriptManager> 
         
          <script type="text/javascript" >
         jQuery(document).ready(function () {
             jQuery(".Opcion8").text("Asignar Proveedor a Pedido");
             jQuery(".Opcion9").text("Configuración almacén");

             jQuery(".Opcion8").click(function () {
                 jQuery("#ContentAsignarProveedorAPedido").fadeIn('slow');
                 jQuery("#ContentConfigAlmacen").hide();
             });
             jQuery(".Opcion9").click(function () {
                 jQuery("#ContentConfigAlmacen").fadeIn('slow');
                 jQuery("#ContentAsignarProveedorAPedido").hide();
             });
         });
	</script>
         
    <div id="ContentAsignarProveedorAPedido" style="display:none;">
        <uc1:WF_AsignarProveedoresAPedido runat="server" id="WF_AsignarProveedoresAPedido" />
    </div>
    <div id="ContentConfigAlmacen" style="display:none;">
        <uc2:WF_Configuracion_Almacen runat="server" id="WF_Configuracion_Almacen" />
    </div>
    </form>
</asp:Content>