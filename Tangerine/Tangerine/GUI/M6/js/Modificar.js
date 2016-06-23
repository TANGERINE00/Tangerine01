
$(document).ready(function () {
    $(".mod_req").on("click", function () {
        var id = $(this).parents().siblings("td:nth-child(1)").html();
        var descripcion = $(this).parents().siblings("td:nth-child(2)").html();
        $(".idreq_input").val(id);
        $(".input_requerimiento").val(descripcion);

    })

    var date = new Date();

    document.getElementById("datepicker1").value = date.toLocaleDateString('en-US');
    document.getElementById("datepicker2").value = date.toLocaleDateString('en-US');

    document.getElementById("datepicker2").readOnly = true;

    if (document.getElementById("formaPago").value == "Mensual") {
        document.getElementById("cantidadCuotas").value = "";
        document.getElementById("cantidadCuotas").readOnly = true;
    }
    else if (document.getElementById("formaPago").value == "Por cuotas") {
        document.getElementById("cantidadCuotas").readOnly = false;
    }

});


function GetRequerimiento(id) {
    var html = $("#" + id).siblings("td").html();
    $("#idreq_input").val(html);

}

function validarTextArea(textArea) {
    var textArea = document.getElementById(textArea);
    var compania = document.getElementById("comboCompañia");

    var regex = new RegExp("^[A-z ,.()]+$");

    var resultado = regex.test(textArea.value);

    if (resultado == false) {
        alert('El texto ingresado en el campo de text es invalido.\n\nPor favor ingrese su descripcion de nuevo.');
        textArea.value = "";
        textArea.style.borderColor = "red";
    }
    else {
        textArea.style.borderColor = "#ccc";
    }

    if (compania.value == "Selecione un cliente") {
        alert('Seleccione una compañía!');
    }
}

function enableDeFechas(s1, date1, date2, input) {
    var s1 = document.getElementById(s1);
    var date1 = document.getElementById(date1);
    var date2 = document.getElementById(date2);
    var input = document.getElementById(input);

    var date = new Date();

    date1.value = date.toLocaleDateString('en-US');
    date2.value = date.toLocaleDateString('en-US');
    input.value = "";

    if (s1.value == "Meses") {
        date2.readOnly = true;
        input.readOnly = false;
    }
    else if (s1.value == "Dias") {
        date2.readOnly = true;
        input.readOnly = false;
    }
    else if (s1.value == "Custom") {
        date2.readOnly = false;
        input.value = "";
        input.readOnly = true;
    }

}

//Cuando se modifica el input de duracion
function setFechas(i1, date1, date2, select1) {
    var i1 = document.getElementById(i1);
    var date1 = document.getElementById(date1);
    var date2 = document.getElementById(date2);
    var select1 = document.getElementById(select1);

    var fechaInicio = new Date(date1.value);
    var fechaFin = new Date();

    var diasASumar = parseInt(i1.value);

    var cambioDeAno = false;

    if (diasASumar > 0) {
        if (select1.value == "Meses") {
            diasASumar = diasASumar * 30;

            fechaFin.setDate(fechaInicio.getDate() + diasASumar);

            date2.value = fechaFin.toLocaleDateString('en-US');
        }
        else if (select1.value == "Dias") {
            fechaFin.setDate(fechaInicio.getDate() + diasASumar);

            date2.value = fechaFin.toLocaleDateString('en-US');
        }
    }
}

//Inhabilitar campo dependiendo de la modalidad
function setCuotas() {
    if (document.getElementById("formaPago").value == "Mensual") {
        document.getElementById("cantidadCuotas").value = "";
        document.getElementById("cantidadCuotas").readOnly = true;
    }
    else if (document.getElementById("formaPago").value == "Por cuotas") {
        document.getElementById("cantidadCuotas").readOnly = false;
    }
}

//Cuando se modifica la Fecha de Inicio
function setFechasMesesYDias() {
    var _fechaInicio = document.getElementById("datepicker1");
    var _fechaFin = document.getElementById("datepicker2");
    var diasASumar = parseInt(document.getElementById("textoDuracion").value);
    var select1 = document.getElementById("comboDuracion");

    var fechaInicio = new Date(_fechaInicio.value);
    var fechaFin = new Date();
    var hoy = new Date();

    //Validacion de fecha inicio "mayor" o "igual" a HOY.
    if (fechaInicio < hoy) {
        _fechaInicio.value = hoy.toLocaleDateString('en-US');
    }

    //Validar que exista una duracion para poder empezar a validar
    if (diasASumar > 0) {
        if (select1.value == "Meses") {
            diasASumar = diasASumar * 30;

            fechaFin.setDate(fechaInicio.getDate() + diasASumar);

            _fechaFin.value = fechaFin.toLocaleDateString('en-US');
        }
        else if (select1.value == "Dias") {
            fechaFin.setDate(fechaInicio.getDate() + diasASumar);

            _fechaFin.value = fechaFin.toLocaleDateString('en-US');
        }
    }
        //Validaciones en caso de que la modalidad sea Custom
    else if (select1.value == "Custom") {
        var fechaAux = new Date(_fechaFin.value);

        //Validacion de fecha de inicio sea "menor" a la fecha de fin.
        if (fechaInicio > fechaAux) {
            _fechaFin.value = _fechaInicio.value;
        }

        //Validacion de fecha de fin "mayor" a la fecha de inicio.
        if (fechaFin < fechaAux) {
            _fechaFin.value = _fechaInicio.value;
        }
    }
    else {
        _fechaInicio.value = hoy.toLocaleDateString('en-US');
    }
}

//Cuando se modifica la Fecha de Fin
function setFechasCustom() {
    var _fechaInicio = document.getElementById("datepicker1");
    var _fechaFin = document.getElementById("datepicker2");

    var fechaInicio = new Date(_fechaInicio.value);
    var fechaFin = new Date();
    var fechaAux = new Date(_fechaFin.value);

    //Validacion de que la fecha de inicio sea "menor" a la fecha de fin.
    if (fechaInicio > fechaAux) {
        _fechaFin.value = _fechaInicio.value;
    }

}









