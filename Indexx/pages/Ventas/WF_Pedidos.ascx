<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Pedidos.ascx.cs" Inherits="Indexx.pages.Ventas.WF_Pedidos" %>



<body>
    <asp:UpdatePanel id="panelX" runat="Server"><ContentTemplate>
            <div class="col-sm-12" style="display:;">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>ITEMS BAJO STOCK </h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <td>BUSCAR ITEMS POR NOMBRE</td>
                        <td><input id="txtBuscarItems" type="text" runat="server"/>
                        <asp:Button ID="btnBuscarItems" runat="server" Text="Buscar" OnClick="getItemsByNombre"/>
                        </td>
                        <p>
                        <asp:GridView ID="dgvItems" runat="server" CssClass="gridview bordered table" 
                            AutoGenerateColumns="False" OnPageIndexChanging="gvItems_PageIndexChanging"
                            DataKeyNames="IdItem,Nombre,PrecioVenta,Stock"
                            OnRowCommand="gvItems_RowComand"
                            AllowPaging="True" PageSize="8" Height="161px" Width="497px" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" >
                            <Columns>
                                <asp:BoundField DataField="IdItem" HeaderText="IdItem" Visible="False" />
                                <asp:BoundField DataField="Nombre"     HeaderText="Nombre del Producto" />
                                <asp:BoundField DataField="PrecioVenta"     HeaderText="Precio de Venta" />
                                <asp:BoundField DataField="Stock"     HeaderText="Stock" />
                                <asp:TemplateField HeaderText="AgregarProducto">
                                    <ItemTemplate>
                                        <asp:Button ID="btnAgregarProducto" runat="server" 
                                                    CommandName="agregarItemxStock" 
                                                    formnovalidate=""
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Seleccionar"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OcultarProducto">
                                    <ItemTemplate>
                                        <asp:Button ID="btnOcultarProducto" runat="server" 
                                                    CommandName="ocultarItemxStock" 
                                                    formnovalidate=""
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Ocultar"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                            </Columns>
                                <EditRowStyle BorderColor="Black" BorderStyle="Solid" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle BorderColor="Black" BorderStyle="Solid" ForeColor="Black" HorizontalAlign="Center" />
                                <SortedDescendingCellStyle BorderColor="blue" BorderStyle="Solid" ForeColor="blue"  HorizontalAlign="Center" VerticalAlign="Middle"/>
                        </asp:GridView>
                        </p>
                    </div>
                </div>
            </div>
        

            <div class="col-sm-12" style="display:;">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>MOSTRAR PEDIDOS </h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                        </ul>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content">
                        <p>
                            <asp:GridView ID="dgvPedidos" runat="server" CssClass="gridview bordered table" 
                            AutoGenerateColumns="False" OnPageIndexChanging="gvItems_PageIndexChanging"
                            DataKeyNames="IdItem,Nombre,PrecioVenta,Stock"
                            OnRowCommand="gvItems_RowComand"
                            AllowPaging="True" PageSize="8" Height="161px" Width="497px" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" >
                            <Columns>
                                <asp:BoundField DataField="IdItem" HeaderText="IdItem" Visible="False" />
                                <asp:BoundField DataField="Nombre"     HeaderText="Nombre del Producto" />
                                <asp:TemplateField HeaderText="Precio">
                                    <ItemTemplate>
                                        <asp:TextBox ID="btnPrecio" runat="server" 
                                                    CommandName="PrecioItem" 
                                                    formnovalidate=""
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Precio"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemTemplate>
                                        <asp:TextBox ID="btnCantidad" runat="server" 
                                                    CommandName="CantidadItem" 
                                                    formnovalidate=""
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Cantidad"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EditarPedido">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEditarPedido" runat="server" 
                                                    CommandName="EditarItemxStock" 
                                                    formnovalidate=""
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Editar"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EliminarPedido">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEliminarItemxStock" runat="server" 
                                                    CommandName="eliminarItemxStock" 
                                                    formnovalidate=""
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Eliminar"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                            </Columns>
                                <EditRowStyle BorderColor="Black" BorderStyle="Solid" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle BorderColor="Black" BorderStyle="Solid" ForeColor="Black" HorizontalAlign="Center" />
                                <SortedDescendingCellStyle BorderColor="blue" BorderStyle="Solid" ForeColor="blue"  HorizontalAlign="Center" VerticalAlign="Middle"/>
                        </asp:GridView>
                            <asp:Button ID="btnGuardarPedido" runat="server" OnClick="GuardarPedidosxItem" Text="GuardarPedido" />
                        </p>
                    </div>
                </div>
            </div>
    </ContentTemplate></asp:UpdatePanel>
</body>