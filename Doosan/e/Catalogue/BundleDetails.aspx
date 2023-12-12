<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="BundleDetails.aspx.cs" Inherits="Doosan.e.Catalogue.BundleDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Bundle Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_bundle {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Bunder Details</h1>
            <hr />

            <div class="d-flex justify-content-between">
                <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" CssClass="btn btn-primary" />
                <asp:Button ID="btn_arc" runat="server" Text="Archive" OnClick="btn_arc_Click" CssClass="btn btn-warning" />
            </div>
            <hr />


            <div class="d-flex justify-content-between">
                <div class="form-group" style="max-width: 600px;">
                    <p>Description:
                                <asp:Label ID="lbl_desc" runat="server"></asp:Label></p>
                </div>

                <table class="price" align="right">
                    <tr>
                        <td>Order Total ($) &nbsp;</td>
                        <td>
                            <asp:Label ID="lbl_TotalPrice" runat="server">0.00</asp:Label></td>
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
