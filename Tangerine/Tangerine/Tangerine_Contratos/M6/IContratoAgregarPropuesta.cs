using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M6
{
    public interface IContratoAgregarPropuesta
    {



        DropDownList ComboCompania
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
        DropDownList TipoCosto
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
        string CantidadCuotas
        {
            get;
        }
        DropDownList ComboStatus
        {
            get;
            set;
        }
        string alertaClase 
        { 
            set; 
        }
        string alertaRol 
        { 
            set; 
        }
        string alerta 
        { 
            set; 
        }
    }
}