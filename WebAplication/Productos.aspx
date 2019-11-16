<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebAplication.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>
        <h2 style= "color:Green ">Productos</h2>
    </div>
    <%--</div>--%>
    <div class="form-row ">
        <asp:GridView ID="dgvProductos" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ID" 
            OnRowCommand="dgvProductos_RowCommand" OnRowEditing="dgvProductos_RowEditing"
            OnRowCancelingEdit="dgvProductos_RowCancelingEdit" OnRowUpdating="dgvProductos_RowUpdating"
            OnRowDeleting="dgvProductos_RowDeleting">
            <columns>
                 <%--<NOMBRE>--%>
                    <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("Nombre")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbNombre" Text='<%# Eval("Nombre")%>' />  
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbNombreFooter" />
                    </FooterTemplate>
                    </asp:TemplateField>
               <%--<MARCA>--%>
                    <asp:TemplateField HeaderText="Marca">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("idMarca")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                  <%--     <asp:TextBox runat="server" ID="txbMarca" Text='<%# Eval("idMarca")%>' />--%> 
                        <asp:DropDownList ID="ddlMarca" runat="server" DataTextField="marca" DataValueField="id"></asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                      <asp:DropDownList ID="ddlMarcaFooter" runat="server" DataTextField="marca" DataValueField="id"></asp:DropDownList>
                    </FooterTemplate>
                    </asp:TemplateField>
               <%--<CATEGORIA>--%>
                    <asp:TemplateField HeaderText="Categoria">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("idCategoria")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                    <asp:DropDownList ID="ddlCategoria" runat="server" DataTextField="categoria" DataValueField="id"></asp:DropDownList>
                      
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbCategoriaFooter" />
                    </FooterTemplate>
                    </asp:TemplateField>
                   <%--<STOCK>--%>
                    <asp:TemplateField HeaderText="Stock">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("Stock")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbStock" Text='<%# Eval("Stock")%>' />  
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbStockFooter" />
                    </FooterTemplate>
                    </asp:TemplateField>
                    <%--<COSTO>--%>
                <asp:TemplateField HeaderText="Costo">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("Costo")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbCosto" Text='<%# Eval("Costo")%>' />  
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbCostoFooter" />
                    </FooterTemplate>
                    </asp:TemplateField>
                    <%--<PRECIO>--%>
                    <asp:TemplateField HeaderText="Precio">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("PrecioVenta")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbPrecio" Text='<%# Eval("PrecioVenta")%>' />  
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
