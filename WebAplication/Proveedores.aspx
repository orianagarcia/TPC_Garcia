<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="WebAplication.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="form-row">
            
        </div>
    </div>

    <%--   <div class="container">
        <div class="form-row">
            <div class="form-group col-md-4">
                <h2>Proveedores</h2>
            </div>
        </div>--%>

    <div class="form-row form-group ">

        <asp:Label Text=" Nombre   " ID="lblNombre" runat="server" Style="margin-top: 30px; margin-left: 30px;"></asp:Label>
        <asp:TextBox ID="txbNombre" runat="server" Style="margin-top: 30px; margin-left: 30px;"> </asp:TextBox>

    </div>
    <div class="form-row form-group">
        <asp:Label Text=" Telefono " ID="lblTelefono" runat="server" Style="margin-top: 30px; margin-left: 30px;"></asp:Label>
        <asp:TextBox ID="txbTelefono" runat="server" Style="margin-top: 30px; margin-left: 30px;">  </asp:TextBox>

    </div>

    <div class="form-row form-group">

        <asp:Label Text=" Direccion " ID="lblDireccion" runat="server" Style="margin-top: 30px; margin-left: 30px;"></asp:Label>
        <asp:TextBox ID="txbDireccion" runat="server" Style="margin-top: 30px; margin-left: 30px;">  </asp:TextBox>

    </div>
    <div class="form-row form-group">

        <asp:Button Text=" Agregar " ID="BtnAgregar" runat="server" OnClick="BtnAgregar_Click" Style="margin-top: 30px; margin-left: 30px;"></asp:Button>

    </div>
    <%--</div>--%>
    <div>
        <asp:GridView ID="dgvProveedores" runat="server">
        </asp:GridView>
    </div>
    <%--  --%>
</asp:Content>

