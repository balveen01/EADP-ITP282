<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/BCOrdersMaster.master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Triangle.w.Admin.Customer_Orders.View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Customer Orders
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_CO_View {
            color: #007bff;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <h1>Customer Orders</h1>
            <hr />

             <asp:GridView ID="gv_CO" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="order_id" OnPageIndexChanging="gv_CO_PageIndexChanging" OnSelectedIndexChanged="gv_CO_SelectedIndexChanged" PageSize="10" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="order_id" HeaderText="Order ID" />
                        <asp:BoundField DataField="order_id" HeaderText="Total Price" DataFormatString="{0:C}"/>
                        <asp:BoundField DataField="order_date" HeaderText="Order Date" />
                        <asp:BoundField DataField="total_price" HeaderText="Supplier Name" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
