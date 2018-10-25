function mostrarError(elemento, hayError) {
    if (hayError) {
        elemento.parent().addClass("has-error");
    } else {
        elemento.parent().removeClass("has-error");
    }
}

function validacionTexto(elemento) {
    let error = false;
    if (elemento.val() == "" || /[^A-Za-z\u00e1\u00e9\u00ed\u00f3\u00fa\u00c1\u00c9\u00cd\u00d3\u00da\u00f1\u00d1\u00FC\u00DC\' ]/.test(elemento.val()) == true) {
        error = true;
    }
    return error;
}

function validacionEmail(e) {
    let error = false;
    if (/^[0-9a-z_\-\.]+@[0-9a-z\-\.]+\.[a-z]{2,4}$/i.test(e.val()) == false) {
        error = true;
    }
    return error;
}

function validacionNumerica(e) {
    let error = false;
    if (e.val() == "" || /^[0-9]+$/.test(e.val()) == false) {
        error = true;
    }
    return error;
}

function validacionCombo(e) {
    let error = false;
    if (e.val() == 0) {
        error = true;
    }
    return error;
}

function validacionVacio(e) {
    let error = false;
    if (e.val() == "") {
        error = true;
    }
    return error;
}

function validacionFecha(e) {
    let error = false;
    if (e.val() == "" || /^(\d{1,2})\/(\d{1,2})\/(\d{4})$/.test(e.val()) == false) {
        error = true;
    }
    return error;
}

$(document).ready(function () {
    //modal
    $("#btnNuevoUsuario").on("click", function (event) {
        event.preventDefault();
        $('#modalNuevoUsuario').modal('show');
    });

    $("#btnNuevoLibro").on("click", function (event) {
        event.preventDefault();
        $('#modalNuevoLibro').modal('show');
    });

    $("#btnNuevoPrestamo").on("click", function (event) {
        event.preventDefault();
        $('#modalNuevoPrestamo').modal('show');
    });

    // validaciones
    $(".validacion-texto").on("blur keyup", function (event) {
        event.preventDefault();
        mostrarError($(this), validacionTexto($(this)));
    });

    $(".validacion-email").on("blur keyup", function (event) {
        event.preventDefault();
        mostrarError($(this), validacionEmail($(this)));
    });

    $(".validacion-numerica").on("blur keyup", function (event) {
        event.preventDefault();
        mostrarError($(this), validacionNumerica($(this)));
    });

    $(".validacion-combo").on("blur keyup", function (event) {
        event.preventDefault();
        mostrarError($(this), validacionCombo($(this)));
    });

    $(".validacion-vacio").on("blur keyup", function (event) {
        event.preventDefault();
        mostrarError($(this), validacionVacio($(this)));
    });

    $(".validacion-fecha").on("blur keyup", function (event) {
        event.preventDefault();
        mostrarError($(this), validacionFecha($(this)));
    });

    $("#btnSubmitNuevoUsuario").on("click", function (event) {
        event.preventDefault();
        if (validacionTexto($("#formNuevoUsuario>#nombre"))) {
            $(this).submit();
        } else {
            console.log("falla");
        }
    });
});