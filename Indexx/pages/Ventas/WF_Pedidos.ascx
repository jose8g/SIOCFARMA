<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Pedidos.ascx.cs" Inherits="Indexx.pages.Ventas.WF_Pedidos" %>
<div>
<p>
    Gestionar Pedidos:</p>
<p>
    Pedidos pendientes:</p>
<asp:GridView ID="gridMostrarPendientes" runat="server">
</asp:GridView>

<p>
    <asp:Button ID="btnRefrescar" runat="server" Text="Refrescar" OnClick="btnRefrescar_Click" />
    </p>
    <p>
        Registrar Pedidos:</p>
    <p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
<p>
    &nbsp;</p>

</div>