<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/AccountsMaster.master" AutoEventWireup="true" CodeBehind="Add-Staff.aspx.cs" Inherits="Doosan.w.Accounts.Add_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Add Staff
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Accounts_Add {
            color: #007bff;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <div class="row no-gutters">
                <h1>Add New Staff</h1>
            </div>
            <hr />
            <div class="row no-gutters justify-content-between">
                <div class="col-md-10">
                    <div class="form-group">
                        <asp:Label ID="lbl_Username" runat="server" Text="Username"></asp:Label>
                        <asp:TextBox ID="tb_Username" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lbl_Name" runat="server" Text="Name"></asp:Label>
                        <asp:TextBox ID="tb_Name" runat="server" CssClass="form-control text-capitalize"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lbl_Email" runat="server" Text="Email"></asp:Label>
                        <div class="input-group mb-3">
                            <asp:TextBox ID="tb_Email" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="input-group-append">
                                <span class="input-group-text">@doosan.com</span>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lbl_Dept" runat="server" Text="Department"></asp:Label>
                        <asp:DropDownList ID="ddl_Dept" runat="server" CssClass="form-control text-capitalize">
                            <asp:ListItem Value="operations">Operations</asp:ListItem>
                            <asp:ListItem Value="finance">Finance</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <div class="d-flex justify-content-end">
                            <asp:Button ID="btn_Create" runat="server" CssClass="btn btn-primary" OnClick="btn_Create_Click" Text="Create Account" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
