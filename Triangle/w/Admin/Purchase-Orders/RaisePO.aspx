<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/POrdersMaster.master" AutoEventWireup="true" CodeBehind="RaisePO.aspx.cs" Inherits="Triangle.w.Admin.Purchase_Orders.RaisePO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Raise Purchase Order
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_raise_po {
            color: #007bff;
        }

        .price {
            margin-right: 10%;
        }

        .supplier {
            margin-right: 0%;
        }

        .bottom {
            margin-left: auto;
            margin-right: auto;
            margin-top: 160px;
        }

        #suppliertable tr td:nth-child(1), .price tr td:nth-child(1){
            width: 35%;
        }

        #suppliertable tr td:nth-child(2), .price tr td:nth-child(2) {
            width: 65%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters mt-4">
        <div class="col-md-12">
            <h1>Raise Purchase Order</h1>
            <hr />

            <div class="card" style="width: 500px">
                <div class="card-body">
                    <table id="suppliertable" style="width: 100%">
                        <tr>
                            <td colspan="2">Choose a supplier:
                            <asp:DropDownList ID="ddl_supplier" runat="server" OnSelectedIndexChanged="ddl_supplier_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control"></asp:DropDownList><br />
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

            <table class="price" style="width: 100%; width: 500px;">
                <tr>
                    <td>Total Item:</td>
                    <td>
                         $<asp:Label ID="lbl_TotalItem" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Shipping Fee:</td>
                    <td>
                         $<asp:Label ID="lbl_ShippingFee" runat="server">0.00</asp:Label></td>
                </tr>
                <tr>
                    <td>Order Total:</td>
                    <td>
                         $<asp:Label ID="lbl_TotalPrice" runat="server">0.00</asp:Label></td>
                </tr>
            </table>
            <br />

            <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" EmptyDataText="There is nothing in your shopping cart." DataKeyNames="ItemID" OnRowCommand="GridView1_RowCommand" CssClass="table table-bordered table-striped">
                <Columns>
                    <asp:BoundField DataField="ItemID" HeaderText="ID"></asp:BoundField>
                    <asp:BoundField HeaderText="Type" DataField="Type"></asp:BoundField>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="img_Product" runat="server" Width="100px" Height="100px" CssClass="prod_img" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("Product_Image")) %>' />
                        </ItemTemplate>
                        <ItemStyle Height="100px" HorizontalAlign="Center" Width="100px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Product_Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_pname" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Product_Price" DataFormatString="{0:C}" HeaderText="Unit Price">
                        <HeaderStyle HorizontalAlign="Center" />
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
                    <asp:BoundField DataField="TotalPrice" DataFormatString="{0:C}" HeaderText="SubTotal"></asp:BoundField>
                </Columns>
            </asp:GridView>

            <br />



            <!-- For the buttons-->
            <table class="bottom" style="width: 50%" align="center">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lbl_Error" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btn_back" runat="server" Text="View Products" OnClick="btn_back_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btn_approval" runat="server" Text="Send for Approval" OnClick="btn_approval_Click" />
                        <asp:HiddenField ID="hdnValue" runat="server" />
                    </td>
                </tr>
            </table>


        </div>
    </div>
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
