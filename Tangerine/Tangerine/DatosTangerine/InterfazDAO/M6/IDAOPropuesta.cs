 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M6;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M6
{
    public interface IDAOPropuesta : IDao
    {
   
        Boolean BorrarPropuesta(string nombrePropuesta);

        List<Entidad> PropuestaProyecto();

        int ConsultarNumeroPropuestas();
    }
}