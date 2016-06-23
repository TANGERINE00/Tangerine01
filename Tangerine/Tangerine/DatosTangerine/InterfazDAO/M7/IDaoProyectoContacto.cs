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

        List<Entidad> ContactCompany(Entidad contacto);
    }
}
