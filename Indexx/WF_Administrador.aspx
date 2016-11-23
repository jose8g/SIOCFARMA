<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF_Administrador.aspx.cs" Inherits="Indexx.Formulario_web11" %>

<%@ Register Src="~/pages/Adquisicion/WF_AsignarProveedoresAPedido.ascx" TagPrefix="uc1" TagName="WF_AsignarProveedoresAPedido" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
     <form runat="server">
         <asp:ScriptManager ID="ScriptManager3" runat="server">
        </asp:ScriptManager> 
         
          <script type="text/javascript" >
         jQuery(document).ready(function () {
             jQuery(".Opcion8").text("Asignar Proveedor a Pedido");

             jQuery(".Opcion8").click(function () {
                 jQuery("#ContentAsignarProveedorAPedido").fadeIn('slow');
             });
             jQuery(".Opcion6").click(function () {
                 jQuery("#ContentAsignarProveedorAPedido").hide();
             });
         });
	</script>
         
          <div id="ContentAsignarProveedorAPedido" style="display:;">
              <uc1:WF_AsignarProveedoresAPedido runat="server" id="WF_AsignarProveedoresAPedido" />
        </div>
     </form>
</asp:Content>