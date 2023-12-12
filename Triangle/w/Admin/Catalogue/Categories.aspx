<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/CatalogueMaster.master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Triangle.w.Admin.Catalogue.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Categories
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
        <div class="col-md-12">
            <div class="d-flex justify-content-between">
                <h1>Customer Orders</h1>

                <div class="form-inline">
                    <div>
                        Sort By: &nbsp;
                        
                        <asp:DropDownList ID="ddl_sort" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_sort_SelectedIndexChanged" CssClass="form-control mr-2">
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem Value="type_id">Type ID</asp:ListItem>
                            <asp:ListItem Value="type_name">Type Name</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <asp:TextBox ID="tb_search" runat="server" placeholder="Search.." CssClass="form-control rounded-0 border-right-0"></asp:TextBox>
                    <asp:Button ID="btn_search" runat="server" CssClass="btn btn-outline-success rounded-0" Text="Search" OnClick="btn_search_Click" />
                </div>
            </div>
            <hr />
        </div>

        <div class="col-md-12">
            <asp:Label ID="lbl_search" runat="server"></asp:Label>

            <asp:GridView ID="gv_category" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="type_id" OnPageIndexChanging="gv_category_PageIndexChanging" OnSelectedIndexChanged="gv_category_SelectedIndexChanged" PageSize="10" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="type_id" HeaderText="Type ID" />
                    <asp:BoundField DataField="type_name" HeaderText="Product Type" />
                    <asp:BoundField DataField="type_desc" HeaderText="Product Description" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
