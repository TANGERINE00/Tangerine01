using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M6
{
    public interface IContratoAgregarPropuesta
    {



        string ComboCompania
        {
            get;
            set;
        }
        string IdCompania
        {
            get;
            set;
        }
        string Descripcion
        {
            get;
        }
        string ArrPrecondicion
        {
            get;
        }
        string ComboDuracion
        {
            get;
            set;
        }
        string TextoDuracion
        {
            get;
        }
        string DatePickerUno
        {
            get;
        }
        string DatePickerDos
        {
            get;
        }
        string TipoCosto
        {
            get;
            set;
        }

        string TextoCosto
        {
            get;
        }
        string FormaPago
        {
            get;
            set;
        }
        string ComboCuota
        {
            get;
            set;
        }
        string ComboStatus
        {
            get;
            set;
        }



    }
}