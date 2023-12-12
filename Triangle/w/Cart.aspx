<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/TemplateMaster.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Triangle.w.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #lbtn_Cart {
            color: #00aeef;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="container">
        <div class="row mx-0">
            <div class="col-md-6 col-md-offset-3">

                <h1>Cart</h1>
                <asp:GridView ID="gvCart" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" >
                    <Columns>
                        <asp:BoundField DataField="ItemID" HeaderText="Product ID" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product name" />
                        <asp:BoundField DataField="Price" DataFormatString="{0:C}" HeaderText="Unit Price" />
                        <asp:BoundField DataField="ProdQuantity" HeaderText="Quantity" />
                    </Columns>
                </asp:GridView>
                <br />
                <p>
                    Total Price = $<asp:Label ID="lbl_TotalPrice" runat="server"></asp:Label>
                </p>

                <asp:Button id="btn_Purchase" runat="server" Text="Purchase Items" CssClass="btn btn-success" OnClick="btn_Purchase_Click"/>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
