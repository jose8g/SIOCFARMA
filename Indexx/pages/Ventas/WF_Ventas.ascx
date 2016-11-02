<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Ventas.ascx.cs" Inherits="Indexx.pages.Ventas.WF_Ventas" %>

<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .bordered {}
</style>
<body>
    <asp:UpdatePanel id="panelX" runat="Server"><ContentTemplate>
    <div class="row">
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
                        <tr>
                            <td>BUSCAR PRODUCTOS POR NOMBRE</td>
                            <td><input id="Text7" type="text" runat="server"/>
                            <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="getItemsByNombre" CssClass="btn btn-info btn-xs"/>
                            </td>
                        </tr>
                        <br />
                        <tr>
                            <td>BUSCAR PRODUCTOS POR MARCA</td>
                            <td>
                                <asp:DropDownList ID="ddlMarca" runat="server" AutoPostBack="True" CssClass="ddl" onselectedindexchanged="marcaSelected" style="margin-bottom: 0px" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <br />
                        <tr>
                            <td>BUSCAR PRODUCTOS POR TIPO</td>
                            <td>
                                <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" CssClass="ddl" onselectedindexchanged="tipoSelected" style="margin-bottom: 0px" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <br />
                </div>
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
                            DataKeyNames="IdItem,Nombre,PrecioVenta,Tipo" AutoGenerateColumns="False" OnPageIndexChanging="gvItems_PageIndexChanging"
                            style="text-align:center" AllowPaging="True">
                        <RowStyle HorizontalAlign="center"></RowStyle>
                        <Columns>
                            <asp:BoundField DataField ="IdItem"          HeaderText ="IdItem" Visible="false" />
                            <asp:BoundField DataField ="Nombre"          HeaderText ="Nombre" />
                            <asp:BoundField DataField ="PrecioVenta"     HeaderText ="Precio" />
                            <asp:BoundField DataField ="Tipo"            HeaderText ="Tipo" />
                            <asp:BoundField DataField ="Marca"           HeaderText ="Marca" />
                            <asp:BoundField DataField ="Stock"           HeaderText ="Stock" />
                            <asp:TemplateField HeaderText="Agregar Producto">
                                <ItemTemplate>
                                    <asp:Button ID="btnAgregarProducto" runat="server"
                                                CommandName="selecItem" CssClass="btn btn-info btn-xs"
                                                formnovalidate=""
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
    <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>LISTA DE VENTA</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView ID="dgvCarrito" runat="server" CssClass="gridview bordered table text-center" OnRowCommand="gvCarrito_RowComand"
                            DataKeyNames="IdItem" AutoGenerateColumns="False" OnPageIndexChanging="gvItems_PageIndexChanging"
                            style="text-align:center" AllowPaging="True" >
                        <RowStyle HorizontalAlign="center"></RowStyle>
                        <Columns>
                            <asp:BoundField DataField ="IdItem"          HeaderText ="IdItem" Visible="false" />
                            <asp:BoundField DataField ="Nombre"          HeaderText ="Nombre" />
                            <asp:BoundField DataField ="PrecioVenta"     HeaderText ="Precio" />
                            <asp:BoundField DataField ="Tipo"            HeaderText ="Tipo" />
                            <asp:BoundField DataField ="Marca"           HeaderText ="Marca" />
                            <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                    <asp:TextBox ID="cantidadVenta" Text='<%#Eval("Cantidad") %>' runat="server"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:Button ID="btnEditItem" runat="server"
                                                CommandName="editItem" CssClass="btn btn-info btn-xs"
                                                formnovalidate=""
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="Guardar"/>
                                    <asp:Button ID="btnDeleteItem" runat="server"
                                                CommandName="deleteItem" CssClass="btn btn-info btn-xs"
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
    <br />
    <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>VENTAS PENDIENTES</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView ID="dgvVentas" runat="server" CssClass="gridview bordered table text-center" OnRowCommand="gvVenta_RowComand"
                            DataKeyNames="IdVenta, FechaRealizacion, NombreVendedor, PrecioTotal" AutoGenerateColumns="False"
                            style="text-align:center" AllowPaging="True" >
                        <RowStyle HorizontalAlign="center"></RowStyle>
                        <Columns>
                            <asp:BoundField DataField ="IdVenta"           HeaderText ="IdVenta" Visible="false" />
                            <asp:BoundField DataField ="FechaRealizacion"  HeaderText ="Fecha" />
                            <asp:BoundField DataField ="NombreVendedor"    HeaderText ="Vendedor" />
                            <asp:BoundField DataField ="PrecioTotal"       HeaderText ="Precio Total" />
                            <asp:TemplateField HeaderText="Observacion">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtObservacion" Text='<%#Eval("Observacion") %>' runat="server"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:Button ID="btnEditVenta" runat="server"
                                                CommandName="editVenta" CssClass="btn btn-info btn-xs"
                                                formnovalidate=""
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="Editar"/>
                                    <asp:Button ID="btnDeleteVenta" runat="server"
                                                CommandName="deleteVenta" CssClass="btn btn-info btn-xs"
                                                formnovalidate=""
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="Eliminar"/>
                                    <asp:Button ID="btnFinalizarVenta" runat="server"
                                                CommandName="finalizarVenta" CssClass="btn btn-info btn-xs"
                                                formnovalidate=""
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="Finalizar"/>
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