<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/InvoiceMaster.master" AutoEventWireup="true" CodeBehind="ViewInvoice.aspx.cs" Inherits="Doosan.e.Finance.ViewInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    View Invoice
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        table {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Invoice List</h1>
            <hr />

            <asp:GridView ID="gv_InvoiceList" runat="server" AutoGenerateColumns="False" EmptyDataText="There is nothing in your invoice list." CssClass="table table-striped table-bordered" AllowPaging="True" OnPageIndexChanging="gv_InvoiceList_PageIndexChanging" OnSelectedIndexChanged="gv_InvoiceList_SelectedIndexChanged" PageSize="10">
                <Columns>
                    <asp:BoundField DataField="order_id" HeaderText="Customer order ID"></asp:BoundField>
                    <asp:BoundField DataField="order_date" HeaderText="Order Date"></asp:BoundField>
                    <asp:BoundField DataField="total_price" DataFormatString="{0:C}" HeaderText="Total Amount"></asp:BoundField>
                    <asp:BoundField DataField="company_name" HeaderText="Company"></asp:BoundField>
                    <asp:BoundField DataField="is_delivered" HeaderText="Delivery Status"></asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" SelectText="Create Invoice"></asp:CommandField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
