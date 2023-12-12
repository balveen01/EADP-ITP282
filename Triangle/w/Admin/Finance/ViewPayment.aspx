<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/FinanceMaster.master" AutoEventWireup="true" CodeBehind="ViewPayment.aspx.cs" Inherits="Triangle.w.Admin.Finance.ViewPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Payments
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Payments {
            color: #007bff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters justify-content-center mt-4">
        <div class="col-md-12">
            <div class="d-flex justify-content-between">
                <h1>Payments</h1>
                <div class="form-inline">
                    <asp:TextBox runat="server" ID="tb_search" class="form-control rounded-0 border-right-0" type="search" placeholder="Search" aria-label="Search"></asp:TextBox>
                    <asp:Button ID="btn_search" runat="server" CssClass="btn btn-outline-success rounded-0" OnClick="btn_search_Click" Text="Search"></asp:Button>
                </div>
            </div>
            <hr />

            <asp:Label ID="lbl_search" runat="server"></asp:Label>

            Filter Status (if its received):
                            <asp:RadioButtonList ID="rb_filter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rb_filter_SelectedIndexChanged">
                                <asp:ListItem>True</asp:ListItem>
                                <asp:ListItem>False</asp:ListItem>
                            </asp:RadioButtonList>
            Sort:
                            <asp:RadioButtonList ID="rb_sort" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rb_sort_SelectedIndexChanged">
                                <asp:ListItem>Price(Highest to Lowest)</asp:ListItem>
                                <asp:ListItem>Expiry Date (Nearest Date)</asp:ListItem>
                            </asp:RadioButtonList>

            <asp:GridView ID="gv_Payment" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_Payment_SelectedIndexChanged" CssClass="table table-striped table-bordered" DataKeyNames="payment_id" OnRowDeleting="gv_Payment_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="payment_id" HeaderText="Payment Id" />
                    <asp:BoundField DataField="description" HeaderText="Description" />
                    <asp:BoundField DataField="total_price" HeaderText="Total Price" />
                    <asp:BoundField DataField="expiry_date" HeaderText="Expiry Date" />
                    <asp:BoundField DataField="is_received" HeaderText="Received" />
                    <asp:BoundField DataField="is_declined" HeaderText="Declined" />
                    <asp:CommandField ShowSelectButton="True" SelectText="View" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
