using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M6
{
    public interface IContratoModificarPropuesta
    {

        Literal Requerimientos
        {
            get;
            set;
        }

        string IdPropuesta
        {
            get;

        }
        string ContenedorCompania
        {
            get;
            set;
        }
        string IdCompania
        {
            get;
        }
        string Descripcion
        {
            get;
            set;
        }
        string ComboDuracion
        {
            get;
            set;
        }
        string TextoDuracion
        {
            get;
            set;
        }
        string DatePickerUno
        {
            get;
            set;
        }
        string DatePickerDos
        {
            get;
            set;
        }
        string TipoCosto
        {
            get;
            set;
        }

        string TextoCosto
        {
            get;
            set;
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
