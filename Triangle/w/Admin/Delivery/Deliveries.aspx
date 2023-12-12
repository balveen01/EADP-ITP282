<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/POrdersMaster.master" AutoEventWireup="true" CodeBehind="Deliveries.aspx.cs" Inherits="Triangle.w.Admin.Delivery.Deliveries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Deliveries
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_DO_View {
            color: #007bff;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <div class="row no-gutters">
                <div class="col-12">
                    <div class="d-flex flex-row justify-content-between">
                        <h1>Delivery List</h1>
                    </div>
                </div>
            </div>
            <hr />
            <div class="row no-gutters">
                <div class="col-12">
                    <asp:GridView ID="gv_Delivery" runat="server" AutoGenerateColumns="False" CssClass="table table-striped border" AllowPaging="True" SortedDescendingHeaderStyle-VerticalAlign="Top" OnSelectedIndexChanged="gv_Staff_SelectedIndexChanged" PageSize="10" OnPageIndexChanging="gv_Delivery_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="delivery_id" HeaderText="Delivery ID" SortExpression="delivery_id" HeaderStyle-Width="10%" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="order_id" HeaderText="Order ID" SortExpression="order_id" />
                            <asp:BoundField DataField="order_date" HeaderText="Order Date" SortExpression="order_date" />
                            <asp:TemplateField HeaderText="Approved Status" SortExpression="is_approved">
                                <ItemTemplate><%# (Boolean.Parse(Eval("is_approved").ToString())) ? "<span class='text-success'>Approved</span>" : "<span class='text-danger'>Pending</span>" %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Packing Status" SortExpression="is_packed">
                                <ItemTemplate><%# (Boolean.Parse(Eval("is_packed").ToString())) ? "<span class='text-success'>Packed</span>" : "<span class='text-danger'>Packing</span>" %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delivery Status" SortExpression="is_delivered">
                                <ItemTemplate><%# (Boolean.Parse(Eval("is_delivered").ToString())) ? "<span class='text-success'>Delivered</span>" : "<span class='text-danger'>Not Delivered</span>" %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowSelectButton="True" SelectText="View" />
                        </Columns>
                        <HeaderStyle HorizontalAlign="Center" />
                        <RowStyle HorizontalAlign="Center" />
                        <SortedDescendingHeaderStyle VerticalAlign="Top"></SortedDescendingHeaderStyle>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
