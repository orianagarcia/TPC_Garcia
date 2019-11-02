<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="WebAplication.prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:BootstrapGridView runat="server" KeyFieldName="CustomerID" DataSourceID="DataSourceDataToggleInRows">
    <Columns>
        <asp:BootstrapGridViewDataColumn FieldName="CompanyName">
            <DataItemTemplate>
                <%# Eval("CompanyName") %>
                <button type="button" class="btn btn-link" data-toggle="gridview-datarow-edit">
                    <span class="fa fa-pencil-alt"></span>
                </button>
                <button type="button" class="btn btn-link" data-toggle="gridview-datarow-delete">
                    <span class="fa fa-trash"></span>
                </button>
            </DataItemTemplate>
        </asp:BootstrapGridViewDataColumn>
        <asp:BootstrapGridViewDataColumn FieldName="ContactName"></asp:BootstrapGridViewDataColumn>
        <asp:BootstrapGridViewDataColumn FieldName="Country"></asp:BootstrapGridViewDataColumn>
        <asp:BootstrapGridViewDataColumn FieldName="City"></asp:BootstrapGridViewDataColumn>
        <aso:BootstrapGridViewDataColumn FieldName="Address"></aso:BootstrapGridViewDataColumn>
    </Columns>
    <Settings ShowTitlePanel="true" />
    <Templates>
        <TitlePanel>
            Customers
            <button type="button" class="btn btn-link" data-toggle="gridview-newrow">
                <span class="fa fa-plus"></span>
            </button>
        </TitlePanel>
    </Templates>
    <SettingsDataSecurity AllowDelete="true" AllowEdit="true" AllowInsert="true" />
</asp:BootstrapGridView>
</asp:Content>
