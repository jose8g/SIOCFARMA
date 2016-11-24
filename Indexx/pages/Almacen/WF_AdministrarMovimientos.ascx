<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_AdministrarMovimientos.ascx.cs" Inherits="Indexx.pages.Almacen.WF_AdministrarMovimientos" %>


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
            </div>
                </div>
       <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
             <div class="x_content">
                    <asp:GridView runat="server" ID="dgvCompras" CssClass="gridview bordered table"  OnRowCommand="dgvCompras_RowCommand"
                        DataKeyNames="IdComposicionxItem,IdItem,Nombre,Cantidad,Medida"
                            AutoGenerateColumns="False" OnPageIndexChanging="dgvCompras_PageIndexChanging">
                        <Columns>
                                <asp:BoundField DataField="IdComposicionxItem" HeaderText="Id" Visible="false"/>
                                <asp:BoundField DataField="IdItem" HeaderText="Id" Visible="false"/>
                                <asp:BoundField DataField="Nombre" HeaderText="Composicion" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"        />
                                <asp:BoundField DataField="Medida"      HeaderText="Medida"  />
                           
                            </Columns>
                    </asp:GridView>
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
                        <asp:Button ID="Button1" runat="server" Text="Buscar" />
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
                    </caption>
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
           
        </div>
    </div>
    <br />
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
                        <td><input id="Text1" type="text" runat="server"/>
                        <asp:Button ID="Button2" runat="server" Text="Buscar"/>
                        </td>
                    </tr>
                    <caption>
                        <br />
                        <tr>
                            <td>BUSCAR PRODUCTOS POR MARCAS</td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="ddl"  style="margin-bottom: 0px" Width="150px">
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

        </div>
    </div>
    <br />
    </asp:panel>
    </ContentTemplate></asp:UpdatePanel>
</body>