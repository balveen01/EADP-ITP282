<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/COrdersMaster.master" AutoEventWireup="true" CodeBehind="Create-Customer-Order.aspx.cs" Inherits="Doosan.w.Orders.Create_Customer_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Create Order
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_CO_Create {
            color: #007bff;
        }

        .price {
            margin-right: 10%;
            font-size: 30px;
        }

        .supplier {
            margin-right: 0%;
        }

        .popupWindow {
            position: absolute;
            left: 18%;
            top: 35%;
            width: 50%;
            border: solid 1px black;
            padding: 10px;
            background-color: white;
        }

        #suppliertable tr td:nth-child(1) {
            width: 35%;
        }

        #suppliertable tr td:nth-child(2) {
            width: 65%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Create Customer Order</h1>
            <hr />

            <div class="d-flex justify-content-between">
                <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CssClass="btn btn-danger" />

                <div>
                    <asp:Button ID="btn_decline" runat="server" Text="Decline Order" OnClick="btn_declined_Click" CssClass="btn btn-warning" />
                    <asp:Button ID="btn_co" runat="server" Text="Create Order" OnClick="btn_co_Click" CssClass="btn btn-primary" />
                </div>
            </div>
            <hr />



            <div id="supplierdetails" runat="server" class="card" style="width: 500px">
                <div class="card-body">
                    <table id="suppliertable">
                        <tr>
                            <td colspan="2">
                                <h5>Company Details</h5>
                            </td>
                        </tr>
                        <tr>
                            <td>Name:</td>
                            <td>
                                <asp:Label ID="lbl_name" runat="server"></asp:Label></td>
                        </tr>

                        <tr>
                            <td>Email:</td>
                            <td>
                                <asp:Label ID="lbl_email" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Address:</td>
                            <td>
                                <asp:Label ID="lbl_addr" runat="server"></asp:Label></td>
                        </tr>

                        <tr>
                            <td>Contact:</td>
                            <td>
                                <asp:Label ID="lbl_cont" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </div>
            </div>

            <br />
            <div id="div_order_total" runat="server">
                <h2>Order Total:                                
                    $<asp:Label ID="lbl_TotalPrice" runat="server"></asp:Label></h2>
            </div>

            <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" EmptyDataText="There is nothing in your shopping cart." DataKeyNames="order_item_id" CssClass="table table-bordered table-striped">
                <Columns>
                    <asp:BoundField DataField="product_id" HeaderText="ID" />
                    <asp:BoundField DataField="product_name" HeaderText="Product Name" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="300px" Width="300px" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="unit_price" HeaderText="Unit Price" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>

            <asp:GridView EmptyDataText="There are no pending purchase order"  ID="gv_po" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="order_id" OnPageIndexChanging="gv_po_PageIndexChanging" OnSelectedIndexChanged="gv_po_SelectedIndexChanged" PageSize="10" OnRowDeleting="gv_po_RowDeleting" OnRowDataBound="gv_po_RowDataBound" CssClass="table table-bordered table-striped">
                <Columns>
                    <asp:BoundField DataField="order_id" HeaderText="Order ID" />
                    <asp:BoundField DataField="total_price" HeaderText="Total Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="order_date" HeaderText="Order Date" />
                    <asp:BoundField DataField="is_supp_approved" HeaderText="Supplier Approved" />
                    <asp:CommandField EditText="View" DeleteText="View" ShowDeleteButton="True" />
                    <asp:CommandField SelectText="Create CO" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
