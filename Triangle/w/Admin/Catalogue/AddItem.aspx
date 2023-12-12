<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="Triangle.w.AddItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Add Item
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Add_Item {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-start mt-4">
        <div class="col-md-12">
            <h1>Add new item</h1>
            <hr />

            <div class="row">
                <div class="col-md-5">
                    <div class="form-group">
                        Product Name
                    <asp:DropDownList ID="ddl_name" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_name_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        Product Quantity
                    <asp:TextBox ID="tb_quant" runat="server" OnTextChanged="tb_quant_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        Unit Price
                    <asp:Label ID="lbl_price" runat="server"></asp:Label>
                    </div>

                    <div class="form-group">
                        Sub Total
                    <asp:Label ID="lbl_total" runat="server"></asp:Label>
                    </div>

                    <div class="form-group">
                        <asp:Button ID="btn_add" runat="server" Text="Add To Cart" OnClick="btn_add_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
