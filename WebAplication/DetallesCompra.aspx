<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetallesCompra.aspx.cs" Inherits="WebAplication.DetalleCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
       <div>
        <h2 class="btn btn-info" style = color: " White">Nueva Compra</h2>
    </div>
    <asp:Label Text="Fecha" runat="server" />
    <asp:TextBox id="txbFecha"  runat="server" Height="25px" Width="111px" TextMode="DateTime" />  
        <br />
        <br />
    <asp:Label ID="lblProveedor" runat="server" Text="Proveedor"></asp:Label>
    <asp:DropDownList ID="ddlProveedores" runat="server"> </asp:DropDownList>
        <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
        <asp:DropDownList runat="server" ID="ddlEstados">
            <asp:ListItem Text="Entregado" Value="Entregado" />
            <asp:ListItem Text="Pedido" Value="Pedido"/>
            
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Forma de pago"></asp:Label>
        <asp:DropDownList runat="server" ID="ddlFormaPago">
            <asp:ListItem Text="Mercado Pago" Value="Mercado Pago"/>
            <asp:ListItem Text="Efectivo"  Value="Efectivo"/>
            <asp:ListItem Text="Tarjeta de Credito" Value="Tarjeta de Credito" />
            <asp:ListItem Text="Transferencia" Value="Transferencia" />
        </asp:DropDownList>
        <br />
        <br />
    
    <asp:Label ID="lblProducto" runat="server" Text="Producto"></asp:Label>
    <asp:DropDownList ID="ddlProductos" runat="server" > </asp:DropDownList>
        
        <asp:Label ID="lblPrecio" runat="server" Text="Precio Unitario"></asp:Label>
        <asp:TextBox ID="txbPrecioU" Text= "0" runat="server"></asp:TextBox>
        <asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label>
        <asp:TextBox ID="txbCantidad" Text="0" runat="server"></asp:TextBox>
        <asp:Button cssClass="btn btn-info" ID="btnAgregarProducto" OnClick="btnAgregarProducto_Click" runat="server" Text="Agregar Producto" />
        <br />
        </div>
    <asp:GridView ID="dgvDetalles" CssClass="table table-striped" runat="server"  AutoGenerateColumns="false" ShowFooter="false" DataKeyNames="ID" 
            Visible="false"  OnRowEditing="dgvDetalles_RowEditing"
            OnRowCancelingEdit="dgvDetalles_RowCancelingEdit" OnRowUpdating="dgvDetalles_RowUpdating"
            OnRowDeleting="dgvDetalles_RowDeleting"> 
                    
            <columns>
                 
                 <%--<INSUMO>--%>
                    <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("insumo.nombre")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                       <%//<asp:TextBox runat="server" ID="txbNombre" Text='<%# Eval("IdInsumo")%>' />   %>
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
               <%--<PRECIO>--%>
                    <asp:TemplateField HeaderText="Precio">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("PrecioUnitario")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
              <asp:TextBox runat="server" ID="txbPrecio" Text='<%# Eval("PrecioUnitario")%>' />   
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
                    <asp:TemplateField >
                    <ItemTemplate> 
                        <asp:ImageButton ImageUrl="~/Images/borrar.png" runat="server" CommandName="Delete" Tooltip="delete" width="20px" Height="20px"/>
                        </ItemTemplate>
                    </asp:TemplateField>
            </columns>
        </asp:GridView>

        <asp:Label ID="lblTotal" runat="server" Text="Total:"></asp:Label>
        <asp:TextBox ID="txbTotal" runat="server" Text="0"></asp:TextBox>

        <br />
        <br />
        <asp:Button cssClass="btn btn-info" ID="btnGuardarFactura" runat="server" Text="Guardar Compra" OnClick="btnGuardarFactura_Click"/>

        <br />
        <asp:Label ID="lblCorrecto" Text="" runat="server" forecolor="Green"/>
        <br />
        <asp:Label ID="lblIncorrecto" Text="" runat="server" forecolor="Red"/>

</asp:Content>
