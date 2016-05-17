

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
			"    <div class=\"col-sm-11 col-md-11 col-lg-11\">" +
			"        <input type=\"text\" placeholder=\"Requerimiento\" class=\"form-control precondicion\" id=\"precondicion_n\" name=\"precondicion_n\"/>" +
			"    </div>" +
			"    <div class=\"col-sm-1 col-md-1 col-lg-1\">" +
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