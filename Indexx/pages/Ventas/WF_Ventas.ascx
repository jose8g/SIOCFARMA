<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Ventas.ascx.cs" Inherits="Indexx.pages.Ventas.WF_Ventas" %>
<!DOCTYPE html>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .bordered {}
</style>
<body>
    <table class="auto-style1">
        <tr>
            <td>PRODUCTOS</td>
            <td><input id="Text7" type="text" runat="server"/></td>
        </tr>
    </table>
    <br />

    <asp:Button ID="Button1" runat="server" Text="Buscar Productos" OnClick="getItemsByNombre"/>
    <br />

    <asp:GridView ID="dgvItems" runat="server" CssClass="gridview bordered" 
            AutoGenerateColumns="False" OnPageIndexChanging="gvItems_PageIndexChanging"
            DataKeyNames="IdItem,Nombre"
            OnRowCommand="gvItems_RowComand"
            AllowPaging="True" PageSize="8" Height="161px" Width="497px" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" >
            <Columns>
                <asp:BoundField DataField="IdItem" HeaderText="IdItem" Visible="false" />
                <asp:BoundField DataField="Nombre"     HeaderText="Titulo" />
                <asp:TemplateField HeaderText="AgregarProducto">
                    <ItemTemplate>
                        <asp:Button ID="btnAgregarProducto" runat="server" 
                                    CommandName="agregarItems" 
                                    formnovalidate=""
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="Agregar"/>
                    </ItemTemplate> 
                </asp:TemplateField>
            </Columns>
                <EditRowStyle BorderColor="Black" BorderStyle="Solid" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle BorderColor="Black" BorderStyle="Solid" ForeColor="Black" HorizontalAlign="Center" />
                <SortedDescendingCellStyle BorderColor="blue" BorderStyle="Solid" ForeColor="blue"  HorizontalAlign="Center" VerticalAlign="Middle"/>
    </asp:GridView>

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