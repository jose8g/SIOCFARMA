<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF_JefeDeInventario.aspx.cs" Inherits="Indexx.Formulario_web12" %>

<%@ Register Src="~/pages/Adquisicion/WF_OrdenCompra.ascx" TagPrefix="uc1" TagName="WF_OrdenCompra" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        
    

        <div id="ContentOrdenCompra" style="display:;">
            <uc1:WF_OrdenCompra runat="server" id="WF_OrdenCompra" />
        </div>
    </form>
</asp:Content>