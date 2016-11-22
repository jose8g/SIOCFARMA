function mostrar() {
    $("#pop1").fadeIn('slow');

} //checkHover
function cerrar() {
    $("#pop1").fadeOut('slow');

}
function cliclBtnShowPopup() {
    $(".btnCerrarSolicitud").click(function () {
        alert("llega");
        mostrar();
    });
}

$(document).ready(function () {

    console.log($(".btnCerrarSolicitud"));
    $("#pop1").fadeOut('slow');

    $(".btnCerrarSolicitud").click(function (){
        mostrar();
    });

    //    $("#pop").fadeOut('slow');
    //Conseguir valores de la img
    // var img_w = $("#pop img").width() + 10;
    //  var img_h = $("#pop img").height() + 28;

    //Darle el alto y ancho
    //    $("#pop").css('width', img_w + 'px');
    //    $("#pop").css('height', img_h + 'px');
    $("#pop1").css('width', '40%');
    $("#pop1").css('height', '40%');

    //Esconder el popup
    //    $("#pop").hide();

    //Consigue valores de la ventana del navegador
    var w = $(this).width();
    var h = $(this).height();

    //Centra el popup   
    w = (w / 2) - (500 / 2);
    h = (h / 2) - (300 / 2);
    $("#pop1").css("left", w + "px");
    $("#pop1").css("top", h + "px");


    //   
    //    //Función para cerrar el popup
    $("#cerrar").click(function () {
        $("#pop1").fadeOut('slow');
    });
    $("#HeadContent_WF_Ventas1_btnPdf").click(function () {
        $("#pop1").fadeOut('slow');
    });

});
function mostrarSub() {

    $("#pop1").fadeIn('slow');

} //checkHover

$(document).ready(function () {


    $("#pop1").fadeOut('slow');

    $(".btnCerrarSolicitud").click(function () {

        mostrarSub();
    });

    //    $("#pop").fadeOut('slow');
    //Conseguir valores de la img
    // var img_w = $("#pop img").width() + 10;
    //  var img_h = $("#pop img").height() + 28;

    //Darle el alto y ancho
    //    $("#pop").css('width', img_w + 'px');
    //    $("#pop").css('height', img_h + 'px');
    $("#pop1").css('width', '60%');
    $("#pop1").css('height', '60%');

    //Esconder el popup
    //    $("#pop").hide();

    //Consigue valores de la ventana del navegador
    var w = $(this).width();
    var h = $(this).height();

    //Centra el popup   
    w = (w / 2) - (500 / 2);
    h = (h / 2) - (300 / 2);
    $("#pop1").css("left", w + "px");
    $("#pop1").css("top", h + "px");


    //   
    //    //Función para cerrar el popup
    $("#cerrar").click(function () {
        $("#pop1").fadeOut('slow');
    });


});