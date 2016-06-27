function onBlurDeInputs(inputId) {
    var input = document.getElementById(inputId);

    regex = new RegExp("^[A-z ,.()0-9]+$");
   
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