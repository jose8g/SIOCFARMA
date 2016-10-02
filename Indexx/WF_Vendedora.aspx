<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF_Vendedora.aspx.cs" Inherits="Indexx.Formulario_web1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
       <form runat="server">
       <asp:ScriptManager ID="ScriptManager2" runat="server">
                                </asp:ScriptManager>
</form>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery(".opcion8").text("Gestionar Pedidos");
            jQuery(".opcion9").text("Crear Pedidos");
            jQuery(".opcion10").text("Editar Pedidos");
            jQuery(".opcion11").text("Eliminar Pedidos");
            jQuery(".opcion12").text("Consultar Pedidos");

            jQuery(".opcion8").click(function () {
                jQuery("#ContentGestionarOrdenPedidos").fadeIn('slow');
                jQuery("#ContentCrearOrdenPedido").hide;
                jQuery("#ContentEditarOrdenPedido").hide;
                jQuery("#ContentEliminarOrdenPedido").hide;
                jQuery("#ContentConsultarOrdenPedido").hide;
            })

            jQuery(".opcion9").click(function () {
                jQuery("#ContentGestionarOrdenPedidos").hide;
                jQuery("#ContentCrearOrdenPedido").fadeIn('slow');
                jQuery("#ContentEditarOrdenPedido").hide;
                jQuery("#ContentEliminarOrdenPedido").hide;
                jQuery("#ContentConsultarOrdenPedido").hide;
            })

            jQuery(".opcion10").click(function () {
                jQuery("#ContentGestionarOrdenPedidos").hide;
                jQuery("#ContentCrearOrdenPedido").hide;
                jQuery("#ContentEditarOrdenPedido").fadeIn('slow');
                jQuery("#ContentEliminarOrdenPedido").hide;
                jQuery("#ContentConsultarOrdenPedido").hide;
            })

            jQuery(".opcion11").click(function () {
                jQuery("#ContentGestionarOrdenPedidos").hide;
                jQuery("#ContentCrearOrdenPedido").hide;
                jQuery("#ContentEditarOrdenPedido").hide;
                jQuery("#ContentEliminarOrdenPedido").fadeIn('slow');
                jQuery("#ContentConsultarOrdenPedido").hide;
            })

            jQuery(".opcion12").click(function () {
                jQuery("#ContentGestionarOrdenPedidos").hide;
                jQuery("#ContentCrearOrdenPedido").hide;
                jQuery("#ContentEditarOrdenPedido").hide;
                jQuery("#ContentEliminarOrdenPedido").hide;
                jQuery("#ContentConsultarOrdenPedido").fadeIn('slow');
            })
        });

</script>

<div id="ContentGestionarOrdenPedidos" style="display:;">
    <uc1:WF_GestionarOrdenPedido runat="server" id="WF_GestionarOrdenPedido" />
</div>

<div id="ContentCrearOrdenPedido" style="display:;">
    <uc2:WF_CrearOrdenPedido runat="server" id="WF_CrearOrdenPedido" />
</div>

<div id="ContentEditarOrdenPedido" style="display:;">
    <uc3:WF_EditarOrdenPedido runat="server" id="WF_EditarOrdenPedido" />
</div>

<div id="ContentEliminarOrdenPedido" style="display:;">
    <uc4:WF_EliminarOrdenPedido runat="server" id="WF_EliminarOrdenPedido" />
</div>

<div id="ContentConsultarOrdenPedido" style="display:;">
    <uc5:WF_ConsultarOrdenPedido runat="server" id="WF_ConsultarOrdenPedido" />
</div>


    </asp:Content>