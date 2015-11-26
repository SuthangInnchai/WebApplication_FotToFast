$(document).ready(function () {
    $('btnForDay').on('click', function () {
        drawDayChart();
    });

});

function drawDayChart() {
    $.ajax({
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        url: '/StatisticView/GetDaySoldOutData',
        dataType: "json",
        /*
        success: function (SaleData) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'SouldOuteDate');
            data.addColumn('string', 'Product name');
            data.addColumn('number', 'Quantity');
       
            $.each(SaleData, function (i, d) {
                data.addRows(
                    [SaleData[i].SouldOuteDate, SaleData[i].ProductName, SaleData[i].Quantity]
                    );
            });*/
        success: function (companyData) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'product name');
            data.addColumn('number', 'XS');
            data.addColumn('number', 'S');
            data.addColumn('number', 'M');
            data.addColumn('number', 'L');
            data.addColumn('number', 'XL');

            $.each(companyData, function (i, d) {
                data.addRow(
                    [companyData[i].pName, companyData[i].XS, companyData[i].S, companyData[i].M, companyData[i].L, companyData[i].XL]
                    );
            });
            var options = {
                chart: {
                    title: 'Sold Out Product',
                    subtitle: 'Today'
                },
                width: 900,
                height: 500,
                axes: {
            x: {
            0: {side: 'top'}
    }
    }
            };

            var chart = new google.charts.Line(document.getElementById('barchart'));
            chart.draw(data, options);

        }, error: function (data) {
            alert("Error In getting Records");
        }
    });
}