<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="WebAplication.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h2 class="btn btn-info" style = color: " White">Clientes</h2>
    </div>
    <%--</div>--%>
    <div class="form-row ">
        <asp:GridView ID="dgvClientes" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ID" 
            OnRowCommand="dgvClientes_RowCommand" OnRowEditing="dgvClientes_RowEditing"
            OnRowCancelingEdit="dgvClientes_RowCancelingEdit" OnRowUpdating="dgvClientes_RowUpdating"
            OnRowDeleting="dgvClientes_RowDeleting">
            <columns>
                  <%--<DNI>--%>
                    <asp:TemplateField HeaderText="DNI">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("dni")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbdni" Text='<%# Eval("dni")%>' />  
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbdniFooter" />
                    </FooterTemplate>
                    </asp:TemplateField>
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
                   <%--<APELLIDO>--%>
                    <asp:TemplateField HeaderText="Apellido">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("Apellido")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbApellido" Text='<%# Eval("Apellido")%>' />  
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbApellidoFooter" />
                    </FooterTemplate>
                    </asp:TemplateField>
               <%--<DIRECCION>--%>
                    <asp:TemplateField HeaderText="Direccion">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("Direccion")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbDireccion" Text='<%# Eval("Direccion")%>' />  
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbDireccionFooter" />
                    </FooterTemplate>
                    </asp:TemplateField>
               <%--<LOCALIDAD>--%>
                    <asp:TemplateField HeaderText="Localidad">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("Localidad")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbLocalidad" Text='<%# Eval("Localidad")%>' />  
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbLocalidadFooter" />
                    </FooterTemplate>
                    </asp:TemplateField>
               <%--<TELEFONO>--%>
                    <asp:TemplateField HeaderText="Telefono">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("Telefono")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbTelefono" Text='<%# Eval("Telefono")%>' />  
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbTelefonoFooter" />
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
