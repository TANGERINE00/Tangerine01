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

        bool DeleteProyectoContacto(Entidad proyecto);

        List<Entidad> ContactCompany(Entidad contacto);
    }
}
