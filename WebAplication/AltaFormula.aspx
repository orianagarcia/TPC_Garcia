﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaFormula.aspx.cs" Inherits="WebAplication.AltaFormula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
       <asp:Label ID="lbl" runat="server" Text="Nueva Formula" class="btn btn-info"></asp:Label>
          <br /><br />
    <asp:Label Text="Fecha" runat="server" cssClass="btn btn-info" />
    <asp:TextBox id="txbFecha"  runat="server" Height="25px" Width="111px" TextMode="DateTime" class="btn btn-secondary"/>  
        <br />
        <br />
   
    <asp:Label ID="lblProducto" runat="server" Text="Producto" cssClass="btn btn-info"></asp:Label>
    <asp:DropDownList ID="ddlProductos" runat="server" class="btn btn-secondary dropdown-toggle" > </asp:DropDownList>

       <asp:Label ID="lblInsumo" runat="server" Text="Insumo" cssClass="btn btn-info"></asp:Label>
    <asp:DropDownList ID="ddlInsumos" runat="server" class="btn btn-secondary dropdown-toggle"> </asp:DropDownList>
           
     <asp:Label ID="lblCantidad" runat="server" Text="Cantidad" cssClass="btn btn-info"></asp:Label>
     <asp:TextBox ID="txbCantidad" Text="0" runat="server" class="btn btn-secondary"></asp:TextBox>
         <asp:Label ID="lblMedida" Text="" runat="server" />
        <asp:Button cssClass="btn btn-info" ID="btnAgregarInsumo" runat="server" OnClick="btnAgregarInsumo_Click" Text="Agregar Insumo" />
        <br />
        </div>
    <asp:GridView ID="dgvFormulas" CssClass="table table-striped" runat="server"  AutoGenerateColumns="false" ShowFooter="false" DataKeyNames="ID" OnRowDeleting="dgvFormulas_RowDeleting">
                    
            <columns>
                 
                 <%--<Producto>--%>
                    <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("producto.nombre")%>' runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>
               <%--<INSUMO>--%>
                    <asp:TemplateField HeaderText="Insumo">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("insumo.nombre")%>' runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>
               <%--<CANTIDAD>--%>
                    <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("Cantidad")%>' runat="server" />
                    </ItemTemplate>
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
        <br />
        <asp:Button cssClass="btn btn-info" ID="btnGuardarFormula" runat="server" OnClick="btnGuardarFormula_Click" Text="Guardar Formula" />

        <br />
        <asp:Label ID="lblCorrecto" Text="" runat="server" forecolor="Green"/>
        <br />
        <asp:Label ID="lblIncorrecto" Text="" runat="server" forecolor="Red"/>
</asp:Content>
