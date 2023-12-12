<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="CProducts.aspx.cs" Inherits="Triangle.w.Admin.Catalogue.CProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Companies Products
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_CProducts {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
   <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <div class="d-flex justify-content-between">
                <h1>Customer Orders</h1>

                <div class="form-inline">
                    <div>
                        Sort By: &nbsp;
                         <asp:DropDownList ID="ddl_sort" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_sort_SelectedIndexChanged" CssClass="form-control mr-2">
                             <asp:ListItem>None</asp:ListItem>
                             <asp:ListItem Value="product_id">Product ID</asp:ListItem>
                             <asp:ListItem Value="product_name">Product Name</asp:ListItem>
                             <asp:ListItem Value="type_id">Product Type</asp:ListItem>
                             <asp:ListItem Value="unit_price asc">Unit Price (Asc)</asp:ListItem>
                             <asp:ListItem Value="unit_price desc">Unit Price (Desc)</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                    <div>
                        Filter By: &nbsp;
                        <asp:DropDownList ID="ddl_filter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_filter_SelectedIndexChanged" CssClass="form-control mr-2">
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem Value="1">Type 1</asp:ListItem>
                            <asp:ListItem Value="2">Type 2</asp:ListItem>
                            <asp:ListItem Value="3">Type 3</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <asp:TextBox ID="tb_search" runat="server" placeholder="Product Name.." CssClass="form-control rounded-0 border-right-0"></asp:TextBox>
                    <asp:Button ID="btn_search" runat="server" CssClass="btn btn-outline-success rounded-0" Text="Search" OnClick="btn_search_Click" />
                </div>
            </div>
            <hr />
        </div>

        <div class="col-md-12">
            <asp:Label ID="lbl_search" runat="server"></asp:Label>

            <asp:GridView ID="gv_products" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="product_id" OnPageIndexChanging="gv_products_PageIndexChanging" OnSelectedIndexChanged="gv_products_SelectedIndexChanged" PageSize="10" CssClass="table table-bordered table-striped">
                <Columns>
                    <asp:BoundField DataField="product_id" HeaderText="Product ID" />
                    <asp:TemplateField HeaderText="Product Image">
                        <ItemTemplate>
                            <asp:Image ID="img_Product" runat="server" CssClass="prod_img" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                        </ItemTemplate>
                        <ItemStyle Height="100px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="product_name" HeaderText="Product Name" />
                    <asp:BoundField DataField="type_name" HeaderText="Product Type" />
                    <asp:BoundField DataField="unit_price" DataFormatString="{0:C}" HeaderText="Unit Price" />
                    <asp:BoundField DataField="stock_level" HeaderText="Stock Level" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
