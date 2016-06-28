<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContraseñaPregunta.aspx.cs" Inherits="Tangerine.GUI.M1.RecuperarContraseñaPregunta" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Tangerine - Inicio de Sesión</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="../../bootstrap/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="../../plugins/iCheck/square/blue.css">
    <link href="css/Estilos.css" rel="stylesheet" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <div id="login-main">
        <div class="container login-main">
            <div class="user-img">
                <img src="/dist/img/tange.png" class="img-circle user-img img-thumbnail" alt="">
            </div>
            <div class="login-logo">
                <span style="color:white; text-shadow:0 0 5px #333" ><b>Tangerine</b> SYSTEM </span>  
            </div>

            <div class="col-md-4 login-form">
                <p class="login-box-msg" style="color: #FFFFFF">Introduzca su correo personal y usuario</p>
               
            </div>



            <div class="col-md-4 login-form">


                <form class="form-horizontal" method="post" id="enviarEmail" runat="server">
                    <div class="form-group">

                        <input type="email" class="form-control login-field" value="" placeholder="Correo" id="correo" runat="server">
                        <label for="login-name" class="login-name"><i class="fa fa-envelope"></i></label>
                    </div>

                    <div class="form-group">
                        <input type="text" class="form-control login-field" value="" placeholder="Usuario" id="usuario" runat="server">
                        <label for="login-pass" class="login-pass"><i class="glyphicon glyphicon-user"></i></label>
                    </div>

                    <div class="form-group">
                        <button type="button" id="LoginButton" runat="server" name="go" class="btn btn-lg btn-block btn-wiggle" onserverclick="Validar_Correo">Aceptar</button>
                        <button type="button" id="volverLogin" runat="server" name="go" class="btn btn-lg btn-block btn-wiggle"  onserverclick="VolverBtn">Volver</button>
                    </div>

                    <asp:Label ID="mensaje" runat="server" class="login-box-msg" Style="color: #FFFFFF;" />
                    <asp:RegularExpressionValidator
                        ID="regexEmailValid"
                        runat="server"
                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="correo"
                        ErrorMessage="Formato de correo invalido"
                        ForeColor="White">
                    </asp:RegularExpressionValidator>
                </form>
            </div>
            <!--login-form-->


            <a>Copyright © 2016 Tangerine.</a>
        </div>
        <!--container-->

    </div>


    <!-- jQuery 2.1.4 -->
    <script src="../../plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="../../bootstrap/js/bootstrap.min.js"></script>

    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
        var ancho = $('.form-group').width();
        $('input[type="email"]').css("width", ancho);
        $('input[type="text"]').css("width", ancho);
        $(window).resize(function () {
            var ancho = $('.form-group').width();
            $('input[type="email"]').css("width", ancho);
            $('input[type="text"]').css("width", ancho);
        });
    </script>
</body>
</html>
