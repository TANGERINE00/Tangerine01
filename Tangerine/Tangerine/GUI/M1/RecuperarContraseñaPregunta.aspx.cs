﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M1;
using LogicaTangerine.M8;

namespace Tangerine.GUI.M1
{
    public partial class RecuperarContraseñaPregunta : System.Web.UI.Page
    {
        LogicaM1 _logicaM1 = new LogicaM1();
        string _correo = String.Empty;
        string _usuario = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Validar_Correo(object sender, EventArgs e)
        {
            Usuario nuevoUsuario = new Usuario();
            _correo = correo.Value.ToString();
            _usuario = usuario.Value.ToString();

            if (_logicaM1.ValidarCorreoUsuario(_correo, _usuario))
            {
                //mensaje.Text = "Correcto";
                string nueva = _logicaM1.GenerarNuevaContrasena(_correo, _usuario);
                CorreoM8 correoEnvio = new CorreoM8();

                correoEnvio.enviarCorreoGmail("Cambio contraseña tangerine", _correo, nueva);

                mensaje.Text = nueva;
            }
            else
            {
                mensaje.Text = "Datos incorrectos, comuniquese con el administrador del sistema.";
            }

        }
    }
}