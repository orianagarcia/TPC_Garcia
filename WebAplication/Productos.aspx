<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebAplication.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Productos</h3>
    <div class="container"> 
         <div class="form-row"Style="margin-top: 30px; margin-left: 30px;">
            <asp:Label text="Nombre" ID="lblNombre" runat =server></asp:Label>
            <asp:TextBox ID="txbNombre" runat="server" Style="margin-top: 30px; margin-left: 30px;">  </asp:TextBox>   
         
             <asp:Label text="Marca" ID="lblMarca" runat =server></asp:Label>
          <asp:DropDownList runat="server" ID="cboMarca">  </asp:DropDownList> 
             
        <asp:Label text="Categoria" ID="lblCategoria" runat =server></asp:Label>
         <asp:DropDownList runat="server" ID="cboCategoria">  </asp:DropDownList>   
       
             <asp:Label text="Precio" ID="lblPrecio" runat =server></asp:Label>
            <asp:TextBox ID="txbPrecio" runat="server" Style="margin-top: 30px; margin-left: 30px;">  </asp:TextBox>   
         
            <asp:Button Text="Agregar" ID= "BtnAgregar" runat = server OnClick="BtnAgregar_Click" > </asp:Button>
       </div>
     </div>
    <div>
        <h2>   Listado  </h2>
    </div>
    <div>

        <asp:GridView ID="dgvProductos" CssClass="table table-striped" runat="server" AutoGenerateColumns="True"  >
            
        </asp:GridView>
    </div>
</asp:Content>
