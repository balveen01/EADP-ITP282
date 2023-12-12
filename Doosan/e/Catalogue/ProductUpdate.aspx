<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="ProductUpdate.aspx.cs" Inherits="Doosan.e.Catalogue.ProductUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Product Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Products {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Product Update</h1>
            <hr />
            <div class="d-flex justify-content-between">
                <div>
                    <h3>ID:
                    <asp:Label ID="lbl_id" runat="server"></asp:Label></h3>
                </div>
                <asp:Button ID="btn_archive" runat="server" Text="Archive Product" OnClick="btn_archive_Click" CssClass="btn btn-warning" />
            </div>
            <hr />
        </div>

        <div class="col-md-12">
            <div class="row no-gutters justify-content-between">
                <div class="col-md-5">
                    <div class="form-group">
                        Product Name
                        <asp:TextBox ID="tb_name" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        Product Description
                        <asp:TextBox ID="tb_desc" runat="server" TextMode="MultiLine" CssClass="form-control" Height="300px"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        Product Type
                        <asp:DropDownList ID="ddl_type" runat="server" AutoPostBack="True" CssClass="form-control">
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        Unit Price
                        <asp:TextBox ID="tb_price" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:CompareValidator ID="cv_price" runat="server" ErrorMessage="Only numeric value is allowed" Type="Double" Operator="DataTypeCheck" ControlToValidate="tb_price" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                    </div>

                    <div class="form-group">
                        Product Insert Date: 
                        <asp:Label ID="lbl_insert" runat="server" Text="Label"></asp:Label>
                    </div>

                    <div class="form-group">
                        <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" CssClass="btn btn-primary" />
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Image ID="image" runat="server" Style="width: 50%; height: 50%" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                    </div>

                    <div class="form-group">
                        <asp:FileUpload ID="FileUpload" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
