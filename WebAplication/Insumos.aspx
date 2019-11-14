<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Insumos.aspx.cs" Inherits="WebAplication.Insumos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div>
        <h2 style= "color:Green ">Insumos</h2>
    </div>
    <%--</div>--%>
    <div class="form-row ">
        <asp:GridView ID="dgvInsumos" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ID" 
                       OnRowCommand="dgvInsumos_RowCommand" OnRowEditing="dgvInsumos_RowEditing"
            OnRowCancelingEdit="dgvInsumos_RowCancelingEdit" OnRowUpdating="dgvInsumos_RowUpdating"
            OnRowDeleting="dgvInsumos_RowDeleting" OnRowDataBound="dgvInsumos_RowDataBound">
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
               <%--<MEDIDA>--%>
                    <asp:TemplateField HeaderText="Medida">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("Medida")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
              <%--<asp:TextBox runat="server" ID="txbMedida" Text='<%# Eval("Medida")%>' /> --%>  
                      <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="Nombre" DataValueField="ID">  
                        </asp:DropDownList>  
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:TextBox runat="server" ID="txbMedidaFooter" />
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
    <%-- --%>
</asp:Content>
