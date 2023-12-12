<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/POrdersMaster.master" AutoEventWireup="true" CodeBehind="ViewApprovePO.aspx.cs" Inherits="Triangle.w.Admin.Purchase_Orders.ViewApprovePO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Approve Purchase Orders
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_approve_po {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <div class="d-flex justify-content-between">
                <h1>Approve Purchase Order</h1>

                <div class="form-inline">
                    <div>
                        Sort By: &nbsp;
                        <asp:DropDownList ID="ddl_sort" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_sort_SelectedIndexChanged" CssClass="form-control mr-2">
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem Value="order_id">Order ID</asp:ListItem>
                            <asp:ListItem Value="order_date">Order Date</asp:ListItem>
                            <asp:ListItem Value="s.supplier_id">Supplier ID</asp:ListItem>
                            <asp:ListItem Value="total_price asc">Total Price (Asc)</asp:ListItem>
                            <asp:ListItem Value="total_price desc">Total Price (Desc)</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <asp:TextBox ID="tb_search" runat="server" placeholder="Company Name.." CssClass="form-control rounded-0 border-right-0"></asp:TextBox>
                    <asp:Button ID="btn_search" runat="server" CssClass="btn btn-outline-success rounded-0" Text="Search" OnClick="btn_search_Click" />
                </div>
            </div>
            <hr />

            <p>
                <asp:Label ID="lbl_search" runat="server"></asp:Label>
            </p>
            <asp:GridView ID="gv_po" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="product_id" OnPageIndexChanging="gv_po_PageIndexChanging" OnSelectedIndexChanged="gv_po_SelectedIndexChanged" PageSize="10" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="order_id" HeaderText="Order ID" />
                    <asp:BoundField DataField="total_price" HeaderText="Total Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="order_date" HeaderText="Order Date" />
                    <asp:BoundField DataField="supplier_name" HeaderText="Supplier Name" />
                    <asp:BoundField DataField="attempt_no" HeaderText="Attempt No" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
