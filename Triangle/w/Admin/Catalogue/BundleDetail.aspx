<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="BundleDetail.aspx.cs" Inherits="Triangle.w.Admin.Catalogue.BundleDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Bundle Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Bundle {
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
            <h1>Bunder Details</h1>
            <hr />

            <div class="d-flex justify-content-between">
                <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CssClass="btn btn-danger" />

                <asp:Button ID="btn_add" runat="server" Text="Add To Cart" OnClick="btn_adda_Click" CssClass="btn btn-primary" />
            </div>
            <hr />


            <div class="card" style="width: 500px">
                <div class="card-body">
                    <table id="suppliertable">
                        <tr>
                            <td colspan="2">
                                <h5>Supplier Details</h5>
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
            <div>
                <table class="price">
                    <tr>
                        <td><h1>Order Total ($) &nbsp;</h1></td>
                        <td>
                            <h1><asp:Label ID="lbl_totalPrice" runat="server">0.00</asp:Label></h1>
                        </td>
                    </tr>
                </table>
            </div>

            <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" EmptyDataText="There is nothing in your shopping cart." DataKeyNames="bundle_item_id" CssClass="table table-bordered table-striped">
                <Columns>
                    <asp:BoundField DataField="product_id" HeaderText="ID" />
                    <asp:BoundField DataField="product_name" HeaderText="Product Name" />
                    <asp:TemplateField HeaderText="Product Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="300px" Width="300px" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
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
