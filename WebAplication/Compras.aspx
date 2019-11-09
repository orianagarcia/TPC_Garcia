
<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="WebAplication.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container" Style="margin-top: 30px; margin-left: 30px;">
      
               <div class="form-row">
            <div class="form-group ">
                <h2>Compras</h2>
            </div>
        </div>

        <div class="form-row"Style="margin-top: 30px; margin-left: 30px;">
            <asp:Label text="Proveedores" ID="lblProveedores" runat =server></asp:Label>
           <asp:DropDownList runat="server" ID="cboProveedores"></asp:DropDownList>    
         <asp:Label text="Estado" ID="lblEstado" runat =server></asp:Label>
          <asp:DropDownList runat="server" ID="cboEstado">  </asp:DropDownList>   
        <asp:Label text="Medio de Pago" ID="lblPago" runat =server></asp:Label>
          <asp:DropDownList runat="server" ID="cboPago">  </asp:DropDownList>   
       
            <asp:Button Text="Agregar" ID= "BtnAgregar" runat = server  OnClick="BtnAgregar_Click"> </asp:Button>
       </div>
               </div> 
     <div class="container" Style="margin-top: 30px; margin-left: 30px;">

         <div class="form-row"Style="margin-top: 30px; margin-left: 30px;">

             <asp:Label text="Compra" ID="lblCompra" runat="server" Style="margin-top: 30px; margin-left: 30px;"></asp:Label>
           <asp:DropDownList runat="server" ID="cboCompra" Style="margin-top: 30px; margin-left: 30px;"></asp:DropDownList>
            <asp:Label text="Insumo" ID="lblInsumo" runat=server Style="margin-top: 30px; margin-left: 30px;"></asp:Label>
           <asp:DropDownList runat="server" ID="cboInsumos" Style="margin-top: 30px; margin-left: 30px;"></asp:DropDownList>
        <asp:Label Text=" Cantidad" ID="lblCantidad" runat="server" Style="margin-top: 30px; margin-left: 30px;"></asp:Label>
        <asp:TextBox ID="txbCantidad" runat="server" Style="margin-top: 30px; margin-left: 30px;">  </asp:TextBox>
         <asp:Label Text=" Precio Unitario" ID="lblPrecio" runat="server" Style="margin-top: 30px; margin-left: 30px;"></asp:Label>
        <asp:TextBox ID="txbPrecio" runat="server" Style="margin-top: 30px; margin-left: 30px;">  </asp:TextBox>
            <asp:Button Text="Agregar Producto" ID= "btnAgregarProducto" runat = server  OnClick="BtnAgregarProducto_Click" Style="margin-top: 30px; margin-left: 30px;"> </asp:Button>
         </div>
         
     </div>
   
      <div>  
          <asp:GridView ID="dgvCompras" runat=server  CssClass="table table-striped" Style="margin-top: 30px; margin-left: 30px;">
          </asp:GridView>
        <asp:GridView ID="dgvDetalles" runat=server  CssClass="table table-striped" Style="margin-top: 30px; margin-left: 30px;">
          </asp:GridView>
     </div>





</asp:Content>

