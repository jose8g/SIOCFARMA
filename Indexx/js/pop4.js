function mostrar() {

    $("#pop4").fadeIn('slow');

} //checkHover

function cliclBtnShowPopup4() {
    $(".btnCerrarSolicitud4").click(function () {
        mostrar();
    });
}

$(document).ready(function () {

    console.log($(".btnCerrarSolicitud4"));
    $("#pop4").fadeOut('slow');

    $(".btnCerrarSolicitud4").click(function () {
        mostrar();
    });

    //    $("#pop").fadeOut('slow');
    //Conseguir valores de la img
    // var img_w = $("#pop img").width() + 10;
    //  var img_h = $("#pop img").height() + 28;

    //Darle el alto y ancho
    //    $("#pop").css('width', img_w + 'px');
    //    $("#pop").css('height', img_h + 'px');
    $("#pop4").css('width', '40%');
    $("#pop4").css('height', '40%');

    //Esconder el popup
    //    $("#pop").hide();

    //Consigue valores de la ventana del navegador
    var w = $(this).width();
    var h = $(this).height();

    //Centra el popup   
    w = (w / 2) - (500 / 2);
    h = (h / 2) - (300 / 2);
    $("#pop4").css("left", w + "px");
    $("#pop4").css("top", h + "px");


    //   
    //    //Función para cerrar el popup
    $("#cerrar4").click(function () {
        $("#pop4").fadeOut('slow');
    });


});
function mostrarSub() {

    $("#pop4").fadeIn('slow');

} //checkHover

$(document).ready(function () {


    $("#pop4").fadeOut('slow');

    $(".btnCerrarSolicitud4").click(function () {

        mostrarSub();
    });

    //    $("#pop").fadeOut('slow');
    //Conseguir valores de la img
    // var img_w = $("#pop img").width() + 10;
    //  var img_h = $("#pop img").height() + 28;

    //Darle el alto y ancho
    //    $("#pop").css('width', img_w + 'px');
    //    $("#pop").css('height', img_h + 'px');
    $("#pop4").css('width', '60%');
    $("#pop4").css('height', '60%');

    //Esconder el popup
    //    $("#pop").hide();

    //Consigue valores de la ventana del navegador
    var w = $(this).width();
    var h = $(this).height();

    //Centra el popup   
    w = (w / 2) - (500 / 2);
    h = (h / 2) - (300 / 2);
    $("#pop4").css("left", w + "px");
    $("#pop4").css("top", h + "px");


    //   
    //    //Función para cerrar el popup
    $("#cerrar4").click(function () {
        $("#pop4").fadeOut('slow');
    });


});