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
        <asp:Label runat="server" ID="Label4" Text="Estado" AssociatedControlID="es"></asp:Label><br /><br />
        <asp:DropDownList runat="server" ID="DropDownList2">
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
        </asp:DropDownList>
        <br /><br />
        <asp:Label runat="server" ID="lbl1" Text="Tipo_Item" AssociatedControlID="esT"></asp:Label><br /><br />
        <asp:DropDownList runat="server" ID="DropDownList"></asp:DropDownList>
        <br />
        
        
        <br />
        <asp:Label runat="server" ID="Label5" Text="Marca_Item" AssociatedControlID="esM"></asp:Label><br /><br />
        <asp:DropDownList runat="server" ID="DropDownList1"></asp:DropDownList>
        <br />
        <br />
        <button runat="server" class="button btn-danger"  type="submit" id="ser" OnServerClick="ser_OnServerClick" >Registrar</button>
       
    </div>
</body>