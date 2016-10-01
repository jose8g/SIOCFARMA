﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_GestionarOrdenPedido.ascx.cs" Inherits="Indexx.pages.Ventas.WF_GestionarOrdenPedido" %>
<p>
    Gestionar Orden de Pedidos</p>
<p>
    Ordenes pendientes:</p>
<asp:GridView ID="gridGestionarPedidoPendiente" runat="server"></asp:GridView>
<p>
    &nbsp;</p>

<asp:Button ID="Button1" runat="server" Text="Crear Orden de Pedido" OnClick="LoadCrearPedido"/>
&nbsp;
<asp:Button ID="Button2" runat="server" Text="Editar Orden de Pedido" OnClick="LoadEditarPedido"/>
&nbsp;
<asp:Button ID="Button3" runat="server" Text="Eliminar Orden de Pedido" OnClick="LoadEliminarPedido"/>
&nbsp;
<asp:Button ID="Button4" runat="server" Text="Consultar Pedido" OnClick="LoadConsultarPedido"/>


<script>
    function SoloNumeros(e) {
        var iKeyCode = 0;
        if (window.event)
            iKeyCode = window.event.keyCode
        else if (e)
            iKeyCode = e.which;
        if ((iKeyCode > 47 && iKeyCode < 58) || (iKeyCode == 8))
            return true
        else
            return false;
    }
    function SoloCaracteresYArroba(e) {
        var iKeyCode = 0;
        if (window.event)
            iKeyCode = window.event.keyCode
        else if (e)
            iKeyCode = e.which;
        if ((iKeyCode >= 65 && iKeyCode <= 90) || (iKeyCode >= 97 && iKeyCode <= 122) || (iKeyCode == 241) || (iKeyCode == 209) || (iKeyCode == 32) || (iKeyCode == 177) || (iKeyCode == 8) || (iKeyCode == 64))
            return true
        else
            return false;
    }

    function SoloCaracteres(e) {
        var iKeyCode = 0;
        if (window.event)
            iKeyCode = window.event.keyCode
        else if (e)
            iKeyCode = e.which;
        if ((iKeyCode >= 65 && iKeyCode <= 90) || (iKeyCode >= 97 && iKeyCode <= 122) || (iKeyCode == 241) || (iKeyCode == 209) || (iKeyCode == 32) || (iKeyCode == 177) || (iKeyCode == 8))
            return true
        else
            return false;
    }

    function SoloCaracteresNumeros(e) {
        var iKeyCode = 0;
        if (window.event)
            iKeyCode = window.event.keyCode
        else if (e)
            iKeyCode = e.which;
        if ((iKeyCode >= 65 && iKeyCode <= 90) || (iKeyCode >= 97 && iKeyCode <= 122) || (iKeyCode == 241) || (iKeyCode == 209) || (iKeyCode == 177) || (iKeyCode == 8) || (iKeyCode > 47 && iKeyCode < 58) || (iKeyCode == 32))
            return true
        else
            return false;
    }
    function SoloNumerosypunto(e) {
        var iKeyCode = 0;
        if (window.event)
            iKeyCode = window.event.keyCode
        else if (e)
            iKeyCode = e.which;
        if ((iKeyCode > 47 && iKeyCode < 58) || (iKeyCode == 8) || (iKeyCode == 46))
            return true
        else
            return false;
    }
</script>
