function mostrar() {

    $("#pop2").fadeIn('slow');

} //checkHover

function cliclBtnShowPopup2() {
    $(".btnCerrarSolicitud2").click(function () {
        mostrar();
    });
}

$(document).ready(function () {

    console.log($(".btnCerrarSolicitud2"));
    $("#pop2").fadeOut('slow');

    $(".btnCerrarSolicitud2").click(function () {
        mostrar();
    });

    //    $("#pop").fadeOut('slow');
    //Conseguir valores de la img
    // var img_w = $("#pop img").width() + 10;
    //  var img_h = $("#pop img").height() + 28;

    //Darle el alto y ancho
    //    $("#pop").css('width', img_w + 'px');
    //    $("#pop").css('height', img_h + 'px');
    $("#pop2").css('width', '40%');
    $("#pop2").css('height', '40%');

    //Esconder el popup
    //    $("#pop").hide();

    //Consigue valores de la ventana del navegador
    var w = $(this).width();
    var h = $(this).height();

    //Centra el popup   
    w = (w / 2) - (500 / 2);
    h = (h / 2) - (300 / 2);
    $("#pop2").css("left", w + "px");
    $("#pop2").css("top", h + "px");


    //   
    //    //Función para cerrar el popup
    $("#cerrar2").click(function () {
        $("#pop2").fadeOut('slow');
    });


});
function mostrarSub() {

    $("#pop2").fadeIn('slow');

} //checkHover

$(document).ready(function () {


    $("#pop2").fadeOut('slow');

    $(".btnCerrarSolicitud2").click(function () {

        mostrarSub();
    });

    //    $("#pop").fadeOut('slow');
    //Conseguir valores de la img
    // var img_w = $("#pop img").width() + 10;
    //  var img_h = $("#pop img").height() + 28;

    //Darle el alto y ancho
    //    $("#pop").css('width', img_w + 'px');
    //    $("#pop").css('height', img_h + 'px');
    $("#pop2").css('width', '60%');
    $("#pop2").css('height', '60%');

    //Esconder el popup
    //    $("#pop").hide();

    //Consigue valores de la ventana del navegador
    var w = $(this).width();
    var h = $(this).height();

    //Centra el popup   
    w = (w / 2) - (500 / 2);
    h = (h / 2) - (300 / 2);
    $("#pop2").css("left", w + "px");
    $("#pop2").css("top", h + "px");


    //   
    //    //Función para cerrar el popup
    $("#cerrar2").click(function () {
        $("#pop2").fadeOut('slow');
    });


});