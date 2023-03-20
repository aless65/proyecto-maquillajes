
$(window).on('beforeunload', function () {
    sessionStorage.setItem("fecha", $("#fact_Fecha").val());
    sessionStorage.setItem("idEditar", $("#fact_IdEditarEn").val())
});


$(document).ready(function () {
    $('#menuMaquillaje').addClass('active');
    $('#facturasItem').addClass('active');
    $('#subMenuMaquillaje').addClass('show');

    if (sessionStorage.getItem("fecha") != null) {
        $("#fact_Fecha").val(sessionStorage.getItem("fecha"));
        $("#fact_Id").val(sessionStorage.getItem("idEditar"));

        $("#esEditar").val("si");
    }
})