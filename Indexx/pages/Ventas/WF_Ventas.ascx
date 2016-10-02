<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Ventas.ascx.cs" Inherits="Indexx.pages.Ventas.WF_Ventas" %>
<!DOCTYPE html>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>
<body>
    &nbsp;<table class="auto-style1">
        <tr>
            <td>ID VENTA<br />
    OBSERVACION 
                <br />
    ESTADO 
                <br />
    ID_VENDEDOR 
                <br />
    ID_CIENTE</td>
            <td><input id="Text1" type="text" runat="server"/><br />
                <input id="Text3" type="text" runat="server"/><br />
                <input id="Text4" type="text" runat="server"/><br />
                <input id="Text5" type="text" runat="server" /><br />
                <input id="Text6" type="text" runat="server" /></td>
        </tr>
    </table>
    &nbsp;<br />
    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="registrar_Click"/>
</body>