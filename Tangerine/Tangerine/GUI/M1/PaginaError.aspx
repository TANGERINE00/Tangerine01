<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaError.aspx.cs" Inherits="Tangerine.GUI.M1.PaginaError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/PagError.css" rel="stylesheet" />
</head>
<body>
    <div id="clouds">
            <div class="cloud x1"></div>
            <div class="cloud x1_5"></div>
            <div class="cloud x2"></div>
            <div class="cloud x3"></div>
            <div class="cloud x4"></div>
            <div class="cloud x5"></div>
        </div>
        <div class='c'>
            <div class='_404'>503</div>
            <hr>
            <div class='_1'>LO SENTIMOS</div>
            <div class='_2'>LA PAGINA NO PUDO SER SOLICITADA</div>
            <a class='btn'runat="server"  href='Login.aspx'>Volver al Login </a>

        </div>
</body>
</html>
