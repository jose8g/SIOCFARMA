<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_GestionarProducto.ascx.cs" Inherits="Indexx.pages.Adquision.WF_GestionarProducto" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="../../css/normalize.css" type="text/css" rel="stylesheet" />
<link href="../../css/webflow.css" type="text/css" rel="stylesheet" />
<link href="../../css/css-informacion/quitocom.webflow.css" rel="stylesheet"type="text/css" />
<script src="../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

<script src="../../js/pop1.js"></script>
<link href="../../css/pop1.css" rel="stylesheet" />
<script src="../../js/pop3.js"></script>
<link href="../../css/pop3.css" rel="stylesheet" />
<script src="../../js/pop5.js"></script>
<link href="../../css/pop5.css" rel="stylesheet" />

<script src="../../Scripts/jquery-1.8.2.min.js"></script>
<script src="../../js/jquery-1.4.1.min.js"></script>

<script language="javascript" type="text/javascript">
    function ocultar() {
        $("#pop1").fadeIn('slow');
    }

    function ocultar3() {
        $("#pop3").fadeIn('slow');
    }


    function ocultar5() {
        $("#pop5").fadeIn('slow');
    }
</script>

<style>

        .lblcampos{float:left;}
        .none
        {
            display:none;
            }
            .txtcampos{width:500px !important ;}
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

        #pop3
       {
            top: 55px !important;
           padding: 15px !important;
    height: auto  !important;
           }3
        {
            padding: 15px !important;
            height: auto !important;
        }

        #pop5
       {top: 55px !important;
           padding: 15px !important;
    height: auto  !important;
           }
        #pop5
        {
            padding: 15px !important;
            height: auto !important;
        }
    </style>
<body>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
    <div class="row">
        <div class="col-sm-6">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Administracion de Productos </h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Nombre del Producto</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    </div>
                </div>
                <div class="x_content">
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Precio de Venta</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtPreVenta" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    </div>
                </div>
                <div class="x_content">
                    <label>Tipo del producto</label>
                    <asp:DropDownList ID="ddlTipo"  CssClass="ddl" runat="server" AutoPostBack="True">
                        <asp:ListItem>Selec. Tipo</asp:ListItem>
                    </asp:DropDownList>
                </div>
                 <div class="x_content">
                    <label>Marca del producto</label>
                    <asp:DropDownList ID="ddlMarca"  CssClass="ddl" runat="server" AutoPostBack="True">
                        <asp:ListItem>Selec. Marca</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAgregarMarca" runat="server" 
                  class="btn btn-info btn-xs btnCerrarSolicitud2" 
                  Text="Nueva Marca" onclick="AgregarMarca" Width="119px" />
                   </div>
                <div class="x_content">
                    <label>Estado</label>
                    <asp:DropDownList ID="ddlEstado"  CssClass="ddl" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0">Selec. Estado</asp:ListItem>
                        <asp:ListItem Value="1">Habilitado</asp:ListItem>
                        <asp:ListItem Value="2">Desabilitado</asp:ListItem>
                    </asp:DropDownList>
                </div>
               <div class="x_content">
                    <asp:Button runat="server" class="btn btn-info btn-xs " Text="Agregar Producto" onclick="AñadirProductos" />
                    </div> 
        </div>
    </div>
   </div>


    <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Añadir Composicion </h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <label>Composicion</label>
                    <asp:DropDownList ID="ddlComposicion" CssClass="ddl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlComposicion_SelectedIndexChanged">
                        <asp:ListItem>Selec. Tipo</asp:ListItem>
                    </asp:DropDownList>
                
                    &nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button ID="btnNewComposicion" runat="server" 
                  class=" btn btn-info btn-xs  btnCerrarSolicitud3" 
                  Text="Nueva Composicion" onclick="AgregarComposicion" Width="119px" />
                  </div>
                <asp:Panel runat="server" ID="Panel3" Visible="false">
        <br>       
        <br/>
                    <div class="x_content">
        <label class="lblcampos" for="name">
            Nombre Composicion:</label>
        <asp:TextBox ID="txtNombreComp"   enable="false" CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
        </div>
                    <div class="x_content">
        <label class="lblcampos" for="name">
           Restricciones:</label>
           <asp:TextBox ID="txtRestricionComp"  enable="false"  CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
                        </div>
                        <div class="x_content">
         <label class="lblcampos" for="name">
           Medida:</label>
           <asp:TextBox ID="txtMedidaComp"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
                            </div>
                    <div class="x_content">
          <label class="lblcampos" for="name">
           Cantidad:</label>
           <asp:TextBox ID="txtCantidadComp"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
                        </div>
        <br>
        <br />
        <asp:Button ID="btnAgrComposicion" runat="server" Height="42px" class="btn btn-info btn-xs" Text="Guardar" Width="229px" OnClick="AgregarComposicionItem"/>
       
        </asp:Panel>

         <br>
        <br />
                <div class="x_content">
                    <asp:GridView runat="server" ID="dgvProdictoComposicion" CssClass="gridview bordered table"  OnRowCommand="dgvProdictoComposicion_RowCommand"
                        DataKeyNames="IdComposicionxItem,IdItem,Nombre,Cantidad,Medida"
                            AutoGenerateColumns="False" OnPageIndexChanging="dgvProdictoComposicion_PageIndexChanging">
                        <Columns>
                                <asp:BoundField DataField="IdComposicionxItem" HeaderText="Id" Visible="false"/>
                                <asp:BoundField DataField="IdItem" HeaderText="Id" Visible="false"/>
                                <asp:BoundField DataField="Nombre" HeaderText="Composicion" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"        />
                                <asp:BoundField DataField="Medida"      HeaderText="Medida"  />
                            <asp:TemplateField HeaderText="Editar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEditar" HeaderText="Editar" CssClass="img"  runat="server"
                                        ImageUrl="../../images/cotizar.png" CommandName="Editar" Width="30px" 
                                        formnovalidate CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEditar" HeaderText="Editar" CssClass="img"  runat="server"
                                        ImageUrl="../../images/img/eliminar.ico" CommandName="Eliminar" Width="30px" 
                                        formnovalidate CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
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
                    <h2>Añadir Proveedor </h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <label>Proveedor:</label>
                    <asp:DropDownList ID="ddlProveedor" CssClass="ddl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged">
                        <asp:ListItem>Selec. Proveedor</asp:ListItem>
                    </asp:DropDownList>
                </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button id="btnNewProveedor1" runat="server" Text="Nuevo Proveedor" class="btn btn-info btn-xs btnCerrarSolicitud5" OnClick="AgregarProveedor"/>
<br>
        <br />


                <div class="x_content">
                    <asp:GridView runat="server" ID="dgvProductoProveedor1" CssClass="gridview bordered table"  OnRowCommand="dgvProductoProveedor_RowCommand"
                        DataKeyNames="IdProveedorxItem,CodigoProveedor,Nombre,Responsable,RUC,Direccion"
                            AutoGenerateColumns="False" OnPageIndexChanging="dgvProductoProveedor_PageIndexChanging">
                        <Columns>
                                <asp:BoundField DataField="IdProveedorxItem" HeaderText="Id" Visible="false"/>
                                <asp:BoundField DataField="CodigoProveedor" HeaderText="Id"/>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Responsable" HeaderText="Responsable"        />
                                <asp:BoundField DataField="RUC"      HeaderText="RUC"  />
                                <asp:BoundField DataField="Direccion"      HeaderText="Direccion"  />
                                <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEditar" HeaderText="Editar" CssClass="img"  runat="server"
                                        ImageUrl="../../images/img/eliminar.ico" CommandName="Eliminar" Width="30px" 
                                        formnovalidate CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
       </ContentTemplate> </asp:UpdatePanel>
</body>       
        
   <div id="pop1" style="display:none; width: 60%; left: 100.5px; top: 660px;">
        <div id="cerrar">
            X</div>
        <%--el boton para cerrar--%>
    <%--    <h1 style="padding: 25px 1px 15px 1px; font-size: 1.2em;">
            </h1>--%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
        <asp:Label runat="server" id="lblTituloPopup" >Agregar Nueva Marca </asp:Label>
        <br>       
        <br/>
                                    <div class="x_content">
        <label class="lblcampos" for="name">
            Nombre Marca:</label>
        <asp:TextBox ID="txtNombreMarca"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
                                        </div>
                                    <div class="x_content">
        <label class="lblcampos" for="name">
           Descripcion:</label>
           <asp:TextBox ID="txtDescripcionMarca"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
                                        </div>
        <br>
        <br />
        <asp:Button ID="btnGuardarPopUpMarca" runat="server" Height="42px" class="w-button btncontent btncontenthover" Text="Guardar" Width="229px" OnClick="AgregarNewMarca"/>
      </ContentTemplate>
        </asp:UpdatePanel>
       
        </div>

    <div id="pop3" style="display:none; width: 60%; left: 100.5px; top: 660px;">
        <div id="cerrar3">
            X</div>
        <%--el boton para cerrar--%>
    <%--    <h1 style="padding: 25px 1px 15px 1px; font-size: 1.2em;">
            </h1>--%>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
        <asp:Label runat="server" id="Label1" >Agregar Nueva Composicion </asp:Label>
        <br>       
        <br/>
                                    <div class="x_content">
        <label class="lblcampos" for="name">
            Composicion:</label>
        <asp:TextBox ID="txtAgrNombre"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
                                        </div>
                                    <div class="x_content">
        <label class="lblcampos" for="name">
           Restricciones:</label>
           <asp:TextBox ID="txtAgrRestriccion"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
                                        </div>
        <br>
        <br />
        <asp:Button ID="btnNewComposi" runat="server" Height="42px" class="w-button btncontent btncontenthover" Text="Guardar" Width="229px" OnClick="AgregarNewComposicion"/>
      </ContentTemplate>
        </asp:UpdatePanel>  
        </div>

    


<div id="pop5" style="display:none; width: 60%; left: 100.5px; top: 660px;">
        <div id="cerrar5">
            X</div>
    <%--el boton para cerrar--%>
    <%--    <h1 style="padding: 25px 1px 15px 1px; font-size: 1.2em;">
            </h1>--%>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
        <asp:Label runat="server" id="Label4" >Agregar Nuevo Proveedor </asp:Label>
        <br>       
        <br/>
                                    <div class="x_content">
        <label class="lblcampos" for="name">
           Nombre Empresa:</label>
           <asp:TextBox ID="txtAgrNombrePro"  enable="false"  CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
                                        </div>
                                    <div class="x_content">
         <label class="lblcampos" for="name">
           Direccion:</label>
           <asp:TextBox ID="txtAgrDireccion"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
                                        </div>
                                        <div class="x_content">
          <label class="lblcampos" for="name">
           Telefono:</label>
           <asp:TextBox ID="txtAgrTelefono"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
                                            </div>
                                    <div class="x_content">
          <label class="lblcampos" for="name">
           RUC:</label>
           <asp:TextBox ID="txtAgrRuc"  enable="false"  CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
                                        </div>
                                    <div class="x_content">
         <label class="lblcampos" for="name">
           Correo:</label>
           <asp:TextBox ID="txtAgrCorreo"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
                                        </div>
                                    <div class="x_content">
          <label class="lblcampos" for="name">
           Responsable:</label>
           <asp:TextBox ID="txtAgrResponsable"   CssClass="w-input txtcampos areadescriptionpopUp"
            runat="server" ></asp:TextBox>
                                        </div>
        <br>
        <br />
        <asp:Button ID="btnNewProveedor" runat="server" Height="42px" class="w-button btncontent btncontenthover" Text="Guardar" Width="229px" OnClick="AgregarNewProveedor"/>
      </ContentTemplate>
        </asp:UpdatePanel>
       
        </div>
