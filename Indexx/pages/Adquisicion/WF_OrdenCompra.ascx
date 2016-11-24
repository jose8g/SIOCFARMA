<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_OrdenCompra.ascx.cs" Inherits="Indexx.pages.WF_OrdenCompra" %>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
    <div class="row">
        <div class="col-sm-6" style="display:none;">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Busqueda </h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Fecha</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Seleccionar Compra</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <label>Pedido Cotizados</label>
                    <asp:DropDownList ID="ddlPedido"  CssClass="ddl" runat="server" AutoPostBack="True" onselectedindexchanged="itemSelected">
                        <asp:ListItem>Selec. Cotizacion</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Compras </h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView runat="server" ID="dgvComprasList" CssClass="gridview bordered table"  OnRowCommand="getItems"
                        DataKeyNames="IdCompras,FechaRegistro,Cantidad,PrecioCan,Descuento,Total,estado,proveedor"
                          AutoGenerateColumns="False" OnPageIndexChanging="gvOrdenCompra_PageIndexChanging">
                        <Columns>
                                <asp:BoundField DataField="IdCompras"     HeaderText="Id" Visible="false"/>
                                <asp:BoundField DataField="proveedor"     HeaderText="Proveedor"     />
                                <asp:BoundField DataField="FechaRegistro" HeaderText="Fec. Registro"     />
                                <asp:BoundField DataField="Cantidad"      HeaderText="Cantidad"  />
                                <asp:BoundField DataField="PrecioCan"     HeaderText ="Precio"   />
                                <asp:BoundField DataField="Descuento"     HeaderText="Descuento" />
                                <asp:BoundField DataField="Total"         HeaderText="Total"     />
                                <asp:BoundField DataField="estado"        HeaderText="Estado"    />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="text-center">
                                            <asp:Button ID="btnVerItems" runat="server" 
                                                        CommandName="verItems" CssClass="btn btn-info btn-xs"
                                                        formnovalidate=""
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        Text="Ver Items"/>
                                        </div>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="text-center">
                                            <asp:Button ID="btnEditCompra" runat="server" 
                                                        CommandName="editarCompra" CssClass="btn btn-info btn-xs"
                                                        formnovalidate=""
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        Text="Editar"/>
                                        </div>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                            </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12" runat="server" id="containerItemsCompra" visible="false"> 
            <div class="x_panel">
                <div class="x_title">
                    <h2>Productos Compra </h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView runat="server" ID="dgvProductosList" CssClass="gridview bordered table"
                            AutoGenerateColumns="False">
                        <Columns>
                                <asp:BoundField DataField="Nombre"      HeaderText = "Nombre"    />
                                <asp:BoundField DataField="Medida"      HeaderText = "Medida"    />
                                <asp:BoundField DataField="Cantidad"    HeaderText = "Cantidad"  />
                                <asp:BoundField DataField="cant_total"  HeaderText = "Total" />
                                <asp:BoundField DataField="monto_total" HeaderText = "Monto Total" />
                            </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

        <div class="col-sm-6" runat="server" id="containterItemsPedido" visible="false">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Productos Pedido </h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="col-sm-12">
                        <label>Pedido Cotizados</label>
                        <asp:DropDownList ID="ddlProveedores"  CssClass="ddl" runat="server" AutoPostBack="True" onselectedindexchanged="itemSelectedProveedor">
                            <asp:ListItem>Selec. Proveedor</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-12">
                        <div ID="contentCotizacionProd" runat="server">
                            <asp:GridView runat="server" ID="dgvProductPedido" CssClass="gridview bordered table" OnRowCommand="getItems" 
                                          DataKeyNames="IdItem,Nombre,Cantidad,PrecioCompra,Tipo"
                                          AutoGenerateColumns="False" OnPageIndexChanging="gvOrdenCompra_PageIndexChanging">
                                <Columns>
                                        <asp:BoundField DataField="IdItem"          HeaderText="Id" Visible="false"/>
                                        <asp:BoundField DataField="Nombre"          HeaderText = "Producto"/>
                                        <asp:BoundField DataField="Cantidad"        HeaderText = "Solicitado"/>
                                        <asp:BoundField DataField="Tipo"            HeaderText = "Tipo Item"/>
                                        <asp:TemplateField HeaderText="Comprar">
                                            <ItemTemplate>
                                                <asp:TextBox ID="cantCompra" runat="server">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="text-center">
                                                    <asp:Button ID="btnVerPrecios" runat="server" 
                                                                CommandName="registrar" CssClass="btn btn-info btn-xs"
                                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                Text="Registrar"/>

                                                </div>
                                            </ItemTemplate> 
                                        </asp:TemplateField>
                                    </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-sm-6" runat="server" id="contentProductCompra" visible="false">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Productos Compra</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="col-sm-12">
                        <div ID="Div3" runat="server">
                            <asp:GridView runat="server" ID="dgvProductoCompra" CssClass="gridview bordered table" OnRowCommand="getItems" 
                                          DataKeyNames="IdItem,Nombre,Medida,Cantidad"
                                          AutoGenerateColumns="False" OnPageIndexChanging="gvOrdenCompra_PageIndexChanging">
                                <Columns>
                                        <asp:BoundField DataField="IdItem"          HeaderText="Id" Visible="false"/>
                                        <asp:BoundField DataField="Nombre"          HeaderText = "Producto"/>
                                        <asp:BoundField DataField="Medida"          HeaderText = "Medida"/>
                                        <asp:TemplateField HeaderText="Comprar">
                                            <ItemTemplate>
                                                <asp:TextBox ID="cantCompraEdit" runat="server" Text='<%#Eval("Cantidad") %>'>
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="text-center">
                                                    <asp:Button ID="btnEditCompra" runat="server" 
                                                                CommandName="editar" CssClass="btn btn-info btn-xs"
                                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                Text="Editar"/>
                                                </div>
                                            </ItemTemplate> 
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="text-center">
                                                    <asp:Button ID="btnDeleteCompra" runat="server" 
                                                                CommandName="eliminar" CssClass="btn btn-info btn-xs"
                                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                Text="Eliminar"/>

                                                </div>
                                            </ItemTemplate> 
                                        </asp:TemplateField>
                                    </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Finalizar Compra" onclick="insertCompra"/>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row" style="display:none;">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2 runat="server" ID="nombreProd">Precios Prodcuto</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div ID="Div1" runat="server">
                        <asp:GridView runat="server" ID="dgvPreciosItem" CssClass="gridview bordered table"
                                      DataKeyNames="IdProveedor,Nombre,PrecioUnitario,Cantidad,Medida,Proveedor,Responsable"
                                      AutoGenerateColumns="False">
                            <Columns>
                                    <asp:BoundField DataField="IdProveedor"    HeaderText="Id" Visible="false"/>
                                    <asp:BoundField DataField="Proveedor"         HeaderText = "Proveedor"    />
                                    <asp:BoundField DataField="Responsable"    HeaderText = "Responsable" />
                                    <asp:BoundField DataField="Telefono"      HeaderText = "Teléfono" />
                                    <asp:BoundField DataField="PrecioUnitario" HeaderText = "Precio"    />
                                    <asp:BoundField DataField="Cantidad"       HeaderText = "Cantidad"  />
                                    <asp:BoundField DataField="Medida"         HeaderText = "Medida" />
                                </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
        
</ContentTemplate>
</asp:UpdatePanel>