$(document).ready(function () {
    $("#errorLogin").hide();
    $("#myWish").click(function showAlert() {
        $("#errorLogin").alert();
        $("#errorLogin").fadeTo(2000, 500).slideUp(500, function () {
            $("#errorLogin").alert('close');
        });
    });
});
