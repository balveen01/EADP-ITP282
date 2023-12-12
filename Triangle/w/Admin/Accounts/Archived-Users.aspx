<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/AccountsMaster.master" AutoEventWireup="true" CodeBehind="Archived-Users.aspx.cs" Inherits="Triangle.w.Admin.Accounts.Archived_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Archived Users
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Accounts_Archived {
            color: #0088CC;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters mt-4">
        <div class="col-12">
            <div class="d-flex justify-content-between">
                <h1>Deactivated Users</h1>

                <div class="form-inline ml-auto">
                    <asp:DropDownList ID="ddl_Filter" runat="server" OnSelectedIndexChanged="ddl_Filter_SelectedIndexChanged" CssClass="form-control mr-2" AutoPostBack="true">
                        <asp:ListItem Value="customer">Customer</asp:ListItem>
                        <asp:ListItem Value="admin">Admin</asp:ListItem>
                    </asp:DropDownList>

                    <asp:TextBox ID="tb_Search" runat="server" CssClass="form-control rounded-0 border-right-0" type="search" placeholder="Search" aria-label="Search"></asp:TextBox>
                    <asp:Button ID="btn_Search" runat="server" CssClass="btn btn-outline-success rounded-0" type="submit" Text="Search" OnClick="btn_Search_Click"></asp:Button>
                </div>
            </div>

            <hr />

            <asp:GridView ID="gv_Accounts" runat="server" DataKeyNames="id" AutoGenerateColumns="False" CssClass="table table-striped border" AllowPaging="True" PageSize="10" SortedDescendingHeaderStyle-VerticalAlign="Top" OnSelectedIndexChanged="gv_Accounts_SelectedIndexChanged" OnPageIndexChanging="gv_Accounts_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="id" SortExpression="id" HeaderText="ID" ItemStyle-Width="5%" />
                    <asp:BoundField DataField="username" SortExpression="username" HeaderText="Username" ItemStyle-Width="20%" />
                    <asp:BoundField DataField="name" SortExpression="name" HeaderText="Name" ItemStyle-CssClass="text-capitalize" ItemStyle-Width="20%" />
                    <asp:BoundField DataField="email" SortExpression="email" HeaderText="Email" ItemStyle-Width="30%" />
                    <asp:BoundField DataField="role" SortExpression="role" HeaderText="Role" ItemStyle-CssClass="text-capitalize" ItemStyle-Width="20%" />
                    <asp:CommandField ShowSelectButton="True" SelectText="View" ItemStyle-Width="5%" />
                </Columns>
                <HeaderStyle HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
