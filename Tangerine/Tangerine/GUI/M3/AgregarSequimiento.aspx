<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AgregarSequimiento.aspx.cs" Inherits="Tangerine.GUI.M3.AgregarSequimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de leads
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Nuevo registro de seguimiento
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Leads</a></li>
    <li class="active">Seguimiento de llamadas y visitas Lead</li>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
<div class="row">
    <div class="col-lg-6 col-md-6 col-xs-12">
        <div class="box box-info">
            <br /><br />
            <form role="form" name="modificar_lead" id="modificar_lead" method="post"   runat="server">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-xs-12">
                            <div class="form-group">
                                <label for="SelectedListType">Tipo de Seguimiento</label> <label for="Requerido" style="color: red;">*</label>
                                <asp:DropDownList runat="server" CssClass="form-control" ID="SelecteTipo" OnTextChanged="SelectedType_Change">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-xs-12">
                            <div class="form-group">
                                <label for="">Fecha de registro</label>
                                <input runat="server" type="Text" class="form-control" ID="fechaActual" disabled>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-xs-12">
                            <div class="form-group">
                            <label for="Descripcion">Motivo del seguimiento</label>
                            <textarea class="form-control" rows="3" runat="server" id="motivo" 
                                pattern="^[a-zA-Z'.\s]{1,40}$"
                                required oninvalid="setCustomValidity('Campo obligatorio')" 
                                oninput="setCustomValidity()" onchange="validarTextArea(this.id)"
                                placeholder="Motivo (solo 150 caracteres)" maxlength="150"></textarea>
                         </div>
                        </div>
                    </div>
                    <asp:Button id="Button1" style="margin-top:5%" class="btn btn-primary" OnClick="btnaceptar_Click" type="submit" runat="server" Text = "Agregar"   ></asp:Button><br /><br />
                </div>
            </form>
        </div>
    </div>
</div>
    <script type="text/javascript">
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
    </script>
</asp:Content>