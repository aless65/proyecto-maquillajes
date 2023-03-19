function MostrarMensajeSuccess(bodymessage) {
    toastr.success(bodymessage, "Exitoso")
}

function MostrarMensajeWarning(bodymessage) {
    toastr.warning(bodymessage, "Advertencia")
}

function MostrarMensajeDanger(bodymessage) {
    toastr.danger(bodymessage, "Error")
}

function MostrarMensajeInfo(bodymessage) {
    toastr.info(bodymessage, "Info")
}

toastr.options = {
    closeButton: true,
    progressBar: true
}