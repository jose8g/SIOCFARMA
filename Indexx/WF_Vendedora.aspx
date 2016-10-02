<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF_Vendedora.aspx.cs" Inherits="Indexx.Formulario_web1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
       <form runat="server">
       <asp:ScriptManager ID="ScriptManager2" runat="server">
                                </asp:ScriptManager>
</form>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery(".opcion8").text("Orden de Pedidos");

            jQuery(".opcion8").click(function () {
                jQuery("#ContentOrdenPedidos").fadeIn('slow');
            })
        });

</script>

<div id="ContentOrdenPedido" style="display:;">
    <uc1:WF_OrdenPedido runat="server" id="WF_OrdenPedido" />
</div>

    </asp:Content>