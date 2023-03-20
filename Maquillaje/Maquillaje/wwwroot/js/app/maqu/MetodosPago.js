$(document).ready(function () {
    $('#menuMaquillaje').addClass('active');
    $('#metodosItem').addClass('active');
    $('#subMenuMaquillaje').addClass('show');
});

function AbrirModalEdit(cadena) {
    var datastring = cadena;
    console.log(datastring);
    var data = datastring.split(',');
    $("#meto_Id_Edit").val(data[0]);
    $("#meto_Nombre_Edit").val(data[1]);
    $("#lbl_meto_NombreEditError").attr('hidden', true);
    $("#EditarMetodos").appendTo('body').modal('show');

};

function GuardarModalEdit() {
    var meto_Nombre = $('#meto_Nombre_Edit').val();

    $("#lbl_meto_NombreEditError").attr('hidden', true);

    if (meto_Nombre != "") {
        $("#formEdit").submit();
        console.log("Mi loco no esta vacio")
    } else {
        $("#lbl_meto_NombreEditError").attr('hidden', false);
        console.log("Mi loco si esta vacio")
    }

}

function eliminar(id) {

    $("#id").val(id);

    $("#modalDelete").appendTo("body").modal('show');

}

function AbrirModalCreate() {
    $("#lbl_meto_NombreCreateError").attr('hidden', true);
    $("#CrearMetodos").appendTo('body').modal('show');
};

function GuardarModalCreate() {
    var meto_Nombre = $('#meto_Nombre').val();

    $("#lbl_meto_NombreCreateError").attr('hidden', true);

    if (meto_Nombre != "") {
        $("#formCreate").submit();

    } else {
        $("#lbl_meto_NombreCreateError").attr('hidden', false);
    }
}