<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/FinanceMaster.master" AutoEventWireup="true" CodeBehind="PaymentArchived.aspx.cs" Inherits="Triangle.w.Admin.Finance.PaymentArchived" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Archived Payments
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Payments_Archived {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters">
        <div class="col-md-12">
            <h1>Archived Payments</h1>

            <asp:GridView ID="gv_payments" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="payment_id" HeaderText="Payment Id" />
                    <asp:BoundField DataField="description" HeaderText="Description" />
                    <asp:BoundField DataField="total_price" HeaderText="Total Price" />
                    <asp:BoundField DataField="expiry_date" HeaderText="Expiry Date" />
                    <asp:BoundField DataField="is_received" HeaderText="Status" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
