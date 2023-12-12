<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="CategoryInsert.aspx.cs" Inherits="Doosan.e.Catalogue.CategoryInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Insert Product Category
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
            <h1>Add New Product Category</h1>
            <hr />

            <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CssClass="btn btn-danger"  CausesValidation="false"/>
            <hr />
        </div>

        <div class="col-md-5">
            <div class="form-group">
                Product Category Name
                
                <asp:TextBox ID="tb_name" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_name" runat="server" ErrorMessage="Please enter type name" ControlToValidate="tb_name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                Category Description
                
                <asp:TextBox ID="tb_desc" runat="server" TextMode="MultiLine" Height="200px" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_desc" runat="server" ErrorMessage="Please enter type description" ControlToValidate="tb_desc" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <asp:Button ID="btn_add" runat="server" Text="Add Category" OnClick="btn_add_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
