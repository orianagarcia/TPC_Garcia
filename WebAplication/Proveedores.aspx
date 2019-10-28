<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="WebAplication.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container"> 
             <div class="form-row">
            <div class="form-group col-md-4">
                <h2>Proveedores</h2>
            </div>
        </div>
       
           <div class="form-row">
            <div class="form-group col-md-3">
            <asp:Label text=" Nombre   " ID="lblNombre" runat =server></asp:Label>
            <asp:TextBox ID= "txbNombre" runat = server> </asp:TextBox>      
            </div>
  </div>
       <div class="form-row">
            <div class="form-group col-md-3">
            <asp:Label text= " Telefono " ID="lblTelefono" runat =server></asp:Label>
            <asp:TextBox ID= "txbTelefono" runat = server>  </asp:TextBox>
        </div>
           </div>
            
        <div class="form-row">
            <div class="form-group col-md-3">
            <asp:Label text=" Direccion " ID="lblDireccion" runat =server></asp:Label>
            <asp:TextBox ID= "txbDireccion" runat = server>  </asp:TextBox>

        </div> 
            <div class="form-row">
            <div class="form-group col-md-3">
            <asp:Button Text=" Agregar " ID= "BtnAgregar" runat = server OnClick= "BtnAgregar_Click"> </asp:Button>
        </div> 
              
            </div>
        </div>

        <div class="form-row">
            <div class="form-group col-md-3">
             <asp:GridView ID="dgvProveedores" runat=server>
          </asp:GridView>
        </div>
         
     </div>
  
</asp:Content>
