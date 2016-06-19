using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M4
{
    public interface IContratoInformacionCompania
    {
        Label NombreCompania { get; set; }
        Label Estatus { get; set; }
        Label Acronimo { get; set; }
        Label PlazoDePagos { get; set; }
        Label RIF { get; set; }
        Label Presupuesto { get; set; }
        Label Direccion { get; set; }
        Label Correo { get; set; }
        Label Telefono { get; set; }
        Label Fecha { get; set; }
    }
}
