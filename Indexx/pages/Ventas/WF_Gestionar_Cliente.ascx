<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Gestionar_Cliente.ascx.cs" Inherits="Indexx.pages.Ventas.WF_Gestionar_Cliente" %>

<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .bordered {}
</style>

<body>
    <asp:UpdatePanel id="panelX" runat="Server"><ContentTemplate>
        <div class="row">
             <div class="col-sm-12" style="display:;">
                 <div class="x_panel">
                     <div class="x_title">
                        <h2>ITEMS BAJO STOCK </h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                     <div class="x_content" style="text-align:center">
                         <td>Nombre de cliente</td><br />
                         <td><input id="NombreCliente" type="text" runat="server"/><br /><br />
                         <td>Dirección</td><br />
                         <td><input id="DireccionCliente" type="text" runat="server"/><br /><br />
                         <td>Teléfono</td><br />
                         <td><input id="TelefonoCliente" type="text" runat="server"/><br /><br />
                         <td>Correo electrónico</td><br />
                         <td><input id="CorreoCliente" type="text" runat="server"/><br /><br />
                         <td>DNI</td><br />
                         <td><input id="Dni" type="text" runat="server"/><br /><br />
                         <td>Empresa</td><br />
                         <td><input id="Empresa" type="text" runat="server"/><br /><br />
                         <asp:Button ID="btnRegistrarCliente" runat="server" Text="Registrar" OnClick="insertCliente" CssClass="btn btn-info btn-xs"/>
                        </td>
                     </div>
                 </div>
             </div>
        </div>
        
        <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Clientes</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView ID="dgvClientes" runat="server" CssClass="gridview bordered table text-center" OnRowCommand="gvClientes_RowComand"
                            DataKeyNames="IdCliente" AutoGenerateColumns="False" OnPageIndexChanging="gvCliente_PageIndexChanging"
                            style="text-align:center" AllowPaging="True">
                        <RowStyle HorizontalAlign="center"></RowStyle>
                        <Columns>
                            <asp:BoundField DataField ="IdCliente"          HeaderText ="IdCliente" Visible="false" />
                            <asp:BoundField DataField ="Nombre"          HeaderText ="Nombre" />
                            <asp:BoundField DataField ="Direccion"     HeaderText ="Direccion" />
                            <asp:BoundField DataField ="Telefono"            HeaderText ="Telefono" />
                            <asp:BoundField DataField ="Correo"           HeaderText ="Correo" />
                            <asp:BoundField DataField ="Dni"           HeaderText ="DNI" />
                            <asp:BoundField DataField ="Empresa"           HeaderText ="Empresa" />
                            <asp:TemplateField HeaderText="Eliminar Cliente">
                                <ItemTemplate>
                                    <asp:Button ID="btnEliminarProducto" runat="server"
                                                CommandName="DeleteCliente" CssClass="btn btn-info btn-xs"
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
    </ContentTemplate></asp:UpdatePanel>
</body>