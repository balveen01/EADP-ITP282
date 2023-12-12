<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="ItemList.aspx.cs" Inherits="Triangle.w.Admin.Catalogue.ItemList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Item List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Item_List {
            color: #007bff;
        }

        .price {
            margin-right: 10%;
            margin-top: 5%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
        <script runat="server">


        public bool visibilitybund(object DivisionSortKey)
        {
            if (DivisionSortKey.ToString() == "product")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool visibility(object DivisionSortKey)
        {
            if (DivisionSortKey.ToString() == "product")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    </script>
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Item List</h1>
            <hr />
        </div>
    </div>

    <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" EmptyDataText="There is nothing in your shopping cart." DataKeyNames="ItemID" OnRowCommand="GridView1_RowCommand" CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="ItemID" HeaderText="ID">
            </asp:BoundField>
            <asp:TemplateField HeaderText="Product">
                <ItemTemplate>
                    <asp:Image ID="img_Product" runat="server" Width="100px" Height="100px" CssClass="prod_img" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                </ItemTemplate>
                <ItemStyle Height="100px" HorizontalAlign="Center" Width="100px" />
            </asp:TemplateField>

            <asp:BoundField DataField="product_name">
            </asp:BoundField>
            <asp:BoundField DataField="product_price" DataFormatString="{0:C}" HeaderText="Unit Price">
            </asp:BoundField>
            <asp:TemplateField ItemStyle-CssClass="qty" HeaderText="Quantity">
                <ItemTemplate>
                   <asp:Button Width="18px" CssClass="btnplus" ID="btn_Plus" CommandArgument='<%# Eval("ItemID")  %>' CommandName="Plus" runat="server" Text="+" Visible='<%# visibility(Eval("Type")) %>' />
                    <asp:TextBox Width="40px" CssClass="tbqty" ID="tb_Quantity" runat="server" Text='<%# Eval("Quantity") %>' Visible='<%# visibility(Eval("Type")) %>'></asp:TextBox>
                    <asp:Label ID="lbl_Quantity" runat="server" Text='<%# Bind("Quantity") %>' Visible='<%# visibilitybund(Eval("Type")) %>'></asp:Label>
                    <asp:Button Width="18px" CssClass="btnminus" ID="btn_Minus" CommandArgument='<%# Eval("ItemID")  %>' CommandName="Minus" runat="server" Text="-" Visible='<%# visibility(Eval("Type")) %>' /><br />
                    <br />

                    <asp:ImageButton ID="btn_Remove" runat="server" CommandArgument='<%# Eval("ItemID") %>' CommandName="Remove" Width="15px" Height="15px" BorderWidth="0" ImageUrl="~/assets/img/bin.png" Visible='<%# visibility(Eval("Type")) %>'></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TotalPrice" DataFormatString="{0:C}" HeaderText="SubTotal">
            </asp:BoundField>
        </Columns>
    </asp:GridView>

    <table class="price" align="right">
        <tr>
            <td>Total Item ($) &nbsp;</td>
            <td>
                <asp:Label ID="lbl_TotalItem" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style1">Shipping Fee ($) &nbsp;</td>
            <td class="auto-style1">
                <asp:Label ID="lbl_ShippingFee" runat="server">  0.00</asp:Label></td>
        </tr>
        <tr>
            <td>Order Total ($) &nbsp;</td>
            <td>
                <asp:Label ID="lbl_TotalPrice" runat="server">0.00</asp:Label></td>
        </tr>
    </table>


    <table class="auto-style2" width="100%">
        <tr>
            <td class="auto-style10" align="right">&nbsp;</td>
            <td class="auto-style12" align="center">
                <asp:Label ID="lbl_Error" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btn_Clear" runat="server" OnClick="btn_Clear_Click" Text="Clear Cart" CssClass="btnclear" />&nbsp;&nbsp;
         <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_Click" Text="Update Cart" CssClass="btnupdate" />&nbsp;&nbsp;
         <asp:Button ID="btn_payment" runat="server" OnClick="btn_payment_Click" Text="Raise Purchase Order" CssClass="btnpayment" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
