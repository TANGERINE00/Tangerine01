<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContraseñaPregunta.aspx.cs" Inherits="Tangerine.GUI.M1.RecuperarContraseñaPregunta" %>

<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>AdminLTE 2 | Log in</title>
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

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>
  <body class="hold-transition login-page" style="background: #3c8dbc;">
    <div class="login-box" >
    
        <div class="login-logo">
          <a href="#"><h1>Tangerine</h1></a>
        </div>

        <div class="login-box-body " style=" background: black; box-shadow:  0px 0px 40px #000000;">
          <p class="login-box-msg">Responda las siguientes preguntas</p>

          <form action="../../index2.html" method="post" style="text-align: center;">
            <div class="form-group has-feedback">
              <input type="text" class="form-control" placeholder="Número de contrato">
            </div>
            <div class="form-group has-feedback">
              <input type="email" class="form-control" placeholder="Correo personal">
            </div>
            <div class="form-group has-feedback">
              <input type="text" class="form-control" placeholder="Pregunta de seguridad">
            </div>
            <div class="row">
              <div class="col-xs-12 col-md-6 col-lg-6">
                <button type="submit" class="btn btn-default">Aceptar</button>
              </div>
              <div class="col-xs-12 col-md-6 col-lg-6">
                <a href="Login.aspx" type="button" class="btn btn-default">Cancelar</a>
              </div>
            </div>
          </form>
          <!-- /.social-auth-links -->
          
        </div>
     </div>

    <!-- jQuery 2.1.4 -->
    <script src="../../plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="../../bootstrap/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="../../plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
    </script>
  </body>
</html>

