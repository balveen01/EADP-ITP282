<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/POrdersMaster.master" AutoEventWireup="true" CodeBehind="PoReject.aspx.cs" Inherits="Triangle.w.Admin.Purchase_Orders.PoReject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Rejected Purchase Orders
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Status {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Rejected Purchase Order</h1>
            <hr />

            <asp:GridView ID="gv_po" runat="server" AllowPaging="True" EmptyDataText="There are no rejected purchase orders." AutoGenerateColumns="False" DataKeyNames="product_id" OnPageIndexChanging="gv_po_PageIndexChanging" OnSelectedIndexChanged="gv_po_SelectedIndexChanged" PageSize="10" CssClass="table table-bordered table-striped">
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
