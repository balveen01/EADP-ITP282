<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/POrdersMaster.master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Triangle.w.Admin.Purchase_Orders.Deliveries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Deliveries
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_DO_View {
            color: #007bff;
        }

        .btn:hover {
            cursor: default !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <div class="row no-gutters">
                <div class="col-12">
                    <div class="d-flex flex-row justify-content-between">
                        <h1>Delivery Details</h1>
                    </div>
                </div>
            </div>
            <hr />

            <div class="row no-gutters justify-content-between">
                <div class="col-md-8">
                    <%-- <div class="form-group">
                       <asp:Label ID="lbl_Order_ID" runat="server" Text="Order ID"></asp:Label>
                        - <a id="alinkOrders" runat="server">Click here to go to order</a>
                        <asp:TextBox ID="tb_Order_ID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>--%>

                    <div class="d-flex justify-content-between">
                        <div class="form-group w-100 mr-2">
                            <asp:Label ID="lbl_company_Address" runat="server" Text="Company Address"></asp:Label>
                            <asp:TextBox ID="tb_companyAddress" runat="server" CssClass="form-control" ReadOnly="true" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>

                        <div class="form-group w-100">
                            <asp:Label ID="lbl_delivery_Address" runat="server" Text="Delivery Address"></asp:Label>
                            <asp:TextBox ID="tb_deliveryAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="d-flex justify-content-between">
                        <div class="form-group w-100 mr-2">
                            <asp:Label ID="lbl_Goods_Price" runat="server" Text="Total Price of Goods"></asp:Label>
                            <div class="input-group mb-2 mr-sm-2">
                                <div class="input-group-prepend">
                                    <div class="input-group-text">$</div>
                                </div>
                                <asp:TextBox ID="tb_goodsPrice" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group w-100 mr-2">
                            <asp:Label ID="lbl_Delivery_Cost" runat="server" Text="Delivery Charge"></asp:Label>
                            <div class="input-group mb-2 mr-sm-2">
                                <div class="input-group-prepend">
                                    <div class="input-group-text">$</div>
                                </div>

                                <asp:TextBox ID="tb_deliveryCost" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group w-100">
                            <asp:Label ID="lbl_Total_Cost" runat="server" Text="Total Cost"></asp:Label>
                            <div class="input-group mb-2 mr-sm-2">
                                <div class="input-group-prepend">
                                    <div class="input-group-text">$</div>
                                </div>
                                <asp:TextBox ID="tb_totalCost" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="status" class="col-md-3">
                    <h2>Status</h2>
                    <hr />
                    <a id="d_approved" runat="server" href="#" class="btn btn-sm btn-outline-success w-160">Delivery Approved</a>
                    <a id="d_not_approved" runat="server" href="#" class="btn btn-sm btn-outline-danger w-160">Delivery Not Approved</a>
                    <p class="update-text text-muted">
                        Date:
                        <asp:Label ID="lbl_approvedDate" runat="server" Text="Not Approved Yet"></asp:Label>
                    </p>
                    <hr />
                    <a id="p_complete" runat="server" href="#" class="btn btn-sm btn-outline-success w-160">Packing Completed</a>
                    <a id="p_incomplete" runat="server" href="#" class="btn btn-sm btn-outline-danger w-160">Packing Incompleted</a>
                    <p class="update-text text-muted">
                        Date:
                        <asp:Label ID="lbl_packingDate" runat="server" Text="Not Packed Yet"></asp:Label>
                    </p>
                    <hr />
                    <a id="d_recieved" runat="server" href="#" class="btn btn-sm btn-outline-success w-160">Delivery Recieved</a>
                    <asp:Button ID="btn_d_not_recieved" runat="server" CssClass="btn btn-sm btn-outline-danger w-160" Text="Delivery Not Received" OnClick="btn_d_not_recieved_Click" OnClientClick="confirm('Please confirm this action.');" />
                    <p class="update-text text-muted">
                        Date:
                        <asp:Label ID="lbl_deliveryDate" runat="server" Text="Not Delivered Yet"></asp:Label>
                    </p>
                    <hr />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
