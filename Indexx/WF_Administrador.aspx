<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF_Administrador.aspx.cs" Inherits="Indexx.Formulario_web11" %>

<%@ Register Src="~/pages/Adquisicion/WF_AsignarProveedoresAPedido.ascx" TagPrefix="uc1" TagName="WF_AsignarProveedoresAPedido" %>
<%@ Register Src="~/pages/Seguridad/WF_Configuracion_Almacen.ascx"  TagPrefix="uc2" TagName="WF_Configuracion_Almacen" %>
<%@ Register Src="~/pages/Seguridad/WF_AdministrarProveedores.ascx" TagPrefix="uc3" TagName="WF_AdministrarProveedores" %>
<%@ Register Src="~/pages/Almacen/WF_AceptarAjustes.ascx" TagPrefix="uc4" TagName="WF_AceptarAjustes" %>




<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
     <form runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager> 
         
          <script type="text/javascript" >
            jQuery(document).ready(function ()
            {
                  jQuery(".opcion4").text("Aprobar Ajustes Negativos");
                  jQuery(".Opcion8").text("Asignar pedido a proveedor");
                  jQuery(".Opcion9").text("Configuracion Almacén");
                  jQuery(".Opcion13").text("Administrar proveedor");
                
                  jQuery(".opcion4").click(function () {
                      jQuery("#ContentAjustarNegativos").fadeIn('slow');
                      jQuery("#ContentAdministrarProveedor").hide();
                      jQuery("#ContentAsignarProveedorAPedido").hide();;
                      jQuery("#ContentConfigAlmacen").hide();
                  });

                  jQuery(".Opcion8").click(function () {
                      jQuery("#ContentAjustarNegativos").hide();
                      jQuery("#ContentAdministrarProveedor").hide();
                      jQuery("#ContentAsignarProveedorAPedido").fadeIn('slow');
                      jQuery("#ContentConfigAlmacen").hide();
                  });

                  jQuery(".Opcion9").click(function () {
                      jQuery("#ContentAjustarNegativos").hide();
                 jQuery("#ContentAsignarProveedorAPedido").hide();
                 jQuery("#ContentConfigAlmacen").fadeIn('slow');
                      jQuery("#ContentAdministrarProveedor").hide();
                  });
                  jQuery(".Opcion13").click(function () {
                      jQuery("#ContentAjustarNegativos").hide();
                      jQuery("#ContentConfigAlmacen").hide();
                      jQuery("#ContentAsignarProveedorAPedido").hide();
                      jQuery("#ContentAdministrarProveedor").fadeIn('slow');
                  });
         });

	</script>
    <div id="ContentAsignarProveedorAPedido" style="display:none;">
        <uc1:WF_AsignarProveedoresAPedido runat="server" id="WF_AsignarProveedoresAPedido" />
        </div>
    <div id="ContentConfigAlmacen" style="display:none;">
        <uc2:WF_Configuracion_Almacen runat="server" id="WF_Configuracion_Almacen" />
    </div>
         
    <div id="ContentAdministrarProveedor" style="display:none;">
         <uc3:WF_AdministrarProveedores runat="server" ID="WF_AdministrarProveedores" />
    </div>
         <div id="ContentAjustarNegativos" style="display:none;">
             <uc4:WF_AceptarAjustes runat="server" id="WF_AceptarAjustes" />
    </div>

         </form>
                   
</asp:Content>