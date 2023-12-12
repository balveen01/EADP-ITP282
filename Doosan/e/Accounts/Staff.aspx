<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/AccountsMaster.master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Doosan.e.Accounts.Staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    View Staff
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Accounts_View {
            color: #007bff;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <div class="row no-gutters">
                <h1>Viewing Staff ID:
                    <asp:Label ID="lbl_StaffID" runat="server"></asp:Label></h1>
            </div>
            <hr />

            <div class="row no-gutters justify-content-between">
                <div class="col-md-10">
                    <div class="d-flex justify-content-end">
                        <asp:Button ID="btn_Deactivate" runat="server" CssClass="btn btn-sm btn-outline-success" Text="Account is ACTIVATED, click here to deactivate account" OnClick="btn_Deactivate_Click"/>
                        <asp:Button ID="btn_Activate" runat="server" CssClass="btn btn-sm btn-outline-danger" Text="Account is DEACTIVATED, click here to activate account" OnClick="btn_Activate_Click"/>
                    </div>
                    <hr />

                    <div class="form-group">
                        <asp:Label ID="lbl_Username" runat="server" Text="Username"></asp:Label>
                        <asp:TextBox ID="tb_Username" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lbl_Name" runat="server" Text="Name"></asp:Label>
                        <asp:TextBox ID="tb_Name" runat="server" CssClass="form-control text-capitalize"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lbl_Email" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="tb_Email" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lbl_Dept" runat="server" Text="Department"></asp:Label>
                        <asp:DropDownList ID="ddl_Dept" runat="server" CssClass="form-control text-capitalize">
                            <asp:ListItem Value="operations">Operations</asp:ListItem>
                            <asp:ListItem Value="finance">Finance</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <div class="d-flex justify-content-between">
                            <asp:Button ID="btn_Back" runat="server" CssClass="btn btn-outline-danger" Text="Go Back" OnClick="btn_Back_Click" />
                            <asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-outline-primary" Text="Make Changes" OnClick="btn_Submit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
