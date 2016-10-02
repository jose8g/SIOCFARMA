<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_OrdenCompra.ascx.cs" Inherits="Indexx.pages.WF_OrdenCompra" %>

    <br />
    <br />
        <asp:DropDownList ID="ddlCotizacion" Width="150px" runat="server" AutoPostBack="True" onselectedindexchanged="itemSelected">

        </asp:DropDownList>
    <br />
<!-- <div class="right_col" role="main">
    <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Titulo</h2>
                </div>
                <div class="x_content">-->
                    <asp:GridView runat="server" ID="dgvComprasList" CssClass="gridview bordered"  OnRowCommand="getItems"
                        DataKeyNames="IdCompras,NumCotizacion,Cantidad,PrecioCan,Descuento,Total,estado"
                            AutoGenerateColumns="False" OnPageIndexChanging="gvOrdenCompra_PageIndexChanging">
                        <Columns>
                                <asp:BoundField DataField="IdCompras"      HeaderText="Id" Visible="false"/>
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
                                                    formnovalidate=""
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Ver"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                            </Columns>
                    </asp:GridView>
                <!-- </div>
            </div>
        </div>
    </div>
</div>-->

    <br />
    <br />
    <asp:GridView runat="server" ID="dgvProductosList" CssClass="gridview bordered"
            AutoGenerateColumns="False">
        <Columns>
                <asp:BoundField DataField="Nombre"      HeaderText = "Nombre"    />
                <asp:BoundField DataField="PrecioVenta" HeaderText = "Precio"    />
                <asp:BoundField DataField="Cantidad"    HeaderText = "Cantidad"  />
                <asp:BoundField DataField="Estado"      HeaderText = "Descuento" />
            </Columns>
    </asp:GridView>
    
    <br />
    <br />
    <div ID="contentCotizacionProd" runat="server" visible="false">
        <asp:GridView runat="server" ID="dgvProductCotizacion" CssClass="gridview bordered"
                AutoGenerateColumns="False">
            <Columns>
                    <asp:BoundField DataField="NombreItem"  HeaderText = "Nombre"    />
                    <asp:BoundField DataField="NombreTipo"  HeaderText = "Precio"    />
                    <asp:BoundField DataField="PrecioVenta" HeaderText = "Cantidad"  />
                    <asp:BoundField DataField="Cantidad"    HeaderText = "Descuento" />
                </Columns>
        </asp:GridView>
        <asp:Button runat="server" Text="Agregar Compra" onclick="insertCompra"/>
    </div>
