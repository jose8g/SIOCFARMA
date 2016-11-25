<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Configuracion_Almacen.ascx.cs" Inherits="Indexx.pages.Seguridad.WebUserControl1" %>

<body>
    <asp:UpdatePanel id="panelX" runat="Server"><ContentTemplate>
    <div class="row">
        <div class="col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Almacenes</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:GridView ID="dgvAlmacenes" runat="server" CssClass="gridview bordered table text-center" OnRowCommand="gvItems_RowComand"
                            DataKeyNames="IdAlmacen" AutoGenerateColumns="False"
                            style="text-align:center" AllowPaging="True">
                        <RowStyle HorizontalAlign="center"></RowStyle>
                        <Columns>
                            <asp:BoundField DataField ="IdAlmacen"          HeaderText ="IdItem" Visible="false" />
                            <asp:BoundField DataField ="rownumber"          HeaderText ="#" />
                            <asp:BoundField DataField ="Direccion"          HeaderText ="Direccion" />
                            <asp:BoundField DataField ="Responsable"        HeaderText ="Responsable" />
                            <asp:BoundField DataField ="Capacidad"          HeaderText ="Capacidad" />
                            
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:Button ID="btnEditarAlmacen" runat="server"
                                                CommandName="editAlmacen" CssClass="btn btn-info btn-xs"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                Text="Editar"/>
                                    <asp:Button ID="btnEliminarAlmacen" runat="server"
                                                CommandName="deleteAlmacen" CssClass="btn btn-info btn-xs"
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
        <div class="col-sm-6">
            <div class="x_panel">
                <div class="x_title">
                    <h2>EDITAR</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:Label runat="server" id="lblDirec" >Direccion :</asp:Label>
                    <asp:TextBox ID="textDirec" runat="server" ReadOnly="true"></asp:TextBox><br />
                    <asp:Label runat="server" id="lblResp" >Responsable :</asp:Label>
                    <asp:TextBox ID="txtResp" runat="server" ReadOnly="true"></asp:TextBox><br />
                    <asp:Label runat="server" id="lblCapac" >Capacidad :</asp:Label>
                    <asp:TextBox ID="txtCapac" runat="server" ReadOnly="true"></asp:TextBox><br /><br />
                    <asp:Button ID="btn1" runat="server" Text="Guardar"  CssClass="btn btn-info btn-xs" OnClick="editarDatosAlmacen"/>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="x_panel">
                <div class="x_title">
                    <h2>NUEVO</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:Label runat="server" id="lblDirec2" >Direccion :</asp:Label>
                    <asp:TextBox ID="textDirec2" runat="server" ReadOnly="true"></asp:TextBox><br />
                    <asp:Label runat="server" id="lblResp2" >Responsable :</asp:Label>
                    <asp:TextBox ID="txtResp2" runat="server" ReadOnly="true"></asp:TextBox><br />
                    <asp:Label runat="server" id="lblCapac2" >Capacidad :</asp:Label>
                    <asp:TextBox ID="txtCapac2" runat="server" ReadOnly="true"></asp:TextBox><br /><br />
                    <asp:Button ID="btn2" runat="server" Text="Nuevo" CssClass="btn btn-info btn-xs" OnClick="habilitarNuevoAlmacen"/>
                    <asp:Button ID="btn3" runat="server" Text="Confirmar" CssClass="btn btn-info btn-xs" OnClick="registrarAlmacen"/>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
    </div>
    </ContentTemplate></asp:UpdatePanel>
</body>