<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Formulas.aspx.cs" Inherits="WebAplication.prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div>
        <h2 class="btn btn-info" style = color: " White" >Formulas</h2>
    </div>
     <div class="form-row"   Style="margin-top: 30px; margin-left: 30px;"> 
        <h5 class="btn btn-info" >Seleccione un producto para ver su formula </h5>
        <asp:DropDownList ID="cboBuscar" runat="server" class="btn btn-secondary dropdown-toggle"> </asp:DropDownList>
        <asp:Button class="btn btn-info" ID="btnBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click"/>
        <asp:Button class="btn btn-info" ID="btnCancelar" Text="Volver atras" runat="server" OnClick="btnCancelar_Click1" Visible="false"/>
    </div>
    <%--</div>--%>
    <div class="form-row ">
        <asp:GridView ID="dgvFormulas" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ID" 
            OnRowEditing="dgvFormulas_RowEditing" OnRowCommand="dgvFormulas_RowCommand" 
            OnRowCancelingEdit="dgvFormulas_RowCancelingEdit" OnRowUpdating="dgvFormulas_RowUpdating"
            OnRowDeleting="dgvFormulas_RowDeleting">
            <columns>
                  <%--<ID>--%>
                    <asp:TemplateField HeaderText="ID" >
                    <ItemTemplate> 
                        <asp:label ID="lblId" text='<%# Eval("id")%>' runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>
               <%--<PRODUCTO>--%>
                    <asp:TemplateField HeaderText="Producto">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("producto.nombre")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox ID="txbProductos" runat="server" Enabled="false"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                       <asp:TextBox ID="txbProductosFooter" runat="server" Enabled="false"></asp:TextBox>
                    </FooterTemplate>
                    </asp:TemplateField>
                 <%--<INSUMO>--%>
                    <asp:TemplateField HeaderText="Insumo">
                    <ItemTemplate> 
                        <asp:label ID="lblInsumo" text='<%# Eval("insumo.nombre")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                          <asp:DropDownList ID="ddlInsumos" runat="server" DataTextField="insumo.nombre" DataValueField="insumo.id" ></asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:DropDownList ID="ddlInsumosFooter" runat="server" DataTextField="insumo.nombre" DataValueField="insumo.id"></asp:DropDownList>
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
