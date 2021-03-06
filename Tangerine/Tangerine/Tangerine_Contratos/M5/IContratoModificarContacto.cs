﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M5
{
    public interface IContratoModificarContacto
    {
        string botonVolver { get; set; }
        int GetTypeComp();
        int GetIdComp();
        int GetidCont();
        string CargarBotonVolver( int typeComp, int idComp );
        string input_nombre { get; set; }
        string input_apellido { get; set; }
        string input_correo { get; set; }
        string item_cargo { get; set; }
        string input_departamento { get; set; }
        string input_telefono { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
        void BotonAceptar( int typeComp, int idComp );

    }
}
