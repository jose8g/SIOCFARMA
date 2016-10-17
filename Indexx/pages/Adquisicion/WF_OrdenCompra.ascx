<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_OrdenCompra.ascx.cs" Inherits="Indexx.pages.WF_OrdenCompra" %>

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
                    <h2>Generar Compra </h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <label>Cotizaciones Generadas</label>
                    <asp:DropDownList ID="ddlCotizacion"  CssClass="ddl" runat="server" AutoPostBack="True" onselectedindexchanged="itemSelected">
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
                        DataKeyNames="IdCompras,NumCotizacion,Cantidad,PrecioCan,Descuento,Total,estado"
                            AutoGenerateColumns="False" OnPageIndexChanging="gvOrdenCompra_PageIndexChanging">
                        <Columns>
                                <asp:BoundField DataField="IdCompras"      HeaderText="Id" Visible="false"/>
                                <asp:BoundField DataField="NumCotizacion" HeaderText="N°"        />
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
                    <h2>Productos Cotización </h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div ID="contentCotizacionProd" runat="server" visible="false">
                        <asp:GridView runat="server" ID="dgvProductCotizacion" CssClass="gridview bordered table"
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