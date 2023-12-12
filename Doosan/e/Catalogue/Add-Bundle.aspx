<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="Add-Bundle.aspx.cs" Inherits="Doosan.e.Catalogue.Add_Bundle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Add new Bundle
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        .price {
            margin-right: 10%;
            margin-top: 5%;
        }

        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_addbundle {
            color: #007bff;
        }

        .prod_img {
            max-height: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-around mt-4">
        <div class="col-md-12">
            <h1>Add New Bundle</h1>
            <hr />
        </div>

        <div class="col-md-3">
            <div class="form-group">
                Description
                <asp:TextBox ID="tb_desc" runat="server" Height="200px" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_desc" runat="server" Display="Dynamic" ErrorMessage="Please enter bundle description" ControlToValidate="tb_desc" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                Product Name:
                <asp:DropDownList ID="ddl_name" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_name" runat="server" Display="Dynamic" ErrorMessage="Please choose a product" ControlToValidate="ddl_name" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                Quantity
                <asp:TextBox ID="tb_quant" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_qty" runat="server" Display="Dynamic" ErrorMessage="Please enter quantity of product" ControlToValidate="tb_quant" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Button ID="btn_add" runat="server" Text="Add To Cart" OnClick="btn_add_Click" CssClass="btn btn-primary" CausesValidation="false"/>
            </div>
        </div>

        <div class="col-md-8">
            <asp:Panel ID="pnlcart" runat="server">
                <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" EmptyDataText="There is nothing in your shopping cart." DataKeyNames="ItemID" OnRowCommand="GridView1_RowCommand" CssClass="table table-bordered table-striped">
                    <Columns>
                        <asp:BoundField DataField="ItemID" HeaderText="ID">
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Product">
                            <ItemTemplate>
                                <asp:Image ID="img_Product" runat="server" CssClass="prod_img" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="product_name" HeaderText="Product Name"></asp:BoundField>
                        <asp:BoundField DataField="product_price" DataFormatString="{0:C}" HeaderText="Unit Price">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-CssClass="qty" HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Button Width="18px" CssClass="btnplus" ID="btn_Plus" CommandArgument='<%# Eval("ItemID")  %>' CommandName="Plus" runat="server" Text="+" CausesValidation="false"/>
                                <asp:TextBox Width="40px" CssClass="tbqty" ID="tb_Quantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                                <asp:Button Width="18px" CssClass="btnminus" ID="btn_Minus" CommandArgument='<%# Eval("ItemID")  %>' CommandName="Minus" runat="server" Text="-" CausesValidation="false"/>
                                <asp:ImageButton ID="btn_Remove" runat="server" CommandArgument='<%# Eval("ItemID") %>' CommandName="Remove" Width="15px" Height="15px" BorderWidth="0" ImageUrl="~/assets/img/bin.png" CausesValidation="false"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TotalPrice" DataFormatString="{0:C}" HeaderText="SubTotal"></asp:BoundField>
                    </Columns>
                </asp:GridView>


                <table class="price" align="right">
                    <tr>
                        <td>Total Item &nbsp;</td>
                        <td>
                            <asp:Label ID="lbl_TotalItem" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Discount &nbsp;</td>
                        <td>
                            <asp:TextBox ID="tb_dist" runat="server" AutoPostBack="True" OnTextChanged="tb_dist_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfV_dist" runat="server" ErrorMessage="Please enter discount" ControlToValidate="tb_dist" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Order Total ($)&nbsp;</td>
                        <td>
                            <asp:Label ID="lbl_TotalPrice" runat="server">0.00</asp:Label></td>
                    </tr>
                </table>


                <table class="auto-style2" width="100%">
                    <tr>
                        <td class="auto-style12" align="center">
                            <asp:Label ID="lbl_Error" runat="server" ForeColor="Red"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="btn_Clear" runat="server" OnClick="btn_Clear_Click" Text="Clear Cart" CssClass="btnclear" CausesValidation="false"/>
                            <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_Click" Text="Update Cart" CssClass="btnupdate" CausesValidation="false"/>
                            <asp:Button ID="btn_payment" runat="server" OnClick="btn_payment_Click" Text="Add Bundle" CssClass="btnpayment" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>



    <%--  <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-11">
            <h1>Add Bundle</h1>
        </div>
    </div>

    <br />
    <p>
        Description
            <asp:TextBox ID="tb_desc" runat="server" Height="133px" TextMode="MultiLine" Width="567px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfv_desc" runat="server" ErrorMessage="Please enter bundle description" ControlToValidate="tb_desc" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <br />
    <p>
        Product Name:
        <asp:DropDownList ID="ddl_name" runat="server" AutoPostBack="true"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfv_name" runat="server" ErrorMessage="Please choose a product" ControlToValidate="ddl_name" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <br />
    <p>
        Quantity
            <asp:TextBox ID="tb_quant" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfv_qty" runat="server" ErrorMessage="Please enter quantity of product" ControlToValidate="tb_quant" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <br />

    <asp:Button ID="btn_add" runat="server" Text="Add To Cart" OnClick="btn_add_Click" />

    <br />

   
    --%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
