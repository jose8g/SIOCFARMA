<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF_JefeDeLogistica.aspx.cs" Inherits="Indexx.Formulario_web15" %>

<%@ Register Src="~/pages/Adquision/WF_GestionarProducto.ascx" TagPrefix="uc1" TagName="WF_GestionarProducto" %>






<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <form runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager> 


      <script type="text/javascript" >
          jQuery(document).ready(function () {
              jQuery(".opcion4").text("Gestionar Productos");

              jQuery(".opcion4").click(function () {
                  jQuery("#contentGestionProductos").fadeIn('slow');

              });
          });

	</script>


<div id="contentGestionProductos" style="display:;" >
    <uc1:WF_GestionarProducto runat="server" ID="WF_GestionarProducto1" />
</div>
    </form>
</asp:Content>
