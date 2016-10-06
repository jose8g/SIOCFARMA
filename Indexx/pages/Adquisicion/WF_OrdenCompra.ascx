<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_OrdenCompra.ascx.cs" Inherits="Indexx.pages.WF_OrdenCompra" %>

    <br />
    <br />
        <asp:DropDownList ID="ddlCotizacion" Width="150px" runat="server" AutoPostBack="True" onselectedindexchanged="itemSelected">
            <asp:ListItem>Selec. Cotizacion</asp:ListItem>
        </asp:DropDownList>
    <br />

    <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Compras </h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">Settings 1</a>
                                </li>
                                <li><a href="#">Settings 2</a>
                                </li>
                            </ul>
                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
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
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Productos Compra<small>Prod.</small></h2>
                </div>
                <div class="x_content">
                    <asp:GridView runat="server" ID="dgvProductosList" CssClass="gridview bordered"
                            AutoGenerateColumns="False">
                        <Columns>
                                <asp:BoundField DataField="Nombre"      HeaderText = "Nombre"    />
                                <asp:BoundField DataField="PrecioVenta" HeaderText = "Precio"    />
                                <asp:BoundField DataField="Cantidad"    HeaderText = "Cantidad"  />
                                <asp:BoundField DataField="Estado"      HeaderText = "Descuento" />
                            </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    
    <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Productos Cotización</h2>
                </div>
                <div class="x_content">
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
                </div>
            </div>
        </div>
    </div>