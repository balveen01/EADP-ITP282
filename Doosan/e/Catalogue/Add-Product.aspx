<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="Add-Product.aspx.cs" Inherits="Doosan.e.Catalogue.Add_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Add a New Product
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Products_Add {
            color: #007bff;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters mt-4">
        <div class="col-md-12">
            <h1>Add New Product</h1>
            <hr />
        </div>

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
                Product Image<br />
                <asp:FileUpload ID="FileUpload" runat="server" />
                <asp:RequiredFieldValidator ID="rfv_image" runat="server" ErrorMessage="Please choose an image file" ControlToValidate="FileUpload" ForeColor="Red"></asp:RequiredFieldValidator>
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
    </div>


    <%--<div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-11">
            <h1>Add New Product</h1>
        </div>

        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Product Name</td>
                <td>
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Product Description</td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Product Image</td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Product Type</td>
                <td>
                   
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Unit Price</td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>--%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
