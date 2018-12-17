function mostrarError(elemento, hayError) {
    if (hayError) {
        elemento.parent().addClass("has-error");
    } else {
        elemento.parent().removeClass("has-error");
    }
}

function validacionTexto(elemento) {
    let error = false;
    if (elemento.val() == "" || /[^A-Za-z\u00e1\u00e9\u00ed\u00f3\u00fa\u00c1\u00c9\u00cd\u00d3\u00da\u00f1\u00d1\u00FC\u00DC\']\s/.test(elemento.val()) == true) {
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

    $(".btnNuevoUsuario").on("click", function (event) {
        event.preventDefault();
        let error = false;
        let form = $("#formNuevoUsuario");
        let nombre = $("#formNuevoUsuario #nombre");
        let apellido = $("#formNuevoUsuario #apellido");
        let email = $("#formNuevoUsuario #email");
        let tipoDoc = $("#formNuevoUsuario #tipoDoc");
        let nroDoc = $("#formNuevoUsuario #nroDoc");

        if (validacionTexto(nombre)) {
            mostrarError(nombre, true);
            error = true;
        } else {
            mostrarError(nombre, false);
        }

        if (validacionTexto(apellido)) {
            mostrarError(apellido, true);
            error = true;
        } else {
            mostrarError(apellido, false);
        }

        if (validacionEmail(email)) {
            mostrarError(email, true);
            error = true;
        } else {
            mostrarError(email, false);
        }

        if (validacionCombo(tipoDoc)) {
            mostrarError(tipoDoc, true);
            error = true;
        } else {
            mostrarError(tipoDoc, false);
        }

        if (validacionNumerica(nroDoc) || nroDoc.val().length < 8) {
            mostrarError(nroDoc, true);
            error = true;
        } else {
            mostrarError(nroDoc, false);
        }

        if (!error) {
            form.submit();
        }
    });

    $(".btnBuscadorPorDoc").on("click", function (event) {
        event.preventDefault();
        let error = false;
        let form = $(".formBuscadorPorDoc");
        let nroDoc = $(".formBuscadorPorDoc #nroDoc");

        if (validacionNumerica(nroDoc)) {
            mostrarError(nroDoc, true);
            error = true;
        } else {
            mostrarError(nroDoc, false);
        }

        if (!error) {
            form.submit();
        }
    });

    $(".btnNuevoLibro").on("click", function (event) {
        event.preventDefault();
        let error = false;
        let form = $("#formNuevoLibro");
        let titulo = $("#formNuevoLibro #titulo");
        let autor = $("#formNuevoLibro #autor");
        let isbn = $("#formNuevoLibro #isbn");
        let genero = $("#formNuevoLibro #genero");
        let ejemplares = $("#formNuevoLibro #ejemplares");

        if (validacionTexto(titulo)) {
            mostrarError(titulo, true);
            error = true;
        } else {
            mostrarError(titulo, false);
        }
        if (validacionTexto(autor)) {
            mostrarError(autor, true);
            error = true;
        } else {
            mostrarError(autor, false);
        }
        if (validacionVacio(isbn)) {
            mostrarError(isbn, true);
            error = true;
        } else {
            mostrarError(isbn, false);
        }
        if (validacionTexto(genero)) {
            mostrarError(genero, true);
            error = true;
        } else {
            mostrarError(genero, false);
        }
        if (validacionNumerica(ejemplares) || ejemplares.val() <1) {
            mostrarError(ejemplares, true);
            error = true;
        } else {
            mostrarError(ejemplares, false);
        }

        if (!error) {
            form.submit();
        }
    });

    $(".btnBuscadorPorTitulo").on("click", function (event) {
        event.preventDefault();
        let error = false;
        let form = $(".formBuscadorPorTitulo");
        let titulo = $(".formBuscadorPorTitulo #titulo");
        if (validacionTexto(titulo)) {
            mostrarError(titulo, true);
            error = true;
        } else {
            mostrarError(titulo, false);
        }
        if (!error) {
            form.submit();
        }
    });

    $("#btnNuevoPrestamo").on("click", function (event) {
        event.preventDefault();
        let error = false;
        let form = $("#formNuevoPrestamo");
        let nroDocUsuario = $("#formNuevoPrestamo #nroDocUsuario");
        let isbnLibro = $("#formNuevoPrestamo #isbnLibro");
        let ejemplares = $("#formNuevoPrestamo #ejemplares");
        let fechaPrestamo = $("#formNuevoPrestamo #fechaPrestamo");

        if (validacionCombo(nroDocUsuario)) {
            mostrarError(nroDocUsuario, true);
            error = true;
        } else {
            mostrarError(nroDocUsuario, false);
        }
        if (validacionCombo(isbnLibro)) {
            mostrarError(isbnLibro, true);
            error = true;
        } else {
            mostrarError(isbnLibro, false);
        }
        if (validacionNumerica(ejemplares) || ejemplares.val() < 1) {
            mostrarError(ejemplares, true);
            error = true;
        } else {
            mostrarError(ejemplares, false);
        }
        if (validacionFecha(fechaPrestamo)) {
            mostrarError(fechaPrestamo, true);
            error = true;
        } else {
            mostrarError(fechaPrestamo, false);
        }
        if (!error) {
            form.submit();
        }
    });


});