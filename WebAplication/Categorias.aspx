<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="WebAplication.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <h2 class="btn btn-info" style = color: " White">Categorias</h2>
    </div>
    <%--</div>--%>
    <div class="form-row ">
        <asp:GridView ID="dgvCategorias" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ID" 
            OnRowCommand="dgvCategorias_RowCommand" OnRowEditing="dgvCategorias_RowEditing"
            OnRowCancelingEdit="dgvCategorias_RowCancelingEdit" OnRowUpdating="dgvCategorias_RowUpdating"
            OnRowDeleting="dgvCategorias_RowDeleting">
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
