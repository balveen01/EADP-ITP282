<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/POrdersMaster.master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Triangle.w.Admin.Purchase_Orders.View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Purchase Orders
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_PO_View {
            color: #007bff;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <div class="d-flex justify-content-between">
                <h1>Purchase Orders</h1>

                <div class="form-inline">
                    <div>
                        Sort By: &nbsp;
                        <asp:DropDownList ID="ddl_sort" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_sort_SelectedIndexChanged" CssClass="form-control mr-2">
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem Value="order_id">Order ID</asp:ListItem>
                            <asp:ListItem Value="order_date">Order Date</asp:ListItem>
                            <asp:ListItem Value="supplier_id">Supplier ID</asp:ListItem>
                            <asp:ListItem Value="total_price asc">Total Price (Asc)</asp:ListItem>
                            <asp:ListItem Value="total_price desc">Total Price (Desc)</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div>
                        Filter By: &nbsp;
                        <asp:DropDownList ID="ddl_filter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_filter_SelectedIndexChanged" CssClass="form-control mr-2">
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem Value="is_com_approved = 'True'">Company Approved</asp:ListItem>
                            <asp:ListItem Value="is_com_declined = 'True'">Company Declined</asp:ListItem>
                            <asp:ListItem Value="is_supp_approved = 'True'">Supplier Approved</asp:ListItem>
                            <asp:ListItem Value="is_supp_declined = 'True'">Supplier Declined</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <asp:TextBox ID="tb_search" runat="server" placeholder="Company Name.." CssClass="form-control rounded-0 border-right-0"></asp:TextBox>
                    <asp:Button ID="btn_search" runat="server" CssClass="btn btn-outline-success rounded-0" Text="Search" OnClick="btn_search_Click" />
                </div>
            </div>
            <hr />
            <asp:Button ID="btn_export" runat="server" Text="Export Purchase Order" OnClick="btn_export_Click" CssClass="btn btn-info" />
            <hr />
        </div>

        <div class="col-md-12">
            <asp:Label ID="lbl_search" runat="server"></asp:Label>

            <asp:GridView ID="gv_po" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="product_id" OnPageIndexChanging="gv_po_PageIndexChanging" OnSelectedIndexChanged="gv_po_SelectedIndexChanged" PageSize="10" CssClass="table table-striped table-bordered" OnRowDataBound="gv_po_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="order_id" HeaderText="Order ID" />
                        <asp:BoundField DataField="total_price" HeaderText="Total Price" DataFormatString="{0:C}"/>
                        <asp:BoundField DataField="order_date" HeaderText="Order Date" />
                        <asp:BoundField DataField="supplier_name" HeaderText="Supplier Name" />
                        <asp:BoundField DataField="is_com_approved" HeaderText="Company Approved" />
                        <asp:BoundField DataField="is_supp_approved" HeaderText="Supplier Approved" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
