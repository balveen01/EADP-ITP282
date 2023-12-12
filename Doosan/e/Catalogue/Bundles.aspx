<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="Bundles.aspx.cs" Inherits="Doosan.e.Catalogue.Bundles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Bundle
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
            <h1>Bundles</h1>
            <hr />

            <asp:Label ID="lbl_search" runat="server"></asp:Label>
            <asp:GridView ID="gv_bundle" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="product_id" OnPageIndexChanging="gv_products_PageIndexChanging" OnSelectedIndexChanged="gv_products_SelectedIndexChanged" PageSize="10" CssClass="table table-bordered table-striped">
                <Columns>
                    <asp:BoundField DataField="bundle_id" HeaderText="Bundle ID" />
                    <asp:BoundField DataField="bundle_desc" HeaderText="Bundle Description" />
                    <asp:BoundField DataField="total_price" DataFormatString="{0:C}" HeaderText="Total Price " />
                    <asp:BoundField DataField="discount" HeaderText="Discount" DataFormatString="{0}%" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
