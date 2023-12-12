<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/FinanceMaster.master" AutoEventWireup="true" CodeBehind="PaymentDetail.aspx.cs" Inherits="Triangle.w.Admin.Finance.PaymentDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Payment Details
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
            <div class="row no-gutters">
                <div class="col-12">
                    <h1>Payment Details</h1>
                    <hr />

                    <div class="d-flex justify-content-between">
                        <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CssClass="btn btn-danger" />
                    </div>
                    <hr />

                </div>
            </div>

            <div class="row col-md-5">
                <div class="form-group w-100">
                    Payment Id: 
                    <asp:Label ID="lbl_paymentid" runat="server"></asp:Label>
                </div>

                <div class="form-group w-100">
                    Description: 
                    <asp:TextBox ID="tb_description" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group w-100">
                    Total Price: 
                    <asp:TextBox ID="tb_totalprice" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group w-100">
                    Expiry Date: 
                    <asp:TextBox ID="tb_expirydate" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group w-100">
                    Status: 
                    <asp:TextBox ID="tb_isreceived" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group w-100">
                    Declined: 
                    <asp:TextBox ID="tb_isdeclined" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="d-flex justify-content-between w-100">
                    <asp:Button ID="btn_archive" runat="server" OnClick="btn_archive_Click" Text="Archive" CssClass="btn btn-warning" />
                    <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
