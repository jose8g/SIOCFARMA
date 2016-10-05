<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_GestionarProducto.ascx.cs" Inherits="Indexx.pages.Adquision.WF_GestionarProducto" %>


<body>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Nombre_Item"></asp:Label>
        <br />
         <input runat="server" type="text" id="Nombre"/>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Precio_Venta"></asp:Label>
        <br /> 
        <input runat="server" type="text" id="PrecioVenta"/>
        <br />
        <asp:Label runat="server" ID="Label4" Text="Estado" AssociatedControlID="ddlEstado"></asp:Label><br /><br />
        <asp:DropDownList runat="server" ID="ddlEstado">
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label runat="server" ID="lbl1" Text="Tipo_Item" AssociatedControlID="ddlTipo"></asp:Label><br /><br />
        <asp:DropDownList runat="server" ID="ddlTipo"></asp:DropDownList>
        <br />
        <asp:Label runat="server" ID="Label5" Text="Marca_Item" AssociatedControlID="ddlMarca"></asp:Label><br /><br />
        <asp:DropDownList runat="server" ID="ddlMarca"></asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <button runat="server" class="button btn-danger"  type="submit" OnServerClick="ser_OnServerClick" >Añadir Marca</button>
        <br />
        <button runat="server" class="button btn-danger"  type="submit" OnServerClick="serM_OnServerClick" >Añadir producto</button>
    </div>
</body>