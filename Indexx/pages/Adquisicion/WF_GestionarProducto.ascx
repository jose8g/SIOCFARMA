<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_GestionarProducto.ascx.cs" Inherits="Indexx.pages.Adquision.WF_GestionarProducto" %>

<link href="../../css/PoPupAgregarMarca.css" rel="stylesheet" />
<script src="../../js/PoPupAgregarMarca.js"></script>


<script src="../../Scripts/jquery-1.8.2.min.js"></script>
<script src="../../js/jquery-1.4.1.min.js"></script>
<script type="text/javascript">
    var Q3 = jQuery.noConflict();
    </script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        jQuery(".popAgregarMarca").show();
    });
    jQuery(".btnBuscarClick").live("click", function () {
        if (vAccion == 1) {
            jQuery(".popAgregarMarca").fadeIn('slow');
        }
    });
    </script>

<style type="text/css">
    .lbl11 {
        float: none;
        color: white;
    }

    #popAgregarMarca{
         top: -180px !important;
    padding: 15px !important;
    height: auto !important;
    margin-top: 600px !important;
    width: 40% !important;
    margin-left: -25px;
    
    }
    .lblcamposNEGRO {
        float: left;
    color: #222;
    
    }

</style>
<body>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
    <div class="row">
        <div class="col-sm-6">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Añadir Nuevo Producto </h2>
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
                    <asp:Button runat="server" Text="Agregar Marca"  OnClick="AgregarMarca"/>
                   </div>
                <asp:Panel id="Panel1" class="x_content" runat="server" Visible ="false">
                    <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Nombre</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtNombreC" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Descripcion</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtDesC" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" Text="Agregar Nueva Marca"  OnClick="AgregarNewMarca"/>
                   </asp:Panel>
                <div class="x_content">
                    <label>Estado</label>
                    <asp:DropDownList ID="ddlEstado"  CssClass="ddl" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0">Selec. Estado</asp:ListItem>
                        <asp:ListItem Value="1">Habilitado</asp:ListItem>
                        <asp:ListItem Value="2">Desabilitado</asp:ListItem>
                    </asp:DropDownList>
                </div>
               <div class="x_content">
                    <asp:Button runat="server" Text="Agregar Producto" onclick="AñadirProductos" />
                    </div> 
        </div>
    </div>
   </div>
   </ContentTemplate> </asp:UpdatePanel>

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
                    <asp:DropDownList ID="ddlComposicion"  CssClass="ddl" runat="server" AutoPostBack="True">
                        <asp:ListItem>Selec. Tipo</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="x_content">
                    <asp:Button runat="server" Text="AgregarComposicion" onclick="AñadirComposicion"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    </div> 
 
                    <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">cantidad</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtNomCan" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    <label id="lbldesmed" class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Medida</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="txtDESmED" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" Text="Agregar Composicion"  OnClick="AgregarComposicion"/>
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
       
        
   <div id="popAgregarMarca" style=" width: 44%; left: 314px; top: 660px;">
        <div id="cerrarpopCotizarServicio">
            X
        </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <label class="lblcamposTitulo" for="name">Detalle de la Cotizacion</label>
               <br />
               <br />
           <label class="lblcamposNEGRO" for="name">Nombre Marca:</label>
          <input class="w-input txtcampos" type="text" name="txtname" 
              data-name="Name" id="txtMarcapopAgregarMarca" runat="server"
              ></input>
                <br />
           <label class="lblcamposNEGRO" for="name">Descripcion:</label>
             <input class="w-input txtcampos" type="text" name="txtname" data-name="Name" id="txtDescripcionpopAgregarMarca" runat="server"></input>              
                     <asp:Button class="w-button btncontent btncontenthover" ID="btnAgegarMarca" runat="server"
                    Text="Guardar"   />
                       </ContentTemplate>
        </asp:UpdatePanel>     
       
        </div>
</body>