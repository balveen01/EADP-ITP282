<%@ Page Title="" Language="C#" MasterPageFile="~/assets/mp/DeliveryMaster.master" AutoEventWireup="true" CodeBehind="Timeline.aspx.cs" Inherits="Doosan.e.Delivery.Timeline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Delivery Timeline
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <style>
        #BodyPlaceHolder_BodyPlaceHolder_SideNavPlaceHolder_lbtn_Delivery_Timeline {
            color: #007bff;
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

        .table tr td, .table tr {
            text-align: center;
        }

            .table tr td:nth-child(1) {
                width: 10%;
            }

            .table tr td:nth-child(2) {
                width: 30%;
            }

            .table tr td:nth-child(3) {
                width: 30%;
            }

            .table tr td:nth-child(4) {
                width: 30%;
            }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="row no-gutters mt-4">
        <div class="col-md-12">
            <h1>Delivery Timeline</h1>
            <p><span class="text-muted" style="font-size: 16px;">(Recent Transactions)</span></p>
            <hr />

            <table class="table table-striped table-bordered table-sm">
                <thead>
                    <tr>
                        <th>Delivery ID</th>
                        <th>Status Changed</th>
                        <th>Date Modified</th>
                        <th>&nbsp;</th>
                    </tr>
                </thead>
                <tbody id="deliveryTable"></tbody>
            </table>
        </div>
    </div>

    <script>
        const getDifferenceInTime = (time) => {
            if (time == null || time === null || typeof time == 'undefined' || typeof time === 'undefined')
                return;

            const today = new Date();
            const previousDate = new Date(time)
            //const previousDate = new Date(time.substring(11, 15), time.substring(4,8), time.substring(8,11));
            const diffTime = Math.abs(today - previousDate);
            //console.log({ today, previousDate, diffTime })
            var diffDays = Math.floor(diffTime / 86400000); // days
            var diffHrs = Math.floor((diffTime % 86400000) / 3600000); // hours
            var diffMins = Math.round(((diffTime % 86400000) % 3600000) / 60000); // min
            //return diffDays + " days, " + diffHrs + " hours, " + diffMins + " minutes";

            if (diffDays > 0 && diffHrs > 0 && diffMins > 0) {
                return diffDays + " days, " + diffHrs + " hours, " + diffMins + " minutes ago";
            } else if (diffDays === 0 && diffHrs > 0 && diffMins > 0) {
                return diffHrs + " hours, " + diffMins + " minutes ago";
            } else {
                return diffMins + " minutes ago";
            }
        }

        const createRow = (id, date, type) => {
            if (date === null || date === null || typeof date === 'undefined' || typeof date === 'undefined') {
                return "";
            }
            else {
                if (type === "a") {
                    return (`<tr><td>${id}</td><td><span class="text-color1">Approved</span></td><td>${getDifferenceInTime(date)}</td><td><a href="/e/Delivery/Details.aspx?id=${id}">View Delivery</a></td></tr>`)
                }
                else if (type == "p") {
                    return (`<tr><td>${id}</td><td><span class="text-color2">Packed</span></td><td>${getDifferenceInTime(date)}</td><td><a href="/e/Delivery/Details.aspx?id=${id}">View Delivery</a></td></tr>`)
                }
                else if (type == "d") {
                    return (`<tr><td>${id}</td><td><span class="text-color3">Delivered</span></td><td>${getDifferenceInTime(date)}</td><td><a href="/e/Delivery/Details.aspx?id=${id}">View Delivery</a></td></tr>`)
                }

            }
        }

        const deliveryTable = document.getElementById("deliveryTable");

        const createDeliveryTable = (string) => {
            deliveryTable.innerHTML += string;
        }

        const generateDeliverTable = () => {
            deliveriesDataSet.sort(function (a, b) {
                if (a[1] === null || b[1] === null || typeof a[1] === 'undefined' || typeof b[1] === 'undefined') {
                    return -1;
                }
                a = new Date(a[1]);
                b = new Date(b[1]);
                return a > b ? -1 : a < b ? 1 : 0
            })

            deliveriesDataSet.forEach(column => createDeliveryTable(createRow(column[0], column[1], column[2])));
        }


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

        generateDeliverTable();
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavascriptPlaceHolder" runat="server">
</asp:Content>
