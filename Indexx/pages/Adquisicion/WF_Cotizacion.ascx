<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Cotizacion.ascx.cs" Inherits="Indexx.pages.Adquisicion.WF_Cotizacion" %>

<div class:"container1">
    <div class="form-group has-feedback">
        <label class="lblTituloC" for="name" ><strong>REGISTRAR COTIZACIÓN</strong></label>
    </div>
</div>

<asp:GridView ID="dgvPedido" runat="server" CssClass="gridview bordered" 
    AutoGenerateColumns="False" OnPageIndexChanging="gvPedidos_PageIndexChanging"
    DataKeyNames="NumeroPedido,Estado"
    OnRowCommand="gvPedidos_RowComand"
    AllowPaging="True" PageSize="8" Height="161px" Width="856px" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" >
    <Columns>
        <asp:BoundField DataField="NumeroPedido" HeaderText="N° de Pedido" />
        <asp:BoundField DataField="Estado" HeaderText="Estado"  />
        <asp:TemplateField HeaderText="Cotizar">
            <ItemTemplate>
                <asp:ImageButton ID="btnCotizar" HeaderText="Cotizar" CssClass="imgGridMiguel" runat="server"
                    ImageUrl="../../images/cotizar.png" CommandName="Cotizar"
                    formnovalidate=""
                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
            </ItemTemplate>

        </asp:TemplateField>

    </Columns>
    <EditRowStyle BorderColor="Black" BorderStyle="Solid" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
    <HeaderStyle BorderColor="Black" BorderStyle="Solid" ForeColor="Black" HorizontalAlign="Center" />
    <SortedDescendingCellStyle BorderColor="blue" BorderStyle="Solid" ForeColor="blue"  HorizontalAlign="Center" VerticalAlign="Middle"/>

</asp:GridView>

<div class:"container2">
    <div class="form-group has-feedback">
        
    </div>
</div>