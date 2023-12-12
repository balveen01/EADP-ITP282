<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/POrdersMaster.master" AutoEventWireup="true" CodeBehind="PoDetail.aspx.cs" Inherits="Doosan.e.Orders.PoDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Purchase Order Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_PO_View {
            color: #007bff;
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
            <div class="d-flex justify-content-between">
                <h1>Purchase Order Details</h1>
                <h2><asp:label id="lbl_status" runat="server"></asp:label></h2>
            </div>
            <hr />

            <div class="d-flex justify-content-between">
                <asp:button id="btn_back" runat="server" text="Back" onclick="btn_back_Click" cssclass="btn btn-danger" />
                <asp:button id="btn_createco" runat="server" text="Create Customer Order" cssclass="btn btn-primary" onclick="btn_createco_Click" />
            </div>

            <hr />

            <div class="card" style="width: 500px">
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
                                <asp:label id="lbl_name" runat="server"></asp:label>
                            </td>
                        </tr>

                        <tr>
                            <td>Email:</td>
                            <td>
                                <asp:label id="lbl_email" runat="server"></asp:label>
                            </td>
                        </tr>
                        <tr>
                            <td>Address:</td>
                            <td>
                                <asp:label id="lbl_addr" runat="server"></asp:label>
                            </td>
                        </tr>

                        <tr>
                            <td>Contact:</td>
                            <td>
                                <asp:label id="lbl_cont" runat="server"></asp:label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <br />
            <div>
                <h2>Order Total:                                
                    $<asp:label id="lbl_TotalPrice" runat="server"></asp:label></h2>
            </div>

            <asp:gridview id="gv_CartView" runat="server" autogeneratecolumns="False" emptydatatext="There is nothing in your shopping cart." datakeynames="order_item_id" cssclass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="product_id" HeaderText="ID" />
                    <asp:BoundField DataField="product_name" HeaderText="Product Name" />
                    <asp:TemplateField HeaderText="Product Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="unit_price" HeaderText="Unit Price" DataFormatString="{0:C}" />
                </Columns>
            </asp:gridview>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
