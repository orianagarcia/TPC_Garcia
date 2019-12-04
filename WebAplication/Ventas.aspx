<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="WebAplication.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>   
         <h2  class="btn btn-info" style = color: " White">Ventas</h2>
    </div>
<div class="form-row ">
        <asp:GridView ID="dgvVentas" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" 
            OnRowEditing="dgvVentas_RowEditing" OnRowCancelingEdit="dgvVentas_RowCancelingEdit" OnRowUpdating="dgvVentas_RowUpdating" >
            <columns>
                 <%--<ID>--%>
                    <asp:TemplateField HeaderText="ID">
                    <ItemTemplate> 
                        <asp:label id="lblID" text='<%# Eval("id")%>' runat="server" />
                    </ItemTemplate>
                         <EditItemTemplate> 
                      <asp:label id="lblID"  runat="server" />
                    </EditItemTemplate>
                    </asp:TemplateField>
                 <%--<CLIENTE>--%>
                    <asp:TemplateField HeaderText="Cliente">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("cliente.nombre")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                       <asp:DropDownList ID="ddlClientes" runat="server"></asp:DropDownList> 
                    </EditItemTemplate>
                    </asp:TemplateField>
                 <%--<Empleado>--%>
                    <asp:TemplateField HeaderText="Empleado">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("empleado.nombre")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                    </EditItemTemplate>
                    </asp:TemplateField>
                     <%--<FECHA>--%>
                    <asp:TemplateField HeaderText="Fecha Pedido">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("fechaPedido")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                    </EditItemTemplate>
                   </asp:TemplateField>
                     <%--<FECHA>--%>
                    <asp:TemplateField HeaderText="Fecha Entrega">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("fechaEntrega")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                    </EditItemTemplate>
                   </asp:TemplateField>
                 <%--<TOTAL>--%>
                    <asp:TemplateField HeaderText="Total">
                    <ItemTemplate> 

                        <asp:label text='<%# Eval("Total")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbTotal" Text='<%# Eval("Total")%>' />  
                    </EditItemTemplate>
                   </asp:TemplateField>
                 <%--<SEÑA>--%>
                    <asp:TemplateField HeaderText="Seña">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("seña")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbSeña" Text='<%# Eval("seña")%>' />  
                    </EditItemTemplate>
                   </asp:TemplateField>
               <%--<ESTADO>--%>
                    <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("estado")%>' runat="server" />
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
           
               
                 <%--<DESCRIPCION>--%>
                    <asp:TemplateField HeaderText="Comentarios">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("descripcion")%>' runat="server" />
                    </ItemTemplate>
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

</asp:Content>
