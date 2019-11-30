
<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="WebAplication.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div> <asp:Button ID="btnAtras" cssClass="btn btn-success" Text="Volver Atras" runat="server" OnClick="btnAtras_Click" Visible="false"/>   </div>
<div class="form-row ">
        <asp:GridView ID="dgvCompras" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" 
                       OnRowCommand="dgvCompras_RowCommand" OnRowEditing="dgvCompras_RowEditing"
            OnRowCancelingEdit="dgvCompras_RowCancelingEdit" OnRowUpdating="dgvCompras_RowUpdating" OnSelectedIndexChanged="dgvCompras_SelectedIndexChanged"
             ShowFooter="false" >
            <columns>
                 <%--<ID>--%>
                    <asp:TemplateField HeaderText="ID">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("Id")%>' runat="server" />
                    </ItemTemplate>
                    
                    </asp:TemplateField>
                 <%--<PROVEEDOR>--%>
                    <asp:TemplateField HeaderText="Proveedor">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("proveedor.nombre")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                       <asp:DropDownList ID="ddlProveedor" runat="server"></asp:DropDownList> 
                    </EditItemTemplate>
                    </asp:TemplateField>
               <%--<ESTADO>--%>
                    <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("EstadoCompra")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                               <asp:DropDownList runat="server" ID="ddlEstado">
                          
                       </asp:DropDownList>
                    </EditItemTemplate>
                    </asp:TemplateField>
               <%--<FORMA DE PAGO>--%>
                    <asp:TemplateField HeaderText="Forma de Pago">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("FormaPago")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
              <asp:DropDownList runat="server" ID="ddlPago" />   
                    </EditItemTemplate>
                   </asp:TemplateField>
                <%--<FECHA>--%>
                    <asp:TemplateField HeaderText="Fecha">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("fechaCompra")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                    </EditItemTemplate>
                   </asp:TemplateField>
                <%--<TOTAL>--%>
                    <asp:TemplateField HeaderText="TOTAL">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("Total")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbTotal" Text='<%# Eval("Total")%>' />  
                    </EditItemTemplate>
                   </asp:TemplateField>
                   <%--<ACCIONES >--%>
                    <asp:TemplateField >
                    <ItemTemplate> 
                        <asp:ImageButton ImageUrl="~/Images/modificar.png" runat="server" CommandName="Edit" Tooltip="edit" width="20px" Height="20px"/>
                        
                        <asp:ImageButton ImageUrl="~/Images/Carrito.png" runat="server" CommandName="Select" Tooltip="select" width="20px" Height="20px"/>
                       
                        
                        </ItemTemplate>
                    <EditItemTemplate> 
                       <asp:ImageButton ImageUrl="~/Images/guardar.png" runat="server" CommandName="Update" Tooltip="Update" width="20px" Height="20px"/>
                       <asp:ImageButton ImageUrl="~/Images/cancelar.png" runat="server" CommandName="Cancel" Tooltip="Cancel" width="20px" Height="20px"/>
                       
                    </EditItemTemplate>

                    </asp:TemplateField>
            </columns>
        </asp:GridView>
     </div>
        <br />
    <div class="form-row" >
    <asp:TextBox id="txbDescripcion" runat="server" Visible="false" Height="50px" Width="300px" MaxLength="100"  />  
        <asp:Button ID="btnAgregarDesc" runat="server" Visible="false" Text="AgregarComentario" OnClick="btnAgregarDesc_Click"/>
   </div>
    <br />
        <asp:Label ID="lblIncorrecto2" Text="" runat="server" forecolor="Red"/>
        <asp:Label ID="lblCorrecto2" Text="" runat="server" forecolor="Green"/>
   
    <%--</div>--%>

    <div class="form-row ">
       
        <asp:GridView ID="dgvDetalles" CssClass="table table-striped" runat="server" ShowFooter="true" AutoGenerateColumns="false"  DataKeyNames="ID" 
            Visible="false" ShowHeaderWhenEmpty="true" ShowFooterWhenEmpty="true" 
                      OnRowCommand="dgvDetalles_RowCommand" OnRowEditing="dgvDetalles_RowEditing"
            OnRowCancelingEdit="dgvDetalles_RowCancelingEdit" OnRowUpdating="dgvDetalles_RowUpdating"
            OnRowDeleting="dgvDetalles_RowDeleting">
            <columns>
                 
                 <%--<INSUMO>--%>
                    <asp:TemplateField HeaderText="Insumo">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("insumo.nombre")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:DropDownList runat="server" ID="ddlInsumo" />
                    </EditItemTemplate>
                    <FooterTemplate>
              <asp:DropDownList ID="ddlInsumosFooter" runat="server" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
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
             <%--<TOTAL POR PRODUCTO>--%>
                    <asp:TemplateField HeaderText="Parcial por producto">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("totalProducto")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
               <asp:Label runat="server" ID="txbParcial" enabled="false"/>
                       
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:Label runat="server" ID="txbParcialFooter" enabled="false"/>
                    </FooterTemplate>
                    </asp:TemplateField>
                   <%--<ACCIONES >--%>
                    <asp:TemplateField >
                    <ItemTemplate> 
          <%--<asp:ImageButton ImageUrl="~/Images/modificar.png" runat="server" CommandName="Edit" Tooltip="edit" width="20px" Height="20px"/>--%>    
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

