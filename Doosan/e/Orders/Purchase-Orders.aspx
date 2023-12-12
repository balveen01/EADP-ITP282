<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/POrdersMaster.master" AutoEventWireup="true" CodeBehind="Purchase-Orders.aspx.cs" Inherits="Doosan.w.Purchase_Orders.Purchase_Orders" %>

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
            <h1>Purchase Orders</h1>
        <hr />
        </div>
        <div class="col-md-12">
            <asp:GridView ID="gv_po" CssClass="table table-striped table-bordered" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="order_id" OnPageIndexChanging="gv_po_PageIndexChanging" OnSelectedIndexChanged="gv_po_SelectedIndexChanged" PageSize="10" OnRowDeleting="gv_po_RowDeleting" OnRowDataBound="gv_po_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="order_id" HeaderText="Order ID" />
                    <asp:BoundField DataField="total_price" HeaderText="Total Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="order_date" HeaderText="Order Date" />
                    <asp:BoundField DataField="is_supp_approved" HeaderText="Status" />
                    <asp:CommandField EditText="View" DeleteText="View" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
