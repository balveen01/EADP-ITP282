<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/COrdersMaster.master" AutoEventWireup="true" CodeBehind="Customer-Orders.aspx.cs" Inherits="Doosan.w.Orders.Customer_Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Customer Orders
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_CO_View {
            color: #007bff;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <div class="d-flex justify-content-between">
                <h1>Customer Orders</h1>

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

                    <asp:TextBox ID="tb_search" runat="server" placeholder="Company Name.." CssClass="form-control rounded-0 border-right-0"></asp:TextBox>
                    <asp:Button ID="btn_search" runat="server" CssClass="btn btn-outline-success rounded-0" Text="Search" OnClick="btn_search_Click" />
                </div>
            </div>
            <hr />
            <asp:Button ID="btn_export" runat="server" Text="Export Customer Order" OnClick="btn_export_Click" CssClass="btn btn-info" />
            <hr />
        </div>

        <div class="col-md-12">
            <asp:Label ID="lbl_search" runat="server"></asp:Label>

            <asp:GridView ID="gv_co" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="product_id" OnPageIndexChanging="gv_po_PageIndexChanging" OnSelectedIndexChanged="gv_po_SelectedIndexChanged" PageSize="10" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="order_id" HeaderText="Order ID" />
                    <asp:BoundField DataField="total_price" HeaderText="Total Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="order_date" HeaderText="Order Date" />
                    <asp:BoundField DataField="company_name" HeaderText="Company ID" />
                    <asp:BoundField DataField="poid_ref" HeaderText="PO Reference ID" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
