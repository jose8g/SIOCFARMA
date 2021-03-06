﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Cotizacion.ascx.cs" Inherits="Indexx.pages.Adquisicion.WF_Cotizacion1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--<asp:updatepanel ID="ps1" runat ="server">--%>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="popup" TargetControlID="lbltitulo" OkControlID="btnAceptar" BackgroundCssClass="overlay"></asp:ModalPopupExtender>--%>
<link href="../../css/normalize.css" type="text/css" rel="stylesheet" />
<link href="../../css/webflow.css" type="text/css" rel="stylesheet" />
<link href="../../css/css-informacion/quitocom.webflow.css" rel="stylesheet"type="text/css" />
<script src="../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

<script src="../../js/pop1.js"type="text/javascript"></script>
<link href="../../css/pop1.css" type="text/css" rel="stylesheet" />

<script src="../../Scripts/jquery-1.8.2.min.js"></script>
<script src="../../js/jquery-1.4.1.min.js"></script>

<style>
        .lblcampos{float:left;}
        .none
        {
            display:none;
            }
            .txtcampos{
    }
    #alertModal
    {
        
        width: auto!important;
height: auto!important;}
       #pop1
       {top: 55px !important;
           padding: 15px !important;
    height: auto  !important;
           }
      
        #HeadContent_ConsultarSolicitudCotizacion2_gvDetallePopUp
         {
        width: 500px !important;
        }
        #pop1
        {
            padding: 15px !important;
            height: auto !important;
        }
    </style>

<script>
    function SoloNumeros(e) {
        var iKeyCode = 0;
        if (window.event)
            iKeyCode = window.event.keyCode
        else if (e)
            iKeyCode = e.which;
        if ((iKeyCode > 47 && iKeyCode < 58) || (iKeyCode == 8))
            return true
        else
            return false;
    }
    function SoloNumerosypunto(e) {
        var iKeyCode = 0;
        if (window.event)
            iKeyCode = window.event.keyCode
        else if (e)
            iKeyCode = e.which;
        if ((iKeyCode > 47 && iKeyCode < 58) || (iKeyCode == 8) || (iKeyCode == 46))
            return true
        else
            return false;
    }
</script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
<%--    <div class="row">
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
    </div>--%>

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
                    <asp:GridView runat="server" ID="dgvPedidos" CssClass="gridview bordered table"  OnRowCommand="dgvPedidos_RowComand"
                        DataKeyNames="IdPedido, Estado, FechaRegistro"
                        AutoGenerateColumns="False" OnPageIndexChanging="dgvPedidos_PageIndexChanging" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="IdPedido"        HeaderText="N° Pedido" />
                            <asp:BoundField DataField="Estado"          HeaderText="Estado" />
                            <asp:BoundField DataField="FechaRegistro"   HeaderText="Fecha de Registro" />
                            <asp:TemplateField HeaderText="Ver">
                                    <ItemTemplate>
                                        <div class="text-center">
                                            <%--<asp:ImageButton ID="btnVers" HeaderText="Ver" runat="server"
                                                ImageUrl="../../images/icon2.png" CommandName="Ver"
                                                formnovalidate=""
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />--%>
                                            <asp:Button ID="btnVer" HeaderText="Ver" runat="server" 
                                                        CommandName="Ver" CssClass="btn btn-info btn-xs"
                                                        formnovalidate=""
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        Text="Ver"/>
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
                    <asp:GridView ID="dgvItems" runat="server" CssClass="gridview bordered table" 
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
                                                formnovalidate="" CssClass="imggrillaedit btnCerrarSolicitud"
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

    <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2></h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView runat="server" ID="dgvPedidoC" CssClass="gridview bordered table" OnRowCommand="dgvPedidoC_RowComand"
                        DataKeyNames="IdItem,IdPedido,Nombre, Medida, Farmaco, CantidadLote, Cantidad, PrecioUnitario, Total"
                        AutoGenerateColumns="False" OnPageIndexChanging="dgvPedidoC_PageIndexChanging" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="IdItem" HeaderText="IdItem" Visible="false" />
                            <asp:BoundField DataField="IdPedido" HeaderText="N° Pedido" />
                            <asp:BoundField DataField="Nombre" HeaderText="Proveedor" />
                            <asp:BoundField DataField="Medida" HeaderText="Medida" />
                            <asp:BoundField DataField="Farmaco" HeaderText="Farmaco" />
                            <asp:BoundField DataField="CantidadLote" HeaderText="Cant. Lote" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio" />
                            <asp:BoundField DataField="Total" HeaderText="Total" />
                            <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <div class="text-center">
                                            <asp:ImageButton ID="btnEliminar" HeaderText="Eliminar" runat="server"
                                                ImageUrl="../../images/icon4.png" CommandName="Eliminar" AllowPaging="True"
                                                formnovalidate="" onclientclick="return confirm('¿Desea eliminar el item?');"
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
    
    <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Subtotal</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:Label ID="lblNombreCot" runat="server" Text="Nombre de la Cotización:" Visible="False"></asp:Label>
                        <asp:TextBox ID="txtNombreCot" runat="server" Visible="False"></asp:TextBox>
                        <br/>
                        <asp:Label ID="lblDescuento" runat="server" Text="Descuento:" Visible="False"></asp:Label>
                        <asp:TextBox ID="txtDescuento" runat="server" Visible="False"></asp:TextBox>
                        <br/>
                        
                    <br/>

                    <asp:GridView runat="server" ID="dgvSubtotal" CssClass="gridview bordered table" OnRowCommand="dgvSubtotal_RowComand"
                        DataKeyNames="SubTotal"
                        AutoGenerateColumns="False" OnPageIndexChanging="dgvSubtotal_PageIndexChanging" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" />
                            <asp:TemplateField HeaderText="Cotizar">
                                    <ItemTemplate>
                                        <div class="text-center">
                                            <asp:Button ID="btnCotizar" HeaderText="Cotizar" runat="server" 
                                                        CommandName="Cotizar" CssClass="btn btn-info btn-xs"
                                                        formnovalidate=""
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        Text="Cotizar"/>
                                        </div>
                                    </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Finalizar">
                                    <ItemTemplate>
                                        <div class="text-center">
                                            <asp:Button ID="btnFinalizar" HeaderText="Finalizar" runat="server" 
                                                        CommandName="Finalizar" CssClass="btn btn-info btn-xs"
                                                        formnovalidate=""
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        Text="Finalizar"/>
                                        </div>
                                    </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                    </asp:GridView>

                     <br/>

                    <asp:GridView runat="server" ID="dgvTotal" CssClass="gridview bordered table"
                        DataKeyNames="NumCotizacion,NombreCotizacion,FechaRegistro,PreTotal,Descuento,Total"
                        AutoGenerateColumns="False" OnPageIndexChanging="dgvTotal_PageIndexChanging" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="NumCotizacion" HeaderText="N° Cotizacion" />
                            <asp:BoundField DataField="NombreCotizacion" HeaderText="Nombre" />
                            <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Registro" />
                            <asp:BoundField DataField="PreTotal" HeaderText="PreTotal" />
                            <asp:BoundField DataField="Descuento" HeaderText="Descuento" />
                            <asp:BoundField DataField="Total" HeaderText="Total" />
                            </Columns>
                    </asp:GridView>
                   
                </div>
            </div>
        </div>
    </div>

    <div class="principal" style="height: 1241px">
       
        <div>
            <asp:TextBox ID="txtIdDDL" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="txtEx" runat="server" Visible="False"></asp:TextBox>
        </div>

        <asp:GridView ID="dgvExistente" runat="server" CssClass="gridview bordered table" 
            AutoGenerateColumns="False" OnPageIndexChanging="dgvExistente_PageIndexChanging"
            DataKeyNames="Existente"
            AllowPaging="True" PageSize="8" Height="161px" 
            Width="856px" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" Visible="False" >
            <Columns>
                <asp:BoundField DataField="Existente" HeaderText="Existente" />
            </Columns>
                <EditRowStyle BorderColor="Black" BorderStyle="Solid" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle BorderColor="Black" BorderStyle="Solid" ForeColor="Black" HorizontalAlign="Center" />
                <SortedDescendingCellStyle BorderColor="blue" BorderStyle="Solid" ForeColor="blue"  HorizontalAlign="Center" VerticalAlign="Middle"/>
        </asp:GridView>

        <asp:GridView ID="dgvLote" runat="server" CssClass="gridview bordered table" 
            AutoGenerateColumns="False" OnPageIndexChanging="dgvLote_PageIndexChanging"
            DataKeyNames="Cantidad"
            AllowPaging="True" PageSize="8" Height="161px" 
            Width="856px" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" Visible="False" >
            <Columns>
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            </Columns>
                <EditRowStyle BorderColor="Black" BorderStyle="Solid" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle BorderColor="Black" BorderStyle="Solid" ForeColor="Black" HorizontalAlign="Center" />
                <SortedDescendingCellStyle BorderColor="blue" BorderStyle="Solid" ForeColor="blue"  HorizontalAlign="Center" VerticalAlign="Middle"/>
        </asp:GridView>

    </div>
                                    </ContentTemplate>
        </asp:UpdatePanel>
<%--</asp:Content>--%>

<div id="pop1" style="display:none ; width: 44%;  left: -8px;"">
        <div id="cerrar">
            X</div>
        <%--el boton para cerrar--%>
    <%--    <h1 style="padding: 25px 1px 15px 1px; font-size: 1.2em;">
            </h1>--%>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
        <asp:Label runat="server" id="lblTituloPopup" >EDITAR</asp:Label>
        <br>       
        <br/>
        <label class="lblcampos" for="name">
            Cantidad:</label>
        <asp:TextBox ID="txtCantidadpopup"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
        <label class="lblcampos" for="name">
           Medida:</label>
            <br/>
           <asp:DropDownList ID="ddlMedida" runat="server" AutoPostBack="true" CssClass="ddl"
               OnSelectedIndexChanged="ddlMedida_SelectedIndexChanged" Width="298px"></asp:DropDownList>
           <%--<asp:TextBox ID="txtMedidapopup"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>--%>
            <br/>
            <br/>
        <label class="lblcampos" for="name">
           Cantidad de Medida:</label>
        <asp:TextBox ID="txtCantidadMpopup"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtResulCantMpopup"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" Visible="false"></asp:TextBox>
        <label class="lblcampos" for="name">
           Precio:</label>
        <asp:TextBox ID="txtPreciopopup"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server"></asp:TextBox>
        <br>
        <br />
        <asp:Button ID="btnAceptarPopUp" runat="server" Height="42px" class="w-button btncontent btncontenthover" Text="Guardar" Width="229px" OnClick="btnAceptarPopUp_Click" />
      </ContentTemplate>
        </asp:UpdatePanel>
</div>