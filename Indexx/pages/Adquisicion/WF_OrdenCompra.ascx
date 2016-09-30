<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_OrdenCompra.ascx.cs" Inherits="Indexx.pages.WF_OrdenCompra" %>

    <br />
    <asp:TextBox ID="txtniombre" runat="server"></asp:TextBox>
    <asp:GridView runat="server" ID="dgvComprasList" CssClass="gridview bordered"  OnRowCommand="getItems"
            AutoGenerateColumns="False" OnPageIndexChanging="gvOrdenCompra_PageIndexChanging">
        <Columns>
                <asp:BoundField DataField="IdCompra"      HeaderText="Id" Visible="false"/>
                <asp:BoundField DataField="NumCotizacion" HeaderText="N° Cotización" />
                <asp:BoundField DataField="Cantidad"      HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioCan"     HeaderText ="Precio" />
                <asp:BoundField DataField="Descuento"     HeaderText="Descuento" />
                <asp:BoundField DataField="Total"         HeaderText="Total" />
                <asp:BoundField DataField="estado"        HeaderText="Estado" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnVerItems" runat="server" 
                                    CommandName="verItems" 
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="Ver"/>
                    </ItemTemplate> 
                </asp:TemplateField>
            </Columns>
    </asp:GridView>

    <asp:GridView runat="server" ID="dgvProductosList" CssClass="gridview bordered"
            AutoGenerateColumns="False" OnPageIndexChanging="gvOrdenCompra_PageIndexChanging">
        <Columns>
                <asp:BoundField DataField="Nombre"      HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioVenta"     HeaderText ="Precio" />
                <asp:BoundField DataField="Estado"     HeaderText="Descuento" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnVerItems" runat="server" 
                                    CommandName="verItems" 
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="Ver"/>
                    </ItemTemplate> 
                </asp:TemplateField>
            </Columns>
    </asp:GridView>