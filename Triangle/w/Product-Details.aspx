<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/TemplateMaster.Master" AutoEventWireup="true" CodeBehind="Product-Details.aspx.cs" Inherits="Triangle.Product_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Our Products | Triangle
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #header > div > div > div.collapse.navbar-collapse > ul > li:nth-child(2) > a {
            color: #00aeef;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">
    <section id="page-breadcrumb">
        <div class="vertical-center sun">
            <div class="container">
                <div class="row">
                    <div class="action">
                        <div class="col-sm-12">
                            <h1 class="title">Our Products</h1>
                            <p>Be Creative, Be Resourceful, Be Effective</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <section id="portfolio-information">
        <div class="container">
            <div class="row">
                <asp:Button ID="btn_Back" runat="server" CssClass="btn btn-danger" Style="padding: 0.6rem 1rem; margin-left: 2%;" Text="Go Back" OnClick="btn_Back_Click"></asp:Button>
            </div>

            <div class="row">
                <div class="col-sm-6 wow fadeInLeft" data-wow-duration="500ms" data-wow-delay="300ms">
                    <asp:Image ID="Image1" runat="server" CssClass="img-responsive" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                </div>
                <div class="col-sm-6">
                    <div class="project-name overflow">
                        <h2 class="bold">
                            <asp:Label ID="lbl_ProductName" runat="server" Text="PRODUCT_NAME"></asp:Label>
                        </h2>
                        <ul class="nav navbar-nav navbar-default">
                            <li><a href="#"  style="font-size: 14px;"><i class="fa fa-clock-o"></i>
                                <asp:Label ID="lbl_ReleaseDate" runat="server" Text="RELEASE_DATE"></asp:Label></a></li>
                            <li><a id="a_Category" runat="server" href="#"  style="font-size: 14px;"><i class="fa fa-tag"></i>
                                <asp:Label ID="lbl_Category" runat="server" Text="CATEGORY"></asp:Label></a></li>
                        </ul>
                    </div>
                    <div class="project-info overflow">
                        <h3>Product Info</h3>
                        <p>
                            <asp:Label ID="lbl_ProductPrice" runat="server" Text="PRODUCT_PRICE"></asp:Label>
                        </p>
                        <p>
                            <asp:Label ID="lbl_ProductDesc" runat="server" Text="PRODUCT_DESC"></asp:Label>
                        </p>
                    </div>
                    <div class="live-preview">
                        <div style="max-width: 200px; margin: 10px 0;">
                            <asp:DropDownList ID="ddl_quantity" runat="server" CssClass="form-control">
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <asp:Button ID="btn_Add" runat="server" CssClass="btn btn-common uppercase" Text="Add to cart" CausesValidation="false" OnClick="btn_Add_Click"></asp:Button>
                        <asp:Button ID="btn_GoToSignIn" runat="server" CssClass="btn btn-common uppercase" Text="Sign In to add to cart" CausesValidation="false" OnClick="btn_GoToSignIn_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="Server">
</asp:Content>

