<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="CategoryInsert.aspx.cs" Inherits="Triangle.w.Admin.Catalogue.CategoryInsert" %>

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
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-11">
            <h1>Insert Product Categories</h1>
        </div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style3">Type Name</td>
                <td>
                    <asp:TextBox ID="tb_name" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_name" runat="server" ErrorMessage="Please enter type name" ControlToValidate="tb_name" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Type Description</td>
                <td>
                    <asp:TextBox ID="tb_desc" runat="server" TextMode="MultiLine" Height="86px" Width="342px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_desc" runat="server" ErrorMessage="Please enter type description" ControlToValidate="tb_desc" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CausesValidation="false"/>
                </td>
                <td class="auto-style5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_add" runat="server" Text="Add Category" OnClick="btn_add_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
