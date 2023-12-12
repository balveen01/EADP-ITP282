<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="Add-Product.aspx.cs" Inherits="Triangle.w.Admin.Catalogue.Add_Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Add a New Product
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Products_Add {
            color: #007bff;
        }

        .auto-style2 {
            padding: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters mt-4">
        <div class="col-md-12">
            <h1>Add New Product</h1>
            <hr />
        </div>

        <div class="col-md-12">
            <div class="row">
                <div class="col-md-5">
                    <div class="form-group">
                        Product Name
                    <asp:TextBox ID="tb_name" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_name" runat="server" ErrorMessage="Please enter product name" ControlToValidate="tb_name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        Product Description
                    <asp:TextBox ID="tb_desc" runat="server" TextMode="MultiLine" Height="200px" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_desc" runat="server" ErrorMessage="Please enter product description" ControlToValidate="tb_desc" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        Product Type
                    <asp:DropDownList ID="ddl_type" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_type" runat="server" ErrorMessage="Please enter product type" ControlToValidate="ddl_type" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        Unit Price of Product
                    <asp:TextBox ID="tb_price" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_price" runat="server" ErrorMessage="Please enter unit price" ControlToValidate="tb_price" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_price" runat="server" ErrorMessage="Only numeric value is allowed" Type="Double" Operator="DataTypeCheck" ControlToValidate="tb_price" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                    </div>

                    <div class="form-group">
                        <asp:Button ID="btn_insert" runat="server" Text="Add Product" OnClick="btn_insert_Click" CssClass="btn btn-primary" />
                    </div>
                </div>

                <div class="col-md-5 ml-5">
                    <div class="form-group">
                        Stock Level
                <asp:TextBox ID="tb_stock" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_stock" runat="server" ErrorMessage="Please enter stock level" Display="Dynamic" ControlToValidate="tb_stock" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_stock" runat="server" ErrorMessage="Only numeric value is allowed" Display="Dynamic" Type="Double" Operator="DataTypeCheck" ControlToValidate="tb_stock" ForeColor="Red"></asp:CompareValidator>
                    </div>

                    <div class="form-group">
                        Reorder Point               
                <asp:TextBox ID="tb_rop" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_rop" runat="server" ErrorMessage="Please enter re-order point" Display="Dynamic" ControlToValidate="tb_rop" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_rop" runat="server" ErrorMessage="Only numeric value is allowed" Type="Double" Operator="DataTypeCheck" ControlToValidate="tb_rop" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                    </div>
                    <div class="form-group">
                        Reorder Quantitiy
                <asp:TextBox ID="tb_qty" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_qty" runat="server" ErrorMessage="Please enter reorder point quantity" Display="Dynamic" ControlToValidate="tb_qty" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_qty" runat="server" ErrorMessage="Only numeric value is allowed" Type="Double" Operator="DataTypeCheck" ControlToValidate="tb_qty" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                    </div>

                    
                    <div class="form-group">
                        Product Image<br />
                        <asp:FileUpload ID="FileUpload" runat="server" />
                        <asp:RequiredFieldValidator ID="rfv_image" runat="server" ErrorMessage="Please choose an image file" ControlToValidate="FileUpload" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
