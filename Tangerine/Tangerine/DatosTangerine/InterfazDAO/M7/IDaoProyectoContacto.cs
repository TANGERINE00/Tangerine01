using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.InterfazDAO.M7
{
    public interface IDaoProyectoContacto : IDao
    {

        List<Entidad> ContactCompany(Entidad contacto);
        List<Entidad> ObtenerListaContactos(Entidad proyecto);
        Boolean ElimminarContactos(Entidad proyecto);
    }
}
