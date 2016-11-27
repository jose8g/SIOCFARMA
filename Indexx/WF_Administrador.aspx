<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF_Administrador.aspx.cs" Inherits="Indexx.Formulario_web11" %>

<%@ Register Src="~/pages/Adquisicion/WF_AsignarProveedoresAPedido.ascx" TagPrefix="uc1" TagName="WF_AsignarProveedoresAPedido" %>
<%@ Register Src="~/pages/Seguridad/WF_Configuracion_Almacen.ascx"  TagPrefix="uc2" TagName="WF_Configuracion_Almacen" %>
<%@ Register Src="~/pages/Seguridad/WF_AdministrarProveedores.ascx" TagPrefix="uc3" TagName="WF_AdministrarProveedores" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
     <form runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager> 
         
          <script type="text/javascript" >
            jQuery(document).ready(function ()
            {
                  jQuery(".Opcion8").text("Asignar pedido a proveedor");
                  jQuery(".Opcion9").text("Configuracion Almacén");
                  jQuery(".Opcion10").text("Administrar proveedor");
                
                  jQuery(".Opcion8").click(function () {
                      jQuery("#ContentAdministrarProveedor").hide();
                      jQuery("#ContentAsignarProveedorAPedido").fadeIn('slow');
                      jQuery("#ContentConfigAlmacen").hide();
                  });

                  jQuery(".Opcion9").click(function () {
                 jQuery("#ContentAsignarProveedorAPedido").hide();
                 jQuery("#ContentConfigAlmacen").fadeIn('slow');
                      jQuery("#ContentAdministrarProveedor").hide();
                  });
                  jQuery(".Opcion10").click(function (){
                      jQuery("#ContentConfigAlmacen").hide();
                      jQuery("#ContentAsignarProveedorAPedido").hide();
                      jQuery("#ContentAdministrarProveedor").fadeIn('slow');
                  });
         });

	</script>
         
        <div id="ContentAdministrarProveedor" style="display:;">
            <uc3:WF_AdministrarProveedores runat="server" id="WF_AdministrarProveedores" />

            </div>
    <div id="ContentAsignarProveedorAPedido" style="display:none;">
        <uc1:WF_AsignarProveedoresAPedido runat="server" id="WF_AsignarProveedoresAPedido" />
        </div>
    <div id="ContentConfigAlmacen" style="display:none;">
        <uc2:WF_Configuracion_Almacen runat="server" id="WF_Configuracion_Almacen" />
    </div>
     </form>
                   
</asp:Content>