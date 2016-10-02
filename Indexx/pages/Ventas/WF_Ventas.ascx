<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Ventas.ascx.cs" Inherits="Indexx.pages.Ventas.WF_Ventas" %>
<!DOCTYPE html>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>
<body>
    <table class="auto-style1">
        <tr>
            <td>PRODUCTOS</td>
            <td><input id="Text7" type="text" runat="server"/></td>
        </tr>
    </table>
    <br />

    <asp:Button ID="Button1" runat="server" Text="Buscar Productos"/>
    <br />

    &nbsp;<table class="auto-style1">
        <tr>
            <td>ID VENTA</td>
            <td><input id="Text1" type="text" runat="server"/></td>
        </tr>
        <tr>
            <td>OBSERVACION</td>
            <td><input id="Text3" type="text" runat="server"/></td>
        </tr>
        <tr>
            <td>ESTADO</td>
            <td><input id="Text4" type="text" runat="server"/></td>
        </tr>
        <tr>
            <td>ID_VENDEDOR</td>
            <td><input id="Text5" type="text" runat="server" /></td>
        </tr>
        <tr>
            <td>ID_CIENTE</td>
            <td><input id="Text6" type="text" runat="server" /></td>
        </tr>
    </table>
    <br />

    <asp:Button ID="Button2" runat="server" Text="Registrar venta" OnClick="registrar_Click"/>
</body>