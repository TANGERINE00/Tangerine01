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
    public class PresentadorModificarContacto
    {
        private IContratoModificarContacto _vista;

        public PresentadorModificarContacto (IContratoModificarContacto vista)
        {
            this._vista = vista;    
        }


        public void cargar_pagina() 
        {
            int idcont = _vista.GetidCont;
            _vista.botonVolver = _vista.CargarBotonVolver(_vista.GetTypeComp, _vista.GetIdComp);

        }
        public void noPost_pagina()
        {
            int idcont = _vista.GetidCont;
            Contacto contacto = new Contacto();
            contacto.IdContacto = idcont;
            LogicaM5 contactLogic = new LogicaM5();
            contacto = contactLogic.SearchContact(contacto);
            _vista.input_nombre = contacto.Nombre;
            _vista.input_apellido = contacto.Apellido;
            _vista.input_cargo = contacto.Cargo;
            _vista.input_correo = contacto.Correo;
            _vista.input_departamento = contacto.Departamento;
            _vista.input_telefono = contacto.Telefono;
             
        }
        public void Event_btnmodificar_Click() 
        {
            Contacto contact = new Contacto();
            contact.IdContacto = _vista.GetidCont;
            contact.Nombre = _vista.input_nombre;
            contact.Apellido = _vista.input_apellido;
            contact.Cargo = _vista.input_cargo;
            contact.Correo = _vista.input_correo;
            contact.Departamento = _vista.input_departamento;
            contact.Telefono = _vista.input_telefono;
            LogicaM5 contactLogic = new LogicaM5();
            contactLogic.ChangeContact(contact);
            _vista.BotonAceptar(_vista.GetTypeComp, _vista.GetIdComp);

        }
    }
}
