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
        /// <summary> Firma de Método para consultar el contacto de un proyecto </summary>
        /// <param name="proyecto"> entidad de tipo proyecto </param>
        /// <returns> Retorna true cuando se consigue el contacto </returns>
        bool ContactProyectoEmpleado(Entidad proyecto);

        /// <summary> Firma de Método para eliminar asociacion entre empleado y un proyecto </summary>
        /// <param name="proyecto"> entidad de tipo proyecto </param>
        /// <returns> Retorna true cuando se elimina exitosamente </returns>
        bool DeleteProyectoEmpleado(Entidad proyecto);

        /// <summary> Firma de Método para consultar todos los programadores en la base de datos </summary>
        /// <returns> Retorna Lista de Entidad Empleado </returns>
        List<Entidad> ConsultarTodosProgramadores();

        bool ObtenerListaEmpleados(Entidad proyecto);

        /// <summary> Firma de Método para agregar asociacion entre empleado y un proyecto </summary>
        /// <param name="proyecto"> entidad de tipo proyecto </param>
        /// <param name="empleado"> entidad de tipo empleado </param>
        /// <returns> Retorna true cuando se agrega exitosamente </returns>
        Boolean AgregarProyectoEmpleados(Entidad proyecto, Entidad empleado);
    }
}
