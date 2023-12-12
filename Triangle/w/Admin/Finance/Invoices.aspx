<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/FinanceMaster.master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="Triangle.w.Admin.Finance.Invoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Invoices
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Invoices {
            color: #007bff;
        }
        table {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Invoices</h1>
            <hr />

            <asp:GridView ID="gvInvoice" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" AllowPaging="True" DataKeyNames="invoice_id" OnSelectedIndexChanged="gvInvoice_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="invoice_id" HeaderText="Invoice ID" />
                <asp:BoundField DataField="invoiced_date" HeaderText="Date" />
                <asp:BoundField DataField="payment_type" HeaderText="Payment" />
                <asp:BoundField DataField="credit_terms" HeaderText="Credit Terms" />
                <asp:BoundField DataField="is_outstanding" HeaderText="Status" />
                <asp:BoundField DataField="total_price" HeaderText="Price" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
