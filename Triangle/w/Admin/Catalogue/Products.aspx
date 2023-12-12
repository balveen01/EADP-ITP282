<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Triangle.w.Admin.Catalogue.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Products
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Products {
            color: #007bff;
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

        .catLabel {
            float: left;
            width: 100px;
            padding: 5px;
            text-align: right;
        }

        .catText {
            float: left;
            padding: 5px;
        }

        .catButton {
            float: left;
            padding-left: 20px;
            text-align: right;
        }

        .clear {
            clear: both;
        }
    </style>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Supplier Products</h1>
            <hr />

            <asp:GridView ID="gv_products" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="product_id" OnPageIndexChanging="gv_products_PageIndexChanging" OnSelectedIndexChanged="gv_products_SelectedIndexChanged" PageSize="6" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="product_id" HeaderText="Product ID" />
                    <asp:TemplateField HeaderText="Product Image">
                        <ItemTemplate>
                            <asp:Image ID="img_Product" runat="server" Width="100px" Height="100px" CssClass="prod_img" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                        </ItemTemplate>
                        <ItemStyle Height="100px" HorizontalAlign="Center" Width="100px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="product_name" HeaderText="Product Name" />
                    <asp:BoundField DataField="type_name" HeaderText="Product Type" />
                    <asp:BoundField DataField="unit_price" DataFormatString="{0:C}" HeaderText="Unit Price" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>


            <asp:Panel runat="server" ID="pnlPopUp" Visible="false" CssClass="popupWindow">
                <asp:DetailsView ID="dv_product" runat="server" Height="50px" Width="100%" AutoGenerateRows="False" Border="0" GridLines="None">
                    <Fields>

                        <asp:TemplateField HeaderText="Product Image">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="product_name" HeaderText="Product Name" />
                        <asp:BoundField DataField="product_desc" HeaderText="Product Description" />
                        <asp:BoundField DataField="unit_price" HeaderText="Unit Price" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="type_name" HeaderText="Type" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btn_close" runat="server" CausesValidation="false" CommandName="" OnClick="btn_close_Click" Text="Close"></asp:LinkButton>
                                &nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="btn_add" runat="server" CausesValidation="false" CommandName="" OnClick="btn_add_Click" Text="Add To Cart"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Fields>
                </asp:DetailsView>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
