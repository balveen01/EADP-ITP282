<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="ViewBundle.aspx.cs" Inherits="Triangle.w.Admin.Catalogue.ViewBundle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Bundle
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Bundle {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Bundles</h1>
            <hr />

            <asp:gridview id="gv_products" runat="server" allowpaging="True" autogeneratecolumns="False" datakeynames="bundle_id" onpageindexchanging="gv_products_PageIndexChanging" onselectedindexchanged="gv_products_SelectedIndexChanged" pagesize="5" cssclass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="bundle_id" HeaderText="Bundle ID" />
                <asp:BoundField DataField="bundle_desc" HeaderText="Bundle Description" />
                <asp:BoundField DataField="total_price" HeaderText="Total Price" DataFormatString="{0:C}"/>
                <asp:BoundField DataField="discount" HeaderText="Discount"  DataFormatString="{0}%"/>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:gridview>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>

