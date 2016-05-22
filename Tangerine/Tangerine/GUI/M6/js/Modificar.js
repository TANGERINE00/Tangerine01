
$(document).ready(function () {
    $(".mod_req").on("click", function () {
        var id = $(this).parents().siblings("td:nth-child(1)").html();
        var descripcion = $(this).parents().siblings("td:nth-child(2)").html();
        $(".idreq_input").val(id);
        $(".input_requerimiento").val(descripcion);

    })

});



function GetRequerimiento(id) {
    var html = $("#" + id).siblings("td").html();
    $("#idreq_input").val(html);

}


///Metodo para habilitar el boton modificar cuando se escriba algo en el textArea
//$(document).ready(function () {
   
//    $('input[type="submit"]').attr('disabled', 'disabled');  
//    $('input[type="text"]').keypress(function () {       
//        if ($(this).val() != '') {         
//            $('input[type="submit"]').removeAttr('disabled');        
//        }    
//    });
//});








