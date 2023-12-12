<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/COrdersMaster.master" AutoEventWireup="true" CodeBehind="COUpdate.aspx.cs" Inherits="Doosan.e.Orders.COUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Customer Order Update
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_CO_View {
            color: #007bff;
        }

        #orderTable tr td:nth-child(1) {
            width: 50%;
        }

        #orderTable tr td:nth-child(2) {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">

    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Customer Order Update</h1>
            <hr />

            <div class="d-flex justify-content-between">
                <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CssClass="btn btn-danger" />
                <asp:Button ID="btn_uodate" runat="server" Text="Update" OnClick="btn_uodate_Click" CssClass="btn btn-primary" />
            </div>
            <hr />

            <div class="card" style="width: 500px">
                <div class="card-body">
                    <table id="orderTable">
                        <tr>
                            <td>Total Item</td>
                            <td>$<asp:Label ID="lbl_TotalItem" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Shipping Fee</td>
                            <td>$<asp:Label ID="lbl_ShippingFee" runat="server">  0.00</asp:Label></td>
                        </tr>
                        <tr>
                            <td>Order Total</td>
                            <td>$<asp:Label ID="lbl_TotalPrice" runat="server">0.00</asp:Label></td>
                        </tr>
                    </table>
                </div>
            </div>

            <br />
            <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" EmptyDataText="There is nothing in your shopping cart." DataKeyNames="ItemID" OnRowCommand="GridView1_RowCommand" CssClass="table table-bordered table-striped text-center">
                <AlternatingRowStyle BackColor=" #FADBD8" />
                <Columns>
                    <asp:BoundField DataField="ItemID" HeaderText="ID"></asp:BoundField>
                    <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                            <asp:Image ID="img_Product" runat="server" Width="100px" Height="100px" CssClass="prod_img" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="product_name" HeaderText="Product Name"></asp:BoundField>
                    <asp:BoundField DataField="product_price" DataFormatString="{0:C}" HeaderText="Unit Price"></asp:BoundField>
                    <asp:TemplateField ItemStyle-CssClass="qty" HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Button Width="18px" CssClass="btnplus" ID="btn_Plus" CommandArgument='<%# Eval("ItemID")  %>' CommandName="Plus" runat="server" Text="+" />
                            <asp:TextBox Width="40px" CssClass="tbqty" ID="tb_Quantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                            <asp:Button Width="18px" CssClass="btnminus" ID="btn_Minus" CommandArgument='<%# Eval("ItemID")  %>' CommandName="Minus" runat="server" Text="-" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TotalPrice" DataFormatString="{0:C}" HeaderText="SubTotal"></asp:BoundField>
                </Columns>
            </asp:GridView>


            <asp:Label ID="lbl_Error" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
