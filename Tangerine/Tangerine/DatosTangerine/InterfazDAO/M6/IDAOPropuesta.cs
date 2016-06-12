using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M6;

namespace DatosTangerine.InterfazDAO.M6
{
    public interface IDAOPropuesta
    {
        bool AgregarPropuesta(Propuesta laPropuesta);

        bool AgregarRequerimiento(Requerimiento elRequerimiento);

        List<Propuesta> PropuestaProyecto();

        List<Propuesta> ListarLasPropuestas();

        List<Requerimiento> ConsultarRequerimientosPorPropuesta(String id);

        Propuesta ConsultarPropuestaporNombre(String id);

        Boolean BorrarPropuesta(string nombrePropuesta);

        Boolean Modificar_Requerimiento(Requerimiento elrequerimiento);

        Boolean Modificar_Propuesta(Propuesta propuesta);
    }
}