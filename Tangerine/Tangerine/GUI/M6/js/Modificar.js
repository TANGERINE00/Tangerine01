
$(document).ready(function () {
    $(".mod_req").on("click", function () {
        var id = $(this).parents().siblings("td:nth-child(1)").html();
        var descripcion = $(this).parents().siblings("td:nth-child(2)").html();
        $(".idreq_input").val(id);
        $(".input_requerimiento").val(descripcion);

    })

});

//La fecha viene en formato dd/mm/yyyy, se cambia a mm/dd//yyyy para que sirva.
$(window).load(function () {

    var fechaInicio = document.getElementById("datepicker1");
    var fechaFin = document.getElementById("datepicker2");
    var s1 = document.getElementById("comboDuracion");
    var input = document.getElementById("textoDuracion");

    //Set fechas en formato MM/dd/yyyy
    var res = fechaInicio.value.split("/");
    var newDate = res[1] + "/" + res[0] + "/" + res[2];
    fechaInicio.value = newDate;

    var res = fechaFin.value.split("/");
    var newDate = res[1] + "/" + res[0] + "/" + res[2];
    fechaFin.value = newDate;

    //Set forma de pago
    if (document.getElementById("formaPago").value == "Mensual") {
        document.getElementById("cantidadCuotas").value = "";
        document.getElementById("cantidadCuotas").disabled = true;
    }
    else if (document.getElementById("formaPago").value == "Por cuotas") {
        document.getElementById("cantidadCuotas").disabled = false;
    }

    //Set datepickers
    if (s1.value == "Meses") {
        fechaFin.disabled = true;
        input.disabled = false;
    }
    else if (s1.value == "Dias") {
        fechaFin.disabled = true;
        input.disabled = false;
    }
    else if (s1.value == "Custom") {
        fechaFin.disabled = false;
        input.value = "";
        input.disabled = true;
    }

});


function GetRequerimiento(id) {
    var html = $("#" + id).siblings("td").html();
    $("#idreq_input").val(html);

}

function validarTextArea(textArea) {
    var textArea = document.getElementById(textArea);
    var compania = document.getElementById("comboCompañia");

    var regex = new RegExp("^[A-z ,.()0-9]+$");

    var resultado = regex.test(textArea.value);

    if (resultado == false && textArea.value != "") {
        alert('El texto ingresado en el campo de text es invalido.\n\nPor favor ingrese su descripcion de nuevo.');
        textArea.value = "";
        textArea.style.borderColor = "red";
    }
    else if (resultado == false && textArea.value == "") {
        textArea.style.borderColor = "#ccc";
    }
    else {
        textArea.style.borderColor = "#00FF00"
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
        date2.disabled = true;
        input.disabled = false;
    }
    else if (s1.value == "Dias") {
        date2.disabled = true;
        input.disabled = false;
    }
    else if (s1.value == "Custom") {
        date2.disabled = false;
        input.value = "";
        input.disabled = true;
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
        document.getElementById("cantidadCuotas").disabled = true;
    }
    else if (document.getElementById("formaPago").value == "Por cuotas") {
        document.getElementById("cantidadCuotas").disabled = false;
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

//Ayuda para el Usuario de saber si lo que introdujo es correcto
function onBlurDeInputs(inputId) {
    var input = document.getElementById(inputId);

    var auxParaReq = inputId.split("_");
    var textoId = auxParaReq[1];

    if (inputId == "textoDuracion") {
        regex = new RegExp("^[0-9]{1,3}[ ]{0,1}$");
    } else if (textoId == "textoCosto") {
        regex = new RegExp("^[0-9]{1,10}[ ]{0,1}$");
    } else if (inputId == "cantidadCuotas") {
        regex = new RegExp("^[0-9]{1,2}[ ]{0,1}$");
    }

    var resultado = regex.test(input.value);

    if (resultado == false && input.value != "") {
        input.style.borderColor = "red";
    }
    else if (resultado == false && input.value == "") {
        input.style.borderColor = "#ccc";
    }
    else {
        input.style.borderColor = "#00FF00"
    }

}


//Habilitar lectura de campos para modificar
function activarLectura()
{
    document.getElementById("datepicker2").disabled = false;
    document.getElementById("datepicker2").readOnly = true;

    document.getElementById("cantidadCuotas").disabled = false;
    document.getElementById("cantidadCuotas").readOnly = true;

    document.getElementById("textoDuracion").disabled = false;
    document.getElementById("textoDuracion").readOnly = true;
}





