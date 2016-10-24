<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Cotizacion.ascx.cs" Inherits="Indexx.pages.Adquisicion.WF_Cotizacion1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--<asp:updatepanel ID="ps1" runat ="server">--%>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="popup" TargetControlID="lbltitulo" OkControlID="btnAceptar" BackgroundCssClass="overlay"></asp:ModalPopupExtender>--%>

    <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Seleccionar proveedor</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <label>Proveedor:</label>
                    <asp:TextBox ID="txtIdProveedor" runat="server"></asp:TextBox>
                    <asp:Button ID="btnBuscarProveedor" runat="server" Text="Buscar" OnClick="btnBuscarProveedor_Click" />
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Pedidos</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView runat="server" ID="dgvPedidos" CssClass="gridview bordered"  OnRowCommand="dgvPedidos_RowComand"
                        DataKeyNames="IdPedido, Estado, FechaRegistro"
                        AutoGenerateColumns="False" OnPageIndexChanging="dgvPedidos_PageIndexChanging" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="IdPedido"        HeaderText="N° Pedido" />
                            <asp:BoundField DataField="Estado"          HeaderText="Estado" />
                            <asp:BoundField DataField="FechaRegistro"   HeaderText="Fecha de Registro" />
                            <asp:TemplateField HeaderText="Ver">
                                    <ItemTemplate>
                                        <div class="text-center">
                                            <asp:ImageButton ID="btnVer" HeaderText="Ver" runat="server"
                                                ImageUrl="../../images/icon2.png" CommandName="Ver"
                                                formnovalidate=""
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </div>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                            </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Pedidos por proveedor</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView ID="dgvItems" runat="server" CssClass="gridview bordered" 
                        AutoGenerateColumns="False" OnPageIndexChanging="dgvItems_PageIndexChanging"
                        DataKeyNames="IdItem, Farmaco, TipoFarmaco, Cantidad, PrecioUnitario"
                        OnRowCommand="dgvItems_RowComand" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="IdItem"          HeaderText="N° Item" />
                            <asp:BoundField DataField="Farmaco"         HeaderText="Farmaco" />
                            <asp:BoundField DataField="TipoFarmaco"     HeaderText="Tipo de Farmaco" />
                            <asp:BoundField DataField="Cantidad"        HeaderText="Cantidad" />
                            <asp:BoundField DataField="PrecioUnitario"  HeaderText="Precio Unitario" />
                            <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <div class="text-center">
                                            <asp:ImageButton ID="btnEditar" HeaderText="Editar" runat="server"
                                                ImageUrl="../../images/icon3.png" CommandName="Editar"
                                                formnovalidate=""
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </div>
                                    </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <div class="text-center">
                                            <asp:ImageButton ID="btnEliminar" HeaderText="Eliminar" runat="server"
                                                ImageUrl="../../images/icon4.png" CommandName="Eliminar"
                                                formnovalidate=""
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </div>
                                    </ItemTemplate>
                            </asp:TemplateField>
                        </Columns> 
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <asp:Panel ID="panel2" runat="server" CssClass="InnerPopup" style="max-height: 500px; width:auto; overflow: auto;/*display:none*/">
        <div id="Div1" runat="server" style="max-height: 500px; width:auto; overflow: auto;">
        <div class="row">
            <div class="col-sm-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Editar</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                        </div>
                    <div class="x_content">
                        <label>Cantidad:</label>
                        <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                    </div>
                    <div class="x_content">
                        <label>Medida:</label>
                        <%--<asp:TextBox ID="txtMedida" runat="server"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddlMedida" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMedida_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="x_content">
                        <label>Cantidad de Medida:</label>
                        <asp:TextBox ID="txtCantidadM" runat="server"></asp:TextBox>
                    </div>
                    <div class="x_content">
                        <label>Precio:</label>
                        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                    </div>
                    <div class="x_content">
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                    </div>
                </div>
            </div>
        </div>
        </div>
    </asp:Panel>

    <div class="principal" style="height: 1241px">
       
        <div><asp:TextBox ID="txtIdPedido" runat="server" Visible="False" ></asp:TextBox>
            <asp:TextBox ID="txtIdProv" runat="server" Visible="False"></asp:TextBox>
        </div>

        <asp:GridView ID="dgvPedidoC" runat="server" CssClass="gridview bordered" 
            AutoGenerateColumns="False" OnPageIndexChanging="dgvPedidoC_PageIndexChanging"
            DataKeyNames="IdItem,Farmaco, TipoFarmaco, Cantidad, Medida, Precio"
            OnRowCommand="dgvPedidoC_RowComand" AllowPaging="True" PageSize="8" Height="161px" 
            Width="856px" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" >
            <Columns>
                <asp:BoundField DataField="IdItem" HeaderText="N° Item" />
                <asp:BoundField DataField="Farmaco" HeaderText="Farmaco" />
                <asp:BoundField DataField="TipoFarmaco" HeaderText="Tipo de Farmaco" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Medida" HeaderText="Medida" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
            </Columns>
                <EditRowStyle BorderColor="Black" BorderStyle="Solid" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle BorderColor="Black" BorderStyle="Solid" ForeColor="Black" HorizontalAlign="Center" />
                <SortedDescendingCellStyle BorderColor="blue" BorderStyle="Solid" ForeColor="blue"  HorizontalAlign="Center" VerticalAlign="Middle"/>
        </asp:GridView>

    </div>
<%--</asp:Content>--%>