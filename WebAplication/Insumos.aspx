<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Insumos.aspx.cs" Inherits="WebAplication.Insumos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
           <div class="container">
      
               <div class="form-row">
            <div class="form-group col-md-">
                <h2>Insumos</h2>
            </div>
        </div>

        <div class="form-row">
            <asp:Label text="Nombre" ID="lblNombre" runat =server></asp:Label>
            <asp:TextBox ID= "txbNombre" runat = server>
                
            </asp:TextBox>
             <asp:Label text="Medida " ID="lblMedida" runat =server></asp:Label>
              
         <asp:DropDownList runat="server" ID="cboMedidas" />
               
           <asp:Button Text="Agregar" ID= "BtnAgregar" runat = server OnClick= "BtnAgregar_Click"> </asp:Button>
</div>
               </div> 
   
      <div>  
          <asp:GridView ID="dgvInsumos" runat=server>
          </asp:GridView>
     </div>
    <%--  --%>





</asp:Content>
