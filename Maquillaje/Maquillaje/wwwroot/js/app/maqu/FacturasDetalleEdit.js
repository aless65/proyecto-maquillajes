function AbrirModalEdit(cadena) {
    var datastring = cadena;
    console.log(datastring);
    var data = datastring.split(',');
    $("#factdeta_IdEdit").val(data[0]);
    $("#prodIdEditar").val(data[1]);
    $("#factdeta_CantidadEditar").val(data[2]);
    $("#cateEditar").val(data[3]);
    $("#fact_IdEdit").val(data[4]);
    $("#prod_IdEditError").attr('hidden', true);
    $("#factdeta_CantidadEditError").attr('hidden', true);
    $("#EditarDetalles").appendTo('body').modal('show');

    $.getJSON('/Factura/CargarProductos', { id: data[3] })
        .done(function (productos) {
            var productosSelect = $('#prodIdEditar');
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

            $("#prodIdEditar").val(data[1]);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.error('Error al cargar los productos: ' + textStatus + ', ' + errorThrown);
        });

    //$(document).ajaxComplete(function () {

    //});

    $("#factdeta_CantidadEditar").on('input', function () {
        $.getJSON('/Factura/RevisarStock', { id: $("#prodIdEditar").val(), cantidad: $("#factdeta_CantidadEditar").val() })
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
};

$("#cateEditar").change(function () {

    var cate_Id = $("#cateEditar").val();

    console.log("cambiaste la cate");

    $.getJSON('/Factura/CargarProductos', { id: cate_Id })
        .done(function (productos) {
            var productosSelect = $('#prodIdEditar');
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

function GuardarModalEdit() {
    var producto = $('#prodIdEditar').val();
    var cantidad = $('#factdeta_CantidadEditar').val();

    $("#prod_IdEditError").attr('hidden', true);
    $("#factdeta_CantidadEditError").attr('hidden', true);

    if (producto != "") {
        $("#prod_IdEditError").attr('hidden', true);
    } else {
        $("#prod_IdEditError").attr('hidden', false);
    }

    if (cantidad != "") {
        $("#factdeta_CantidadEditError").attr('hidden', true);
    } else {
        $("#factdeta_CantidadEditError").attr('hidden', false);
    }

    if (producto != "" && cantidad != "") {
        $.getJSON('/Factura/RevisarStock', { id: $("#prodIdEditar").val(), cantidad: $("#factdeta_CantidadEditar").val() })
            .done(function (stock) {
                if (stock == 0) {
                    MostrarMensajeWarning('Stock insuficiente');
                } else {
                    $("#formEdit").submit();
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.error('Error al cargar los productos: ' + textStatus + ', ' + errorThrown);
            });
    }
}