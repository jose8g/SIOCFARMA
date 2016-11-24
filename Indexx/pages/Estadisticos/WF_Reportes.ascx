<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Reportes.ascx.cs" Inherits="Indexx.pages.Estadisticos.WebUserControl1" %>

<canvas id="barChart">

</canvas>

<script type="text/javascript">
    function initBarChart(arrData1, arrData2, arrCate) {
        console.log(JSON.parse(arrCate));
        arrCate = JSON.parse(arrCate);
        var ctx = document.getElementById("barChart");
        $(document).ready(function () {
            //arrCate = ['lbl', 'lbl2'];
            arrData1 = [1, 2];
            arrData2 = [2, 3];
            var mybarChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: arrCate,
                    datasets: [{
                        label: '# of Votes',
                        backgroundColor: "#26B99A",
                        data : arrData1
                    }, {
                        label: '# of Votes',
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