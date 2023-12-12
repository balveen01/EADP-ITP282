<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/COrdersMaster.master" AutoEventWireup="true" CodeBehind="CODetails.aspx.cs" Inherits="Doosan.e.Orders.CODetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Customer Order Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_CO_View {
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
            <h1>Customer Order Details</h1>
            <hr />

            <div class="d-flex justify-content-between">
                <asp:Button ID="btn_Back" runat="server" Text="Back" CssClass="btn btn-danger" OnClick="btn_Back_Click" />
                <div>
                    <asp:Button ID="btn_arc" runat="server" Text="Archive" OnClick="btn_arc_Click" CssClass="btn btn-warning" />
                    <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" CssClass="btn btn-primary" />
                </div>
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
            <div class="d-flex justify-content-between">
                <div>
                    <h2>Order Total:                                
                    $<asp:Label ID="lbl_TotalPrice" runat="server"></asp:Label></h2>
                </div>
            </div>

            <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" EmptyDataText="There is nothing in your shopping cart." DataKeyNames="order_item_id" CssClass="table table-striped table-bordered">
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
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
