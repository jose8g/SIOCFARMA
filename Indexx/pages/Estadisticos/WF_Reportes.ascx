<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WF_Reportes.ascx.cs" Inherits="Indexx.pages.Estadisticos.WF_Reportes" %>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate>
<div class="row">
    <div class="col-sm-12" >
        <div class="x_panel">
            <div class="x_title">
                <h2>Busqueda </h2>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Fecha Inicio</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="fecInicio" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-3" style="top:6px;">Fecha Fin</label>
                        <div class="col-md-9 col-sm-9 col-xs-9">
                            <asp:TextBox ID="fecFin" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="fa fa-calendar-o form-control-feedback right" aria-hidden="true"></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Buscar" OnClick="getGraficosByFiltro"/>
            </div>
        </div>
    </div>
</div>

<div class="row">
    <div class="col-md-6 col-sm-6 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <h2><small>Ventas por vendedor</small></h2>
                <ul class="nav navbar-right panel_toolbox">
                    <li>
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <canvas id="barChart"></canvas>
            </div>
        </div>
    </div>
    <div class="col-md-6 col-sm-6 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <h2><small>Items mas vendidos</small></h2>
                <ul class="nav navbar-right panel_toolbox">
                    <li>
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <canvas id="barChart2"></canvas>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    function initBarChart(arrData1, arrData2, arrCate, value) {
        console.log("ENTRA1");
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

    function initBarChart2(arrData1, arrCate) {
        console.log("ENTRA2");
        arrCate = JSON.parse(arrCate);
        arrData1 = JSON.parse(arrData1);
        var ctx = document.getElementById("barChart2");

        $(document).ready(function () {
            var mybarChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: arrCate,
                    datasets: [{
                        label: 'Productos',
                        backgroundColor: "#26B99A",
                        data: arrData1
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

    
</ContentTemplate>
</asp:UpdatePanel>