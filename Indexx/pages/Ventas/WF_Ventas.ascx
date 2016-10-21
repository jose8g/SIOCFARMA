<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Ventas.ascx.cs" Inherits="Indexx.pages.Ventas.WF_Ventas" %>

<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .bordered {}
</style>
<body>
    <asp:UpdatePanel id="panelX" runat="Server"><ContentTemplate>

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
                        <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="getItemsByNombre"/>
                        </td>
                    </tr>
                <br />
                    <tr>
                        <td>BUSCAR PRODUCTOS POR MARCAS</td>
                        <td>
                            <asp:DropDownList ID="ddlMarca" CssClass="ddl" Width="150px" runat="server" AutoPostBack="True" onselectedindexchanged="itemSelected" style="margin-bottom: 0px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <br />
            </div>
        </div>
    </div>
    <br />
    <div class="col-sm-12">
        <div class="x_panel">
            <div class="x_title">
                <h2>ITEMS</h2>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <asp:GridView ID="dgvItems" runat="server" CssClass="gridview bordered table text-center" OnRowCommand="gvItems_RowComand"
                        DataKeyNames="IdItem,Nombre,PrecioVenta"
                        AutoGenerateColumns="False" OnPageIndexChanging="gvItems_PageIndexChanging"
                         style="text-align:center"
                        AllowPaging="True" >
                    <RowStyle HorizontalAlign="center"></RowStyle>
                    <Columns>
                        <asp:BoundField DataField="IdItem"          HeaderText="IdItem" Visible="false" />
                        <asp:BoundField DataField="Nombre"          HeaderText ="Item" />
                        <asp:BoundField DataField="PrecioVenta"     HeaderText="Precio"/>
                        <asp:BoundField DataField="Estado"          HeaderText="Estado"/>
                        <asp:TemplateField HeaderText="AgregarProducto">
                            <ItemTemplate>
                                <asp:Button ID="btnAgregarProducto" runat="server"
                                            CommandName="agregarItems" CssClass="btn btn-info btn-xs"
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
    <br />
    <div class="col-sm-12">
        <div class="x_panel">
            <div class="x_title">
                <h2>DETALLE DEL ITEM
                </h2>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">

                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <br />
    &nbsp;<!--p>
    <input id="Text8" type="text" runat="server" />
    </p-->
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
                <p>
                    <asp:GridView ID="dgvCarrito" runat="server" CssClass="gridview bordered"
                            AutoGenerateColumns="False" OnPageIndexChanging="gvItems_PageIndexChanging"
                            DataKeyNames="IdItem"
                            OnRowCommand="gvItems2_RowComand" style="text-align:center"
                            AllowPaging="True" PageSize="8" Width="497px" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" >
                        <RowStyle HorizontalAlign="center"></RowStyle>
                        <Columns>
                            <asp:BoundField DataField="IdItem"          HeaderText="IdItem"/>
                        </Columns>
                        <EditRowStyle BorderColor="Black" BorderStyle="Solid" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle BorderColor="Black" BorderStyle="Solid" ForeColor="Black" HorizontalAlign="Center" />
                        <SortedDescendingCellStyle BorderColor="blue" BorderStyle="Solid" ForeColor="blue"  HorizontalAlign="Center" VerticalAlign="Middle"/>
                    </asp:GridView>
                    <br />
                </p>
            </div>
        </div>
    </div>
    
    </ContentTemplate></asp:UpdatePanel>
</body>