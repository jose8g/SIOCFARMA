<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Ventas.ascx.cs" Inherits="Indexx.pages.Ventas.WF_Ventas" %>

<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .bordered {}
</style>
<body>
    <asp:UpdatePanel id="panelX" runat="Server">
    <ContentTemplate>
    <table class="auto-style1">
        <tr>
            <td>BUSCAR PRODUCTOS POR NOMBRE</td>
            <td><input id="Text7" type="text" runat="server"/>
            <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="getItemsByNombre"/>
            </td>
        </tr>
    </table>
    <br />BUSCAR PRODUCTOS POR MARCAS<br />&nbsp;<asp:DropDownList ID="ddlMarca" Width="150px" runat="server" AutoPostBack="True" onselectedindexchanged="itemSelected" style="margin-bottom: 0px">
    </asp:DropDownList>
    <br /><br />

    <asp:GridView ID="dgvItems" runat="server" CssClass="gridview bordered"
            AutoGenerateColumns="False" OnPageIndexChanging="gvItems_PageIndexChanging"
            DataKeyNames="IdItem,Nombre,PrecioVenta"
            OnRowCommand="gvItems_RowComand" style="text-align:center"
            AllowPaging="True" PageSize="8" Width="497px" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" >
        <RowStyle HorizontalAlign="center"></RowStyle>
        <Columns>
            <asp:BoundField DataField="IdItem"          HeaderText="IdItem" Visible="false"/>
            <asp:BoundField DataField="Nombre"          HeaderText ="Item" />
            <asp:BoundField DataField="PrecioVenta"     HeaderText="Precio"/>
            <asp:BoundField DataField="Estado"          HeaderText="Estado"/>
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
            
    <br />
            
    &nbsp;<!--p>
    <input id="Text8" type="text" runat="server" />
    </p-->
    
        <p>
            <asp:GridView ID="dgvCarrito" runat="server" CssClass="gridview bordered"
                    AutoGenerateColumns="False" OnPageIndexChanging="gvItems_PageIndexChanging"
                    DataKeyNames="IdItem"
                    OnRowCommand="gvItems2_RowComand" style="text-align:center"
                    AllowPaging="True" PageSize="8" Width="497px" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" >
                <RowStyle HorizontalAlign="center"></RowStyle>
                <Columns>
                    <asp:BoundField DataField="IdItem"          HeaderText="IdItem"/>
                </Columns>
                <EditRowStyle BorderColor="Black" BorderStyle="Solid" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle BorderColor="Black" BorderStyle="Solid" ForeColor="Black" HorizontalAlign="Center" />
                <SortedDescendingCellStyle BorderColor="blue" BorderStyle="Solid" ForeColor="blue"  HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:GridView>
            <br />
        </p>
    
    </ContentTemplate></asp:UpdatePanel>
</body>