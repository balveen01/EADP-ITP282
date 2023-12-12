<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/AccountsMaster.master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Doosan.w.Accounts.View" %>

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
                <div class="col-12">
                    <div class="d-flex flex-row justify-content-between">
                        <h1>Staff Directory</h1>

                        <div class="form-inline">
                           <%-- <div class="btn-group">
                                <button type="button" class="btn border-info mr-2 dropdown-toggle w-100" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    Sort by Department
                                </button>
                                <div class="dropdown-menu">
                                    <asp:LinkButton ID="lbtn_Operations" runat="server" CssClass="dropdown-item" OnClick="lbtn_Operations_Click">Operations</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Delivery" runat="server" CssClass="dropdown-item" OnClick="lbtn_Delivery_Click">Delivery</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Finance" runat="server" CssClass="dropdown-item" OnClick="lbtn_Finance_Click">Finance</asp:LinkButton>
                                </div>
                            </div>--%>

                            <asp:TextBox ID="tb_Search" runat="server" CssClass="form-control rounded-0 border-right-0" type="search" placeholder="Search" aria-label="Search"></asp:TextBox>
                            <asp:Button ID="btn_Search" runat="server" CssClass="btn btn-outline-success rounded-0" type="submit" Text="Search" OnClick="btn_Search_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
            <hr />
            <div class="row no-gutters">
                <div class="col-12">
                    <asp:GridView ID="gv_Staff" runat="server" DataKeyNames="id" AutoGenerateColumns="False" CssClass="table table-striped border" AllowPaging="True" PageSize="10" SortedDescendingHeaderStyle-VerticalAlign="Top" OnSelectedIndexChanged="gv_Staff_SelectedIndexChanged" OnPageIndexChanging="gv_Staff_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="id" SortExpression="id" HeaderText="ID" ItemStyle-Width="5%" />
                            <asp:BoundField DataField="username" SortExpression="username" HeaderText="Username" ItemStyle-Width="20%" />
                            <asp:BoundField DataField="name" SortExpression="name" HeaderText="Name" ItemStyle-CssClass="text-capitalize" ItemStyle-Width="20%" />
                            <asp:BoundField DataField="email" SortExpression="email" HeaderText="Email" ItemStyle-Width="30%" />
                            <asp:BoundField DataField="department" SortExpression="department" HeaderText="Department" ItemStyle-CssClass="text-capitalize" ItemStyle-Width="20%" />
                            <asp:CommandField ShowSelectButton="True" SelectText="View" ItemStyle-Width="5%" />
                        </Columns>
                        <HeaderStyle HorizontalAlign="Center" />
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
