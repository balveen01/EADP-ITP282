<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/InvoiceMaster.master" AutoEventWireup="true" CodeBehind="InvoiceSummary.aspx.cs" Inherits="Doosan.e.Finance.InvoiceSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
         #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Invoices {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-11">
            <h1>Invoice for
                <asp:Label ID="lbl_client" runat="server" Text="lbl_client"></asp:Label></h1>
            <hr />
            <asp:Button ID="btn_back" runat="server" Text="Go back" CssClass="btn btn-danger" />
            <hr />

            <div class="card">
                <div class="card-body">
                    <div class="form-group">
                        Invoice ID
                    <asp:Label ID="lbl_invoice_id" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                    </div>

                    <div class="form-group">
                        Invoice Date
                        <asp:Label ID="lbl_invoiced_date" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="451px">
                <Columns>
                    <asp:BoundField DataField="product_id" />
                    <asp:BoundField DataField="product_name" HeaderText="Product" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="unit_price" HeaderText="Unit price" />
                    <asp:BoundField DataField="total_price" HeaderText="Total Price" />
                </Columns>
            </asp:GridView>

            <br />
            <asp:Label ID="Label1" runat="server" Text="Grand Total : "></asp:Label>
            <asp:Label ID="lbl_grand_total" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btn_payNow0" runat="server" Text="Proceed to payment" />
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
