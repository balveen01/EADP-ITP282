<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/POrdersMaster.master" AutoEventWireup="true" CodeBehind="Pending-PO.aspx.cs" Inherits="Doosan.e.Orders.Pending_PO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Pending Purchase Order
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_PO_Pendings {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Pending Purchase Orders</h1>
            <hr />
        </div>
    </div>
    <asp:GridView ID="gv_po" runat="server" AllowPaging="True"  EmptyDataText="There are not pending purchase orders." AutoGenerateColumns="False" DataKeyNames="order_id" CssClass="table table-bordered table-striped" OnPageIndexChanging="gv_po_PageIndexChanging" OnSelectedIndexChanged="gv_po_SelectedIndexChanged" PageSize="10"  OnRowDeleting="gv_po_RowDeleting" OnRowDataBound="gv_po_RowDataBound">
        <Columns>
            <asp:BoundField DataField="order_id" HeaderText="Order ID" />
            <asp:BoundField DataField="total_price" HeaderText="Total Price" DataFormatString="{0:C}"/>
            <asp:BoundField DataField="order_date" HeaderText="Order Date" />
            <asp:BoundField DataField="is_supp_approved" HeaderText="Status" />
            <asp:CommandField EditText="View" DeleteText="View" ShowDeleteButton="True" />
            <asp:CommandField SelectText="Create CO" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
