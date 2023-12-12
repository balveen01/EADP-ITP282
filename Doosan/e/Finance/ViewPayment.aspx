<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/InvoiceMaster.master" AutoEventWireup="true" CodeBehind="ViewPayment.aspx.cs" Inherits="Doosan.e.Finance.ViewPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Payments
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Payments {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Payments</h1>
            <hr />

            <asp:GridView ID="gv_Payment" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_Payment_SelectedIndexChanged" CssClass="table table-striped table-bordered" DataKeyNames="payment_id" OnRowDeleting="gv_Payment_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="payment_id" HeaderText="Payment Id" />
                    <asp:BoundField DataField="description" HeaderText="Description" />
                    <asp:BoundField DataField="total_price" HeaderText="Total Price" />
                    <asp:BoundField DataField="expiry_date" HeaderText="Expiry Date" />
                    <asp:BoundField DataField="is_received" HeaderText="Status" />
                    <asp:BoundField DataField="is_declined" HeaderText="Declined" />
                    <asp:CommandField ShowSelectButton="True" SelectText="View" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
