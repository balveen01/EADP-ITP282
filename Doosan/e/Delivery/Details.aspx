<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/DeliveryMaster.master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Doosan.e.Delivery.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    View Delivery Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Delivery_View {
            color: #007bff;
        }

        .update-text {
            font-size: 12px;
        }

        #status .btn-outline-success:hover {
            cursor: default;
            background-color: white;
            color: #28a745;
        }

        #status .btn-outline-danger:hover {
            cursor: default;
            background-color: white;
            color: #dc3545;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <div class="row no-gutters">
                <div class="col-12">
                    <div class="d-flex flex-row justify-content-between">
                        <h1>Delivery Details: Delivery ID <asp:Label ID="lbl_ID" runat="server"></asp:Label></h1>
                    </div>
                </div>
            </div>
            <hr />

            <div class="row no-gutters justify-content-between">
                <div class="col-md-8">
                    <div class="form-group">

                        <div class="d-flex justify-content-between">
                            <div class="w-100 mr-2">
                                <span class="font-weight-bold" style="font-size:18px;">Order ID:                                
                                <asp:Label ID="lbl_OrderID" runat="server"></asp:Label></span>
                                - <a id="alinkOrders" runat="server">Click here to go to order</a><br />
                                
                            </div>
                            <div class="w-100" style="font-size:18px;">
                                Order Date: 
                                <asp:Label ID="lbl_Order_Date" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lbl_CompanyName" runat="server" Text="Company Name"></asp:Label>
                        <asp:TextBox ID="tb_companyName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="d-flex justify-content-between">
                        <div class="form-group w-100 mr-2">
                            <asp:Label ID="lbl_company_Address" runat="server" Text="Company Address"></asp:Label>
                            <asp:TextBox ID="tb_companyAddress" runat="server" CssClass="form-control" ReadOnly="true" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>

                        <div class="form-group w-100">
                            <asp:Label ID="lbl_delivery_Address" runat="server" Text="Delivery Address"></asp:Label>
                            <asp:TextBox ID="tb_deliveryAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
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

                                <asp:TextBox ID="tb_deliveryCost" runat="server" CssClass="form-control"></asp:TextBox>
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
                    <div class="form-group">
                        <div class="d-flex justify-content-between">
                            <asp:Button ID="btn_Back" runat="server" CssClass="btn btn-outline-danger" Text="Go Back" OnClick="btn_Back_Click" />
                            <asp:Button ID="btn_Approve" runat="server" CssClass="btn btn-outline-success" Text="Approve Delivery" OnClick="btn_d_not_approved_Click" OnClientClick="confirm('Please confirm this action.');"/>
                            <asp:Button ID="btn_reverseApprove" runat="server" CssClass="btn btn-outline-dark" Text="Reverse Approval" OnClick="btn_d_approved_Click" OnClientClick="confirm('Please confirm this action.');"/>
                        </div>
                    </div>
                </div>

                <div id="status" class="col-md-3">
                    <h2>Status</h2>
                    <hr />
                    <asp:Button ID="btn_d_approved" runat="server" CssClass="btn btn-sm btn-outline-success w-160" Text="Delivery Approved" />
                    <asp:Button ID="btn_d_not_approved" runat="server" CssClass="btn btn-sm btn-outline-danger w-160" Text="Delivery Not Approved" />
                    <p class="update-text text-muted">
                        Approved Date:
                        <asp:Label ID="lbl_approvedDate" runat="server" Text="Not Approved Yet"></asp:Label>
                    </p>
                    <hr />
                    <asp:Button ID="btn_p_complete" runat="server" CssClass="btn btn-sm btn-outline-success w-160" Text="Packing Completed" OnClick="btn_p_complete_Click" OnClientClick="confirm('Please confirm this action.');"/>
                    <asp:Button ID="btn_p_incomplete" runat="server" CssClass="btn btn-sm btn-outline-danger w-160" Text="Packing Incompleted" OnClick="btn_p_incomplete_Click" OnClientClick="confirm('Please confirm this action.');"/>
                    <p class="update-text text-muted">
                        Packed Date:
                        <asp:Label ID="lbl_packingDate" runat="server" Text="Not Packed Yet"></asp:Label>
                    </p>
                    <hr />
                    <asp:Button ID="btn_d_recieved" runat="server" CssClass="btn btn-sm btn-outline-success w-160" Text="Delivery Recieved" OnClientClick="alert('You are not allowed to change this status.');"/>
                    <asp:Button ID="btn_d_not_recieved" runat="server" CssClass="btn btn-sm btn-outline-danger w-160" Text="Delivery Not Received" OnClientClick="alert('You are not allowed to change this status.');"/>
                    <p class="update-text text-muted">
                        Delivery Date:
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
