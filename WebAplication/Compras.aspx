
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
       
     </div>
 <div>
        <h2 style= "color:Green ">Detalle</h2>
    </div>
    <%--</div>--%>
    <div class="form-row ">
        <asp:GridView ID="dgvDetalles" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ID" 
                       OnRowCommand="dgvDetalles_RowCommand" OnRowEditing="dgvDetalles_RowEditing"
            OnRowCancelingEdit="dgvDetalles_RowCancelingEdit" OnRowUpdating="dgvDetalles_RowUpdating"
            OnRowDeleting="dgvDetalles_RowDeleting" >
            <columns>
                 <%--<INSUMO>--%>
                    <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("IdInsumo")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbNombre" Text='<%# Eval("IdInsumo")%>' />  
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbNombreFooter" />
                    </FooterTemplate>
                    </asp:TemplateField>
               <%--<CANTIDAD>--%>
                    <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("Cantidad")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbCantidad" Text='<%# Eval("Cantidad")%>' />  
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbCantidadFooter" />
                    </FooterTemplate>
                    </asp:TemplateField>
               <%--<PRECIO>--%>
                    <asp:TemplateField HeaderText="Precio">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("PrecioUnitario")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
              <asp:TextBox runat="server" ID="txbPrecio" Text='<%# Eval("PrecioUnitario")%>' />   
                       
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbPrecioFooter" />
                    </FooterTemplate>
                    </asp:TemplateField>
                   <%--<ACCIONES >--%>
                    <asp:TemplateField >
                    <ItemTemplate> 
                        <asp:ImageButton ImageUrl="~/Images/modificar.png" runat="server" CommandName="Edit" Tooltip="edit" width="20px" Height="20px"/>
                        <asp:ImageButton ImageUrl="~/Images/borrar.png" runat="server" CommandName="Delete" Tooltip="delete" width="20px" Height="20px"/>
                        </ItemTemplate>
                    <EditItemTemplate> 
                       <asp:ImageButton ImageUrl="~/Images/guardar.png" runat="server" CommandName="Update" Tooltip="Update" width="20px" Height="20px"/>
                       <asp:ImageButton ImageUrl="~/Images/cancelar.png" runat="server" CommandName="Cancel" Tooltip="Cancel" width="20px" Height="20px"/>
                       
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:ImageButton ImageUrl="~/Images/agregar.png" runat="server" CommandName="AddNew" Tooltip="AddNew" width="20px" Height="20px"/>
                    </FooterTemplate>
                    </asp:TemplateField>
            </columns>
        </asp:GridView>

        <br />
        <asp:Label ID="lblCorrecto" Text="" runat="server" forecolor="Green"/>
        <br />
        <asp:Label ID="lblIncorrecto" Text="" runat="server" forecolor="Red"/>
    </div>




</asp:Content>

