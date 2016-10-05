<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_GestionarMarca.ascx.cs" Inherits="Indexx.pages.Adquisicion.WF_GestionarMarca" %>


<body>
    <div>
        
        
        <asp:Label runat="server" ID="lbl1" Text="Marca" AssociatedControlID="ddlMarca"></asp:Label><br /><br />
        <asp:DropDownList runat="server" Width="150px" AutoPostBack="True" ID="ddlMarca"></asp:DropDownList>

        <asp:GridView ID="gvDetalleMarca" runat="server" 
                        AutoGenerateColumns="false"
                        DataKeyNames="IdMarca,Nombre,Descripcion,Detalle" 
                        AllowPaging="False">

                        <Columns>
                            <asp:BoundField DataField="IdMarca" FooterText="IdMarca" HeaderText="ID Marca" Visible="true"/>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtNombreM" runat="server"  MaxLength="8" onChange="changeNombreM(event,this);"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField FooterText="Descripcion" HeaderText="Descripcion de marca">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblDescripcionM" runat="server" onChange="changeDescripcionM(event,this);"></asp:TextBox>
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
        <asp:Button ID="btnAgregarMarca" runat="server" OnClick="btnAgregarMarca_Click" Text="Agregar Marca" />
        <br />
       
    </div>
</body>