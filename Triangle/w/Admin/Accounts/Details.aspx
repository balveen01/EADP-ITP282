<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/AccountsMaster.master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Triangle.w.Admin.Accounts.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Account Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Accounts_View {
            color: #0088CC;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <div class="d-flex justify-content-between">
                <h1>Viewing User ID:
                        <asp:Label ID="lbl_StaffID" runat="server"></asp:Label></h1>

            </div>
            <hr />


            <div class="row no-gutters justify-content-between">
                <div class="col-md-5">
                    <div class="form-group">
                        <div class="d-flex justify-content-between">
                            <p id="p_Activated" runat="server" class="text-success">User is activated</p>
                            <p id="p_Deactivated" runat="server" class="text-danger">User is deactivated</p>

                            <asp:Button ID="btn_change_to_not_archived" runat="server" Text="Reactivate User" OnClick="btn_change_to_not_archived_Click" CssClass="btn btn-outline-info" />
                            <asp:Button ID="btn_change_to_archived" runat="server" Text="Deactivate User" OnClick="btn_change_to_archived_Click" CssClass="btn btn-outline-info" />
                        </div>
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
                        <asp:Label ID="lbl_Role" runat="server" Text="Role"></asp:Label>
                        <asp:TextBox ID="tb_Role" runat="server" CssClass="form-control text-capitalize"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <div class="d-flex justify-content-between">
                            <asp:Button ID="btn_Back" runat="server" CssClass="btn btn-outline-danger" Text="Go Back" OnClick="btn_Back_Click" />

                            <div>

                                <asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-primary" Text="Make Changes" OnClick="btn_Submit_Click" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
