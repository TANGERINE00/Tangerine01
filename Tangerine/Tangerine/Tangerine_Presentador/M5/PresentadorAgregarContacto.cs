using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M5;

namespace Tangerine_Presentador.M5
{
    public class PresentadorAgregarContacto
    {
        string _nombre = String.Empty;
        string _apellido = String.Empty;
        string _departamento = String.Empty;
        string _cargo = String.Empty;
        string _telefono = String.Empty;
        string _correo = String.Empty;
        int typeComp;
        int idComp;
        string volverCC;
        private IContratoAgregarContacto _vista;

        public PresentadorAgregarContacto(IContratoAgregarContacto vista)
        {
            this._vista = vista;
        }
        public void cargar_pagina()
        {

            _vista.botonVolver = _vista.CargarBotonVolver(_vista.GetTypeComp, _vista.GetIdComp);

        }

    }
}
