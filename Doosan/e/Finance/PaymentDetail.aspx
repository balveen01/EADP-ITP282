<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/InvoiceMaster.master" AutoEventWireup="true" CodeBehind="PaymentDetail.aspx.cs" Inherits="Doosan.e.Finance.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Payments {
            color: #007bff;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters mt-4">
        <div class="col-md-12">
            <h1>View Payment Details</h1>
            <hr />
        </div>

        <div class="col-md-5">
            <div class="form-group">
                Payment Id:
                <asp:Label ID="lbl_paymentid" runat="server" CssClass="form-control" readonly="true"></asp:Label>
            </div>

            <div class="form-group">
                Description:
                  <asp:Label ID="lbl_description" runat="server" CssClass="form-control" readonly="true"></asp:Label>
            </div>

            <div class="form-group">
                Total Price:
                  <asp:Label ID="lbl_total" runat="server" CssClass="form-control" readonly="true"></asp:Label>
            </div>

            <div class="form-group">
                Expiry Date:
                 <asp:Label ID="lbl_expiry" runat="server" CssClass="form-control" readonly="true"></asp:Label>
            </div>

            <div class="form-group">
                Status:
                  <asp:Label ID="lbl_status" runat="server" CssClass="form-control" readonly="true"></asp:Label>
            </div>

            <div class="form-group">
                Declined:
                  <asp:Label ID="lbl_decline" runat="server" CssClass="form-control" readonly="true"></asp:Label>
            </div>

            <div class="d-flex justify-content-between">
                <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CssClass="btn btn-danger" />

                <div>
                    <asp:Button ID="btn_approve" runat="server" Text="Approve" OnClick="btn_approve_Click" CssClass="btn btn-success" />
                    <asp:Button ID="btn_decline" runat="server" Text="Decline" OnClick="btn_decline_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
