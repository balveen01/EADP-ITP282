<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/TemplateMaster.Master" AutoEventWireup="true" CodeBehind="Sign-In.aspx.cs" Inherits="Triangle.w.Sign_In" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Sign In | Triangle
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_btn_Submit {
            width: 100% !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="container">
        <div class="row mx-0">
            <div class="col-md-6 col-md-offset-3">
                <div class="form-group text-center">
                    <h1 class="display-4 text-white">Sign In
                    </h1>

                    <div class="form-group">
                        <asp:TextBox ID="tb_Username" runat="server" placeholder="Username" CssClass="form-control" autofocus="autofocus"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Username" runat="server" ErrorMessage="Please enter a username" ControlToValidate="tb_Username" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="tb_Password" runat="server" placeholder="Password" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Password" runat="server" ErrorMessage="Please enter a password" ControlToValidate="tb_Password" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <asp:Button ID="btn_Submit" runat="server" Text="Sign in" CssClass="btn btn-success" OnClick="btn_Submit_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
