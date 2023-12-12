<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/FinanceMaster.master" AutoEventWireup="true" CodeBehind="PaymentInsert.aspx.cs" Inherits="Triangle.w.Admin.Finance.PaymentInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Create Payment
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Payment_Insert {
            color: #007bff;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-start mt-4">
        <div class="col-md-12">
            <h1>Create a payment</h1>
            <hr />
        </div>

        <div class="col-md-4">
            <div class="form-group w-100">
                Description:
                <asp:TextBox ID="tb_description" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group w-100">
                Total Price:
                <asp:TextBox ID="tb_totalprice" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group w-100">
                Bank Name:
                <asp:TextBox ID="tb_bankname" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group w-100">
                Bank Number:
                <asp:TextBox ID="tb_banknumber" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group w-100">
                Bank_Branch:
                <asp:TextBox ID="tb_bankbranch" runat="server" CssClass="form-control"></asp:TextBox>
            </div>


            <div class="form-group w-100">
                <asp:Button ID="btn_makepayment" runat="server" Text="Confirm Payment" OnClick="btn_makepayment_Click" CssClass="btn btn-primary" />
            </div>
        </div>

        <div class="col-md-4 ml-5">
            <div class="form-group w-100">
                Card Name:
                <asp:TextBox ID="tb_cardname" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group w-100">
                Card Number:
                <asp:TextBox ID="tb_cardnumber" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group w-100">
                Expiry Date:
                <asp:TextBox ID="tb_expirydate" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group w-100">
                Payment Date:
                <asp:TextBox ID="tb_paymentdate" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group w-100">
                Payment Method:
                <asp:TextBox ID="tb_paymentmethod" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
