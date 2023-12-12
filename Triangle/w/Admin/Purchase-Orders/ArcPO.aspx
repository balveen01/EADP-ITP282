<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/POrdersMaster.master" AutoEventWireup="true" CodeBehind="ArcPO.aspx.cs" Inherits="Triangle.w.Admin.Purchase_Orders.ArcPO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Archived Purchase Order
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Accounts_Archived {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Archived Purchase Order</h1>
            <hr />

            <asp:Label ID="lbl_search" runat="server"></asp:Label>
            <asp:GridView ID="gv_po" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="order_id" OnPageIndexChanging="gv_po_PageIndexChanging" PageSize="10" OnRowDeleting="gv_po_RowDeleting" OnRowDataBound="gv_po_RowDataBound" CssClass="table table-bordered table-striped">
                <Columns>
                    <asp:BoundField DataField="order_id" HeaderText="Order ID" />
                    <asp:BoundField DataField="total_price" HeaderText="Total Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="order_date" HeaderText="Order Date" />
                    <asp:BoundField DataField="is_com_approved" HeaderText="Company Approved" />
                    <asp:BoundField DataField="is_supp_approved" HeaderText="Supplier Approved" />
                    <asp:CommandField DeleteText="Unarchive" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
