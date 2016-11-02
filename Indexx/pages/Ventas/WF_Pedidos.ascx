<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Pedidos.ascx.cs" Inherits="Indexx.pages.Ventas.WF_Pedidos" %>
<div>
<p>
    Gestionar Pedidos:</p>
<p>
    Pedidos pendientes:</p>
<asp:GridView ID="gridMostrarPendientes" runat="server" CssClass="gridview bordered" 
            AutoGenerateColumns="False" OnPageIndexChanging="gvItems_PageIndexChanging"
            DataKeyNames="IdItem,Nombre,PrecioVenta"
            OnRowCommand="gvItems_RowComand"
            AllowPaging="True" PageSize="8" Height="161px" Width="467px" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" >
            <Columns>
                <asp:BoundField DataField="IdItem" HeaderText="IdItem" Visible="false" />
                <asp:BoundField DataField="Nombre"     HeaderText="Nombre" />
                <asp:BoundField DataField="Estado"     HeaderText="Estado" />
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

<p>
    <asp:Button ID="btnRefrescar" runat="server" Text="Refrescar" OnClick="btnRefrescar_Click" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        Registrar Pedidos:</p>
    <p>
        Selecciona Items:</p>
    <p>
        Ingresa nombre del Item:&nbsp;&nbsp;&nbsp;
        <input id="txtNombre" runat="server" type="text" />&nbsp;
        <asp:Button ID="btnNombre" runat="server" Text="Buscar por Nombre" OnClick="btnNombre_Click" />
    </p>
    <p>
         <asp:GridView ID="dgvItems" runat="server" CssClass="gridview bordered" 
            AutoGenerateColumns="False" OnPageIndexChanging="gvItems_PageIndexChanging"
            DataKeyNames="IdItem,Nombre,PrecioVenta"
            OnRowCommand="gvItems_RowComand"
            AllowPaging="True" PageSize="8" Height="161px" Width="497px" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" >
            <Columns>
                <asp:BoundField DataField="IdItem" HeaderText="IdItem" Visible="false" />
                <asp:BoundField DataField="Nombre"     HeaderText="Nombre" />
                <asp:BoundField DataField="PrecioVenta"     HeaderText="Precio de Venta" />
                <asp:BoundField DataField="Estado"     HeaderText="Estado" />
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

    </p>
    <p>
         &nbsp;</p>
    <p>
        &nbsp;</p>
<p>
    &nbsp;</p>

</div>