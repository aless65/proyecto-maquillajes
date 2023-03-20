$(document).ready(function () {
        $('#menuMaquillaje').addClass('active');
        $('#categoriasItem').addClass('active');
        $('#subMenuMaquillaje').addClass('show');
 });


function AbrirModalCreate() {
    $("#lbl_cate_NombreCreateError").attr('hidden', true);
    $("#CrearCategorias").appendTo('body').modal('show');
};

function GuardarModalCreate() {
    var cate_Nombre = $('#cate_Nombre').val();

    $("#lbl_cate_NombreCreateError").attr('hidden', true);

    if (cate_Nombre != "") {
        $("#formCreate").submit();

    } else {
        $("#lbl_cate_NombreCreateError").attr('hidden', false);
    }
}


function eliminar(id) {

    $("#id").val(id);

    $("#modalDelete").appendTo("body").modal('show');

}

function AbrirModalEdit(cadena) {
    var datastring = cadena;
    console.log(datastring);
    var data = datastring.split(',');
    $("#cate_Id_Edit").val(data[0]);
    $("#cate_Nombre_Edit").val(data[1]);
    $("#lbl_cate_NombreEditError").attr('hidden', true);
    $("#EditarCategorias").appendTo('body').modal('show');
};

function GuardarModalEdit() {
    var cate_Nombre = $('#cate_Nombre_Edit').val();

    $("#lbl_cate_NombreEditError").attr('hidden', true);

    if (cate_Nombre != "") {
        $("#formEdit").submit();
    } else {
        $("#lbl_cate_NombreEditError").attr('hidden', false);
    }

}