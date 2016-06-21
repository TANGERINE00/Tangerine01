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
        /// <summary> Firma de Método para eliminar un proyecto </summary>
        /// <param name="proyecto"> entidad de tipo proyecto</param>
        /// <returns>Retorna true cuando se elimina exitosamente</returns>
        bool DeleteProyecto(Entidad proyecto);

        List<Entidad> ContactProyectoxAcuerdoPago();

        List<Entidad> ContactProyectoPorEmpleado(Entidad empleado);

        List<Entidad> ContactProyectoPorGerente (Entidad empleado);

        Entidad ContactNombrePropuestaId(Entidad proupesta);

        int ContactMaxIdProyecto();

        Double CalcularPagoMensual(Entidad parametro);

        String GenerarCodigoProyecto(Entidad parametro);

    }
}
