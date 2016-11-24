function mostrar() {

    $("#pop3").fadeIn('slow');

} //checkHover

function cliclBtnShowPopup3() {
    $(".btnCerrarSolicitud3").click(function () {
        mostrar();
    });
}

$(document).ready(function () {

    console.log($(".btnCerrarSolicitud3"));
    $("#pop3").fadeOut('slow');

    $(".btnCerrarSolicitud3").click(function () {
        mostrar();
    });

    //    $("#pop").fadeOut('slow');
    //Conseguir valores de la img
    // var img_w = $("#pop img").width() + 10;
    //  var img_h = $("#pop img").height() + 28;

    //Darle el alto y ancho
    //    $("#pop").css('width', img_w + 'px');
    //    $("#pop").css('height', img_h + 'px');
    $("#pop3").css('width', '40%');
    $("#pop3").css('height', '40%');

    //Esconder el popup
    //    $("#pop").hide();

    //Consigue valores de la ventana del navegador
    var w = $(this).width();
    var h = $(this).height();

    //Centra el popup   
    w = (w / 2) - (500 / 2);
    h = (h / 2) - (300 / 2);
    $("#pop3").css("left", w + "px");
    $("#pop3").css("top", h + "px");


    //   
    //    //Función para cerrar el popup
    $("#cerrar3").click(function () {
        $("#pop3").fadeOut('slow');
    });


});
function mostrarSub() {

    $("#pop3").fadeIn('slow');

} //checkHover

$(document).ready(function () {


    $("#pop3").fadeOut('slow');

    $(".btnCerrarSolicitud3").click(function () {

        mostrarSub();
    });

    //    $("#pop").fadeOut('slow');
    //Conseguir valores de la img
    // var img_w = $("#pop img").width() + 10;
    //  var img_h = $("#pop img").height() + 28;

    //Darle el alto y ancho
    //    $("#pop").css('width', img_w + 'px');
    //    $("#pop").css('height', img_h + 'px');
    $("#pop3").css('width', '60%');
    $("#pop3").css('height', '60%');

    //Esconder el popup
    //    $("#pop").hide();

    //Consigue valores de la ventana del navegador
    var w = $(this).width();
    var h = $(this).height();

    //Centra el popup   
    w = (w / 2) - (500 / 2);
    h = (h / 2) - (300 / 2);
    $("#pop3").css("left", w + "px");
    $("#pop3").css("top", h + "px");


    //   
    //    //Función para cerrar el popup
    $("#cerrar3").click(function () {
        $("#pop3").fadeOut('slow');
    });


});