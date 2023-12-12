<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/POrdersMaster.master" AutoEventWireup="true" CodeBehind="PoUpdate.aspx.cs" Inherits="Triangle.w.Admin.Purchase_Orders.PoUpdate" %>

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
        <div class="col-md-11">
            <h1>Purchase Order Details</h1>

            <asp:Button ID="btn_addproduct" runat="server" Text="Add Products" OnClick="btn_addproduct_Click" />
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


    <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" EmptyDataText="There is nothing in your shopping cart." DataKeyNames="ItemID" OnRowCommand="GridView1_RowCommand" Height="100px" Width="100%" CssClass="auto-style6" CellPadding="0">
        <HeaderStyle HorizontalAlign="Left" BackColor=" #ff8080" ForeColor="#FFFFFF" />
        <AlternatingRowStyle BackColor=" #FADBD8" />
        <Columns>
            <asp:BoundField DataField="ItemID" HeaderText="ID">
                <ItemStyle Width="100px" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Type" DataField="Type">
                <ItemStyle Width="100px" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Product">
                <ItemTemplate>
                    <asp:Image ID="img_Product" runat="server" Width="100px" Height="100px" CssClass="prod_img" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                </ItemTemplate>
                <ItemStyle Height="100px" HorizontalAlign="Center" Width="100px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Product Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("product_name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_pname" runat="server" Text='<%# Bind("product_name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="270px" />
            </asp:TemplateField>
            <asp:BoundField DataField="product_price" DataFormatString="{0:C}" HeaderText="Unit Price">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="110px" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField ItemStyle-CssClass="qty" HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Button Width="18px" CssClass="btnplus" ID="btn_Plus" CommandArgument='<%# Eval("ItemID")  %>' CommandName="Plus" runat="server" Text="+" Visible='<%# visibility(Eval("Type")) %>' />
                    <asp:TextBox Width="40px" CssClass="tbqty" ID="tb_Quantity" runat="server" Text='<%# Eval("Quantity") %>' Visible='<%# visibility(Eval("Type")) %>'></asp:TextBox>
                    <asp:Label ID="lbl_Quantity" runat="server" Text='<%# Bind("Quantity") %>' Visible='<%# visibilitybund(Eval("Type")) %>'></asp:Label>
                    <asp:Button Width="18px" CssClass="btnminus" ID="btn_Minus" CommandArgument='<%# Eval("ItemID")  %>' CommandName="Minus" runat="server" Text="-" Visible='<%# visibility(Eval("Type")) %>' /><br />
                    <br />

                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="150px" />
            </asp:TemplateField>
            <asp:BoundField DataField="TotalPrice" DataFormatString="{0:C}" HeaderText="SubTotal">
                <HeaderStyle Height="15px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>



    <br />


    <table class="price" align="right">
        <tr>
            <td>Total Item ($) &nbsp;</td>
            <td>
                <asp:Label ID="lbl_TotalItem" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>Shipping Fee ($) &nbsp;</td>
            <td>
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

            </td>
        </tr>
    </table>

    <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" />
    <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" />
    <asp:Button ID="btn_approve" runat="server" Text="Send for approval" OnClick="btn_approve_Click" />

    <asp:Panel runat="server" ID="pnlPopUp" Visible="false" CssClass="popupWindow">

        <table class="auto-style1">
            <tr>
                <td>Product Name</td>
                <td>
                    <asp:DropDownList ID="ddl_name" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Quantity</td>
                <td>
                    <asp:TextBox ID="tb_qty" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btn_add" runat="server" Text="Add Product" OnClick="btn_add_Click" />
                    <asp:Button ID="btnt_close" runat="server" Text="Close" OnClick="btn_close_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>






</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
