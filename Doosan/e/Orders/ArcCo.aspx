<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/COrdersMaster.master" AutoEventWireup="true" CodeBehind="ArcCo.aspx.cs" Inherits="Doosan.e.Orders.ArcCo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Archived Customer Orders
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Orders_Archived {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <div class="d-flex justify-content-between">
                <h1>Archived Customer Orders</h1>

                <div class="form-inline">
                    <div>
                        Sort By: &nbsp;
                        <asp:DropDownList ID="ddl_sort" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_sort_SelectedIndexChanged" CssClass="form-control mr-2">
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem Value="order_id">Order ID</asp:ListItem>
                            <asp:ListItem Value="order_date">Order Date</asp:ListItem>
                            <asp:ListItem Value="total_price asc">Total Price (Asc)</asp:ListItem>
                            <asp:ListItem Value="total_price desc">Total Price (Desc)</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <asp:TextBox ID="tb_search" runat="server" placeholder="Search.." CssClass="form-control rounded-0 border-right-0"></asp:TextBox>
                    <asp:Button ID="btn_search" runat="server" CssClass="btn btn-outline-success rounded-0" Text="Search" OnClick="btn_search_Click" />
                </div>
            </div>
            <hr />
        </div>

        <div class="col-md-12">
            <asp:Label ID="lbl_search" runat="server"></asp:Label>

            <asp:GridView ID="gv_co" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="order_id" OnPageIndexChanging="gv_po_PageIndexChanging" PageSize="10"  OnRowDeleting="gv_co_RowDeleting" CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField DataField="order_id" HeaderText="Order ID" />
                        <asp:BoundField DataField="total_price" HeaderText="Total Price" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="order_date" HeaderText="Order Date" />
                        <asp:BoundField DataField="is_approved" HeaderText="Approved" />
                        <asp:CommandField DeleteText="Unarchive" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
