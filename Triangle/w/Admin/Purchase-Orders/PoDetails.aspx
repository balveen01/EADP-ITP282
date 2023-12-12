<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/POrdersMaster.master" AutoEventWireup="true" CodeBehind="PoDetails.aspx.cs" Inherits="Triangle.w.Admin.Purchase_Orders.PoDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Purchase Order Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_PO_View {
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
            <h1>Purchase Order Details</h1>
            <hr />

            <div class="d-flex justify-content-between">
                <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CssClass="btn btn-danger" />
                <div>
                    <asp:Button ID="btn_arc" runat="server" Text="Archive" OnClick="btn_arc_Click" CssClass="btn btn-warning"/>
                    <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" CssClass="btn btn-primary"/>
                </div>
            </div>
            <hr />

            <div class="card" style="width: 500px">
                <div class="card-body">
                    <table id="suppliertable">
                        <tr>
                            <td colspan="2">
                                <h5>Supplier Details</h5>
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
            <div>
                <p style="padding-right: 45px; font-weight: bold; color: red;">
                    <asp:Label ID="lbl_aname" runat="server" Text="Attempt No: "></asp:Label>
                    <asp:Label ID="lbl_attempt" runat="server"></asp:Label>
                </p>
                <p id="reason" style="padding-right: 45px; font-weight: bold; color: red;">
                    <asp:Label ID="lbl_rname" runat="server" Text="Reason: "></asp:Label>
                    <asp:Label ID="lbl_reason" runat="server"></asp:Label>
                </p>
                <br />

                <h2>Order Total:                                
                    $<asp:Label ID="lbl_TotalPrice" runat="server"></asp:Label></h2>
            </div>

            <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" EmptyDataText="There is nothing in your shopping cart." DataKeyNames="order_item_id" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="product_id" HeaderText="ID" />
                    <asp:BoundField DataField="type" HeaderText="Type" />
                    <asp:BoundField DataField="product_name" HeaderText="Product Name" />
                    <asp:TemplateField HeaderText="Product Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="unit_price" HeaderText="Unit Price" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <%--    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-11">
            <h1>Purchase Order Details</h1>
            <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" />
            <asp:Button ID="btn_arc" runat="server" Text="Archive" OnClick="btn_arc_Click" />
            <p id="reason" style="float: right; padding-right: 45px; font-weight: bold; color: red;">
                <asp:Label ID="lbl_rname" runat="server" Text="Reason: "></asp:Label>
                <asp:Label ID="lbl_reason" runat="server"></asp:Label>
            </p>
            <p style="float: right; padding-right: 45px; font-weight: bold; color: red;">
                <asp:Label ID="lbl_aname" runat="server" Text="Attempt No: "></asp:Label>
                <asp:Label ID="lbl_attempt" runat="server"></asp:Label>
            </p>
        </div>
    </div>
    <br />

    <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" EmptyDataText="There is nothing in your shopping cart." DataKeyNames="order_item_id"  CssClass="auto-style6" CellPadding="0">
        <Columns>
            <asp:BoundField DataField="product_id" HeaderText="ID" />
            <asp:BoundField DataField="type" HeaderText="Type" />
            <asp:BoundField DataField="product_name" HeaderText="Product Name" />
            <asp:TemplateField HeaderText="Product Image">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="300px" Width="300px" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="unit_price" HeaderText="Unit Price" DataFormatString="{0:C}"/>
        </Columns>
    </asp:GridView>






    <!--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="product_id" HeaderText="ID" />
            <asp:BoundField DataField="product_image" HeaderText="Product" />
            <asp:BoundField DataField="product_name" />
            <asp:BoundField DataField="unit_price" HeaderText="Unit Price" />
            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
        </Columns>
    </asp:GridView>-->

    <table style="margin-right: auto; margin-left: 0px">
        <tr>
            <td>Supplier Name:
                <asp:Label ID="lbl_name" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Supplier Email:
                <asp:Label ID="lbl_email" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Supplier Address:
                <asp:Label ID="lbl_addr" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Supplier Contact:
                <asp:Label ID="lbl_cont" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

    <br />

    <table class="price" align="right">
        <tr>
            <td>Order Total ($) &nbsp;</td>
            <td>
                <asp:Label ID="lbl_TotalPrice" runat="server">0.00</asp:Label></td>
        </tr>
    </table>


    --%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
