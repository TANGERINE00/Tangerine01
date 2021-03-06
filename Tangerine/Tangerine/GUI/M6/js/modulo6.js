﻿
$(document).ready(function () {
    
    var date = new Date();

    document.getElementById("datepicker1").value = date.toLocaleDateString('en-US');
    document.getElementById("datepicker2").value = date.toLocaleDateString('en-US');

    document.getElementById("datepicker2").disabled = true;

    if (document.getElementById("formaPago").value == "Mensual") {
        document.getElementById("cantidadCuotas").value = "";
        document.getElementById("cantidadCuotas").disabled = true;
    }
    else if (document.getElementById("formaPago").value == "Por cuotas")
    {
        document.getElementById("cantidadCuotas").disabled = false;
    }
});

function actualizarIdPrecondiciones() {
    escenarios = $("[id^=precondicion_]");
    for (i = 0; i < escenarios.length; i++) {
        escenario = escenarios[i];
        escenario.id = "precondicion_" + i;
        escenario.name = "precondicion_" + i;
    }
}

function agregarPrecondicion() {
    child = document.getElementById("div-precondiciones").lastElementChild.lastElementChild;
    child.innerHTML = "<button type=\"button\" class=\"btn btn-danger btn-circle glyphicon glyphicon-remove\" onclick=\"eliminarCampo(this)\"></button>";
    codigo = "<div class=\"form-group\">" +
			"    <div class=\"col-sm-11 col-md-11 col-lg-11\" style=\"margin-left:-30px;\"> " +
			"        <input type=\"text\" runat\"server\" placeholder=\"Requerimiento\" class=\"form-control precondicion\" id=\"precondicion_n\" name=\"precondicion_n\" required onblur = \"onBlurDeInputs(this.id)\"" +
            "           oninvalid=\"setCustomValidity('Campo obligatorio, no puede tener numeros ni simbolos')\" oninput=\"setCustomValidity('')\" title=\"Descripcion\" pattern=\"^[A-z ,.()0-9]+$\" />" +
			"    </div>" +
			"    <div class=\"col-sm-1 col-md-1 col-lg-1\" style=\"margin-left:-20px;\" >" +
			"        <button type=\"button\" class=\"btn btn-default btn-circle glyphicon glyphicon-plus\" onclick=\"agregarPrecondicion()\"></button>" +
			"    </div>" +
			"</div>";
    $("#div-precondiciones").append(codigo);
    actualizarIdPrecondiciones();
}

function eliminarCampo(caller) {
    var parent = caller.parentElement.parentElement;
    parent.parentElement.removeChild(parent);
}

function contarElementos() {
    var campos = $("#div-precondiciones").find(".form-control");
    var requerimientos = [];
    for (var i = 0; i < campos.length; i++) {
        requerimientos[i] = campos.eq(i).val();
    }
}

function crearPrecondicionArr() {

    var values = "";
    // escenarios = $("[id^=precondicion_]");
    $('.arrPrecondicion').val("");
    $('.precondicion').each(function () {
        //   alert($(this).val());
        values = values + $(this).val() + ";";
        //   $('#precondicion_arr').val($('#precondicion_arr').val() + ";" + $(this).val());

    });
    
    // alert(values);
    $('.arrPrecondicion').val(values);
    /* for (i = 0; i < escenarios.length; i++) {
         values += escenarios[i].value + ";";
     }*/
    //$('#precondicion_arr').val(values);

    document.getElementById("datepicker2").disabled = false;
    document.getElementById("datepicker2").readOnly = true;

    document.getElementById("cantidadCuotas").disabled = false;
    document.getElementById("cantidadCuotas").readOnly = true;

    document.getElementById("textoDuracion").disabled = false;
    document.getElementById("textoDuracion").readOnly = true;

}

function doSearch() {
    var tableReg = document.getElementById('example2');
    var searchText = document.getElementById('searchTerm').value.toLowerCase();
    for (var i = 1; i < tableReg.rows.length; i++) {
        var cellsOfRow = tableReg.rows[i].getElementsByTagName('td');
        var found = false;
        for (var j = 0; j < cellsOfRow.length && !found; j++) {
            var compareWith = cellsOfRow[j].innerHTML.toLowerCase();
            if (searchText.length == 0 || (compareWith.indexOf(searchText) > -1)) {
                found = true;
            }
        }
        if (found) {
            tableReg.rows[i].style.display = '';
        } else {
            tableReg.rows[i].style.display = 'none';
        }
    }
}

function validarTextArea(textArea)
{
    var textArea = document.getElementById(textArea);
    
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

function enableDeFechas(s1, date1, date2, input)
{
    var s1 = document.getElementById(s1);
    var date1 = document.getElementById(date1);
    var date2 = document.getElementById(date2);
    var input = document.getElementById(input);

    var date = new Date();

    date1.value = date.toLocaleDateString('en-US');
    date2.value = date.toLocaleDateString('en-US');
    input.value = "";

    if (s1.value == "Meses")
    {
        date2.disabled = true;
        input.disabled = false;
    }
    else if (s1.value == "Dias")
    {
        date2.disabled = true;
        input.disabled = false;
    }
    else if (s1.value == "Custom")
    {
        date2.disabled = false;
        input.value = "";
        input.disabled = true;
    }

}

//Cuando se modifica el input de duracion
function setFechas(i1, date1, date2, select1)
{
    var i1 = document.getElementById(i1);
    var date1 = document.getElementById(date1);
    var date2 = document.getElementById(date2);
    var select1 = document.getElementById(select1);

    var fechaInicio = new Date(date1.value);
    var fechaFin = new Date();

    var diasASumar = parseInt(i1.value);

    var cambioDeAno = false;

    if (diasASumar > 0)
    {
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
function setCuotas()
{
    if (document.getElementById("formaPago").value == "Mensual") {
        document.getElementById("cantidadCuotas").value = "";
        document.getElementById("cantidadCuotas").disabled = true;
    }
    else if (document.getElementById("formaPago").value == "Por cuotas") {
        document.getElementById("cantidadCuotas").disabled = false;
    }
}

//Cuando se modifica la Fecha de Inicio
function setFechasMesesYDias()
{
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
        //alert("La fecha de inicio debe ser una fecha mayor o igual a HOY.");
    }

    //Validar que exista una duracion para poder empezar a validar
    if (diasASumar > 0)
    {
        if (select1.value == "Meses")
        {
            diasASumar = diasASumar * 30;

            fechaFin.setDate(fechaInicio.getDate() + diasASumar);

            _fechaFin.value = fechaFin.toLocaleDateString('en-US');
        }
        else if (select1.value == "Dias")
        {
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
            //alert("La fecha de inicio indicada es MAYOR a la fecha de fin\npor favor vuelva a seleccionar las fechas.");
        } 

        //Validacion de fecha de fin "mayor" a la fecha de inicio.
        if (fechaFin < fechaAux) {
            _fechaFin.value = _fechaInicio.value;
            //alert("La fecha de fin indicada es MENOR a la fecha de inicio\npor favor vuelva a seleccionar las fechas.");
        }
    }
    else {
        _fechaInicio.value = hoy.toLocaleDateString('en-US');
        //alert("Por favor indique una duracion.");
    } 
}

//Cuando se modifica la Fecha de Fin
function setFechasCustom()
{
    var _fechaInicio = document.getElementById("datepicker1");
    var _fechaFin = document.getElementById("datepicker2");

    var fechaInicio = new Date(_fechaInicio.value);
    var fechaFin = new Date();
    var fechaAux = new Date(_fechaFin.value);

    //Validacion de que la fecha de inicio sea "menor" a la fecha de fin.
    if (fechaInicio > fechaAux) {
        _fechaFin.value = _fechaInicio.value;
        //alert("La fecha de fin indicada es MENOR a la fecha de inicio\npor favor vuelva a seleccionar las fechas.");
    } 
}

//Ayuda para el Usuario de saber si lo que introdujo es correcto
function onBlurDeInputs(inputId) {
    var input = document.getElementById(inputId);

    var auxParaReq = inputId.split("_");
    var textoId = auxParaReq[1];

    if (textoId == "precondicion") {
        regex = new RegExp("^[A-z ,.()0-9]+$");
    } else if (inputId == "textoDuracion") {
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