using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.InterfazDAO.M7
{
    public interface IDaoProyecto : IDao
    {

        List<Entidad> ContactProyectoxAcuerdoPago();

        Entidad ContactNombrePropuestaId(Entidad proupesta);

        int ContactMaxIdProyecto();

        Double CalcularPagoMensual(Entidad parametro);

        String GenerarCodigoProyecto(Entidad parametro);

    }
}
