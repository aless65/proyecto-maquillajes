function eliminar(id, idFactura) {

    $("#id").val(id);

    $("#idFactura").val(idFactura);

    $("#modalDelete").appendTo("body").modal('show');

}