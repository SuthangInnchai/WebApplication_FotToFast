$(document).ready(function () {
    $('#btnBarChart').on('click', function () {
        drawBarChart();
    });

    $('#btnBarChart2').on('click', function () {
        drawBarChart2();
    });

    $('#btnForDay').on('click', function () {
        drawDaySoldChart();
    });

    $('#btnForWeek').on('click', function () {
        drawWeekSoldChart();
    });

    $('#btnForMonth').on('click', function () {
        drawMonthSoldChart();
    });

    $('#btnForYear').on('click', function () {
        drawYearSoldChart();
    });
    $('#btnForSale').on('click', function () {
        drawAllSoldChart();
    });
});


function drawBarChart() {
    $.ajax({
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        url: '/StatisticView/GetProductAddingData',
        dataType: "json",
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
                    title: 'Import Product',
                    subtitle: 'XS, S , M, L, and XL Size'
                },
                bars: 'vertical',
                width: 900,
                height: 500
            };
            var chart = new google.charts.Line(document.getElementById('barchart'));
            chart.draw(data, options);
        },
        error: function (data) {
            alert("Error In getting Records");
        }
    });
}

function drawBarChart2() {
    $.ajax({
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        url: '/StatisticView/GetProductExsitingData',
        dataType: "json",
        success: function (companyData) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Product name');
            data.addColumn('number', 'XS');
            data.addColumn('number', 'S');
            data.addColumn('number', 'M');
            data.addColumn('number', 'L');
            data.addColumn('number', 'XL');

            $.each(companyData, function (i, d) {
                data.addRow([companyData[i].pName, companyData[i].XS, companyData[i].S, companyData[i].M, companyData[i].L, companyData[i].XL]);
            });
            var options = {
                chart: {
                    title: 'Total Balance Product in stock',
                    subtitle: 'XS, S , M, L, and XL Size'
                },
                bars: 'vertical',
                width: 900,
                height: 500
            };
            var chart = new google.charts.Line(document.getElementById('barchart'));
            chart.draw(data, options);
        },
        error: function (data) {
            alert("Error In getting Records");
        }
    });
}


function drawDaySoldChart() {
    $.ajax({
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        url: '/StatisticView/GetDaySoldOutData',
        dataType: "json",
        success: function (companyData) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Time of Day');
            data.addColumn('number', 'Quantity');
       
            var monthNames = [
                "Jan",
                "Feb",
                "Mar",
                "Apr",
                "May",
                "June",
                "July",
                "Aug",
                "Sep",
                "Oct",
                "Nov",
                "Dec"
            ];

            var DayName = [
                "Sun",
                "Mon",
                "Tue",
                "Wed",
                "Thu",
                "Fri",
                "Sat"
            ];
                 
            var currentdate = new Date(); 
            var datetime = DayName[currentdate.getDay()] + " "
                + monthNames[currentdate.getMonth()] + " "
                + currentdate.getDate() + " "
                + currentdate.getFullYear() + " ";
            //alert(datetime);
            
            
            $.each(companyData, function (i, d) {
              //  if(new Date(parseInt(companyData[i].SouldOuteDate.replace(/(^.*\()|([+-].*$)/g, '')).toString().substring(0, 15)) == datetime)  {

                        data.addRows
                            ([
                                [new Date(parseInt(companyData[i].SouldOuteDate.replace(/(^.*\()|([+-].*$)/g, ''))).toString().substring(16, 25) + "||" + companyData[i].ProductName, companyData[i].Quantity]
                                //[new Date(parseInt(companyData[i].SouldOuteDate.replace(/(^.*\()|([+-].*$)/g, ''))).toString().substring(0, 15) + "||" + companyData[i].ProductName, companyData[i].Quantity]

                            ]);
                        
                  //  }//while end

                
                    
                });

                var options = {
                    title: 'Product Sold a day',
                    width: 900,
                    height: 500,
                    hAxis: {
                        format: 'M/d/yy',
                        gridlines: { count: 5 }
                    },
                    vAxis: {
                        gridlines: { color: 'none' },
                        minValue: 0
                    }
                };


                var chart = new google.visualization.LineChart(document.getElementById('barchart'));

                    chart.draw(data, options);
                    
                
         },
        error: function (data) {
            alert("Error In getting Records"+datetime);
            
        }
    });
}

function drawWeekSoldChart() {
    $.ajax({
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        url: '/StatisticView/GetDaySoldOutData',
        dataType: "json",
        success: function (companyData) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Time of Day');
            data.addColumn('number', 'Quantity');
            // data.addColumn('string', 'Product name');
            //console.log("" + companyData[i].ProductName);

            $.each(companyData, function (i, d) {

                data.addRows
                    ([
                        [new Date(parseInt(companyData[i].SouldOuteDate.replace(/(^.*\()|([+-].*$)/g, ''))).toString().substring(0, 4) + "||" + companyData[i].ProductName, companyData[i].Quantity]
                    ]);


                /*   for (i = 0 ; i < itemTable; i++)
                   {
                  if (Date(companyData[i].SouldOuteDate).substring(0, 15) == Date().substring(0, 15))
                  {
                                    <input data row here>
                  } else {
                      i++;
                  }
              }*/


            });

            var options = {
                title: 'Product Sold Week',
                width: 900,
                height: 500,
                hAxis: {
                    format: 'M/d/yy',
                    gridlines: { count: 5 }
                },
                vAxis: {
                    gridlines: { color: 'none' },
                    minValue: 0
                }
            };
            var chart = new google.visualization.LineChart(document.getElementById('barchart'));
            chart.draw(data, options);
        },
        error: function (data) {
            alert("Error In getting Records");
        }
    });
}

       
function drawMonthSoldChart() {
    $.ajax({
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        url: '/StatisticView/GetDaySoldOutData',
        dataType: "json",
        success: function (companyData) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Time of Day');
            data.addColumn('number', 'Quantity');
            // data.addColumn('string', 'Product name');
            //console.log("" + companyData[i].ProductName);
            //[Date(companyData[i].SouldOuteDate).substring(16, 24)

            $.each(companyData, function (i, d) {

                data.addRows([[new Date(parseInt(companyData[i].SouldOuteDate.replace(/(^.*\()|([+-].*$)/g, ''))).toString().substring(4, 8) + "||" + companyData[i].ProductName, companyData[i].Quantity]]);

                /*   for (i = 0 ; i < itemTable; i++)
                   {
                  if (Date(companyData[i].SouldOuteDate).substring(0, 15) == Date().substring(0, 15))
                  {
                                    <input data row here>
                  } else {
                      i++;
                  }
              }*/


            });

            var options = {
                title: 'Product Sold Month',
                width: 900,
                height: 500,
                hAxis: {
                    format: 'M/d/yy',
                    gridlines: { count: 5 }
                },
                vAxis: {
                    gridlines: { color: 'none' },
                    minValue: 0
                }
            };
            var chart = new google.visualization.LineChart(document.getElementById('barchart'));
            chart.draw(data, options);
        },
        error: function (data) {
            alert("Error In getting Records");
        }
    });
}

function drawYearSoldChart() {
    $.ajax({
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        url: '/StatisticView/GetDaySoldOutData',
        dataType: "json",
        success: function (companyData) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Time of Day');
            data.addColumn('number', 'Quantity');
            // data.addColumn('string', 'Product name');
            //console.log("" + companyData[i].ProductName);
            //[Date(companyData[i].SouldOuteDate).substring(16, 24)

            $.each(companyData, function (i, d) {

                data.addRows([[new Date(parseInt(companyData[i].SouldOuteDate.replace(/(^.*\()|([+-].*$)/g, ''))).toString().substring(10, 15) + "||" + companyData[i].ProductName, companyData[i].Quantity]]);

                /*   for (i = 0 ; i < itemTable; i++)
                   {
                  if (Date(companyData[i].SouldOuteDate).substring(0, 15) == Date().substring(0, 15))
                  {
                                    <input data row here>
                  } else {
                      i++;
                  }
              }*/


            });

            var options = {
                title: 'Product Sold Year',
                width: 900,
                height: 500,
                hAxis: {
                    format: 'M/d/yy',
                    gridlines: { count: 5 }
                },
                vAxis: {
                    gridlines: { color: 'none' },
                    minValue: 0
                }
            };
            var chart = new google.visualization.LineChart(document.getElementById('barchart'));
            chart.draw(data, options);
        },
        error: function (data) {
            alert("Error In getting Records");
        }
    });
}
function drawAllSoldChart() {
    $.ajax({
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        url: '/StatisticView/GetDaySoldOutData',
        dataType: "json",
        success: function (companyData) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Time of Day');
            data.addColumn('number', 'Quantity');
      
            $.each(companyData, function (i, d) {

                data.addRows([[new Date(parseInt(companyData[i].SouldOuteDate.replace(/(^.*\()|([+-].*$)/g, ''))).toString().substring(0, 10) + "||" + companyData[i].ProductName, companyData[i].Quantity]]);

                /*   for (i = 0 ; i < itemTable; i++)
                   {
                  if (Date(companyData[i].SouldOuteDate).substring(0, 15) == Date().substring(0, 15))
                  {
                                    <input data row here>
                  } else {
                      i++;
                  }
              }*/


            });

            var options = {
                title: 'Product Sold Year',
                width: 900,
                height: 500,
                hAxis: {
                    format: 'M/d/yy',
                    gridlines: { count: 5 }
                },
                vAxis: {
                    gridlines: { color: 'none' },
                    minValue: 0
                }
            };
            var chart = new google.visualization.LineChart(document.getElementById('barchart'));
            chart.draw(data, options);
        },
        error: function (data) {
            alert("Error In getting Records");
        }
    });
}