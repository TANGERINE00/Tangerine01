using DominioTangerine.Entidades.M5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M5
{
    public interface IContratoConsultarContactos
    {
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
        Literal contact { get; set; }
        string botonVolver { get; set; }
        string button { get; set; }
        string nombreEmpresa { get; set; }
        int getTypeComp();
        int getIdComp();
        int IdCont();
        int StatusAccion();
        string CargarBotonNuevoContacto( int typeComp, int idComp );
    }
}
