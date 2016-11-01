<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Pedidos.ascx.cs" Inherits="Indexx.pages.Ventas.WF_Pedidos" %>



<body>
    <asp:UpdatePanel id="panelX" runat="Server"><ContentTemplate>
        <div class="row">
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
                        <br /><br />
                        <asp:GridView ID="dgvItems" runat="server" CssClass="gridview bordered table text-center" OnRowCommand="gvItems_RowComand"
                            DataKeyNames="IdItem,Nombre,PrecioVenta,Stock" AutoGenerateColumns="False"
                            style="text-align:center" AllowPaging="True" >
                            <Columns>
                                <asp:BoundField DataField="IdItem" HeaderText="IdItem" Visible="False" />
                                <asp:BoundField DataField="Nombre"     HeaderText="Nombre del Producto" />
                                <asp:BoundField DataField="PrecioVenta"     HeaderText="Precio de Venta" />
                                <asp:BoundField DataField="Stock"     HeaderText="Stock" />
                                <asp:TemplateField HeaderText="Agregar Producto">
                                    <ItemTemplate>
                                        <asp:Button ID="btnAgregarProducto" runat="server" 
                                                    CommandName="agregarItemxStock"  CssClass="btn btn-info btn-xs"
                                                    formnovalidate=""
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Seleccionar"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="OcultarProducto">
                                    <ItemTemplate>
                                        <asp:Button ID="btnOcultarProducto" runat="server" 
                                                    CommandName="ocultarItemxStock" CssClass="btn btn-info btn-xs"
                                                    formnovalidate=""
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Ocultar"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="row">
            <div class="col-sm-12" style="display:;">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>LISTA DE PRODUCTOS DEL PEDIDO</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                        </ul>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content">
                        <asp:GridView ID="dgvPedidos" runat="server" CssClass="gridview bordered table text-center" OnRowCommand="gvPedidos_RowComand"
                        DataKeyNames="IdItem,Nombre,PrecioUnitario" AutoGenerateColumns="False"
                        style="text-align:center" AllowPaging="True" >
                            <Columns>
                                <asp:BoundField DataField="IdItem"             HeaderText="IdItem" Visible="False" />
                                <asp:BoundField DataField="Nombre"             HeaderText="Nombre del Producto"  /> 
                                <asp:BoundField DataField="PrecioUnitario"     HeaderText="Precio del Producto" />
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemTemplate>
                                        <asp:TextBox ID="CantidadPedido" runat="server" Text='<%#Eval("Cantidad") %>'/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EditarPedido">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEditarPedido" runat="server" 
                                                    CommandName="EditarItemxStock" CssClass="btn btn-info btn-xs" 
                                                    formnovalidate=""
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Editar"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EliminarPedido">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEliminarItemxStock" runat="server" 
                                                    CommandName="eliminarItemxStock" CssClass="btn btn-info btn-xs"
                                                    formnovalidate=""
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Eliminar"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="row">
            <div class="col-sm-12" style="display:;">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>PEDIDOS</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                        </ul>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content">
                        <asp:GridView ID="GridView1" runat="server" CssClass="gridview bordered table text-center" OnRowCommand="gvPedidos_RowComand"
                        DataKeyNames="IdItem,Nombre,PrecioUnitario" AutoGenerateColumns="False"
                        style="text-align:center" AllowPaging="True" >
                            <Columns>
                                <asp:BoundField DataField="IdItem"             HeaderText="IdItem" Visible="False" />
                                <asp:BoundField DataField="Nombre"             HeaderText="Nombre del Producto"  /> 
                                <asp:BoundField DataField="PrecioUnitario"     HeaderText="Precio del Producto" />
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemTemplate>
                                        <asp:TextBox ID="CantidadPedido" runat="server" Text='<%#Eval("Cantidad") %>'/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EditarPedido">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEditarPedido" runat="server" 
                                                    CommandName="EditarItemxStock" CssClass="btn btn-info btn-xs" 
                                                    formnovalidate=""
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Editar"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EliminarPedido">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEliminarItemxStock" runat="server" 
                                                    CommandName="eliminarItemxStock" CssClass="btn btn-info btn-xs"
                                                    formnovalidate=""
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Eliminar"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate></asp:UpdatePanel>
</body>