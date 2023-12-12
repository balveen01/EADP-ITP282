<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/POrdersMaster.master" AutoEventWireup="true" CodeBehind="Approve-PO.aspx.cs" Inherits="Doosan.e.Orders.Approve_PO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Approved Purchase Order
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_PO_Approved {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Approve Purchase Orders</h1>
            <hr />

            <asp:GridView ID="gv_po" runat="server" AllowPaging="True" EmptyDataText="There are no approved purchase orders." AutoGenerateColumns="False" DataKeyNames="order_id" OnPageIndexChanging="gv_po_PageIndexChanging" PageSize="10" OnRowDeleting="gv_po_RowDeleting" OnRowDataBound="gv_po_RowDataBound" CssClass="table table-striped table-bordered">
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
