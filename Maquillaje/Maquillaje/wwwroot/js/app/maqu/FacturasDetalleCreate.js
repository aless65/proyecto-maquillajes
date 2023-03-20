$("#fact_Id").prop("hidden", true);

if ($("#fact_Id").val() > 0) {
    sessionStorage.setItem('id', $("#fact_Id").val());
}

$(document).ready(function () {
    $("#factdeta_Precio").val("");
    $("#factdeta_Cantidad").val("");
})

//$(window).on('beforeunload', function () {
//    sessionStorage.setItem('id', $("#fact_Id").val());
//});

$("#btnContinuar").click(function () {

    if (!($("#prod_Id").val() > 0)) {
        $("#prod_IdValidation").prop("hidden", false);
    } else {
        $("#prod_IdValidation").prop("hidden", true);
    }

    if (!($("#factdeta_Cantidad").val() > 0)) {
        $("#factdeta_CantidadValidation").prop("hidden", false);
    } else {
        $("#factdeta_CantidadValidation").prop("hidden", true);
    }

    if ($("#prod_Id").val() > 0 && $("#factdeta_Cantidad").val() > 0) {
        $("#fact_Id").val(sessionStorage.getItem('id'));

        $.getJSON('/Factura/RevisarStock', { id: $("#prod_Id").val(), cantidad: $("#factdeta_Cantidad").val() })
            .done(function (stock) {
                if (stock == 0) {
                    MostrarMensajeWarning('Stock insuficiente');
                } else {
                    $("#formCreateDetalles").submit();
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.error('Error al cargar los productos: ' + textStatus + ', ' + errorThrown);
            });
    }
});

$("#cate").change(function () {
    var cate_Id = $("#cate").val();

    $.getJSON('/Factura/CargarProductos', { id: cate_Id })
        .done(function (productos) {
            var productosSelect = $('#prod_Id');
            productosSelect.empty();
            productosSelect.append($('<option>', {
                value: '',
                text: '--Selecciona un producto--'
            }));
            $.each(productos, function (index, item) {
                productosSelect.append($('<option>', {
                    value: item.prod_Id,
                    text: item.prod_Nombre
                }));
            });
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.error('Error al cargar los productos: ' + textStatus + ', ' + errorThrown);
        });
})


$("#factdeta_Cantidad").on('input', function () {
    $.getJSON('/Factura/RevisarStock', { id: $("#prod_Id").val(), cantidad: $("#factdeta_Cantidad").val() })
        .done(function (stock) {
            if (stock == 0) {
                console.log(stock);
                MostrarMensajeWarning('Stock insuficiente');
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.error('Error al cargar los productos: ' + textStatus + ', ' + errorThrown);
        });
})


$("#prod_Id").change(function () {
    var prod_Id = $("#prod_Id").val();

    $.getJSON('/Factura/PrecioProductos', { id: prod_Id })
        .done(function (productos) {
            $.each(productos, function (index, item) {
                $("#factdeta_Precio").val(item.prod_PrecioUni);
                $("#factdeta_PrecioShow").val(item.prod_PrecioUni);
            });
            console.log(productos);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.error('Error al cargar los productos: ' + textStatus + ', ' + errorThrown);
        });

})

//$(document).ajaxComplete(function () {

//});

$("#btnFinalizar").click(function () {

    //if ($("#meto_Id") != "" && $("#clie_Id") != "") {

    //    sessionStorage.setItem("inserta", "jaja");

    //    $("#formCreate").submit();
    //}
});