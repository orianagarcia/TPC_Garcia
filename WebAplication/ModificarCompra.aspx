<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ModificarCompra.aspx.cs" Inherits="WebAplication.ModificarCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
     <div>
        <h2 class="btn btn-info" style = color: " White">Modificacion Compra </h2>
    </div>   
    <asp:Label ID="lblProv" runat="server" Text="Proveedor" class="btn btn-info"></asp:Label>
    <asp:DropDownList ID="ddlProveedores" runat="server" class="btn btn-secondary dropdown-toggle"> </asp:DropDownList>
         
         <asp:Label ID="lblEstado" runat="server" Text="Estado" class="btn btn-info"></asp:Label>
        <asp:DropDownList runat="server" ID="ddlEstados" class="btn btn-secondary dropdown-toggle">
            <asp:ListItem Text="Entregado" Value="Entregado" />
            <asp:ListItem Text="Pedido" Value="Pedido"/>
            <asp:ListItem Text="Devolucion" Value="Devolucion"/>
        </asp:DropDownList>
        <asp:Label ID="lblPago" runat="server" Text="Forma de pago" class="btn btn-info"></asp:Label>
        <asp:DropDownList runat="server" ID="ddlPago" class="btn btn-secondary dropdown-toggle">
            <asp:ListItem Text="Mercado Pago" Value="Mercado Pago"/>
            <asp:ListItem Text="Efectivo"  Value="Efectivo"/>
            <asp:ListItem Text="Tarjeta de Credito" Value="Tarjeta de Credito" />
            <asp:ListItem Text="Tarjeta de Credito" Value="Tarjeta de Debito" />
            <asp:ListItem Text="Transferencia" Value="Transferencia" />
        </asp:DropDownList>
        <br />
        <br />
     <asp:Label ID="Label1" runat="server" Text="Fecha Pedido" class="btn btn-info"></asp:Label>
        <asp:TextBox ID="txbPedido" runat="server" TextMode="Date"></asp:TextBox>
       <br />
         <br /> 
         <asp:Label Text="Descripcion" runat="server" Visible="false" />
         <asp:TextBox id="txbDescripcion" runat="server" Visible="false" /> 
         <asp:Button Text="Agregar Motivo de Devolucion" runat="server" id="btnAgregarDesc" Visible="false" class="btn btn-info" OnClick="btnAgregarDesc_Click" /> 
         <br />
         <br />
        </div>
    
    <asp:GridView ID="dgvDetalles" CssClass="table table-striped" runat="server"  AutoGenerateColumns="false" ShowFooter="false" DataKeyNames="ID" >
                    
            <columns>
                 <%--<ID>--%>
                    <asp:TemplateField HeaderText="ID">
                    <ItemTemplate> 
                        <asp:label  ID="LblID" text='<%# Eval("id")%>' runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>
                 <%--<PRODUCTO>--%>
                    <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate> 
                        <asp:label  text='<%# Eval("insumo.nombre")%>' runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>
                   <%--<PRECIO>--%>
                    <asp:TemplateField HeaderText="Precio">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("precioUnitario")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
              <asp:TextBox runat="server" ID="txbPrecio" Text='<%# Eval("precioUnitario")%>' />   
                    </EditItemTemplate>
                             </asp:TemplateField>
               <%--<CANTIDAD>--%>
                    <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("Cantidad")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbCantidad" Text='<%# Eval("Cantidad")%>' />  
                    </EditItemTemplate>
                    </asp:TemplateField>
            
             <%--<TOTAL POR PRODUCTO>--%>
                    <asp:TemplateField HeaderText="Parcial por producto">
                    <ItemTemplate> 
                        <asp:label ID="LblTprod" text='<%# Eval("totalProducto")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
              <asp:TextBox runat="server" ID="txbParcial" Text='<%# Eval("totalProducto")%>' />   
                       
                    </EditItemTemplate>
                    </asp:TemplateField>
                   <%--<ACCIONES >--%>
                    <%--<asp:TemplateField >
                    <ItemTemplate> 
                        <asp:ImageButton ImageUrl="~/Images/borrar.png" runat="server" CommandName="Delete" Tooltip="delete" width="20px" Height="20px"/>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
            </columns>
        </asp:GridView>
     <br />
        <asp:Label ID="lblTotal" runat="server" Text="Total:" class="btn btn-info"></asp:Label>
        <asp:TextBox ID="txbTotal" runat="server" Text="0"></asp:TextBox>
        
        
        <asp:Button cssClass="btn btn-info" ID="btnModCompra" runat="server" Text="Modificar Compra" OnClick="btnModCompra_Click" />

        <br />
        <asp:Label cssClass="btn btn-info" ID="lblCorrecto" Text="" runat="server" forecolor="white" Visible="false"/>
        <br />
        <asp:Label  cssClass="btn btn-info" ID="lblIncorrecto" Text="" runat="server" forecolor="White" Visible="false"/>

</asp:Content>
