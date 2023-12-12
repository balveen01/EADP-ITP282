<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/_settings/Bootstrap.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Doosan.Sign_in" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Sign in
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        body {
            background: linear-gradient(14deg, rgba(91, 91, 91, 0.05) 0%, rgba(91, 91, 91, 0.05) 25%,rgba(242, 242, 242, 0.05) 25%, rgba(242, 242, 242, 0.05) 50%,rgba(100, 100, 100, 0.05) 50%, rgba(100, 100, 100, 0.05) 75%,rgba(249, 249, 249, 0.05) 75%, rgba(249, 249, 249, 0.05) 100%),linear-gradient(12deg, rgba(44, 44, 44, 0.05) 0%, rgba(44, 44, 44, 0.05) 25%,rgba(41, 41, 41, 0.05) 25%, rgba(41, 41, 41, 0.05) 50%,rgba(139, 139, 139, 0.05) 50%, rgba(139, 139, 139, 0.05) 75%,rgba(250, 250, 250, 0.05) 75%, rgba(250, 250, 250, 0.05) 100%),linear-gradient(144deg, rgba(111, 111, 111, 0.05) 0%, rgba(111, 111, 111, 0.05) 25%,rgba(205, 205, 205, 0.05) 25%, rgba(205, 205, 205, 0.05) 50%,rgba(184, 184, 184, 0.05) 50%, rgba(184, 184, 184, 0.05) 75%,rgba(152, 152, 152, 0.05) 75%, rgba(152, 152, 152, 0.05) 100%),linear-gradient(90deg, rgb(35, 40, 64),rgb(24, 66, 207));
            height: 100%;
            min-height: 100vh;
            width: 100%;
            overflow: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center mx-0">
            <div class="col-lg-10 col-sm-10">
                <div class="table-display">
                    <div class="table-child">
                        <div class="form-group text-center">
                            <h1 class="display-4 text-white">Admin Portal
                            </h1>
                        </div>

                        <div class="row no-gutters justify-content-center py-4">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="tb_Username" runat="server" placeholder="Username" CssClass="form-control" autofocus="autofocus"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_Username" runat="server" ErrorMessage="Please enter a username" ControlToValidate="tb_Username" Display="Dynamic" ForeColor="white"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group">
                                    <asp:Button ID="btn_Submit" runat="server" Text="Sign in" CssClass="btn btn-success w-100" onclick="btn_Submit_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
