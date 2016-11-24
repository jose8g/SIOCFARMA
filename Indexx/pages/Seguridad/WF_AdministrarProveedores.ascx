<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_AdministrarProveedores.ascx.cs" Inherits="Indexx.pages.Seguridad.WF_AdministrarProveedores" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
        #pop1
        {
            padding: 15px !important;
            height: auto !important;
        }
    </style>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="row">
            <div class="col-sm-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>REGISTRAR PROVEEDOR</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <h3>INGRESAR DATOS</h3>
                        <br />
                        <label>Nombre:</label>
                        <asp:TextBox ID="txtNombreProv" runat="server"></asp:TextBox>
                        <label>Dirección:</label>
                        <asp:TextBox ID="txtDireccionProv" runat="server"></asp:TextBox>
                        <label>Teléfono:</label>
                        <asp:TextBox ID="txtTelefonoProv" runat="server"></asp:TextBox>
                        <label>RUC:</label>
                        <asp:TextBox ID="txtRucProv" runat="server"></asp:TextBox>
                        <label>Correo:</label>
                        <asp:TextBox ID="txtCorreoProv" runat="server"></asp:TextBox>
                        <label>Responsable:</label>
                        <asp:TextBox ID="txtResponsableProv" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-info btn-xs" OnClick="btnRegistrar_Click" />  
                    </div>
                </div>
            </div>
        </div>
            
        <div class="row">
            <div class="col-sm-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>PROVEEDORES</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <h3>PROVEEDORES</h3>
                        <br />
                        <asp:GridView runat="server" ID="dgvProveedores" CssClass="gridview bordered table" 
                            AutoGenerateColumns="False" OnPageIndexChanging="dgvProveedores_PageIndexChanging"
                            DataKeyNames="IdProveedor, CodigoProveedor, Nombre, Direccion, Telefono, RUC, Correo, Responsable, Estado"
                            OnRowCommand="dgvProveedores_RowComand" AllowPaging="True" PageSize="12">
                            <Columns>
                                <asp:BoundField DataField="IdProveedor"         HeaderText="IdProveedor" Visible="false" />
                                <asp:BoundField DataField="CodigoProveedor"     HeaderText="Cod. de proveedor" />
                                <asp:BoundField DataField="Nombre"              HeaderText="Empresa" />
                                <asp:BoundField DataField="Direccion"           HeaderText="Dirección" />
                                <asp:BoundField DataField="Telefono"            HeaderText="Teléfono" />
                                <asp:BoundField DataField="RUC"                 HeaderText="RUC" />
                                <asp:BoundField DataField="Correo"              HeaderText="Correo" />
                                <asp:BoundField DataField="Responsable"         HeaderText="Responsable" />
                                <asp:BoundField DataField="Estado"              HeaderText="Estado" />
                                <asp:ButtonField ButtonType="Image" CommandName="Editar" HeaderText="Editar"  ImageUrl="../../images/icon3.png"  ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" CssClass="imggrillaedit btnCerrarSolicitud"/>
                                </asp:ButtonField>
                                <%--<asp:ButtonField ButtonType="Image"  CommandName="Eliminar" HeaderText="Eliminar" ImageUrl="../../images/icon4.png" 
                                     ItemStyle-HorizontalAlign="Center">
                                         <ItemStyle HorizontalAlign="Center" />
                                </asp:ButtonField>--%>
                                <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <div class="text-center">
                                            <asp:ImageButton ID="ImageButton1" HeaderText="Eliminar" runat="server"
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
</ContentTemplate>
</asp:UpdatePanel>


<div id="pop1" style="display:none; width: 44%;  left: -8px;"">
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
            Nombre:</label>
        <asp:TextBox ID="txtNombrepopup"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
        <label class="lblcampos" for="name">
           Dirección:</label>
        <asp:TextBox ID="txtDireccionpopup"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
        <label class="lblcampos" for="name">
           Teléfono:</label>
        <asp:TextBox ID="txtTelefonopopup"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server"></asp:TextBox>
        <label class="lblcampos" for="name">
           RUC:</label>
        <asp:TextBox ID="txtRucpopup"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server"></asp:TextBox>
            <br/>
        <label class="lblcampos" for="name">
           Correo:</label>
        <asp:TextBox ID="txtCorreopopup"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server"></asp:TextBox>
        <label class="lblcampos" for="name">
           Responsable:</label>
        <asp:TextBox ID="txtResponsablepopup"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server"></asp:TextBox>
            <br/>
            <br/>
        <label class="lblcampos" for="name">
           Estado:</label>
           <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="true" CssClass="ddl"
               OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" Width="298px">
               <asp:ListItem Value="0">Deshabilitado</asp:ListItem>
               <asp:ListItem Value="1">Habilitado</asp:ListItem>
                                    </asp:DropDownList>
           <%--<asp:TextBox ID="txtMedidapopup"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>--%>
            <br/>
            <br/>
        
        <br>
        <br />
        <asp:Button ID="btnAceptarPopUp" runat="server" Height="42px" class="w-button btncontent btncontenthover" Text="Guardar" Width="229px" OnClick="btnAceptarPopUp_Click" />
      </ContentTemplate>
        </asp:UpdatePanel>
</div>