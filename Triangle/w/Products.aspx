<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/TemplateMaster.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Triangle.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Our Products | Triangle
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #header > div > div > div.collapse.navbar-collapse > ul > li:nth-child(2) > a {
            color: #00aeef;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
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

    <section id="projects">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="row">
                        <%--<ul class="portfolio-filter text-center">
                            <li><a class="btn btn-default active" href="#" data-filter="*">All</a></li>
                            <li><a class="btn btn-default" href="#" data-filter=".branded">Branded</a></li>
                            <li><a class="btn btn-default" href="#" data-filter=".design">Design</a></li>
                            <li><a class="btn btn-default" href="#" data-filter=".folio">Folio</a></li>
                            <li><a class="btn btn-default" href="#" data-filter=".logos">Logos</a></li>
                            <li><a class="btn btn-default" href="#" data-filter=".mobile">Mobile</a></li>
                            <li><a class="btn btn-default" href="#" data-filter=".mockup">Mockup</a></li>
                        </ul>--%>
                        <div class="portfolio-items">
                            <asp:Repeater ID="Re1" runat="server" DataSourceID="ProdDataSource">
                                <ItemTemplate>
                                    <div class="col-xs-6 col-sm-6 col-md-3 portfolio-item branded logos  wow scaleIn" data-wow-duration="500ms" data-wow-delay="300ms">
                                        <div class="portfolio-wrapper">

                                            <div class="portfolio-single">
                                                <div class="portfolio-thumb">
                                                    <asp:Image runat="server" CssClass="img-responsive" Style="object-fit: contain; height: 250px; width: 250px; margin: 0 auto;" ImageUrl='<%# "data:Image/png;base64,"+ Convert.ToBase64String((byte[])Eval("product_image")) %>' />
                                                </div>
                                                <div class="portfolio-view">
                                                    <ul class="nav nav-pills">
                                                        <li><a href="/w/Product-Details.aspx?pid=<%#Eval("product_id")%>"><i class="fa fa-link"></i></a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="portfolio-info ">
                                                <h3 style="text-align: center;">
                                                    <asp:Label ID="lbl_ProductName" runat="server" Text='<%#Eval("product_name")%>'></asp:Label>
                                                </h3>
                                            </div>


                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <asp:SqlDataSource ID="ProdDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:TRIANGLE_DB %>" SelectCommand="SELECT * FROM products where is_available = 'TRUE'"></asp:SqlDataSource>
                    </div>
                </div>
                <%--<div class="col-md-3 col-sm-4">
                    <div class="sidebar portfolio-sidebar">
                        <div class="sidebar-item categories">
                            <h3>Product Categories</h3>
                            <ul class="nav navbar-stacked">
                                <li><a href="/w/Products.aspx?category=laptop">Laptops<span class="pull-right">(<asp:Label ID="lbl_CategoryLaptop" runat="server" Text="0"></asp:Label>)</span></a></li>
                                <li><a href="/w/Products.aspx?category=phones">Phones<span class="pull-right">(<asp:Label ID="lbl_CategoryPhones" runat="server" Text="0"></asp:Label>)</span></a></li>
                                <li><a href="/w/Products.aspx?category=tablets">Tablets<span class="pull-right">(<asp:Label ID="lbl_CategoryTablets" runat="server" Text="0"></asp:Label>)</span></a></li>
                            </ul>
                        </div>
                        <div class="sidebar-item popular">
                            <h3>What's new</h3>
                            <ul class="gallery">
                                <li><a href="#">
                                    <img src="/assets/template/img/products/product1.jpg" alt="" /></a>
                                </li>
                                <li><a href="#">
                                    <img src="/assets/template/img/products/product1.jpg" alt="" /></a>
                                </li>
                                <li><a href="#">
                                    <img src="/assets/template/img/products/product1.jpg" alt="" /></a>
                                </li>
                                <li><a href="#">
                                    <img src="/assets/template/img/products/product1.jpg" alt="" /></a>
                                </li>
                                <li><a href="#">
                                    <img src="/assets/template/img/products/product1.jpg" alt="" /></a>
                                </li>
                                <li><a href="#">
                                    <img src="/assets/template/img/products/product1.jpg" alt="" /></a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
