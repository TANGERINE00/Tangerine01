using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.InterfazDAO.M7
{
    public interface IDaoProyecto : IDao<Entidad, bool, Entidad>
    {
        bool DeleteProyecto(Entidad proyecto);

        List<Entidad> ContactProyectoxAcuerdoPago();

        List<Entidad> ContactProyectoPorEmpleado(Entidad empleado);

        List<Entidad> ContactProyectoPorGerente (Entidad empleado);

        Entidad ContactNombrePropuestaId(Entidad proupesta);

        int ContactMaxIdProyecto();

    }
}
