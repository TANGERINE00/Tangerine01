
$(document).ready(function () {
    
    var date = new Date();

    document.getElementById("datepicker1").value = date.toLocaleDateString('en-US');
    document.getElementById("datepicker2").value = date.toLocaleDateString('en-US');

    document.getElementById("datepicker2").readOnly = true;

    if (document.getElementById("formaPago").value == "Mensual") {
        document.getElementById("cantidadCuotas").value = "";
        document.getElementById("cantidadCuotas").readOnly = true;
    }
    else if (document.getElementById("formaPago").value == "Por cuotas")
    {
        document.getElementById("cantidadCuotas").readOnly = false;
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
			"        <input type=\"text\" placeholder=\"Requerimiento\" class=\"form-control precondicion\" id=\"precondicion_n\" name=\"precondicion_n\"/>" +
			"    </div>" +
			"    <div class=\"col-sm-1 col-md-1 col-lg-1\" style=\"margin-left:-20px;\" >" +
			"        <button type=\"button\" class=\"btn btn-default btn-circle glyphicon glyphicon-plus\" onclick=\"agregarPrecondicion()\"></button>" +
			"    </div>" +
			"</div>";
    $("#div-precondiciones").append(codigo);
    actualizarIdPrecondiciones();

    //var reach_array = $('#div-precondiciones').find('input');
    //console.log(reach_array.length);
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
        date2.readOnly = true;
        input.readOnly = false;
    }
    else if (s1.value == "Dias")
    {
        date2.readOnly = true;
        input.readOnly = false;
    }
    else if (s1.value == "Custom")
    {
        date2.readOnly = false;
        input.value = "";
        input.readOnly = true;
    }

}

function setFechas(i1, date1, date2, select1)
{
    var i1 = document.getElementById(i1);
    var date1 = document.getElementById(date1);
    var date2 = document.getElementById(date2);
    var select1 = document.getElementById(select1);

    var fechaInicio = new Date(date1.value);
    var fechaFin = new Date();

    var diasASumar = parseInt(i1.value);

    if (diasASumar > 0)
    {
        if (select1.value == "Meses") {
            var mes = fechaInicio.getMonth() + 1 + diasASumar;
            var texto = mes + "/" + fechaInicio.getDate() + "/" + fechaInicio.getFullYear();
            date2.value = texto;
        }
        else if (select1.value == "Dias") {
            var dia = fechaInicio.getDate() + diasASumar;
            var texto = fechaInicio.getMonth() + 1 + "/" + dia + "/" + fechaInicio.getFullYear();
            date2.value = texto;
        }
    }
}

function setCuotas()
{
    if (document.getElementById("formaPago").value == "Mensual") {
        document.getElementById("cantidadCuotas").value = "";
        document.getElementById("cantidadCuotas").readOnly = true;
    }
    else if (document.getElementById("formaPago").value == "Por cuotas") {
        document.getElementById("cantidadCuotas").readOnly = false;
    }
}

function setFechasMesesYDias()
{
    var _fechaInicio = document.getElementById("datepicker1");
    var _fechaFin = document.getElementById("datepicker2");
    var diasASumar = parseInt(document.getElementById("textoDuracion").value);
    var select1 = document.getElementById("comboDuracion");

    var fechaInicio = new Date(_fechaInicio.value);
    var fechaFin = new Date();

    if (diasASumar > 0)
    {
        if (select1.value == "Meses")
        {
            var mes = fechaInicio.getMonth() + 1 + diasASumar;
            var texto = mes + "/" + fechaInicio.getDate() + "/" + fechaInicio.getFullYear();
            _fechaFin.value = texto;
        }
        else if (select1.value == "Dias")
        {
            var dia = fechaInicio.getDate() + diasASumar;
            var texto = fechaInicio.getMonth() + 1 + "/" + dia + "/" + fechaInicio.getFullYear();
            _fechaFin.value = texto;
        }
    }
    else if (select1.value == "Custom")
    {
        var fechaAux = new Date(_fechaFin.value);

        var diaInicio = fechaInicio.getDate();
        var diaFin = fechaAux.getDate();
        var mesInicio = fechaInicio.getMonth() + 1;
        var mesFin = fechaAux.getMonth() + 1;
        var anoInicio = fechaInicio.getFullYear();
        var anoFin = fechaAux.getFullYear();

        if (anoInicio <= anoFin)
        {
            if (mesInicio <= mesFin)
            {
                if (diaInicio <= diaFin)
                {
                    //
                }
            }
            else
            {
                _fechaFin.value = _fechaInicio.value;
            }
        }
        else
        {
            _fechaFin.value = _fechaInicio.value;
        }

    }
}

function setFechasCustom()
{
    var _fechaInicio = document.getElementById("datepicker1");
    var _fechaFin = document.getElementById("datepicker2");

    var fechaInicio = new Date(_fechaInicio.value);
    var fechaFin = new Date();

    var fechaAux = new Date(_fechaFin.value);

    var diaInicio = fechaInicio.getDate();
    var diaFin = fechaAux.getDate();
    var mesInicio = fechaInicio.getMonth() + 1;
    var mesFin = fechaAux.getMonth() + 1;
    var anoInicio = fechaInicio.getFullYear();
    var anoFin = fechaAux.getFullYear();

    if (anoInicio <= anoFin)
    {
        if (mesInicio <= mesFin)
        {
            if (diaInicio <= diaFin)
            {
                //
            }
            else
            {
                _fechaFin.value = _fechaInicio.value;
            }
        }
        else
        {
            _fechaFin.value = _fechaInicio.value;
        }
    }
    else
    {
        _fechaFin.value = _fechaInicio.value;
    }

}
