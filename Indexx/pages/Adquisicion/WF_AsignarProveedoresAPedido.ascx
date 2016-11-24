<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_AsignarProveedoresAPedido.ascx.cs" Inherits="Indexx.pages.Adquisicion.WF_AsignarProveedoresAPedido" %>


<body>
    <asp:UpdatePanel id="panelX" runat="Server"><ContentTemplate>
        <div class="row">
            <div class="col-sm-12" style="display:;">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Tabla de pedidos </h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>

                 <div class="x_content">
                     <td>SELECCIONAR PEDIDO</td><br /><br />
                     <asp:DropDownList ID="ddlpedido" runat="server" AutoPostBack="True" CssClass="ddl" style="margin-bottom: 0px" Width="150px" onselectedindexchanged="pedidoSelected"></asp:DropDownList>
                         
                        <asp:GridView ID="dgvPedidos1" runat="server" CssClass="gridview bordered table text-center" OnRowCommand="gvPedidos1_RowComand"
                       DataKeyNames="IdItem" AutoGenerateColumns="False"
                        style="text-align:center" AllowPaging="True" >
                            <Columns>
                                <asp:BoundField DataField="IdItem"             HeaderText="IdItem" Visible="False" />
                                <asp:BoundField DataField="nombreItem"         HeaderText="Nombre de item"  />
                                <asp:BoundField DataField="Cantidad"           HeaderText ="Cantidad" />
                                <asp:BoundField DataField="nombreTipo"         HeaderText ="Tipo" />
                                <asp:BoundField DataField="nombreMarca"        HeaderText ="Marca" />
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
                        <h2>Tabla de proveedores </h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    
                    <td>SELECCIONAR PROVEEDOR</td><br /><br />
                     <asp:DropDownList ID="ddlproveedor" runat="server" AutoPostBack="True" CssClass="ddl" style="margin-bottom: 0px" Width="150px" onselectedindexchanged="proveedorSelected"></asp:DropDownList>
                     
                     <asp:GridView ID="dgvProveedor" runat="server" CssClass="gridview bordered table text-center" OnRowCommand="gvPeoveedores_RowComand"
                       DataKeyNames="IdProveedor" AutoGenerateColumns="False"
                        style="text-align:center" AllowPaging="True" >
                            <Columns>
                                <asp:BoundField DataField="IdProveedor"             HeaderText="IdProveedor" Visible="False" />
                                <asp:BoundField DataField="CodigoProveedor"         HeaderText="Codigo Proveedor"  />
                                <asp:BoundField DataField="Nombre"                  HeaderText="Nombre" />
                                <asp:BoundField DataField="Direccion"               HeaderText ="Direccion" />
                                <asp:BoundField DataField="Telefono"                HeaderText="Telefono" />
                                <asp:BoundField DataField="RUC"                     HeaderText ="RUC" />
                                <asp:BoundField DataField="Responsable"             HeaderText ="Responsable" />
                                <asp:TemplateField HeaderText="GuardarPedido">
                                    <ItemTemplate>
                                        <asp:Button ID="btnGuardarPedido" runat="server" 
                                                    CommandName="GuardarPedido" CssClass="btn btn-info btn-xs" 
                                                    formnovalidate=""
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="Asignar"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        <div class="row">
            <div class="col-sm-12" style="display:;">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Tabla proveedores por pedido </h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                     <asp:GridView ID="dgvProveedorxPedido" runat="server" CssClass="gridview bordered table text-center" OnRowCommand="gvPedidosxPeoveedor_RowComand"
                       DataKeyNames="IdPedido,IdProveedor" AutoGenerateColumns="False"
                        style="text-align:center" AllowPaging="True" >
                            <Columns>
                                <asp:BoundField DataField="IdPedido"             HeaderText="IdPedido" Visible="False" />
                                <asp:BoundField DataField="IdProveedor"             HeaderText="IdProveedor" Visible="False" />
                                <asp:BoundField DataField="NumeroPedido"                  HeaderText="Cantidad de pedido" />
                                <asp:BoundField DataField="NombreProveedor"                  HeaderText="Nombre Proveedor" />
                                <asp:TemplateField HeaderText="EliminarPedidoxProveedor">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEliminarPedidoxProveedor" runat="server" 
                                                    CommandName="eliminarPedidoxProveedor" CssClass="btn btn-info btn-xs"
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
     </ContentTemplate></asp:UpdatePanel>
    <p>
    </p>
</body>