using DominioTangerine;
using LogicaTangerine.M3;
using LogicaTangerine.M4;
using LogicaTangerine.M5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M5;

namespace Tangerine_Presentador.M5
{
    public class PresentadorConsultarContactos
    {
        LogicaM4 _logicM4 = new LogicaM4();
        LogicaM3 _logicM3 = new LogicaM3();
        LogicaM5 _logicM5 = new LogicaM5();
        private IContratoConsultarContactos _vista;

        public PresentadorConsultarContactos(IContratoConsultarContactos vista)
        {
            this._vista = vista;
        }
        public void CargarBotonVolver(int typeComp, int idComp)
        {
            if (typeComp == 1)
            {
                Compania compania = _logicM4.ConsultCompany(idComp);
                _vista.botonVolver = _vista.botonVolverCompania();
                _vista.nombreEmpresa = _vista.empresaGen() + compania.NombreCompania;
            }
            else
            {
                ClientePotencial cliPotencial = _logicM3.BuscarClientePotencial(idComp);
                _vista.botonVolver = _vista.botonVolverLead();
                _vista.nombreEmpresa = _vista.leadGen() + cliPotencial.NombreClientePotencial;
            }
        }

        public void EliminarContacto()
        {
            try
            {
                int id = _vista.idCont();
                Contacto contacto = new Contacto();
                contacto.IdContacto= id;
                _logicM5.DeleteContact(contacto);
            }
            
            catch (Exception ex)
            {
                //No se hace nada,  ya que el idCont no es un parametro obligatorio
            }

        }
        public void alertas ()
        {
        try
            {
                int status = _vista.statusAccion();

                switch (status)
                {
                    case 1:
                        _vista.Alerta(_vista.ContactoAgregadoMsj(), _vista.statusAgregado());
                        break;
                    case 2:
                        _vista.Alerta(_vista.ContadoModificadoMsj(), _vista.statusAgregado());
                        break;
                    case 3:
                        _vista.Alerta(_vista.ContactoEliminadoMsj(), _vista.statusAgregado());
                        break;
                }
            }
            catch (Exception ex)
            {
                //No se hace nada,  ya que el status no es un parametro obligatorio
            } 
        }

        public void LlenarTablaContactos()
        {
            try
            {
                List<Contacto> _listContact;
                _listContact = _logicM5.GetContacts(_vista.GetTypeComp, _vista.GetIdComp);
                foreach (Contacto _contacto2 in _listContact)
                {
                   _vista.LlenarTabla(_contacto2, _vista.GetTypeComp, _vista.GetIdComp);
                }
                _vista.CargarBotonNuevoContacto(_vista.GetTypeComp, _vista.GetIdComp);
            }
            catch (Exception ex)
            {
                _vista.Alerta(ex.Message,int.Parse(_vista.StatusModificado()));


            }
        }

        public void cargar_pagina()
        {
            CargarBotonVolver(_vista.GetTypeComp, _vista.GetIdComp);
            EliminarContacto();
            alertas();
            LlenarTablaContactos();
        }




    


    }
}
