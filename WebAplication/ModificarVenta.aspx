<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ModificarVenta.aspx.cs" Inherits="WebAplication.ModificarVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
     <div>
        <h2 class="btn btn-info" style = color: " White">Modificacion Venta </h2>
    </div>   
    <asp:Label ID="lblCliente" runat="server" Text="Cliente" class="btn btn-info"></asp:Label>
    <asp:DropDownList ID="ddlClientes" runat="server" class="btn btn-secondary dropdown-toggle"> </asp:DropDownList>
         <asp:Label ID="lblEmp" runat="server" Text="Empleado" class="btn btn-info"></asp:Label>
    <asp:DropDownList ID="ddlEmpleados" runat="server" class="btn btn-secondary dropdown-toggle"> </asp:DropDownList>
        <asp:Label ID="lblEstado" runat="server" Text="Estado" class="btn btn-info"></asp:Label>
        <asp:DropDownList runat="server" ID="ddlEstados" class="btn btn-secondary dropdown-toggle">
            <asp:ListItem Text="Entregado" Value="Entregado" />
            <asp:ListItem Text="Pedido" Value="Pedido"/>
            <asp:ListItem Text="En fabricacion" Value="Pedido"/>
        </asp:DropDownList>
        <asp:Label ID="lblPago" runat="server" Text="Forma de pago" class="btn btn-info"></asp:Label>
        <asp:DropDownList runat="server" ID="ddlFormaPago" class="btn btn-secondary dropdown-toggle">
            <asp:ListItem Text="Mercado Pago" Value="Mercado Pago"/>
            <asp:ListItem Text="Efectivo"  Value="Efectivo"/>
            <asp:ListItem Text="Tarjeta de Credito" Value="Tarjeta de Credito" />
            <asp:ListItem Text="Transferencia" Value="Transferencia" />
        </asp:DropDownList>
        <br />
        <br />
     <asp:Label ID="Label1" runat="server" Text="Fecha Pedido" class="btn btn-info"></asp:Label>
        <asp:TextBox ID="txbPedido" runat="server" TextMode="Date"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Fecha Entrega" class="btn btn-info"></asp:Label>
        <asp:TextBox ID="txbEntrega" runat="server" TextMode="Date"></asp:TextBox>
         <br />
         <br /> 
         <asp:Label ID="lblProducto" runat="server" Text="Producto" CssClass="btn btn-info" ></asp:Label>
       <asp:DropDownList ID="ddlProducto" class="btn btn-secondary dropdown-toggle" runat="server" > </asp:DropDownList>
        
       <%-- <asp:Label ID="lblPrecio" runat="server" Text="Precio Unitario" CssClass="btn btn-info"></asp:Label>
        <asp:TextBox ID="txbPrecioU" Text= "0" runat="server"></asp:TextBox>--%>
        <asp:Label ID="lblCantidad" runat="server" Text="Cantidad" class="btn btn-info"></asp:Label>
        <asp:TextBox ID="txbCantidad" Text="0" runat="server"></asp:TextBox>
        <asp:Button cssClass="btn btn-info" ID="btnAgregarProducto"  OnClick="btnAgregarProducto_Click" runat="server" Text="Agregar Producto" />
        
        </div>
    <br />
    <asp:GridView ID="dgvDetalles" CssClass="table table-striped" runat="server"  AutoGenerateColumns="false" ShowFooter="false" DataKeyNames="ID" OnRowDeleting="dgvDetalles_RowDeleting" >
                    
            <columns>
                 
                 <%--<PRODUCTO>--%>
                    <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate> 
                        <asp:label  text='<%# Eval("producto.nombre")%>' runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>
                   <%--<PRECIO>--%>
                    <asp:TemplateField HeaderText="Precio">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("producto.precioVenta")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
              <asp:TextBox runat="server" ID="txbPrecio" Text='<%# Eval("producto.precioVenta")%>' />   
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
                    <asp:TemplateField >
                    <ItemTemplate> 
                        <asp:ImageButton ImageUrl="~/Images/borrar.png" runat="server" CommandName="Delete" Tooltip="delete" width="20px" Height="20px"/>
                        </ItemTemplate>
                    </asp:TemplateField>
            </columns>
        </asp:GridView>
     <asp:Label runat="server" Text="Nuevos Productos" class="btn btn-info"></asp:Label>
        
       <asp:GridView ID="dgvNueva" CssClass="table table-striped" runat="server"  AutoGenerateColumns="false" ShowFooter="false" ShowHeader="false" DataKeyNames="ID" >
                    
            <columns>
                 
                 <%--<PRODUCTO>--%>
                    <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate> 
                        <asp:label  text='<%# Eval("producto.nombre")%>' runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>
                   <%--<PRECIO>--%>
                    <asp:TemplateField HeaderText="Precio">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("producto.precioVenta")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
              <asp:TextBox runat="server" ID="txbPrecio" Text='<%# Eval("producto.precioVenta")%>' />   
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
                    <asp:TemplateField >
                    <ItemTemplate> 
                        <asp:ImageButton ImageUrl="~/Images/borrar.png" runat="server" CommandName="Delete" Tooltip="delete" width="20px" Height="20px"/>
                        </ItemTemplate>
                    </asp:TemplateField>
            </columns>
        </asp:GridView>
     <br />
        <asp:Label ID="lblTotal" runat="server" Text="Total:" class="btn btn-info"></asp:Label>
        <asp:TextBox ID="txbTotal" runat="server" Text="0"></asp:TextBox>
        
        <asp:Label ID="lblSeña" runat="server" Text="Seña:" class="btn btn-info"></asp:Label>
        <asp:TextBox ID="txbSeña" runat="server" Text="0"></asp:TextBox>

    <asp:Label ID="lblAdeuda" runat="server" Text="Adeuda:" class="btn btn-info"></asp:Label>
        <asp:TextBox ID="txbAdeuda" runat="server"></asp:TextBox>
        <asp:Label ID="lblNuevoP" runat="server" Text="Nuevo Pago:" class="btn btn-info"></asp:Label>
        <asp:TextBox ID="txbNuevoPago" runat="server" Text="0"></asp:TextBox>
    <br /> <br />
    <asp:Label ID="lblDesc" runat="server" Text="Descripcion:" class="btn btn-info"></asp:Label>
        <asp:TextBox ID="txbDesc" runat="server" ></asp:TextBox>
        <br /> <br />
        <asp:Button cssClass="btn btn-info" ID="btnModVenta" runat="server" Text="Modificar Venta" OnClick="btnModVenta_Click"/>

        <br />
        <asp:Label cssClass="btn btn-info" ID="lblCorrecto" Text="" runat="server" forecolor="white"/>
        <br />
        <asp:Label  cssClass="btn btn-info" ID="lblIncorrecto" Text="" runat="server" forecolor="white"/>



</asp:Content>
