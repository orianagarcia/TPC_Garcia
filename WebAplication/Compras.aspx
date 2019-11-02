
<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="WebAplication.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container">
      
               <div class="form-row">
            <div class="form-group col-md-4">
                <h2>Compras</h2>
            </div>
        </div>

        <div class="form-row">
            <asp:Label text="Proveedores" ID="lblProveedores" runat =server></asp:Label>
               <asp:DropDownList runat="server" ID="cboProveedores"></asp:DropDownList>    
           
             <asp:Label text="Insumo " ID="lblInsumo" runat =server></asp:Label>
               <asp:DropDownList runat="server" ID="cboInsumos">  </asp:DropDownList>
          <asp:Label text="Estado" ID="lblEstado" runat =server></asp:Label>
          <asp:DropDownList runat="server" ID="cboEstado">  </asp:DropDownList>   
        <asp:Label text="Medio de Pago" ID="lblPago" runat =server></asp:Label>
          <asp:DropDownList runat="server" ID="cboPago">  </asp:DropDownList>   
       
            <asp:Button Text="Agregar" ID= "BtnAgregar" runat = server > </asp:Button>
</div>
               </div> 
   
      <div>  
          <asp:GridView ID="dgvCompras" runat=server>
          </asp:GridView>
     </div>





</asp:Content>

