<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="BundleUpdate.aspx.cs" Inherits="Doosan.e.Catalogue.BundleUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Bundle Update
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        .price {
            margin-right: 10%;
            margin-top: 5%;
        }

        table {
            text-align: center;
        }

        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_bundle {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters mt-4">
        <div class="col-md-12">
            <h1>Bundle Update</h1>
            <hr />

            <div class="d-flex justify-content-between">
                <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CssClass="btn btn-danger" />
                <asp:Button ID="btn_uodate" runat="server" Text="Update" OnClick="btn_uodate_Click" CssClass="btn btn-primary" />
            </div>

            <hr />

            <div class="d-flex">
                <div class="card" style="width: 600px;">
                    <div class="card-body">
                        <div class="form-group">
                            Total Item ($)&nbsp;
                        <asp:Label ID="lbl_TotalItem" runat="server" CssClass="form-control" readonly="true"></asp:Label>
                        </div>
                        <div class="form-group">
                            Shipping Fee ($) &nbsp;
                        <asp:Label ID="lbl_ShippingFee" runat="server" CssClass="form-control" readonly="true">  0.00</asp:Label>
                        </div>
                        <div class="form-group">
                            Order Total ($) &nbsp;
                        <asp:Label ID="lbl_TotalPrice" runat="server" CssClass="form-control" readonly="true">0.00</asp:Label>
                        </div>
                    </div>
                </div>

                <div class="card" style="width: 600px; margin-left: 20px;">
                    <div class="card-body">
                        <div class="form-group">
                            Bundle Description
                            <asp:TextBox ID="tb_desc" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            Bundle Discount               
                            <asp:TextBox ID="tb_dist" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <br />

            <asp:Label ID="lbl_Error" runat="server" ForeColor="Red"></asp:Label>

            <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" EmptyDataText="There is nothing in your shopping cart." DataKeyNames="ItemID" OnRowCommand="GridView1_RowCommand" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="ItemID" HeaderText="ID"></asp:BoundField>
                    <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                            <asp:Image ID="img_Product" runat="server" Width="100px" Height="100px" CssClass="prod_img" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="product_name"></asp:BoundField>
                    <asp:BoundField DataField="product_price" DataFormatString="{0:C}" HeaderText="Unit Price"></asp:BoundField>
                    <asp:TemplateField ItemStyle-CssClass="qty" HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Button Width="18px" CssClass="btnplus" ID="btn_Plus" CommandArgument='<%# Eval("ItemID")  %>' CommandName="Plus" runat="server" Text="+" />
                            <asp:TextBox Width="40px" CssClass="tbqty" ID="tb_Quantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                            <asp:Button Width="18px" CssClass="btnminus" ID="btn_Minus" CommandArgument='<%# Eval("ItemID")  %>' CommandName="Minus" runat="server" Text="-" /><br />
                            <br />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TotalPrice" DataFormatString="{0:C}" HeaderText="SubTotal"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
