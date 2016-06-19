using DominioTangerine;
using LogicaTangerine.M5;
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

        public void BtnaceptarContrato()
        {
            Contacto contact = new Contacto(_vista.input_nombre, _vista.input_apellido, _vista.input_departamento,
               _vista.input_cargo, _vista.input_telefono, _vista.input_correo, _vista.GetTypeComp, _vista.GetIdComp);
            LogicaM5 contactLogic = new LogicaM5();
            contactLogic.AddNewContact(contact);

        }

    }
}
