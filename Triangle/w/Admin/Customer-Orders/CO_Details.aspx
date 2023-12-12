<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/BCOrdersMaster.master" AutoEventWireup="true" CodeBehind="CO_Details.aspx.cs" Inherits="Triangle.w.Admin.Customer_Orders.CO_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Order Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_CO_View {
            color: #007bff;
        }

        table {
            text-align:center;
        }

        table tr td {
            width: 10%;
        }

        table tr td:nth-child(3) {
            width: 40%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters mt-4">
        <div class="col-md-12">
            <h1>Order Details</h1>
            <hr />

            <div class="card" style="width: 600px;">
                <div class="card-body">
                    <div class="form-group">
                        <strong>Order ID</strong>
                        <asp:Label ID="lbl_ID" runat="server" CssClass="form-control"></asp:Label>
                    </div>

                    <div class="form-group">
                        Order Date
                        <asp:Label ID="lbl_Date" runat="server" CssClass="form-control"></asp:Label>
                    </div>

                    <div class="form-group">
                        Total Price
                        <asp:Label ID="lbl_Total_Price" runat="server" CssClass="form-control"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
             <asp:GridView ID="gv_CO" runat="server" AutoGenerateColumns="False" DataKeyNames="order_item_id" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="order_item_id" HeaderText="Order Item ID" />
                    <asp:BoundField DataField="product_id" HeaderText="Product ID" />
                    <asp:BoundField DataField="product_name" HeaderText="Product Name" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="unit_price" HeaderText="Unit Price" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
