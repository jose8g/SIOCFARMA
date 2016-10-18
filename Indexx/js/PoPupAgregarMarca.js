function mostrarpopAgregarMarca() {
    Q3("#popAgregarMarca").fadeIn('slow');
} //checkHover

$(document).ready(function () {

    Q3("#popAgregarMarca").hide();
    Q3(".popAgregarMarca").live("click", function () {
        mostrarpopAjustarCotizacionProducto();
    });

    Q3("#popAgregarMarca").css('width', '40%');
    Q3("#popAgregarMarca").css('height', '80%');

    var w = $(this).width();
    var h = $(this).height();

    //Centra el popup   
    w = (w / 2) - (500 / 2);
    h = (h / 2) - (300 / 2);
    Q3("#popAgregarMarca").css("left", w + "px");
    Q3("#popAgregarMarca").css("top", h + "px");

    //    //Función para cerrar el popup
    Q3("#cerrarpopAgregarMarca").live("click", function () {
        Q3("#popAgregarMarca").fadeOut('slow');
    });

});