using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.InterfazDAO.M7
{
    public interface IDaoProyectoEmpleado : IDao<Entidad, bool, Entidad>
    {
        bool ContactProyectoEmpleado(Entidad proyecto);

        bool DeleteProyectoEmpleado(Entidad proyecto);

        List<Entidad> ConsultarTodosProgramadores();

        bool ObtenerListaEmpleados(Entidad proyecto);

        Boolean AgregarProyectoEmpleados(Entidad proyecto, Entidad empleado);
    }
}
