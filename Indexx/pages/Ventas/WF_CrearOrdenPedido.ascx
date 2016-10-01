<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_CrearOrdenPedido.ascx.cs" Inherits="Indexx.pages.Ventas.WF_CrearOrdenPedido" %>
<p>
    Crear Orden de Pedidos:</p>
<p>
    IdPedido:
    <input id="txtEmpresa" type="text" /></p>
<p>
    Número de Pedido:
    <input id="txtDireccion" type="text" /></p>
<p>
    Estado:
    <input id="txtFechaEntrega" type="text" /></p>
<p>
    Grilla de productos:</p>
<p>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</p>
<p>
    <asp:Button ID="btnGenerarOrden" runat="server" Text="Generar" OnClick="btnGenerarOrden_Click" />
</p>
<p>
    <asp:Label ID="labelSalida" runat="server" Text=" "></asp:Label>
</p>
<p>
    &nbsp;</p>