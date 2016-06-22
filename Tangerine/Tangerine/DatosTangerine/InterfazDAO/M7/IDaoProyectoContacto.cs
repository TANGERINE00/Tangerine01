using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.InterfazDAO.M7
{
    public interface IDaoProyectoContacto : IDao<Entidad, bool, Entidad>
    {
        bool ContactProyectoContacto(Entidad proyecto);

        /// <summary> Firma de Método para eliminar asociacion entre contactos y un proyecto </summary>
        /// <param name="proyecto">entidad de tipo proyecto</param>
        /// <returns>Retorna true cuando se elimina exitosamente</returns>
        bool DeleteProyectoContacto(Entidad proyecto);

        List<Entidad> ContactCompany(Entidad contacto);
    }
}
