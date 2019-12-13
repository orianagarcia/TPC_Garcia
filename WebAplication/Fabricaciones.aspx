﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Fabricaciones.aspx.cs" Inherits="WebAplication.Fabricaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div>
        <h2 class="btn btn-info" style = color: " White">Fabricaciones</h2>
    </div>
    <div>
     <asp:Label ID="lblProducto" runat="server" Text="Producto" class="btn btn-info"></asp:Label>
    <asp:DropDownList ID="ddlProductos" runat="server" class="btn btn-secondary dropdown-toggle" > </asp:DropDownList>

       <asp:Label ID="lblInsumo" runat="server" Text="Empleados" class="btn btn-info"></asp:Label>
    <asp:DropDownList ID="ddlEmpleados" runat="server" class="btn btn-secondary dropdown-toggle" > </asp:DropDownList>
           
     <asp:Label ID="lblCantidad" runat="server" Text="Cantidad" class="btn btn-info"></asp:Label>
     <asp:TextBox ID="txbCantidad" Text="0" runat="server" class="btn btn-secondary"></asp:TextBox>

 <asp:Label ID="lblEstados" runat="server" Text="Estado" class="btn btn-info" ></asp:Label>
        <asp:DropDownList runat="server" ID="ddlEstados" class="btn btn-secondary dropdown-toggle">
            <asp:ListItem Text="Completado" />
            <asp:ListItem Text="Pendiente" />
             <asp:ListItem Text="Cancelado" />
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label Text="Fecha inicio" runat="server" class="btn btn-info"/>
        <asp:TextBox ID="txbInicio" runat="server" TextMode="Date" />  
        <asp:Label Text="Fecha Fin" runat="server" class="btn btn-info"/>
        <asp:TextBox ID="txbFin" runat="server" TextMode="Date" />
        <asp:Button ID="btnAgregar" Text="Agregar" runat="server" OnClick="btnAgregar_Click" class="btn btn-info"/>
    </div>
        <asp:Label ID="lblCorrecto" Text="" runat="server" forecolor="Green"/>
        <br />
        <asp:Label ID="lblIncorrecto" Text="" runat="server" forecolor="Red"/>
    <%--</div>--%>
    <div class="form-row ">
        <asp:GridView ID="dgvFabricaciones" CssClass="table table-striped" runat="server" AutoGenerateColumns="false"  DataKeyNames="ID" 
            OnRowCommand="dgvFabricaciones_RowCommand" OnRowEditing="dgvFabricaciones_RowEditing"
            OnRowCancelingEdit="dgvFabricaciones_RowCancelingEdit" OnRowUpdating="dgvFabricaciones_RowUpdating"
            OnRowDeleting="dgvFabricaciones_RowDeleting">
            <columns>
                  <%--<idProducto>--%>
                    <asp:TemplateField HeaderText="Producto">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("producto.nombre")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:DropDownList runat="server" ID="ddlProductos" />  
                    </EditItemTemplate>
                     </asp:TemplateField>
                 <%--<idEmpleado>--%>
                    <asp:TemplateField HeaderText="Empleado">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("empleado.nombre")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:DropDownList runat="server" ID="ddlEmpleados" /> 
                    </EditItemTemplate>
                    </asp:TemplateField>
                   <%--<Cantidad>--%>
                    <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("Cantidad")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox runat="server" ID="txbCantidad" Text='<%# Eval("Cantidad")%>' />  
                    </EditItemTemplate>
                    </asp:TemplateField>
                 <%--<ESTADO>--%>
                    <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("estadoFab")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:DropDownList runat="server" ID="ddlEstadoEdit">
                            <asp:ListItem Text="Completado" />
                            <asp:ListItem Text="Pendiente" />
                            <asp:ListItem Text="Cancelado" />
                        </asp:DropDownList>
                    </EditItemTemplate>
                    </asp:TemplateField>
                <%--<Fecha inicio>--%>
                    <asp:TemplateField HeaderText="Fecha inicio">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("fechaInicio")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:Textbox runat="server" ID="txbFechaI" TextMode="Date" />  
                    </EditItemTemplate>
                     </asp:TemplateField>
                <%--<Fecha Fin>--%>
                    <asp:TemplateField HeaderText="Fecha Fin">
                    <ItemTemplate> 
                        <asp:label text='<%# Eval("fechaFin")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:Textbox runat="server" ID="txbFechaFin" TextMode="Date" />  
                    </EditItemTemplate>
                     </asp:TemplateField>
                   <%--<ACCIONES >--%>
                    <asp:TemplateField >
                    <ItemTemplate> 
                        <asp:ImageButton ImageUrl="~/Images/modificar.png" runat="server" CommandName="Edit" Tooltip="edit" width="20px" Height="20px"/>
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
