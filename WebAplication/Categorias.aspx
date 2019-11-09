<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="WebAplication.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h2>
        Categorias
    </h2>
    <div class="form-row" style="margin-top: 30px; margin-left: 30px;">

              <asp:Label Text=" Nombre" ID="lblCategoria" runat="server" Style="margin-top: 30px; margin-left: 30px;"></asp:Label>
        <asp:TextBox ID="txbCategoria" runat="server" Style="margin-top: 30px; margin-left: 30px;" >  </asp:TextBox>
            <asp:Button Text="Agregar" ID= "btnAgregar" runat = server  OnClick="BtnAgregar_Click" Style="margin-top: 30px; margin-left: 30px;"> </asp:Button>
         </div>
    
    <div>
      <div class="form-row">
        <asp:GridView ID="dgvCategorias" runat=server  CssClass="table table-striped"> </asp:GridView>
    </div>
    </div>
</asp:Content>
