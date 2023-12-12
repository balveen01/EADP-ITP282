<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="ProductUpdate.aspx.cs" Inherits="Triangle.w.Admin.Catalogue.ProductUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Product Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_CProducts {
            color: #007bff;
        }

        .auto-style1 {
            height: 33px;
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
            <div class="row no-gutters justify-content-start">
                <div class="col-md-5">
                    <div class="form-group">
                        Product Name
                        <asp:TextBox ID="tb_name" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        Product Description
                        <asp:TextBox ID="tb_desc" runat="server" TextMode="MultiLine" CssClass="form-control" Height="100px"></asp:TextBox>
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

                <div class="col-md-5 ml-3">
                      <div class="form-group">
                        Stock Level
                            <asp:TextBox ID="tb_stock" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                        <asp:CompareValidator ID="cv_stock" runat="server" ErrorMessage="Only numeric value is allowed" Type="Double" Operator="DataTypeCheck" ControlToValidate="tb_stock" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                    </div>

                    <div class="form-group">
                        Re-Order Point
                        <asp:TextBox ID="tb_rop" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                        <asp:CompareValidator ID="cv_rop" runat="server" ErrorMessage="Only numeric value is allowed" Type="Double" Operator="DataTypeCheck" ControlToValidate="tb_rop" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                    </div>

                    <div class="form-group">
                        Re-Order Quantity
                        <asp:TextBox ID="tb_qty" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                        <asp:CompareValidator ID="cv_qty" runat="server" ErrorMessage="Only numeric value is allowed" Type="Double" Operator="DataTypeCheck" ControlToValidate="tb_qty" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                    </div>

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

    <%-- <div class="col-md-11">
        <h1>Product Details</h1>
    </div>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style7">
                <asp:Button ID="btn_archive" runat="server" Text="Archive" OnClick="btn_archive_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Product ID</td>
            <td class="auto-style5">
                <asp:Label ID="lbl_id" runat="server"></asp:Label>
            </td>
            <td>Product Image</td>
        </tr>
        <tr>
            <td class="auto-style3">Product Name</td>
            <td class="auto-style6">
                <asp:TextBox ID="tb_name" runat="server"  AutoPostBack="True" Height="32px" Width="341px"></asp:TextBox>
            </td>
            <td rowspan="7">
                <asp:Image ID="image" runat="server" Style="width: 50%; height: 50%" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Product Description</td>
            <td class="auto-style5">
                <asp:TextBox ID="tb_desc" runat="server" TextMode="MultiLine" Height="166px" Width="614px"  AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Product Type</td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddl_type" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Unit Price ($)</td>
            <td class="auto-style5">
                <asp:TextBox ID="tb_price" runat="server"  AutoPostBack="True"></asp:TextBox>
            </td>
            <td>
                <asp:CompareValidator ID="cv_price" runat="server" ErrorMessage="Only numeric value is allowed" Type="Double" Operator="DataTypeCheck" ControlToValidate="tb_price" ForeColor="Red"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td class="auto-style1">Insert Date</td>
            <td class="auto-style1">
                <asp:Label ID="lbl_insert" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
      
        <tr>
            <td class="auto-style2">
                <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CausesValidation="false" />
            </td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style8">
                    <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" />

            </td>
        </tr>
    </table>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
