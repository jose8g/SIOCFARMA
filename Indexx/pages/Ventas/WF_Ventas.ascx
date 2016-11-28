<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Ventas.ascx.cs" Inherits="Indexx.pages.Ventas.WF_Ventas" %>
<script src="../../js/pop1.js"type="text/javascript"></script>
<link href="../../css/pop1.css" type="text/css" rel="stylesheet" />

<script src="../../Scripts/jquery-1.8.2.min.js"></script>
<script src="../../js/jquery-1.4.1.min.js"></script>
<style type="text/css">
    .auto-style1 {
        width: 100%;
        border: 10px solid white;
        padding: 15px;
    }
    .bordered {}
    
    #pop1

    {
        top: 55px !important;
        padding: 15px !important;
        height: auto  !important;
    }
    th, td {
        padding: 2px;
    }
    
    .auto-style2 {
        width: 100%;
        border-collapse: collapse;
        border: solid white;
    }
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
                <div class="x_content" >
                    <table class="auto-style1" >
                        <tr>
                            <td width="50%">Nombre</td>
                            <td width="50%"><input id="Text7" type="text" runat="server"/></td>
                        </tr>
                        <tr>
                            <td width="50%">Marca</td>
                            <td width="50%"><asp:DropDownList ID="ddlMarca" runat="server" AutoPostBack="True" CssClass="ddl" style="margin-bottom: 0px" Width="150px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td width="50%">Tipo</td>
                            <td width="50%"><asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" CssClass="ddl" style="margin-bottom: 0px" Width="150px">
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                    <br />
                    <table class="auto-style2">
                        <tr>
                            <td width="50%"><asp:Label runat="server" id="Label4" >Realizar búsqueda</asp:Label></td>
                            <td width="50%"><asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="getItemsByNombre" CssClass="btn btn-info btn-xs"/></td>
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
                            DataKeyNames="IdItem,Nombre,PrecioVenta,Tipo,IdAlmacen" AutoGenerateColumns="False" OnPageIndexChanging="gvItems_PageIndexChanging"
                            style="text-align:center" AllowPaging="True">
                        <RowStyle HorizontalAlign="center"></RowStyle>
                        <Columns>
                            <asp:BoundField DataField ="IdItem"          HeaderText ="IdItem" Visible="false" />
                            <asp:BoundField DataField ="Nombre"          HeaderText ="Nombre" />
                            <asp:BoundField DataField ="PrecioVenta"     HeaderText ="Precio unitario" />
                            <asp:BoundField DataField ="Tipo"            HeaderText ="Tipo" />
                            <asp:BoundField DataField ="Marca"           HeaderText ="Marca" />
                            <asp:BoundField DataField ="Stock"           HeaderText ="Stock" />
                            <asp:BoundField DataField ="Direccion"       HeaderText ="Sede" />
                            <asp:BoundField DataField ="IdAlmacen"       HeaderText ="IdAlmacen" Visible="false" />
                            <asp:TemplateField HeaderText="Agregar Producto">
                                <ItemTemplate>
                                    <asp:Button ID="btnAgregarProducto" runat="server"
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
                    
                    <h2 id="tituloVenta" runat="server"></h2>
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
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="Guardar"/>
                                    <asp:Button ID="btnDeleteItem" runat="server"
                                                CommandName="deleteItem" CssClass="btn btn-info btn-xs"
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
                            DataKeyNames="IdVenta, FechaRealizacion, NombreVendedor, PrecioTotal, IdAlmacen" AutoGenerateColumns="False"
                            style="text-align:center" AllowPaging="True" >
                        <RowStyle HorizontalAlign="center"></RowStyle>
                        <Columns>
                            <asp:BoundField DataField ="IdVenta"           HeaderText ="Codigo de venta" />
                            <asp:BoundField DataField ="FechaRealizacion"  HeaderText ="Fecha" />
                            <asp:BoundField DataField ="NombreVendedor"    HeaderText ="Vendedor" />
                            <asp:BoundField DataField ="PrecioTotal"       HeaderText ="Precio Total" />
                            <asp:BoundField DataField ="Total"             HeaderText ="Total(+IGV)" />
                            <asp:BoundField DataField ="IdAlmacen"           HeaderText ="Codigo de venta" Visible="false"/>
                            <asp:TemplateField HeaderText="Observacion" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtObservacion" Text='<%#Eval("Observacion") %>' runat="server"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:Button ID="btnEditVenta" runat="server"
                                                CommandName="editVenta" CssClass="btn btn-info btn-xs"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="Editar"/>
                                    <asp:Button ID="btnDeleteVenta" runat="server"
                                                CommandName="deleteVenta" CssClass="btn btn-info btn-xs"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="Eliminar"/>
                                    <asp:Button ID="btnFinalizarVenta" runat="server"
                                                CommandName="finalizarVenta" CssClass="btn btn-info btn-xs"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="Finalizar"/>
                                    <asp:Button ID="btnGenerarPDF" runat="server"
                                                CommandName="generarPDF" CssClass="btn btn-info btn-xs"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="Generar PDF"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    </ContentTemplate></asp:UpdatePanel>
    <div id="pop1" style="display:none ; width: 44%;  left: -8px;"">
        <div id="cerrar">X</div>
        <%--el boton para cerrar--%>
    <%--    <h1 style="padding: 25px 1px 15px 1px; font-size: 1.2em;">
            </h1>--%>
        <asp:Label runat="server" id="lblTituloPopup" ><h2>GENERAR BOLETA DE VENTA</h2><br /></asp:Label>
        <table class="table">
            <tr>
                <td><asp:Label runat="server" id="lblNombre" >NOMBRE</asp:Label></td>
                <td><asp:TextBox ID="textNombre" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" id="lblDni" >DNI</></asp:Label></td>
                <td><asp:TextBox ID="textDni" runat="server"></asp:TextBox><br /></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" id="lblRuc" >RUC</asp:Label></td>
                <td><asp:TextBox ID="textRuc" runat="server"></asp:TextBox><br /></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" id="lblDirec" >Direccion</asp:Label></td>
                <td><asp:TextBox ID="textDirec" runat="server"></asp:TextBox><br /></td>
            </tr>
        </table>
        <asp:Button ID="btnPdf" runat="server" BackColor="#0099FF" BorderColor="#3399FF" ForeColor="White" Text="Generar Boleta" Width="177px" OnClick="btnPdf_Click" />
    </div>
</body>