sessionStorage.clear();

$(document).ready(function () {
    $('#menuMaquillaje').addClass('active');
    $('#clientesItem').addClass('active');
    $('#subMenuMaquillaje').addClass('show');
});

function eliminar(id) {

    $("#id").val(id);

    $("#modalEditar").appendTo("body").modal('show');

}

$('#clie_Identidad').on('input', function () {
    var c = this.selectionStart,
        r = /[^0-9]/gi,
        v = $(this).val();
    if (r.test(v)) {
        $(this).val(v.replace(r, ''));
        c--;
    }
    this.setSelectionRange(c, c);
});

$("#btnGuardar").click(function () {
    sessionStorage.setItem('contarCargas', "hola");

    console.log(sessionStorage.getItem('contarCargas'));
});

$(window).bind('beforeunload', function () {
    sessionStorage.setItem('contarCargas', "hola");

    sessionStorage.setItem('depId', $("#depa_Id").val());
    sessionStorage.setItem('muniId', $("#muni_Id").val());
});

$(document).ready(function () {
    $('#menuMaquillaje').addClass('active');
    $('#clientesItem').addClass('active');
    $('#subMenuMaquillaje').addClass('show');


    var clie_Id = $("#clie_Id").val();

    console.log(sessionStorage.getItem('contarCargas'));

    if (sessionStorage.getItem('contarCargas') == null) {

        $.getJSON('/Cliente/CargarMunicipiosCliente', { id: clie_Id })

            .done(function (municipios) {

                var municipiosSelect = $('#muni_Id');
                municipiosSelect.empty();
                $.each(municipios, function (index, item) {
                    $("#depa_Id").val(item.depa_Id);
                    console.log("seleccionar depa");

                    $.getJSON('/Cliente/CargarMunicipios', { id: item.depa_Id })
                        .done(function (municipios) {
                            $("#muni_Id").prop("disabled", false);
                            var municipiosSelect = $('#muni_Id');
                            municipiosSelect.empty();
                            municipiosSelect.append($('<option>', {
                                value: '',
                                text: '--Selecciona un municipio--'
                            }));
                            $.each(municipios, function (index, item) {
                                municipiosSelect.append($('<option>', {
                                    value: item.muni_id,
                                    text: item.muni_Nombre
                                }));
                            });
                            console.log("cargar muni");

                            $.getJSON('/Cliente/CargarMunicipiosCliente', { id: clie_Id })
                                .done(function (municipios) {
                                    $.each(municipios, function (index, item) {
                                        $("#muni_Id").val(item.muni_id);
                                        console.log("seleccionar muni");
                                        console.log(item.muni_id);
                                    });
                                })
                                .fail(function (jqXHR, textStatus, errorThrown) {
                                    console.error('Error al cargar los municipios: ' + textStatus + ', ' + errorThrown);
                                });
                        })
                        .fail(function (jqXHR, textStatus, errorThrown) {
                            console.error('Error al cargar los municipios: ' + textStatus + ', ' + errorThrown);
                        });
                });
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.error('Error al cargar los municipios: ' + textStatus + ', ' + errorThrown);
            });
    } else {
        $("#depa_Id").val(sessionStorage.getItem('depId'));
        $.getJSON('/Cliente/CargarMunicipios', { id: sessionStorage.getItem('depId') })
            .done(function (municipios) {
                $("#muni_Id").prop("disabled", false);
                var municipiosSelect = $('#muni_Id');
                municipiosSelect.empty();
                municipiosSelect.append($('<option>', {
                    value: '',
                    text: '--Selecciona un municipio--'
                }));
                $.each(municipios, function (index, item) {
                    municipiosSelect.append($('<option>', {
                        value: item.muni_id,
                        text: item.muni_Nombre
                    }));
                    console.log(item.muni_Id)
                });

                $("#muni_Id").val(sessionStorage.getItem('muniId'));
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.error('Error al cargar los municipios: ' + textStatus + ', ' + errorThrown);
            });
    }

});

$('#depa_Id').change(function () {
    var departamentoId = $("#depa_Id").val();
    $.getJSON('/Cliente/CargarMunicipios', { id: departamentoId })
        .done(function (municipios) {
            $("#muni_Id").prop("disabled", false);
            var municipiosSelect = $('#muni_Id');
            municipiosSelect.empty();
            municipiosSelect.append($('<option>', {
                value: '',
                text: '--Selecciona un municipio--'
            }));
            $.each(municipios, function (index, item) {
                municipiosSelect.append($('<option>', {
                    value: item.muni_id,
                    text: item.muni_Nombre
                }));
                console.log(item.muni_Id)
            });
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.error('Error al cargar los municipios: ' + textStatus + ', ' + errorThrown);
        });
});


$('#clie_Identidad').on('input', function () {
    var c = this.selectionStart,
        r = /[^0-9]/gi,
        v = $(this).val();
    if (r.test(v)) {
        $(this).val(v.replace(r, ''));
        c--;
    }
    this.setSelectionRange(c, c);
});

$("#btnGuardar").click(function () {
    sessionStorage.setItem('contarCargas', "hola");

    console.log(sessionStorage.getItem('contarCargas'));
});

$(window).bind('beforeunload', function () {
    sessionStorage.setItem('contarCargas', "hola");
    sessionStorage.setItem('depId', $("#depa_Id").val());
    sessionStorage.setItem('muniId', $("#muni_Id").val());
});

$(document).ready(function () {
    $('#menuMaquillaje').addClass('active');
    $('#clientesItem').addClass('active');
    $('#subMenuMaquillaje').addClass('show');

    var clie_Id = $("#clie_Id").val();


    if (sessionStorage.getItem('contarCargas') == null) {

        $.getJSON('/Cliente/CargarMunicipiosCliente', { id: clie_Id })

            .done(function (municipios) {

                var municipiosSelect = $('#muni_Id');
                municipiosSelect.empty();
                $.each(municipios, function (index, item) {
                    $("#depa_Id").val(item.depa_Id);
                    console.log("seleccionar depa");

                    $.getJSON('/Cliente/CargarMunicipios', { id: item.depa_Id })
                        .done(function (municipios) {
                            $("#muni_Id").prop("disabled", false);
                            var municipiosSelect = $('#muni_Id');
                            municipiosSelect.empty();
                            municipiosSelect.append($('<option>', {
                                value: '',
                                text: '--Selecciona un municipio--'
                            }));
                            $.each(municipios, function (index, item) {
                                municipiosSelect.append($('<option>', {
                                    value: item.muni_id,
                                    text: item.muni_Nombre
                                }));
                            });
                            console.log("cargar muni");

                            $.getJSON('/Cliente/CargarMunicipiosCliente', { id: clie_Id })
                                .done(function (municipios) {
                                    $.each(municipios, function (index, item) {
                                        $("#muni_Id").val(item.muni_id);
                                        console.log("seleccionar muni");
                                        console.log(item.muni_id);
                                    });
                                })
                                .fail(function (jqXHR, textStatus, errorThrown) {
                                    console.error('Error al cargar los municipios: ' + textStatus + ', ' + errorThrown);
                                });
                        })
                        .fail(function (jqXHR, textStatus, errorThrown) {
                            console.error('Error al cargar los municipios: ' + textStatus + ', ' + errorThrown);
                        });
                });
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.error('Error al cargar los municipios: ' + textStatus + ', ' + errorThrown);
            });
    } else {
        $("#depa_Id").val(sessionStorage.getItem('depId'));

        $.getJSON('/Cliente/CargarMunicipios', { id: sessionStorage.getItem('depId') })
            .done(function (municipios) {
                $("#muni_Id").prop("disabled", false);
                var municipiosSelect = $('#muni_Id');
                municipiosSelect.empty();
                municipiosSelect.append($('<option>', {
                    value: '',
                    text: '--Selecciona un municipio--'
                }));
                $.each(municipios, function (index, item) {
                    municipiosSelect.append($('<option>', {
                        value: item.muni_id,
                        text: item.muni_Nombre
                    }));
                    console.log(item.muni_Id);
                    console.log("municipios luego de segunda carga");
                });

                $("#muni_Id").val(sessionStorage.getItem('muniId'));
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.error('Error al cargar los municipios: ' + textStatus + ', ' + errorThrown);
            });
    }
});

$('#depa_Id').change(function () {
    var departamentoId = $("#depa_Id").val();
    $.getJSON('/Cliente/CargarMunicipios', { id: departamentoId })
        .done(function (municipios) {
            $("#muni_Id").prop("disabled", false);
            var municipiosSelect = $('#muni_Id');
            municipiosSelect.empty();
            municipiosSelect.append($('<option>', {
                value: '',
                text: '--Selecciona un municipio--'
            }));
            $.each(municipios, function (index, item) {
                municipiosSelect.append($('<option>', {
                    value: item.muni_id,
                    text: item.muni_Nombre
                }));
                console.log(item.muni_Id)
            });
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.error('Error al cargar los municipios: ' + textStatus + ', ' + errorThrown);
        });
});