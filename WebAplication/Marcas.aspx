<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="WebAplication.Stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Marcas
    </h2>
    <div class="form-row"Style="margin-top: 30px; margin-left: 30px;">

              <asp:Label Text=" Nombre" ID="lblMarca" runat="server" Style="margin-top: 30px; margin-left: 30px;"></asp:Label>
        <asp:TextBox ID="txbMarca" runat="server" Style="margin-top: 30px; margin-left: 30px;" CausesValidation="False">  </asp:TextBox>
            <asp:Button Text="Agregar" ID= "btnAgregar" runat = server  OnClick="BtnAgregar_Click" Style="margin-top: 30px; margin-left: 30px;"> </asp:Button>
         </div>
    <asp:GridView ID="dgvMarcas" runat=server  CssClass="table table-striped" Style="margin-top: 30px; margin-left: 30px;">
    </asp:GridView>
</asp:Content>
