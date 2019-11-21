
<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="WebAplication.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="form-row ">
        <asp:GridView ID="dgvCompras" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ID" 
                       OnRowCommand="dgvCompras_RowCommand" OnRowEditing="dgvCompras_RowEditing"
            OnRowCancelingEdit="dgvCompras_RowCancelingEdit" OnRowUpdating="dgvCompras_RowUpdating"
            OnRowDeleting="dgvCompras_RowDeleting" OnSelectedIndexChanged="btn_Detalle_Click">
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
                        <asp:label text='<%# Eval("idProveedor")%>' runat="server" />
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
                               <asp:DropDownList runat="server" ID="ddlEstados">
                          
                       </asp:DropDownList>
                    </EditItemTemplate>
                    </asp:TemplateField>
               <%--<FORMA DE PAGO>--%>
                    <asp:TemplateField HeaderText="Forma de Pago">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("FormaPago")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
              <asp:DropDownList runat="server" ID="ddlPago" Text='<%# Eval("FormaPago")%>' />   
                    </EditItemTemplate>
                   </asp:TemplateField>
                   <%--<ACCIONES >--%>
                    <asp:TemplateField >
                    <ItemTemplate> 
                        <asp:ImageButton ImageUrl="~/Images/modificar.png" runat="server" CommandName="Edit" Tooltip="edit" width="20px" Height="20px"/>
                        <asp:ImageButton ImageUrl="~/Images/borrar.png" runat="server" CommandName="Delete" Tooltip="delete" width="20px" Height="20px"/>
                        <asp:ImageButton ImageUrl="~/Images/Carrito.png" runat="server"  width="20px" HeighT="20px" OnClick="btn_Detalle_Click" />
                       
                        
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
        <asp:Label ID="lblCorrecto2" Text="" runat="server" forecolor="Green"/>
        <br />
        <asp:Label ID="lblIncorrecto2" Text="" runat="server" forecolor="Red"/>
    </div>
    <%--</div>--%>
    <div class="form-row ">
        <asp:DropDownList runat="server">
            <asp:ListItem Text="Entregado" Value="Entregado" />
            <asp:ListItem Text="Pedido" Value="Pedido"/>
            <asp:ListItem Text="Devolucion" Value="Devolucion"/>
        </asp:DropDownList>
        <asp:GridView ID="dgvDetalles" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ID" 
            Visible="false" ShowHeaderWhenEmpty="true"> 
                    
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

