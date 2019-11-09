<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Formulas.aspx.cs" Inherits="WebAplication.prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="form-row"Style="margin-top: 30px; margin-left: 30px;">
    <div>   Formulas </div>
             <asp:Label text="Producto" ID="lblprod" runat="server" Style="margin-top: 30px; margin-left: 30px;"></asp:Label>
           <asp:DropDownList runat="server" ID="cboProductos" Style="margin-top: 30px; margin-left: 30px;"></asp:DropDownList>
            <asp:Label text="Insumo" ID="lblInsumo" runat=server Style="margin-top: 30px; margin-left: 30px;"></asp:Label>
           <asp:DropDownList runat="server" ID="cboInsumos" Style="margin-top: 30px; margin-left: 30px;"></asp:DropDownList>
        <asp:Label Text=" Cantidad" ID="lblCantidad" runat="server" Style="margin-top: 30px; margin-left: 30px;"></asp:Label>
        <asp:TextBox ID="txbCantidad" runat="server" Style="margin-top: 30px; margin-left: 30px;">  </asp:TextBox>
       <asp:Button CssClass="btn btn-primary" Text="Agregar" ID="BtnAgregar" runat="server" OnClick="BtnAgregar_Click"></asp:Button>
       
     </div>

    <div class="form-row">
        <asp:GridView ID="dgvFormulas" runat=server  CssClass="table table-striped"> </asp:GridView>
    </div>
</asp:Content>
