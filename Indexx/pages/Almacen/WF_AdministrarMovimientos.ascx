<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_AdministrarMovimientos.ascx.cs" Inherits="Indexx.pages.Almacen.WF_AdministrarMovimientos" %>


<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .bordered {}
    .form-control {}
</style>
<body>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
        <div class="col-sm-12">
        <div class="x_panel">
            <div class="x_title">
                <h2>BÚSQUEDA</h2>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <table class="auto-style1">
                    <caption>
                        <br />
                        <tr>
                            <td>Seleccionar Tipo de Movimiento</td>
                            <td>
                                <asp:DropDownList ID="ddlTipoMov" runat="server" AutoPostBack="True" CssClass="ddl" onselectedindexchanged="itemSelected_SelectedIndexChanged" style="margin-bottom: 0px" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </caption>
                </table>
                <br />
            </div>
        </div>
    </div>
        <asp:panel ID="PnlEntrada" runat="server" visible="false">
            <div class="col-sm-12">
        <div class="x_panel">
             <div class="x_title">
                <h2>Entrada de productos</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <label>Ordenes de Compra</label>
                    <asp:DropDownList ID="ddlCompras"  CssClass="ddl" runat="server" AutoPostBack="True" onselectedindexchanged="itemSelected">
                        <asp:ListItem>Selec. la Orden de Compra</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
        <div class="col-sm-12" runat="server" id="containerItemsCompra" visible="true"> 
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
                    <asp:GridView runat="server" ID="dgvProductosList" OnRowCommand="dgvProductosList_RowCommand"
                        DataKeyNames="IdCompras,IdItem,Nombre,Tipo,Marca,Cantidad,Medida,CanUnid" CssClass="gridview bordered table"
                          AutoGenerateColumns="false" OnPageIndexChanging="dgvProductosList_PageIndexChanging">
                        <Columns>
                                <asp:BoundField DataField="IdCompras"      HeaderText = "IdCompras"   visible="false" />
                                <asp:BoundField DataField="IdItem"      HeaderText = "IdItem"    visible="false"/>
                                <asp:BoundField DataField="Nombre"      HeaderText = "Nombre"    />
                                <asp:BoundField DataField="Tipo"      HeaderText = "Tipo"    />
                                <asp:BoundField DataField="Marca"      HeaderText = "Marca"    />
                                <asp:BoundField DataField="Cantidad"    HeaderText = "Cantidad"  />
                                <asp:BoundField DataField="Medida"  HeaderText = "Medida Lote" />
                                <asp:BoundField DataField="CanUnid" HeaderText = "Cantidad Unidades" />
                            <asp:TemplateField HeaderText="Seleccion">
                                <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Style="position: static" />
                                </ItemTemplate>
                                        </asp:TemplateField>
                            </Columns>
                    </asp:GridView>
                </div>
            </div>

            <div class="col-sm-12">
                        <asp:Button ID="Button3" runat="server" CssClass="btn btn-success" Text="Finalizar Movimiento " onclick="insertItems"/>
                    </div>
        </div>
            </div>
        </asp:panel>

        <asp:panel ID="PnlSalida" runat="server" visible="false">
            <div class="col-sm-12">
        <div class="x_panel">
             <div class="x_title">
                <h2>Salida de Productos</h2>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            </div>
                </div>
        </asp:panel>
        
        <asp:panel ID="PnlAjustePositivo" runat="server" visible="false">
    <div class="col-sm-12">
        <div class="x_panel">
            <div class="x_title">
                <h2>Ajuste Positivo</h2>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <table class="auto-style1">
                    <tr>
                        <td>BUSCAR PRODUCTOS POR NOMBRE</td>
                        <td><input id="Text7" type="text" runat="server"/>
                        <asp:Button ID="BuscarAp" runat="server" Text="Buscar" OnClick="buscaAP" />
                        </td>
                    </tr>
                    <caption>
                        <br />
                        <tr>
                            <td>BUSCAR PRODUCTOS POR MARCAS</td>
                            <td>
                                <asp:DropDownList ID="ddlMarca" runat="server" AutoPostBack="True" CssClass="ddl"  style="margin-bottom: 0px" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>BUSCAR PRODUCTOS POR TIPO</td>
                            <td>
                                <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" CssClass="ddl" style="margin-bottom: 0px" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </caption>
                </table>
                <br />
            </div>
        </div>
    </div>
    <br />
        <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>PRODUCTOS</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView ID="dgvItems" runat="server" CssClass="gridview bordered table text-center" OnRowCommand="gvItems_RowComand"
                            DataKeyNames="IdItem,Nombre,PrecioVenta,Tipo,Marca,Stock" AutoGenerateColumns="False" OnPageIndexChanging="gvItems_PageIndexChanging"
                            style="text-align:center" AllowPaging="True">
                        <RowStyle HorizontalAlign="center"></RowStyle>
                        <Columns>
                            <asp:BoundField DataField ="IdItem"          HeaderText ="IdItem"  />
                            <asp:BoundField DataField ="Nombre"          HeaderText ="Nombre" />
                            <asp:BoundField DataField ="PrecioVenta"     HeaderText ="Precio unitario" Visible="false"/>
                            <asp:BoundField DataField ="Tipo"            HeaderText ="Tipo" />
                            <asp:BoundField DataField ="Marca"           HeaderText ="Marca" />
                            <asp:BoundField DataField ="Stock"           HeaderText ="Stock" />
                            <asp:TemplateField HeaderText="Ajustar Producto">
                                <ItemTemplate>
                                    <asp:Button ID="btnAjustarProducto" runat="server"
                                                CommandName="selecItem" CssClass="btn btn-info btn-xs"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="Agregar"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <br />
      <asp:panel id="Panel1" runat="server" Visible="false">     
           <div class="col-sm-12">
        <div class="x_panel">
            <div class="x_title">
                <h2>Movimiento</h2>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Añadir la Cantidad a Mover</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    </div>
                </div>
            <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Observacion</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control" Width="479px"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    </div>
            <asp:Button ID="AceptarMov" runat="server" class="btn btn-info btn-xs" Text="Aceptar Movimiento" onclick="AceptarMov_click" Width="172px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <div class="x_content">
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Nuevo Stock</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtnewStock" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    </div>
                <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Responsable</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtRes" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    </div>
                <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Autorizacion</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtAuto" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    </div>
                
                </div>
        </div>
    </div>
          </asp:panel>
    </asp:panel>

   <asp:panel ID="PnlAjusteNegativo" runat="server" visible="false">
    <div class="col-sm-12">
        <div class="x_panel">
            <div class="x_title">
                <h2>Ajuste Negativo</h2>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <table class="auto-style1">
                    <tr>
                        <td>BUSCAR PRODUCTOS POR NOMBRE</td>
                        <td><input id="Text7n" type="text" runat="server"/>
                        <asp:Button ID="BuscarApn" runat="server" Text="Buscar" OnClick="buscaAPn_click" />
                        </td>
                    </tr>
                    <caption>
                        <br />
                        <tr>
                            <td>BUSCAR PRODUCTOS POR MARCAS</td>
                            <td>
                                <asp:DropDownList ID="ddlMarcan" runat="server" AutoPostBack="True" CssClass="ddl"  style="margin-bottom: 0px" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>BUSCAR PRODUCTOS POR TIPO</td>
                            <td>
                                <asp:DropDownList ID="ddlTipon" runat="server" AutoPostBack="True" CssClass="ddl" style="margin-bottom: 0px" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </caption>
                </table>
                <br />
            </div>
        </div>
    </div>
    <br />
        <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>PRODUCTOS</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView ID="dgvItemsn" runat="server" CssClass="gridview bordered table text-center" OnRowCommand="gvItemsn_RowComand"
                            DataKeyNames="IdItem,Nombre,PrecioVenta,Tipo" AutoGenerateColumns="False" OnPageIndexChanging="gvItemsn_PageIndexChanging"
                            style="text-align:center" AllowPaging="True">
                        <RowStyle HorizontalAlign="center"></RowStyle>
                        <Columns>
                            <asp:BoundField DataField ="IdItem"          HeaderText ="IdItem" />
                            <asp:BoundField DataField ="Nombre"          HeaderText ="Nombre" />
                            <asp:BoundField DataField ="PrecioVenta"     HeaderText ="Precio unitario" Visible="false"/>
                            <asp:BoundField DataField ="Tipo"            HeaderText ="Tipo" />
                            <asp:BoundField DataField ="Marca"           HeaderText ="Marca" />
                            <asp:BoundField DataField ="Stock"           HeaderText ="Stock" />
                            <asp:TemplateField HeaderText="Ajustar Producto">
                                <ItemTemplate>
                                    <asp:Button ID="btnAjustarProducto" runat="server"
                                                CommandName="selecItem23" CssClass="btn btn-info btn-xs"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="Agregar"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <br />
      <asp:panel id="Panel2" runat="server" Visible="false">     
           <div class="col-sm-12">
        <div class="x_panel">
            <div class="x_title">
                <h2>Movimiento</h2>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Añadir la Cantidad a Mover</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtCantidadn" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    </div>
                </div>
            <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Observacion</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtObservacionn" runat="server" CssClass="form-control" Width="479px"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    </div>
            <asp:Button ID="AceptarMovn" runat="server" class="btn btn-info btn-xs" Text="Aceptar Movimiento" onclick="AceptarnMov_Click" Width="172px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                        <div class="x_content">
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Nuevo Stock</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtnewStockn" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    </div>
                <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Responsable</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtResn" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    </div>                
                </div>
        </div>
    </div>
          </asp:panel>
    </asp:panel>
</ContentTemplate>
        </asp:UpdatePanel>
</body>