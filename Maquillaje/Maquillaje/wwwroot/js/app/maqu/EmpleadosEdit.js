$(document).ready(function () {
    $('#menuMaquillaje').addClass('active');
    $('#empleadosItem').addClass('active');
    $('#subMenuMaquillaje').addClass('show');


    var empe_Id = $("#empe_Id").val();

    console.log(sessionStorage.getItem('contarCargas'));

    if (sessionStorage.getItem('contarCargas') == null) {

        $.getJSON('/Empleado/CargarMunicipiosEmpleado', { id: empe_Id })

            .done(function (municipios) {

                var municipiosSelect = $('#muni_Id');
                municipiosSelect.empty();
                $.each(municipios, function (index, item) {
                    $("#depa_Id").val(item.depa_Id);
                    console.log("seleccionar depa");

                    $.getJSON('/Empleado/CargarMunicipios', { id: item.depa_Id })
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

                            $.getJSON('/Empleado/CargarMunicipiosEmpleado', { id: empe_Id })
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

        $.getJSON('/Empleado/CargarMunicipios', { id: sessionStorage.getItem('depId') })
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
    $.getJSON('/Empleado/CargarMunicipios', { id: departamentoId })
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