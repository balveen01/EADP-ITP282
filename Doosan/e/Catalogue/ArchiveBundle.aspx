<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="ArchiveBundle.aspx.cs" Inherits="Doosan.e.Catalogue.ArchiveBundle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Archived Bundle
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Bundle_Archive {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Archived Bundles</h1>
            <hr />

            <asp:GridView ID="gv_bundle" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="bundle_id" OnPageIndexChanging="gv_products_PageIndexChanging" PageSize="10" OnRowDeleting="gv_co_RowDeleting" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="bundle_id" HeaderText="Bundle ID" />
                    <asp:BoundField DataField="bundle_desc" HeaderText="Bundle Description" />
                    <asp:BoundField DataField="total_price" DataFormatString="{0:C}" HeaderText="Total Price " />
                    <asp:BoundField DataField="discount" HeaderText="Dicount" />
                    <asp:CommandField DeleteText="Unarchive" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
