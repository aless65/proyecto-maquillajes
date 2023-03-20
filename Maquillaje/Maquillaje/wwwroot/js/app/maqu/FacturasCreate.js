$("#prod_Id").prop("disabled", true);
$("#factdeta_Cantidad").prop("disabled", true);
$("#factdeta_PrecioShow").prop("disabled", true);
$("#cate").prop("disabled", true);
$("#btnContinuar").prop("disabled", true);
$("#btnFinalizar").prop("disabled", true);

$("#btnSiguiente").click(function () {

    if (!($("#clie_Id").val() > 0)) {
        $("#clie_IdValidation").prop("hidden", false);
        console.log("cliente");
    } else {
        $("#clie_IdValidation").prop("hidden", true);
    }

    if (!($("#meto_Id").val() > 0)) {
        $("#meto_IdValidation").prop("hidden", false);
        console.log("metodo");
    } else {
        $("#meto_IdValidation").prop("hidden", true);
    }

    if ($("#meto_Id").val() > 0 && $("#clie_Id").val() > 0) {

        sessionStorage.setItem("inserta", "jaja");
        sessionStorage.setItem("metodo", $("#meto_Id").val());
        sessionStorage.setItem("cliente", $("#clie_Id").val());

        $("#formCreate").submit();
    }
});

$(document).ready(function () {

    $('#menuMaquillaje').addClass('active');
    $('#facturasItem').addClass('active');
    $('#subMenuMaquillaje').addClass('show');

    console.log(sessionStorage.getItem("inserta"));

    if (sessionStorage.getItem("inserta") != null) {
        $("#clie_Id").prop("disabled", true);
        $("#clie_Id").val(sessionStorage.getItem("cliente"));
        $("#meto_Id").prop("disabled", true);
        $("#meto_Id").val(sessionStorage.getItem("metodo"));
        $("#empe_Id").prop("disabled", true);
        $("#btnSiguiente").prop("disabled", true);

        $("#prod_Id").prop("disabled", false);
        $("#factdeta_Cantidad").prop("disabled", false);
        $("#cate").prop("disabled", false);
        $("#btnContinuar").prop("disabled", false);
        $("#btnFinalizar").prop("disabled", false);
    }

    $("#esEditar").val("no");
    $("#esEditar2").val("no");
})