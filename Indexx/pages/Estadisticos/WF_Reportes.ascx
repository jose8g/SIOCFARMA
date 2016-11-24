<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Reportes.ascx.cs" Inherits="Indexx.pages.Estadisticos.WebUserControl1" %>

<canvas id="barChart">

</canvas>

<script type="text/javascript">
    function initBarChart(arrData1, arrData2, arrCate) {
        arrCate  = JSON.parse(arrCate);
        arrData1 = JSON.parse(arrData1);
        arrData2 = JSON.parse(arrData2);
        console.log(arrCate);
        console.log(arrData1);
        console.log(arrData2);
        var ctx = document.getElementById("barChart");
        $(document).ready(function () {
            var mybarChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: arrCate,
                    datasets: [{
                        label: 'Items',
                        backgroundColor: "#26B99A",
                        data : arrData1
                    }, {
                        label: 'Ventas',
                        backgroundColor: "#03586A",
                        data: arrData2
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
        });
    }
    
</script>