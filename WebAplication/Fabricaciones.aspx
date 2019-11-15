<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Fabricaciones.aspx.cs" Inherits="WebAplication.Fabricaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div>
        <h2 style= "color:Green ">Fabricaciones</h2>
    </div>
    <%--</div>--%>
    <div class="form-row ">
        <asp:GridView ID="dgvFabricaciones" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ID" 
            OnRowCommand="dgvFabricaciones_RowCommand" OnRowEditing="dgvFabricaciones_RowEditing"
            OnRowCancelingEdit="dgvFabricaciones_RowCancelingEdit" OnRowUpdating="dgvFabricaciones_RowUpdating"
            OnRowDeleting="dgvFabricaciones_RowDeleting">
            <columns>
                  <%--<idProducto>--%>
                    <asp:TemplateField HeaderText="idProducto">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("idProducto")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbidProducto" Text='<%# Eval("idProducto")%>' />  
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbidProductoFooter" />
                    </FooterTemplate>
                    </asp:TemplateField>
                 <%--<idEmpleado>--%>
                    <asp:TemplateField HeaderText="idEmpleado">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("idEmpleado")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbidEmpleado" Text='<%# Eval("idEmpleado")%>' />  
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbidEmpleadoFooter" />
                    </FooterTemplate>
                    </asp:TemplateField>
                   <%--<Cantidad>--%>
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
