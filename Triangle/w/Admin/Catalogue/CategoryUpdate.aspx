<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="CategoryUpdate.aspx.cs" Inherits="Triangle.w.Admin.Catalogue.CategoryUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Categories Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Categories {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
     <div class="row no-gutters mt-4">
        <div class="col-md-12">
            <h1>Product Category</h1>
            <hr />
            <div class="d-flex justify-content-between">
                <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CssClass="btn btn-danger" CausesValidation="false"/>

                <div>
                    <asp:Button ID="btn_insert" runat="server" Text="Add new category" OnClick="btn_insert_Click" CssClass="btn btn-info mr-2" />
                    <asp:Button ID="btn_archive" runat="server" Text="Archive" OnClick="btn_archive_Click" CssClass="btn btn-warning" />
                </div>
            </div>
            <hr />
        </div>

        <div class="col-md-5">
            <asp:Panel id="detials" runat="server">
                <div class="form-group">
                    Type ID
                        <asp:Label ID="lbl_id" runat="server"></asp:Label>
                </div>

                <div class="form-group">
                    Type Name
                    <asp:TextBox ID="tb_name" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    Type Description
                    <asp:TextBox ID="tb_desc" runat="server" TextMode="MultiLine" Height="200px" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" CssClass="btn btn-primary" />
                </div>
            </asp:Panel>
        </div>

        <div class="col-md-12">
            <asp:Label ID="lbl_error" runat="server"></asp:Label>
            <br />
            <asp:GridView ID="gv_products" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="product_id" OnPageIndexChanging="gv_products_PageIndexChanging" OnSelectedIndexChanged="gv_products_SelectedIndexChanged" PageSize="5" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="product_id" HeaderText="Product ID" />
                    <asp:BoundField DataField="product_name" HeaderText="Product Name" />
                    <asp:BoundField DataField="type_name" HeaderText="Product Type" />
                    <asp:BoundField DataField="unit_price" DataFormatString="{0:C}" HeaderText="Unit Price" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
