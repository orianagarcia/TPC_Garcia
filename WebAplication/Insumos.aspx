<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Insumos.aspx.cs" Inherits="WebAplication.Insumos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
           <div class="container">
      
        <div class="form-row">
            <div class="form-group col-md-4">
                <h2>Insumos</h2>
            </div>
        </div>

        <div class="container">
            <asp:Label text="Nombre" ID="lblNombre" runat =server></asp:Label>
            <asp:TextBox ID= "txbNombre" runat = server>
                
            </asp:TextBox>
            
         </div>  
        </div>  

        <div>
        <div>
            <asp:Label text="Medida " ID="lblMedida" runat =server></asp:Label>
            <select ID="listamedidas" name="listMedida">
  <option value="1">Kilos</option> 
  <option value="2" selected>Gramos</option>
  <option value="3">Litros</option>
</select>
        </div>
            </div>  

        <div>
        
             <asp:Button Text="Agregar" ID= "BtnAgregar" runat = server OnClick= "BtnAgregar_Click">
                
            </asp:Button>
        <div>

        </div>

      <div>  
          <asp:GridView ID="dgvInsumos" runat=server>
          </asp:GridView>
     </div>
      </div>
    <%--  --%>





</asp:Content>
