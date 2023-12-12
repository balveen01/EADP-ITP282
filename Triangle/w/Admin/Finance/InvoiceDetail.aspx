<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/FinanceMaster.master" AutoEventWireup="true" CodeBehind="InvoiceDetail.aspx.cs" Inherits="Triangle.w.Admin.Finance.InvoiceDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Invoice Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        table {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters mt-4">
        <div class="col-md-12">
            <div class="d-flex justify-content-between">
                <h1>Invoice Details</h1>
            </div>

            <hr />
            
            <div>
                <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CssClass="btn btn-danger" />
            </div>
            <hr />

            <asp:GridView ID="gv_InvoiceView" runat="server" AutoGenerateColumns="False" EmptyDataText="There is nothing in your invoice." CssClass="table table-bordered table-striped">
                <Columns>
                    <asp:BoundField DataField="order_id" HeaderText="Order #"></asp:BoundField>
                    <asp:BoundField DataField="order_date" HeaderText="Order Date"></asp:BoundField>
                    <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                            <asp:Image ID="product_image" runat="server" Width="100px" Height="100px" CssClass="prod_img" ImageUrl="<% Bind('product_image') %>" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="product_name"></asp:BoundField>
                    <asp:BoundField DataField="unit_price" DataFormatString="{0:C}" HeaderText="Unit Price"></asp:BoundField>
                    <asp:BoundField DataField="total_price" DataFormatString="{0:C}" HeaderText="SubTotal"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>


</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
