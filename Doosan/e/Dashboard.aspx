<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/_settings/Navigation.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Doosan.w.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Dashboard
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.css" />
    <style>
        .chart-container {
            border: 1px solid rgba(0,0,0,.1);
        }

        table {
            text-align: center;
        }

        .text-color1 {
            color: #07A0C3;
            font-weight: bold;
        }

        .text-color2 {
            color: #CC5803;
            font-weight: bold;
        }

        .text-color3 {
            color: #28a745;
            font-weight: bold;
        }

        .table tr td:nth-child(1) {
            width: 10%;
        }

        .table tr td:nth-child(2) {
            width: 35%;
        }

        .table tr td:nth-child(3) {
            width: 55%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters mt-3">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-12">
                    <h1>Company Dashboard</h1>
                    <hr />
                </div>
            </div>
            <div class="row no-gutters">
                <div class="col-8">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="chart-container">
                                <canvas id="productsShipped"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 pl-4">
                    <div class="row no-gutters justify-content-center">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="chart-container">
                                        <canvas id="bestSellingProducts"></canvas>
                                    </div>
                                </div>
                                <div class="col-md-12" style="margin-top: 20px;">
                                    <div class="chart-container">
                                        <canvas id="worstSellingProducts"></canvas>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
    <script>
        $(".col-md-2.bg-light.sidebar").addClass("d-none").removeClass("col-md-2");
        $(".col-md-10.ml-sm-auto.px-4").addClass("col-md-12").removeClass("col-md-10");

        const getMonth = (index) => {
            if (index === 1) return 'January';
            else if (index === 2) return 'February';
            else if (index === 3) return 'March';
            else if (index === 4) return 'April';
            else if (index === 5) return 'May';
            else if (index === 6) return 'June';
            else if (index === 7) return 'July';
            else if (index === 8) return 'August';
            else if (index === 9) return 'September';
            else if (index === 10) return 'October';
            else if (index === 11) return 'November';
            else if (index === 12) return 'December';
        }

        let productsShippedData = [];
        let productShippedLabels = [];
        let topProductsSalesData = [];
        let topProductsSalesNames = [];
        let bottomProductsSalesData = [];
        let bottomProductsSalesNames = [];

        const pushProductsShipped = (data, monthIndex) => {
            productsShippedData.push(data);
            productShippedLabels.push(getMonth(monthIndex));
        }

        const pushTopProductsSales = (data, name) => {
            topProductsSalesData.push(data);
            topProductsSalesNames.push(name);
        }

        const pushBottomProductsSales = (data, name) => {
            bottomProductsSalesData.push(data);
            bottomProductsSalesNames.push(name);
        }

        const pushData = () => {
            productShippedDataSet.forEach(column => pushProductsShipped(column[2], column[1]));
            topProductsSalesDataSet.forEach(column => pushTopProductsSales(column[2], column[1]))
            bottomProductsSalesDataSet.forEach(column => pushBottomProductsSales(column[2], column[1]))
            createCharts();
        }


        const createCharts = () => {
            var productsShipped = document.getElementById('productsShipped')
            var productsShippedChart = new Chart(productsShipped, {
                type: 'line',
                data: {
                    labels: productShippedLabels,
                    datasets: [{
                        data: productsShippedData,
                        lineTension: 0.4,
                        backgroundColor: 'transparent',
                        borderColor: '#007bff',
                        borderWidth: 4,
                        responsive: true,
                        pointBackgroundColor: '#007bff'
                    }]
                },
                options: {
                    responsive: true,
                    title: {
                        display: true,
                        text: 'Number of Products Shipped for the Past 12 Months'
                    },
                    tooltips: {
                        mode: 'index',
                        intersect: false,
                    },
                    hover: {
                        mode: 'nearest',
                        intersect: true
                    },
                    scales: {
                        xAxes: [{
                            display: true,
                            scaleLabel: {
                                display: true,
                                labelString: 'Month'
                            }
                        }],
                        yAxes: [{
                            display: true,
                            scaleLabel: {
                                display: true,
                                labelString: 'Product Shipped ($SGD)'
                            }
                        }]
                    },
                    legend: {
                        display: false
                    }
                }
            })

            var bestSellingProducts = document.getElementById('bestSellingProducts')
            var bestSellingProductsChart = new Chart(bestSellingProducts, {
                type: 'bar',
                data: {
                    datasets: [{
                        data: topProductsSalesData,
                        backgroundColor: ["#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                        label: 'Products Sold'
                    }],
                    labels: topProductsSalesNames,
                },
                options: {
                    scales: {
                        xAxes: [{
                            ticks: {
                                callback: function (t) {
                                    var maxLabelLength = 7;
                                    if (t.length > maxLabelLength) return t.substr(0, maxLabelLength) + '...';
                                    else return t;
                                }
                            }
                        }],
                        yAxes: [{
                            ticks: {
                                beginAtZero: true,
                                stepSize: 200
                            }
                        }]
                    },
                    responsive: true,
                    legend: {
                        display: false
                    },
                    title: {
                        display: true,
                        text: 'Best Selling Products'
                    },
                    animation: {
                        animateScale: true,
                        animateRotate: true
                    }
                }
            });

            var worstSellingProducts = document.getElementById('worstSellingProducts')
            var worstSellingProductsChart = new Chart(worstSellingProducts, {
                type: 'bar',
                data: {
                    datasets: [{
                        data: bottomProductsSalesData,
                        backgroundColor: ["#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                        label: "Products Sold",
                    }],
                    labels: bottomProductsSalesNames,
                },
                options: {
                    scales: {
                        xAxes: [{
                            ticks: {
                                callback: function (t) {
                                    var maxLabelLength = 7;
                                    if (t.length > maxLabelLength) return t.substr(0, maxLabelLength) + '...';
                                    else return t;
                                }
                            }
                        }],
                        yAxes: [{
                            ticks: {
                                beginAtZero: true,
                                stepSize: 200
                            }
                        }]
                    },
                    responsive: true,
                    legend: {
                        display: false
                    },
                    title: {
                        display: true,
                        text: 'Worst Selling Products'
                    },
                    animation: {
                        animateScale: true,
                        animateRotate: true
                    }
                }
            });
        }


        pushData();
    </script>
</asp:Content>
