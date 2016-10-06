<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_GestionarComposicion.ascx.cs" Inherits="Indexx.pages.Adquisicion.WF_GestionarComposicion" %>


<body>
    <div>
        
        
        <asp:Label runat="server" ID="lbl1" Text="Composicion" AssociatedControlID="ddlComposicion"></asp:Label><br /><br />
        <asp:DropDownList runat="server" ID="ddlComposicion"></asp:DropDownList><br /><br />


        <asp:GridView ID="gvDetalleComposicion" runat="server"
                        AutoGenerateColumns="False" 
                        DataKeyNames="IdComposicion,Nombre,Restricciones,Detalle" 
                        AllowPaging="True">

                        <Columns>
                            <asp:BoundField DataField="IdComposicion" FooterText="IdComposicion" HeaderText="ID Composicion" Visible="true"/>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtNombreC" runat="server"  MaxLength="8" onChange="changeNombreC(event,this);"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField FooterText="Restricciones" HeaderText="Restriccion de marca">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblRestriccion" runat="server" disabled onChange="changeRestriccion(event,this);"></asp:TextBox>
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
        <br />
        <button runat="server" class="button btn-danger"  type="submit" OnServerClick="serC_OnServerClick" >Añadir Composicion</button>
       
    </div>
</body>