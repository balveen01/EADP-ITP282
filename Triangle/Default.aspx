<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/TemplateMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Triangle.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Home | Triangle
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div id="NotSignedInContainer" runat="server">
        <section id="home-slider">
            <div class="container">
                <div class="row">
                    <div class="main-slider">
                        <div class="slide-text">
                            <h1>3 Points of Success for the Environment</h1>
                            <p>To achieve a better world, 3 groups of people must agree to the same thing. The first are governments, the second are companies like us that help the environment and the third is your participation.</p>
                            <a href="/w/Products.aspx" class="btn btn-common">View our products</a>
                        </div>
                        <img src="/assets/template/img/slider/hill.png" class="slider-hill" alt="slider image" />
                        <img src="/assets/template/img/slider/house.png" class="slider-house" alt="slider image" />
                        <img src="/assets/template/img/slider/sun.png" class="slider-sun" alt="slider image" />
                        <img src="/assets/template/img/slider/birds1.png" class="slider-birds1" alt="slider image" />
                        <img src="/assets/template/img/slider/birds2.png" class="slider-birds2" alt="slider image" />
                    </div>
                </div>
            </div>
            <div class="preloader"><i class="fa fa-sun-o fa-spin"></i></div>
        </section>

        <section id="services">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4 text-center padding wow fadeIn" data-wow-duration="1000ms" data-wow-delay="300ms">
                        <div class="single-service">
                            <div class="wow scaleIn" data-wow-duration="500ms" data-wow-delay="300ms">
                                <img src="/assets/template/img/services/product.png" alt="" />
                            </div>
                            <h2>Great Products</h2>
                            <p>Our products are made from recycled electronic parts that function as efficient as brand new components.</p>
                        </div>
                    </div>
                    <div class="col-sm-4 text-center padding wow fadeIn" data-wow-duration="1000ms" data-wow-delay="600ms">
                        <div class="single-service">
                            <div class="wow scaleIn" data-wow-duration="500ms" data-wow-delay="600ms">
                                <img src="/assets/template/img/services/teamwork.png" alt="" />
                            </div>
                            <h2>Sourcing Practices</h2>
                            <p>We source our resources from countries all over the world, allowing us to provide jobs for the citizens living there.</p>
                        </div>
                    </div>
                    <div class="col-sm-4 text-center padding wow fadeIn" data-wow-duration="1000ms" data-wow-delay="900ms">
                        <div class="single-service">
                            <div class="wow scaleIn" data-wow-duration="500ms" data-wow-delay="900ms">
                                <img src="/assets/template/img/services/environment.png" alt="" />
                            </div>
                            <h2>Environment Focused</h2>
                            <p>For every product that you buy, you contribute to countless of environmental charities that help perserve the world.</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section id="features">
            <div class="container">
                <div class="row">
                    <div class="single-features">
                        <div class="col-sm-5 wow fadeInLeft" data-wow-duration="500ms" data-wow-delay="300ms">
                            <img src="/assets/template/img/features/feature1.svg" class="img-responsive" alt="" />
                        </div>
                        <div class="col-sm-6 wow fadeInRight" data-wow-duration="500ms" data-wow-delay="300ms">
                            <h2>Join our Ecosystem</h2>
                            <p>All our devices are linked through a proprietary peer-to-peer network distribution system. This allows us to use blockchain technology to enhance content distribution to you. Your photos, videos and games will download faster, work better and never be an inconvience.</p>
                        </div>
                    </div>
                    <div class="single-features">
                        <div class="col-sm-6 col-sm-offset-1 align-right wow fadeInLeft" data-wow-duration="500ms" data-wow-delay="300ms">
                            <h2>Collaborative Mission</h2>
                            <p>Sourcing from countries like Loas, Uganda and Nepal, we aim to impact them positively. We want to contribute to the growth of these countries as well as serve the environmental concerns. We promise that we will never jeopardise the countries that we invest in.</p>
                        </div>
                        <div class="col-sm-5 wow fadeInRight" data-wow-duration="500ms" data-wow-delay="300ms">
                            <img src="/assets/template/img/features/feature2.svg" class="img-responsive" alt="" />
                        </div>
                    </div>
                    <div class="single-features">
                        <div class="col-sm-5 wow fadeInLeft" data-wow-duration="500ms" data-wow-delay="300ms">
                            <img src="/assets/template/img/features/feature3.svg" class="img-responsive" alt="" />
                        </div>
                        <div class="col-sm-6 wow fadeInRight" data-wow-duration="500ms" data-wow-delay="300ms">
                            <h2>Communicate our message, it starts with You</h2>
                            <p>As a company, we can only take the steps within our reach. This is where you come in. We advocate for the environmental changes that are coming and we hope not only will you trust us to provide you products that are environmentally friendly but as well as take a stand in this problem.</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section id="clients">
            <div class="container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="clients text-center wow fadeInUp" data-wow-duration="500ms" data-wow-delay="300ms">
                            <p>
                                <img src="assets/template/img/engineers/coding.png" class="img-responsive" alt="" width="200" />
                            </p>
                            <h1 class="title">Our Technology Experts</h1>
                            <p>
                                Why should you trust us?<br />
                                That's because our team of enginneers are proudly from these companies
                            </p>
                        </div>
                        <div class="clients-logo wow fadeIn" data-wow-duration="1000ms" data-wow-delay="600ms">
                            <div class="col-xs-3 col-sm-2">
                                <img src="/assets/template/img/engineers/google.png" class="img-responsive" alt="" />
                            </div>
                            <div class="col-xs-3 col-sm-2">
                                <img src="/assets/template/img/engineers/intel.png" class="img-responsive" alt="" />
                            </div>
                            <div class="col-xs-3 col-sm-2">
                                <img src="/assets/template/img/engineers/kingston.png" class="img-responsive" alt="" />
                            </div>
                            <div class="col-xs-3 col-sm-2">
                                <img src="/assets/template/img/engineers/coolermaster.png" class="img-responsive" alt="" />
                            </div>
                            <div class="col-xs-3 col-sm-2">
                                <img src="/assets/template/img/engineers/microsoft.png" class="img-responsive" alt="" />
                            </div>
                            <div class="col-xs-3 col-sm-2">
                                <img src="/assets/template/img/engineers/amd.png" class="img-responsive" alt="" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <div id="SignedInContainer" runat="server">
        <div class="container">
            <h1>Signed In.</h1>
            <p>Welcome back</p>
            <br /><br />
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
